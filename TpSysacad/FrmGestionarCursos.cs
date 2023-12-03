using BibliotecaCLases.Controlador;
using BibliotecaCLases.DataBase;
using BibliotecaCLases.Modelo;
using BibliotecaCLases.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FrmGestionarCursos : Form
    {
        Serializador serializador = new Serializador();
        private Usuario _usuario;
        private CrudEstudiante crudEstudiante;
        private Curso _cursoSeleccionado;
        private CrudCurso _crudCurso;
        private DBCursos _dBCursos = new DBCursos();
        public FrmGestionarCursos(Usuario usuario)
        {
            crudEstudiante = new CrudEstudiante();
            _usuario = usuario;
            _crudCurso = new CrudCurso();
            InitializeComponent();
            MostrarBtn(_usuario);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnAgregarCurso_Click(object sender, EventArgs e)
        {
            FrmAgregarCurso frmAgregarCurso = new FrmAgregarCurso(this);
            frmAgregarCurso.Show();
        }

        private void BtnEditarCursos_Click(object sender, EventArgs e)
        {
            if (_cursoSeleccionado != null)
            {
                FrmEditarCurso frmEditarCurso = new FrmEditarCurso(_cursoSeleccionado, this);
                frmEditarCurso.Show();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un curso para editar.", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminarCursos_Click(object sender, EventArgs e)
        {
            if (_cursoSeleccionado != null)
            {
                DialogResult confirmacion = MessageBox.Show("¿Está seguro de eliminar este curso?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacion == DialogResult.Yes)
                {
                    string resultadoEliminacion = _crudCurso.EliminarCurso(_cursoSeleccionado);

                    if (resultadoEliminacion.StartsWith("Se realizó la eliminación lógica"))
                    {
                        MessageBox.Show(resultadoEliminacion, "Resultado:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActualizarListaCursos();
                    }
                    else
                    {
                        MessageBox.Show(resultadoEliminacion, "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un curso para eliminar.", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmGestionarCurso_Load(object sender, EventArgs e)
        {
            List<Curso> listaCursos = null;

            listaCursos = _dBCursos.ObtenerTodosLosCursos();
            if (listaCursos != null)
            {
                foreach (Curso curso in listaCursos)
                {
                    if (curso.Activo != "False")
                    {
                        dataGridViewCursos.Rows.Add(curso.Codigo, curso.Nombre, curso.Descripcion, curso.CuposDisponibles, curso.CupoMaximo);
                    }
                }
            }
        }

        private void dataGridViewCursos_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewCursos.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewCursos.SelectedRows[0];

                string codigoCurso = selectedRow.Cells["codigo"].Value.ToString();

                _cursoSeleccionado = _crudCurso.ObtenerCursoPorCodigo(codigoCurso);
            }
        }

        private void MostrarBtn(Usuario usuario)
        {
            BtnAgregarCurso.Visible = false;
            BtnEditarCursos.Visible = false;
            BtnEliminarCursos.Visible = false;
            btnInscripcion.Visible = false;
            if (usuario.TipoUsuario.ToString() == "Estudiante")
            {
                btnInscripcion.Visible = true;
            }
            else if (usuario.TipoUsuario.ToString() == "Administrador")
            {
                BtnAgregarCurso.Visible = true;
                BtnEditarCursos.Visible = true;
                BtnEliminarCursos.Visible = true;
            }
        }

        private void btnInscripcion_Click(object sender, EventArgs e)
        {
            if (_cursoSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un curso", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int.TryParse(_usuario.Legajo.ToString(), out int legajo);
                string mensajeError;
                bool inscripcionExitosa = crudEstudiante.AgregarCursoAEstudiante(legajo, _cursoSeleccionado.Codigo, out mensajeError);

                if (inscripcionExitosa)
                {
                    MessageBox.Show($"Inscripción exitosa al curso: {_cursoSeleccionado.Nombre}");
                    ActualizarListaCursos();
                }
                else
                {
                    if (!string.IsNullOrEmpty(mensajeError))
                    {
                        MessageBox.Show($"Error: {mensajeError}", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Error: No se encontró al estudiante.", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void ActualizarListaCursos()
        {
            dataGridViewCursos.Rows.Clear();

            foreach (Curso curso in _crudCurso.ObtenerListaCursos())
            {
                if (curso.Activo != "False")
                {
                    dataGridViewCursos.Rows.Add(curso.Codigo, curso.Nombre, curso.Descripcion, curso.CuposDisponibles, curso.CupoMaximo);
                }
            }

            _cursoSeleccionado = null;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FormPanelUsuario formPanelUsuario = new FormPanelUsuario(_usuario);

            formPanelUsuario.FormClosed += (s, args) =>
            {
                this.Close();
            };

            formPanelUsuario.Show();
            this.Hide();
        }
    }
}