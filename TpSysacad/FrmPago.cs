using BibliotecaCLases.Controlador;
using BibliotecaCLases.Interfaces;
using BibliotecaCLases.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Formularios
{
    public partial class FrmPago : Form, IPagoVista
    {
        private PagoPresentador _presentador;

        private Usuario _usuario;
        public FrmPago(Usuario usuario)
        {
            InitializeComponent();
            CmboxCuota.Visible = false;
            TbxNumeroTarjeta.Visible = false;
            TbxNombreTitular.Visible = false;
            TbxFechaVencimiento.Visible = false;
            TbxCvv.Visible = false;

            _presentador = new PagoPresentador(this, usuario);
            _usuario = usuario;

        }



        public event EventHandler MetodoPagoSeleccionado
        {
            add { CmboxMetodoPago.SelectedIndexChanged += value; }
            remove { CmboxMetodoPago.SelectedIndexChanged -= value; }
        }

        public event EventHandler PagarClicked
        {
            add { btnPagar.Click += value; }
            remove { btnPagar.Click -= value; }
        }



        public void MostrarConceptosPagoPendientes(List<ConceptoPago> conceptosPago)
        {
            dtgvConceptoPago.Rows.Clear();

            foreach (var concepto in conceptosPago)
            {
                dtgvConceptoPago.Rows.Add(concepto.Nombre, concepto.MontoAPagar, "");
            }

        }

        public void MostrarMetodosPago(List<string> metodosPago)
        {
            CmboxMetodoPago.Items.AddRange(metodosPago.ToArray());
        }

        public void MostrarMensaje(string mensaje)
        {
            MessageBox.Show(mensaje);
        }
        public void MostrarComprobantePago(string comprobante)
        {
            MessageBox.Show(comprobante, "Comprobante de Pago", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void MostrarTotalPagar(int total)
        {
            // Lógica para mostrar el total a pagar en tu formulario
            // Por ejemplo, podrías actualizar un label con el total
        }
        public string ObtenerMetodoPagoSeleccionado()
        {
            if (CmboxMetodoPago.SelectedItem != null)
            {

                return CmboxMetodoPago.SelectedItem.ToString();
            }

            return null;
        }

        public void MostrarCamposTarjetaCredito()
        {
            TbxNumeroTarjeta.Visible = true;
            TbxNombreTitular.Visible = true;
            TbxFechaVencimiento.Visible = true;
            TbxCvv.Visible = true;
            CmboxCuota.Items.Clear();
            CmboxCuota.Visible = true;
            CmboxCuota.Items.Add("3 cuotas");
            CmboxCuota.Items.Add("6 cuotas");
            CmboxCuota.Items.Add("12 cuotas");
        }

        public void MostrarCamposTarjetaDebito()
        {
            CmboxCuota.Visible = false;
            TbxNumeroTarjeta.Visible = true;
            TbxNombreTitular.Visible = true;
            TbxFechaVencimiento.Visible = true;
            TbxCvv.Visible = true;
        }

        public void MostrarInformacionTransferenciaBancaria()
        {
            TbxNumeroTarjeta.Visible = false;
            TbxNombreTitular.Visible = false;
            TbxFechaVencimiento.Visible = false;
            TbxCvv.Visible = false;
            CmboxCuota.Visible = false;
        }

        public string ObtenerNumeroTarjeta()
        {
            return TbxNumeroTarjeta.Text;
        }

        public string ObtenerFechaVencimiento()
        {
            return TbxFechaVencimiento.Text;
        }

        public string ObtenerCVV()
        {
            return TbxCvv.Text;
        }

        public List<int> ObtenerValoresEditados(List<int> montosIngresados)
        {
            List<int> valores = new List<int>();

            foreach (DataGridViewRow row in dtgvConceptoPago.Rows)
            {
                object cellValue = row.Cells[2].Value;

                if (cellValue != null && !string.IsNullOrWhiteSpace(cellValue.ToString()))
                {
                    if (int.TryParse(cellValue.ToString(), out int valorCelda) && valorCelda >= 0)
                    {
                        valores.Add(valorCelda);
                    }
                    else
                    {
                        MessageBox.Show(this, "Ingrese un número válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return new List<int>();
                    }
                }
                else
                {
                    
                    valores.Add(0);
                }
            }

            return valores;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            FormPanelUsuario formPanelUsuario = new FormPanelUsuario(_usuario);

            formPanelUsuario.FormClosed += (s, args) =>
            {
                this.Close();
            };

            formPanelUsuario.Show();
            this.Hide();
        }
        public void RecargarPrograma()
        {

            FrmPago frmPago = new FrmPago(_usuario);
            frmPago.Show();
            this.Close();
        }
    }
}