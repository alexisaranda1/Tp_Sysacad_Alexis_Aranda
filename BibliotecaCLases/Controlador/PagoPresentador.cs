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
            _vista.MostrarConceptosPagoPendientes(_gestorPagoLogic.ObtenerConceptosPagoPendientes(usuario.Legajo));


            _vista.MostrarMetodosPago(_gestorPagoLogic.ObtenerMetodosPago());
        }
        private void Vista_PagarClicked(object sender, EventArgs e)
        {
            string metodoSeleccionado = _vista.ObtenerMetodoPagoSeleccionado();
            string numeroTarjeta = _vista.ObtenerNumeroTarjeta();
            string fechaVencimiento = _vista.ObtenerFechaVencimiento();
            string cvv = _vista.ObtenerCVV();
            bool seEvitoCelda = Vista_CeldaEditada();

            if (metodoSeleccionado != null)
            {
                if (seEvitoCelda)
                {                   
                    string mensaje= "";
                    bool pagoExitoso = _gestorPagoLogic.RealizarPago(_usuario, metodoSeleccionado, numeroTarjeta, fechaVencimiento, cvv, out mensaje);
                    if (mensaje != "")
                    {
                        _vista.MostrarMensaje(mensaje);


                    }
                    if (pagoExitoso)
                    {
                        string comprobante = _gestorPagoLogic.GenerarComprobante();                                        
                        _vista.MostrarComprobantePago(comprobante);
                        ActualizarPrograma();
                    }
                    else
                    {
                        _vista.MostrarMensaje("Error en la validación del pago. Por favor, verifique los datos e inténtelo nuevamente.");
                    }
                }
                else
                {
                    _vista.MostrarMensaje("Error. Por favor, inténtelo nuevamente.");
                }
            }
            else
            {
                _vista.MostrarMensaje("Error: Seleccione un método de pago. Por favor, inténtelo nuevamente.");
            }
        }

        private bool Vista_CeldaEditada()
        {
            List<int> valoresCelda = _vista.ObtenerValoresEditados(_gestorPagoLogic.MontosIngresados);

            if (valoresCelda.Count > 0)
            {
                _gestorPagoLogic.MontosIngresados = valoresCelda;
                return true;
            }
            return false;


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
