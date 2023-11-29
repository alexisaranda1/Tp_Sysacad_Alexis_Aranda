using BibliotecaCLases.Utilidades;
using System;
using System.Collections.Generic;

namespace BibliotecaCLases.Modelo
{
    /// <summary>
    /// Clase que representa una lista de espera para un curso.
    /// </summary>
    public class ListaEspera
    {
        /// <summary>
        /// Obtiene o establece el código del curso asociado a la lista de espera.
        /// </summary>
        public string CodigoCurso { get; set; }

        /// <summary>
        /// Obtiene o establece la lista de legajos de estudiantes en espera.
        /// </summary>
        public List<int> LegajosEnEspera { get; set; }

        /// <summary>
        /// Obtiene o establece la lista de fechas de solicitud de los estudiantes en espera.
        /// </summary>
        public List<DateTime> FechasSolicitud { get; set; }

        /// <summary>
        /// Constructor de la clase ListaEspera.
        /// </summary>
        /// <param name="codigoCurso">Código del curso asociado a la lista de espera.</param>
        public ListaEspera(string codigoCurso)
        {
            CodigoCurso = codigoCurso;
            LegajosEnEspera = new List<int>();
            FechasSolicitud = new List<DateTime>();
        }

        /// <summary>
        /// Agrega un estudiante a la lista de espera.
        /// </summary>
        /// <param name="legajo">Legajo del estudiante que se va a agregar.</param>
        public void AgregarEstudiante(int legajo)
        {
            if (!EstudianteEnEspera(legajo))
            {
                LegajosEnEspera.Add(legajo);
                FechasSolicitud.Add(DateTime.Now.Date);
            }
        }

        /// <summary>
        /// Elimina un estudiante de la lista de espera.
        /// </summary>
        /// <param name="legajo">Legajo del estudiante que se va a eliminar.</param>
        public void EliminarEstudiante(int legajo)
        {
            int index = LegajosEnEspera.IndexOf(legajo);
            if (index != -1)
            {
                LegajosEnEspera.RemoveAt(index);
                FechasSolicitud.RemoveAt(index);
            }
        }

        /// <summary>
        /// Obtiene una copia de la lista de legajos de estudiantes en espera.
        /// </summary>
        /// <returns>Lista de legajos de estudiantes en espera.</returns>
        public List<int> ObtenerLegajosEnEspera()
        {
            return new List<int>(LegajosEnEspera);
        }

        /// <summary>
        /// Verifica si un estudiante está en la lista de espera.
        /// </summary>
        /// <param name="legajo">Legajo del estudiante a verificar.</param>
        /// <returns>True si el estudiante está en espera, False en caso contrario.</returns>
        public bool EstudianteEnEspera(int legajo)
        {
            return LegajosEnEspera.Contains(legajo);
        }
    }
}
