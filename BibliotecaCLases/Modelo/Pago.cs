using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.Modelo
{

    /// <summary>
    /// Representa un registro de pago realizado por un estudiante.
    /// </summary>
    public class Pago
    {
        private DateTime _fecha;
        private Usuario _estudiante;
        private List<ConceptoPago> _conceptosPago;
        private MetodoPago _metodoPago;
        private decimal _montoTotal;




        /// <summary>
        /// Crea una nueva instancia de la clase Pago.
        /// </summary>
        public Pago(Usuario estudiante, List<ConceptoPago> conceptosPago, MetodoPago metodoPago, decimal montoTotal)
        {
            _fecha = DateTime.Now;
            _estudiante = estudiante;
            _conceptosPago = conceptosPago;
            _metodoPago = metodoPago;
            _montoTotal = montoTotal;
        }


        /// <summary>
        /// Obtiene o establece la fecha en que se realizó el pago.
        /// </summary>
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }


        /// <summary>
        /// Obtiene o establece el estudiante que realizó el pago.
        /// </summary>
        public Usuario Estudiante 
        {
            get { return _estudiante; } 
            set { _estudiante = value; }
        }


        /// <summary>
        /// Obtiene o establece la lista de conceptos de pago incluidos en el pago.
        /// </summary>
        public List<ConceptoPago> ConceptosPago
        {
            get { return _conceptosPago; }
            set { _conceptosPago = value; }
        }


        /// <summary>
        /// Obtiene o establece el método de pago utilizado.
        /// </summary>
        public MetodoPago MetodoPago
        {
            get { return _metodoPago; }
            set { _metodoPago = value; }
        }


        /// <summary>
        /// Obtiene o establece el monto total del pago.
        /// </summary>
        public decimal MontoTotal
        {
            get { return _montoTotal; }
            set { _montoTotal = value; }
        }
    }
}
