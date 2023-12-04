namespace Formularios
{
    partial class FrmGestionarProfesores
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
            btnSalir = new Button();
            btnAgregarProfesor = new Button();
            btnEditarProfesor = new Button();
            btnEliminarProfesor = new Button();
            btnAgregarCurso = new Button();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtDni = new TextBox();
            txtDireccion = new TextBox();
            txtCorreo = new TextBox();
            txtTelefono = new TextBox();
            btnRegistrarProfesor = new Button();
            dtgProfesores = new DataGridView();
            txtEspecializacion = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dtgProfesores).BeginInit();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(12, 378);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 0;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnAgregarProfesor
            // 
            btnAgregarProfesor.Location = new Point(61, 303);
            btnAgregarProfesor.Name = "btnAgregarProfesor";
            btnAgregarProfesor.Size = new Size(115, 23);
            btnAgregarProfesor.TabIndex = 2;
            btnAgregarProfesor.Text = "Agregar Profesor";
            btnAgregarProfesor.UseVisualStyleBackColor = true;
            btnAgregarProfesor.Click += btnAgregarProfesor_Click;
            // 
            // btnEditarProfesor
            // 
            btnEditarProfesor.Location = new Point(205, 303);
            btnEditarProfesor.Name = "btnEditarProfesor";
            btnEditarProfesor.Size = new Size(111, 23);
            btnEditarProfesor.TabIndex = 3;
            btnEditarProfesor.Text = "Editar Profesor";
            btnEditarProfesor.UseVisualStyleBackColor = true;
            btnEditarProfesor.Click += btnEditarProfesor_Click;
            // 
            // btnEliminarProfesor
            // 
            btnEliminarProfesor.Location = new Point(370, 303);
            btnEliminarProfesor.Name = "btnEliminarProfesor";
            btnEliminarProfesor.Size = new Size(117, 23);
            btnEliminarProfesor.TabIndex = 4;
            btnEliminarProfesor.Text = "Eliminar Profesor";
            btnEliminarProfesor.UseVisualStyleBackColor = true;
            btnEliminarProfesor.Click += btnEliminarProfesor_Click;
            // 
            // btnAgregarCurso
            // 
            btnAgregarCurso.Location = new Point(584, 303);
            btnAgregarCurso.Name = "btnAgregarCurso";
            btnAgregarCurso.Size = new Size(173, 23);
            btnAgregarCurso.TabIndex = 5;
            btnAgregarCurso.Text = "Agregar Curso en Profesor";
            btnAgregarCurso.UseVisualStyleBackColor = true;
            btnAgregarCurso.Click += btnAgregarCurso_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(157, 30);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Nombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 6;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(157, 86);
            txtApellido.Name = "txtApellido";
            txtApellido.PlaceholderText = "Apellido";
            txtApellido.Size = new Size(100, 23);
            txtApellido.TabIndex = 7;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(303, 30);
            txtDni.Name = "txtDni";
            txtDni.PlaceholderText = "DNI";
            txtDni.Size = new Size(100, 23);
            txtDni.TabIndex = 8;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(303, 86);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.PlaceholderText = "Direccion";
            txtDireccion.Size = new Size(100, 23);
            txtDireccion.TabIndex = 9;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(479, 30);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.PlaceholderText = "Correo";
            txtCorreo.Size = new Size(100, 23);
            txtCorreo.TabIndex = 10;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(479, 86);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PlaceholderText = "Telefono";
            txtTelefono.Size = new Size(100, 23);
            txtTelefono.TabIndex = 11;
            // 
            // btnRegistrarProfesor
            // 
            btnRegistrarProfesor.Location = new Point(260, 332);
            btnRegistrarProfesor.Name = "btnRegistrarProfesor";
            btnRegistrarProfesor.Size = new Size(153, 23);
            btnRegistrarProfesor.TabIndex = 12;
            btnRegistrarProfesor.Text = "Registrar Profesor";
            btnRegistrarProfesor.UseVisualStyleBackColor = true;
            btnRegistrarProfesor.Click += btnRegistrarProfesor_Click;
            // 
            // dtgProfesores
            // 
            dtgProfesores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgProfesores.Location = new Point(33, 129);
            dtgProfesores.Name = "dtgProfesores";
            dtgProfesores.RowTemplate.Height = 25;
            dtgProfesores.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dtgProfesores.Size = new Size(724, 150);
            dtgProfesores.TabIndex = 13;
            dtgProfesores.CellClick += dtgProfesores_CellClick;
            // 
            // txtEspecializacion
            // 
            txtEspecializacion.Location = new Point(653, 58);
            txtEspecializacion.Name = "txtEspecializacion";
            txtEspecializacion.PlaceholderText = "Especializacion";
            txtEspecializacion.Size = new Size(100, 23);
            txtEspecializacion.TabIndex = 14;
            // 
            // FrmGestionarProfesores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtEspecializacion);
            Controls.Add(dtgProfesores);
            Controls.Add(btnRegistrarProfesor);
            Controls.Add(txtTelefono);
            Controls.Add(txtCorreo);
            Controls.Add(txtDireccion);
            Controls.Add(txtDni);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(btnAgregarCurso);
            Controls.Add(btnEliminarProfesor);
            Controls.Add(btnEditarProfesor);
            Controls.Add(btnAgregarProfesor);
            Controls.Add(btnSalir);
            Name = "FrmGestionarProfesores";
            Text = "FrmGestionarProfesores";
            Load += FrmGestionarProfesores_Load;
            ((System.ComponentModel.ISupportInitialize)dtgProfesores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSalir;
        private Button btnAgregarProfesor;
        private Button btnEditarProfesor;
        private Button btnEliminarProfesor;
        private Button btnAgregarCurso;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtDni;
        private TextBox txtDireccion;
        private TextBox txtCorreo;
        private TextBox txtTelefono;
        private Button btnRegistrarProfesor;
        private DataGridView dtgProfesores;
        private TextBox txtEspecializacion;
    }
}