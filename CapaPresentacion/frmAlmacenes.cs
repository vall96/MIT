using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using CultureResources;
using System.Threading;
using System.Globalization;
using CapaLogicaNegocios;


namespace CapaPresentacion
{
    public partial class frmAlmacenes : Form
    {
        public frmAlmacenes()
        {
            InitializeComponent();            
            cargar_CboEmpresa();            
            //cargar_listadoSucursales();  
           // cargar_CboSucursal();
            funcionInicio();
        }
        frmTbAlmacenes ventAlmacenes;
        //---------------------------------
        DataTable dt = new DataTable();
        DataTable dts = new DataTable();            //tabla de sucursules
        clsEmpresa Suc = new clsEmpresa();
        //-----------------------------------------------
        string estado = "";
        int pos = 0;
        DateTime fecha;
        //-------------------------------------------------------
        public string mensajeText = "", mensajeCaption = "";
        public static string tipoPais = "", nombreBd="",nombreSucursal="",codSucursal="";
        //--------------------------------------------------
        private void funcionInicio()
        {
            cboxEmpresas.Enabled = true;
          //  cboSucursales.Enabled = true;
            //----------------------------
            this.cboxEmpresas.SelectedIndex = 0;
         //   this.cboSucursales.SelectedIndex = 0;
        //    this.cboSucursales.Enabled = true;
            this.cboxEmpresas.Enabled = true;
            //--------------------------------------
            lblselectEmpresa.Visible = true;
         //   lblselectSucursal.Visible = true;
            lblMensaje.Visible = false;
            //--------------------------------------
            this.toolStripBtoAgregar.Enabled = true;
            this.toolStripBtoDescartar.Enabled = false;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoGuardar.Enabled = false;
            this.toolStripBtoEliminar.Enabled = false;
            //***Cajas************
            this.txtCodigo.Enabled = true;
            this.txtNombre.Enabled = true; 
            this.txtCod.Enabled = false;
            this.txtNom.Enabled = false;
            this.txtDescripcion.Enabled = false;
            this.txtContacto.Enabled = false;
            this.txtFechaCreacion.Enabled = false;
            this.txtTelefono1.Enabled = false;
            this.txtTelefono2.Enabled = false;
            this.lblSepador.Visible = true;
            this.cboNombreCorto.Enabled = false;

            //----------------------------------
            this.txtDireccion.Enabled = false;
            //tab2
            this.txtFechaCreacion.Enabled = false;
            this.dtimeFecha.Visible = false;
            this.dtimeFecha.Value = DateTime.Now;
        }

        private void cargar_CboEmpresa()
        {
            dt = Suc.listadoEmpresa();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["empr_Bd"].ToString().Trim()=="si")
                {
                    this.cboxEmpresas.Items.Add(dt.Rows[i]["empr_nombre"].ToString());
                    this.cboxCodEmp.Items.Add(dt.Rows[i]["empr_dni"].ToString());
                    this.cboNombreCorto.Items.Add(dt.Rows[i]["empr_nombCorto"].ToString());
                }
              
            }
        }
        private void cargar_listadoSucursales()
        {
            dts = Suc.Listado_sucursules("MITCore");       //sucursales pasar nombre corto
        }
        private void funcionAgregar()
        {
            
            estado = "agregar";
            //lblEmpresa.Visible = false;
            //lblSucursal.Visible = false;
            //--------------------------------------
            this.cboxEmpresas.Enabled = false;
           
            //---------------------------------------
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoGuardar.Enabled = true;
            this.toolStripBtoEliminar.Enabled = false;
            //***************************
            //***Cajas************
            txtCodigo.Enabled = false;
            txtNombre.Enabled = false;
            //------------------------
            this.txtCod.Enabled = false;
            this.lblMensaje.Visible = true;
            this.txtNom.Enabled = true;
            this.txtDescripcion.Enabled = true;
            this.txtContacto.Enabled = true;
            this.txtFechaCreacion.Enabled = true;
            this.txtTelefono1.Enabled = true;
            this.txtTelefono2.Enabled = true;
            this.txtDireccion.Enabled = true;
            //tab2           
            this.txtFechaCreacion.Enabled = false;
            this.dtimeFecha.Visible = true;
            this.txtNom.Focus();
          
            //tab
            this.tbControlEmpresa.SelectedIndex = 0;
        }
        private void limpiarcajas()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            //------------------------
            this.txtCod.Clear();
            this.txtNom.Clear();
            this.txtDescripcion.Clear();
            this.txtContacto.Clear();
            this.txtFechaCreacion.Clear();
            this.txtTelefono1.Clear();
            this.txtTelefono2.Clear();
            this.txtDireccion.Clear();

            //tab2
            
            this.txtFechaCreacion.Text = "";
            //tab3          
            //this.btnAgregarMoneda.Clear();
        }

        private void funcionGuardar()
        {
            if (estado == "agregar")
            {
                if (txtNom.Text == "" || txtDescripcion.Text == "" ||
                    txtDescripcion.Text == "" || txtContacto.Text == "" ||
                    txtTelefono2.Text == "" ||  txtFechaCreacion.Text == "")
                {
                    MessageBox.Show("Existen Campos vacios", "Error de Validacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string msj = "";
                    string codigoEmp = "";
                    Suc.m_emprNomb = txtNom.Text.ToString().Trim();
                    Suc.m_emprDesc = txtDescripcion.Text.ToString().Trim();
                    Suc.m_emprDir = txtDireccion.Text.ToString().Trim();
                    Suc.m_empContacto = txtContacto.Text.ToString().Trim();
                    Suc.m_emprTelf1 = txtTelefono1.Text.ToString().Trim();
                    Suc.m_emprTelf2 = txtTelefono2.Text.ToString().Trim();
                    Suc.m_emprFechaCreacion = fecha;
                    // -------------- para crear codigo--------------------
                    codigoEmp = cboxCodEmp.Text.ToString().Trim();                   
                    Suc.m_emprCodigo = Int32.Parse(codigoEmp);                   
                    //--------------------------------------------------
                    msj = Suc.registar_SucursalAlmacen(nombreBd);
                    MessageBox.Show(msj, "Validacion Exitosa",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiarcajas();
                    funcionInicio();
                    return;
                }

            }

        }
        private void toolStripBtoAgregar_Click(object sender, EventArgs e)
        {
            funcionAgregar();
        }

        private void btoSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboxEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
            this.toolStripBtoAgregar.Enabled = true;
            this.cboxCodEmp.SelectedIndex = this.cboxEmpresas.SelectedIndex;
            this.cboNombreCorto.SelectedIndex = this.cboxEmpresas.SelectedIndex;
            nombreBd = cboNombreCorto.Text;
           
        }

        private void cboxCodEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            pos= this.cboxCodEmp.SelectedIndex;
           // cargar_CboSucursal();
        }

        
        private void toolStripBtoDescartar_Click(object sender, EventArgs e)
        {
            limpiarcajas();
            funcionInicio();
        }

        private void dtimeFecha_ValueChanged(object sender, EventArgs e)
        {
            fecha = dtimeFecha.Value.Date;
            txtFechaCreacion.Text = fecha.ToString("dd/MM/yyyy");
        }

        private void toolStripBtoGuardar_Click(object sender, EventArgs e)
        {
            funcionGuardar();
        }

       
        private void frmAlmacenes_Load(object sender, EventArgs e)
        {
            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();
            this.Location = new System.Drawing.Point(0, 0);


        }

       
      
        private void toolStripBtoAgregar_Click_1(object sender, EventArgs e)
        {
            funcionAgregar();
        }

        
        private void toolStripBtoGuardar_Click_1(object sender, EventArgs e)
        {
            funcionGuardar();

        }
       
        private void frmAlmacenes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                funcionAgregar();
                //accion = "agregar";
            }
            if (e.KeyCode == Keys.F6)
            {
                // funcionEditar();
              //  accion = "editar";
            }
            if (e.KeyCode == Keys.F7)
            {
                funcionGuardar();
            }
            if (e.KeyCode == Keys.F8)
            {
               // accion = "eliminar";
               // funcionEliminar();

                funcionInicio();
                limpiarcajas();
            }
            if (e.KeyCode == Keys.F9)
            {
                funcionInicio();
                limpiarcajas();
            }
        }

        private void btnPuntos_Click(object sender, EventArgs e)
        {
            ventAlmacenes = new frmTbAlmacenes();
            ventAlmacenes.pasado += new frmTbAlmacenes.pasar(ejecutar);
            ventAlmacenes.ShowDialog();
        }

        private void toolStripBtoDescartar_Click_1(object sender, EventArgs e)
        {
            limpiarcajas();
            funcionInicio();
        }

        public void ejecutar(string[,] dato)
        {
            txtCodigo.Text = dato[0, 0];
            txtCod.Text = dato[0, 0];
            txtNom.Text = dato[0, 1];
            txtNombre.Text = dato[0, 1];
            txtDescripcion.Text = dato[0, 2];
            txtDireccion.Text = dato[0, 3];
            txtTelefono1.Text = dato[0, 5];
            txtTelefono2.Text = dato[0, 6];   //hay que cambiarlo
            txtContacto.Text = dato[0, 4];
           txtFechaCreacion.Text= dato[0, 7];
            this.toolStripBtoEditar.Enabled = true;
            this.toolStripBtoEliminar.Enabled = true;
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            this.btoBuscar.Enabled = false;
            ///--------carga de sucursales 
            cboxEmpresas.Enabled = false;
          
            //---------------------------------------------
            txtCodigo.Enabled = false;
            txtNombre.Enabled = false;
        }
        public void AplicarIdioma()
        {
            this.lblselectEmpresa.Text = StringResources.SeleccionarEmpresa;         
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
            this.lblCodigo.Text = StringResources.Codigo;
            this.lblCod.Text = StringResources.Codigo;
            this.lblContacto.Text = StringResources.Contacto;
            this.lblDescripcion.Text = StringResources.Descripcion;
            this.lblFecha2.Text = StringResources.FechaCreacion;
            this.lblMensaje.Text = StringResources.CodigoAutogenerado;
            this.lblNom.Text = StringResources.Nombre;
            this.lblNombre.Text = StringResources.Nombre;
            //this.lblRespaldos.Text = StringResources.UbicacionRespaldos;
            this.lblTelefono.Text = StringResources.Telefonos;
            this.lbldireccion.Text = StringResources.Direccion;
            this.lblNombreCorto.Text = StringResources.lblNombeDosPuntos;
            //
            this.Text = StringResources.Almacenes;
            this.lblTituloPanel.Text = StringResources.Almacenes;
            //
            this.tabPage1.Text = StringResources.Informaciongeneral;
            this.tabPage2.Text = StringResources.PropiedadesdeAlmacen;
            //
            this.btoBuscar.Text = StringResources.btnBuscar;
            this.btoSalir.Text = StringResources.btnSalir;
            //
            this.lblRespaldos.Text = StringResources.UbicacionRespaldos;
            //
        }
    }
}
