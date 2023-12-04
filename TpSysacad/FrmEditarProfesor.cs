using BibliotecaCLases.Controlador;
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
        CrudProfesor _crudProfesor;
        public FrmEditarProfesor(Usuario usuario, int legajo)
        {
            _usuario = usuario;
            _legajo = legajo;
            _crudProfesor = new();
            _profesor = _crudProfesor.ObtenerProfesorPorLegajo(_legajo);
            InitializeComponent();
            CargarDetallesProfesor();

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
                txtEspecializacion.Text = _profesor.Especializacion;
            }
            else
            {
                MessageBox.Show("El profesor seleccionado no se encontró en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnGuardarProfesor_Click(object sender, EventArgs e)
        {
            string nuevoNombre = textBoxNombre.Text;
            string nuevoApellido = textBoxApellido.Text;
            string nuevoDni = textBoxDni.Text;
            string nuevoCorreo = textBoxCorreo.Text;
            string nuevaDireccion = textBoxDireccion.Text;
            string nuevoTelefono = textBoxTelefono.Text;
            string nuevaEspecializacion = txtEspecializacion.Text;

            string mensajeErrorEspecializacion;
            if (!Validacion.EsNombreValido(nuevaEspecializacion))
            {
                MessageBox.Show("La especialización no es válida. Por favor, verifique la información proporcionada.");
                return;
            }

            string mensaje = _crudProfesor.ActualizarProfesor(_legajo, nuevoNombre, nuevoApellido, nuevoDni, nuevoCorreo, nuevaDireccion, nuevoTelefono, nuevaEspecializacion);
            MessageBox.Show(mensaje);
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
            this.Close();
            FrmGestionarProfesores formPrincipal = new FrmGestionarProfesores(_usuario);
            formPrincipal.Show();
        }


    }
}
