using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.Modelo
{

    /// <summary>
    /// Clase que representa un concepto de pago, como un nombre y un monto a pagar.
    /// </summary>
    public class ConceptoPago
    {
        private string _nombre;
        private decimal _monto;
        private decimal _montoIngresado;






        /// <summary>
        /// Constructor de la clase ConceptoPago.
        /// </summary>
        /// <param name="nombre">Nombre del concepto de pago.</param>
        /// <param name="monto">Monto a pagar por el concepto.</param>
        public ConceptoPago(string nombre, decimal monto)
        {
            _nombre = nombre;
            _monto = monto;
        }


        /// <summary>
        /// Propiedad para acceder o modificar el nombre del concepto de pago.
        /// </summary>
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }


        /// <summary>
        /// Propiedad para acceder o modificar el monto a pagar por el concepto.
        /// </summary>
        public decimal MontoPagar
        { 
            get { return _monto; } 
            set { _monto = value; }
        }

        /// <summary>
        /// Propiedad para acceder o modificar el monto que ha sido ingresado o pagado por el concepto.
        /// </summary>
        public decimal MontoIngresado
        { 
            get { return _montoIngresado; }
            set { _montoIngresado = value; } 
        }  

    }
}
