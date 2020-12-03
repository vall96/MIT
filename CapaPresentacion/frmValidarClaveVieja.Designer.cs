namespace CapaPresentacion
{
    partial class frmValidarClaveVieja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmValidarClaveVieja));
            this.panelValidacion = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btoCancelar = new System.Windows.Forms.Button();
            this.btoValidar = new System.Windows.Forms.Button();
            this.lblValidaciondeClave = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtClaveVieja = new System.Windows.Forms.TextBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.lblSubTite = new System.Windows.Forms.Label();
            this.panelValidacion.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelValidacion
            // 
            this.panelValidacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelValidacion.Controls.Add(this.label3);
            this.panelValidacion.Controls.Add(this.label1);
            this.panelValidacion.Controls.Add(this.btoCancelar);
            this.panelValidacion.Controls.Add(this.btoValidar);
            this.panelValidacion.Controls.Add(this.lblValidaciondeClave);
            this.panelValidacion.Controls.Add(this.panel1);
            this.panelValidacion.Location = new System.Drawing.Point(13, 12);
            this.panelValidacion.Name = "panelValidacion";
            this.panelValidacion.Size = new System.Drawing.Size(402, 233);
            this.panelValidacion.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(159)))), ((int)(((byte)(81)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(383, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 31);
            this.label3.TabIndex = 26;
            this.label3.Text = " ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(159)))), ((int)(((byte)(81)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(-3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 31);
            this.label1.TabIndex = 20;
            this.label1.Text = "C";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btoCancelar
            // 
            this.btoCancelar.AutoSize = true;
            this.btoCancelar.BackColor = System.Drawing.Color.Teal;
            this.btoCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btoCancelar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.btoCancelar.ForeColor = System.Drawing.SystemColors.Control;
            this.btoCancelar.Location = new System.Drawing.Point(217, 182);
            this.btoCancelar.Name = "btoCancelar";
            this.btoCancelar.Size = new System.Drawing.Size(99, 30);
            this.btoCancelar.TabIndex = 25;
            this.btoCancelar.Text = "&Cancelar";
            this.btoCancelar.UseVisualStyleBackColor = false;
            this.btoCancelar.Click += new System.EventHandler(this.btoCancelar_Click);
            // 
            // btoValidar
            // 
            this.btoValidar.AutoSize = true;
            this.btoValidar.BackColor = System.Drawing.Color.Teal;
            this.btoValidar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.btoValidar.ForeColor = System.Drawing.SystemColors.Control;
            this.btoValidar.Location = new System.Drawing.Point(56, 182);
            this.btoValidar.Name = "btoValidar";
            this.btoValidar.Size = new System.Drawing.Size(99, 30);
            this.btoValidar.TabIndex = 24;
            this.btoValidar.Text = "&Validar";
            this.btoValidar.UseVisualStyleBackColor = false;
            this.btoValidar.Click += new System.EventHandler(this.btoValidar_Click);
            // 
            // lblValidaciondeClave
            // 
            this.lblValidaciondeClave.BackColor = System.Drawing.Color.Teal;
            this.lblValidaciondeClave.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblValidaciondeClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValidaciondeClave.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblValidaciondeClave.Location = new System.Drawing.Point(0, 0);
            this.lblValidaciondeClave.Name = "lblValidaciondeClave";
            this.lblValidaciondeClave.Size = new System.Drawing.Size(398, 31);
            this.lblValidaciondeClave.TabIndex = 20;
            this.lblValidaciondeClave.Text = "Validacion Clave Actual";
            this.lblValidaciondeClave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.txtClaveVieja);
            this.panel1.Controls.Add(this.lblClave);
            this.panel1.Controls.Add(this.lblSubTite);
            this.panel1.Location = new System.Drawing.Point(24, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(358, 99);
            this.panel1.TabIndex = 27;
            // 
            // txtClaveVieja
            // 
            this.txtClaveVieja.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtClaveVieja.Location = new System.Drawing.Point(105, 42);
            this.txtClaveVieja.Name = "txtClaveVieja";
            this.txtClaveVieja.PasswordChar = '*';
            this.txtClaveVieja.Size = new System.Drawing.Size(212, 24);
            this.txtClaveVieja.TabIndex = 0;
            this.txtClaveVieja.Tag = "";
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblClave.Location = new System.Drawing.Point(13, 45);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(53, 18);
            this.lblClave.TabIndex = 22;
            this.lblClave.Text = "Clave: ";
            // 
            // lblSubTite
            // 
            this.lblSubTite.AutoSize = true;
            this.lblSubTite.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblSubTite.Location = new System.Drawing.Point(13, 9);
            this.lblSubTite.Name = "lblSubTite";
            this.lblSubTite.Size = new System.Drawing.Size(277, 18);
            this.lblSubTite.TabIndex = 21;
            this.lblSubTite.Text = "Por su seguridad, Ingrese la clave Actual:";
            // 
            // frmValidarClaveVieja
            // 
            this.AcceptButton = this.btoValidar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(431, 268);
            this.Controls.Add(this.panelValidacion);
            this.Name = "frmValidarClaveVieja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Validar Clave Actual";
            this.Load += new System.EventHandler(this.frmValidarClaveVieja_Load);
            this.panelValidacion.ResumeLayout(false);
            this.panelValidacion.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelValidacion;
        private System.Windows.Forms.Button btoCancelar;
        private System.Windows.Forms.Button btoValidar;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.Label lblSubTite;
        private System.Windows.Forms.Label lblValidaciondeClave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtClaveVieja;
    }
}