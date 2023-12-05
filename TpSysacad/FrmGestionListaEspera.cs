using BibliotecaCLases.Controlador;
using BibliotecaCLases.Interfaces;
using BibliotecaCLases.Modelo;
using BibliotecaCLases.Utilidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Formularios
{
    /// <summary>
    /// Formulario para la gestión de la lista de espera.
    /// </summary>
    public partial class FrmGestionListaEspera : Form, ICursoVista
    {
        private CursoPresentador _cursoPresentador;
        private bool esListaDeEstudiantes;
        private Usuario _usuario;

        /// <summary>
        /// Constructor de la clase <see cref="FrmGestionListaEspera"/>.
        /// </summary>
        /// <param name="usuario">Instancia del usuario actual.</param>
        public FrmGestionListaEspera(Usuario usuario)
        {
            InitializeComponent();

            _usuario = usuario;
            _cursoPresentador = new CursoPresentador(this);
            CargarListaCursos();
            btnAgregarEstudiante.Visible = false;
            btnEliminarEstudiante.Visible = false;
            btnAgregar.Visible = false;
            dtgvListaEspera.ClearSelection();
        }

        /// <inheritdoc/>
        public event Action OnListaCursosPedida;
        /// <inheritdoc/>
        public event Action OnListaEstudiantePedida;
        /// <inheritdoc/>
        public event Action OnListaEsperaPedida;
        /// <inheritdoc/>
        public event Action<string, int> OnAgregarEstudianteListaEspera;
        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public void CrearColumnasCursos()
        {
            dtgvListaEspera.Columns.Clear();

            dtgvListaEspera.Columns.Add("Codigo", "Código");
            dtgvListaEspera.Columns.Add("Nombre", "Nombre");
            dtgvListaEspera.Columns.Add("Descripcion", "Descripción");
            dtgvListaEspera.Columns.Add("CupoMaximo", "Cupo Máximo");
            dtgvListaEspera.Columns.Add("CuposDisponibles", "Cupos Disponibles");
            esListaDeEstudiantes = false;
            foreach (DataGridViewColumn columna in dtgvListaEspera.Columns)
            {
                columna.ReadOnly = true;
            }
        }

        /// <inheritdoc/>
        public void CrearColumnasAlumno()
        {
            dtgvListaEspera.Columns.Clear();
            dtgvListaEspera.Columns.Add("Legajo", "Legajo");
            dtgvListaEspera.Columns.Add("Nombre", "Nombre");
            dtgvListaEspera.Columns.Add("Apellido", "Apellido");
            dtgvListaEspera.Columns.Add("Correo", "Correo");
            dtgvListaEspera.Columns.Add("DNI", "DNI");
            esListaDeEstudiantes = true;
            foreach (DataGridViewColumn columna in dtgvListaEspera.Columns)
            {
                columna.ReadOnly = true;
            }
        }

        /// <inheritdoc/>
        public void CrearColumnasListaEspera()
        {
            dtgvListaEspera.Columns.Clear();
            dtgvListaEspera.Columns.Add("Legajo", "Legajo");
            dtgvListaEspera.Columns.Add("Nombre", "Nombre");
            dtgvListaEspera.Columns.Add("Apellido", "Apellido");
            dtgvListaEspera.Columns.Add("Correo", "Correo");
            dtgvListaEspera.Columns.Add("DNI", "DNI");
            dtgvListaEspera.Columns.Add("Fecha", "Fecha");
            esListaDeEstudiantes = true;
            foreach (DataGridViewColumn columna in dtgvListaEspera.Columns)
            {
                columna.ReadOnly = true;
            }
        }

        /// <inheritdoc/>
        public void MostrarListaEsperas(Dictionary<Estudiante, DateTime> dict)
        {
            label.Text = "Lista de Espera";

            // Limpiar las columnas y agregarlas
            CrearColumnasListaEspera();

            if (dict != null && dict.Count > 0)
            {
                dtgvListaEspera.Visible = true;
                lblAvisoListavacia.Visible = false;
                dtgvListaEspera.Rows.Clear();

                foreach (var kvp in dict)
                {
                    Estudiante estudiante = kvp.Key;
                    DateTime fecha = kvp.Value;

                    dtgvListaEspera.Rows.Add(estudiante.Legajo, estudiante.Nombre, estudiante.Apellido, estudiante.Correo, estudiante.Dni, fecha);
                }

            }
            else
            {
                dtgvListaEspera.Visible = false;
                lblAvisoListavacia.Visible = true;
                lblAvisoListavacia.Text = "No hay estudiantes en la lista de espera";
            }
        }

        /// <inheritdoc/>
        public void MostrarListaEstudiante(List<Estudiante> estudiantes)
        {
            label.Text = "Estudiantes disponibles";
            if (estudiantes != null)
            {
                dtgvListaEspera.Visible = true;
                lblAvisoListavacia.Visible = false;
                dtgvListaEspera.Rows.Clear();
                foreach (Estudiante estudiante in estudiantes)
                {
                    dtgvListaEspera.Rows.Add(estudiante.Legajo, estudiante.Nombre, estudiante.Apellido, estudiante.Correo, estudiante.Dni);
                }
            }
            else
            {
                dtgvListaEspera.Visible = false;
                lblAvisoListavacia.Visible = true;
                lblAvisoListavacia.Text = "No hay Estudiantes Registrados";
            }
        }

        /// <inheritdoc/>
        public void MostrarCurso(List<Curso> cursos)
        {
            label.Text = "Cursos no disponibles";
            if (cursos.Count > 0)
            {
                dtgvListaEspera.Visible = true;
                lblAvisoListavacia.Visible = false;
                dtgvListaEspera.Rows.Clear();
                foreach (Curso curso in cursos)
                {
                    if (curso.CuposDisponibles == 0)
                    {
                        dtgvListaEspera.Rows.Add(curso.Codigo, curso.Nombre, curso.Descripcion, curso.CupoMaximo, curso.CuposDisponibles);
                    }
                }
            }
            else
            {
                dtgvListaEspera.Visible = false;
                lblAvisoListavacia.Visible = true;
                lblAvisoListavacia.Text = "No hay cursos";
            }
        }

        /// <inheritdoc/>
        public void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <inheritdoc/>
        public void LimpiarFormulario()
        {
            // Implementar según sea necesario.
        }

        /// <summary>
        /// Manejador del evento click del botón "Agregar Estudiante".
        /// Muestra la interfaz para agregar un estudiante a la lista de espera.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btnAgregarEstudiante_Click_1(object sender, EventArgs e)
        {
            btnAgregarEstudiante.Visible = false;
            btnEliminarEstudiante.Visible = false;
            btnVerlista.Visible = false;
            btnAgregar.Visible = true;
            OnListaEstudiantePedida?.Invoke();
        }

        /// <summary>
        /// Manejador del evento click del botón "Eliminar Estudiante".
        /// Elimina un estudiante de la lista de espera para el curso seleccionado.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btnEliminarEstudiante_Click_1(object sender, EventArgs e)
        {
            if (dtgvListaEspera.SelectedRows.Count > 0)
            {
                string valorPrimeraColumna = dtgvListaEspera.SelectedRows[0].Cells[0].Value.ToString();

                if (esListaDeEstudiantes)
                {
                    _cursoPresentador.LegajoEstudiante = valorPrimeraColumna;
                }
                else
                {
                    _cursoPresentador.CodigoCurso = valorPrimeraColumna;
                }
                int identificador = Convert.ToInt32(valorPrimeraColumna);
                OnEliminarEstudianteListaEspera?.Invoke(_cursoPresentador.CodigoCurso, identificador);
                OnListaEsperaPedida?.Invoke();
                MostrarMensaje("¡Operación exitosa! El estudiante ha sido eliminado correctamente de la lista de espera para este curso.");
            }
            else
            {
                MostrarMensaje("Seleccione una fila para eliminar.");
            }
        }

        /// <summary>
        /// Manejador del evento CellClick de la tabla dtgvListaEspera.
        /// Captura el valor de la celda seleccionada para su posterior uso.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
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

        /// <summary>
        /// Manejador del evento click del botón "Agregar".
        /// Agrega un estudiante a la lista de espera para el curso seleccionado.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            btnAgregarEstudiante.Visible = true;
            btnEliminarEstudiante.Visible = true;
            btnVerlista.Visible = false;
            btnAgregar.Visible = false;
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

        /// <summary>
        /// Manejador del evento click del botón "Salir".
        /// Cierra el formulario actual y muestra el formulario principal del usuario.
        /// </summary>
        /// <param name="sender">El objeto que desencadenó el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            FormPanelUsuario formPrincipal = new FormPanelUsuario(_usuario);
            formPrincipal.Show();
        }
    }
}
