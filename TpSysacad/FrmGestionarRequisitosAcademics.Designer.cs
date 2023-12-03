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
            lblListaVacia = new Label();
            btnSalir = new Button();
            btnEditarPromedio = new Button();
            btnEditarCreditos = new Button();
            btnEditarCorrelativas = new Button();
            txtNuevoPromedio = new TextBox();
            btnGuardar = new Button();
            txtNuevoCredito = new TextBox();
            btnGuardarCredito = new Button();
            btnGuardarCorrelativa = new Button();
            Codigo = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            PromedioRequerido = new DataGridViewTextBoxColumn();
            Correlatividades = new DataGridViewTextBoxColumn();
            CreditosRequeridos = new DataGridViewTextBoxColumn();
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
            // lblListaVacia
            // 
            lblListaVacia.Location = new Point(128, 147);
            lblListaVacia.Name = "lblListaVacia";
            lblListaVacia.Size = new Size(475, 88);
            lblListaVacia.TabIndex = 1;
            lblListaVacia.Text = "label1";
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(12, 387);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 2;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnEditarPromedio
            // 
            btnEditarPromedio.Location = new Point(70, 327);
            btnEditarPromedio.Name = "btnEditarPromedio";
            btnEditarPromedio.Size = new Size(122, 23);
            btnEditarPromedio.TabIndex = 3;
            btnEditarPromedio.Text = "Editar Promedio";
            btnEditarPromedio.UseVisualStyleBackColor = true;
            btnEditarPromedio.Click += btnEditarPromedio_Click;
            // 
            // btnEditarCreditos
            // 
            btnEditarCreditos.Location = new Point(282, 327);
            btnEditarCreditos.Name = "btnEditarCreditos";
            btnEditarCreditos.Size = new Size(137, 23);
            btnEditarCreditos.TabIndex = 4;
            btnEditarCreditos.Text = "Editar Creditos";
            btnEditarCreditos.UseVisualStyleBackColor = true;
            btnEditarCreditos.Click += btnEditarCreditos_Click_1;
            // 
            // btnEditarCorrelativas
            // 
            btnEditarCorrelativas.Location = new Point(498, 327);
            btnEditarCorrelativas.Name = "btnEditarCorrelativas";
            btnEditarCorrelativas.Size = new Size(136, 23);
            btnEditarCorrelativas.TabIndex = 5;
            btnEditarCorrelativas.Text = "Editar Correlativas";
            btnEditarCorrelativas.UseVisualStyleBackColor = true;
            btnEditarCorrelativas.Click += btnEditarCorrelativas_Click_1;
            // 
            // txtNuevoPromedio
            // 
            txtNuevoPromedio.Location = new Point(265, 258);
            txtNuevoPromedio.Name = "txtNuevoPromedio";
            txtNuevoPromedio.PlaceholderText = "Ingrese Nuevo Promedio";
            txtNuevoPromedio.Size = new Size(154, 23);
            txtNuevoPromedio.TabIndex = 7;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(282, 303);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(137, 23);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar Promedio";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtNuevoCredito
            // 
            txtNuevoCredito.Location = new Point(265, 258);
            txtNuevoCredito.Name = "txtNuevoCredito";
            txtNuevoCredito.PlaceholderText = "Nuevo Credito";
            txtNuevoCredito.Size = new Size(134, 23);
            txtNuevoCredito.TabIndex = 9;
            // 
            // btnGuardarCredito
            // 
            btnGuardarCredito.Location = new Point(282, 303);
            btnGuardarCredito.Name = "btnGuardarCredito";
            btnGuardarCredito.Size = new Size(131, 23);
            btnGuardarCredito.TabIndex = 10;
            btnGuardarCredito.Text = "Guardar Credito";
            btnGuardarCredito.UseVisualStyleBackColor = true;
            btnGuardarCredito.Click += btnGuardarCredito_Click;
            // 
            // btnGuardarCorrelativa
            // 
            btnGuardarCorrelativa.Location = new Point(282, 356);
            btnGuardarCorrelativa.Name = "btnGuardarCorrelativa";
            btnGuardarCorrelativa.Size = new Size(137, 23);
            btnGuardarCorrelativa.TabIndex = 11;
            btnGuardarCorrelativa.Text = "Guardar Correlativa";
            btnGuardarCorrelativa.UseVisualStyleBackColor = true;
            btnGuardarCorrelativa.Click += btnGuardarCorrelativa_Click;
            // 
            // Codigo
            // 
            Codigo.HeaderText = "Codigo";
            Codigo.Name = "Codigo";
            Codigo.ReadOnly = true;
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.Name = "Nombre";
            Nombre.ReadOnly = true;
            // 
            // PromedioRequerido
            // 
            PromedioRequerido.HeaderText = "PromedioRequerido";
            PromedioRequerido.Name = "PromedioRequerido";
            PromedioRequerido.ReadOnly = true;
            PromedioRequerido.Width = 120;
            // 
            // Correlatividades
            // 
            Correlatividades.HeaderText = "CreditosRequeridos";
            Correlatividades.Name = "Correlatividades";
            Correlatividades.ReadOnly = true;
            Correlatividades.Width = 120;
            // 
            // CreditosRequeridos
            // 
            CreditosRequeridos.HeaderText = "Correlatividades";
            CreditosRequeridos.Name = "CreditosRequeridos";
            CreditosRequeridos.ReadOnly = true;
            CreditosRequeridos.Width = 1000;
            // 
            // FrmGestionarRequisitosAcademics
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGuardarCorrelativa);
            Controls.Add(btnGuardarCredito);
            Controls.Add(txtNuevoCredito);
            Controls.Add(btnGuardar);
            Controls.Add(txtNuevoPromedio);
            Controls.Add(btnEditarCorrelativas);
            Controls.Add(btnEditarCreditos);
            Controls.Add(btnEditarPromedio);
            Controls.Add(btnSalir);
            Controls.Add(lblListaVacia);
            Controls.Add(dataGridView1);
            Name = "FrmGestionarRequisitosAcademics";
            Text = "FrmGestionarRequisitosAcademics";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label lblListaVacia;
        private Button btnSalir;
        private Button btnEditarPromedio;
        private Button btnEditarCreditos;
        private Button btnEditarCorrelativas;
        private TextBox txtNuevoPromedio;
        private Button btnGuardar;
        private TextBox txtNuevoCredito;
        private Button btnGuardarCredito;
        private Button btnGuardarCorrelativa;
        private DataGridViewTextBoxColumn Codigo;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn PromedioRequerido;
        private DataGridViewTextBoxColumn Correlatividades;
        private DataGridViewTextBoxColumn CreditosRequeridos;
    }
}