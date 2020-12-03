namespace CapaPresentacion
{
    partial class frmTbUsuarioPersonalizada
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "",
            ""}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTbUsuarioPersonalizada));
            this.listViewUsurios = new System.Windows.Forms.ListView();
            this.Usuario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Estatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Descripcion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.btoSalir = new System.Windows.Forms.Button();
            this.btoAceptar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btoBuscar = new System.Windows.Forms.Button();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.Código = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewUsurios
            // 
            this.listViewUsurios.AllowDrop = true;
            this.listViewUsurios.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.listViewUsurios.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Usuario,
            this.Nombre,
            this.Estatus,
            this.Descripcion});
            this.listViewUsurios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewUsurios.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewUsurios.ForeColor = System.Drawing.SystemColors.MenuText;
            this.listViewUsurios.FullRowSelect = true;
            this.listViewUsurios.GridLines = true;
            this.listViewUsurios.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            listViewItem1.StateImageIndex = 0;
            this.listViewUsurios.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listViewUsurios.Location = new System.Drawing.Point(0, 0);
            this.listViewUsurios.MultiSelect = false;
            this.listViewUsurios.Name = "listViewUsurios";
            this.listViewUsurios.Size = new System.Drawing.Size(663, 385);
            this.listViewUsurios.TabIndex = 9;
            this.listViewUsurios.UseCompatibleStateImageBehavior = false;
            this.listViewUsurios.View = System.Windows.Forms.View.Details;
            this.listViewUsurios.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewUsurios_ColumnClick);
            this.listViewUsurios.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listViewUsurios_ColumnWidthChanging);
            this.listViewUsurios.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listViewUsurios_DrawColumnHeader_1);
            this.listViewUsurios.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listViewUsurios_DrawItem_1);
            this.listViewUsurios.SelectedIndexChanged += new System.EventHandler(this.listViewUsurios_SelectedIndexChanged);
            this.listViewUsurios.DoubleClick += new System.EventHandler(this.listViewUsurios_DoubleClick);
            // 
            // Usuario
            // 
            this.Usuario.Text = "Usuario";
            this.Usuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Usuario.Width = 118;
            // 
            // Nombre
            // 
            this.Nombre.Text = "Nombre";
            this.Nombre.Width = 278;
            // 
            // Estatus
            // 
            this.Estatus.Text = "";
            this.Estatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Estatus.Width = 0;
            // 
            // Descripcion
            // 
            this.Descripcion.Text = "Descripcion";
            this.Descripcion.Width = 450;
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
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(717, 605);
            this.panel1.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(-5, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(733, 2);
            this.label9.TabIndex = 26;
            this.label9.Text = " ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btoSalir
            // 
            this.btoSalir.BackColor = System.Drawing.Color.Teal;
            this.btoSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btoSalir.ForeColor = System.Drawing.SystemColors.Control;
            this.btoSalir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btoSalir.Location = new System.Drawing.Point(461, 551);
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
            this.btoAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btoAceptar.ForeColor = System.Drawing.SystemColors.Control;
            this.btoAceptar.Location = new System.Drawing.Point(122, 551);
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
            this.label3.Location = new System.Drawing.Point(691, -2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 33);
            this.label3.TabIndex = 18;
            this.label3.Text = " ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btoBuscar);
            this.panel3.Controls.Add(this.txtUsuario);
            this.panel3.Controls.Add(this.lblNombre);
            this.panel3.Controls.Add(this.txtNombre);
            this.panel3.Controls.Add(this.lblUsuario);
            this.panel3.ForeColor = System.Drawing.SystemColors.Control;
            this.panel3.Location = new System.Drawing.Point(22, 43);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(667, 74);
            this.panel3.TabIndex = 17;
            // 
            // btoBuscar
            // 
            this.btoBuscar.BackColor = System.Drawing.Color.Teal;
            this.btoBuscar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btoBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btoBuscar.ForeColor = System.Drawing.Color.White;
            this.btoBuscar.Location = new System.Drawing.Point(482, 26);
            this.btoBuscar.Name = "btoBuscar";
            this.btoBuscar.Size = new System.Drawing.Size(99, 28);
            this.btoBuscar.TabIndex = 24;
            this.btoBuscar.Text = "Buscar";
            this.btoBuscar.UseVisualStyleBackColor = false;
            this.btoBuscar.Click += new System.EventHandler(this.botBuscar_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtUsuario.Location = new System.Drawing.Point(21, 32);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(150, 22);
            this.txtUsuario.TabIndex = 11;
            this.txtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuario_KeyPress);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblNombre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNombre.Location = new System.Drawing.Point(192, 8);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(62, 18);
            this.lblNombre.TabIndex = 15;
            this.lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtNombre.Location = new System.Drawing.Point(195, 32);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(239, 22);
            this.txtNombre.TabIndex = 12;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblUsuario.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblUsuario.Location = new System.Drawing.Point(18, 8);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(60, 18);
            this.lblUsuario.TabIndex = 14;
            this.lblUsuario.Text = "Usuario";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.listViewUsurios);
            this.panel2.Location = new System.Drawing.Point(22, 156);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(667, 389);
            this.panel2.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(191)))), ((int)(((byte)(199)))));
            this.label5.Location = new System.Drawing.Point(951, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 31);
            this.label5.TabIndex = 5;
            this.label5.Text = " ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.label2.Text = " U";
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
            this.lblTitulo.Size = new System.Drawing.Size(713, 31);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Tabla Usuarios";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Código
            // 
            this.Código.Text = "Código";
            // 
            // frmTbUsuarioPersonalizada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(230)))), ((int)(((byte)(233)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(744, 638);
            this.Controls.Add(this.panel1);
            this.Name = "frmTbUsuarioPersonalizada";
            this.Text = "Tabla de usuarios";
            this.Load += new System.EventHandler(this.frmTbUsuarioPersonalizada_Load);
            this.DoubleClick += new System.EventHandler(this.listViewUsurios_DoubleClick);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewUsurios;
        private System.Windows.Forms.ColumnHeader Usuario;
        private System.Windows.Forms.ColumnHeader Nombre;
        private System.Windows.Forms.ColumnHeader Estatus;
        private System.Windows.Forms.ColumnHeader Descripcion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btoBuscar;
        private System.Windows.Forms.Button btoAceptar;
        private System.Windows.Forms.Button btoSalir;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ColumnHeader Código;
    }
}