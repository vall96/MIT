namespace CapaPresentacion
{
    partial class frmTbAlmacenes
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
            this.txtAlmacen = new System.Windows.Forms.TextBox();
            this.lblAlmacen = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.lstvAlmacenes = new System.Windows.Forms.ListView();
            this.ColCodigo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNomAlmacen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDescripcion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDireccion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colContacto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTelf1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTelf2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFecha = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
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
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1134, 453);
            this.panel1.TabIndex = 12;
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
            this.btoSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btoSalir.ForeColor = System.Drawing.SystemColors.Control;
            this.btoSalir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btoSalir.Location = new System.Drawing.Point(610, 416);
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
            this.btoAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btoAceptar.ForeColor = System.Drawing.SystemColors.Control;
            this.btoAceptar.Location = new System.Drawing.Point(380, 416);
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
            this.label3.Location = new System.Drawing.Point(1108, 0);
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
            this.panel3.Controls.Add(this.txtAlmacen);
            this.panel3.Controls.Add(this.lblAlmacen);
            this.panel3.ForeColor = System.Drawing.SystemColors.Control;
            this.panel3.Location = new System.Drawing.Point(146, 45);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(748, 62);
            this.panel3.TabIndex = 17;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblCodigo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCodigo.Location = new System.Drawing.Point(50, 1);
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
            this.btoBuscar.Location = new System.Drawing.Point(604, 19);
            this.btoBuscar.Name = "btoBuscar";
            this.btoBuscar.Size = new System.Drawing.Size(99, 28);
            this.btoBuscar.TabIndex = 24;
            this.btoBuscar.Text = "Buscar";
            this.btoBuscar.UseVisualStyleBackColor = false;
            this.btoBuscar.Click += new System.EventHandler(this.btoBuscar_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtCodigo.Location = new System.Drawing.Point(39, 25);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(150, 22);
            this.txtCodigo.TabIndex = 11;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // txtAlmacen
            // 
            this.txtAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlmacen.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtAlmacen.Location = new System.Drawing.Point(291, 22);
            this.txtAlmacen.Name = "txtAlmacen";
            this.txtAlmacen.Size = new System.Drawing.Size(239, 22);
            this.txtAlmacen.TabIndex = 12;
            this.txtAlmacen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAlmacen_KeyPress);
            // 
            // lblAlmacen
            // 
            this.lblAlmacen.AutoSize = true;
            this.lblAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblAlmacen.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblAlmacen.Location = new System.Drawing.Point(288, 1);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Size = new System.Drawing.Size(65, 18);
            this.lblAlmacen.TabIndex = 14;
            this.lblAlmacen.Text = "Almacen";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lblEmpresa);
            this.panel2.Controls.Add(this.txtEmpresa);
            this.panel2.Controls.Add(this.lstvAlmacenes);
            this.panel2.Location = new System.Drawing.Point(33, 146);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1083, 264);
            this.panel2.TabIndex = 10;
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblEmpresa.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEmpresa.Location = new System.Drawing.Point(12, 17);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(72, 18);
            this.lblEmpresa.TabIndex = 30;
            this.lblEmpresa.Text = "Empresa:";
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.Enabled = false;
            this.txtEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpresa.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtEmpresa.Location = new System.Drawing.Point(90, 17);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Size = new System.Drawing.Size(133, 22);
            this.txtEmpresa.TabIndex = 30;
            // 
            // lstvAlmacenes
            // 
            this.lstvAlmacenes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColCodigo,
            this.colNomAlmacen,
            this.colDescripcion,
            this.colDireccion,
            this.colContacto,
            this.colTelf1,
            this.colTelf2,
            this.colFecha});
            this.lstvAlmacenes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstvAlmacenes.FullRowSelect = true;
            this.lstvAlmacenes.GridLines = true;
            this.lstvAlmacenes.HideSelection = false;
            this.lstvAlmacenes.Location = new System.Drawing.Point(15, 61);
            this.lstvAlmacenes.Name = "lstvAlmacenes";
            this.lstvAlmacenes.Size = new System.Drawing.Size(1051, 180);
            this.lstvAlmacenes.TabIndex = 0;
            this.lstvAlmacenes.UseCompatibleStateImageBehavior = false;
            this.lstvAlmacenes.View = System.Windows.Forms.View.Details;
            this.lstvAlmacenes.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstvAlmacenes_ColumnClick);
            this.lstvAlmacenes.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lstvAlmacenes_DrawColumnHeader);
            this.lstvAlmacenes.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lstvAlmacenes_DrawItem);
            this.lstvAlmacenes.DoubleClick += new System.EventHandler(this.lstvAlmacenes_DoubleClick);
            // 
            // ColCodigo
            // 
            this.ColCodigo.Text = "Codigo";
            this.ColCodigo.Width = 78;
            // 
            // colNomAlmacen
            // 
            this.colNomAlmacen.Text = "Almacen";
            this.colNomAlmacen.Width = 183;
            // 
            // colDescripcion
            // 
            this.colDescripcion.Text = "Descripcion";
            this.colDescripcion.Width = 200;
            // 
            // colDireccion
            // 
            this.colDireccion.Text = "Dirección";
            this.colDireccion.Width = 200;
            // 
            // colContacto
            // 
            this.colContacto.Text = "Contacto";
            this.colContacto.Width = 104;
            // 
            // colTelf1
            // 
            this.colTelf1.Text = "Telf";
            this.colTelf1.Width = 100;
            // 
            // colTelf2
            // 
            this.colTelf2.Text = "Telf";
            this.colTelf2.Width = 100;
            // 
            // colFecha
            // 
            this.colFecha.Text = "Fecha";
            this.colFecha.Width = 100;
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
            this.label2.Text = " A";
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
            this.lblTitulo.Size = new System.Drawing.Size(1130, 31);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Tabla de DtAlmacenes";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmTbAlmacenes
            // 
            this.AcceptButton = this.btoBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CapaPresentacion.Properties.Resources.images__6_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1163, 477);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Name = "frmTbAlmacenes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTbAlmacenes";
            this.Load += new System.EventHandler(this.frmTbAlmacenes_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.TextBox txtAlmacen;
        private System.Windows.Forms.Label lblAlmacen;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lstvAlmacenes;
        private System.Windows.Forms.ColumnHeader ColCodigo;
        private System.Windows.Forms.ColumnHeader colNomAlmacen;
        private System.Windows.Forms.ColumnHeader colDescripcion;
        private System.Windows.Forms.ColumnHeader colDireccion;
        private System.Windows.Forms.ColumnHeader colContacto;
        private System.Windows.Forms.ColumnHeader colTelf1;
        private System.Windows.Forms.ColumnHeader colTelf2;
        private System.Windows.Forms.ColumnHeader colFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.TextBox txtEmpresa;
    }
}
