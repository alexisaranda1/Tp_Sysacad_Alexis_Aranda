using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.Modelo
{
    /// <summary>
    /// Clase que representa un pago realizado por un estudiante.
    /// </summary>
    public class Pago
    {



        private DateTime _fecha;
       
        private int _idUsuario;
        private string _nombreUsuario;
        private string _apellidoUsuario;

        private List<ConceptoPago> _conceptosPago;
        private string _metodoPago;
        private decimal _montoTotal;

        /// <summary>
        /// Constructor de la clase Pago.
        /// </summary>
        /// <param name="estudiante">El estudiante que realiza el pago.</param>
        /// <param name="conceptosPago">Lista de conceptos de pago asociados al pago.</param>
        /// <param name="metodoPago">El método de pago utilizado para el pago.</param>
        /// <param name="montoTotal">El monto total del pago.</param>
        public Pago(Usuario estudiante, List<ConceptoPago> conceptosPago, string metodoPago, decimal montoTotal)
        {
            _fecha = DateTime.Now;
            _idUsuario = estudiante.Legajo;
            _nombreUsuario = estudiante.Nombre;
            _apellidoUsuario = estudiante.Apellido;
            _conceptosPago = conceptosPago;
            _metodoPago = metodoPago;
            _montoTotal = montoTotal;
        }

        /// <summary>
        /// Propiedad para obtener o establecer la fecha en que se realizó el pago.
        /// </summary>
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        public string NombreUsuario
        {
            get { return _nombreUsuario; }
            set { _nombreUsuario = value; }
        }
        public string ApellidoUsuario
        {
            get { return _apellidoUsuario; }
            set { _apellidoUsuario = value; }
        }

        /// <summary>
        /// Propiedad para obtener o establecer la lista de conceptos de pago asociados al pago.
        /// </summary>
        public List<ConceptoPago> ConceptosPago
        {
            get { return _conceptosPago; }
            set { _conceptosPago = value; }
        }
        public decimal MontoTotal
        {
            get { return _montoTotal; }
            set { _montoTotal = value; }
        }
        /// <summary>
        /// Propiedad para obtener o establecer el método de pago utilizado para el pago.
        /// </summary>
        public string MetodoPago
        {
            get { return _metodoPago; }
            set { _metodoPago = value; }
        }

        /// <summary>
        /// Propiedad para obtener o establecer el monto total del pago.
        /// </summary>


    }
}
