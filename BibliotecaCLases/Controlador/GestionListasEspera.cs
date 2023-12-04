using BibliotecaCLases.DataBase;
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
        private DBListaDeEspera _dBListaDeEspera = new DBListaDeEspera();

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
            ExisteListaEspera(codigoCurso);
        }

        /// <summary>
        /// Actualiza el código de un curso en la lista de espera.
        /// </summary>
        /// <param name="codigoViejo">Código del curso a actualizar.</param>
        /// <param name="nuevoCodigo">Nuevo código del curso.</param>
        public bool ActualizarCodigoCurso(string codigoViejo, string nuevoCodigo)
        {
            return _dBListaDeEspera.ActualizarCodigo(nuevoCodigo);
        }

        /// <summary>
        /// Obtiene las fechas de solicitud para un curso específico.
        /// </summary>
        /// <param name="codigoCurso">Código del curso.</param>
        /// <returns>Lista de fechas en formato de cadena (yyyy-MM-dd).</returns>
        public List<ListaEspera> ObtenerFechas(string codigoCurso)
        {
            List<ListaEspera> listaEspera = ObtenerListaEsperaPorCodigos(codigoCurso);

            if (listaEspera == null)
            {
                return new List<ListaEspera>();
            }

            return listaEspera;
        }

        /// <summary>
        /// Obtiene la lista de espera para un curso específico.
        /// </summary>
        /// <param name="codigoCurso">Código del curso.</param>
        /// <returns>Lista de legajos en espera ordenada por fecha de solicitud.</returns>
        public List<ListaEspera> ObtenerListaEspera(string codigoCurso)
        {
            List<ListaEspera> listaEspera = ObtenerListaEsperaPorCodigos(codigoCurso);

            return listaEspera;
        }

        /// <summary>
        /// Agrega un estudiante a la lista de espera de un curso.
        /// </summary>
        /// <param name="codigoCurso">Código del curso.</param>
        /// <param name="legajo">Número de legajo del estudiante.</param>
        public bool AgregarEstudianteAListaEspera(string codigoCurso, int legajo)
        {
            if (!_dBListaDeEspera.VerificaEstudianteEnCurso(codigoCurso, legajo))
            {
                return _dBListaDeEspera.Guardar(codigoCurso,legajo);
            }
            return false;
            
        }

        /// <summary>
        /// Elimina un estudiante de la lista de espera de un curso.
        /// </summary>
        /// <param name="codigoCurso">Código del curso.</param>
        /// <param name="legajo">Número de legajo del estudiante.</param>
        public void EliminarEstudianteDeListaEspera(string codigoCurso, int legajo)
        {
            _dBListaDeEspera.Eliminar(codigoCurso, legajo);
        }

        private ListaEspera ObtenerListaEsperaPorCodigo(string codigoCurso)
        {
            return _listasEspera.FirstOrDefault(lista => lista.CodigoCurso == codigoCurso);
        }

        private List<ListaEspera> ObtenerListaEsperaPorCodigos(string codigoCurso)
        {
            return _dBListaDeEspera.ObtenerTodasLasEsperas();
        }

        private bool ExisteListaEspera(string codigoCurso)
        {
            return _dBListaDeEspera.GuardarCodigo(codigoCurso);
        }
    }
}
