using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotecaCLases.DataBase;
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
        DBEstudiantes dBEstudiante = new DBEstudiantes();
        DBGeneric dBGeneric = new DBGeneric();
        DBConceptoPago _dBConceptoCurso = new DBConceptoPago();
        DBCursosInscriptos _dBCursosInscriptos = new DBCursosInscriptos();

        public CrudEstudiante()
        {
            crudCurso = new CrudCurso();
        }

        public bool AgregarCursoAEstudiante(int legajoEstudiante, string codigoCurso, out string mensajeError)
        {
            Estudiante estudiante = ObtenerEstudiantePorLegajo(legajoEstudiante);
            int.TryParse(codigoCurso, out int codigo);
            if (estudiante != null)
            {
                if (_dBCursosInscriptos.VerificaCodigo(codigo, legajoEstudiante))
                {
                    mensajeError = "El estudiante ya está inscrito en este curso.";
                    return false;
                }

                string mensaje = crudCurso.InscribirEstudianteEnCurso(codigoCurso, legajoEstudiante);

                if (mensaje == "Inscripción exitosa.")
                {
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
            if (dBEstudiante.VerificaMail(correo))
            {
                return 1;
            }
            if (dBGeneric.AutenticarUsuario(dni, "Estudiante"))
            {
                return 2;
            }

            return 0;
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


        public string RegistrarEstudiante(string nombre, string apellido, string dni, string correo, string direccion, string telefono, int debeCambiar)
        {
            string claveProvisional = GenerarContrasenaAleatoria(7, 12);
            string mensaje = Email.SendMessageSmtp(correo, claveProvisional, nombre, apellido);
            String contrasena = PasswordHashing.GetHash(claveProvisional.ToString());
            Estudiante nuevoEstudiante = new Estudiante(nombre, apellido, dni, correo, direccion, telefono, contrasena, debeCambiar);
            dBEstudiante.Guardar(nuevoEstudiante);
            Estudiante estudianteRegistrado = dBEstudiante.TraeEstudiantePorDNI(dni);
            _dBConceptoCurso.Guardar(estudianteRegistrado.Legajo);
            return mensaje;
        }

        public List<Estudiante> ObtenerEstudiantesRegistrados()
        {           
            List<Estudiante> estudiantes = dBEstudiante.ObtenerTodosLosEstudiantes();
            return estudiantes;
        }
        public Estudiante ObtenerEstudiantePorLegajo(int legajo)
        {
            return dBEstudiante.TraeEstudiantePorLegajo(legajo);
        }
    }
}
