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
        }


        // Método para cargar la lista de profesores en la vista
        public void CargarListaProfesores()
        {
            var profesores = _crudProfesor.ObtenerProfesoresRegistrados();
            _profesorVista.ActualizarListaProfesores(profesores);
        }


        // Método para agregar un profesor desde la vista
        public void AgregarProfesor(string nombre, string apellido, string dni, string correo, string direccion, string telefono)
        {
            string mensaje = _crudProfesor.RegistrarProfesor(nombre, apellido, dni, correo, direccion, telefono);
            _profesorVista.MostrarMensaje(mensaje);
            CargarListaProfesores(); // Actualizar la lista después de agregar un profesor
        }


        // Método para eliminar un profesor desde la vista
        public void EliminarProfesor(int legajoProfesor)
        {
            _crudProfesor.EliminarProfesor(legajoProfesor);
            CargarListaProfesores(); // Actualizar la lista después de eliminar un profesor
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

        // Otros métodos según sea necesario
    }


}
