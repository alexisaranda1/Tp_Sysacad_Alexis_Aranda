using BibliotecaCLases.Controlador;
using BibliotecaCLases.DataBase;
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
    public partial class FrmCursosAcargo : Form
    {

        private Usuario _usuario;
        bool esCurso;
        GestorAccionesProfesor _accionesProfesor;

        public FrmCursosAcargo(Usuario usuario)
        {
            _accionesProfesor = new GestorAccionesProfesor();

            _usuario = usuario;
            _accionesProfesor.LegajoProfesor = _usuario.Legajo;
            InitializeComponent();
            esCurso = true;
            MostrarCursos();


        }
        private void FrmCursosAcargo_Load(object sender, EventArgs e)
        {
            CargarCombox();
        }
        public void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void CrearColumnasAlumno()
        {
            dtgCrusos_alumnos.Columns.Clear();
            dtgCrusos_alumnos.Columns.Add("Legajo", "Legajo");
            dtgCrusos_alumnos.Columns.Add("Nombre", "Nombre");
            dtgCrusos_alumnos.Columns.Add("Apellido", "Apellido");
            dtgCrusos_alumnos.Columns.Add("Correo", "Correo");
            dtgCrusos_alumnos.Columns.Add("DNI", "DNI");

            foreach (DataGridViewColumn columna in dtgCrusos_alumnos.Columns)
            {
                columna.ReadOnly = true;
            }
        }

        public void MostrarListaEstudiante()
        {
            esCurso = false;
            List<Estudiante> estudiantes = _accionesProfesor.ObtenerEstudiantesIncriptos();
            if (estudiantes != null)
            {

                dtgCrusos_alumnos.Rows.Clear();

                CrearColumnasAlumno();
                foreach (Estudiante estudiante in estudiantes)
                {
                    dtgCrusos_alumnos.Rows.Add(estudiante.Legajo, estudiante.Nombre, estudiante.Apellido, estudiante.Correo, estudiante.Dni);
                }
            }
        }

        public void CrearColumnasCursos()
        {
            dtgCrusos_alumnos.Columns.Clear();
            dtgCrusos_alumnos.Columns.Add("Codigo", "Código");
            dtgCrusos_alumnos.Columns.Add("Nombre", "Nombre");
            dtgCrusos_alumnos.Columns.Add("Descripcion", "Descripción");
            dtgCrusos_alumnos.Columns.Add("CupoMaximo", "Cupo Máximo");
            dtgCrusos_alumnos.Columns.Add("CuposDisponibles", "Cupos Disponibles");
            foreach (DataGridViewColumn columna in dtgCrusos_alumnos.Columns)
            {
                columna.ReadOnly = true;
            }
        }
        public void MostrarCursos()
        {
            esCurso = true;
            List<Curso> cursos = _accionesProfesor.ObtenerCursosACargo();
            if (cursos.Count > 0)
            {
                CrearColumnasCursos();
                foreach (Curso curso in cursos)
                {
                    dtgCrusos_alumnos.Rows.Add(curso.Codigo, curso.Nombre, curso.Descripcion, curso.CupoMaximo, curso.CuposDisponibles);
                }
            }
        }



        private void btnMostrarAlumnos_Click(object sender, EventArgs e)
        {

            if (_accionesProfesor.codigoCursoObtenido != 0)
            {
                btnMostrarAlumnos.Visible = false;
                btnAsistancia.Visible = true;
                btnIngresarNota.Visible = true;
                MostrarListaEstudiante();
            }
            else
            {
                MostrarMensaje("seleccione un Curso!");
                RecargarPrograma();
            }


        }

        private void dtgCrusos_alumnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dtgCrusos_alumnos.Rows.Count)
            {
                DataGridViewRow filaSeleccionada = dtgCrusos_alumnos.Rows[e.RowIndex];

                if (filaSeleccionada != null)
                {
                    DataGridViewCell primeraCelda = filaSeleccionada.Cells[0];

                    if (primeraCelda != null && primeraCelda.Value != null)
                    {
                        string valorPrimeraColumna = primeraCelda.Value.ToString();
                        if (esCurso)
                        {
                            _accionesProfesor.codigoCursoObtenido = int.Parse(valorPrimeraColumna);
                        }
                        else
                        {
                            _accionesProfesor.LegajoAlumno = int.Parse(valorPrimeraColumna);
                        }


                    }
                }
            }
        }

        private void btnIngresarNota_Click(object sender, EventArgs e)
        {


            if (_accionesProfesor.LegajoAlumno != 0)
            {
                btnAsistancia.Visible = false;
                btnIngresarNota.Visible = false;
                textBoxNota.Visible = true;
                btnGuardarNota.Visible = true;
                CbxTipoEvaluacion.Visible = true;

                dtgCrusos_alumnos.Visible = false;
            }
            else
            {
                MostrarMensaje("seleccione un alumno!");
                RecargarPrograma();
            }


        }


        private void btnAsistancia_Click(object sender, EventArgs e)
        {
            if (_accionesProfesor.LegajoAlumno != 0)
            {
                btnAsistancia.Visible = false;
                btnIngresarNota.Visible = false;
                dtgCrusos_alumnos.Visible = false;
                cbxAsistencia.Visible = true;
                btnGuardarAsistencia.Visible=true;


            }
            else
            {
                MostrarMensaje("seleccione un alumno!");
                RecargarPrograma();
            }

        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            FormPanelUsuario formPrincipal = new FormPanelUsuario(_usuario);
            formPrincipal.Show();
        }

        public void RecargarPrograma()
        {
            this.Close();
            FrmCursosAcargo frmCursosAcargo = new FrmCursosAcargo(_usuario);
            frmCursosAcargo.Show();

        }
        void CargarCombox()
        {
            CbxTipoEvaluacion.Items.Add("Parcial");
            CbxTipoEvaluacion.Items.Add("TP");
            CbxTipoEvaluacion.Items.Add("Proyecto");
            cbxAsistencia.Items.Add("Regular");
            cbxAsistencia.Items.Add("No Regular");


        }

        private void btnGuardarNota_Click(object sender, EventArgs e)
        {
            string nota = textBoxNota.Text;
            if (Validacion.EsNumeroEnRango(nota, 1, 10))
            {
                string tipoEvaluacionSeleccionada = CbxTipoEvaluacion.SelectedItem.ToString();
                MostrarMensaje("Es valido");
                RecargarPrograma();
            }
            else
            {
                MostrarMensaje("No es valido");
            }

        }

        private void btnGuardarAsistencia_Click(object sender, EventArgs e)
        {
            string tipoAsistencia = cbxAsistencia.SelectedItem.ToString();
            MostrarMensaje(tipoAsistencia);
        }
    }
}
