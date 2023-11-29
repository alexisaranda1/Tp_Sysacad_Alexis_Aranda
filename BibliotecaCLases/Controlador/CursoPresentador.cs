using BibliotecaCLases.Interfaces;
using BibliotecaCLases.Modelo;
using BibliotecaCLases.Utilidades;
using System.Collections.Generic;

namespace BibliotecaCLases.Controlador
{
    public class CursoPresentador
    {
        private ICursoVista _vista;
        private CrudCurso _crudCurso;
        private CrudEstudiante _crudEstudiante;
        private GestionListasEspera _gestionListasEspera;

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
            _vista.CrearColumnasAlumno();
            List<Estudiante> listaEstudiante = cargarListaEsperaEstudiante();
            _vista.MostrarListaEspera(listaEstudiante);
        }

        public List<Estudiante> cargarListaEsperaEstudiante()
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

        public void AgregarEstudianteListaEspera(string codigoCurso, int legajo)
        {
            _gestionListasEspera.AgregarEstudianteAListaEspera(codigoCurso, legajo);
        }

        public void EliminarEstudianteListaEspera(string codigoCurso, int legajo)
        {
            _gestionListasEspera.EliminarEstudianteDeListaEspera(codigoCurso, legajo);
        }

        public void MostrarCursos()
        {
            _vista.CrearColumnasCursos();
            var listaCursos = _crudCurso.ObtenerListaCursos();
            _vista.MostrarCurso(listaCursos);
        }

        public void MostrarEstudiantes()
        {
            _vista.CrearColumnasAlumno();
            List<Estudiante> listaEstudiante = _crudEstudiante.ObtenerEstudiantesRegistrados();
            _vista.MostrarListaEstudiante(listaEstudiante);
        }

        public string CodigoCurso { get; set; }
        public string LegajoEstudiante { get; set; }
        public Curso ObtenerCursoPorCodigo(string codigo)
        {
            return _crudCurso.ObtenerCursoPorCodigo(codigo);
        }
    }
}
