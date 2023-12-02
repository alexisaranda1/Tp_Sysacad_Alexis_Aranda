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
        bool mostrarRequisitos;
        bool escorrelativa = false;
        public FrmGestionarRequisitosAcademics(Usuario usuario)
        {
            _usuario = usuario;
            InitializeComponent();
            _gestorRequisitosAcademicos = new(this);
            txtNuevoPromedio.Visible = false;
            txtNuevoCredito.Visible = false;
            btnGuardar.Visible = false;
            btnGuardarCorrelativa.Visible = false;
            btnGuardarCredito.Visible = false;
            btnEditarCorrelativas.Visible = true;
            btnEditarCreditos.Visible = true;
            btnEditarPromedio.Visible = true;
            mostrarRequisitos = true;

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
        public void CrearColumnasCursos()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Codigo", "Código");
            dataGridView1.Columns.Add("Nombre", "Nombre");
            dataGridView1.Columns.Add("Descripcion", "Descripción");
            dataGridView1.Columns.Add("CupoMaximo", "Cupo Máximo");
            dataGridView1.Columns.Add("CuposDisponibles", "Cupos Disponibles");
            foreach (DataGridViewColumn columna in dataGridView1.Columns)
            {
                columna.ReadOnly = true;
            }
        }
        public void MostrarCursos(List<Curso> cursos)
        {

            if (cursos.Count > 0)
            {
                lblListaVacia.Visible = false;
                if (mostrarRequisitos)
                {
                    foreach (Curso curso in cursos)
                    {
                        dataGridView1.Rows.Add(curso.Codigo, curso.Nombre, curso.PromedioRequerido, curso.CreditosRequerido, curso.Correlativas);
                    }
                }
                else
                {
                    CrearColumnasCursos();
                    foreach (Curso curso in cursos)
                    {
                        dataGridView1.Rows.Add(curso.Codigo, curso.Nombre, curso.Descripcion, curso.CupoMaximo, curso.CuposDisponibles);
                    }
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
                        if (escorrelativa)
                        {
                            _gestorRequisitosAcademicos.CodigoCursoCorrelativa = valorPrimeraColumna;
                        }
                        else
                        {

                            _gestorRequisitosAcademicos.CodigoCurso = valorPrimeraColumna;
                        }
                    }
                }
            }

        }
        private void btnEditarPromedio_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_gestorRequisitosAcademicos.CodigoCurso))
            {
                MessageBox.Show("Por favor, selecciona un curso antes de editar el promedio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            btnEditarCorrelativas.Visible = false;
            btnEditarPromedio.Visible = false;
            btnEditarCreditos.Visible = false;
            dataGridView1.Visible = false;
            txtNuevoPromedio.Visible = true;
            lblListaVacia.Visible = true;
            btnGuardar.Visible = true;
            Curso curso = _gestorRequisitosAcademicos.ObtenerCursoPorCodigo();
            lblListaVacia.Text = $"Código: {curso.Codigo}\nNombre: {curso.Nombre}\nPromedio Requerido: {curso.PromedioRequerido}";
            OnEditarPromedioRequerido?.Invoke();
        }
        private void btnEditarCreditos_Click_1(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(_gestorRequisitosAcademicos.CodigoCurso))
            {
                MessageBox.Show("Por favor, selecciona un curso antes de editar los créditos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                RecargarPrograma();
                return;
            }
            btnGuardar.Visible = false;
            btnEditarCorrelativas.Visible = false;
            btnEditarPromedio.Visible = false;
            btnEditarCreditos.Visible = false;
            btnEditarCorrelativas.Visible = false;
            dataGridView1.Visible = false;
            btnGuardarCredito.Visible = true;
            txtNuevoCredito.Visible = true;
            lblListaVacia.Visible = true;

            Curso curso = _gestorRequisitosAcademicos.ObtenerCursoPorCodigo();
            lblListaVacia.Text = $"Código: {curso.Codigo}\nNombre: {curso.Nombre}\nCredito Requerido : {curso.CreditosRequerido}";
            OnEditarCreditosRequeridos?.Invoke();
        }
        private void btnEditarCorrelativas_Click_1(object sender, EventArgs e)
        {
            mostrarRequisitos = false;
            escorrelativa = true;
            OnListaCursosPedida?.Invoke();
            if (string.IsNullOrEmpty(_gestorRequisitosAcademicos.CodigoCurso))
            {
                MessageBox.Show("Por favor, selecciona un curso antes de editar las correlativas.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //RecargarPrograma();
                return;
            }
            btnGuardar.Visible = false;
            btnGuardarCorrelativa.Visible = true;
            btnEditarCorrelativas.Visible = false;
            btnEditarPromedio.Visible = false;
            btnEditarCreditos.Visible = false;
            btnEditarCorrelativas.Visible = false;



        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nuevoPromedio = txtNuevoPromedio.Text;
            _gestorRequisitosAcademicos.NuevoPromedio = nuevoPromedio;
            OnEditarPromedioRequerido?.Invoke();
            RecargarPrograma();
        }
        private void btnGuardarCredito_Click(object sender, EventArgs e)
        {
            btnEditarCreditos.Visible = false;
            string nuevoCredito = txtNuevoCredito.Text;
            _gestorRequisitosAcademicos.NuevoCredito = nuevoCredito;
            OnEditarCreditosRequeridos?.Invoke();
            RecargarPrograma();
        }

        private void btnGuardarCorrelativa_Click(object sender, EventArgs e)
        {
            OnEditarCorrelativas?.Invoke();
            RecargarPrograma();

        }

        public void RecargarPrograma()
        {
            FrmGestionarRequisitosAcademics frmGestionRequisitos = new FrmGestionarRequisitosAcademics(_usuario);
            frmGestionRequisitos.Show();
            this.Close();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            FormPanelUsuario formPrincipal = new FormPanelUsuario(_usuario);
            formPrincipal.Show();
        }
    }
}
