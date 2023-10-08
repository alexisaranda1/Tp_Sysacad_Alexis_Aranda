using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.Modelo
{

    /// <summary>
    /// Clase que representa un método de pago.
    /// </summary>
    public class MetodoPago
    {
        private string _nombre;


        /// <summary>
        /// Constructor de la clase MetodoPago.
        /// </summary>
        public MetodoPago(string nombre)
        {
            _nombre = nombre;
        }


        /// <summary>
        /// Obtiene o establece el nombre del método de pago.
        /// </summary>
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

    }
}
