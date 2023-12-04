namespace Formularios
{
    partial class FormGenerarReportes
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
            dataGridViewReportes = new DataGridView();
            Check = new DataGridViewCheckBoxColumn();
            Informe = new DataGridViewTextBoxColumn();
            label = new Label();
            cBCurso = new ComboBox();
            btnMuestra = new Button();
            btnGenerador = new Button();
            cBPeriodo = new ComboBox();
            cBPago = new ComboBox();
            btnAtras = new Button();
            cBEspera = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewReportes).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewReportes
            // 
            dataGridViewReportes.AllowUserToAddRows = false;
            dataGridViewReportes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewReportes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewReportes.Columns.AddRange(new DataGridViewColumn[] { Check, Informe });
            dataGridViewReportes.Location = new Point(82, 67);
            dataGridViewReportes.Name = "dataGridViewReportes";
            dataGridViewReportes.RowHeadersWidth = 62;
            dataGridViewReportes.RowTemplate.Height = 33;
            dataGridViewReportes.Size = new Size(677, 225);
            dataGridViewReportes.TabIndex = 0;
            dataGridViewReportes.CellContentClick += dataGridViewReportes_CellContentClick;
            // 
            // Check
            // 
            Check.HeaderText = "Check";
            Check.MinimumWidth = 8;
            Check.Name = "Check";
            Check.Width = 65;
            // 
            // Informe
            // 
            Informe.HeaderText = "Informe";
            Informe.MinimumWidth = 8;
            Informe.Name = "Informe";
            Informe.Width = 111;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(324, 9);
            label.Name = "label";
            label.Size = new Size(140, 25);
            label.TabIndex = 1;
            label.Text = "Generar Reporte";
            // 
            // cBCurso
            // 
            cBCurso.FormattingEnabled = true;
            cBCurso.Location = new Point(297, 298);
            cBCurso.Name = "cBCurso";
            cBCurso.Size = new Size(182, 33);
            cBCurso.TabIndex = 2;
            cBCurso.Text = "Curso";
            cBCurso.Visible = false;
            // 
            // btnMuestra
            // 
            btnMuestra.Location = new Point(82, 348);
            btnMuestra.Name = "btnMuestra";
            btnMuestra.Size = new Size(142, 34);
            btnMuestra.TabIndex = 3;
            btnMuestra.Text = "Mostrar Datos";
            btnMuestra.UseVisualStyleBackColor = true;
            btnMuestra.Click += btnMuestra_Click;
            // 
            // btnGenerador
            // 
            btnGenerador.Location = new Point(82, 348);
            btnGenerador.Name = "btnGenerador";
            btnGenerador.Size = new Size(156, 34);
            btnGenerador.TabIndex = 4;
            btnGenerador.Text = "Generar Reporte";
            btnGenerador.UseVisualStyleBackColor = true;
            btnGenerador.Visible = false;
            btnGenerador.Click += btnGenerador_Click;
            // 
            // cBPeriodo
            // 
            cBPeriodo.FormattingEnabled = true;
            cBPeriodo.Location = new Point(297, 298);
            cBPeriodo.Name = "cBPeriodo";
            cBPeriodo.Size = new Size(182, 33);
            cBPeriodo.TabIndex = 5;
            cBPeriodo.Text = "Periodo";
            cBPeriodo.Visible = false;
            // 
            // cBPago
            // 
            cBPago.FormattingEnabled = true;
            cBPago.Location = new Point(297, 298);
            cBPago.Name = "cBPago";
            cBPago.Size = new Size(182, 33);
            cBPago.TabIndex = 6;
            cBPago.Text = "Pago";
            cBPago.Visible = false;
            // 
            // btnAtras
            // 
            btnAtras.Location = new Point(23, 404);
            btnAtras.Name = "btnAtras";
            btnAtras.Size = new Size(112, 34);
            btnAtras.TabIndex = 7;
            btnAtras.Text = "Atras";
            btnAtras.UseVisualStyleBackColor = true;
            btnAtras.Click += btnAtras_Click;
            // 
            // cBEspera
            // 
            cBEspera.FormattingEnabled = true;
            cBEspera.Location = new Point(297, 298);
            cBEspera.Name = "cBEspera";
            cBEspera.Size = new Size(182, 33);
            cBEspera.TabIndex = 8;
            cBEspera.Text = "Espera Por Curso";
            cBEspera.Visible = false;
            // 
            // FormGenerarReportes
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cBEspera);
            Controls.Add(btnAtras);
            Controls.Add(cBPago);
            Controls.Add(cBPeriodo);
            Controls.Add(btnGenerador);
            Controls.Add(btnMuestra);
            Controls.Add(cBCurso);
            Controls.Add(label);
            Controls.Add(dataGridViewReportes);
            Name = "FormGenerarReportes";
            Text = "FormGemerarReportes";
            ((System.ComponentModel.ISupportInitialize)dataGridViewReportes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewReportes;
        private DataGridViewCheckBoxColumn Check;
        private DataGridViewTextBoxColumn Informe;
        private Label label;
        private ComboBox cBCurso;
        private Button btnMuestra;
        private Button btnGenerador;
        private ComboBox cBPeriodo;
        private ComboBox cBPago;
        private Button btnAtras;
        private ComboBox cBEspera;
    }
}