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

    }
}
