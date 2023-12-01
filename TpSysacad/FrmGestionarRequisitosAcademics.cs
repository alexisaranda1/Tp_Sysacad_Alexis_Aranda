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
        private GestorRequisitosAcademicos _gestorRequisitosAcademicos;
        Usuario _usuario;
        public FrmGestionarRequisitosAcademics(Usuario usuario)
        {
            _usuario = usuario;
            InitializeComponent();
            _gestorRequisitosAcademicos = new(this);
            OnListaCursosPedida?.Invoke();

        }

        public event Action OnListaCursosPedida;
        public event Action OnEditarPromedioRequerido;
        public event Action OnEditarCreditosRequeridos;
        public event Action OnEditarCorrelativas;
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

                    dataGridView1.Rows.Add(curso.Codigo, curso.Nombre, curso.PromedioRequerido, curso.CreditosRequerido, curso.Correlativas);

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
                        _gestorRequisitosAcademicos.CodigoCurso = valorPrimeraColumna;
                    }
                }
            }

        }
        private void btnEditarPromedio_Click(object sender, EventArgs e)
        {
            OnEditarPromedioRequerido?.Invoke();
        }

        private void btnEditarCreditos_Click(object sender, EventArgs e)
        {
            OnEditarCreditosRequeridos?.Invoke();
        }

        private void btnEditarCorrelativas_Click(object sender, EventArgs e)
        {
            OnEditarCorrelativas?.Invoke();
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            FormPanelUsuario formPrincipal = new FormPanelUsuario(_usuario);
            formPrincipal.Show();
        }
    }
}
