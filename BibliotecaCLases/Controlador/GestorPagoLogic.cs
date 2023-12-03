using BibliotecaCLases.Modelo;
using BibliotecaCLases.DataBase;
using BibliotecaCLases.Utilidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BibliotecaCLases.Controlador

{
    public class GestorPagoLogic
    {
        private List<Pago>  _pagos = new List<Pago>();
        private Pago _pago;
        private Estudiante _estudiante;
        private readonly string _pathPago;
        Serializador serializador = new Serializador();
        private readonly CrudEstudiante _crudEstudiante;
        private List<int> _montosIngresados = new();
        private List<ConceptoPago> _conceptosPendientes = new ();
        private decimal _totalAPagar = 0;
        private DBConceptoPago _dBConceptoPago = new DBConceptoPago();
        private DBPagos _dBPago = new DBPagos();




        public GestorPagoLogic(Usuario usuario)
        {   
            _crudEstudiante = new CrudEstudiante();
            _estudiante = _crudEstudiante.ObtenerEstudiantePorLegajo(usuario.Legajo);


            _pathPago = PathManager.ObtenerRuta("Data", "Pagos.json");
            _pagos = serializador.LeerJson<List<Pago>>(_pathPago) ?? new List<Pago>();


        }
        public List<ConceptoPago> ObtenerConceptosPagoPendientes(int legajo)
        {
            List<ConceptoPago> conceptosPendientes = new List<ConceptoPago>();
            List<ConceptoPago> conceptosPendientesAMostrar = new List<ConceptoPago>();

            conceptosPendientes = _dBConceptoPago.TraerConceptosPagoPorLegajo(legajo);

            foreach (ConceptoPago conceptoPago in conceptosPendientes)
            {
                if (conceptoPago.MontoAPagar > 0)
                {
                    conceptosPendientesAMostrar.Add(conceptoPago);
                    _montosIngresados.Add(0);
                }
            }
            _conceptosPendientes = conceptosPendientes;
            return conceptosPendientes;
        }


        public List<string> ObtenerMetodosPago()
        {
            List<string> metodosDePago = new List<string>
            {
                "Tarjeta de crédito",
                "Tarjeta de débito",
                "Transferencia bancaria"
            };

            return metodosDePago;
        }
        public bool ValidarDatosTarjeta(string numeroTarjeta, string fechaVencimiento, string cvv)
        {
            bool esTarjetaValida = Validacion.EsNumeroValido(numeroTarjeta, 16);
            bool esFechaValida = Validacion.EsFechaValida(fechaVencimiento);
            bool esCVVValido = Validacion.EsCVVValido(cvv);

            return esTarjetaValida && esFechaValida && esCVVValido;
        }


        public bool RealizarPago(Usuario usuario, string metodoPago, string numeroTarjeta, string fechaVencimiento, string cvv, out string mensaje)
        {
            bool esPagoValido = false;

            List<ConceptoPago> conceptosPago = _conceptosPendientes;
            List<ConceptoPago> conceptosPagopagados = new List<ConceptoPago>();
            mensaje = string.Empty;  // Inicializamos la variable de mensaje

            if (metodoPago.Contains("Tarjeta"))
            {
                esPagoValido = ValidarDatosTarjeta(numeroTarjeta, fechaVencimiento, cvv);
            }
            else if (metodoPago == "Transferencia bancaria")
            {
                esPagoValido = true;
            }

            if (esPagoValido)
            {
                bool guardar = true;
                foreach (ConceptoPago conceptoPago in conceptosPago)
                {
                    int montoIngresado = (int)_montosIngresados[conceptosPago.IndexOf(conceptoPago)];
                    if (montoIngresado > conceptoPago.MontoAPagar)
                    {
                        mensaje = "El monto ingresado es mayor que el monto a pagar. Se cobrará solo el monto a pagar.";
                    }
                    montoIngresado = Math.Min(montoIngresado, conceptoPago.MontoAPagar);
                    //conceptoPago.MontoPagado = montoIngresado;
                    _montosIngresados[conceptosPago.IndexOf(conceptoPago)] = montoIngresado;

                    if (conceptoPago.MontoAPagar > 0)
                    {
                        ActualizarMontoPendiente(montoIngresado, usuario.Legajo, conceptoPago);
                    }
                    else
                    {
                        mensaje = "Ya esta pagado, no lo puede volver a pagar!";
                        guardar = false;
                    }
                    if (montoIngresado > 0)
                    {
                        conceptosPagopagados.Add(conceptoPago);
                    }
                    if (!RegistrarPago(conceptosPagopagados, metodoPago, guardar))
                    {
                        mensaje = "Error a guardar en la base de datos";
                    }
                }
            }
            return esPagoValido;
        }

        /// <summary>
        /// Método para actualizar el monto pendiente restando el monto ingresado.
        /// </summary>
        public void ActualizarMontoPendiente(int montoingresado, int legajo, ConceptoPago concepto)
        {

            concepto.MontoAPagar -= montoingresado;
            _dBConceptoPago.ActualizarConceptoPago(legajo, concepto.Nombre, montoingresado, concepto.MontoAPagar);
        }

        public List<int> MontosIngresados
        {
            get { return _montosIngresados; }
            set { _montosIngresados = value; }
        }


        private bool RegistrarPago(List<ConceptoPago> conceptosPago, string metodoPago, bool guardar)
        {
            CalcularMontoTotal(conceptosPago);
            _pago = new Pago(_estudiante, conceptosPago, metodoPago, _totalAPagar);
            if (guardar)
            {
                if (_dBPago.Guardar(_pago))
                {
                    return true;
                }
            }
            return false;
        }

        private void CalcularMontoTotal(List<ConceptoPago> conceptosPago)
        {
            _totalAPagar = _montosIngresados.Sum();
        }

        public string GenerarComprobante()
        {
            if (_pago.MetodoPago.Contains("Tarjeta"))
            {
                return GenerarComprobanteDePago();
            }
            else if (_pago.MetodoPago == "Transferencia bancaria")
            {
                return GenerarDatosTransferenciaBancaria();
            }


            return "No se pudo generar el comprobante";
        }

        public string GenerarComprobanteDePago()
        {
            if (_totalAPagar != 0)
            {
                StringBuilder comprobante = new StringBuilder();
                comprobante.AppendLine("Comprobante de Pago");
                comprobante.AppendLine("===================");
                comprobante.AppendLine($"Fecha: {_pago.Fecha}");
                comprobante.AppendLine($"Estudiante: {_pago.NombreUsuario}, {_pago.ApellidoUsuario}");
                comprobante.AppendLine("Conceptos de Pago:");

                List<ConceptoPago> conceptos = _conceptosPendientes;

                for (int i = 0; i < conceptos.Count && i < _montosIngresados.Count; i++)
                {
                    if (_montosIngresados[i] > 0)
                    {
                        comprobante.AppendLine($"- {_pago.ConceptosPago[i].Nombre}: ${_montosIngresados[i]}");
                    }
                }


                comprobante.AppendLine($"Monto Total: ${_totalAPagar}");
                comprobante.AppendLine($"Método de Pago: {_pago.MetodoPago}");

                return comprobante.ToString();
            }
            else
            {
                return "No se realizó el pago";
            }
        }


        public string GenerarDatosTransferenciaBancaria()
        {
            if (_totalAPagar != 0)
            {
                StringBuilder mensajeTransferencia = new StringBuilder("Por favor, realice la transferencia bancaria con los siguientes datos:\n\n");
                mensajeTransferencia.AppendLine("Nombre del Banco: Ciudad");
                mensajeTransferencia.AppendLine("Número de CBU: 0110599540000001234567");
                mensajeTransferencia.AppendLine("Alias: Utn.fra.2023");
                mensajeTransferencia.AppendLine("Titular de la Cuenta: UTN-fra");
                mensajeTransferencia.AppendLine("Referencia:");
                List<ConceptoPago>  conceptos = _conceptosPendientes;
                foreach (var concepto in conceptos)
                {

                    int indiceConcepto = conceptos.IndexOf(concepto);
                    if (_montosIngresados[indiceConcepto] > 0)
                    {
                        mensajeTransferencia.AppendLine($"- {concepto.Nombre}: ${_montosIngresados[indiceConcepto]}");
                    }
                }

                mensajeTransferencia.AppendLine($"Monto a Transferir: {_totalAPagar}");

                return mensajeTransferencia.ToString();
            }
            return "No se realizo el pago";
        }

    }
}
