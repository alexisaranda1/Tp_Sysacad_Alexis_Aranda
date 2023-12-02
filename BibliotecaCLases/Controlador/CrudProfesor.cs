using BibliotecaCLases.Modelo;
using BibliotecaCLases.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BibliotecaCLases.Modelo.Usuario;

namespace BibliotecaCLases.Controlador
{
    public class CrudProfesor
    {
        private string _path;
        private string _pathUltimoLegajo;
        private int _ultimoLegajoEnArchivo;
        private List<Profesor> _listaProfesoresRegistrados;
        private Serializador _serializador = new();
        private CrudCurso _crudCurso;

        public CrudProfesor()
        {
            _listaProfesoresRegistrados = new List<Profesor>();
            _path = PathManager.ObtenerRuta("Data", "DataUsuariosProfesores.json");
            _listaProfesoresRegistrados = _serializador.LeerJson<List<Profesor>>(_path) ?? new List<Profesor>();
            _pathUltimoLegajo = PathManager.ObtenerRuta("Data", "LegajoProfesor.json");
            _ultimoLegajoEnArchivo = _serializador.LeerJson<int>(_pathUltimoLegajo);
            _crudCurso = new CrudCurso();
        }

        public string RegistrarProfesor(string nombre, string apellido, string dni, string correo, string direccion, string telefono)
        {
            int legajo = ObtieneLegajo();

            string claveProvisional = GenerarContrasenaAleatoria(7, 12);
            string mensaje = Email.SendMessageSmtp(correo, claveProvisional, nombre, apellido);
            String contrasena = PasswordHashing.GetHash(claveProvisional.ToString());
            Profesor nuevoProfesor = new Profesor(nombre, apellido, dni, correo, direccion, telefono, contrasena);
            nuevoProfesor.Legajo = legajo;

            _listaProfesoresRegistrados.Add(nuevoProfesor);

            string path = PathManager.ObtenerRuta("Data", "DataUsuariosProfesores.json");
            _serializador.ActualizarJson(_listaProfesoresRegistrados, path);

            return mensaje;
        }
        public void EliminarProfesor(int legajoProfesor)
        {
            Profesor profesorAEliminar = _listaProfesoresRegistrados.FirstOrDefault(profesor => profesor.Legajo == legajoProfesor);

            if (profesorAEliminar != null)
            {
                _listaProfesoresRegistrados.Remove(profesorAEliminar);
                string path = PathManager.ObtenerRuta("Data", "DataUsuariosProfesores.json");
                _serializador.ActualizarJson(_listaProfesoresRegistrados, path);
            }
            else
            {
                // Manejar el caso donde no se encuentra al profesor
            }
        }

        public List<Profesor> ObtenerProfesoresRegistrados()
        {
            var profesores = _listaProfesoresRegistrados.Where(u => u.TipoUsuario == tipoUsuario.Profesor);

            if (profesores.Any())
            {
                return profesores.Cast<Profesor>().ToList();
            }
            else
            {
                return new List<Profesor>();
            }
        }

        public Profesor ObtenerProfesorPorLegajo(int legajo)
        {
            return _listaProfesoresRegistrados.FirstOrDefault(profesor => profesor.Legajo == legajo);
        }


        //public bool AgregarCursoAProfesor(int legajoProfesor, string codigoCurso, out string mensajeError)
        //{
        //    Profesor profesor = ObtenerProfesorPorLegajo(legajoProfesor);

        //    if (profesor != null)
        //    {
        //        if (profesor.CursosAsignados.Contains(codigoCurso))
        //        {
        //            mensajeError = "El profesor ya tiene asignado este curso.";
        //            return false;
        //        }

        //        string mensaje = _crudCurso.AsignarProfesorACurso(codigoCurso);

        //        if (mensaje == "Asignación exitosa.")
        //        {
        //            profesor.CursosAsignados.Add(codigoCurso);
        //            string path = PathManager.ObtenerRuta("Data", "DataUsuariosProfesores.json");
        //            _serializador.ActualizarJson(_listaProfesoresRegistrados, path);
        //            mensajeError = null;
        //            return true;
        //        }
        //        else
        //        {
        //            mensajeError = mensaje;
        //            return false;
        //        }
        //    }

        //    mensajeError = "El profesor no se encontró.";
        //    return false;
        //}



        private int ObtieneLegajo()
        {
            _ultimoLegajoEnArchivo++;
            string pathLegajo = PathManager.ObtenerRuta("Data", "LegajoProfesor.json");
            Serializador.GuardarAJson(_ultimoLegajoEnArchivo, pathLegajo);
            return _ultimoLegajoEnArchivo;
        }

        public static string GenerarContrasenaAleatoria(int longitudMinima, int longitudMaxima)
        {
            return "";
            // ... (Código previo)
        }

 

    }

}
