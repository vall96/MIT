namespace CapaPresentacion
{
    partial class frmTbUsuariosElimi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTbUsuariosElimi));
            this.lstViewUsuaElimi = new System.Windows.Forms.ListView();
            this.usuario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Descripcion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.BtoEliminarTodo = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btoBuscar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btoSalir = new System.Windows.Forms.Button();
            this.btoAceptar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTituloPanel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstViewUsuaElimi
            // 
            this.lstViewUsuaElimi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.usuario,
            this.nombre,
            this.status,
            this.Descripcion});
            this.lstViewUsuaElimi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstViewUsuaElimi.GridLines = true;
            this.lstViewUsuaElimi.Location = new System.Drawing.Point(16, 15);
            this.lstViewUsuaElimi.MultiSelect = false;
            this.lstViewUsuaElimi.Name = "lstViewUsuaElimi";
            this.lstViewUsuaElimi.Size = new System.Drawing.Size(676, 340);
            this.lstViewUsuaElimi.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.lstViewUsuaElimi.TabIndex = 0;
            this.lstViewUsuaElimi.UseCompatibleStateImageBehavior = false;
            this.lstViewUsuaElimi.View = System.Windows.Forms.View.Details;
            this.lstViewUsuaElimi.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstViewUsuaElimi_ColumnClick);
            this.lstViewUsuaElimi.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lstViewUsuaElimi_DrawColumnHeader);
            this.lstViewUsuaElimi.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lstViewUsuaElimi_DrawItem);
            this.lstViewUsuaElimi.SelectedIndexChanged += new System.EventHandler(this.lstViewUsuaElimi_SelectedIndexChanged);
            this.lstViewUsuaElimi.DoubleClick += new System.EventHandler(this.lstViewUsuaElimi_DoubleClick);
            // 
            // usuario
            // 
            this.usuario.Text = "Usuario";
            this.usuario.Width = 185;
            // 
            // nombre
            // 
            this.nombre.Text = "Nombre";
            this.nombre.Width = 176;
            // 
            // status
            // 
            this.status.Text = "Status";
            this.status.Width = 0;
            // 
            // Descripcion
            // 
            this.Descripcion.Text = "Descripcion";
            this.Descripcion.Width = 344;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(16, 31);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(181, 22);
            this.txtUsuario.TabIndex = 1;
            this.txtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuarioElim_KeyPress);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(223, 31);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(178, 22);
            this.txtNombre.TabIndex = 2;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblUsuario.Location = new System.Drawing.Point(16, 10);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(60, 18);
            this.lblUsuario.TabIndex = 6;
            this.lblUsuario.Text = "Usuario";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNombre.Location = new System.Drawing.Point(220, 10);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(62, 18);
            this.lblNombre.TabIndex = 7;
            this.lblNombre.Text = "Nombre";
            // 
            // BtoEliminarTodo
            // 
            this.BtoEliminarTodo.BackColor = System.Drawing.Color.Teal;
            this.BtoEliminarTodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtoEliminarTodo.ForeColor = System.Drawing.SystemColors.Control;
            this.BtoEliminarTodo.Location = new System.Drawing.Point(37, 561);
            this.BtoEliminarTodo.Name = "BtoEliminarTodo";
            this.BtoEliminarTodo.Size = new System.Drawing.Size(119, 30);
            this.BtoEliminarTodo.TabIndex = 10;
            this.BtoEliminarTodo.Text = "Eliminar Todo";
            this.BtoEliminarTodo.UseVisualStyleBackColor = false;
            this.BtoEliminarTodo.Click += new System.EventHandler(this.BtoEliminarTodo_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btoBuscar);
            this.panel3.Controls.Add(this.lblUsuario);
            this.panel3.Controls.Add(this.txtUsuario);
            this.panel3.Controls.Add(this.txtNombre);
            this.panel3.Controls.Add(this.lblNombre);
            this.panel3.ForeColor = System.Drawing.SystemColors.Control;
            this.panel3.Location = new System.Drawing.Point(19, 52);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(694, 74);
            this.panel3.TabIndex = 22;
            // 
            // btoBuscar
            // 
            this.btoBuscar.BackColor = System.Drawing.Color.Teal;
            this.btoBuscar.Cursor = System.Windows.Forms.Cursors.Default;
            this.btoBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btoBuscar.ForeColor = System.Drawing.Color.White;
            this.btoBuscar.Location = new System.Drawing.Point(439, 31);
            this.btoBuscar.Name = "btoBuscar";
            this.btoBuscar.Size = new System.Drawing.Size(99, 25);
            this.btoBuscar.TabIndex = 25;
            this.btoBuscar.Text = "Buscar";
            this.btoBuscar.UseVisualStyleBackColor = false;
            this.btoBuscar.Click += new System.EventHandler(this.botBuscar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lstViewUsuaElimi);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(19, 162);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(712, 384);
            this.panel2.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(3, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(747, 2);
            this.label9.TabIndex = 27;
            this.label9.Text = " ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.BtoEliminarTodo);
            this.panel1.Controls.Add(this.btoSalir);
            this.panel1.Controls.Add(this.btoAceptar);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lblTituloPanel);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(11, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(755, 610);
            this.panel1.TabIndex = 28;
            // 
            // btoSalir
            // 
            this.btoSalir.BackColor = System.Drawing.Color.Teal;
            this.btoSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btoSalir.ForeColor = System.Drawing.SystemColors.Control;
            this.btoSalir.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btoSalir.Location = new System.Drawing.Point(614, 561);
            this.btoSalir.Name = "btoSalir";
            this.btoSalir.Size = new System.Drawing.Size(99, 30);
            this.btoSalir.TabIndex = 41;
            this.btoSalir.Text = "Salir";
            this.btoSalir.UseVisualStyleBackColor = false;
            this.btoSalir.Click += new System.EventHandler(this.btoSalir_Click);
            // 
            // btoAceptar
            // 
            this.btoAceptar.BackColor = System.Drawing.Color.Teal;
            this.btoAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btoAceptar.ForeColor = System.Drawing.SystemColors.Control;
            this.btoAceptar.Location = new System.Drawing.Point(473, 561);
            this.btoAceptar.Name = "btoAceptar";
            this.btoAceptar.Size = new System.Drawing.Size(99, 30);
            this.btoAceptar.TabIndex = 40;
            this.btoAceptar.Text = "Aceptar";
            this.btoAceptar.UseVisualStyleBackColor = false;
            this.btoAceptar.Click += new System.EventHandler(this.btoAceptar_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(159)))), ((int)(((byte)(81)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(730, -2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 34);
            this.label3.TabIndex = 39;
            this.label3.Text = "  ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(159)))), ((int)(((byte)(81)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(-1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 32);
            this.label2.TabIndex = 38;
            this.label2.Text = " E";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTituloPanel
            // 
            this.lblTituloPanel.BackColor = System.Drawing.Color.Teal;
            this.lblTituloPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTituloPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPanel.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTituloPanel.Location = new System.Drawing.Point(0, 0);
            this.lblTituloPanel.Name = "lblTituloPanel";
            this.lblTituloPanel.Size = new System.Drawing.Size(751, 32);
            this.lblTituloPanel.TabIndex = 28;
            this.lblTituloPanel.Text = "Usuario Eliminados";
            this.lblTituloPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // frmTbUsuariosElimi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(778, 638);
            this.Controls.Add(this.panel1);
            this.Name = "frmTbUsuariosElimi";
            this.Text = "Usuarios Eliminados MIT";
            this.Load += new System.EventHandler(this.frmUsuariosEliminados_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstViewUsuaElimi;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button BtoEliminarTodo;
        private System.Windows.Forms.ColumnHeader usuario;
        private System.Windows.Forms.ColumnHeader nombre;
        private System.Windows.Forms.ColumnHeader status;
        private System.Windows.Forms.ColumnHeader Descripcion;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btoBuscar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTituloPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btoSalir;
        private System.Windows.Forms.Button btoAceptar;
    }
}