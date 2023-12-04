using BibliotecaCLases.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FormMostrarReporte : Form
    {
        private FormGenerarReportes _ownerForm;
        private PDF pdf;
        string _reporte;
        public FormMostrarReporte(FormGenerarReportes ownerForm, string reporte)
        {
            pdf = new PDF();
            _ownerForm = ownerForm;
            _reporte = reporte;
            InitializeComponent();
        }

        private void FormMostrarReporte_Load(object sender, EventArgs e)
        {
            lblMuestraPDF.Text = _reporte;
        }

        private void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            pdf.CrearPDF(_reporte);
        }
    }
}
