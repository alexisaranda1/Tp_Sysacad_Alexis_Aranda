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

        public event Action OnListaCursosPedida;
        public event Action OnEditarPromedioRequerido;
        public event Action OnEditarCreditosRequeridos;
        public event Action OnEditarCorrelativas;


        /// <summary>
        /// Muestra un mensaje en la vista.
        /// </summary>
        /// <param name="mensaje">Mensaje a mostrar.</param>
        void MostrarMensaje(string mensaje);
        //event Action<Curso> RequisitosActualizados;
    }
}
