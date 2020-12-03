namespace CapaPresentacion
{
    partial class frmTbEmpresas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTbEmpresas));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.btoSalir = new System.Windows.Forms.Button();
            this.btoAceptar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblRif = new System.Windows.Forms.Label();
            this.txtRif = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.btoBuscar = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboEmpSinBd = new System.Windows.Forms.ComboBox();
            this.listviewEmpresas = new System.Windows.Forms.ListView();
            this.ColCodigo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEmpresa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRIF = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDireccion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNIT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTelf1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colWeb = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFecha = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDescripcion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colContacto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNombCorto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.panel1.Size = new System.Drawing.Size(1384, 495);
            this.panel1.TabIndex = 11;
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
            this.btoSalir.Location = new System.Drawing.Point(701, 423);
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
            this.btoAceptar.Location = new System.Drawing.Point(465, 423);
            this.btoAceptar.Name = "btoAceptar";
            this.btoAceptar.Size = new System.Drawing.Size(99, 30);
            this.btoAceptar.TabIndex = 24;
            this.btoAceptar.Text = "Aceptar";
            this.btoAceptar.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(159)))), ((int)(((byte)(81)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(1359, 0);
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
            this.panel3.Controls.Add(this.lblRif);
            this.panel3.Controls.Add(this.txtRif);
            this.panel3.Controls.Add(this.txtDireccion);
            this.panel3.Controls.Add(this.lblDireccion);
            this.panel3.Controls.Add(this.lblCodigo);
            this.panel3.Controls.Add(this.btoBuscar);
            this.panel3.Controls.Add(this.txtCodigo);
            this.panel3.Controls.Add(this.txtEmpresa);
            this.panel3.Controls.Add(this.lblEmpresa);
            this.panel3.ForeColor = System.Drawing.SystemColors.Control;
            this.panel3.Location = new System.Drawing.Point(22, 45);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1210, 60);
            this.panel3.TabIndex = 17;
            // 
            // lblRif
            // 
            this.lblRif.AutoSize = true;
            this.lblRif.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblRif.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblRif.Location = new System.Drawing.Point(492, 0);
            this.lblRif.Name = "lblRif";
            this.lblRif.Size = new System.Drawing.Size(35, 18);
            this.lblRif.TabIndex = 29;
            this.lblRif.Text = "RIF:";
            // 
            // txtRif
            // 
            this.txtRif.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRif.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtRif.Location = new System.Drawing.Point(495, 21);
            this.txtRif.Name = "txtRif";
            this.txtRif.Size = new System.Drawing.Size(150, 22);
            this.txtRif.TabIndex = 26;
            this.txtRif.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRif_KeyPress);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtDireccion.Location = new System.Drawing.Point(706, 21);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(239, 22);
            this.txtDireccion.TabIndex = 27;
            this.txtDireccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDireccion_KeyPress);
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblDireccion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDireccion.Location = new System.Drawing.Point(703, 0);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(75, 18);
            this.lblDireccion.TabIndex = 28;
            this.lblDireccion.Text = "Direccion:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblCodigo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCodigo.Location = new System.Drawing.Point(11, 0);
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
            this.btoBuscar.Location = new System.Drawing.Point(980, 17);
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
            this.txtCodigo.Location = new System.Drawing.Point(14, 21);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(150, 22);
            this.txtCodigo.TabIndex = 11;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpresa.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtEmpresa.Location = new System.Drawing.Point(215, 21);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Size = new System.Drawing.Size(239, 22);
            this.txtEmpresa.TabIndex = 12;
            this.txtEmpresa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpresa_KeyPress);
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblEmpresa.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEmpresa.Location = new System.Drawing.Point(212, 0);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(72, 18);
            this.lblEmpresa.TabIndex = 14;
            this.lblEmpresa.Text = "Empresa:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.cboEmpSinBd);
            this.panel2.Controls.Add(this.listviewEmpresas);
            this.panel2.Location = new System.Drawing.Point(22, 143);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1341, 263);
            this.panel2.TabIndex = 10;
            // 
            // cboEmpSinBd
            // 
            this.cboEmpSinBd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpSinBd.FormattingEnabled = true;
            this.cboEmpSinBd.Location = new System.Drawing.Point(14, 232);
            this.cboEmpSinBd.Name = "cboEmpSinBd";
            this.cboEmpSinBd.Size = new System.Drawing.Size(57, 24);
            this.cboEmpSinBd.TabIndex = 1;
            this.cboEmpSinBd.Visible = false;
            // 
            // listviewEmpresas
            // 
            this.listviewEmpresas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColCodigo,
            this.colEmpresa,
            this.colRIF,
            this.colDireccion,
            this.colNIT,
            this.colTelf1,
            this.colEmail,
            this.colWeb,
            this.colFecha,
            this.colDescripcion,
            this.colContacto,
            this.colNombCorto});
            this.listviewEmpresas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listviewEmpresas.GridLines = true;
            this.listviewEmpresas.Location = new System.Drawing.Point(14, 22);
            this.listviewEmpresas.Name = "listviewEmpresas";
            this.listviewEmpresas.Size = new System.Drawing.Size(1309, 207);
            this.listviewEmpresas.TabIndex = 0;
            this.listviewEmpresas.UseCompatibleStateImageBehavior = false;
            this.listviewEmpresas.View = System.Windows.Forms.View.Details;
            this.listviewEmpresas.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listviewEmpresas_DrawColumnHeader);
            this.listviewEmpresas.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listviewEmpresas_DrawItem);
            this.listviewEmpresas.DoubleClick += new System.EventHandler(this.listviewEmpresas_DoubleClick);
            // 
            // ColCodigo
            // 
            this.ColCodigo.Text = "Codigo";
            this.ColCodigo.Width = 86;
            // 
            // colEmpresa
            // 
            this.colEmpresa.DisplayIndex = 2;
            this.colEmpresa.Text = "Empresa";
            this.colEmpresa.Width = 142;
            // 
            // colRIF
            // 
            this.colRIF.DisplayIndex = 3;
            this.colRIF.Text = "RIF";
            this.colRIF.Width = 88;
            // 
            // colDireccion
            // 
            this.colDireccion.DisplayIndex = 4;
            this.colDireccion.Text = "Dirección";
            this.colDireccion.Width = 159;
            // 
            // colNIT
            // 
            this.colNIT.DisplayIndex = 5;
            this.colNIT.Text = "NIT";
            this.colNIT.Width = 89;
            // 
            // colTelf1
            // 
            this.colTelf1.DisplayIndex = 6;
            this.colTelf1.Text = "Telf";
            this.colTelf1.Width = 100;
            // 
            // colEmail
            // 
            this.colEmail.DisplayIndex = 7;
            this.colEmail.Text = "Email";
            this.colEmail.Width = 123;
            // 
            // colWeb
            // 
            this.colWeb.DisplayIndex = 8;
            this.colWeb.Text = "Pag. Web";
            this.colWeb.Width = 120;
            // 
            // colFecha
            // 
            this.colFecha.DisplayIndex = 9;
            this.colFecha.Text = "Fecha";
            this.colFecha.Width = 96;
            // 
            // colDescripcion
            // 
            this.colDescripcion.DisplayIndex = 10;
            this.colDescripcion.Text = "Descripcion";
            this.colDescripcion.Width = 95;
            // 
            // colContacto
            // 
            this.colContacto.DisplayIndex = 11;
            this.colContacto.Text = "Contacto";
            this.colContacto.Width = 104;
            // 
            // colNombCorto
            // 
            this.colNombCorto.DisplayIndex = 1;
            this.colNombCorto.Text = "Nombre Corto";
            this.colNombCorto.Width = 99;
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
            this.label2.Text = " E";
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
            this.lblTitulo.Size = new System.Drawing.Size(1380, 31);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Tabla de Empresas";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmTbEmpresas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1422, 532);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTbEmpresas";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "tabla de Empresas";
            this.Load += new System.EventHandler(this.frmTbEmpresas_Load);
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
        private System.Windows.Forms.Label lblRif;
        private System.Windows.Forms.TextBox txtRif;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Button btoBuscar;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtEmpresa;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ListView listviewEmpresas;
        private System.Windows.Forms.ColumnHeader ColCodigo;
        private System.Windows.Forms.ColumnHeader colEmpresa;
        private System.Windows.Forms.ColumnHeader colRIF;
        private System.Windows.Forms.ColumnHeader colDireccion;
        private System.Windows.Forms.ColumnHeader colNIT;
        private System.Windows.Forms.ColumnHeader colTelf1;
        private System.Windows.Forms.ColumnHeader colEmail;
        private System.Windows.Forms.ColumnHeader colWeb;
        private System.Windows.Forms.ColumnHeader colFecha;
        private System.Windows.Forms.ColumnHeader colDescripcion;
        private System.Windows.Forms.ColumnHeader colContacto;
        private System.Windows.Forms.ColumnHeader colNombCorto;
        private System.Windows.Forms.ComboBox cboEmpSinBd;
    }
}