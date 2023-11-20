using BibliotecaCLases.Interfaces;
using BibliotecaCLases.Modelo;
using System;
using System.Collections.Generic;

namespace BibliotecaCLases.Controlador
{
    public class PagoPresentador
    {
        private readonly IPagoVista _vista;
        private readonly GestorPagoLogic _gestorPagoLogic;
        private readonly Usuario _usuario;

        public PagoPresentador(IPagoVista vista, Usuario usuario)
        {
            _vista = vista;
            _usuario = usuario;
            _gestorPagoLogic = new GestorPagoLogic(usuario);
            _vista.MetodoPagoSeleccionado += Vista_MetodoPagoSeleccionado;
            _vista.PagarClicked += Vista_PagarClicked;
           


            _vista.MostrarConceptosPagoPendientes(_gestorPagoLogic.ObtenerConceptosPagoPendientes());

            _vista.MostrarMetodosPago(_gestorPagoLogic.ObtenerMetodosPago());
        }

        private void Vista_PagarClicked(object sender, EventArgs e)
        {
            string metodoSeleccionado = _vista.ObtenerMetodoPagoSeleccionado();
            string numeroTarjeta = _vista.ObtenerNumeroTarjeta();
            string fechaVencimiento = _vista.ObtenerFechaVencimiento();
            string cvv = _vista.ObtenerCVV();
            Vista_CeldaEditada();
            bool pagoExitoso = _gestorPagoLogic.RealizarPago(_usuario, metodoSeleccionado, numeroTarjeta, fechaVencimiento, cvv);

            if (pagoExitoso)
            {              
                string comprobante = _gestorPagoLogic.GenerarComprobante();
                _vista.MostrarComprobantePago(comprobante);
               
                foreach ( string comprobanteObtenido in _gestorPagoLogic.ObtenerHistorialPagos())
                {
                    _vista.MostrarMensaje(comprobanteObtenido);
                    ActualizarPrograma();
                }

            }
            else
            {               
                _vista.MostrarMensaje("Error en la validación del pago. Por favor, verifique los datos e inténtelo nuevamente.");
            }
        }


        private void Vista_CeldaEditada()
        {
            List<decimal> valoresCelda = _vista.ObtenerValoresCelda();
            _gestorPagoLogic.MontosIngresados = valoresCelda;

            foreach (decimal valorCelda in valoresCelda)
            {
                _vista.MostrarMensaje(valorCelda.ToString());
            }

        }
        private void Vista_MetodoPagoSeleccionado(object sender, EventArgs e)
        {
            string metodoSeleccionado = _vista.ObtenerMetodoPagoSeleccionado();

            switch (metodoSeleccionado)
            {
                case "Tarjeta de crédito":
                    _vista.MostrarCamposTarjetaCredito();
                    break;

                case "Tarjeta de débito":
                    _vista.MostrarCamposTarjetaDebito();
                    break;

                case "Transferencia bancaria":
                    _vista.MostrarInformacionTransferenciaBancaria();
                    break;

                // Agrega más casos según sea necesario

                default:
                    // Manejo por defecto o lanzar una excepción si es necesario
                    break;
            }
        }
        public void ActualizarPrograma()
        {
            _vista.RecargarPrograma();
        }



    }
}
