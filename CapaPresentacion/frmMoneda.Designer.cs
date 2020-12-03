namespace CapaPresentacion
{
    partial class frmMoneda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMoneda));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblCuadrito = new System.Windows.Forms.Label();
            this.lblTituloPanel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lsvMoneda = new System.Windows.Forms.ListView();
            this.Codigo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.descripcion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Simbolo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Codmon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.panel1.Controls.Add(this.btnAceptar);
            this.panel1.Controls.Add(this.lblCuadrito);
            this.panel1.Controls.Add(this.lblTituloPanel);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(22, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(531, 494);
            this.panel1.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(159)))), ((int)(((byte)(81)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(511, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 32);
            this.label1.TabIndex = 39;
            this.label1.Text = " ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAceptar
            // 
            this.btnAceptar.AutoSize = true;
            this.btnAceptar.BackColor = System.Drawing.Color.Teal;
            this.btnAceptar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAceptar.Location = new System.Drawing.Point(410, 445);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(99, 30);
            this.btnAceptar.TabIndex = 42;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblCuadrito
            // 
            this.lblCuadrito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(159)))), ((int)(((byte)(81)))));
            this.lblCuadrito.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuadrito.ForeColor = System.Drawing.SystemColors.Control;
            this.lblCuadrito.Location = new System.Drawing.Point(-1, 0);
            this.lblCuadrito.Name = "lblCuadrito";
            this.lblCuadrito.Size = new System.Drawing.Size(41, 32);
            this.lblCuadrito.TabIndex = 38;
            this.lblCuadrito.Text = " L";
            this.lblCuadrito.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTituloPanel
            // 
            this.lblTituloPanel.BackColor = System.Drawing.Color.Teal;
            this.lblTituloPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPanel.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTituloPanel.Location = new System.Drawing.Point(0, 0);
            this.lblTituloPanel.Name = "lblTituloPanel";
            this.lblTituloPanel.Size = new System.Drawing.Size(527, 32);
            this.lblTituloPanel.TabIndex = 28;
            this.lblTituloPanel.Text = "Monedas";
            this.lblTituloPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btnBuscar);
            this.panel3.Controls.Add(this.lblCodigo);
            this.panel3.Controls.Add(this.txtCodigo);
            this.panel3.Controls.Add(this.txtDescripcion);
            this.panel3.Controls.Add(this.lblDescripcion);
            this.panel3.ForeColor = System.Drawing.SystemColors.Control;
            this.panel3.Location = new System.Drawing.Point(19, 52);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(490, 74);
            this.panel3.TabIndex = 22;
            // 
            // btnBuscar
            // 
            this.btnBuscar.AutoSize = true;
            this.btnBuscar.BackColor = System.Drawing.Color.Teal;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(372, 28);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(99, 28);
            this.btnBuscar.TabIndex = 25;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCodigo.Location = new System.Drawing.Point(16, 10);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(60, 18);
            this.lblCodigo.TabIndex = 6;
            this.lblCodigo.Text = "Código:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(16, 31);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(84, 22);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(119, 31);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(210, 22);
            this.txtDescripcion.TabIndex = 2;
            this.txtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescripcion_KeyPress);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDescripcion.Location = new System.Drawing.Point(116, 10);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(91, 18);
            this.lblDescripcion.TabIndex = 7;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(3, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(747, 2);
            this.label9.TabIndex = 27;
            this.label9.Text = " ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(191)))), ((int)(((byte)(199)))));
            this.label8.Location = new System.Drawing.Point(951, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 31);
            this.label8.TabIndex = 5;
            this.label8.Text = " ";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lsvMoneda);
            this.panel2.Location = new System.Drawing.Point(19, 162);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(490, 266);
            this.panel2.TabIndex = 23;
            // 
            // lsvMoneda
            // 
            this.lsvMoneda.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.lsvMoneda.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Codigo,
            this.descripcion,
            this.Simbolo,
            this.Codmon});
            this.lsvMoneda.FullRowSelect = true;
            this.lsvMoneda.GridLines = true;
            this.lsvMoneda.Location = new System.Drawing.Point(28, 26);
            this.lsvMoneda.Name = "lsvMoneda";
            this.lsvMoneda.Size = new System.Drawing.Size(455, 216);
            this.lsvMoneda.TabIndex = 0;
            this.lsvMoneda.UseCompatibleStateImageBehavior = false;
            this.lsvMoneda.View = System.Windows.Forms.View.Details;
            this.lsvMoneda.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lsvMoneda_DrawColumnHeader);
            this.lsvMoneda.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lsvMoneda_DrawItem);
            this.lsvMoneda.SelectedIndexChanged += new System.EventHandler(this.lsvMoneda_SelectedIndexChanged);
            // 
            // Codigo
            // 
            this.Codigo.Text = "Código";
            this.Codigo.Width = 105;
            // 
            // descripcion
            // 
            this.descripcion.Text = "Descripcion";
            this.descripcion.Width = 212;
            // 
            // Simbolo
            // 
            this.Simbolo.Text = "Simbolo";
            this.Simbolo.Width = 157;
            // 
            // Codmon
            // 
            this.Codmon.Text = "codigo";
            this.Codmon.Width = 0;
            // 
            // frmMoneda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(577, 520);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMoneda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Monedas";
            this.Load += new System.EventHandler(this.frmMoneda_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblCuadrito;
        private System.Windows.Forms.Label lblTituloPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lsvMoneda;
        private System.Windows.Forms.ColumnHeader Codigo;
        private System.Windows.Forms.ColumnHeader descripcion;
        private System.Windows.Forms.ColumnHeader Simbolo;
        private System.Windows.Forms.ColumnHeader Codmon;
    }
}