using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.Modelo
{
    /// <summary>
    /// Representa un usuario en el sistema.
    /// </summary>
    public class Usuario
    {
        private string _nombre;
        private string _apellido;
        private string _correo;
        private string _dni;
        private string _clave;
        private int _legajo;



        /// <summary>
        /// Enumeración que define los tipos de usuarios.
        /// </summary>
        public enum tipoUsuario
        {
            Administrador=0,
            Estudiante=1
        }
        private tipoUsuario _tipoUsuario;



        /// <summary>
        /// Constructor de la clase Usuario.
        /// </summary>
        /// <param name="nombre">El nombre del usuario.</param>
        /// <param name="apellido">El apellido del usuario.</param>
        /// <param name="dni">El DNI del usuario.</param>
        /// <param name="correo">La dirección de correo del usuario.</param>
        /// <param name="clave">La clave de acceso del usuario.</param>
        /// <param name="indiceTipoUsuario">El índice del tipo de usuario (0 para Administrador, 1 para Estudiante).</param>
        public Usuario(string nombre, string apellido, string dni, string correo, string clave, int indiceTipoUsuario)
        {
           
            _nombre = nombre;
            _apellido = apellido;
            _dni = dni;
            _correo = correo;
            _clave = clave;
            _tipoUsuario = (tipoUsuario)indiceTipoUsuario;
        }

        /// <summary>
        /// Obtiene o establece el nombre del usuario.
        /// </summary>
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        /// <summary>
        /// Obtiene o establece el apellido del usuario.
        /// </summary>
        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        /// <summary>
        /// Obtiene o establece la dirección de correo del usuario.
        /// </summary>
        public string Correo
        {
            get { return _correo; }
            set { _correo = value; }
        }

        /// <summary>
        /// Obtiene o establece el DNI del usuario.
        /// </summary>
        public string Dni
        {
            get { return _dni; }
            set { _dni = value; }
        }


        /// <summary>
        /// Obtiene o establece la clave de acceso del usuario.
        /// </summary>
        public string Clave
        {
            get { return _clave; }
            set { _clave = value; }
        }

        /// <summary>
        /// Obtiene o establece el tipo de usuario (Administrador o Estudiante).
        /// </summary>
        public tipoUsuario TipoUsuario
        {
            get { return _tipoUsuario; }
            set { _tipoUsuario = value; }
        }


        /// <summary>
        /// Obtiene o establece el legajo del usuario.
        /// </summary>
        public int Legajo
        {
            get { return _legajo; }
            set { _legajo = value; }
        }

    }
}
