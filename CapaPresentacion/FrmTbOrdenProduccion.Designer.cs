namespace CapaPresentacion
{
    partial class FrmTbOrdenProduccion
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
            this.label9 = new System.Windows.Forms.Label();
            this.btoSalir = new System.Windows.Forms.Button();
            this.btoAceptar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.btoBuscar = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtDescrip = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lstvOrdenProduccion = new System.Windows.Forms.ListView();
            this.colCodigoOrden = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColDescripcionOrden = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColStatusOrden = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColCodCedula = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.lblTituloPanel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.btoSalir);
            this.panel1.Controls.Add(this.btoAceptar);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblTituloPanel);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(824, 448);
            this.panel1.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(-1, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(1382, 2);
            this.label9.TabIndex = 26;
            this.label9.Text = " ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btoSalir
            // 
            this.btoSalir.BackColor = System.Drawing.Color.Teal;
            this.btoSalir.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btoSalir.ForeColor = System.Drawing.SystemColors.Control;
            this.btoSalir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btoSalir.Location = new System.Drawing.Point(666, 406);
            this.btoSalir.Name = "btoSalir";
            this.btoSalir.Size = new System.Drawing.Size(99, 30);
            this.btoSalir.TabIndex = 25;
            this.btoSalir.Text = "Salir";
            this.btoSalir.UseVisualStyleBackColor = false;
            this.btoSalir.Click += new System.EventHandler(this.btoSalir_Click);
            // 
            // btoAceptar
            // 
            this.btoAceptar.BackColor = System.Drawing.Color.Teal;
            this.btoAceptar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btoAceptar.ForeColor = System.Drawing.SystemColors.Control;
            this.btoAceptar.Location = new System.Drawing.Point(85, 406);
            this.btoAceptar.Name = "btoAceptar";
            this.btoAceptar.Size = new System.Drawing.Size(99, 30);
            this.btoAceptar.TabIndex = 24;
            this.btoAceptar.Text = "Aceptar";
            this.btoAceptar.UseVisualStyleBackColor = false;
            this.btoAceptar.Click += new System.EventHandler(this.btoAceptar_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(159)))), ((int)(((byte)(81)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(798, -1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 31);
            this.label3.TabIndex = 18;
            this.label3.Text = " ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.lblCodigo);
            this.panel3.Controls.Add(this.btoBuscar);
            this.panel3.Controls.Add(this.txtCodigo);
            this.panel3.Controls.Add(this.txtDescrip);
            this.panel3.Controls.Add(this.lblDescripcion);
            this.panel3.ForeColor = System.Drawing.SystemColors.Control;
            this.panel3.Location = new System.Drawing.Point(22, 51);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(782, 60);
            this.panel3.TabIndex = 17;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblCodigo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCodigo.Location = new System.Drawing.Point(47, 1);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(60, 18);
            this.lblCodigo.TabIndex = 25;
            this.lblCodigo.Text = "Codigo:";
            // 
            // btoBuscar
            // 
            this.btoBuscar.BackColor = System.Drawing.Color.Teal;
            this.btoBuscar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btoBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btoBuscar.ForeColor = System.Drawing.Color.White;
            this.btoBuscar.Location = new System.Drawing.Point(597, 16);
            this.btoBuscar.Name = "btoBuscar";
            this.btoBuscar.Size = new System.Drawing.Size(99, 28);
            this.btoBuscar.TabIndex = 24;
            this.btoBuscar.Text = "Buscar";
            this.btoBuscar.UseVisualStyleBackColor = false;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtCodigo.Location = new System.Drawing.Point(50, 22);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(150, 22);
            this.txtCodigo.TabIndex = 11;
            // 
            // txtDescrip
            // 
            this.txtDescrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescrip.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtDescrip.Location = new System.Drawing.Point(326, 22);
            this.txtDescrip.Name = "txtDescrip";
            this.txtDescrip.Size = new System.Drawing.Size(239, 22);
            this.txtDescrip.TabIndex = 12;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblDescripcion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDescripcion.Location = new System.Drawing.Point(323, 1);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(91, 18);
            this.lblDescripcion.TabIndex = 14;
            this.lblDescripcion.Text = "Descripcion:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lstvOrdenProduccion);
            this.panel2.Location = new System.Drawing.Point(22, 142);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(782, 251);
            this.panel2.TabIndex = 10;
            // 
            // lstvOrdenProduccion
            // 
            this.lstvOrdenProduccion.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCodigoOrden,
            this.ColDescripcionOrden,
            this.ColStatusOrden,
            this.ColCodCedula});
            this.lstvOrdenProduccion.FullRowSelect = true;
            this.lstvOrdenProduccion.GridLines = true;
            this.lstvOrdenProduccion.HideSelection = false;
            this.lstvOrdenProduccion.Location = new System.Drawing.Point(8, 6);
            this.lstvOrdenProduccion.Name = "lstvOrdenProduccion";
            this.lstvOrdenProduccion.Size = new System.Drawing.Size(761, 236);
            this.lstvOrdenProduccion.TabIndex = 0;
            this.lstvOrdenProduccion.UseCompatibleStateImageBehavior = false;
            this.lstvOrdenProduccion.View = System.Windows.Forms.View.Details;
            this.lstvOrdenProduccion.SelectedIndexChanged += new System.EventHandler(this.lstvOrdenProduccion_SelectedIndexChanged);
            this.lstvOrdenProduccion.DoubleClick += new System.EventHandler(this.lstvOrdenProduccion_DoubleClick);
            // 
            // colCodigoOrden
            // 
            this.colCodigoOrden.Text = "Codigo";
            this.colCodigoOrden.Width = 111;
            // 
            // ColDescripcionOrden
            // 
            this.ColDescripcionOrden.Text = "Descripcion";
            this.ColDescripcionOrden.Width = 318;
            // 
            // ColStatusOrden
            // 
            this.ColStatusOrden.Text = "Status";
            this.ColStatusOrden.Width = 163;
            // 
            // ColCodCedula
            // 
            this.ColCodCedula.Text = "Codigo Cedula";
            this.ColCodCedula.Width = 162;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(159)))), ((int)(((byte)(81)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(-1, -1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "OP";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTituloPanel
            // 
            this.lblTituloPanel.AutoEllipsis = true;
            this.lblTituloPanel.BackColor = System.Drawing.Color.Teal;
            this.lblTituloPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPanel.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTituloPanel.Location = new System.Drawing.Point(0, 0);
            this.lblTituloPanel.Name = "lblTituloPanel";
            this.lblTituloPanel.Size = new System.Drawing.Size(820, 31);
            this.lblTituloPanel.TabIndex = 0;
            this.lblTituloPanel.Text = "Orden de Producto";
            this.lblTituloPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTituloPanel.UseCompatibleTextRendering = true;
            // 
            // FrmTbOrdenProduccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CapaPresentacion.Properties.Resources.images__6_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(850, 475);
            this.Controls.Add(this.panel1);
            this.Name = "FrmTbOrdenProduccion";
            this.Text = "Tabla de Orden de Produccion";
            this.Load += new System.EventHandler(this.FrmTbOrdenProduccion_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btoSalir;
        private System.Windows.Forms.Button btoAceptar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Button btoBuscar;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtDescrip;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTituloPanel;
        private System.Windows.Forms.ListView lstvOrdenProduccion;
        private System.Windows.Forms.ColumnHeader colCodigoOrden;
        private System.Windows.Forms.ColumnHeader ColDescripcionOrden;
        private System.Windows.Forms.ColumnHeader ColStatusOrden;
        private System.Windows.Forms.ColumnHeader ColCodCedula;
    }
}