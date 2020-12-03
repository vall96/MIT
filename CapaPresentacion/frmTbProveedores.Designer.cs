namespace CapaPresentacion
{
    partial class frmTbProveedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTbProveedores));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.btoSalir = new System.Windows.Forms.Button();
            this.btoAceptar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.btoBuscar = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lsvProveedores = new System.Windows.Forms.ListView();
            this.ColCodigo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProveedor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDescripcion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDireccion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colContacto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTelf1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTelf2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.panel1.Size = new System.Drawing.Size(1177, 421);
            this.panel1.TabIndex = 14;
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
            this.btoSalir.Location = new System.Drawing.Point(703, 383);
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
            this.btoAceptar.Location = new System.Drawing.Point(371, 383);
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
            this.label3.Location = new System.Drawing.Point(1153, -2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 32);
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
            this.panel3.Controls.Add(this.txtProveedor);
            this.panel3.Controls.Add(this.lblProveedor);
            this.panel3.ForeColor = System.Drawing.SystemColors.Control;
            this.panel3.Location = new System.Drawing.Point(22, 51);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(727, 60);
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
            this.btoBuscar.Location = new System.Drawing.Point(591, 22);
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
            this.txtCodigo.Location = new System.Drawing.Point(53, 22);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(150, 22);
            this.txtCodigo.TabIndex = 11;
            // 
            // txtProveedor
            // 
            this.txtProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProveedor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtProveedor.Location = new System.Drawing.Point(291, 22);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(239, 22);
            this.txtProveedor.TabIndex = 12;
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblProveedor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblProveedor.Location = new System.Drawing.Point(288, 1);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(77, 18);
            this.lblProveedor.TabIndex = 14;
            this.lblProveedor.Text = "Proveedor";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lsvProveedores);
            this.panel2.Location = new System.Drawing.Point(22, 142);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1129, 235);
            this.panel2.TabIndex = 10;
            // 
            // lsvProveedores
            // 
            this.lsvProveedores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColCodigo,
            this.colProveedor,
            this.colDescripcion,
            this.colDireccion,
            this.colContacto,
            this.colTelf1,
            this.colTelf2,
            this.colEmail,
            this.colFecha});
            this.lsvProveedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvProveedores.FullRowSelect = true;
            this.lsvProveedores.GridLines = true;
            this.lsvProveedores.HideSelection = false;
            this.lsvProveedores.Location = new System.Drawing.Point(19, 20);
            this.lsvProveedores.Name = "lsvProveedores";
            this.lsvProveedores.Size = new System.Drawing.Size(1080, 190);
            this.lsvProveedores.TabIndex = 0;
            this.lsvProveedores.UseCompatibleStateImageBehavior = false;
            this.lsvProveedores.View = System.Windows.Forms.View.Details;
            this.lsvProveedores.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lsvProveedores_ColumnClick);
            this.lsvProveedores.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lsvProveedores_DrawColumnHeader);
            this.lsvProveedores.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lsvProveedores_DrawItem);
            this.lsvProveedores.DoubleClick += new System.EventHandler(this.lsvProveedores_DoubleClick);
            // 
            // ColCodigo
            // 
            this.ColCodigo.Text = "Codigo";
            this.ColCodigo.Width = 100;
            // 
            // colProveedor
            // 
            this.colProveedor.Text = "Proveedor";
            this.colProveedor.Width = 99;
            // 
            // colDescripcion
            // 
            this.colDescripcion.Text = "Descripcion";
            this.colDescripcion.Width = 187;
            // 
            // colDireccion
            // 
            this.colDireccion.Text = "Dirección";
            this.colDireccion.Width = 165;
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
            // colEmail
            // 
            this.colEmail.Text = "Email";
            this.colEmail.Width = 142;
            // 
            // colFecha
            // 
            this.colFecha.Text = "Fecha";
            this.colFecha.Width = 202;
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
            this.label2.Text = "P";
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
            this.lblTitulo.Size = new System.Drawing.Size(1173, 31);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Proveedores";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmTbProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1201, 452);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "frmTbProveedores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proveedores";
            this.Load += new System.EventHandler(this.fmrTbProveedores_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTbProveedores_KeyDown);
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
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lsvProveedores;
        private System.Windows.Forms.ColumnHeader ColCodigo;
        private System.Windows.Forms.ColumnHeader colProveedor;
        private System.Windows.Forms.ColumnHeader colDescripcion;
        private System.Windows.Forms.ColumnHeader colDireccion;
        private System.Windows.Forms.ColumnHeader colContacto;
        private System.Windows.Forms.ColumnHeader colTelf1;
        private System.Windows.Forms.ColumnHeader colTelf2;
        private System.Windows.Forms.ColumnHeader colEmail;
        private System.Windows.Forms.ColumnHeader colFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitulo;
    }
}
