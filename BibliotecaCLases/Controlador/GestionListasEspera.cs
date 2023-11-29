using BibliotecaCLases.Modelo;
using BibliotecaCLases.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BibliotecaCLases.Controlador
{
    /// <summary>
    /// Clase que gestiona las listas de espera de los cursos.
    /// </summary>
    public class GestionListasEspera
    {
        private List<ListaEspera> _listasEspera;
        private Serializador _serializador;
        private string _path;

        /// <summary>
        /// Constructor de la clase <see cref="GestionListasEspera"/>.
        /// </summary>
        public GestionListasEspera()
        {
            _serializador = new Serializador();
            _path = PathManager.ObtenerRuta("Data", "listasEspera.json");
            _listasEspera = _serializador.LeerJson<List<ListaEspera>>(_path) ?? new List<ListaEspera>();
        }

        /// <summary>
        /// Agrega un nuevo curso a la lista de espera.
        /// </summary>
        /// <param name="codigoCurso">Código del curso.</param>
        public void AgregarCurso(string codigoCurso)
        {
            if (!ExisteListaEspera(codigoCurso))
            {
                ListaEspera nuevaListaEspera = new ListaEspera(codigoCurso);
                _listasEspera.Add(nuevaListaEspera);
                _serializador.ActualizarJson(_listasEspera, _path);
            }
        }

        /// <summary>
        /// Actualiza el código de un curso en la lista de espera.
        /// </summary>
        /// <param name="codigoViejo">Código del curso a actualizar.</param>
        /// <param name="nuevoCodigo">Nuevo código del curso.</param>
        public void ActualizarCodigoCurso(string codigoViejo, string nuevoCodigo)
        {
            foreach (var listaEspera in _listasEspera)
            {
                if (listaEspera.CodigoCurso == codigoViejo)
                {
                    listaEspera.CodigoCurso = nuevoCodigo;
                    _serializador.ActualizarJson(_listasEspera, _path);
                    return;
                }
            }
        }

        /// <summary>
        /// Obtiene las fechas de solicitud para un curso específico.
        /// </summary>
        /// <param name="codigoCurso">Código del curso.</param>
        /// <returns>Lista de fechas en formato de cadena (yyyy-MM-dd).</returns>
        public List<string> ObtenerFechas(string codigoCurso)
        {
            ListaEspera listaEspera = ObtenerListaEsperaPorCodigo(codigoCurso);

            if (listaEspera?.FechasSolicitud == null)
            {
                return new List<string>();
            }

            List<string> fechasString = new List<string>();
            foreach (DateTime fecha in listaEspera.FechasSolicitud)
            {
                string fechaFormateada = fecha.ToString("yyyy-MM-dd");
                fechasString.Add(fechaFormateada);
            }

            return fechasString;
        }

        /// <summary>
        /// Obtiene la lista de espera para un curso específico.
        /// </summary>
        /// <param name="codigoCurso">Código del curso.</param>
        /// <returns>Lista de legajos en espera ordenada por fecha de solicitud.</returns>
        public List<int> ObtenerListaEspera(string codigoCurso)
        {
            ListaEspera listaEspera = ObtenerListaEsperaPorCodigo(codigoCurso);

            if (listaEspera != null)
            {
                return listaEspera.LegajosEnEspera.OrderBy(legajo =>
                {
                    int index = listaEspera.LegajosEnEspera.IndexOf(legajo);
                    if (index >= 0 && index < listaEspera.FechasSolicitud.Count)
                    {
                        return listaEspera.FechasSolicitud[index];
                    }
                    return DateTime.MinValue;
                }).ToList();
            }

            return new List<int>();
        }

        /// <summary>
        /// Agrega un estudiante a la lista de espera de un curso.
        /// </summary>
        /// <param name="codigoCurso">Código del curso.</param>
        /// <param name="legajo">Número de legajo del estudiante.</param>
        public void AgregarEstudianteAListaEspera(string codigoCurso, int legajo)
        {
            var listaEsperaModificada = ObtenerListaEsperaPorCodigo(codigoCurso);

            if (listaEsperaModificada != null)
            {
                listaEsperaModificada.AgregarEstudiante(legajo);
                _listasEspera.Remove(listaEsperaModificada);
                _listasEspera.Add(listaEsperaModificada);
                _serializador.ActualizarJson(_listasEspera, _path);
            }
        }

        /// <summary>
        /// Elimina un estudiante de la lista de espera de un curso.
        /// </summary>
        /// <param name="codigoCurso">Código del curso.</param>
        /// <param name="legajo">Número de legajo del estudiante.</param>
        public void EliminarEstudianteDeListaEspera(string codigoCurso, int legajo)
        {
            var listaEsperaModificada = ObtenerListaEsperaPorCodigo(codigoCurso);

            if (listaEsperaModificada != null)
            {
                listaEsperaModificada.EliminarEstudiante(legajo);
                _listasEspera.Remove(listaEsperaModificada);
                _listasEspera.Add(listaEsperaModificada);
                _serializador.ActualizarJson(_listasEspera, _path);
            }
        }

        private ListaEspera ObtenerListaEsperaPorCodigo(string codigoCurso)
        {
            return _listasEspera.FirstOrDefault(lista => lista.CodigoCurso == codigoCurso);
        }

        private bool ExisteListaEspera(string codigoCurso)
        {
            return _listasEspera.Any(lista => lista.CodigoCurso == codigoCurso);
        }
    }
}
