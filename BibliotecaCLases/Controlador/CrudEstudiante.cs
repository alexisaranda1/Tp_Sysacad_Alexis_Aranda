using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotecaCLases.Modelo;
using BibliotecaCLases.Utilidades;
using static BibliotecaCLases.Modelo.Usuario;

namespace BibliotecaCLases.Controlador
{
    public class CrudEstudiante
    {       
        private string _path;
        public string pathUltimoLegajo;
        private int _ultimoLegajoEnArchivo;
        private CrudCurso crudCurso;
        private List<Estudiante> listaEstudiantesRegistrados;
        Serializador serializador = new Serializador();

        public CrudEstudiante()
        {
            listaEstudiantesRegistrados = new List<Estudiante>();
            _path = PathManager.ObtenerRuta("Data", "DataUsuarios.json");
            listaEstudiantesRegistrados = serializador.LeerJson<List<Estudiante>>(_path) ?? new List<Estudiante>();
            pathUltimoLegajo = PathManager.ObtenerRuta("Data", "Legajo.json");
            _ultimoLegajoEnArchivo = serializador.LeerJson<int>(pathUltimoLegajo);
            crudCurso = new CrudCurso();
        }

        public bool AgregarCursoAEstudiante(int legajoEstudiante, string codigoCurso, out string mensajeError)
        {
            Estudiante estudiante = ObtenerEstudiantePorLegajo(legajoEstudiante);

            if (estudiante != null)
            {
                if (estudiante.CursosInscriptos.Contains(codigoCurso))
                {
                    mensajeError = "El estudiante ya está inscrito en este curso.";
                    return false;
                }

                string mensaje = crudCurso.InscribirEstudianteEnCurso(codigoCurso);

                if (mensaje == "Inscripción exitosa.")
                {
                    estudiante.CursosInscriptos.Add(codigoCurso);
                    string path = PathManager.ObtenerRuta("Data", "DataUsuarios.json");
                    serializador.ActualizarJson(listaEstudiantesRegistrados, path);
                    mensajeError = null;
                    return true;
                }
                else
                {
                    mensajeError = mensaje;
                    return false;
                }
            }

            mensajeError = "El estudiante no se encontró.";
            return false;
        }

        public void ModificarEstudiante(Estudiante estudiante)
        {
            Estudiante estudianteAModificar = listaEstudiantesRegistrados.FirstOrDefault(e => e.Legajo == estudiante.Legajo);

            if (estudianteAModificar != null)
            {
              
                estudianteAModificar = estudiante;

                
                string path = PathManager.ObtenerRuta("Data", "DataUsuarios.json");
                serializador.ActualizarJson(listaEstudiantesRegistrados, path);
            }
        }


        public void EliminarEstudiante(int estudianteId)
        {
            Estudiante estudianteAEliminar = listaEstudiantesRegistrados.FirstOrDefault(e => e.Legajo == estudianteId);

            if (estudianteAEliminar != null)
            {
                listaEstudiantesRegistrados.Remove(estudianteAEliminar);
                string path = PathManager.ObtenerRuta("Data", "DataUsuarios.json");
                serializador.ActualizarJson(listaEstudiantesRegistrados, path);
            }
        }

        public int VerificarDatosEstudiante(string correo, string dni)
        {
            if (listaEstudiantesRegistrados != null)
            {
                if (listaEstudiantesRegistrados.Any(est => est.Correo == correo))
                {
                    return 1;
                }
                if (listaEstudiantesRegistrados.Any(est => est.Dni == dni))
                {
                    return 2;
                }
            }

            return 0;
        }

        public int ObtieneLegajo()
        {
            _ultimoLegajoEnArchivo++;
            string pathLegajo = PathManager.ObtenerRuta("Data", "Legajo.json");
            Serializador.GuardarAJson(_ultimoLegajoEnArchivo, pathLegajo);

            return _ultimoLegajoEnArchivo;
        }

        static string GenerarContrasenaAleatoria(int longitudMinima, int longitudMaxima)
        {
            const string caracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()-_+=<>?";

            Random random = new Random();
            int longitud = random.Next(longitudMinima, longitudMaxima + 1);
            StringBuilder contrasena = new StringBuilder();

            for (int i = 0; i < longitud; i++)
            {
                int indice = random.Next(caracteresPermitidos.Length);
                char caracterAleatorio = caracteresPermitidos[indice];
                contrasena.Append(caracterAleatorio);
            }

            return contrasena.ToString();
        }

        static List<ConceptoPago> GenerarConceptoPago()
        {
            List<ConceptoPago> conceptoPagos = new List<ConceptoPago>
            {
                new ConceptoPago("Noviembre", 22500),
                new ConceptoPago("Diciembre", 25000),
                new ConceptoPago("Febrero", 26000)
            };

            return conceptoPagos;
        }

        public string RegistrarEstudiante(string nombre, string apellido, string dni, string correo, string direccion, string telefono, bool debeCambiar)
        {
            int legajo = ObtieneLegajo();
            List<ConceptoPago> conceptoPagos = GenerarConceptoPago();

            string claveProvisional = GenerarContrasenaAleatoria(7, 12);
            string mensaje = Email.SendMessageSmtp(correo, claveProvisional, nombre, apellido);
            String contrasena = PasswordHashing.GetHash(claveProvisional.ToString());
            Estudiante nuevoEstudiante = new Estudiante(nombre, apellido, dni, correo, direccion, telefono, contrasena, debeCambiar, conceptoPagos);
            nuevoEstudiante.Legajo = legajo;

            listaEstudiantesRegistrados.Add(nuevoEstudiante);

            string path = PathManager.ObtenerRuta("Data", "DataUsuarios.json");
           
            serializador.ActualizarJson(listaEstudiantesRegistrados, path);

            return mensaje;
        }

        public List<Estudiante> ObtenerEstudiantesRegistrados()
        {           
            var estudiantes = listaEstudiantesRegistrados.Where(u => u.TipoUsuario == tipoUsuario.Estudiante);
         
            if (estudiantes.Any())
            {            
                return estudiantes.Cast<Estudiante>().ToList();
            }
            else
            {
                return new List<Estudiante>();
            }
        }


        public Estudiante ObtenerEstudiantePorLegajo(int legajo)
        {
            return listaEstudiantesRegistrados.FirstOrDefault(estudiante => estudiante.Legajo == legajo);
        }


    }
}
