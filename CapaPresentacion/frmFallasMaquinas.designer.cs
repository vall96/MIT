namespace CapaPresentacion
{
    partial class frmFallasMaquinas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFallasMaquinas));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btoSalir = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabIformacionG = new System.Windows.Forms.TabPage();
            this.txtDescrip = new System.Windows.Forms.TextBox();
            this.txtCod = new System.Windows.Forms.TextBox();
            this.lblDescrip = new System.Windows.Forms.Label();
            this.lblCod = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btoBuscar = new System.Windows.Forms.Button();
            this.btoPuntos = new System.Windows.Forms.Button();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripBtoAgregar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtoEditar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtoGuardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtoEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtoDescartar = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblF = new System.Windows.Forms.Label();
            this.lblTituloPanel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabIformacionG.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel7.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btoSalir);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblF);
            this.panel1.Controls.Add(this.lblTituloPanel);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(541, 447);
            this.panel1.TabIndex = 0;
            // 
            // btoSalir
            // 
            this.btoSalir.BackColor = System.Drawing.Color.Teal;
            this.btoSalir.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F);
            this.btoSalir.ForeColor = System.Drawing.SystemColors.Control;
            this.btoSalir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btoSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btoSalir.Location = new System.Drawing.Point(424, 411);
            this.btoSalir.Name = "btoSalir";
            this.btoSalir.Size = new System.Drawing.Size(99, 30);
            this.btoSalir.TabIndex = 30;
            this.btoSalir.Text = "Salir";
            this.btoSalir.UseVisualStyleBackColor = false;
            this.btoSalir.Click += new System.EventHandler(this.btoSalir_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Location = new System.Drawing.Point(17, 126);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(508, 281);
            this.panel4.TabIndex = 3;
            this.panel4.Tag = "";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Location = new System.Drawing.Point(30, 106);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(453, 158);
            this.panel2.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabIformacionG);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.tabControl1.Location = new System.Drawing.Point(3, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(417, 127);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.Tag = "";
            // 
            // tabIformacionG
            // 
            this.tabIformacionG.Controls.Add(this.txtDescrip);
            this.tabIformacionG.Controls.Add(this.txtCod);
            this.tabIformacionG.Controls.Add(this.lblDescrip);
            this.tabIformacionG.Controls.Add(this.lblCod);
            this.tabIformacionG.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.tabIformacionG.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(191)))), ((int)(((byte)(199)))));
            this.tabIformacionG.Location = new System.Drawing.Point(4, 27);
            this.tabIformacionG.Name = "tabIformacionG";
            this.tabIformacionG.Padding = new System.Windows.Forms.Padding(3);
            this.tabIformacionG.Size = new System.Drawing.Size(409, 96);
            this.tabIformacionG.TabIndex = 0;
            this.tabIformacionG.Text = "Información general";
            this.tabIformacionG.UseVisualStyleBackColor = true;
            // 
            // txtDescrip
            // 
            this.txtDescrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtDescrip.Location = new System.Drawing.Point(118, 47);
            this.txtDescrip.Name = "txtDescrip";
            this.txtDescrip.Size = new System.Drawing.Size(256, 22);
            this.txtDescrip.TabIndex = 5;
            // 
            // txtCod
            // 
            this.txtCod.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtCod.Location = new System.Drawing.Point(118, 17);
            this.txtCod.Name = "txtCod";
            this.txtCod.Size = new System.Drawing.Size(138, 22);
            this.txtCod.TabIndex = 3;
            this.txtCod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCod_KeyPress);
            // 
            // lblDescrip
            // 
            this.lblDescrip.AutoSize = true;
            this.lblDescrip.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblDescrip.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDescrip.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDescrip.Location = new System.Drawing.Point(6, 47);
            this.lblDescrip.Name = "lblDescrip";
            this.lblDescrip.Size = new System.Drawing.Size(91, 18);
            this.lblDescrip.TabIndex = 4;
            this.lblDescrip.Text = "Descripcion:";
            // 
            // lblCod
            // 
            this.lblCod.AutoSize = true;
            this.lblCod.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblCod.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCod.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCod.Location = new System.Drawing.Point(6, 17);
            this.lblCod.Name = "lblCod";
            this.lblCod.Size = new System.Drawing.Size(56, 18);
            this.lblCod.TabIndex = 1;
            this.lblCod.Text = "Código";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.btoBuscar);
            this.panel3.Controls.Add(this.btoPuntos);
            this.panel3.Controls.Add(this.lblDescripcion);
            this.panel3.Controls.Add(this.txtDescripcion);
            this.panel3.Controls.Add(this.txtCodigo);
            this.panel3.Controls.Add(this.lblCodigo);
            this.panel3.Location = new System.Drawing.Point(30, 19);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(453, 81);
            this.panel3.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // btoBuscar
            // 
            this.btoBuscar.BackColor = System.Drawing.Color.Teal;
            this.btoBuscar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btoBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btoBuscar.ForeColor = System.Drawing.Color.White;
            this.btoBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btoBuscar.Location = new System.Drawing.Point(359, 12);
            this.btoBuscar.Name = "btoBuscar";
            this.btoBuscar.Size = new System.Drawing.Size(75, 27);
            this.btoBuscar.TabIndex = 25;
            this.btoBuscar.Text = "Buscar";
            this.btoBuscar.UseVisualStyleBackColor = false;
            this.btoBuscar.Click += new System.EventHandler(this.btoBuscar_Click);
            // 
            // btoPuntos
            // 
            this.btoPuntos.BackColor = System.Drawing.Color.White;
            this.btoPuntos.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F);
            this.btoPuntos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btoPuntos.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btoPuntos.Location = new System.Drawing.Point(279, 13);
            this.btoPuntos.Name = "btoPuntos";
            this.btoPuntos.Size = new System.Drawing.Size(33, 25);
            this.btoPuntos.TabIndex = 5;
            this.btoPuntos.Text = "...\r\n   ";
            this.btoPuntos.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btoPuntos.UseVisualStyleBackColor = false;
            this.btoPuntos.Click += new System.EventHandler(this.btoPuntos_Click);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblDescripcion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDescripcion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDescripcion.Location = new System.Drawing.Point(81, 43);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(91, 18);
            this.lblDescripcion.TabIndex = 3;
            this.lblDescripcion.Text = "Descripcion:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtDescripcion.Location = new System.Drawing.Point(188, 43);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(196, 22);
            this.txtDescripcion.TabIndex = 2;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtCodigo.Location = new System.Drawing.Point(188, 15);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(124, 22);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblCodigo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCodigo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCodigo.Location = new System.Drawing.Point(81, 15);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(60, 18);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código:";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(-98, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(699, 2);
            this.label3.TabIndex = 30;
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.AutoSize = true;
            this.panel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Controls.Add(this.toolStrip2);
            this.panel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel7.ForeColor = System.Drawing.Color.Teal;
            this.panel7.Location = new System.Drawing.Point(17, 43);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(369, 46);
            this.panel7.TabIndex = 31;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(31, 22);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtoAgregar,
            this.toolStripSeparator5,
            this.toolStripBtoEditar,
            this.toolStripSeparator6,
            this.toolStripBtoGuardar,
            this.toolStripSeparator7,
            this.toolStripBtoEliminar,
            this.toolStripSeparator8,
            this.toolStripBtoDescartar});
            this.toolStrip2.Location = new System.Drawing.Point(4, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(361, 42);
            this.toolStrip2.TabIndex = 20;
            // 
            // toolStripBtoAgregar
            // 
            this.toolStripBtoAgregar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtoAgregar.Image")));
            this.toolStripBtoAgregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtoAgregar.Margin = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this.toolStripBtoAgregar.Name = "toolStripBtoAgregar";
            this.toolStripBtoAgregar.Size = new System.Drawing.Size(67, 39);
            this.toolStripBtoAgregar.Text = "F5 Agregar";
            this.toolStripBtoAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripBtoAgregar.Click += new System.EventHandler(this.toolStripBtoAgregar_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.toolStripSeparator5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 42);
            // 
            // toolStripBtoEditar
            // 
            this.toolStripBtoEditar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtoEditar.Image")));
            this.toolStripBtoEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtoEditar.Name = "toolStripBtoEditar";
            this.toolStripBtoEditar.Size = new System.Drawing.Size(56, 39);
            this.toolStripBtoEditar.Text = "F6 Editar";
            this.toolStripBtoEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripBtoEditar.Click += new System.EventHandler(this.toolStripBtoEditar_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 42);
            // 
            // toolStripBtoGuardar
            // 
            this.toolStripBtoGuardar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtoGuardar.Image")));
            this.toolStripBtoGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtoGuardar.Name = "toolStripBtoGuardar";
            this.toolStripBtoGuardar.Size = new System.Drawing.Size(68, 39);
            this.toolStripBtoGuardar.Text = "F7 Guardar";
            this.toolStripBtoGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripBtoGuardar.Click += new System.EventHandler(this.toolStripBtoGuardar_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 42);
            // 
            // toolStripBtoEliminar
            // 
            this.toolStripBtoEliminar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtoEliminar.Image")));
            this.toolStripBtoEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtoEliminar.Name = "toolStripBtoEliminar";
            this.toolStripBtoEliminar.Size = new System.Drawing.Size(67, 39);
            this.toolStripBtoEliminar.Text = "F8 Eliminar";
            this.toolStripBtoEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripBtoEliminar.Click += new System.EventHandler(this.toolStripBtoEliminar_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 42);
            // 
            // toolStripBtoDescartar
            // 
            this.toolStripBtoDescartar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtoDescartar.Image")));
            this.toolStripBtoDescartar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtoDescartar.Name = "toolStripBtoDescartar";
            this.toolStripBtoDescartar.Size = new System.Drawing.Size(74, 39);
            this.toolStripBtoDescartar.Text = "F9 Descartar";
            this.toolStripBtoDescartar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripBtoDescartar.Click += new System.EventHandler(this.toolStripBtoDescartar_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(159)))), ((int)(((byte)(81)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(521, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 32);
            this.label1.TabIndex = 30;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblF
            // 
            this.lblF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(159)))), ((int)(((byte)(81)))));
            this.lblF.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblF.ForeColor = System.Drawing.Color.White;
            this.lblF.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblF.Location = new System.Drawing.Point(0, 0);
            this.lblF.Name = "lblF";
            this.lblF.Size = new System.Drawing.Size(34, 31);
            this.lblF.TabIndex = 2;
            this.lblF.Text = "F";
            this.lblF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTituloPanel
            // 
            this.lblTituloPanel.BackColor = System.Drawing.Color.Teal;
            this.lblTituloPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblTituloPanel.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTituloPanel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblTituloPanel.Location = new System.Drawing.Point(0, 0);
            this.lblTituloPanel.Name = "lblTituloPanel";
            this.lblTituloPanel.Size = new System.Drawing.Size(541, 31);
            this.lblTituloPanel.TabIndex = 1;
            this.lblTituloPanel.Text = "Falla de Maquinas";
            this.lblTituloPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmFallasMaquinas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CapaPresentacion.Properties.Resources.images__6_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(563, 477);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmFallasMaquinas";
            this.Text = "Falla de Maquinas";
            this.Load += new System.EventHandler(this.frmFallasMaquinas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFallasMaquinas_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabIformacionG.ResumeLayout(false);
            this.tabIformacionG.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTituloPanel;
        private System.Windows.Forms.Label lblF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripBtoAgregar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripBtoEditar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton toolStripBtoGuardar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton toolStripBtoEliminar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton toolStripBtoDescartar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabIformacionG;
        private System.Windows.Forms.TextBox txtDescrip;
        private System.Windows.Forms.TextBox txtCod;
        private System.Windows.Forms.Label lblDescrip;
        private System.Windows.Forms.Label lblCod;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btoBuscar;
        private System.Windows.Forms.Button btoPuntos;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Button btoSalir;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}