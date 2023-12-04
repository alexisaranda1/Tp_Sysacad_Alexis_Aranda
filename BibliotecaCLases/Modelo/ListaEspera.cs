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
        public int LegajosEnEspera { get; set; }

        /// <summary>
        /// Obtiene o establece la lista de fechas de solicitud de los estudiantes en espera.
        /// </summary>
        public string FechasSolicitud { get; set; }

        /// <summary>
        /// Constructor de la clase ListaEspera.
        /// </summary>
        /// <param name="codigoCurso">Código del curso asociado a la lista de espera.</param>
        public ListaEspera(string codigoCurso,int legajoEstudiante,string date)
        {
            CodigoCurso = codigoCurso;

            LegajosEnEspera = legajoEstudiante;
            FechasSolicitud = date;
        }


        /// <summary>
        /// Obtiene una copia de la lista de legajos de estudiantes en espera.
        /// </summary>
        /// <returns>Lista de legajos de estudiantes en espera.</returns>
        public List<int> ObtenerLegajosEnEspera()
        {
            return new List<int>(LegajosEnEspera);
        }
    }
}
