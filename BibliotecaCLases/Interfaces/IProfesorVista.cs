using BibliotecaCLases.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.Interfaces
{
    public interface IProfesorVista
    {
        /// <summary>
        /// Muestra un mensaje en la vista.
        /// </summary>
        /// <param name="mensaje">Mensaje a mostrar.</param>
        void MostrarMensaje(string mensaje);
        public void CargarListaProfesores(List<Profesor> profesores);
        public void ActualizarListaProfesores(List<Profesor> profesores);
        public void ActualizarCursosAsignados(List<string> cursosAsignados);
        
    }
}
