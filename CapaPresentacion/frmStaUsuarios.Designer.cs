namespace CapaPresentacion
{
    partial class frmStaUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStaUsuario));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripBtoAgregar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtoEditar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtoGuardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtoEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtoDescartar = new System.Windows.Forms.ToolStripButton();
            this.btoSalir = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.txtDescrip = new System.Windows.Forms.TextBox();
            this.lblDescripcion2 = new System.Windows.Forms.Label();
            this.lblCodigo2 = new System.Windows.Forms.Label();
            this.txtCod = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTituloPanel = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnPuntos = new System.Windows.Forms.Button();
            this.btoBuscar = new System.Windows.Forms.Button();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.btoSalir);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.tabControl);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblTituloPanel);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(644, 582);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.toolStrip1);
            this.panel4.Location = new System.Drawing.Point(14, 60);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(398, 46);
            this.panel4.TabIndex = 43;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(31, 21);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtoAgregar,
            this.toolStripSeparator1,
            this.toolStripBtoEditar,
            this.toolStripSeparator2,
            this.toolStripBtoGuardar,
            this.toolStripSeparator3,
            this.toolStripBtoEliminar,
            this.toolStripSeparator4,
            this.toolStripBtoDescartar});
            this.toolStrip1.Location = new System.Drawing.Point(2, 1);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(392, 41);
            this.toolStrip1.TabIndex = 21;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripBtoAgregar
            // 
            this.toolStripBtoAgregar.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.toolStripBtoAgregar.ForeColor = System.Drawing.Color.Teal;
            this.toolStripBtoAgregar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtoAgregar.Image")));
            this.toolStripBtoAgregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtoAgregar.Margin = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this.toolStripBtoAgregar.Name = "toolStripBtoAgregar";
            this.toolStripBtoAgregar.Size = new System.Drawing.Size(67, 38);
            this.toolStripBtoAgregar.Text = "F5 Agregar";
            this.toolStripBtoAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripBtoAgregar.ToolTipText = "F5 Agregar";
            this.toolStripBtoAgregar.Click += new System.EventHandler(this.toolStripBtoAgregar_Click_1);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.toolStripSeparator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 41);
            // 
            // toolStripBtoEditar
            // 
            this.toolStripBtoEditar.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.toolStripBtoEditar.ForeColor = System.Drawing.Color.Teal;
            this.toolStripBtoEditar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtoEditar.Image")));
            this.toolStripBtoEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtoEditar.Name = "toolStripBtoEditar";
            this.toolStripBtoEditar.Size = new System.Drawing.Size(56, 38);
            this.toolStripBtoEditar.Text = "F6 Editar";
            this.toolStripBtoEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripBtoEditar.ToolTipText = "F6 Editar";
            this.toolStripBtoEditar.Click += new System.EventHandler(this.toolStripBtoEditar_Click_1);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 41);
            // 
            // toolStripBtoGuardar
            // 
            this.toolStripBtoGuardar.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.toolStripBtoGuardar.ForeColor = System.Drawing.Color.Teal;
            this.toolStripBtoGuardar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtoGuardar.Image")));
            this.toolStripBtoGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtoGuardar.Name = "toolStripBtoGuardar";
            this.toolStripBtoGuardar.Size = new System.Drawing.Size(68, 38);
            this.toolStripBtoGuardar.Text = "F7 Guardar";
            this.toolStripBtoGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripBtoGuardar.ToolTipText = "F7 Guardar";
            this.toolStripBtoGuardar.Click += new System.EventHandler(this.toolStripBtoGuardar_Click_1);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 41);
            // 
            // toolStripBtoEliminar
            // 
            this.toolStripBtoEliminar.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.toolStripBtoEliminar.ForeColor = System.Drawing.Color.Teal;
            this.toolStripBtoEliminar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtoEliminar.Image")));
            this.toolStripBtoEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtoEliminar.Name = "toolStripBtoEliminar";
            this.toolStripBtoEliminar.Size = new System.Drawing.Size(67, 38);
            this.toolStripBtoEliminar.Text = "F8 Eliminar";
            this.toolStripBtoEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripBtoEliminar.ToolTipText = "F8 Eliminar";
            this.toolStripBtoEliminar.Click += new System.EventHandler(this.toolStripBtoEliminar_Click_1);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 41);
            // 
            // toolStripBtoDescartar
            // 
            this.toolStripBtoDescartar.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.toolStripBtoDescartar.ForeColor = System.Drawing.Color.Teal;
            this.toolStripBtoDescartar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtoDescartar.Image")));
            this.toolStripBtoDescartar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtoDescartar.Name = "toolStripBtoDescartar";
            this.toolStripBtoDescartar.Size = new System.Drawing.Size(74, 38);
            this.toolStripBtoDescartar.Text = "F9 Descartar";
            this.toolStripBtoDescartar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripBtoDescartar.ToolTipText = "F9 Descartar";
            this.toolStripBtoDescartar.Click += new System.EventHandler(this.toolStripBtoDescartar_Click_1);
            // 
            // btoSalir
            // 
            this.btoSalir.BackColor = System.Drawing.Color.Teal;
            this.btoSalir.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btoSalir.ForeColor = System.Drawing.SystemColors.Control;
            this.btoSalir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btoSalir.Location = new System.Drawing.Point(508, 545);
            this.btoSalir.Name = "btoSalir";
            this.btoSalir.Size = new System.Drawing.Size(99, 30);
            this.btoSalir.TabIndex = 5;
            this.btoSalir.Text = "Salir";
            this.btoSalir.UseVisualStyleBackColor = false;
            this.btoSalir.Click += new System.EventHandler(this.btoSalir_Click);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(-1, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(641, 2);
            this.label9.TabIndex = 41;
            this.label9.Text = " ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(39, 252);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(549, 245);
            this.tabControl.TabIndex = 40;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblMensaje);
            this.tabPage1.Controls.Add(this.txtDescrip);
            this.tabPage1.Controls.Add(this.lblDescripcion2);
            this.tabPage1.Controls.Add(this.lblCodigo2);
            this.tabPage1.Controls.Add(this.txtCod);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(541, 216);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Estados ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.Location = new System.Drawing.Point(319, 30);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(134, 26);
            this.lblMensaje.TabIndex = 34;
            this.lblMensaje.Text = "El código es autogenerado\r\n por el sistema.";
            this.lblMensaje.Visible = false;
            // 
            // txtDescrip
            // 
            this.txtDescrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescrip.Location = new System.Drawing.Point(160, 77);
            this.txtDescrip.Name = "txtDescrip";
            this.txtDescrip.Size = new System.Drawing.Size(340, 24);
            this.txtDescrip.TabIndex = 33;
            // 
            // lblDescripcion2
            // 
            this.lblDescripcion2.AutoSize = true;
            this.lblDescripcion2.BackColor = System.Drawing.Color.White;
            this.lblDescripcion2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion2.Location = new System.Drawing.Point(16, 77);
            this.lblDescripcion2.Name = "lblDescripcion2";
            this.lblDescripcion2.Size = new System.Drawing.Size(91, 18);
            this.lblDescripcion2.TabIndex = 32;
            this.lblDescripcion2.Text = "Descripción:";
            // 
            // lblCodigo2
            // 
            this.lblCodigo2.AutoSize = true;
            this.lblCodigo2.BackColor = System.Drawing.Color.White;
            this.lblCodigo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo2.Location = new System.Drawing.Point(16, 35);
            this.lblCodigo2.Name = "lblCodigo2";
            this.lblCodigo2.Size = new System.Drawing.Size(60, 18);
            this.lblCodigo2.TabIndex = 31;
            this.lblCodigo2.Text = "Código:";
            // 
            // txtCod
            // 
            this.txtCod.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCod.Location = new System.Drawing.Point(160, 32);
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(136, 24);
            this.txtCod.TabIndex = 29;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(541, 216);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Propiedades de estados";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(159)))), ((int)(((byte)(81)))));
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.Control;
            this.label10.Location = new System.Drawing.Point(620, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 31);
            this.label10.TabIndex = 39;
            this.label10.Text = " ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(159)))), ((int)(((byte)(81)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(-4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 31);
            this.label2.TabIndex = 37;
            this.label2.Text = " E";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTituloPanel
            // 
            this.lblTituloPanel.BackColor = System.Drawing.Color.Teal;
            this.lblTituloPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPanel.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTituloPanel.Location = new System.Drawing.Point(0, 0);
            this.lblTituloPanel.Name = "lblTituloPanel";
            this.lblTituloPanel.Size = new System.Drawing.Size(640, 31);
            this.lblTituloPanel.TabIndex = 36;
            this.lblTituloPanel.Text = "Tabla de Estados de Usuario";
            this.lblTituloPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.btnPuntos);
            this.panel5.Controls.Add(this.btoBuscar);
            this.panel5.Controls.Add(this.lblDescripcion);
            this.panel5.Controls.Add(this.txtDescripcion);
            this.panel5.Controls.Add(this.txtCodigo);
            this.panel5.Controls.Add(this.lblCodigo);
            this.panel5.Location = new System.Drawing.Point(37, 149);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(551, 86);
            this.panel5.TabIndex = 32;
            // 
            // btnPuntos
            // 
            this.btnPuntos.BackColor = System.Drawing.Color.White;
            this.btnPuntos.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.btnPuntos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPuntos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnPuntos.Location = new System.Drawing.Point(267, 9);
            this.btnPuntos.Name = "btnPuntos";
            this.btnPuntos.Size = new System.Drawing.Size(33, 24);
            this.btnPuntos.TabIndex = 32;
            this.btnPuntos.Text = "...\r\n   ";
            this.btnPuntos.UseVisualStyleBackColor = false;
            this.btnPuntos.Click += new System.EventHandler(this.btnPuntos_Click);
            // 
            // btoBuscar
            // 
            this.btoBuscar.BackColor = System.Drawing.Color.Teal;
            this.btoBuscar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btoBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btoBuscar.ForeColor = System.Drawing.Color.White;
            this.btoBuscar.Location = new System.Drawing.Point(429, 10);
            this.btoBuscar.Name = "btoBuscar";
            this.btoBuscar.Size = new System.Drawing.Size(75, 27);
            this.btoBuscar.TabIndex = 25;
            this.btoBuscar.Text = "Buscar";
            this.btoBuscar.UseVisualStyleBackColor = false;
            this.btoBuscar.Click += new System.EventHandler(this.botBuscar_Click);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(14, 52);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(87, 18);
            this.lblDescripcion.TabIndex = 31;
            this.lblDescripcion.Text = "Descripcion";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(155, 46);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(349, 24);
            this.txtDescripcion.TabIndex = 1;
            this.txtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescripcion_KeyPress);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.Location = new System.Drawing.Point(155, 10);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(132, 24);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.Location = new System.Drawing.Point(14, 10);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(56, 18);
            this.lblCodigo.TabIndex = 30;
            this.lblCodigo.Text = "Código";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Location = new System.Drawing.Point(14, 140);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(593, 381);
            this.panel2.TabIndex = 42;
            // 
            // frmStaUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(668, 620);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "frmStaUsuario";
            this.Text = "Usuario Status";
            this.Load += new System.EventHandler(this.frmStaUsuario_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmStaUsuario_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTituloPanel;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btoBuscar;
        private System.Windows.Forms.Button btoSalir;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblDescripcion2;
        private System.Windows.Forms.Label lblCodigo2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnPuntos;
        private System.Windows.Forms.Label lblMensaje;
        public System.Windows.Forms.TextBox txtDescrip;
        public System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripBtoAgregar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripBtoEditar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripBtoGuardar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripBtoEliminar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripBtoDescartar;
    }
}