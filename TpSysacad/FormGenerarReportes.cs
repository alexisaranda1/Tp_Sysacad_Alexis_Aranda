using BibliotecaCLases.Controlador;
using BibliotecaCLases.DataBase;
using BibliotecaCLases.Modelo;
using Newtonsoft.Json.Linq;
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
using static BibliotecaCLases.Modelo.Curso;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Formularios
{
    public partial class FormGenerarReportes : Form
    {
        private CrudReporte _crudReporte;
        private Usuario _usuario;
        bool _valid = false;
        private List<Curso> _listCurso = new List<Curso>();
        private List<string> _listPago = new List<string>();
        private string reporte;
        public FormGenerarReportes(Usuario usuario)
        {
            _usuario = usuario;
            _crudReporte = new CrudReporte();
            InitializeComponent();
            CargarComboBox();
            CargarDataGrid();
        }
        private void CargarComboBox()
        {
            _listCurso = _crudReporte.ObtenerTodosLosCursos();
            _listPago = _crudReporte.ObtenerTodosLosPagos();
            foreach (Curso curso in _listCurso)
            {
                cBCurso.Items.Add(curso.Nombre);
            }
            foreach (string pago in _listPago)
            {
                cBPago.Items.Add(pago);
            }
            foreach (Curso curso in _listCurso)
            {
                cBPeriodo.Items.Add(curso.Descripcion);
            }
            foreach (Curso curso in _listCurso)
            {
                cBEspera.Items.Add(curso.Nombre);
            }
        }
        private void btnGenerador_Click(object sender, EventArgs e)
        {
            string materia = cBCurso.SelectedItem?.ToString()!;
            string descripcion = cBPeriodo.SelectedItem?.ToString()!;
            string pago = cBPago.SelectedItem?.ToString()!;
            string espera = cBEspera.SelectedItem?.ToString()!;
            if (cBCurso.Visible == true && materia != null)
            {
                _valid = true;
                reporte = _crudReporte.GeneraReportePorMateriaPeriodo(_valid, materia);
            }
            else if (cBPeriodo.Visible == true && descripcion != null)
            {
                _valid = true;
                reporte = _crudReporte.GeneraReportePorMateriaPeriodo(_valid, descripcion);
            }
            else if (cBPago.Visible == true && pago != null)
            {
                _valid = true;
                reporte = _crudReporte.GeneraReportePorPago(_valid, pago);
            }
            else if (cBEspera.Visible == true && espera != null)
            {
                _valid = true;
                reporte = _crudReporte.GeneraReportePorEspera(_valid, espera, _listCurso);
            }
            if (reporte != null)
            {
                FormMostrarReporte formMostrarReporte = new FormMostrarReporte(this, reporte);
                formMostrarReporte.Show();
            }
        }

        private void CargarDataGrid()
        {
            List<Reporte> listaReporte = null;

            listaReporte = _crudReporte.ObtenerTodosLosReportes();
            if (listaReporte != null)
            {
                int indice = 1;
                foreach (Reporte reporte in listaReporte)
                {
                    int indiceFila = dataGridViewReportes.Rows.Add(false, reporte.Nombre); // Agrega una columna para el checkbox y establece su valor inicial en false.
                    dataGridViewReportes.Rows[indiceFila].Tag = indice;
                    indice++;
                }
            }
        }

        private void dataGridViewReportes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridViewReportes.Columns["Check"].Index)
            {
                DataGridViewCheckBoxCell currentCheckBox = (DataGridViewCheckBoxCell)dataGridViewReportes.Rows[e.RowIndex].Cells["Check"];

                // Desmarcar todas las casillas de verificación antes de marcar la actual
                foreach (DataGridViewRow row in dataGridViewReportes.Rows)
                {
                    if (row.Index != e.RowIndex)
                    {
                        DataGridViewCheckBoxCell checkBox = (DataGridViewCheckBoxCell)row.Cells["Check"];
                        checkBox.Value = false;

                        //btnParametros.Visible = true;
                        //generarReportes.Visible = false;
                    }
                }
            }
        }

        private void btnMuestra_Click(object sender, EventArgs e)
        {
            bool selecciono = false;
            string codigo = "";
            foreach (DataGridViewRow row in dataGridViewReportes.Rows)
            {
                if (row.Cells["Check"].Value != null && (bool)row.Cells["Check"].Value == true)
                {
                    int filaSeleccionadaIndex = dataGridViewReportes.SelectedCells[0].RowIndex;
                    codigo = (dataGridViewReportes.Rows[filaSeleccionadaIndex].Cells["informe"].Value.ToString()!);

                    if (codigo == "Informe de inscripciones por período")
                    {
                        cBPeriodo.Visible = true;
                        selecciono = true;
                    }
                    if (codigo == "Informe de estudiantes inscritos en un curso específico.")
                    {
                        cBCurso.Visible = true;
                        selecciono = true;
                    }
                    if (codigo == "Informe de listas de espera de cursos.")
                    {
                        cBEspera.Visible = true;
                        selecciono = true;
                    }
                    if (codigo == "Informe de ingresos por conceptos de pago.")
                    {
                        cBPago.Visible = true;
                        selecciono = true;
                    }

                }
            }
            if (selecciono == false)
            {
                MessageBox.Show("No selecciono ningun tipo de informe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Ingrese los parametros para el informe", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnGenerador.Visible = true;
                btnMuestra.Visible = false;
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Close();
            FormPanelUsuario formPrincipal = new FormPanelUsuario(_usuario);
            formPrincipal.Show();
        }

    }
}
