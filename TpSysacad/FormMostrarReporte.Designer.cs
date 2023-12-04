namespace Formularios
{
    partial class FormMostrarReporte
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblMuestraPDF = new Label();
            btnGenerarPDF = new Button();
            SuspendLayout();
            // 
            // lblMuestraPDF
            // 
            lblMuestraPDF.AutoSize = true;
            lblMuestraPDF.Location = new Point(195, 36);
            lblMuestraPDF.Name = "lblMuestraPDF";
            lblMuestraPDF.Size = new Size(46, 25);
            lblMuestraPDF.TabIndex = 0;
            lblMuestraPDF.Text = "hola";
            // 
            // btnGenerarPDF
            // 
            btnGenerarPDF.Location = new Point(512, 367);
            btnGenerarPDF.Name = "btnGenerarPDF";
            btnGenerarPDF.Size = new Size(178, 34);
            btnGenerarPDF.TabIndex = 1;
            btnGenerarPDF.Text = "Generar PDF";
            btnGenerarPDF.UseVisualStyleBackColor = true;
            btnGenerarPDF.Click += btnGenerarPDF_Click;
            // 
            // FormMostrarReporte
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(702, 488);
            Controls.Add(btnGenerarPDF);
            Controls.Add(lblMuestraPDF);
            Name = "FormMostrarReporte";
            Text = "FormMostrarReporte";
            Load += FormMostrarReporte_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMuestraPDF;
        private Button btnGenerarPDF;
    }
}