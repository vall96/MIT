namespace CapaPresentacion
{
    partial class FrmNumeroDecimal
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dudNumeroDecimal = new System.Windows.Forms.DomainUpDown();
            this.lblConfigurarNumeros = new System.Windows.Forms.Label();
            this.btoGuardar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.lblConfigurarNumeros);
            this.panel1.Controls.Add(this.btoGuardar);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(373, 153);
            this.panel1.TabIndex = 1;
            // 
            // dudNumeroDecimal
            // 
            this.dudNumeroDecimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dudNumeroDecimal.Items.Add("1");
            this.dudNumeroDecimal.Items.Add("2");
            this.dudNumeroDecimal.Items.Add("3");
            this.dudNumeroDecimal.Items.Add("4");
            this.dudNumeroDecimal.Items.Add("5");
            this.dudNumeroDecimal.Items.Add("6");
            this.dudNumeroDecimal.Items.Add("7");
            this.dudNumeroDecimal.Items.Add("8");
            this.dudNumeroDecimal.Items.Add("9");
            this.dudNumeroDecimal.Items.Add("10");
            this.dudNumeroDecimal.Location = new System.Drawing.Point(288, 16);
            this.dudNumeroDecimal.Name = "dudNumeroDecimal";
            this.dudNumeroDecimal.ReadOnly = true;
            this.dudNumeroDecimal.Size = new System.Drawing.Size(52, 26);
            this.dudNumeroDecimal.TabIndex = 29;
            // 
            // lblConfigurarNumeros
            // 
            this.lblConfigurarNumeros.AutoSize = true;
            this.lblConfigurarNumeros.BackColor = System.Drawing.Color.White;
            this.lblConfigurarNumeros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfigurarNumeros.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblConfigurarNumeros.Location = new System.Drawing.Point(12, 54);
            this.lblConfigurarNumeros.Name = "lblConfigurarNumeros";
            this.lblConfigurarNumeros.Size = new System.Drawing.Size(260, 20);
            this.lblConfigurarNumeros.TabIndex = 28;
            this.lblConfigurarNumeros.Text = "Número de Decimales a Configurar:";
            // 
            // btoGuardar
            // 
            this.btoGuardar.BackColor = System.Drawing.Color.Teal;
            this.btoGuardar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btoGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btoGuardar.ForeColor = System.Drawing.Color.White;
            this.btoGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btoGuardar.Location = new System.Drawing.Point(269, 113);
            this.btoGuardar.Name = "btoGuardar";
            this.btoGuardar.Size = new System.Drawing.Size(95, 27);
            this.btoGuardar.TabIndex = 26;
            this.btoGuardar.Text = "Guardar";
            this.btoGuardar.UseVisualStyleBackColor = false;
            this.btoGuardar.Click += new System.EventHandler(this.btoGuardar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.Teal;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(373, 31);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Configuración de Número Decimal";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dudNumeroDecimal);
            this.panel2.Location = new System.Drawing.Point(6, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(358, 61);
            this.panel2.TabIndex = 30;
            // 
            // FrmNumeroDecimal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CapaPresentacion.Properties.Resources.images__6_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(397, 170);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Name = "FrmNumeroDecimal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmNumeroDecimal";
            this.Load += new System.EventHandler(this.FrmNumeroDecimal_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btoGuardar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DomainUpDown dudNumeroDecimal;
        private System.Windows.Forms.Label lblConfigurarNumeros;
        private System.Windows.Forms.Panel panel2;
    }
}
