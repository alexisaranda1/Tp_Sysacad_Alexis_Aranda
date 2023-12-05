using BibliotecaCLases.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.Controlador
{
   
    public class GestorAccionesProfesor
    {
        public int LegajoProfesor { get; set; }
        public int codigoCursoObtenido { get; set; }
        public int LegajoAlumno { get; set; }

        private CrudProfesor _crudProfesor;

        public GestorAccionesProfesor ()
        {
            _crudProfesor = new CrudProfesor ();            
        }
        
        public List<Curso> ObtenerCursosACargo()
        {
            return _crudProfesor.ObtenerCursosACargo(LegajoProfesor);
        }
        public List<Estudiante> ObtenerEstudiantesIncriptos()
        {
            return _crudProfesor.ObtenerEstudiantesInscriptos(codigoCursoObtenido);
        }

        public bool MandaAGuardarNotas(string tipoEvaluacion, int nota)
        {
            ConceptoNota concepto = new ConceptoNota(tipoEvaluacion, nota, LegajoAlumno, codigoCursoObtenido);
            return _crudProfesor.GuardaLaNota(concepto);
        }
        public bool MandaAGuardarAsistencia(string estadoAsistencia)
        {
            ConceptoAsistencia conceptoAsistencia = new ConceptoAsistencia(estadoAsistencia, LegajoAlumno, codigoCursoObtenido);
            return _crudProfesor.GuardaLaAsistencia(conceptoAsistencia);
        }
    }
}
