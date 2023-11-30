using BibliotecaCLases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.Controlador
{
    public class RequisitosAcademicos
    {
        private IRequisitosAcademicosVista vista;
        public RequisitosAcademicos(IRequisitosAcademicosVista vista)
        {
            this.vista = vista;
        }

        public void EditarRequisitos(RequisitosCurso requisitos)
        {
            // Lógica para guardar requisitos 
            vista.RequisitosActualizados(requisitos.Curso);
        }
    }
}
