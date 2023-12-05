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
            btnGuardar = new Button();
            ((System.ComponentModel.ISupportInitialize)dtgProfesores).BeginInit();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(17, 630);
            btnSalir.Margin = new Padding(4, 5, 4, 5);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(107, 38);
            btnSalir.TabIndex = 0;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnAgregarProfesor
            // 
            btnAgregarProfesor.Location = new Point(87, 505);
            btnAgregarProfesor.Margin = new Padding(4, 5, 4, 5);
            btnAgregarProfesor.Name = "btnAgregarProfesor";
            btnAgregarProfesor.Size = new Size(164, 38);
            btnAgregarProfesor.TabIndex = 2;
            btnAgregarProfesor.Text = "Agregar Profesor";
            btnAgregarProfesor.UseVisualStyleBackColor = true;
            btnAgregarProfesor.Click += btnAgregarProfesor_Click;
            // 
            // btnEditarProfesor
            // 
            btnEditarProfesor.Location = new Point(293, 505);
            btnEditarProfesor.Margin = new Padding(4, 5, 4, 5);
            btnEditarProfesor.Name = "btnEditarProfesor";
            btnEditarProfesor.Size = new Size(159, 38);
            btnEditarProfesor.TabIndex = 3;
            btnEditarProfesor.Text = "Editar Profesor";
            btnEditarProfesor.UseVisualStyleBackColor = true;
            btnEditarProfesor.Click += btnEditarProfesor_Click;
            // 
            // btnEliminarProfesor
            // 
            btnEliminarProfesor.Location = new Point(529, 505);
            btnEliminarProfesor.Margin = new Padding(4, 5, 4, 5);
            btnEliminarProfesor.Name = "btnEliminarProfesor";
            btnEliminarProfesor.Size = new Size(167, 38);
            btnEliminarProfesor.TabIndex = 4;
            btnEliminarProfesor.Text = "Eliminar Profesor";
            btnEliminarProfesor.UseVisualStyleBackColor = true;
            btnEliminarProfesor.Click += btnEliminarProfesor_Click;
            // 
            // btnAgregarCurso
            // 
            btnAgregarCurso.Location = new Point(834, 505);
            btnAgregarCurso.Margin = new Padding(4, 5, 4, 5);
            btnAgregarCurso.Name = "btnAgregarCurso";
            btnAgregarCurso.Size = new Size(247, 38);
            btnAgregarCurso.TabIndex = 5;
            btnAgregarCurso.Text = "Agregar Curso en Profesor";
            btnAgregarCurso.UseVisualStyleBackColor = true;
            btnAgregarCurso.Click += btnAgregarCurso_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(224, 50);
            txtNombre.Margin = new Padding(4, 5, 4, 5);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Nombre";
            txtNombre.Size = new Size(141, 31);
            txtNombre.TabIndex = 6;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(224, 143);
            txtApellido.Margin = new Padding(4, 5, 4, 5);
            txtApellido.Name = "txtApellido";
            txtApellido.PlaceholderText = "Apellido";
            txtApellido.Size = new Size(141, 31);
            txtApellido.TabIndex = 7;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(433, 50);
            txtDni.Margin = new Padding(4, 5, 4, 5);
            txtDni.Name = "txtDni";
            txtDni.PlaceholderText = "DNI";
            txtDni.Size = new Size(141, 31);
            txtDni.TabIndex = 8;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(433, 143);
            txtDireccion.Margin = new Padding(4, 5, 4, 5);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.PlaceholderText = "Direccion";
            txtDireccion.Size = new Size(141, 31);
            txtDireccion.TabIndex = 9;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(684, 50);
            txtCorreo.Margin = new Padding(4, 5, 4, 5);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.PlaceholderText = "Correo";
            txtCorreo.Size = new Size(141, 31);
            txtCorreo.TabIndex = 10;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(684, 143);
            txtTelefono.Margin = new Padding(4, 5, 4, 5);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PlaceholderText = "Telefono";
            txtTelefono.Size = new Size(141, 31);
            txtTelefono.TabIndex = 11;
            // 
            // btnRegistrarProfesor
            // 
            btnRegistrarProfesor.Location = new Point(387, 630);
            btnRegistrarProfesor.Margin = new Padding(4, 5, 4, 5);
            btnRegistrarProfesor.Name = "btnRegistrarProfesor";
            btnRegistrarProfesor.Size = new Size(219, 38);
            btnRegistrarProfesor.TabIndex = 12;
            btnRegistrarProfesor.Text = "Registrar Profesor";
            btnRegistrarProfesor.UseVisualStyleBackColor = true;
            btnRegistrarProfesor.Click += btnRegistrarProfesor_Click;
            // 
            // dtgProfesores
            // 
            dtgProfesores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgProfesores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgProfesores.Location = new Point(13, 215);
            dtgProfesores.Margin = new Padding(4, 5, 4, 5);
            dtgProfesores.Name = "dtgProfesores";
            dtgProfesores.RowHeadersWidth = 62;
            dtgProfesores.RowTemplate.Height = 25;
            dtgProfesores.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dtgProfesores.Size = new Size(1107, 250);
            dtgProfesores.TabIndex = 13;
            dtgProfesores.CellClick += dtgProfesores_CellClick;
            // 
            // txtEspecializacion
            // 
            txtEspecializacion.Location = new Point(933, 97);
            txtEspecializacion.Margin = new Padding(4, 5, 4, 5);
            txtEspecializacion.Name = "txtEspecializacion";
            txtEspecializacion.PlaceholderText = "Especializacion";
            txtEspecializacion.Size = new Size(141, 31);
            txtEspecializacion.TabIndex = 14;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(433, 553);
            btnGuardar.Margin = new Padding(4, 5, 4, 5);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(107, 38);
            btnGuardar.TabIndex = 15;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // FrmGestionarProfesores
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(btnGuardar);
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
            Margin = new Padding(4, 5, 4, 5);
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
        private Button btnGuardar;
    }
}