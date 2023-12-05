using System.Collections.Generic;
using System.Linq;
using BibliotecaCLases.DataBase;
using BibliotecaCLases.Modelo;
using BibliotecaCLases.Utilidades;

namespace BibliotecaCLases.Controlador
{
    /// <summary>
    /// Clase que gestiona la autenticación de usuarios y la carga de usuarios desde un archivo JSON.
    /// </summary>
    public class ControlLogin
    {
        private DBGeneric dBGeneric = new DBGeneric();
        private DBEstudiantes dBEstudiante = new DBEstudiantes();
        private DBAdministrador dBAdministrador = new DBAdministrador();
        private DBProfesor DBProfesor = new DBProfesor();
        Serializador serializador = new Serializador();
        private Usuario? _usuario;
        private readonly List<Usuario> listaUsuarios;
        private string _path;
        private bool _existeUsuario;

        /// <summary>
        /// Inicializa una nueva instancia de la clase ControlLogin.
        /// </summary>
        /// <remarks>
        /// Este CONSTRUCTOR se utiliza para gestionar la carga de usuarios desde un archivo JSON.
        /// Si el archivo no existe o está vacío, se crea una lista de usuarios predeterminada
        /// y se guarda en el archivo JSON especificado.
        /// </remarks>
        public ControlLogin()
        {

        }

        /// <summary>
        /// Verifica si en la lista de usuarios hay uno que coincide con el DNI y la contraseña.
        /// </summary>
        /// <param name="dni">El DNI del usuario.</param>
        /// <param name="contrasena">La contraseña del usuario.</param>
        /// <returns>True si la autenticación es exitosa; de lo contrario, False.</returns>
        public bool AutenticarUsuario(string dni)
        {

            if (dBGeneric.AutenticarUsuario(dni, "Estudiante"))
            {
                _usuario = dBEstudiante.TraeEstudiantePorDNI(dni);
                return true;
            }
            else if (dBGeneric.AutenticarUsuario(dni, "Administrador"))
            {
                
                _usuario = dBAdministrador.VerificaDni(dni);
                return true;
                
            }
            else
            {
                if (dBGeneric.AutenticarUsuario(dni, "Profesor"))
                {
                    _usuario = DBProfesor.VerificaDni(dni);
                    return true;

                }
            }
            return false;
        }

        public bool AutenticarContraseña(string contrasena)
        {
            return PasswordHashing.ValidatePassword(contrasena, _usuario.Clave);
        }


        /// <summary>
        /// Obtiene el valor del usuario.
        /// </summary>
        public Usuario GetUsuario
        {
            get { return _usuario!; }
        }


        /// <summary>
        /// Obtiene un valor que indica si existe al menos un usuario en la lista.
        /// </summary>
        public bool ExisteUsuario
        {
            get { return _existeUsuario; }
        }
    }
}
