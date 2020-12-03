namespace CapaPresentacion
{
    partial class frmConfigurarDecimal
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
            this.btoGuardar = new System.Windows.Forms.Button();
            this.rbtnComa = new System.Windows.Forms.RadioButton();
            this.rbtnPunto = new System.Windows.Forms.RadioButton();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btoGuardar);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(14, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(319, 183);
            this.panel1.TabIndex = 0;
            // 
            // btoGuardar
            // 
            this.btoGuardar.BackColor = System.Drawing.Color.Teal;
            this.btoGuardar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btoGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btoGuardar.ForeColor = System.Drawing.Color.White;
            this.btoGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btoGuardar.Location = new System.Drawing.Point(212, 142);
            this.btoGuardar.Name = "btoGuardar";
            this.btoGuardar.Size = new System.Drawing.Size(95, 27);
            this.btoGuardar.TabIndex = 26;
            this.btoGuardar.Text = "Guardar";
            this.btoGuardar.UseVisualStyleBackColor = false;
            this.btoGuardar.Click += new System.EventHandler(this.btoGuardar_Click);
            // 
            // rbtnComa
            // 
            this.rbtnComa.AutoSize = true;
            this.rbtnComa.BackColor = System.Drawing.Color.White;
            this.rbtnComa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnComa.Location = new System.Drawing.Point(22, 42);
            this.rbtnComa.Name = "rbtnComa";
            this.rbtnComa.Size = new System.Drawing.Size(87, 24);
            this.rbtnComa.TabIndex = 4;
            this.rbtnComa.Text = "Coma (,)";
            this.rbtnComa.UseVisualStyleBackColor = false;
            // 
            // rbtnPunto
            // 
            this.rbtnPunto.AutoSize = true;
            this.rbtnPunto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPunto.Location = new System.Drawing.Point(22, 12);
            this.rbtnPunto.Name = "rbtnPunto";
            this.rbtnPunto.Size = new System.Drawing.Size(87, 24);
            this.rbtnPunto.TabIndex = 3;
            this.rbtnPunto.Text = "Punto (.)";
            this.rbtnPunto.UseVisualStyleBackColor = true;
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.Teal;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(319, 31);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Configuracion de Decimal";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.rbtnPunto);
            this.panel2.Controls.Add(this.rbtnComa);
            this.panel2.Location = new System.Drawing.Point(19, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(288, 83);
            this.panel2.TabIndex = 27;
            // 
            // frmConfigurarDecimal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CapaPresentacion.Properties.Resources.images__6_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(345, 206);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfigurarDecimal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuracion de Decimal";
            this.Load += new System.EventHandler(this.frmConfigurarDecimal_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbtnComa;
        private System.Windows.Forms.RadioButton rbtnPunto;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btoGuardar;
        private System.Windows.Forms.Panel panel2;
    }
}