using BibliotecaCLases.Interfaces;
using BibliotecaCLases.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.Controlador
{
    public class GestorRequisitosAcademicos
    {
        
        private IRequisitosAcademicosVista _vista;
        private CrudCurso _crudCurso;
        public GestorRequisitosAcademicos(IRequisitosAcademicosVista vista)
        {
            _crudCurso = new CrudCurso();
            _vista = vista;
            _vista.OnListaCursosPedida += MostrarCursos;
        }
        /// <summary>
        /// Muestra la lista de cursos en la vista.
        /// </summary>
        public void MostrarCursos()
        {
        
            var listaCursos = _crudCurso.ObtenerListaCursos();
            _vista.MostrarCursos(listaCursos);
        }
        /// <summary>
        /// Obtiene o establece el código del curso.
        /// </summary>
        public string CodigoCurso { get; set; }

        public Curso ObtenerCursoPorCodigo()
        {
            return _crudCurso.ObtenerCursoPorCodigo(CodigoCurso);
        }

    }
}
