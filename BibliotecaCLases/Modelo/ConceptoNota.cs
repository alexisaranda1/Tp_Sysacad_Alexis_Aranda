using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.Modelo
{
    public class ConceptoNota
    {

        public string Nombre { get; set; }
        public int Nota { get; set; }
        public int Legajo { get; set; }


        public ConceptoNota(string tipoEvaluacion, int nota,int legajo)
        {
            Nombre = tipoEvaluacion;
            Nota = nota;
            Legajo = legajo;
        }

    }
}
