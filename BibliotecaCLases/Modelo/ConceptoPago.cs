using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

/// <summary>
/// Clase que representa un concepto de pago.
/// </summary>
namespace BibliotecaCLases.Modelo
{
    /// /// <summary>
    /// Constructor de la clase ConceptoPago.
    /// </summary>
    /// <param name="nombre">Nombre del concepto de pago.</param>
    /// <param name="monto">Monto a pagar asociado al concepto.</param>
    public class ConceptoPago
    {
        private string _nombre;
        private int _montoAPagar;
      
        private int _montoPagado;

        /// <summary>
        /// Constructor de la clase ConceptoPago.
        /// </summary>
        /// <param name="nombre">Nombre del concepto de pago.</param>
        /// <param name="monto">Monto a pagar asociado al concepto.</param>
        public ConceptoPago(string nombre, int monto)
        {
            _nombre = nombre;
            _montoAPagar = monto;
        }

        /// <summary>
        /// Propiedad para obtener o establecer el nombre del concepto de pago.
        /// </summary>
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        /// <summary>
        /// Propiedad para obtener o establecer el monto a pagar asociado al concepto.
        /// </summary>
        public int MontoAPagar
        { 
            get { return _montoAPagar; } 
            set { _montoAPagar = value; }
        }

        public int MontoPagado
        {
            get { return _montoPagado; }
            set { _montoPagado += value; }
        }

    }
}
