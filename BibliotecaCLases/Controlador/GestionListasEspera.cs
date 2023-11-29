using BibliotecaCLases.Modelo;
using BibliotecaCLases.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.Controlador
{
    public class GestionListasEspera
    {
  
        private List<ListaEspera> _listasEspera;
        Serializador serializador = new Serializador();
        private string _path;
        public GestionListasEspera()
        {
            _path = PathManager.ObtenerRuta("Data", "listasEspera.json");
            _listasEspera = serializador.LeerJson<List<ListaEspera>>(_path) ?? new List<ListaEspera>();

        }
        public void AgregarCurso(string codigoCurso)
        {
            // Verificar si ya existe una lista de espera para el curso
            if (!ExisteListaEspera(codigoCurso))
            {
                ListaEspera nuevaListaEspera = new ListaEspera(codigoCurso);
                _listasEspera.Add(nuevaListaEspera);
                serializador.ActualizarJson(_listasEspera, _path);
            }
        }
        public void ActualizarCodigoCurso(string codigoViejo, string nuevoCodigo)
        {
            foreach (var listaEspera in _listasEspera)
            {
                if (listaEspera.CodigoCurso == codigoViejo)
                {
                    listaEspera.CodigoCurso = nuevoCodigo;
                    serializador.ActualizarJson(_listasEspera, _path);
                    return;
                }
            }
        }


        public List<string> ObtenerCursosConListaEspera()
        {
            
            return _listasEspera.Select(lista => lista.CodigoCurso).ToList();
        }

        public List<int> ObtenerListaEspera(string codigoCurso)
        {

            ListaEspera listaEspera = ObtenerListaEsperaPorCodigo(codigoCurso);
            List<int> listaLegados = listaEspera.LegajosEnEspera;
            return listaLegados;
        }
        public void AgregarEstudianteAListaEspera(string codigoCurso, int legajo)
        {
            var listaEsperaModificada = ObtenerListaEsperaPorCodigo(codigoCurso);

            if (listaEsperaModificada != null)
            {
                // Agrega el estudiante a la lista específica
                listaEsperaModificada.AgregarEstudiante(legajo);

                // Reemplaza la lista específica en la lista completa
                //listasEspera.RemoveAll(lista => lista.CodigoCurso == codigoCurso);
                //listasEspera.Add(listaEsperaModificada);

                // O, alternativamente
                _listasEspera.Remove(listaEsperaModificada);
                _listasEspera.Add(listaEsperaModificada);

                // Actualiza y guarda la lista completa
                serializador.ActualizarJson(_listasEspera, _path);
            }
        }



        private List<ListaEspera> ObtenerListasEspera()
        {
            return serializador.LeerJson<List<ListaEspera>>(_path) ?? new List<ListaEspera>();
        }



        public void EliminarEstudianteDeListaEspera(string codigoCurso, int legajo)
        {
            var listaEspera = ObtenerListaEsperaPorCodigo(codigoCurso);

            if (listaEspera != null)
            {
                listaEspera.EliminarEstudiante(legajo);

              
                serializador.ActualizarJson(_listasEspera, _path);
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



