using BibliotecaCLases.Controlador;
using BibliotecaCLases.Interfaces;
using BibliotecaCLases.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FrmGestionarRequisitosAcademics : Form, IRequisitosAcademicosVista
    {
        private GestorRequisitosAcademicos _requisitosAcademicos;
        public FrmGestionarRequisitosAcademics()
        {
            InitializeComponent();
            _requisitosAcademicos = new(this);
            OnListaCursosPedida?.Invoke();

        }

        public event Action OnListaCursosPedida;
        /// <inheritdoc/>
        public void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void MostrarCursos(List<Curso> cursos)
        {

            if (cursos.Count > 0)
            {
                lblListaVacia.Visible = false;
                foreach (Curso curso in cursos)
                {

                    dataGridView1.Rows.Add(curso.Codigo, curso.Nombre,curso.PromedioRequerido,curso.CreditosRequerido,curso.Correlativas);

                }
            }
            else
            {
                dataGridView1.Visible = false;
                lblListaVacia.Visible = true;
                lblListaVacia.Text = "No hay cursos";

            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow filaSeleccionada = dataGridView1.Rows[e.RowIndex];

                if (filaSeleccionada != null)
                {
                    DataGridViewCell primeraCelda = filaSeleccionada.Cells[0];

                    if (primeraCelda != null && primeraCelda.Value != null)
                    {
                        string valorPrimeraColumna = primeraCelda.Value.ToString();
                        _requisitosAcademicos.CodigoCurso= valorPrimeraColumna;
                    }
                }
            }

        }


    }
}
