namespace CapaPresentacion
{
    partial class frmIngreseNombreUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIngreseNombreUsuario));
            this.lblIngreseNombre = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btoCancelar = new System.Windows.Forms.Button();
            this.btoAceptar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblIngreseNombre
            // 
            this.lblIngreseNombre.AutoSize = true;
            this.lblIngreseNombre.BackColor = System.Drawing.Color.White;
            this.lblIngreseNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIngreseNombre.Location = new System.Drawing.Point(20, 63);
            this.lblIngreseNombre.Name = "lblIngreseNombre";
            this.lblIngreseNombre.Size = new System.Drawing.Size(190, 18);
            this.lblIngreseNombre.TabIndex = 0;
            this.lblIngreseNombre.Text = "Ingrese Nombre de Usuario";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Controls.Add(this.btoCancelar);
            this.panel1.Controls.Add(this.btoAceptar);
            this.panel1.Controls.Add(this.lblIngreseNombre);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(424, 288);
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(159)))), ((int)(((byte)(81)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(400, -2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 33);
            this.label3.TabIndex = 19;
            this.label3.Text = " ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(159)))), ((int)(((byte)(81)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(-1, -1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "N";
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
            this.lblTitulo.Size = new System.Drawing.Size(420, 31);
            this.lblTitulo.TabIndex = 5;
            this.lblTitulo.Text = "Nombre de Usuario";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btoCancelar
            // 
            this.btoCancelar.AutoSize = true;
            this.btoCancelar.BackColor = System.Drawing.Color.Teal;
            this.btoCancelar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.btoCancelar.ForeColor = System.Drawing.SystemColors.Control;
            this.btoCancelar.Location = new System.Drawing.Point(213, 242);
            this.btoCancelar.Name = "btoCancelar";
            this.btoCancelar.Size = new System.Drawing.Size(99, 30);
            this.btoCancelar.TabIndex = 3;
            this.btoCancelar.Text = "Cancelar";
            this.btoCancelar.UseVisualStyleBackColor = false;
            this.btoCancelar.Click += new System.EventHandler(this.btoCancelar_Click);
            // 
            // btoAceptar
            // 
            this.btoAceptar.AutoSize = true;
            this.btoAceptar.BackColor = System.Drawing.Color.Teal;
            this.btoAceptar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.btoAceptar.ForeColor = System.Drawing.SystemColors.Control;
            this.btoAceptar.Location = new System.Drawing.Point(74, 242);
            this.btoAceptar.Name = "btoAceptar";
            this.btoAceptar.Size = new System.Drawing.Size(99, 30);
            this.btoAceptar.TabIndex = 2;
            this.btoAceptar.Text = "Aceptar";
            this.btoAceptar.UseVisualStyleBackColor = false;
            this.btoAceptar.Click += new System.EventHandler(this.btoAceptar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lblUsuario);
            this.panel2.Controls.Add(this.txtNombreUsuario);
            this.panel2.Location = new System.Drawing.Point(24, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(365, 83);
            this.panel2.TabIndex = 4;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(3, 10);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(64, 18);
            this.lblUsuario.TabIndex = 20;
            this.lblUsuario.Text = "Usuario:";
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreUsuario.Location = new System.Drawing.Point(7, 33);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(347, 24);
            this.txtNombreUsuario.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Location = new System.Drawing.Point(16, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(388, 152);
            this.panel3.TabIndex = 20;
            // 
            // frmIngreseNombreUsuario
            // 
            this.AcceptButton = this.btoAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(466, 329);
            this.Controls.Add(this.panel1);
            this.Name = "frmIngreseNombreUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingrese Nombre Usuario";
            this.Load += new System.EventHandler(this.frmIngreseNombreUsuario_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblIngreseNombre;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.Button btoCancelar;
        private System.Windows.Forms.Button btoAceptar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblTitulo;
    }
}