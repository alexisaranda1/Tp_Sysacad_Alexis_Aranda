using BibliotecaCLases.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaCLases.Interfaces
{
    public interface IPagoVista
    {
        event EventHandler MetodoPagoSeleccionado;
        event EventHandler PagarClicked;        
        public void MostrarConceptosPagoPendientes(List<ConceptoPago> conceptosPago);
        public void MostrarMetodosPago(List<string> metodosPago);
        void MostrarCamposTarjetaCredito();
        void MostrarCamposTarjetaDebito();
        void MostrarInformacionTransferenciaBancaria();
        public void MostrarMensaje(string mensaje);
        public string ObtenerNumeroTarjeta();
        public string ObtenerFechaVencimiento();
        public string ObtenerCVV();
        public List<int> ObtenerValoresEditados(List<int> montosIngresados);
        public void MostrarTotalPagar(int total);
        public void MostrarComprobantePago(string comprobante);
        public string ObtenerMetodoPagoSeleccionado();
        public void RecargarPrograma();
        // comentario
    }
}
