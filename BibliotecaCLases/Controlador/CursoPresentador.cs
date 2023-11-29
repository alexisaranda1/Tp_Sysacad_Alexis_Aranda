using BibliotecaCLases.Interfaces;
using BibliotecaCLases.Modelo;
using BibliotecaCLases.Utilidades;
using System.Collections.Generic;

namespace BibliotecaCLases.Controlador
{
    /// <summary>
    /// Clase que actúa como presentador para la vista de cursos.
    /// </summary>
    public class CursoPresentador
    {
        private ICursoVista _vista;
        private CrudCurso _crudCurso;
        private CrudEstudiante _crudEstudiante;
        private GestionListasEspera _gestionListasEspera;

        /// <summary>
        /// Constructor de la clase <see cref="CursoPresentador"/>.
        /// </summary>
        /// <param name="vista">Instancia de la interfaz de la vista de cursos.</param>
        public CursoPresentador(ICursoVista vista)
        {
            _vista = vista;
            _crudCurso = new CrudCurso();
            _crudEstudiante = new CrudEstudiante();
            _gestionListasEspera = new GestionListasEspera();

            _vista.OnListaCursosPedida += MostrarCursos;
            _vista.OnListaEstudiantePedida += MostrarEstudiantes;
            _vista.OnListaEsperaPedida += _vista_MostrarListaEsperaPedida;
            _vista.OnAgregarEstudianteListaEspera += AgregarEstudianteListaEspera;
            _vista.OnEliminarEstudianteListaEspera += EliminarEstudianteListaEspera;
        }

        private void _vista_MostrarListaEsperaPedida()
        {
            _vista.CrearColumnasListaEspera();
            List<Estudiante> listaEstudiante = CargarListaEsperaEstudiante();
            List<string> listaFechas = _gestionListasEspera.ObtenerFechas(CodigoCurso);
            _vista.MostrarListaEspera(listaEstudiante, listaFechas);
        }

        /// <summary>
        /// Carga la lista de estudiantes en espera para un curso específico.
        /// </summary>
        /// <returns>Lista de estudiantes en espera.</returns>
        public List<Estudiante> CargarListaEsperaEstudiante()
        {
            List<Estudiante> estudiantes = new List<Estudiante>();
            string codigo = CodigoCurso;
            List<int> lista = _gestionListasEspera.ObtenerListaEspera(codigo);
            if (lista.Count > 0)
            {
                foreach (int legajo in lista)
                {
                    estudiantes.Add(_crudEstudiante.ObtenerEstudiantePorLegajo(legajo));
                }
            }
            return estudiantes;
        }

        /// <summary>
        /// Agrega un estudiante a la lista de espera de un curso.
        /// </summary>
        /// <param name="codigoCurso">Código del curso.</param>
        /// <param name="legajo">Número de legajo del estudiante.</param>
        public void AgregarEstudianteListaEspera(string codigoCurso, int legajo)
        {
            _gestionListasEspera.AgregarEstudianteAListaEspera(codigoCurso, legajo);
        }

        /// <summary>
        /// Elimina un estudiante de la lista de espera de un curso.
        /// </summary>
        /// <param name="codigoCurso">Código del curso.</param>
        /// <param name="legajo">Número de legajo del estudiante.</param>
        public void EliminarEstudianteListaEspera(string codigoCurso, int legajo)
        {
            _gestionListasEspera.EliminarEstudianteDeListaEspera(codigoCurso, legajo);
        }

        /// <summary>
        /// Muestra la lista de cursos en la vista.
        /// </summary>
        public void MostrarCursos()
        {
            _vista.CrearColumnasCursos();
            var listaCursos = _crudCurso.ObtenerListaCursos();
            _vista.MostrarCurso(listaCursos);
        }

        /// <summary>
        /// Muestra la lista de estudiantes en la vista.
        /// </summary>
        public void MostrarEstudiantes()
        {
            _vista.CrearColumnasAlumno();
            List<Estudiante> listaEstudiante = _crudEstudiante.ObtenerEstudiantesRegistrados();
            _vista.MostrarListaEstudiante(listaEstudiante);
        }

        /// <summary>
        /// Obtiene o establece el código del curso.
        /// </summary>
        public string CodigoCurso { get; set; }

        /// <summary>
        /// Obtiene o establece el número de legajo del estudiante.
        /// </summary>
        public string LegajoEstudiante { get; set; }

        /// <summary>
        /// Obtiene un curso por su código.
        /// </summary>
        /// <param name="codigo">Código del curso.</param>
        /// <returns>Instancia del curso encontrado.</returns>
        public Curso ObtenerCursoPorCodigo(string codigo)
        {
            return _crudCurso.ObtenerCursoPorCodigo(codigo);
        }
    }
}
