using BibliotecaCLases.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.Interfaces
{
    public interface IRequisitosAcademicosVista
    {
        void MostrarCursos(List<Curso> cursos);
        void MostrarRequisitosCurso(Curso requisitos);
        void MostrarMensaje(string mensaje);
        event Action<Curso> RequisitosActualizados;
    }
}
