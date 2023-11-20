using BibliotecaCLases.Modelo;
using BibliotecaCLases.Utilidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BibliotecaCLases.Controlador
{
    public class GestorPagoLogic
    {
        private readonly List<Pago> _pagos;
        private Pago _pago;
        private Estudiante _estudiante;
        private readonly string _path;
        private readonly CrudEstudiante _crudEstudiante;
        private List<decimal> _montosIngresados = new();
        private decimal _totalIngresado = 0;
        private decimal _totalAPagar = 0;

        public GestorPagoLogic(Usuario usuario)
        {   
            _crudEstudiante = new CrudEstudiante();
            _estudiante = _crudEstudiante.ObtenerEstudiantePorLegajo(usuario.Legajo);
            _pagos = new List<Pago>();
            _path = PathManager.ObtenerRuta("Data", "DataUsuarios.json");
        }
        public List<ConceptoPago> ObtenerConceptosPagoPendientes()
        {
            return _estudiante.ConceptoPagos; ;
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


        public bool RealizarPago(Usuario usuario, string metodoPago, string numeroTarjeta, string fechaVencimiento, string cvv)
        {
            bool esPagoValido = false;

            List<ConceptoPago> conceptosPago = ObtenerConceptosPagoPendientes();

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
                for (int i = 0; i < conceptosPago.Count && i < _montosIngresados.Count; i++)
                {
                    decimal montoIngresado = _montosIngresados[i];
                    conceptosPago[i].ActualizarMontoPendiente(montoIngresado);

                    // Realiza las operaciones necesarias con montoIngresado
                }

                // Registrar el pago después de actualizar los montos pendientes
                RegistrarPago(conceptosPago, metodoPago);
            }

            return esPagoValido;
        }



        public List<decimal> MontosIngresados
        {
            get { return _montosIngresados; }
            set { _montosIngresados = value; }
        }

        private void RegistrarPago(List<ConceptoPago> conceptosPago, string metodoPago)
        {
            CalcularMontoTotal(conceptosPago);          
            _pago = new Pago(_estudiante, conceptosPago, metodoPago, _totalIngresado);

            if (_estudiante.ConceptoPagos.All(concepto => concepto.MontoPagar == 0))
            {
                _estudiante.EstadoDePago = "pagado";
            }

            Serializador.ActualizarJson(_estudiante, _estudiante.Legajo, _path);

            _pagos.Add(_pago);
        }


        public List<string> ObtenerHistorialPagos()
        {
            List<string> comprobantes = new List<string>();
            foreach (Pago pago in _pagos)
            {
                StringBuilder comprobante = new StringBuilder();
                comprobante.AppendLine("Comprobante de Pago");
                comprobante.AppendLine("===================");
                comprobante.AppendLine($"Fecha: {pago.Fecha}");
                comprobante.AppendLine($"Estudiante: {_estudiante.Nombre}, {_estudiante.Apellido}");
                comprobante.AppendLine("Conceptos de Pago:");

                for (int i = 0; i < _pago.ConceptosPago.Count && i < _montosIngresados.Count; i++)
                {
                    comprobante.AppendLine($"- {_pago.ConceptosPago[i].Nombre}: ${_montosIngresados[i]}");
                }


                comprobante.AppendLine($"Monto Total: ${pago.MontoTotal}");
                comprobante.AppendLine($"Método de Pago: {pago.MetodoPago}");
                comprobantes.Add(comprobante.ToString());
            }

            return comprobantes;
        }


        private void CalcularMontoTotal(List<ConceptoPago> conceptosPago)
        {
            foreach (var concepto in conceptosPago)
            {
                
                _totalIngresado += _montosIngresados[conceptosPago.IndexOf(concepto)];
                _totalAPagar += concepto.MontoPagar;
            }
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
            if (_totalIngresado != 0)
            {
                StringBuilder comprobante = new StringBuilder();
                comprobante.AppendLine("Comprobante de Pago");
                comprobante.AppendLine("===================");
                comprobante.AppendLine($"Fecha: {_pago.Fecha}");
                comprobante.AppendLine($"Estudiante: {_estudiante.Nombre}, {_estudiante.Apellido}");
                comprobante.AppendLine("Conceptos de Pago:");

                for (int i = 0; i < _pago.ConceptosPago.Count && i < _montosIngresados.Count; i++)
                {
                    comprobante.AppendLine($"- {_pago.ConceptosPago[i].Nombre}: ${_montosIngresados[i]}");
                }

                comprobante.AppendLine($"Monto Total: ${_totalIngresado}");
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
            if (_totalIngresado != 0)
            {
                StringBuilder mensajeTransferencia = new StringBuilder("Por favor, realice la transferencia bancaria con los siguientes datos:\n\n");
                mensajeTransferencia.AppendLine("Nombre del Banco: Ciudad");
                mensajeTransferencia.AppendLine("Número de CBU: 0110599540000001234567");
                mensajeTransferencia.AppendLine("Alias: Utn.fra.2023");
                mensajeTransferencia.AppendLine("Titular de la Cuenta: UTN-fra");
                mensajeTransferencia.AppendLine("Referencia:");

                foreach (var concepto in _pago.ConceptosPago)
                {
                   
                    int indiceConcepto = _pago.ConceptosPago.IndexOf(concepto);
                    mensajeTransferencia.AppendLine($"- {concepto.Nombre}: ${_montosIngresados[indiceConcepto]}");
                }

                mensajeTransferencia.AppendLine($"Monto a Transferir: {_totalIngresado}");

                return mensajeTransferencia.ToString();
            }
            else
            {
                return "Ingrese el monto a transferir";
            }
        }

    }
}
