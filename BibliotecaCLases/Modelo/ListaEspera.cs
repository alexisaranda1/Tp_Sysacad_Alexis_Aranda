using BibliotecaCLases.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.Modelo
{

    public class ListaEspera
    {
        public string CodigoCurso { get; set; }
        public List<int> LegajosEnEspera { get; set; }

        private string _path;
        
        private Serializador serializador;


        public ListaEspera(string codigoCurso)
        {
            CodigoCurso = codigoCurso;
            LegajosEnEspera = new List<int>();
     
        }

        public void AgregarEstudiante(int legajo)
        {
            if (!EstudianteEnEspera(legajo))
            {
                LegajosEnEspera.Add(legajo);
            }
           
        }

        public void EliminarEstudiante(int legajo)
        { 
            LegajosEnEspera.Remove(legajo);
        }

        public List<int> ObtenerLegajosEnEspera()
        {
            return new List<int>(LegajosEnEspera);
        }

        public bool EstudianteEnEspera(int legajo)
        {
            return LegajosEnEspera.Contains(legajo);
        }
     


    }
}