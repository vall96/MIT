using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;
using CultureResources;
using System.Windows.Forms;
using CapaLogicaNegocios;
using System.Windows.Threading;

namespace CapaPresentacion
{
    public partial class frmUsuarioPruebaEstilo : Form
    {
        public frmUsuarioPruebaEstilo()
        {
            InitializeComponent();
            this.cboCodStatus.Visible = false;
        //    this.cboCodStatus.Enabled= false;
            this.cboStatus.Visible = false;

            tipoPais = frmRegristroUsuario.tipoPais;

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);

            AplicarIdioma();

        }

        private delegate void EmptyDelegate();
        private clsUsuario lstview = new clsUsuario();
        private clsUsuario Usua = new clsUsuario();
        private clsStatus c = new clsStatus();
        frmTbUsuarioPersonalizada ventUsuarioPerso;
        frmPrincipal ventPrincipal;
        public string usuario="",nombre="";
        public string mensajeText = "", mensajeCaption = "";

        public string estado = "", tipoPais = "";
        public static string accion = "", user="", nomb="", estad="", descripcion="";
        private string usuaValido = "";
        public static int ventana = 0;
       
        public void cargarDatos()
        {

            //ventUsuarioPerso = new frmTbUsuarioPersonalizada();
            txtUsuario.Text = frmTbUsuarioPersonalizada._usuario;
            txtUsua.Text = frmTbUsuarioPersonalizada._usuario;
            txtNom.Text = frmTbUsuarioPersonalizada._nombre;
            txtNombre.Text = frmTbUsuarioPersonalizada._nombre;
            txtDescripcion.Text = frmTbUsuarioPersonalizada._descripion;
       
         
        
        }

        //protected void DoEvents()
        //{
        //    Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.Background, new EmptyDelegate(delegate { }));
        //}
        private void btnPuntos_Click(object sender, EventArgs e)
        {
            //this.Location = new System.Drawing.Point(0, 175);
                        
           // this.Hide();
            if (ventana==0)
            {
            ventUsuarioPerso = new frmTbUsuarioPersonalizada();
            ventUsuarioPerso.pasado += new frmTbUsuarioPersonalizada.pasar(ejecutar);
                //ventUsuarioPerso.Show();
                ventUsuarioPerso.ShowDialog();
            ventana++;
            }
            else
            {
                ventUsuarioPerso.pasado += new frmTbUsuarioPersonalizada.pasar(ejecutar);
                ventUsuarioPerso.ShowDialog();
                //ventUsuarioPerso.Show();                
            }
            
        }
        public void ejecutar (string[,] dato)
        {
            txtUsuario.Text = dato[0,0];
            txtUsua.Text = dato[0, 0];
            txtNom.Text = dato[0, 1];
            txtNombre.Text = dato[0,1];
            txtDescripcion.Text = dato[0, 2];
            this.toolStripBtoEditar.Enabled = true;
            this.toolStripBtoEliminar.Enabled = true;
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            this.btoBuscar.Enabled = false;
        }



        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                FuncionBuscar();                
            }
        }

        private void frmUsuarioPruebaEstilo_Load(object sender, EventArgs e)
        {
            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();

            // this.txtDescripcion.au;
            //Ypos = Location.Y;
            //Xpos = Location.X;
            ventUsuarioPerso = new frmTbUsuarioPersonalizada();
            //  ventUsuarioPerso.MdiParent = this;
            //ventPrincipal = new frmPrincipal("","");
           
            this.Location = new System.Drawing.Point(0,0);
            cargar_statuscbox();
            FuncionInicio();
        }

        private void frmUsuarioPruebaEstilo_FormClosed(object sender, FormClosedEventArgs e)
        {
            //ventUsuarioPerso.cerrar();        
        }

        private void botBuscar_Click(object sender, EventArgs e)
        {
            FuncionBuscar();
        }

        private void FuncionBuscar()
        {
            estado = "buscar";
            if (txtUsuario.Text == "" && txtNombre.Text == "")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);

                mensajeText = StringResources.IngresarNombreDeUsuario;

                MessageBox.Show(mensajeText, mensajeCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                this.txtUsuario.Focus();
                return;
                // usuaValido = "no";
            }
            else if ((txtUsuario.Text != "" && txtNombre.Text != ""))
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.No_se_puede_realizar_la_busqueda_con_todos_los_campos_llenos;
                mensajeCaption = StringResources.ErrordeValidacion;

                MessageBox.Show(mensajeText, mensajeCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                this.txtUsuario.Focus();
                return;
            }
            else
            {
                if (txtUsuario.Text != "")
                {
                    usuario = txtUsuario.Text;
                    nombre = "";
                    ventUsuarioPerso.validarUsuario_Buscar(usuario, nombre, estado);
                }
                else
                {
                    usuario = "";
                    nombre = txtNombre.Text;
                    ventUsuarioPerso.validarUsuario_Buscar(usuario, nombre, estado);

                }
                if (frmTbUsuarioPersonalizada.usuaValido == "usuario valido")
                {
                    txtUsua.Text = frmTbUsuarioPersonalizada._usuario;
                    txtUsuario.Text = frmTbUsuarioPersonalizada._usuario;
                    txtNom.Text = frmTbUsuarioPersonalizada._nombre;
                    txtNombre.Text = frmTbUsuarioPersonalizada._nombre;
                    txtDescripcion.Text = frmTbUsuarioPersonalizada._descripion;
                    cboStatus.Text = txtDescripcion.Text;
                    HabilitarBotones();
                }
                else
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    mensajeText = StringResources.NoSeEncontroInformacion;
                    mensajeCaption = StringResources.ErrordeValidacion;

                    MessageBox.Show(mensajeText, mensajeCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                    this.txtUsuario.Focus();
                    LimpiarCajas();

                }
            }
        }
        private void toolStripBtoDescartar_Click(object sender, EventArgs e)
        {
            LimpiarCajas();
            FuncionInicio();
        }

        public void HabilitarBotones()
        {
            this.toolStripBtoEditar.Enabled = true;
            this.toolStripBtoEliminar.Enabled = true;
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            this.btoBuscar.Enabled = false;
        }
        private void LimpiarCajas()
        {
            txtDescripcion.Text = "";
            txtUsua.Text = "";
            txtUsuario.Text = "";
            txtNom.Text = "";
            txtNombre.Text = "";
            cboStatus.Text = "";
            cboCodStatus.Text = "";
        }
        private void FuncionInicio()
        {
            this.btnPuntos.Enabled = true;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoEliminar.Enabled = false;
            this.toolStripBtoGuardar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = false;
            this.toolStripBtoAgregar.Enabled = true;
            this.btoBuscar.Enabled = true;

            txtNom.Enabled = false;
            txtUsua.Enabled = false;
            txtDescripcion.Enabled = false;
            cboStatus.Visible = false;
            txtNombre.Enabled = true;
            txtUsuario.Enabled = true;
        }

        private void cargar_statuscbox()
        {
            DataTable dt = new DataTable();
            dt = c.Listado_status();
            //  num_usuarios = dt.Rows.Count;
            //agrgregar parametros a combobox de valido
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.cboStatus.Items.Add(dt.Rows[i]["st_descripcion"].ToString());
                cboCodStatus.Items.Add(dt.Rows[i]["st_status"].ToString());
            }

        }
        private void toolStripBtoEditar_Click(object sender, EventArgs e)
        {
            funcionEditar();
            accion = "editar";
        }

        private void funcionEditar()
        {
            this.btnPuntos.Enabled = false;
            this.toolStripBtoGuardar.Enabled = true;
            txtNom.Enabled = true;
            this.btoBuscar.Enabled = false;
            // txtUsua.Enabled = true;            
            txtUsuario.Enabled = false;
            txtNombre.Enabled = false;
            this.cboStatus.Visible = true;
            this.toolStripBtoEliminar.Enabled = false;
            this.toolStripBtoEditar.Enabled = false;
            accion = "editar";
            this.txtNom.Focus();
            this.cboStatus.Text = this.txtDescripcion.Text;
        }

        private void funcionGuardar()
        {
            if (accion == "editar")
            {
                if (frmTbUsuarioPersonalizada.usuaValido == "usuario valido")
                {
                    if (txtNom.Text == "")
                    {

                        Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                        mensajeText = StringResources.frmUsuarioEstiloPrueba_messDebeingresarUnNombre; ;
                        mensajeCaption = StringResources.ErrordeValidacion;
                        MessageBox.Show(mensajeText, mensajeCaption,
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error);

                        txtNom.Focus();
                        return;
                    }
                    else
                    {
                        string msj = "";
                        string status = "";
                        Usua.m_username = txtUsua.Text.ToString().Trim();
                        Usua.m_nombre = txtNom.Text.ToString().Trim();
                        status = cboCodStatus.SelectedItem.ToString();
                        Usua.m_status = Int32.Parse(status.ToString());
                        //Usua.actualizar_usuarios();
                        msj = Usua.actualizar_usuarios();

                        Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                        mensajeCaption = StringResources.frmUsuarioEstiloPrueba_TituloValidacionDeActualizacion;
                        if (msj== "Actualizacion Exitosa")
                        {
                            msj = StringResources.DBActualizacionExitosa;
                            MessageBox.Show(msj, mensajeCaption,
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
                        }

                       

                        actualizarListview();
                        LimpiarCajas();
                        FuncionInicio();
                    }
                }
            }
            else if (accion == "agregar")
            {
                if (this.txtUsua.Text == "")
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    mensajeText = StringResources.IngresarNombreDeUsuario;
                    mensajeCaption = StringResources.ErrordeValidacion;

                    MessageBox.Show(mensajeText, mensajeCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                    this.txtUsua.Focus();                  
                    return;

                }
                if (this.txtNom.Text == "")
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    mensajeText = StringResources.frmUsuarioEstiloPrueba_messDebeingresarUnNombre; ;
                    mensajeCaption = StringResources.ErrordeValidacion;

                    MessageBox.Show(mensajeText, mensajeCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                    this.txtNom.Focus();
                    return;
                }
                else
                {
                    string msj = "";
                    string status = "";
                    Usua.m_username = txtUsua.Text.ToString().Trim();
                    Usua.m_nombre = txtNom.Text.ToString().Trim();
                    status = cboCodStatus.SelectedItem.ToString();   //paso el valor a status y luego a entero
                    Usua.m_status = Int32.Parse(status.ToString());
                    msj = Usua.registar_usuarios();
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    mensajeCaption = StringResources.ValidaciondeRegistro;
                    if (msj== "Registro exitoso")
                    {
                        msj = StringResources.DBRegistroexitoso;
                        MessageBox.Show(msj, mensajeCaption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                    actualizarListview();
                    LimpiarCajas();
                    FuncionInicio();
                }
            }
        }

        private void actualizarListview()
        {
            
            user = txtUsua.Text.ToString().Trim();
            nomb = txtNom.Text.ToString().Trim();
            //estad = cboCodStatus.SelectedItem.ToString();
            descripcion = txtDescripcion.Text.ToString().Trim();
            ventUsuarioPerso.ActualizarListview(accion);

        }
        private void funcionEliminar()
        {
            if (frmTbUsuarioPersonalizada.usuaValido == "usuario valido")             // si en buscar encontro un usuario valido
            {
                string msj = "";

                //Preguntar al usuario si esta seguro de eliminar el resgistro
                DialogResult respuesta;

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.frmUsuarioEstiloPrueba_messDeseaEliminarUsuario;
                mensajeCaption = StringResources.ValidacióndeEliminación;

                respuesta = MessageBox.Show(mensajeText + txtUsuario.Text.ToString().Trim() + " ?", mensajeCaption, MessageBoxButtons.YesNo);

                if (respuesta== DialogResult.Yes)
                {
                    Usua.m_username = txtUsua.Text.ToString().Trim();
                    //Usua.EliminarUsuario();
                    msj = Usua.EliminarUsuario();

                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    mensajeCaption = StringResources.ValidacióndeEliminación;

                    if (msj== "Eliminacion exitosa")
                    {
                        msj = StringResources.DBEliminacionexitosa;
                        MessageBox.Show(msj, mensajeCaption,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }                  
                    actualizarListview();
                }       
            }
        }

        private void funcionAgregar()
        {
            this.btnPuntos.Enabled = false;
            LimpiarCajas();
            //*****Habilitar Botones*****************//
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoEliminar.Enabled = false;
            this.toolStripBtoGuardar.Enabled = true;
            this.toolStripBtoDescartar.Enabled = true;
            //****************Habilitar cajas***********************
            txtNombre.Enabled = false;
            txtUsuario.Enabled = false;
            //***************************************************
            txtUsua.Enabled = true;
            txtNom.Enabled = true;
            txtDescripcion.Enabled = false;
            cboStatus.Visible = true;
            cboStatus.SelectedIndex = 0;
            cboCodStatus.SelectedIndex = 0;
            this.txtUsua.Focus();
            this.btoBuscar.Enabled = false;
        }

        private void frmUsuarioPruebaEstilo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                funcionAgregar();
                accion = "agregar";
            }
            if (e.KeyCode == Keys.F6)
            {
                funcionEditar();
                accion = "editar";
            }
            if (e.KeyCode == Keys.F7)
            {
                funcionGuardar();
            }
            if (e.KeyCode == Keys.F8)
            {
                accion = "eliminar";
                funcionEliminar();

                LimpiarCajas();
                FuncionInicio();
            }
            if (e.KeyCode == Keys.F9)
            {
                LimpiarCajas();
                FuncionInicio();
            }
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cboCodStatus.SelectedIndex = this.cboStatus.SelectedIndex;
           this.txtDescripcion.Text  = this.cboStatus.Text;
        }

        
        private void toolStripBtoGuardar_Click(object sender, EventArgs e)
        {
            funcionGuardar();
        }

        private void toolStripBtoEliminar_Click(object sender, EventArgs e)
        {
            accion = "eliminar";
            funcionEliminar();

            LimpiarCajas();
            FuncionInicio();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                FuncionBuscar();
            }
        }

        private void toolStripBtoAgregar_Click(object sender, EventArgs e)
        {
            funcionAgregar();
            accion = "agregar";
        }

        private void btoSalir_Click(object sender, EventArgs e)
        {
          // ventUsuarioPerso.cerrar();  //la otra ventana esta en .hide para ello cerrar desde aqui, y cerrar desde evento "X"
            this.Close();
           // ventana = 0;
        }

        public void AplicarIdioma()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
            //
            this.lblTituloPanel.Text = StringResources.frmUsuarioEstiloPrueba_TituloFormulario;
            //
            this.lblNombre.Text = StringResources.Nombre;
            this.lblNombe1.Text = StringResources.Nombre;
            this.lblUsuario.Text = StringResources.Usuario;
            this.lblUsuario1.Text = StringResources.Usuario;
            this.lblDescripcion.Text = StringResources.Nombre;
            //
            this.Text = StringResources.frmUsuarioEstiloPrueba_TituloFormulario;
            //
            this.btoBuscar.Text = StringResources.btnBuscar;
            this.btoSalir.Text = StringResources.btnSalir;
            //
            this.tabPage1.Text = StringResources.DetallesDeUsuario;
            this.tabPage2.Text = StringResources.PropiedadesdeUsuario;
            //
            this.toolStripBtoAgregar.Text = StringResources.btoAgregar;
            this.toolStripBtoDescartar.Text = StringResources.btoDescartar;
            this.toolStripBtoEditar.Text = StringResources.btoEditar;
            this.toolStripBtoEliminar.Text = StringResources.btoEliminar;
            this.toolStripBtoGuardar.Text = StringResources.btoGuardar;
            //
            this.toolStripBtoAgregar.ToolTipText = StringResources.btoAgregar;
            this.toolStripBtoDescartar.ToolTipText = StringResources.btoDescartar;
            this.toolStripBtoEditar.ToolTipText = StringResources.btoEditar;
            this.toolStripBtoEliminar.ToolTipText = StringResources.btoEliminar;
            this.toolStripBtoGuardar.ToolTipText = StringResources.btoGuardar;
            //
        }
    }
}
