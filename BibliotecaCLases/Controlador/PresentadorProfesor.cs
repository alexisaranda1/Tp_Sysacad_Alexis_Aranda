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
            private readonly IProfesorVista _profesorVista;
            private readonly CrudProfesor _crudProfesor;

        public PresentadorProfesor(IProfesorVista profesorVista)
        {
            _profesorVista = profesorVista;
            _crudProfesor = new();
            CargarListaProfesores();

        }


        // Método para cargar la lista de profesores en la vista
        public void CargarListaProfesores()
        {
            
                List<Profesor> profesores = _crudProfesor.ObtenerProfesoresRegistrados();
                //_profesorVista.ActualizarListaProfesores(profesores);
            
           
        }

        public void AgregarProfesor()
        {

            Profesor profesor = _profesorVista.ObtenerDatosNuevoProfesor();
            GestorRegistroProfesores gestorRegistroProfesores = new(profesor);
            if (gestorRegistroProfesores.Validado && gestorRegistroProfesores.VerificarDatosExistentes())
            {
                string mensaje = gestorRegistroProfesores.RegistrarProfesor();
                _profesorVista.MostrarMensaje(mensaje);
                //CargarListaProfesores();
            }
            else
            {
                _profesorVista.MostrarMensaje(gestorRegistroProfesores.MensajeError);
            }
        }
        public string EliminarProfesor(int legajoProfesor)
        {
            string mensaje = _crudProfesor.EliminarProfesor(legajoProfesor);
            //CargarListaProfesores();
            return mensaje;
        }
        public void CargarCursosAsignados(int legajoProfesor)
        {
            Profesor profesor = _crudProfesor.ObtenerProfesorPorLegajo(legajoProfesor);

            if (profesor != null)
            {
                _profesorVista.ActualizarCursosAsignados(profesor.CursosAsignados);
            }
            else
            {
                _profesorVista.MostrarMensaje("Profesor no encontrado.");
            }
        }

    }


}
