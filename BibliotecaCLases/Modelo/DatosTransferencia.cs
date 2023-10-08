using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.Modelo
{

    /// <summary>
    /// Clase que representa los datos de una transferencia.
    /// </summary>
    internal class DatosTransferencia
    {




        /// <summary>
        /// Obtiene o establece la lista de conceptos de pago asociados a la transferencia.
        /// </summary>
        public List<string> ConceptosDePago { get; set; }

        /// <summary>
        /// Obtiene o establece el monto total de la transferencia.
        /// </summary>
        public decimal MontoTotal { get; set; }
    }
}
