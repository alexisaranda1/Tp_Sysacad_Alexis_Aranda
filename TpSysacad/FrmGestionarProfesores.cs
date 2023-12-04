using BibliotecaCLases.Controlador;
using BibliotecaCLases.DataBase;
using BibliotecaCLases.Interfaces;
using BibliotecaCLases.Modelo;
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
    public partial class FrmGestionarProfesores : Form, IProfesorVista
    {
        Usuario _usuario;
        PresentadorProfesor _presentador;
        public FrmGestionarProfesores(Usuario usuario)
        {
            _usuario = usuario;
            _presentador = new(this);
            InitializeComponent();
            CrearColumnasProfesores();
            dtgProfesores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }
        private void FrmGestionarProfesores_Load(object sender, EventArgs e)
        {
            MostrarProfes();
            txtNombre.Visible = false;
            txtApellido.Visible = false;
            txtDni.Visible = false;
            txtDireccion.Visible = false;
            txtCorreo.Visible = false;
            txtTelefono.Visible = false;
            txtEspecializacion.Visible = false; 
            btnRegistrarProfesor.Visible = false;

        }

        public event Action OnListaProfesoresPedida;
        public event Action OnAgragarProfesor;
        public event Action OnEliminarProfesorSolicitada;
        public event Action OnEditarProfesorSolicitada;

        public Profesor ObtenerDatosNuevoProfesor()
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string dni = txtDni.Text;
            string direccion = txtDireccion.Text;
            string correo = txtCorreo.Text;
            string telefono = txtTelefono.Text;
            string especializacion = txtEspecializacion.Text;
            return new Profesor(nombre, apellido, dni, correo, direccion, telefono, "", especializacion);
        }

        /// <inheritdoc/>
        public void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void CrearColumnasProfesores()
        {
            dtgProfesores.Columns.Clear();
            dtgProfesores.Columns.Add("legajo", "legajo");
            dtgProfesores.Columns.Add("Nombre", "Nombre");
            dtgProfesores.Columns.Add("Apellido", "Apellido");
            dtgProfesores.Columns.Add("correo", "correo");
            dtgProfesores.Columns.Add("Telefono", "Telefono");
            dtgProfesores.Columns.Add("especialización", "especialización");
            dtgProfesores.Columns.Add("cursos asignados", "cursos asignados");
            foreach (DataGridViewColumn columna in dtgProfesores.Columns)
            {
                columna.ReadOnly = true;
            }
        }

        public void MostrarProfes()
        {
            CrudProfesor crudProfesor = new CrudProfesor();
            List<Profesor> profesores = _presentador.CargarListaProfesores();
            foreach (Profesor profesor in profesores)
            {
                if (profesor.Activo != "false")
                {
                    dtgProfesores.Rows.Add(profesor.Legajo, profesor.Nombre, profesor.Apellido, profesor.Correo, profesor.Telefono, profesor.Especializacion, profesor.CursosAsignados);
                }

            }

        }

        public void CrearColumnasCursos()
        {
            dtgProfesores.Columns.Clear();
            dtgProfesores.Columns.Add("Codigo", "Código");
            dtgProfesores.Columns.Add("Nombre", "Nombre");
            dtgProfesores.Columns.Add("Descripcion", "Descripción");
            dtgProfesores.Columns.Add("CupoMaximo", "Cupo Máximo");
            dtgProfesores.Columns.Add("CuposDisponibles", "Cupos Disponibles");
            foreach (DataGridViewColumn columna in dtgProfesores.Columns)
            {
                columna.ReadOnly = true;
            }
        }
        public void MostrarCursos(List<Curso> cursos)
        {

            if (cursos.Count > 0)
            {          
                CrearColumnasCursos();
                foreach (Curso curso in cursos)
                {
                    dtgProfesores.Rows.Add(curso.Codigo, curso.Nombre, curso.Descripcion, curso.CupoMaximo, curso.CuposDisponibles);
                }               
            }          
        }


        public void ActualizarCursosAsignados(List<string> cursosAsignados)
        {
            // Implementa la lógica para mostrar la lista de cursos asignados a un profesor
            // Puedes utilizar un control ListBox, ComboBox u otro adecuado
        }

        public void CargarListaProfesores(List<Profesor> profesores)
        {


        }
        private void btnAgregarProfesor_Click(object sender, EventArgs e)
        {

            dtgProfesores.Visible = false;
            txtNombre.Visible = true;
            txtApellido.Visible = true;
            txtDni.Visible = true;
            txtDireccion.Visible = true;
            txtCorreo.Visible = true;
            txtTelefono.Visible = true;
            btnRegistrarProfesor.Visible = true;
            txtEspecializacion.Visible = true;

            btnEliminarProfesor.Visible = false;
            btnEditarProfesor.Visible = false;
            btnAgregarProfesor.Visible = false;
            btnAgregarCurso.Visible = false;
        }
        private void btnRegistrarProfesor_Click(object sender, EventArgs e)
        {
            _presentador.AgregarProfesor();
        }



        private void btnEditarProfesor_Click(object sender, EventArgs e)
        {
            if (_presentador.LegajoObtenido != 0)
            {
                FrmEditarProfesor frmEditarProfesor = new(_usuario, _presentador.LegajoObtenido);
                frmEditarProfesor.Show();
            }
            else
            {
                MostrarMensaje("Selecciona un profesor");
            }


        }

        private void btnEliminarProfesor_Click(object sender, EventArgs e)
        {
            OnEliminarProfesorSolicitada?.Invoke();
        }

        private void btnAgregarCurso_Click(object sender, EventArgs e)
        {
            CrudCurso crudCurso = new CrudCurso();
            List<Curso> cursos =crudCurso.ObtenerListaCursos();
            MostrarCursos(cursos);


        }
        public void RecargarPrograma()
        {
            FrmGestionarProfesores frmGestionRequisitos = new FrmGestionarProfesores(_usuario);
            frmGestionRequisitos.Show();
            this.Close();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            FormPanelUsuario formPrincipal = new FormPanelUsuario(_usuario);
            formPrincipal.Show();
        }

        private void dtgProfesores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dtgProfesores.Rows.Count)
            {
                DataGridViewRow filaSeleccionada = dtgProfesores.Rows[e.RowIndex];

                if (filaSeleccionada != null)
                {
                    DataGridViewCell primeraCelda = filaSeleccionada.Cells[0];

                    if (primeraCelda != null && primeraCelda.Value != null)
                    {
                        string valorPrimeraColumna = primeraCelda.Value.ToString();
                        _presentador.LegajoObtenido = int.Parse(valorPrimeraColumna);
                    }
                }
            }
        }
    }
}
