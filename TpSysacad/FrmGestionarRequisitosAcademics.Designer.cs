namespace Formularios
{
    partial class FrmGestionarRequisitosAcademics
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
            dataGridView1 = new DataGridView();
            Codigo = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            PromedioRequerido = new DataGridViewTextBoxColumn();
            Correlatividades = new DataGridViewTextBoxColumn();
            CreditosRequeridos = new DataGridViewTextBoxColumn();
            lblListaVacia = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Codigo, Nombre, PromedioRequerido, Correlatividades, CreditosRequeridos });
            dataGridView1.Location = new Point(30, 147);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(636, 150);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;

            // 
            // Codigo
            // 
            Codigo.HeaderText = "Codigo";
            Codigo.Name = "Codigo";
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.Name = "Nombre";
            // 
            // PromedioRequerido
            // 
            PromedioRequerido.HeaderText = "PromedioRequerido";
            PromedioRequerido.Name = "PromedioRequerido";
            PromedioRequerido.Width = 120;
            // 
            // Correlatividades
            // 
            Correlatividades.HeaderText = "CreditosRequeridos";
            Correlatividades.Name = "Correlatividades";
            Correlatividades.Width = 120;
            // 
            // CreditosRequeridos
            // 
            CreditosRequeridos.HeaderText = "Correlatividades";
            CreditosRequeridos.Name = "CreditosRequeridos";
            CreditosRequeridos.Width = 150;
            // 
            // lblListaVacia
            // 
            lblListaVacia.Location = new Point(134, 185);
            lblListaVacia.Name = "lblListaVacia";
            lblListaVacia.Size = new Size(475, 88);
            lblListaVacia.TabIndex = 1;
            lblListaVacia.Text = "label1";
            // 
            // FrmGestionarRequisitosAcademics
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblListaVacia);
            Controls.Add(dataGridView1);
            Name = "FrmGestionarRequisitosAcademics";
            Text = "FrmGestionarRequisitosAcademics";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Label lblListaVacia;
        private DataGridViewTextBoxColumn Codigo;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn PromedioRequerido;
        private DataGridViewTextBoxColumn Correlatividades;
        private DataGridViewTextBoxColumn CreditosRequeridos;
    }
}