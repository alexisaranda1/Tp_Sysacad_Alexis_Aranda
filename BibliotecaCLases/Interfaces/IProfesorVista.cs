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
        /// Evento que se dispara al solicitar la lista de Profesores.
        /// </summary>
        event Action OnListaProfesoresPedida;
        event Action OnAgragarProfesor;
        event Action OnEliminarProfesorSolicitada;
        public event Action OnEditarProfesorSolicitada;


        /// <summary>
        /// Obtiene los datos ingresados para agregar un profesor.
        /// </summary>
        /// <returns>Un objeto Profesor con los datos ingresados.</returns>
        Profesor ObtenerDatosNuevoProfesor();
        void RecargarPrograma();
        /// <summary>
        /// Muestra un mensaje en la vista.
        /// </summary>
        /// <param name="mensaje">Mensaje a mostrar.</param>
        void MostrarMensaje(string mensaje);
        public void CargarListaProfesores(List<Profesor> profesores);
       
        public void ActualizarCursosAsignados(List<string> cursosAsignados);
        
    }
}
