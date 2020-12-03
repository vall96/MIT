namespace CapaPresentacion
{
    partial class frmCambiarRespuestas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCambiarRespuestas));
            this.lblSeleccionePregunta = new System.Windows.Forms.Label();
            this.cboPreguntas = new System.Windows.Forms.ComboBox();
            this.cboCodPreguntas = new System.Windows.Forms.ComboBox();
            this.txtRespuesta = new System.Windows.Forms.TextBox();
            this.lblIngreseRespuesta = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btoAceptar = new System.Windows.Forms.Button();
            this.btoCancelar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btoGurdar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSeleccionePregunta
            // 
            this.lblSeleccionePregunta.AutoSize = true;
            this.lblSeleccionePregunta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lblSeleccionePregunta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeleccionePregunta.Location = new System.Drawing.Point(9, 36);
            this.lblSeleccionePregunta.Name = "lblSeleccionePregunta";
            this.lblSeleccionePregunta.Size = new System.Drawing.Size(161, 18);
            this.lblSeleccionePregunta.TabIndex = 0;
            this.lblSeleccionePregunta.Text = "Seleccione la pregunta:";
            // 
            // cboPreguntas
            // 
            this.cboPreguntas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPreguntas.FormattingEnabled = true;
            this.cboPreguntas.Location = new System.Drawing.Point(268, 33);
            this.cboPreguntas.Name = "cboPreguntas";
            this.cboPreguntas.Size = new System.Drawing.Size(338, 26);
            this.cboPreguntas.TabIndex = 2;
            this.cboPreguntas.SelectedIndexChanged += new System.EventHandler(this.cboPreguntas_SelectedIndexChanged);
            // 
            // cboCodPreguntas
            // 
            this.cboCodPreguntas.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCodPreguntas.FormattingEnabled = true;
            this.cboCodPreguntas.Location = new System.Drawing.Point(612, 33);
            this.cboCodPreguntas.Name = "cboCodPreguntas";
            this.cboCodPreguntas.Size = new System.Drawing.Size(53, 26);
            this.cboCodPreguntas.TabIndex = 2;
            this.cboCodPreguntas.Visible = false;
            // 
            // txtRespuesta
            // 
            this.txtRespuesta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRespuesta.Location = new System.Drawing.Point(268, 91);
            this.txtRespuesta.Name = "txtRespuesta";
            this.txtRespuesta.Size = new System.Drawing.Size(338, 24);
            this.txtRespuesta.TabIndex = 0;
            this.txtRespuesta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRespuesta_KeyPress);
            // 
            // lblIngreseRespuesta
            // 
            this.lblIngreseRespuesta.AutoSize = true;
            this.lblIngreseRespuesta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lblIngreseRespuesta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngreseRespuesta.Location = new System.Drawing.Point(9, 97);
            this.lblIngreseRespuesta.Name = "lblIngreseRespuesta";
            this.lblIngreseRespuesta.Size = new System.Drawing.Size(198, 18);
            this.lblIngreseRespuesta.TabIndex = 4;
            this.lblIngreseRespuesta.Text = "Ingrese su nueva Respuesta:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(12, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(748, 300);
            this.panel1.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(159)))), ((int)(((byte)(81)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(727, -2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 33);
            this.label4.TabIndex = 20;
            this.label4.Text = " ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(159)))), ((int)(((byte)(81)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MintCream;
            this.label3.Location = new System.Drawing.Point(0, -1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 32);
            this.label3.TabIndex = 7;
            this.label3.Text = "MIT";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.Teal;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(744, 31);
            this.lblTitulo.TabIndex = 6;
            this.lblTitulo.Text = "Modificacion de Respuestas";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btoAceptar);
            this.panel3.Controls.Add(this.btoCancelar);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Location = new System.Drawing.Point(21, 44);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(703, 225);
            this.panel3.TabIndex = 24;
            // 
            // btoAceptar
            // 
            this.btoAceptar.BackColor = System.Drawing.Color.Teal;
            this.btoAceptar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.btoAceptar.ForeColor = System.Drawing.SystemColors.Control;
            this.btoAceptar.Location = new System.Drawing.Point(172, 177);
            this.btoAceptar.Name = "btoAceptar";
            this.btoAceptar.Size = new System.Drawing.Size(99, 30);
            this.btoAceptar.TabIndex = 22;
            this.btoAceptar.Text = "Aceptar";
            this.btoAceptar.UseVisualStyleBackColor = false;
            this.btoAceptar.Click += new System.EventHandler(this.btoAceptar_Click);
            // 
            // btoCancelar
            // 
            this.btoCancelar.BackColor = System.Drawing.Color.Teal;
            this.btoCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btoCancelar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.btoCancelar.ForeColor = System.Drawing.SystemColors.Control;
            this.btoCancelar.Location = new System.Drawing.Point(365, 177);
            this.btoCancelar.Name = "btoCancelar";
            this.btoCancelar.Size = new System.Drawing.Size(99, 30);
            this.btoCancelar.TabIndex = 23;
            this.btoCancelar.Text = "Cancelar";
            this.btoCancelar.UseVisualStyleBackColor = false;
            this.btoCancelar.Click += new System.EventHandler(this.btoCancelar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.cboCodPreguntas);
            this.panel2.Controls.Add(this.lblIngreseRespuesta);
            this.panel2.Controls.Add(this.cboPreguntas);
            this.panel2.Controls.Add(this.btoGurdar);
            this.panel2.Controls.Add(this.lblSeleccionePregunta);
            this.panel2.Controls.Add(this.txtRespuesta);
            this.panel2.Location = new System.Drawing.Point(18, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(672, 146);
            this.panel2.TabIndex = 21;
            // 
            // btoGurdar
            // 
            this.btoGurdar.AutoSize = true;
            this.btoGurdar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btoGurdar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btoGurdar.BackgroundImage")));
            this.btoGurdar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btoGurdar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.btoGurdar.ForeColor = System.Drawing.SystemColors.Control;
            this.btoGurdar.Location = new System.Drawing.Point(612, 84);
            this.btoGurdar.Name = "btoGurdar";
            this.btoGurdar.Size = new System.Drawing.Size(43, 35);
            this.btoGurdar.TabIndex = 24;
            this.btoGurdar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btoGurdar.UseVisualStyleBackColor = false;
            this.btoGurdar.Click += new System.EventHandler(this.btoGurdar_Click);
            // 
            // frmCambiarRespuestas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btoCancelar;
            this.ClientSize = new System.Drawing.Size(787, 363);
            this.Controls.Add(this.panel1);
            this.Name = "frmCambiarRespuestas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmCambiarRespuestas_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSeleccionePregunta;
        private System.Windows.Forms.ComboBox cboPreguntas;
        private System.Windows.Forms.ComboBox cboCodPreguntas;
        private System.Windows.Forms.TextBox txtRespuesta;
        private System.Windows.Forms.Label lblIngreseRespuesta;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btoAceptar;
        private System.Windows.Forms.Button btoCancelar;
        private System.Windows.Forms.Button btoGurdar;
        private System.Windows.Forms.Panel panel3;
    }
}