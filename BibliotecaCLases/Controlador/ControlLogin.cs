using System.Collections.Generic;
using System.Linq;
using BibliotecaCLases.Modelo;
using BibliotecaCLases.Utilidades;

namespace BibliotecaCLases.Controlador
{
    /// <summary>
    /// Clase que gestiona la autenticación de usuarios y la carga de usuarios desde un archivo JSON.
    /// </summary>
    public class ControlLogin
    {
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
            int nivelesARetroceder = 4;
            _path = PathManager.ObtenerRuta("Data", "DataUsuarios.json", nivelesARetroceder);

            listaUsuarios = serializador.LeerJson<List<Usuario>>(_path);

            _existeUsuario = listaUsuarios != null && listaUsuarios.Any();
        }

        /// <summary>
        /// Verifica si en la lista de usuarios hay uno que coincide con el DNI y la contraseña.
        /// </summary>
        /// <param name="dni">El DNI del usuario.</param>
        /// <param name="contrasena">La contraseña del usuario.</param>
        /// <returns>True si la autenticación es exitosa; de lo contrario, False.</returns>
        public bool AutenticarUsuario(string dni, string contrasena)
        {
            _usuario = listaUsuarios.FirstOrDefault(u => u.Dni == dni);

            if (_usuario != null && contrasena != null && PasswordHashing.ValidatePassword(contrasena, _usuario.Clave))
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Obtiene el valor del usuario.
        /// </summary>
        public Usuario GetUsuario
        {
            get { return _usuario; }
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
