namespace CapaPresentacion
{
    partial class frmCambiarClave
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCambiarClave));
            this.lblContraseña = new System.Windows.Forms.Label();
            this.lblConfirmarContraseña = new System.Windows.Forms.Label();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.txtConfirmarContraseña = new System.Windows.Forms.TextBox();
            this.btoAceptar = new System.Windows.Forms.Button();
            this.btoCancelar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContraseña.Location = new System.Drawing.Point(10, 11);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(89, 18);
            this.lblContraseña.TabIndex = 0;
            this.lblContraseña.Text = "Contraseña:";
            // 
            // lblConfirmarContraseña
            // 
            this.lblConfirmarContraseña.AutoSize = true;
            this.lblConfirmarContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmarContraseña.Location = new System.Drawing.Point(10, 74);
            this.lblConfirmarContraseña.Name = "lblConfirmarContraseña";
            this.lblConfirmarContraseña.Size = new System.Drawing.Size(159, 18);
            this.lblConfirmarContraseña.TabIndex = 1;
            this.lblConfirmarContraseña.Text = "Confirmar Contraseña:";
            // 
            // txtContraseña
            // 
            this.txtContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraseña.Location = new System.Drawing.Point(13, 32);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.PasswordChar = '*';
            this.txtContraseña.Size = new System.Drawing.Size(246, 24);
            this.txtContraseña.TabIndex = 2;
            // 
            // txtConfirmarContraseña
            // 
            this.txtConfirmarContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmarContraseña.Location = new System.Drawing.Point(13, 95);
            this.txtConfirmarContraseña.Name = "txtConfirmarContraseña";
            this.txtConfirmarContraseña.PasswordChar = '*';
            this.txtConfirmarContraseña.Size = new System.Drawing.Size(246, 24);
            this.txtConfirmarContraseña.TabIndex = 3;
            // 
            // btoAceptar
            // 
            this.btoAceptar.BackColor = System.Drawing.Color.Teal;
            this.btoAceptar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.btoAceptar.ForeColor = System.Drawing.SystemColors.Control;
            this.btoAceptar.Location = new System.Drawing.Point(32, 227);
            this.btoAceptar.Name = "btoAceptar";
            this.btoAceptar.Size = new System.Drawing.Size(99, 30);
            this.btoAceptar.TabIndex = 4;
            this.btoAceptar.Text = "&Aceptar";
            this.btoAceptar.UseVisualStyleBackColor = false;
            this.btoAceptar.Click += new System.EventHandler(this.btoAceptar_Click);
            // 
            // btoCancelar
            // 
            this.btoCancelar.BackColor = System.Drawing.Color.Teal;
            this.btoCancelar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.btoCancelar.ForeColor = System.Drawing.SystemColors.Control;
            this.btoCancelar.Location = new System.Drawing.Point(165, 227);
            this.btoCancelar.Name = "btoCancelar";
            this.btoCancelar.Size = new System.Drawing.Size(99, 30);
            this.btoCancelar.TabIndex = 5;
            this.btoCancelar.Text = "&Cancelar";
            this.btoCancelar.UseVisualStyleBackColor = false;
            this.btoCancelar.Click += new System.EventHandler(this.btoCancelar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Controls.Add(this.btoCancelar);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btoAceptar);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(315, 289);
            this.panel1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(159)))), ((int)(((byte)(81)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(298, -1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 31);
            this.label3.TabIndex = 19;
            this.label3.Text = " ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(159)))), ((int)(((byte)(81)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(-1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 31);
            this.label2.TabIndex = 7;
            this.label2.Text = "C";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.Teal;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(311, 31);
            this.lblTitulo.TabIndex = 6;
            this.lblTitulo.Text = "Cambio de clave";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lblContraseña);
            this.panel2.Controls.Add(this.txtContraseña);
            this.panel2.Controls.Add(this.txtConfirmarContraseña);
            this.panel2.Controls.Add(this.lblConfirmarContraseña);
            this.panel2.Location = new System.Drawing.Point(17, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(274, 133);
            this.panel2.TabIndex = 0;
            // 
            // frmCambiarClave
            // 
            this.AcceptButton = this.btoAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(341, 327);
            this.Controls.Add(this.panel1);
            this.Name = "frmCambiarClave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambiar Clave";
            this.Load += new System.EventHandler(this.frmCambiarClave_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.Label lblConfirmarContraseña;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.TextBox txtConfirmarContraseña;
        private System.Windows.Forms.Button btoAceptar;
        private System.Windows.Forms.Button btoCancelar;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}