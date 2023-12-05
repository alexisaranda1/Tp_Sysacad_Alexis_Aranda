using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.Modelo
{
    public class ConceptoAsistencia
    {
        public string EstadoAsistencia { get; set; }

        public int Legajo { get; set; }

        public int CodigoCurso { get; set; }
        
        public ConceptoAsistencia(string estadoAsistencia,int legajo,int codigoCurso, string estado)
        {
            EstadoAsistencia = estadoAsistencia;
            Legajo = legajo;
            CodigoCurso = codigoCurso;
          
        }

    }
}
