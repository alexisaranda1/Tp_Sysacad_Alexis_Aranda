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
            SuspendLayout();
            // 
            // btnRegistrarEstudiante
            // 
            btnRegistrarEstudiante.Location = new Point(293, 67);
            btnRegistrarEstudiante.Name = "btnRegistrarEstudiante";
            btnRegistrarEstudiante.Size = new Size(186, 33);
            btnRegistrarEstudiante.TabIndex = 0;
            btnRegistrarEstudiante.Text = "Registrar Estudiante";
            btnRegistrarEstudiante.UseVisualStyleBackColor = true;
            btnRegistrarEstudiante.Click += button1_Click;
            // 
            // btnGestionarCursos
            // 
            btnGestionarCursos.Location = new Point(293, 146);
            btnGestionarCursos.Name = "btnGestionarCursos";
            btnGestionarCursos.Size = new Size(186, 33);
            btnGestionarCursos.TabIndex = 1;
            btnGestionarCursos.Text = "Gestionar Curso";
            btnGestionarCursos.UseVisualStyleBackColor = true;
            btnGestionarCursos.Click += BtnGestionarCursos_Click;
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.HotTrack;
            label2.Location = new Point(364, 15);
            label2.Name = "label2";
            label2.Size = new Size(53, 25);
            label2.TabIndex = 2;
            label2.Text = "Panel";
            // 
            // btnInscripcionCurso
            // 
            btnInscripcionCurso.Location = new Point(293, 67);
            btnInscripcionCurso.Name = "btnInscripcionCurso";
            btnInscripcionCurso.Size = new Size(186, 33);
            btnInscripcionCurso.TabIndex = 3;
            btnInscripcionCurso.Text = "Inscripcion a cursos";
            btnInscripcionCurso.UseVisualStyleBackColor = true;
            btnInscripcionCurso.Click += button2_Click;
            // 
            // btnConsultarHorario
            // 
            btnConsultarHorario.Location = new Point(293, 107);
            btnConsultarHorario.Name = "btnConsultarHorario";
            btnConsultarHorario.Size = new Size(186, 33);
            btnConsultarHorario.TabIndex = 4;
            btnConsultarHorario.Text = "Consultar Horario";
            btnConsultarHorario.UseVisualStyleBackColor = true;
            btnConsultarHorario.Click += button3_Click;
            // 
            // btnRealizarPagos
            // 
            btnRealizarPagos.Location = new Point(293, 298);
            btnRealizarPagos.Name = "btnRealizarPagos";
            btnRealizarPagos.Size = new Size(186, 33);
            btnRealizarPagos.TabIndex = 5;
            btnRealizarPagos.Text = "Realizar Pagos";
            btnRealizarPagos.UseVisualStyleBackColor = true;
            btnRealizarPagos.Click += button4_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(293, 373);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(186, 33);
            btnSalir.TabIndex = 6;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnGestionarListasEspera
            // 
            btnGestionarListasEspera.Location = new Point(293, 187);
            btnGestionarListasEspera.Margin = new Padding(4, 5, 4, 5);
            btnGestionarListasEspera.Name = "btnGestionarListasEspera";
            btnGestionarListasEspera.Size = new Size(186, 38);
            btnGestionarListasEspera.TabIndex = 7;
            btnGestionarListasEspera.Text = "Gestionar Espera";
            btnGestionarListasEspera.UseVisualStyleBackColor = true;
            btnGestionarListasEspera.Click += btnGestionarListasEspera_Click;
            // 
            // btnGestionarRequisitos
            // 
            btnGestionarRequisitos.Location = new Point(293, 235);
            btnGestionarRequisitos.Margin = new Padding(4, 5, 4, 5);
            btnGestionarRequisitos.Name = "btnGestionarRequisitos";
            btnGestionarRequisitos.Size = new Size(186, 38);
            btnGestionarRequisitos.TabIndex = 8;
            btnGestionarRequisitos.Text = "Gestionar Requisitos";
            btnGestionarRequisitos.UseVisualStyleBackColor = true;
            btnGestionarRequisitos.Click += btnGestionarRequisitos_Click;
            // 
            // btnGestionarProfesor
            // 
            btnGestionarProfesor.Location = new Point(293, 298);
            btnGestionarProfesor.Margin = new Padding(4, 5, 4, 5);
            btnGestionarProfesor.Name = "btnGestionarProfesor";
            btnGestionarProfesor.Size = new Size(186, 38);
            btnGestionarProfesor.TabIndex = 9;
            btnGestionarProfesor.Text = "Gestionar Profesores";
            btnGestionarProfesor.UseVisualStyleBackColor = true;
            btnGestionarProfesor.Click += btnGestionarProfesor_Click;
            // 
            // bttnGenerarReporte
            // 
            bttnGenerarReporte.Location = new Point(293, 107);
            bttnGenerarReporte.Name = "bttnGenerarReporte";
            bttnGenerarReporte.Size = new Size(186, 34);
            bttnGenerarReporte.TabIndex = 10;
            bttnGenerarReporte.Text = "Gnerar Reporte";
            bttnGenerarReporte.UseVisualStyleBackColor = true;
            bttnGenerarReporte.Click += bttnGenerarReporte_Click;
            // 
            // FormPanelUsuario
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}