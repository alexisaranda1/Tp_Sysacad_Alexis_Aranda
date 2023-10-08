using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.Modelo
{


    /// <summary>
    /// Representa a un estudiante que se ha registrado en el sistema.
    /// </summary>
    public class Estudiante : Usuario
    {
        private string _direccion;
        private string _telefono;
        private bool _debecambiar;
        private List<string> _cursosInscriptos;
        private string _estadoDePago;





        /// <summary>
        /// Inicializa una nueva instancia de la clase Estudiante.
        /// </summary>
        /// <param name="nombre">El nombre del estudiante.</param>
        /// <param name="apellido">El apellido del estudiante.</param>
        /// <param name="dni">El número de identificación del estudiante (DNI).</param>
        /// <param name="correo">La dirección de correo electrónico del estudiante.</param>
        /// <param name="direccion">La dirección del estudiante.</param>
        /// <param name="telefono">El número de teléfono del estudiante.</param>
        /// <param name="claveProvisional">La clave provisional del estudiante.</param>
        /// <param name="debeCambiar">Indica si el estudiante debe cambiar su clave al iniciar sesión.</param>
        public Estudiante(string nombre, string apellido, string dni, string correo, string direccion, string telefono, string claveProvisional, bool debeCambiar)
            : base(nombre, apellido, dni, correo, claveProvisional, 1)
        {
            _debecambiar = debeCambiar;
            _direccion = direccion;
            _telefono = telefono;

            _cursosInscriptos = new List<string>();
            _estadoDePago = "pendiente";
        }


        /// <summary>
        /// Obtiene o establece un valor que indica si el estudiante debe cambiar su clave al iniciar sesión.
        /// </summary>
        public bool Debecambiar
        {
            get { return _debecambiar; }
            set { _debecambiar = value; }
        }


        /// <summary>
        /// Obtiene o establece la dirección del estudiante.
        /// </summary>
        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }


        /// <summary>
        /// Obtiene o establece el número de teléfono del estudiante.
        /// </summary>
        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }


        /// <summary>
        /// Obtiene o establece la lista de cursos en los que el estudiante está inscrito.
        /// </summary>
        public List<string> CursosInscriptos
        {
            get { return _cursosInscriptos; }
            set { _cursosInscriptos = value; }
        }


        /// <summary>
        /// Obtiene o establece el estado de pago del estudiante.
        /// </summary>
        public string EstadoDePago
        {
            get { return _estadoDePago; }
            set { _estadoDePago = value; }
        }

    }
}
