namespace CapaPresentacion
{
    partial class frmPropiedadesSistema
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPropiedadesSistema));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btoSalir = new System.Windows.Forms.Button();
            this.btoGuardar = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.PropiedadesSistema = new System.Windows.Forms.TabPage();
            this.dgvPropiedades = new System.Windows.Forms.DataGridView();
            this.CodigoModulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Configurar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cbocodModulo = new System.Windows.Forms.ComboBox();
            this.cboModulo = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblModulo = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblP = new System.Windows.Forms.Label();
            this.lblTituloPanel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.PropiedadesSistema.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPropiedades)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btoSalir);
            this.panel1.Controls.Add(this.btoGuardar);
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblP);
            this.panel1.Controls.Add(this.lblTituloPanel);
            this.panel1.Location = new System.Drawing.Point(9, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 598);
            this.panel1.TabIndex = 1;
            // 
            // btoSalir
            // 
            this.btoSalir.BackColor = System.Drawing.Color.Teal;
            this.btoSalir.Cursor = System.Windows.Forms.Cursors.Default;
            this.btoSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btoSalir.ForeColor = System.Drawing.Color.White;
            this.btoSalir.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btoSalir.Location = new System.Drawing.Point(709, 563);
            this.btoSalir.Name = "btoSalir";
            this.btoSalir.Size = new System.Drawing.Size(102, 27);
            this.btoSalir.TabIndex = 33;
            this.btoSalir.Text = "Salir";
            this.btoSalir.UseVisualStyleBackColor = false;
            this.btoSalir.Click += new System.EventHandler(this.btoSalir_Click);
            // 
            // btoGuardar
            // 
            this.btoGuardar.BackColor = System.Drawing.Color.Teal;
            this.btoGuardar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btoGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btoGuardar.ForeColor = System.Drawing.Color.White;
            this.btoGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btoGuardar.Location = new System.Drawing.Point(817, 563);
            this.btoGuardar.Name = "btoGuardar";
            this.btoGuardar.Size = new System.Drawing.Size(102, 27);
            this.btoGuardar.TabIndex = 29;
            this.btoGuardar.Text = "F7 Guardar";
            this.btoGuardar.UseVisualStyleBackColor = false;
            this.btoGuardar.Click += new System.EventHandler(this.btoGuardar_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.PropiedadesSistema);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(10, 47);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(919, 514);
            this.tabControl1.TabIndex = 32;
            // 
            // PropiedadesSistema
            // 
            this.PropiedadesSistema.Controls.Add(this.dgvPropiedades);
            this.PropiedadesSistema.Controls.Add(this.panel3);
            this.PropiedadesSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.PropiedadesSistema.Location = new System.Drawing.Point(4, 27);
            this.PropiedadesSistema.Name = "PropiedadesSistema";
            this.PropiedadesSistema.Padding = new System.Windows.Forms.Padding(3);
            this.PropiedadesSistema.Size = new System.Drawing.Size(911, 483);
            this.PropiedadesSistema.TabIndex = 0;
            this.PropiedadesSistema.Text = "Propiedades del Sistema";
            this.PropiedadesSistema.UseVisualStyleBackColor = true;
            // 
            // dgvPropiedades
            // 
            this.dgvPropiedades.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPropiedades.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPropiedades.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPropiedades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPropiedades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoModulo,
            this.Codigo,
            this.Nombre,
            this.Valor,
            this.Configurar});
            this.dgvPropiedades.Cursor = System.Windows.Forms.Cursors.Default;
            this.dgvPropiedades.Location = new System.Drawing.Point(6, 68);
            this.dgvPropiedades.Name = "dgvPropiedades";
            this.dgvPropiedades.ReadOnly = true;
            this.dgvPropiedades.RowHeadersWidth = 25;
            this.dgvPropiedades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPropiedades.Size = new System.Drawing.Size(898, 416);
            this.dgvPropiedades.TabIndex = 31;
            this.dgvPropiedades.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPropiedades_CellClick);
            // 
            // CodigoModulo
            // 
            this.CodigoModulo.FillWeight = 80.58376F;
            this.CodigoModulo.HeaderText = "Codigo de Modulo";
            this.CodigoModulo.Name = "CodigoModulo";
            this.CodigoModulo.ReadOnly = true;
            this.CodigoModulo.Width = 140;
            // 
            // Codigo
            // 
            this.Codigo.FillWeight = 80.58376F;
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 90;
            // 
            // Nombre
            // 
            this.Nombre.FillWeight = 80.58376F;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 495;
            // 
            // Valor
            // 
            this.Valor.FillWeight = 80.58376F;
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            this.Valor.Width = 120;
            // 
            // Configurar
            // 
            this.Configurar.FillWeight = 70F;
            this.Configurar.HeaderText = "";
            this.Configurar.Name = "Configurar";
            this.Configurar.ReadOnly = true;
            this.Configurar.Text = "...";
            this.Configurar.Width = 25;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btnBuscar);
            this.panel3.Controls.Add(this.cbocodModulo);
            this.panel3.Controls.Add(this.cboModulo);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.lblModulo);
            this.panel3.Controls.Add(this.txtBuscar);
            this.panel3.Controls.Add(this.lblBuscar);
            this.panel3.Location = new System.Drawing.Point(6, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(899, 60);
            this.panel3.TabIndex = 30;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Teal;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBuscar.Location = new System.Drawing.Point(787, 14);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(102, 27);
            this.btnBuscar.TabIndex = 34;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cbocodModulo
            // 
            this.cbocodModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbocodModulo.FormattingEnabled = true;
            this.cbocodModulo.Location = new System.Drawing.Point(739, 14);
            this.cbocodModulo.Name = "cbocodModulo";
            this.cbocodModulo.Size = new System.Drawing.Size(38, 26);
            this.cbocodModulo.TabIndex = 29;
            this.cbocodModulo.Visible = false;
            // 
            // cboModulo
            // 
            this.cboModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModulo.FormattingEnabled = true;
            this.cboModulo.Location = new System.Drawing.Point(490, 14);
            this.cboModulo.Name = "cboModulo";
            this.cboModulo.Size = new System.Drawing.Size(247, 26);
            this.cboModulo.TabIndex = 28;
            this.cboModulo.SelectedIndexChanged += new System.EventHandler(this.cboModulo_SelectedIndexChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(53, 52);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 27;
            this.pictureBox2.TabStop = false;
            // 
            // lblModulo
            // 
            this.lblModulo.AutoSize = true;
            this.lblModulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblModulo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblModulo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblModulo.Location = new System.Drawing.Point(429, 17);
            this.lblModulo.Name = "lblModulo";
            this.lblModulo.Size = new System.Drawing.Size(62, 18);
            this.lblModulo.TabIndex = 3;
            this.lblModulo.Text = "Modulo:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtBuscar.Location = new System.Drawing.Point(138, 15);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(285, 22);
            this.txtBuscar.TabIndex = 2;
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblBuscar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBuscar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblBuscar.Location = new System.Drawing.Point(72, 15);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(59, 18);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(159)))), ((int)(((byte)(81)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(924, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 32);
            this.label1.TabIndex = 31;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblP
            // 
            this.lblP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(159)))), ((int)(((byte)(81)))));
            this.lblP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblP.ForeColor = System.Drawing.Color.White;
            this.lblP.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblP.Location = new System.Drawing.Point(0, 0);
            this.lblP.Name = "lblP";
            this.lblP.Size = new System.Drawing.Size(34, 31);
            this.lblP.TabIndex = 3;
            this.lblP.Text = "P";
            this.lblP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.lblTituloPanel.Size = new System.Drawing.Size(944, 31);
            this.lblTituloPanel.TabIndex = 2;
            this.lblTituloPanel.Text = "Propiedades del Sistema";
            this.lblTituloPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmPropiedadesSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CapaPresentacion.Properties.Resources.images__6_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(963, 631);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPropiedadesSistema";
            this.Text = "Propiedades del Sistema";
            this.Load += new System.EventHandler(this.frmPropiedadesSistema_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.PropiedadesSistema.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPropiedades)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btoGuardar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage PropiedadesSistema;
        private System.Windows.Forms.DataGridView dgvPropiedades;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cbocodModulo;
        private System.Windows.Forms.ComboBox cboModulo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblModulo;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblP;
        private System.Windows.Forms.Label lblTituloPanel;
        private System.Windows.Forms.Button btoSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoModulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewButtonColumn Configurar;
        private System.Windows.Forms.Button btnBuscar;
    }
}
