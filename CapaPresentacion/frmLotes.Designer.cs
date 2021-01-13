namespace CapaPresentacion
{
    partial class frmLotes
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btoSalir = new System.Windows.Forms.Button();
            this.btoAceptar = new System.Windows.Forms.Button();
            this.dtpFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.lblFechaVencimiento = new System.Windows.Forms.Label();
            this.lblNroLote = new System.Windows.Forms.Label();
            this.txtNroLote = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btoSalir);
            this.panel1.Controls.Add(this.btoAceptar);
            this.panel1.Controls.Add(this.dtpFechaVencimiento);
            this.panel1.Controls.Add(this.lblFechaVencimiento);
            this.panel1.Controls.Add(this.lblNroLote);
            this.panel1.Controls.Add(this.txtNroLote);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(304, 140);
            this.panel1.TabIndex = 2;
            // 
            // btoSalir
            // 
            this.btoSalir.BackColor = System.Drawing.Color.Teal;
            this.btoSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btoSalir.ForeColor = System.Drawing.SystemColors.Control;
            this.btoSalir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btoSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btoSalir.Location = new System.Drawing.Point(193, 101);
            this.btoSalir.Name = "btoSalir";
            this.btoSalir.Size = new System.Drawing.Size(93, 27);
            this.btoSalir.TabIndex = 36;
            this.btoSalir.Text = "Salir";
            this.btoSalir.UseVisualStyleBackColor = false;
            this.btoSalir.Click += new System.EventHandler(this.btoSalir_Click);
            // 
            // btoAceptar
            // 
            this.btoAceptar.BackColor = System.Drawing.Color.Teal;
            this.btoAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.btoAceptar.ForeColor = System.Drawing.SystemColors.Control;
            this.btoAceptar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btoAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btoAceptar.Location = new System.Drawing.Point(31, 101);
            this.btoAceptar.Name = "btoAceptar";
            this.btoAceptar.Size = new System.Drawing.Size(86, 27);
            this.btoAceptar.TabIndex = 35;
            this.btoAceptar.Text = "Aceptar";
            this.btoAceptar.UseVisualStyleBackColor = false;
            this.btoAceptar.Click += new System.EventHandler(this.btoAceptar_Click);
            // 
            // dtpFechaVencimiento
            // 
            this.dtpFechaVencimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.dtpFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaVencimiento.Location = new System.Drawing.Point(193, 57);
            this.dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            this.dtpFechaVencimiento.Size = new System.Drawing.Size(93, 24);
            this.dtpFechaVencimiento.TabIndex = 9;
            this.dtpFechaVencimiento.ValueChanged += new System.EventHandler(this.dtpFechaVencimiento_ValueChanged);
            // 
            // lblFechaVencimiento
            // 
            this.lblFechaVencimiento.AutoSize = true;
            this.lblFechaVencimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblFechaVencimiento.Location = new System.Drawing.Point(28, 62);
            this.lblFechaVencimiento.Name = "lblFechaVencimiento";
            this.lblFechaVencimiento.Size = new System.Drawing.Size(154, 18);
            this.lblFechaVencimiento.TabIndex = 8;
            this.lblFechaVencimiento.Text = "Fecha de Vencimiento";
            // 
            // lblNroLote
            // 
            this.lblNroLote.AutoSize = true;
            this.lblNroLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblNroLote.Location = new System.Drawing.Point(28, 27);
            this.lblNroLote.Name = "lblNroLote";
            this.lblNroLote.Size = new System.Drawing.Size(86, 18);
            this.lblNroLote.TabIndex = 7;
            this.lblNroLote.Text = "Nro de Lote";
            // 
            // txtNroLote
            // 
            this.txtNroLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtNroLote.Location = new System.Drawing.Point(143, 24);
            this.txtNroLote.Name = "txtNroLote";
            this.txtNroLote.Size = new System.Drawing.Size(143, 24);
            this.txtNroLote.TabIndex = 6;
            // 
            // frmLotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CapaPresentacion.Properties.Resources.images__6_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(324, 168);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "frmLotes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lotes de entrada";
            this.Load += new System.EventHandler(this.frmLotes_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpFechaVencimiento;
        private System.Windows.Forms.Label lblFechaVencimiento;
        private System.Windows.Forms.Label lblNroLote;
        private System.Windows.Forms.TextBox txtNroLote;
        private System.Windows.Forms.Button btoAceptar;
        private System.Windows.Forms.Button btoSalir;
    }
}