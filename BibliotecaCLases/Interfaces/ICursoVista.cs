using BibliotecaCLases.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.Interfaces
{
    public interface ICursoVista
    {
        event Action OnListaCursosPedida;
        event Action OnListaEstudiantePedida;
        event Action OnListaEsperaPedida;
        event Action<string, int> OnAgregarEstudianteListaEspera;
        event Action<string, int> OnEliminarEstudianteListaEspera;


        public void CrearColumnasCursos();
        public void CrearColumnasAlumno();
        void MostrarCurso(List<Curso> cursos);
        public void MostrarListaEstudiante(List<Estudiante> estudiante);
        public void MostrarListaEspera(List<Estudiante> estudiantes);
        void MostrarMensaje(string mensaje);
        void LimpiarFormulario();
    }

}
