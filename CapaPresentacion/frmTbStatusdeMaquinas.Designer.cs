namespace CapaPresentacion
{
    partial class frmTbStatusdeMaquinas
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
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btoSalir = new System.Windows.Forms.Button();
            this.btoAceptar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btoBuscar = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lsvEstatusMaquina = new System.Windows.Forms.ListView();
            this.codigo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.descripcion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label5 = new System.Windows.Forms.Label();
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
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.btoSalir);
            this.panel1.Controls.Add(this.btoAceptar);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblTituloPanel);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(547, 478);
            this.panel1.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(159)))), ((int)(((byte)(81)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(525, -2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 33);
            this.label1.TabIndex = 40;
            this.label1.Text = " ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(-3, 134);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(733, 2);
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
            this.btoSalir.Location = new System.Drawing.Point(315, 429);
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
            this.btoAceptar.Location = new System.Drawing.Point(114, 429);
            this.btoAceptar.Name = "btoAceptar";
            this.btoAceptar.Size = new System.Drawing.Size(99, 30);
            this.btoAceptar.TabIndex = 24;
            this.btoAceptar.Text = "Aceptar";
            this.btoAceptar.UseVisualStyleBackColor = false;
            this.btoAceptar.Click += new System.EventHandler(this.btoAceptar_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btoBuscar);
            this.panel3.Controls.Add(this.txtCodigo);
            this.panel3.Controls.Add(this.lblDescripcion);
            this.panel3.Controls.Add(this.txtDescripcion);
            this.panel3.Controls.Add(this.lblCodigo);
            this.panel3.ForeColor = System.Drawing.SystemColors.Control;
            this.panel3.Location = new System.Drawing.Point(22, 47);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(510, 74);
            this.panel3.TabIndex = 17;
            // 
            // btoBuscar
            // 
            this.btoBuscar.BackColor = System.Drawing.Color.Teal;
            this.btoBuscar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btoBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btoBuscar.ForeColor = System.Drawing.Color.White;
            this.btoBuscar.Location = new System.Drawing.Point(386, 27);
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
            this.txtCodigo.Location = new System.Drawing.Point(21, 29);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(108, 24);
            this.txtCodigo.TabIndex = 11;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblDescripcion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDescripcion.Location = new System.Drawing.Point(169, 8);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(87, 18);
            this.lblDescripcion.TabIndex = 15;
            this.lblDescripcion.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txtDescripcion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtDescripcion.Location = new System.Drawing.Point(172, 29);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(182, 24);
            this.txtDescripcion.TabIndex = 12;
            this.txtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescripcion_KeyPress);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lblCodigo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCodigo.Location = new System.Drawing.Point(18, 8);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(56, 18);
            this.lblCodigo.TabIndex = 14;
            this.lblCodigo.Text = "Código";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lsvEstatusMaquina);
            this.panel2.Location = new System.Drawing.Point(22, 157);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(510, 266);
            this.panel2.TabIndex = 10;
            // 
            // lsvEstatusMaquina
            // 
            this.lsvEstatusMaquina.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.codigo,
            this.descripcion});
            this.lsvEstatusMaquina.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvEstatusMaquina.FullRowSelect = true;
            this.lsvEstatusMaquina.GridLines = true;
            this.lsvEstatusMaquina.Location = new System.Drawing.Point(21, 17);
            this.lsvEstatusMaquina.Name = "lsvEstatusMaquina";
            this.lsvEstatusMaquina.Size = new System.Drawing.Size(464, 219);
            this.lsvEstatusMaquina.TabIndex = 0;
            this.lsvEstatusMaquina.UseCompatibleStateImageBehavior = false;
            this.lsvEstatusMaquina.View = System.Windows.Forms.View.Details;
            this.lsvEstatusMaquina.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lsvEstatusMaquina_ColumnClick);
            this.lsvEstatusMaquina.DoubleClick += new System.EventHandler(this.lsvCategoria_DoubleClick);
            // 
            // codigo
            // 
            this.codigo.Text = "Código";
            this.codigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.codigo.Width = 143;
            // 
            // descripcion
            // 
            this.descripcion.Text = "Descripción";
            this.descripcion.Width = 468;
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
            this.label2.Size = new System.Drawing.Size(40, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "SM";
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
            this.lblTituloPanel.Size = new System.Drawing.Size(543, 31);
            this.lblTituloPanel.TabIndex = 0;
            this.lblTituloPanel.Text = "Status De Maquina";
            this.lblTituloPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmTbStatusdeMaquinas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CapaPresentacion.Properties.Resources.images__6_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(571, 500);
            this.Controls.Add(this.panel1);
            this.Name = "frmTbStatusdeMaquinas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tabla Status de Maquinas";
            this.Load += new System.EventHandler(this.frmTbStatusdeMaquinas_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btoSalir;
        private System.Windows.Forms.Button btoAceptar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btoBuscar;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lsvEstatusMaquina;
        private System.Windows.Forms.ColumnHeader codigo;
        private System.Windows.Forms.ColumnHeader descripcion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTituloPanel;
    }
}
