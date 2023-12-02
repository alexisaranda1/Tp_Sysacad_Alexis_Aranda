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
        public FrmGestionarProfesores(Usuario usuario)
        {
            _usuario = usuario;
            InitializeComponent();
        }
        /// <inheritdoc/>
        public void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ActualizarListaProfesores(List<Profesor> profesores)
        {
            // Aquí debes implementar la lógica para mostrar la lista de profesores en tu formulario
            // Puedes utilizar un control DataGridView o ListBox, por ejemplo
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

        }

        private void btnEditarProfesor_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminarProfesor_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarCurso_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            FormPanelUsuario formPrincipal = new FormPanelUsuario(_usuario);
            formPrincipal.Show();
        }
    }
}
