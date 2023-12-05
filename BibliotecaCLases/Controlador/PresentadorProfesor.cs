using BibliotecaCLases.Interfaces;
using BibliotecaCLases.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.Controlador
{

  
    public class PresentadorProfesor
    {
        public int LegajoObtenido { get; set; }
        public int codigoCursoObtenido { get; set; }
        private readonly IProfesorVista _profesorVista;
        private readonly CrudProfesor _crudProfesor;

        public PresentadorProfesor(IProfesorVista profesorVista)
        {
            _profesorVista = profesorVista;
            _crudProfesor = new();
       
            profesorVista.OnEliminarProfesorSolicitada += () => EliminarProfesor();


        }  
        public Dictionary<int, Tuple<string, string, string, List<string>>> CargarAsignaturasDeProfesor()
        {
            return _crudProfesor.ObtenerAsignaturas();
        }
        public void AgregarCursoAProfesor()
        {
            string mensajeError = "Algo Salio mal!";
            _crudProfesor.AgregarCursoAProfesor(LegajoObtenido,codigoCursoObtenido,out mensajeError);
            _profesorVista.MostrarMensaje(mensajeError);
        }    
        public void AgregarProfesor()
        {

            Profesor profesor = _profesorVista.ObtenerDatosNuevoProfesor();
            GestorRegistroProfesores gestorRegistroProfesores = new(profesor);
            if (gestorRegistroProfesores.Validado && gestorRegistroProfesores.VerificarDatosExistentes())
            {
                string mensaje = gestorRegistroProfesores.RegistrarProfesor();
                _profesorVista.MostrarMensaje(mensaje);
                _profesorVista.MostrarMensaje("Profesor registrado exitosamente.");
                _profesorVista.RecargarPrograma();

            }
            else
            {
                _profesorVista.MostrarMensaje(gestorRegistroProfesores.MensajeError);
            }
        }
        public void EliminarProfesor()
        {
            string mensaje = _crudProfesor.EliminarProfesor(LegajoObtenido);
            _profesorVista.MostrarMensaje(mensaje);
            _profesorVista.RecargarPrograma();
        }
        public void CargarCursosAsignados(int legajoProfesor)
        {
            Profesor profesor = _crudProfesor.ObtenerProfesorPorLegajo(legajoProfesor);

            if (profesor != null)
            {
                //_profesorVista.ActualizarCursosAsignados(profesor.CursosAsignados);
            }
            else
            {
                _profesorVista.MostrarMensaje("Profesor no encontrado.");
            }
        }

    }


}
