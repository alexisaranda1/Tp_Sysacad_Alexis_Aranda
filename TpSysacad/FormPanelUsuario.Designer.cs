namespace Formularios
{
    partial class FormPanelUsuario
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
            btnRegistrarEstudiante = new Button();
            btnGestionarCursos = new Button();
            label1 = new Label();
            label2 = new Label();
            btnInscripcionCurso = new Button();
            btnConsultarHorario = new Button();
            btnRealizarPagos = new Button();
            btnSalir = new Button();
            btnGestionarListasEspera = new Button();
            btnGestionarRequisitos = new Button();
            btnGestionarProfesor = new Button();
            bttnGenerarReporte = new Button();
            btnVerCursos = new Button();
            SuspendLayout();
            // 
            // btnRegistrarEstudiante
            // 
            btnRegistrarEstudiante.Location = new Point(205, 40);
            btnRegistrarEstudiante.Margin = new Padding(2);
            btnRegistrarEstudiante.Name = "btnRegistrarEstudiante";
            btnRegistrarEstudiante.Size = new Size(130, 20);
            btnRegistrarEstudiante.TabIndex = 0;
            btnRegistrarEstudiante.Text = "Registrar Estudiante";
            btnRegistrarEstudiante.UseVisualStyleBackColor = true;
            btnRegistrarEstudiante.Click += button1_Click;
            // 
            // btnGestionarCursos
            // 
            btnGestionarCursos.Location = new Point(205, 64);
            btnGestionarCursos.Margin = new Padding(2);
            btnGestionarCursos.Name = "btnGestionarCursos";
            btnGestionarCursos.Size = new Size(130, 20);
            btnGestionarCursos.TabIndex = 1;
            btnGestionarCursos.Text = "Gestionar Curso";
            btnGestionarCursos.UseVisualStyleBackColor = true;
            btnGestionarCursos.Click += BtnGestionarCursos_Click;
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(70, 14);
            label1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.HotTrack;
            label2.Location = new Point(255, 9);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 2;
            label2.Text = "Panel";
            // 
            // btnInscripcionCurso
            // 
            btnInscripcionCurso.Location = new Point(205, 40);
            btnInscripcionCurso.Margin = new Padding(2);
            btnInscripcionCurso.Name = "btnInscripcionCurso";
            btnInscripcionCurso.Size = new Size(130, 20);
            btnInscripcionCurso.TabIndex = 3;
            btnInscripcionCurso.Text = "Inscripcion a cursos";
            btnInscripcionCurso.UseVisualStyleBackColor = true;
            btnInscripcionCurso.Click += button2_Click;
            // 
            // btnConsultarHorario
            // 
            btnConsultarHorario.Location = new Point(205, 64);
            btnConsultarHorario.Margin = new Padding(2);
            btnConsultarHorario.Name = "btnConsultarHorario";
            btnConsultarHorario.Size = new Size(130, 20);
            btnConsultarHorario.TabIndex = 4;
            btnConsultarHorario.Text = "Consultar Horario";
            btnConsultarHorario.UseVisualStyleBackColor = true;
            btnConsultarHorario.Click += button3_Click;
            // 
            // btnRealizarPagos
            // 
            btnRealizarPagos.Location = new Point(205, 179);
            btnRealizarPagos.Margin = new Padding(2);
            btnRealizarPagos.Name = "btnRealizarPagos";
            btnRealizarPagos.Size = new Size(130, 20);
            btnRealizarPagos.TabIndex = 5;
            btnRealizarPagos.Text = "Realizar Pagos";
            btnRealizarPagos.UseVisualStyleBackColor = true;
            btnRealizarPagos.Click += button4_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(205, 224);
            btnSalir.Margin = new Padding(2);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(130, 20);
            btnSalir.TabIndex = 6;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnGestionarListasEspera
            // 
            btnGestionarListasEspera.Location = new Point(205, 112);
            btnGestionarListasEspera.Name = "btnGestionarListasEspera";
            btnGestionarListasEspera.Size = new Size(130, 23);
            btnGestionarListasEspera.TabIndex = 7;
            btnGestionarListasEspera.Text = "Gestionar Espera";
            btnGestionarListasEspera.UseVisualStyleBackColor = true;
            btnGestionarListasEspera.Click += btnGestionarListasEspera_Click;
            // 
            // btnGestionarRequisitos
            // 
            btnGestionarRequisitos.Location = new Point(205, 141);
            btnGestionarRequisitos.Name = "btnGestionarRequisitos";
            btnGestionarRequisitos.Size = new Size(130, 23);
            btnGestionarRequisitos.TabIndex = 8;
            btnGestionarRequisitos.Text = "Gestionar Requisitos";
            btnGestionarRequisitos.UseVisualStyleBackColor = true;
            btnGestionarRequisitos.Click += btnGestionarRequisitos_Click;
            // 
            // btnGestionarProfesor
            // 
            btnGestionarProfesor.Location = new Point(205, 179);
            btnGestionarProfesor.Name = "btnGestionarProfesor";
            btnGestionarProfesor.Size = new Size(130, 23);
            btnGestionarProfesor.TabIndex = 9;
            btnGestionarProfesor.Text = "Gestionar Profesores";
            btnGestionarProfesor.UseVisualStyleBackColor = true;
            btnGestionarProfesor.Click += btnGestionarProfesor_Click;
            // 
            // bttnGenerarReporte
            // 
            bttnGenerarReporte.Location = new Point(205, 89);
            bttnGenerarReporte.Name = "bttnGenerarReporte";
            bttnGenerarReporte.Size = new Size(130, 20);
            bttnGenerarReporte.TabIndex = 10;
            bttnGenerarReporte.Text = "Gnerar Reporte";
            bttnGenerarReporte.UseVisualStyleBackColor = true;
            bttnGenerarReporte.Click += bttnGenerarReporte_Click;
            // 
            // btnVerCursos
            // 
            btnVerCursos.Location = new Point(357, 198);
            btnVerCursos.Name = "btnVerCursos";
            btnVerCursos.Size = new Size(75, 23);
            btnVerCursos.TabIndex = 11;
            btnVerCursos.Text = "Ver Cursos";
            btnVerCursos.UseVisualStyleBackColor = true;
            btnVerCursos.Click += btnVerCursos_Click;
            // 
            // FormPanelUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 270);
            Controls.Add(btnVerCursos);
            Controls.Add(bttnGenerarReporte);
            Controls.Add(btnGestionarProfesor);
            Controls.Add(btnGestionarRequisitos);
            Controls.Add(btnGestionarListasEspera);
            Controls.Add(btnSalir);
            Controls.Add(btnRealizarPagos);
            Controls.Add(btnConsultarHorario);
            Controls.Add(btnInscripcionCurso);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnGestionarCursos);
            Controls.Add(btnRegistrarEstudiante);
            Margin = new Padding(2);
            Name = "FormPanelUsuario";
            Text = "PanelUsuario";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRegistrarEstudiante;
        private Button btnGestionarCursos;
        private Label label1;
        private Label label2;
        private Button btnInscripcionCurso;
        private Button btnConsultarHorario;
        private Button btnRealizarPagos;
        private Button btnSalir;
        private Button btnGestionarListasEspera;
        private Button btnGestionarRequisitos;
        private Button btnGestionarProfesor;
        private Button bttnGenerarReporte;
        private Button btnVerCursos;
    }
}