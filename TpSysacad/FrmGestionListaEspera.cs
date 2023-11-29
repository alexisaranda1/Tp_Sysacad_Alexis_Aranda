using BibliotecaCLases.Controlador;
using BibliotecaCLases.Interfaces;
using BibliotecaCLases.Modelo;
using BibliotecaCLases.Utilidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FrmGestionListaEspera : Form, ICursoVista
    {
        private CursoPresentador _cursoPresentador;
        private bool esListaDeEstudiantes;



        public FrmGestionListaEspera()
        {
            InitializeComponent();


            _cursoPresentador = new CursoPresentador(this);
            CargarListaCursos();
            btnAgregarEstudiante.Visible = false;
            btnEliminarEstudiante.Visible = false;
            btnAgregar.Visible = false;
            dtgvListaEspera.ClearSelection();

        }

        public event Action OnListaCursosPedida;
        public event Action OnListaEstudiantePedida;
        public event Action OnListaEsperaPedida;
        public event Action<string, int> OnAgregarEstudianteListaEspera;
        public event Action<string, int> OnEliminarEstudianteListaEspera;



        private void CargarListaCursos()
        {
            OnListaCursosPedida?.Invoke();
        }
        private void btnVerlista_Click(object sender, EventArgs e)
        {
            btnAgregarEstudiante.Visible = true;
            btnEliminarEstudiante.Visible = true;
            btnVerlista.Visible = false;
            btnAgregar.Visible = false;
            OnListaEsperaPedida?.Invoke();
        }


        public void CrearColumnasCursos()
        {
            dtgvListaEspera.Columns.Clear();

            dtgvListaEspera.Columns.Add("Codigo", "Código");
            dtgvListaEspera.Columns.Add("Nombre", "Nombre");
            dtgvListaEspera.Columns.Add("Descripcion", "Descripción");
            dtgvListaEspera.Columns.Add("CupoMaximo", "Cupo Máximo");
            dtgvListaEspera.Columns.Add("CuposDisponibles", "Cupos Disponibles");
            esListaDeEstudiantes = false;

        }
        public void CrearColumnasAlumno()
        {
            dtgvListaEspera.Columns.Clear();
            dtgvListaEspera.Columns.Add("Legajo", "Legajo");
            dtgvListaEspera.Columns.Add("Nombre", "Nombre");
            dtgvListaEspera.Columns.Add("Apellido", "Apellido");
            dtgvListaEspera.Columns.Add("Correo", "Correo");
            dtgvListaEspera.Columns.Add("DNI", "DNI");
            esListaDeEstudiantes = true;
        }
        public void MostrarListaEspera(List<Estudiante> estudiantes)
        {
            if (estudiantes != null && estudiantes.Count > 0)
            {
                dtgvListaEspera.Rows.Clear();
                foreach (Estudiante estudiante in estudiantes)
                {
                    dtgvListaEspera.Rows.Add(estudiante.Legajo, estudiante.Nombre, estudiante.Apellido, estudiante.Correo, estudiante.Dni);
                }
            }
            else
            {
                MostrarMensaje("Estudiante no encontrado");
            }
        }
        public void MostrarListaEstudiante(List<Estudiante> estudiantes)
        {
            if (estudiantes != null)
            {
                dtgvListaEspera.Rows.Clear();
                foreach (Estudiante estudiante in estudiantes)
                {
                    dtgvListaEspera.Rows.Add(estudiante.Legajo, estudiante.Nombre, estudiante.Apellido, estudiante.Correo, estudiante.Dni);
                }
            }
            else
            {
                MostrarMensaje("Estudiante no encontrado");
            }
        }

        public void MostrarCurso(List<Curso> cursos)
        {
            if (cursos.Count > 0)
            {
                dtgvListaEspera.Rows.Clear();
                foreach (Curso curso in cursos)
                {

                    dtgvListaEspera.Rows.Add(curso.Codigo, curso.Nombre, curso.Descripcion, curso.CupoMaximo, curso.CuposDisponibles);
                }
            }
            else
            {
                MostrarMensaje("Curso no encontrado");
            }
        }

        public void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void LimpiarFormulario()
        {

        }



        private void btnAgregarEstudiante_Click_1(object sender, EventArgs e)
        {

            btnAgregarEstudiante.Visible = false;
            btnEliminarEstudiante.Visible = false;
            btnVerlista.Visible = false;
            btnAgregar.Visible = true;
            OnListaEstudiantePedida?.Invoke();            
        }

        private void btnEliminarEstudiante_Click_1(object sender, EventArgs e)
        {

        }

        private void dtgvListaEspera_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dtgvListaEspera.Rows.Count)
            {
                DataGridViewRow filaSeleccionada = dtgvListaEspera.Rows[e.RowIndex];

                if (filaSeleccionada != null)
                {                  
                    DataGridViewCell primeraCelda = filaSeleccionada.Cells[0];

                    if (primeraCelda != null && primeraCelda.Value != null)
                    {
                        string valorPrimeraColumna = primeraCelda.Value.ToString();

                        if (esListaDeEstudiantes)
                        {
                            _cursoPresentador.LegajoEstudiante = valorPrimeraColumna;                                                        
                        }
                        else
                        {
                            _cursoPresentador.CodigoCurso = valorPrimeraColumna;                                                     
                        }
                    }
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_cursoPresentador.CodigoCurso) && !string.IsNullOrEmpty(_cursoPresentador.LegajoEstudiante))
            {
                int legajo = Convert.ToInt32(_cursoPresentador.LegajoEstudiante);

                OnAgregarEstudianteListaEspera?.Invoke(_cursoPresentador.CodigoCurso, legajo);               
                OnListaEsperaPedida?.Invoke();
            }
            else
            {
                MostrarMensaje("Seleccione un curso y un estudiante.");
            }
        }

    }
}
