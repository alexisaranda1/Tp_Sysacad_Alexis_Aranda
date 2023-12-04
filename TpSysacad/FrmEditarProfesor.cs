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
    public partial class FrmEditarProfesor : Form
    {
        Usuario _usuario;
        Profesor _profesor;
        int _legajo;
        public FrmEditarProfesor(Usuario usuario, int legajo)
        {
            _usuario = usuario;
            _legajo = legajo;
            InitializeComponent();
           
        }
        private void CargarDetallesProfesor()
        {

            if (_profesor != null)
            {
                textBoxNombre.Text = _profesor.Nombre;
                textBoxApellido.Text = _profesor.Apellido;
                textBoxDni.Text = _profesor.Dni;
                textBoxDireccion.Text = _profesor.Direccion;
                textBoxCorreo.Text = _profesor.Correo;
                textBoxTelefono.Text = _profesor.Telefono;
            }
            else
            {
                MessageBox.Show("El profesor seleccionado no se encontró en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnGuardarProfesor_Click(object sender, EventArgs e)
        {
            RecargarPrograma();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmGestionarProfesores formPrincipal = new FrmGestionarProfesores(_usuario);
            formPrincipal.Show();
        }
        public void RecargarPrograma()
        {
            FrmEditarProfesor frmEditarProfesor = new FrmEditarProfesor(_usuario, _legajo);
            frmEditarProfesor.Show();
            this.Close();
        }


    }
}
