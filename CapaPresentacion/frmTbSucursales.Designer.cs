namespace CapaPresentacion
{
    partial class frmTbSucursales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTbSucursales));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.btoSalir = new System.Windows.Forms.Button();
            this.btoAceptar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblContacto = new System.Windows.Forms.Label();
            this.txtContacto = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.btoBuscar = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtSucursal = new System.Windows.Forms.TextBox();
            this.lblSucursal = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.lsvSucursales = new System.Windows.Forms.ListView();
            this.ColCodigo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNomSucursal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.panel1.Location = new System.Drawing.Point(25, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 460);
            this.panel1.TabIndex = 13;
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
            this.btoSalir.Location = new System.Drawing.Point(703, 413);
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
            this.btoAceptar.Location = new System.Drawing.Point(374, 413);
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
            this.label3.Location = new System.Drawing.Point(1289, -10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 41);
            this.label3.TabIndex = 18;
            this.label3.Text = " ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.lblContacto);
            this.panel3.Controls.Add(this.txtContacto);
            this.panel3.Controls.Add(this.lblCodigo);
            this.panel3.Controls.Add(this.btoBuscar);
            this.panel3.Controls.Add(this.txtCodigo);
            this.panel3.Controls.Add(this.txtSucursal);
            this.panel3.Controls.Add(this.lblSucursal);
            this.panel3.ForeColor = System.Drawing.SystemColors.Control;
            this.panel3.Location = new System.Drawing.Point(22, 51);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1134, 60);
            this.panel3.TabIndex = 17;
            // 
            // lblContacto
            // 
            this.lblContacto.AutoSize = true;
            this.lblContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblContacto.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblContacto.Location = new System.Drawing.Point(625, 1);
            this.lblContacto.Name = "lblContacto";
            this.lblContacto.Size = new System.Drawing.Size(73, 18);
            this.lblContacto.TabIndex = 29;
            this.lblContacto.Text = "Contacto:";
            // 
            // txtContacto
            // 
            this.txtContacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContacto.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtContacto.Location = new System.Drawing.Point(628, 22);
            this.txtContacto.Name = "txtContacto";
            this.txtContacto.Size = new System.Drawing.Size(150, 22);
            this.txtContacto.TabIndex = 26;
            this.txtContacto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContacto_KeyPress);
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
            this.btoBuscar.Location = new System.Drawing.Point(848, 19);
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
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // txtSucursal
            // 
            this.txtSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSucursal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtSucursal.Location = new System.Drawing.Point(291, 22);
            this.txtSucursal.Name = "txtSucursal";
            this.txtSucursal.Size = new System.Drawing.Size(239, 22);
            this.txtSucursal.TabIndex = 12;
            this.txtSucursal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSucursal_KeyPress);
            // 
            // lblSucursal
            // 
            this.lblSucursal.AutoSize = true;
            this.lblSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblSucursal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSucursal.Location = new System.Drawing.Point(288, 1);
            this.lblSucursal.Name = "lblSucursal";
            this.lblSucursal.Size = new System.Drawing.Size(66, 18);
            this.lblSucursal.TabIndex = 14;
            this.lblSucursal.Text = "Sucursal";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lblEmpresa);
            this.panel2.Controls.Add(this.txtEmpresa);
            this.panel2.Controls.Add(this.lsvSucursales);
            this.panel2.Location = new System.Drawing.Point(22, 142);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1158, 265);
            this.panel2.TabIndex = 10;
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblEmpresa.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEmpresa.Location = new System.Drawing.Point(21, 18);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(72, 18);
            this.lblEmpresa.TabIndex = 31;
            this.lblEmpresa.Text = "Empresa:";
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.Enabled = false;
            this.txtEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpresa.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtEmpresa.Location = new System.Drawing.Point(99, 18);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Size = new System.Drawing.Size(104, 22);
            this.txtEmpresa.TabIndex = 32;
            // 
            // lsvSucursales
            // 
            this.lsvSucursales.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColCodigo,
            this.colNomSucursal,
            this.colDescripcion,
            this.colDireccion,
            this.colContacto,
            this.colTelf1,
            this.colTelf2,
            this.colEmail,
            this.colFecha});
            this.lsvSucursales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvSucursales.FullRowSelect = true;
            this.lsvSucursales.GridLines = true;
            this.lsvSucursales.Location = new System.Drawing.Point(14, 60);
            this.lsvSucursales.Name = "lsvSucursales";
            this.lsvSucursales.Size = new System.Drawing.Size(1118, 190);
            this.lsvSucursales.TabIndex = 0;
            this.lsvSucursales.UseCompatibleStateImageBehavior = false;
            this.lsvSucursales.View = System.Windows.Forms.View.Details;
            this.lsvSucursales.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lsvSucursales_ColumnClick);
            this.lsvSucursales.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lsvSucursales_DrawColumnHeader);
            this.lsvSucursales.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lsvSucursales_DrawItem);
            this.lsvSucursales.DoubleClick += new System.EventHandler(this.listviewSucursales_DoubleClick);
            // 
            // ColCodigo
            // 
            this.ColCodigo.Text = "Codigo";
            this.ColCodigo.Width = 105;
            // 
            // colNomSucursal
            // 
            this.colNomSucursal.Text = "Sucursal";
            this.colNomSucursal.Width = 99;
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
            this.colEmail.Width = 150;
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
            this.label2.Text = " S";
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
            this.lblTitulo.Size = new System.Drawing.Size(1196, 31);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Tabla de Sucursales";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmTbSucursales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1230, 496);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmTbSucursales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sucursales";
            this.Load += new System.EventHandler(this.frmTbSucursales_Load);
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
        private System.Windows.Forms.Label lblContacto;
        private System.Windows.Forms.TextBox txtContacto;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Button btoBuscar;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtSucursal;
        private System.Windows.Forms.Label lblSucursal;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lsvSucursales;
        private System.Windows.Forms.ColumnHeader ColCodigo;
        private System.Windows.Forms.ColumnHeader colNomSucursal;
        private System.Windows.Forms.ColumnHeader colDescripcion;
        private System.Windows.Forms.ColumnHeader colDireccion;
        private System.Windows.Forms.ColumnHeader colContacto;
        private System.Windows.Forms.ColumnHeader colTelf1;
        private System.Windows.Forms.ColumnHeader colTelf2;
        private System.Windows.Forms.ColumnHeader colEmail;
        private System.Windows.Forms.ColumnHeader colFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.TextBox txtEmpresa;
    }
}