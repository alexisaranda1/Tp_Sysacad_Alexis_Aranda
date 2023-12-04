using BibliotecaCLases.Modelo;
using System;
using System.Collections.Generic;

namespace BibliotecaCLases.Interfaces
{
    /// <summary>
    /// Interfaz que define la vista de cursos en una aplicación.
    /// </summary>
    public interface ICursoVista
    {
        /// <summary>
        /// Evento que se dispara cuando se solicita la lista de cursos.
        /// </summary>
        event Action OnListaCursosPedida;

        /// <summary>
        /// Evento que se dispara cuando se solicita la lista de estudiantes.
        /// </summary>
        event Action OnListaEstudiantePedida;

        /// <summary>
        /// Evento que se dispara cuando se solicita la lista de espera.
        /// </summary>
        event Action OnListaEsperaPedida;

        /// <summary>
        /// Evento que se dispara al agregar un estudiante a la lista de espera.
        /// </summary>
        event Action<string, int> OnAgregarEstudianteListaEspera;

        /// <summary>
        /// Evento que se dispara al eliminar un estudiante de la lista de espera.
        /// </summary>
        event Action<string, int> OnEliminarEstudianteListaEspera;

        /// <summary>
        /// Crea las columnas para mostrar la lista de cursos.
        /// </summary>
        void CrearColumnasCursos();

        /// <summary>
        /// Crea las columnas para mostrar la lista de alumnos.
        /// </summary>
        void CrearColumnasAlumno();

        /// <summary>
        /// Crea las columnas para mostrar la lista de espera.
        /// </summary>
        void CrearColumnasListaEspera();

        /// <summary>
        /// Muestra la lista de cursos en la vista.
        /// </summary>
        /// <param name="cursos">Lista de cursos a mostrar.</param>
        void MostrarCurso(List<Curso> cursos);

        /// <summary>
        /// Muestra la lista de estudiantes en la vista.
        /// </summary>
        /// <param name="estudiante">Lista de estudiantes a mostrar.</param>
        void MostrarListaEstudiante(List<Estudiante> estudiante);

        /// <summary>
        /// Muestra la lista de espera en la vista.
        /// </summary>
        /// <param name="estudiantes">Lista de estudiantes en espera.</param>
        /// <param name="listaFechas">Lista de fechas de solicitud de los estudiantes en espera.</param>
        //void MostrarListaEspera(List<Estudiante> estudiantes, List<ListaEspera> espera);
        void MostrarListaEsperas(Dictionary<Estudiante, DateTime> dict);

        /// <summary>
        /// Muestra un mensaje en la vista.
        /// </summary>
        /// <param name="mensaje">Mensaje a mostrar.</param>
        void MostrarMensaje(string mensaje);

        /// <summary>
        /// Limpia el formulario de la vista.
        /// </summary>
        void LimpiarFormulario();
    }
}
