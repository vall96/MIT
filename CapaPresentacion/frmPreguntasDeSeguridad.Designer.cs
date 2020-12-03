namespace CapaPresentacion
{
    partial class frmPreguntasDeSeguridad
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
            this.lvPreguntasSeguridad = new System.Windows.Forms.ListView();
            this.colCodigo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPreguntas = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtPregunta = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblPregunta = new System.Windows.Forms.Label();
            this.btoAgregar = new System.Windows.Forms.Button();
            this.btoCancelar = new System.Windows.Forms.Button();
            this.btoEliminar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvPreguntasSeguridad
            // 
            this.lvPreguntasSeguridad.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCodigo,
            this.colPreguntas});
            this.lvPreguntasSeguridad.Cursor = System.Windows.Forms.Cursors.Default;
            this.lvPreguntasSeguridad.FullRowSelect = true;
            this.lvPreguntasSeguridad.GridLines = true;
            this.lvPreguntasSeguridad.Location = new System.Drawing.Point(23, 139);
            this.lvPreguntasSeguridad.Name = "lvPreguntasSeguridad";
            this.lvPreguntasSeguridad.Size = new System.Drawing.Size(353, 226);
            this.lvPreguntasSeguridad.TabIndex = 0;
            this.lvPreguntasSeguridad.UseCompatibleStateImageBehavior = false;
            this.lvPreguntasSeguridad.View = System.Windows.Forms.View.Details;
            this.lvPreguntasSeguridad.DoubleClick += new System.EventHandler(this.lvPreguntasSeguridad_DoubleClick);
            // 
            // colCodigo
            // 
            this.colCodigo.Text = "Codigo";
            this.colCodigo.Width = 67;
            // 
            // colPreguntas
            // 
            this.colPreguntas.Text = "Preguntas";
            this.colPreguntas.Width = 280;
            // 
            // txtPregunta
            // 
            this.txtPregunta.Location = new System.Drawing.Point(120, 53);
            this.txtPregunta.Name = "txtPregunta";
            this.txtPregunta.Size = new System.Drawing.Size(256, 20);
            this.txtPregunta.TabIndex = 1;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(23, 53);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(80, 20);
            this.txtCodigo.TabIndex = 2;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(23, 34);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.TabIndex = 3;
            this.lblCodigo.Text = "Codigo:";
            // 
            // lblPregunta
            // 
            this.lblPregunta.AutoSize = true;
            this.lblPregunta.Location = new System.Drawing.Point(117, 34);
            this.lblPregunta.Name = "lblPregunta";
            this.lblPregunta.Size = new System.Drawing.Size(53, 13);
            this.lblPregunta.TabIndex = 4;
            this.lblPregunta.Text = "Pregunta:";
            // 
            // btoAgregar
            // 
            this.btoAgregar.Location = new System.Drawing.Point(23, 101);
            this.btoAgregar.Name = "btoAgregar";
            this.btoAgregar.Size = new System.Drawing.Size(75, 23);
            this.btoAgregar.TabIndex = 5;
            this.btoAgregar.Text = "Agregar";
            this.btoAgregar.UseVisualStyleBackColor = true;
            this.btoAgregar.Click += new System.EventHandler(this.btoAgregar_Click);
            // 
            // btoCancelar
            // 
            this.btoCancelar.Location = new System.Drawing.Point(301, 101);
            this.btoCancelar.Name = "btoCancelar";
            this.btoCancelar.Size = new System.Drawing.Size(75, 23);
            this.btoCancelar.TabIndex = 7;
            this.btoCancelar.Text = "Cancelar";
            this.btoCancelar.UseVisualStyleBackColor = true;
            this.btoCancelar.Click += new System.EventHandler(this.btoCancelar_Click);
            // 
            // btoEliminar
            // 
            this.btoEliminar.Location = new System.Drawing.Point(159, 101);
            this.btoEliminar.Name = "btoEliminar";
            this.btoEliminar.Size = new System.Drawing.Size(75, 23);
            this.btoEliminar.TabIndex = 8;
            this.btoEliminar.Text = "Eliminar";
            this.btoEliminar.UseVisualStyleBackColor = true;
            this.btoEliminar.Click += new System.EventHandler(this.btoEliminar_Click);
            // 
            // frmPreguntasDeSeguridad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 389);
            this.Controls.Add(this.btoEliminar);
            this.Controls.Add(this.btoCancelar);
            this.Controls.Add(this.btoAgregar);
            this.Controls.Add(this.lblPregunta);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.txtPregunta);
            this.Controls.Add(this.lvPreguntasSeguridad);
            this.Name = "frmPreguntasDeSeguridad";
            this.Text = "Preguntas De Seguridad";
            this.Load += new System.EventHandler(this.btoAgregar_Click);
            this.MdiChildActivate += new System.EventHandler(this.frmPreguntasDeSeguridad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColumnHeader colCodigo;
        private System.Windows.Forms.ColumnHeader colPreguntas;
        private System.Windows.Forms.TextBox txtPregunta;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblPregunta;
        private System.Windows.Forms.Button btoAgregar;
        private System.Windows.Forms.Button btoCancelar;
        private System.Windows.Forms.Button btoEliminar;
        public System.Windows.Forms.ListView lvPreguntasSeguridad;
    }
}