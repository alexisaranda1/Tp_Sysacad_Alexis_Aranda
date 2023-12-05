using BibliotecaCLases.Controlador;
using BibliotecaCLases.Modelo;
using System.Configuration;

namespace Formularios

{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string dni = textUsuario.Text; // de momento se usa el dni de usuario
            string contraseña = textContraseña.Text;
            ControlLogin controlLogin = new ControlLogin();
            if (controlLogin.AutenticarUsuario(dni) && controlLogin.AutenticarContraseña(contraseña))
            {

                Usuario usuarioActual = controlLogin.GetUsuario;

                FormPanelUsuario frmPanelUsuario = new(usuarioActual);

                frmPanelUsuario.FormClosed += (sender, args) =>
                {
                    this.Close();
                };
                frmPanelUsuario.Show();

                this.Hide();

            }

            else
            {
                MessageBox.Show("Usuario o contraseña Incorrecta");
                textUsuario.Text = string.Empty;
                textContraseña.Text = string.Empty;

            }

        }


        private void BtnAdministrador_Click(object sender, EventArgs e)
        {
            string usuario = ConfigurationManager.AppSettings["administradorUsuario"]!;
            string password = ConfigurationManager.AppSettings["administradorPassword"]!;
            textUsuario.Text = usuario;
            textContraseña.Text = password;
        }

        private void BtnEstudiante_Click_1(object sender, EventArgs e)
        {
            string usuario = ConfigurationManager.AppSettings["estudianteUsuario"]!;
            string password = ConfigurationManager.AppSettings["estudiantePassword"]!;
            textUsuario.Text = usuario;
            textContraseña.Text = password;


        }

        private void btnProfesor_Click(object sender, EventArgs e)
        {
            string usuario = ConfigurationManager.AppSettings["profesorUsuario"]!;
            string password = ConfigurationManager.AppSettings["profesorPassword"]!;
            textUsuario.Text = usuario;
            textContraseña.Text = password;
        }
    }
}