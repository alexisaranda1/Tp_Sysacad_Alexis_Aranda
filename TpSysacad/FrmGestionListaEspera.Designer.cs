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
            dtgvListaEspera.Location = new Point(116, 183);
            dtgvListaEspera.Margin = new Padding(4, 5, 4, 5);
            dtgvListaEspera.Name = "dtgvListaEspera";
            dtgvListaEspera.RowHeadersWidth = 62;
            dtgvListaEspera.RowTemplate.Height = 25;
            dtgvListaEspera.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvListaEspera.Size = new Size(779, 272);
            dtgvListaEspera.TabIndex = 2;
            dtgvListaEspera.CellClick += dtgvListaEspera_CellClick;
            // 
            // btnVerlista
            // 
            btnVerlista.Location = new Point(391, 465);
            btnVerlista.Margin = new Padding(4, 5, 4, 5);
            btnVerlista.Name = "btnVerlista";
            btnVerlista.Size = new Size(269, 38);
            btnVerlista.TabIndex = 3;
            btnVerlista.Text = "Consultar Lista de Espera";
            btnVerlista.UseVisualStyleBackColor = true;
            btnVerlista.Click += btnVerlista_Click;
            // 
            // btnEliminarEstudiante
            // 
            btnEliminarEstudiante.Location = new Point(669, 465);
            btnEliminarEstudiante.Margin = new Padding(4, 5, 4, 5);
            btnEliminarEstudiante.Name = "btnEliminarEstudiante";
            btnEliminarEstudiante.Size = new Size(226, 38);
            btnEliminarEstudiante.TabIndex = 4;
            btnEliminarEstudiante.Text = "Eliminar Estudiante";
            btnEliminarEstudiante.UseVisualStyleBackColor = true;
            btnEliminarEstudiante.Click += btnEliminarEstudiante_Click_1;
            // 
            // btnAgregarEstudiante
            // 
            btnAgregarEstudiante.Location = new Point(116, 465);
            btnAgregarEstudiante.Margin = new Padding(4, 5, 4, 5);
            btnAgregarEstudiante.Name = "btnAgregarEstudiante";
            btnAgregarEstudiante.Size = new Size(253, 38);
            btnAgregarEstudiante.TabIndex = 5;
            btnAgregarEstudiante.Text = "Agregar Estudiante";
            btnAgregarEstudiante.UseVisualStyleBackColor = true;
            btnAgregarEstudiante.Click += btnAgregarEstudiante_Click_1;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(454, 465);
            btnAgregar.Margin = new Padding(4, 5, 4, 5);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(146, 38);
            btnAgregar.TabIndex = 6;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(17, 617);
            btnSalir.Margin = new Padding(4, 5, 4, 5);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(107, 38);
            btnSalir.TabIndex = 7;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // label
            // 
            label.Location = new Point(264, 40);
            label.Margin = new Padding(4, 0, 4, 0);
            label.Name = "label";
            label.Size = new Size(377, 138);
            label.TabIndex = 8;
            label.Text = "label";
            // 
            // lblAvisoListavacia
            // 
            lblAvisoListavacia.Location = new Point(163, 212);
            lblAvisoListavacia.Margin = new Padding(4, 0, 4, 0);
            lblAvisoListavacia.Name = "lblAvisoListavacia";
            lblAvisoListavacia.Size = new Size(681, 202);
            lblAvisoListavacia.TabIndex = 9;
            lblAvisoListavacia.Text = "Aviso Lista vacia";
            // 
            // FrmGestionListaEspera
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(lblAvisoListavacia);
            Controls.Add(label);
            Controls.Add(btnSalir);
            Controls.Add(btnAgregar);
            Controls.Add(btnAgregarEstudiante);
            Controls.Add(btnEliminarEstudiante);
            Controls.Add(btnVerlista);
            Controls.Add(dtgvListaEspera);
            Margin = new Padding(4, 5, 4, 5);
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