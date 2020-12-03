namespace CapaPresentacion
{
    partial class frmTbProcedencia
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.btoSalir = new System.Windows.Forms.Button();
            this.btoAceptar = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lstvProcedencia = new System.Windows.Forms.ListView();
            this.lstvCodigo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstvDescripcion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btoBuscar = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblP = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.btoSalir);
            this.panel3.Controls.Add(this.btoAceptar);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.lblP);
            this.panel3.Controls.Add(this.lblTitulo);
            this.panel3.Location = new System.Drawing.Point(9, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(627, 500);
            this.panel3.TabIndex = 49;
            // 
            // btoSalir
            // 
            this.btoSalir.BackColor = System.Drawing.Color.Teal;
            this.btoSalir.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btoSalir.ForeColor = System.Drawing.SystemColors.Control;
            this.btoSalir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btoSalir.Location = new System.Drawing.Point(380, 461);
            this.btoSalir.Name = "btoSalir";
            this.btoSalir.Size = new System.Drawing.Size(99, 30);
            this.btoSalir.TabIndex = 41;
            this.btoSalir.Text = "Salir";
            this.btoSalir.UseVisualStyleBackColor = false;
            this.btoSalir.Click += new System.EventHandler(this.btoSalir_Click);
            // 
            // btoAceptar
            // 
            this.btoAceptar.BackColor = System.Drawing.Color.Teal;
            this.btoAceptar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btoAceptar.ForeColor = System.Drawing.SystemColors.Control;
            this.btoAceptar.Location = new System.Drawing.Point(131, 462);
            this.btoAceptar.Name = "btoAceptar";
            this.btoAceptar.Size = new System.Drawing.Size(99, 30);
            this.btoAceptar.TabIndex = 46;
            this.btoAceptar.Text = "Aceptar";
            this.btoAceptar.UseVisualStyleBackColor = false;
            this.btoAceptar.Click += new System.EventHandler(this.btoAceptar_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.lstvProcedencia);
            this.panel4.Location = new System.Drawing.Point(8, 130);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(606, 326);
            this.panel4.TabIndex = 45;
            // 
            // lstvProcedencia
            // 
            this.lstvProcedencia.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lstvCodigo,
            this.lstvDescripcion});
            this.lstvProcedencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstvProcedencia.FullRowSelect = true;
            this.lstvProcedencia.GridLines = true;
            this.lstvProcedencia.HideSelection = false;
            this.lstvProcedencia.Location = new System.Drawing.Point(21, 13);
            this.lstvProcedencia.MultiSelect = false;
            this.lstvProcedencia.Name = "lstvProcedencia";
            this.lstvProcedencia.Size = new System.Drawing.Size(562, 286);
            this.lstvProcedencia.TabIndex = 0;
            this.lstvProcedencia.UseCompatibleStateImageBehavior = false;
            this.lstvProcedencia.View = System.Windows.Forms.View.Details;
            this.lstvProcedencia.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstvProcedencia_ColumnClick);
            this.lstvProcedencia.DoubleClick += new System.EventHandler(this.lstvProcedencia_DoubleClick);
            // 
            // lstvCodigo
            // 
            this.lstvCodigo.Text = "Código";
            this.lstvCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lstvCodigo.Width = 212;
            // 
            // lstvDescripcion
            // 
            this.lstvDescripcion.Text = "Descripción";
            this.lstvDescripcion.Width = 547;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(5, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(733, 2);
            this.label3.TabIndex = 44;
            this.label3.Text = " ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.btoBuscar);
            this.panel5.Controls.Add(this.txtCodigo);
            this.panel5.Controls.Add(this.lblDescripcion);
            this.panel5.Controls.Add(this.txtDescripcion);
            this.panel5.Controls.Add(this.lblCodigo);
            this.panel5.ForeColor = System.Drawing.SystemColors.Control;
            this.panel5.Location = new System.Drawing.Point(29, 50);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(585, 54);
            this.panel5.TabIndex = 43;
            // 
            // btoBuscar
            // 
            this.btoBuscar.BackColor = System.Drawing.Color.Teal;
            this.btoBuscar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btoBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btoBuscar.ForeColor = System.Drawing.Color.White;
            this.btoBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btoBuscar.Location = new System.Drawing.Point(479, 13);
            this.btoBuscar.Name = "btoBuscar";
            this.btoBuscar.Size = new System.Drawing.Size(99, 28);
            this.btoBuscar.TabIndex = 24;
            this.btoBuscar.Text = "Buscar";
            this.btoBuscar.UseVisualStyleBackColor = false;
            this.btoBuscar.Click += new System.EventHandler(this.btoBuscar_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtCodigo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtCodigo.Location = new System.Drawing.Point(65, 13);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 24);
            this.txtCodigo.TabIndex = 11;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblDescripcion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDescripcion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDescripcion.Location = new System.Drawing.Point(171, 17);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(87, 18);
            this.lblDescripcion.TabIndex = 15;
            this.lblDescripcion.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtDescripcion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtDescripcion.Location = new System.Drawing.Point(274, 14);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(184, 24);
            this.txtDescripcion.TabIndex = 12;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblCodigo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCodigo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCodigo.Location = new System.Drawing.Point(3, 16);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(56, 18);
            this.lblCodigo.TabIndex = 14;
            this.lblCodigo.Text = "Código";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(159)))), ((int)(((byte)(81)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(608, -1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 32);
            this.label6.TabIndex = 41;
            this.label6.Text = " ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblP
            // 
            this.lblP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(159)))), ((int)(((byte)(81)))));
            this.lblP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP.ForeColor = System.Drawing.SystemColors.Control;
            this.lblP.Location = new System.Drawing.Point(-1, -1);
            this.lblP.Name = "lblP";
            this.lblP.Size = new System.Drawing.Size(34, 32);
            this.lblP.TabIndex = 2;
            this.lblP.Text = " P";
            this.lblP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.Teal;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(627, 31);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Tabla de Procedencia";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmTbProcedencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CapaPresentacion.Properties.Resources.images__6_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(648, 526);
            this.Controls.Add(this.panel3);
            this.KeyPreview = true;
            this.Name = "frmTbProcedencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tabla de Procedencia";
            this.Load += new System.EventHandler(this.frmTbProcedencia_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTbProcedencia_KeyDown);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btoSalir;
        private System.Windows.Forms.Button btoAceptar;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ListView lstvProcedencia;
        private System.Windows.Forms.ColumnHeader lstvCodigo;
        private System.Windows.Forms.ColumnHeader lstvDescripcion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btoBuscar;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblP;
        private System.Windows.Forms.Label lblTitulo;
    }
}