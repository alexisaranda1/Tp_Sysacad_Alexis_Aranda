namespace Formularios
{
    partial class FrmGestionListaEspera
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
            dtgvListaEspera = new DataGridView();
            btnVerlista = new Button();
            btnEliminarEstudiante = new Button();
            btnAgregarEstudiante = new Button();
            btnAgregar = new Button();
            btnSalir = new Button();
            label = new Label();
            lblAvisoListavacia = new Label();
            ((System.ComponentModel.ISupportInitialize)dtgvListaEspera).BeginInit();
            SuspendLayout();
            // 
            // dtgvListaEspera
            // 
            dtgvListaEspera.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgvListaEspera.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgvListaEspera.Location = new Point(81, 110);
            dtgvListaEspera.Name = "dtgvListaEspera";
            dtgvListaEspera.RowHeadersWidth = 62;
            dtgvListaEspera.RowTemplate.Height = 25;
            dtgvListaEspera.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvListaEspera.Size = new Size(545, 163);
            dtgvListaEspera.TabIndex = 2;
            dtgvListaEspera.CellClick += dtgvListaEspera_CellClick;
            // 
            // btnVerlista
            // 
            btnVerlista.Location = new Point(274, 279);
            btnVerlista.Name = "btnVerlista";
            btnVerlista.Size = new Size(188, 23);
            btnVerlista.TabIndex = 3;
            btnVerlista.Text = "Consultar Lista de Espera";
            btnVerlista.UseVisualStyleBackColor = true;
            btnVerlista.Click += btnVerlista_Click;
            // 
            // btnEliminarEstudiante
            // 
            btnEliminarEstudiante.Location = new Point(468, 279);
            btnEliminarEstudiante.Name = "btnEliminarEstudiante";
            btnEliminarEstudiante.Size = new Size(158, 23);
            btnEliminarEstudiante.TabIndex = 4;
            btnEliminarEstudiante.Text = "Eliminar Estudiante";
            btnEliminarEstudiante.UseVisualStyleBackColor = true;
            btnEliminarEstudiante.Click += btnEliminarEstudiante_Click_1;
            // 
            // btnAgregarEstudiante
            // 
            btnAgregarEstudiante.Location = new Point(81, 279);
            btnAgregarEstudiante.Name = "btnAgregarEstudiante";
            btnAgregarEstudiante.Size = new Size(177, 23);
            btnAgregarEstudiante.TabIndex = 5;
            btnAgregarEstudiante.Text = "Agregar Estudiante";
            btnAgregarEstudiante.UseVisualStyleBackColor = true;
            btnAgregarEstudiante.Click += btnAgregarEstudiante_Click_1;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(318, 279);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(102, 23);
            btnAgregar.TabIndex = 6;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(12, 370);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 7;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // label
            // 
            label.Location = new Point(185, 24);
            label.Name = "label";
            label.Size = new Size(264, 83);
            label.TabIndex = 8;
            label.Text = "label";
            // 
            // lblAvisoListavacia
            // 
            lblAvisoListavacia.Location = new Point(114, 127);
            lblAvisoListavacia.Name = "lblAvisoListavacia";
            lblAvisoListavacia.Size = new Size(477, 121);
            lblAvisoListavacia.TabIndex = 9;
            lblAvisoListavacia.Text = "Aviso Lista vacia";
            // 
            // FrmGestionListaEspera
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 421);
            Controls.Add(lblAvisoListavacia);
            Controls.Add(label);
            Controls.Add(btnSalir);
            Controls.Add(btnAgregar);
            Controls.Add(btnAgregarEstudiante);
            Controls.Add(btnEliminarEstudiante);
            Controls.Add(btnVerlista);
            Controls.Add(dtgvListaEspera);
            Name = "FrmGestionListaEspera";
            Text = "s";
            ((System.ComponentModel.ISupportInitialize)dtgvListaEspera).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dtgvListaEspera;
        private Button btnVerlista;
        private Button btnEliminarEstudiante;
        private Button btnAgregarEstudiante;
        private Button btnAgregar;
        private Button btnSalir;
        private Label label;
        private Label lblAvisoListavacia;
    }
}