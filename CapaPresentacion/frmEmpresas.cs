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
using System.Diagnostics;

namespace CapaPresentacion
{
    public partial class frmEmpresas : Form
    {
        clsEmpresa Emp = new clsEmpresa();
        //
        DateTime fecha;
        DataTable dt = new DataTable();
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        int a, tab = 0,j=0, codEmp, codMon;
        public static string activarChek = "", accion = "";
        string estado = "", moneda = "", codMoneda;
        public static int b = 0, statusLsv;
        //----------------------------------------------------------------------------
        public string mensajeText = "", sucursal = "", mensajeCaption = "";
        public static string tipoPais = "";
        public static string[,] codMonAsociados;
        DataTable dts = new DataTable();            //tabla de sucursules
        DataTable dta = new DataTable();
        DataTable dtm= new DataTable();
        DataTable dtem = new DataTable();           //relacion empMoneda
        clsEmpresa Suc = new clsEmpresa();
        ListViewItem lvrow;
        //---------------------------------------------------------------------------

        frmTbEmpresas ventTbEmpresas;
        frmMoneda ventMoneda;

        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        public frmEmpresas()
        {
            InitializeComponent();
            funcionInicio();
            cargar_CboMoneda();
            cargar_MonedasAsociadas();
            //cargar_listadoSucursales();
            // cargar_listadoAlmacenes();
        }
        private void funcionInicio()
        {
            lstvMoneda.Items.Clear(); //aqui
            lstvMoneda.Visible = false;
            tab = 0;
            this.txtNombreBd.Enabled = false;
            this.toolStripBtoAgregar.Enabled = true;
            this.toolStripBtoDescartar.Enabled = false;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoGuardar.Enabled = false;
            this.toolStripBtoEliminar.Enabled = false;
            this.btnPuntos.Enabled = true;
            //***Cajas************
            txtCodigo.Enabled = true;
            txtNombre.Enabled = true;
            lblMensaje.Visible = false;
            lblNombBd.Visible = false;
            //-------------------------
            this.txtCod.Enabled = false;
            this.txtNom.Enabled = false;
            this.txtDescripcion.Enabled = false;
            this.txtContacto.Enabled = false;
            this.txtFechaCreacion.Enabled = false;
            this.txtTelefono1.Enabled = false;
            this.txtTelefono2.Enabled = false;
            this.lblSepador.Visible = true;
            this.txtDireccion.Enabled = false;
            //tab2
            this.txtRIF.Enabled = false;
            this.cboxMoneda.Enabled = false;
            this.txtEmail.Enabled = false;
            this.txtPagWeb.Enabled = false;
            this.txtFechaCreacion.Enabled = false;
            this.dtimeFecha.Visible = false;
            this.cboSimbolo.Enabled = false;
            ckbMon.Checked = false;
            this.lblSeleccionMoneda.Visible = false;
            this.btnMoneda.Visible = false;
            this.txtNIT.Enabled = false;
            this.ckbMon.Enabled = false;
            //tab3
            this.dtimeFecha.Value = DateTime.Now;
            this.tbControlEmpresa.TabPages.Remove(tPagSucursales);    //aqui
            this.tbControlEmpresa.TabPages.Remove(tabPAlmacen);

            this.cboxMoneda.Visible = true;
            this.cboSimbolo.Visible = true;
            this.ckbMon.Visible = false;
            this.lblmultimoneda.Visible = false;
            
        }

        private void funcionAgregar()
        {
            codMonAsociados = new string[1, dt.Rows.Count];
            estado = "agregar";
            this.txtNombreBd.Enabled = true;
            //**********************************************
            this.lblNombBd.Visible = true;
            this.txtNombreBd.Enabled = true;
            //----------------------------------------------
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoGuardar.Enabled = true;
            this.toolStripBtoEliminar.Enabled = false;
            //*************************************************************************
            this.cboxMoneda.SelectedIndex = 4;
            this.btnPuntos.Enabled = false;

            //*************Cajas*******************************************************
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
            this.txtRIF.Enabled = true;
            this.cboxMoneda.Enabled = true;
            this.txtEmail.Enabled = true;
            this.txtPagWeb.Enabled = true;
            this.txtFechaCreacion.Enabled = false;
            this.dtimeFecha.Visible = true;
            this.txtNIT.Enabled = true;
            //tab3
            this.txtNombreBd.Focus();

            this.cboxMoneda.Visible = true;
            this.cboSimbolo.Visible = true;
            this.ckbMon.Visible = true;
            this.ckbMon.Enabled = true;
            this.lblmultimoneda.Visible = true;
            //tab
            this.tbControlEmpresa.SelectedIndex = 0;
        }
        private void funcionEditar()
        {
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoGuardar.Enabled = true;
            this.toolStripBtoEliminar.Enabled = false;

            //***Cajas************
            txtCodigo.Enabled = false;
            txtNombre.Enabled = false;
            //------------------------
            this.txtCod.Enabled = false;
            this.txtNom.Enabled = true;
            this.txtDescripcion.Enabled = true;
            this.txtContacto.Enabled = true;
            this.txtFechaCreacion.Enabled = true;
            this.txtTelefono1.Enabled = true;
            this.txtTelefono2.Enabled = true;
            //tab2
            this.txtRIF.Enabled = true;
            this.cboxMoneda.Enabled = true;
            this.txtEmail.Enabled = true;
            this.txtPagWeb.Enabled = true;
            this.txtFechaCreacion.Enabled = false;
            this.dtimeFecha.Visible = true;
            this.btnMoneda.Enabled = true;
            //tab3
            this.btnMoneda.Enabled = true;
            this.txtNom.Focus();
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
            this.txtNombreBd.Clear();

            //tab2
            this.txtRIF.Clear();
            this.txtEmail.Clear();
            this.txtPagWeb.Clear();
            this.txtFechaCreacion.Clear();
            this.cboSimbolo.Text = "";
            this.cboxMoneda.Text = "";
            this.txtFechaCreacion.Text = "";
            this.txtNIT.Text = "";

            this.lstvSucursales.Items.Clear();
            //tab3
            //     this.txtSucursales.Clear();
            //    this.txtAlmacenes.Clear();
            //this.btnAgregarMoneda.Clear();
            for (int i = 0; i == b; i++)
            {
                codMonAsociados[0, i] = null;
            }
            b = 0;
        }
       
        private void funcionGuardar()
        {
            if (estado == "agregar")
            {
                if (txtNombreBd.Text == "" || txtNom.Text == "" || txtDescripcion.Text == "" ||
                    txtDescripcion.Text == "" || txtContacto.Text == "" ||
                    txtTelefono2.Text == "" || txtRIF.Text == "" ||
                    txtEmail.Text == "" || txtPagWeb.Text == "" || txtFechaCreacion.Text == "")
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    mensajeText = StringResources.ExistenCamposVacios;
                    mensajeCaption = StringResources.ErrordeValidacion;

                    MessageBox.Show(mensajeText, mensajeCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                    //MessageBox.Show("Existen Campos vacios", "Error de Validacion",
                    //MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
                else
                {
                    string msj = "";
                    Emp.m_emprNombCorto = txtNombreBd.Text.ToString().Trim();
                    Emp.m_emprNomb = txtNom.Text.ToString().Trim();
                    Emp.m_emprDesc = txtDescripcion.Text.ToString().Trim();
                    Emp.m_emprDir = txtDireccion.Text.ToString().Trim();
                    Emp.m_empContacto = txtContacto.Text.ToString().Trim();
                    Emp.m_emprTelf1 = txtTelefono1.Text.ToString().Trim();
                    Emp.m_emprTelf2 = txtTelefono2.Text.ToString().Trim();
                    //------------------------------------------------------------
                    Emp.m_emprRif = txtRIF.Text.ToString().Trim();
                    //pasamos los codmoneda a int
                    moneda = cboCodMoneda.Text.ToString().Trim();
                    Emp.m_emprMoneda = Int32.Parse(moneda);
                    Emp.m_emprEmail = txtEmail.Text.ToString().Trim();
                    Emp.m_emprWeb = txtPagWeb.Text.ToString().Trim();
                    Emp.m_emprFechaCreacion = fecha;
                    Emp.m_emprNit = txtNIT.Text.ToString().Trim();
                    msj = Emp.registar_empresa();
                    codEmp =Int32.Parse(Emp.codEmp);
                    MonSelecionadas();
                    Emp.registar_moneda(dtm, "MITCore");
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    mensajeCaption = StringResources.ValidacionExitosa;
                    if (msj == "Registro exitoso")
                    {
                        msj = StringResources.DBRegistroexitoso;
                        MessageBox.Show(msj, mensajeCaption,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    limpiarcajas();
                    funcionInicio();
                    return;
                }
            }
        }

       private void contrunccionDtMonedas()
        {
            dtm.Columns.Add("EmpM_codEmp", Type.GetType("System.Int32"));
            dtm.Columns.Add("EmpM_codMon", Type.GetType("System.Int32"));
        }

        private void cargarDtMonedas()
        {
            dtm.Rows.Add();
            dtm.Rows[j]["EmpM_codEmp"] = codEmp;
            dtm.Rows[j]["EmpM_codMon"] = codMon;

        }
        private void MonSelecionadas()
        {
            contrunccionDtMonedas();
           // codEmp =Int32.Parse(txtCodigo.Text);
            if (ckbMon.Checked==false)
            {
                codMon = Int32.Parse(cboCodMoneda.Text);
                cargarDtMonedas();
            }
            else
            {
                for (int i=0; i<lstvMoneda.Items.Count;i++)
                {
                    codMon = Int32.Parse(lstvMoneda.Items[i].SubItems[0].Text.ToString());
                    cargarDtMonedas();
                    j++;
                }
            }
        }
        private void cargar_CboMoneda()
        {
            dt = Emp.Listado_monedas();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.cboxMoneda.Items.Add(dt.Rows[i]["mon_cod"].ToString());
                this.cboCodMoneda.Items.Add(dt.Rows[i]["mon_codID"].ToString());
                this.cboSimbolo.Items.Add(dt.Rows[i]["mon_simbolo"].ToString());
            }
        }

        private void buscar_Moneda()
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (codMoneda == dt.Rows[i]["mon_codID"].ToString())
                {
                    this.cboxMoneda.SelectedIndex = i;
                    this.cboxMoneda.SelectedIndex = i;
                }
            }
        }
        private void cargar_listadoSucursales()
        {
            dts = Suc.Listado_sucursules(txtNombreBd.Text);       //sucursales
           // lstvSucursales.Items.Clear();                 //aqui
            for (int i = 0; i < dts.Rows.Count; i++)
          
            {
                lvrow = new ListViewItem(dts.Rows[i]["suc_cod"].ToString());
                lvrow.SubItems.Add(dts.Rows[i]["suc_nombre"].ToString());
                lvrow.SubItems.Add(dts.Rows[i]["suc_dir"].ToString());
                lvrow.SubItems.Add(dts.Rows[i]["suc_contacto"].ToString());
                this.lstvSucursales.Items.Add(lvrow); 
            }
        }
        private void cargar_MonedasAsociadas()
        {
            dtem = Suc.Listado_EmpMonedas();
        }
       
        private void cargar_listadoAlmacenes()
        {
            dta = Suc.Listado_Almacenes(txtNombreBd.Text);       //almacenes
            for (int a = 0; a < dta.Rows.Count; a++)
            {
                lvrow = new ListViewItem(dta.Rows[a]["alm_cod"].ToString());
                lvrow.SubItems.Add(dta.Rows[a]["alm_nombre"].ToString());
                lvrow.SubItems.Add(dta.Rows[a]["alm_dir"].ToString());
                this.lsvAlmacenes.Items.Add(lvrow);
            }
           
        }
        private void cargar_lsvMonAsoc()
        {
            int cont = 0;
            codMonAsociados = new string[1, dt.Rows.Count];
            lstvMoneda.Items.Clear();
            if (dtem.Rows.Count==0)
            {
               // lblSinmonedas.Visible = true;
               // lblSinmonedas.Text = txtNombre.Text + " No posee monedas asociados";
            }
            else
            {
               this.lstvMoneda.Visible = true;
                
                b = 0;
                for (int i = 0; i < dtem.Rows.Count; i++)
                {
                    if (txtCodigo.Text== dtem.Rows[i]["EmpM_codEmp"].ToString())
                    {
                        cont++;
                        moneda = dtem.Rows[i]["EmpM_codMon"].ToString();
                        for (int a = 0; a < dt.Rows.Count; a++)
                        {
                            if (moneda== dt.Rows[a]["mon_codID"].ToString())
                            {
                                codMonAsociados[0, b] = dt.Rows[a]["mon_codID"].ToString();
                                lvrow = new ListViewItem(dt.Rows[a]["mon_codID"].ToString());
                                lvrow.SubItems.Add(dt.Rows[a]["mon_cod"].ToString());
                                lvrow.SubItems.Add(dt.Rows[a]["mon_Descripcion"].ToString());
                                lvrow.SubItems.Add(dt.Rows[a]["mon_simbolo"].ToString());
                                this.lstvMoneda.Items.Add(lvrow);
                                b++;
                            }
                            
                        }
                    }
                }
            }
            if(lstvMoneda.Items.Count>1)
            {
                lblmultimoneda.Visible = true;                
                ckbMon.Visible = true;
                ckbMon.Checked = true;
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
        private void buscarAlmaneces()
        {
         //   lsvAlmacenes.Items.Clear();            
            for (int a = 0; a < dta.Rows.Count; a++)
            {
                if (sucursal == dta.Rows[a]["alm_succod"].ToString())
                {
                   lvrow = new ListViewItem(dta.Rows[a]["alm_cod"].ToString());
                   lvrow.SubItems.Add(dta.Rows[a]["alm_nombre"].ToString());
                   lvrow.SubItems.Add(dta.Rows[a]["alm_dir"].ToString());
                   lvrow.SubItems.Add(dta.Rows[a]["alm_contacto"].ToString());
                 //  this.lsvAlmacenes.Items.Add(lvrow);   //aqui
                }
            }
            this.tbControlEmpresa.SelectedIndex = 4;
            return;     
        }

        private void toolStripBtoDescartar_Click(object sender, EventArgs e)
        {           
            funcionInicio();
            limpiarcajas();
        }

        private void frmEmpresas_Load(object sender, EventArgs e)
        {
            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();
            lstvMoneda.OwnerDraw = true;
            lstvSucursales.OwnerDraw = true;  //aqui           
            lsvAlmacenes.OwnerDraw = true;
            this.Location = new System.Drawing.Point(0, 0);
        }

        private void btnPuntos_Click(object sender, EventArgs e)
        {
            ventTbEmpresas = new frmTbEmpresas();
            ventTbEmpresas.pasado += new frmTbEmpresas.pasar(ejecutar);
            //ventTbEmpresas.pasado += new frmTbUsuarioPersonalizada.pasar(ejecutar);
            ventTbEmpresas.ShowDialog();
        }

        public void ejecutar(string[,] dato)
        {
            txtCodigo.Text = dato[0, 0];
            txtCod.Text = dato[0, 0];
            txtNom.Text = dato[0, 1];
            txtNombre.Text = dato[0, 1];
            txtDescripcion.Text = dato[0, 9];
            txtDireccion.Text = dato[0, 3];
            txtTelefono1.Text = dato[0, 5];
            txtTelefono2.Text = dato[0, 5];   //hay que cambiarlo
            txtContacto.Text = dato[0, 10];
            txtRIF.Text = dato[0, 2];
            txtNIT.Text = dato[0, 4];
            txtEmail.Text = dato[0, 6];
            txtPagWeb.Text = dato[0, 7];
            txtFechaCreacion.Text = dato[0, 8];
            txtNombreBd.Text = dato[0, 12];
            // cboxMoneda.Text= dato[0, 11];
            codMoneda = dato[0, 11];           
            this.toolStripBtoEditar.Enabled = true;
            this.toolStripBtoEliminar.Enabled = true;
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            this.btoBuscar.Enabled = false;
            this.cboxMoneda.Visible = false;
            this.ckbMon.Visible = false;
            this.lblmultimoneda.Visible = false;
            this.cboSimbolo.Visible = false;
            this.lblMoneda.Visible = true;
            cargar_lsvMonAsoc();
            if (frmTbEmpresas.existeBd=="si")
            {
                ///--------carga de sucursales 
                cargar_listadoSucursales();
                cargar_listadoAlmacenes();
                //------------Habilitar tab----------------
                if (tab == 0)
                {
                    this.tbControlEmpresa.TabPages.Add(tabPAlmacen); //aqui
                    this.tbControlEmpresa.TabPages.Add(tPagSucursales);
                    tab++;
                }
            }
            else
            {

                if (tab > 0)
                {
                    this.lsvAlmacenes.Items.Clear();
                    this.lstvSucursales.Items.Clear();
                    this.tbControlEmpresa.TabPages.Remove(tabPAlmacen); //aqui
                    this.tbControlEmpresa.TabPages.Remove(tPagSucursales);
                }
            }
            //---------------------------------------------
            txtCodigo.Enabled = false;
            txtNombre.Enabled = false;
        }
        private void datosSeleccionados()
        {
         //   if (lstvSucursales.SelectedItems.Count > 0) //aqui
            {
          //      sucursal = lstvSucursales.SelectedItems[0].Text;
            }
        }
        
        private void toolStripBtoEliminar_Click(object sender, EventArgs e)
        {
            accion = "eliminar";
            //funcionEliminar();
        }

       
        private void lsvAlmacenes_DrawItem(object sender, DrawListViewItemEventArgs e)
        {            
           e.DrawDefault = true;
        }

        private void lstvSucursales_DoubleClick_1(object sender, EventArgs e)
        {
            datosSeleccionados();
            buscarAlmaneces();
        }
       
        private void cboxMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            a = cboCodMoneda.SelectedIndex;
            this.cboCodMoneda.SelectedIndex = this.cboxMoneda.SelectedIndex;
            cboSimbolo.SelectedIndex = this.cboxMoneda.SelectedIndex;
        }

        private void ckbMon_Click(object sender, EventArgs e)
        {
            if (ckbMon.Checked == true)
            {
                btnMoneda.Enabled = true;
                this.lblSeleccionMoneda.Visible = true;
                this.btnMoneda.Visible = true;
                this.cboxMoneda.Enabled = false;
                this.cboxMoneda.Text = "";
                this.cboSimbolo.Text = "";
                this.lstvMoneda.Visible = true;
            }
            else
            {
                btnMoneda.Enabled = false;
                this.lblSeleccionMoneda.Visible = false;
                this.btnMoneda.Visible = false;
                this.cboxMoneda.Enabled = true;
                this.lstvMoneda.Visible = false;
            }
        }

        private void dtimeFecha_ValueChanged(object sender, EventArgs e)
        {
            fecha = dtimeFecha.Value.Date;
            txtFechaCreacion.Text = fecha.ToString("dd/MM/yyyy");
        }

        private void lstvMoneda_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.DarkOrange, e.Bounds);
            e.DrawText();
        }

        private void lsvAlmacenes_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.DarkOrange, e.Bounds);
            e.DrawText();
        }

        private void lsvAlmacenes_DrawItem_1(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lstvSucursales_DrawItem_1(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lstvSucursales_DrawColumnHeader_1(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.DarkOrange, e.Bounds);
            e.DrawText();
        }

        private void lstvMoneda_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void btnMoneda_Click(object sender, EventArgs e)
        {
            statusLsv = lstvMoneda.Items.Count;
            activarChek = "activar";
            ventMoneda = new frmMoneda();
            ventMoneda.MonAsociados += new frmMoneda.relacion(relacionMon);
            ventMoneda.ShowDialog();
        }


        public void relacionMon(DataTable dtMon)
        {
            this.lstvMoneda.Visible = true;
            for (int a = 0; a < dtMon.Rows.Count; a++)
            {
                codMonAsociados[0, b] = dtMon.Rows[a]["codMon"].ToString();
                lvrow = new ListViewItem(dtMon.Rows[a]["codMon"].ToString());
                lvrow.SubItems.Add(dtMon.Rows[a]["codigo"].ToString());
                lvrow.SubItems.Add(dtMon.Rows[a]["descripcion"].ToString());
                lvrow.SubItems.Add(dtMon.Rows[a]["simbolo"].ToString());
                this.lstvMoneda.Items.Add(lvrow);
                b++;
            }
            
        }

        private void frmEmpresas_KeyDown(object sender, KeyEventArgs e)
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
                //funcionEliminar();

                funcionInicio();
                limpiarcajas();
            }
            if (e.KeyCode == Keys.F9)
            {
                funcionInicio();
                limpiarcajas();
            }
        }

      
        private void txtNombreBd_KeyPress(object sender, KeyPressEventArgs e)
        {           
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || (e.KeyChar >= 97 && e.KeyChar <= 122) || (e.KeyChar >= 65 && e.KeyChar <= 90) )
            {
                e.Handled =false;               
            }
            else
            {
                e.Handled = true;
            }
            if (e.KeyChar==08)
            {
                e.Handled = false;
            }            
        }
     
        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (ckbMon.Checked == true)
            {
                btnMoneda.Enabled = true;
                this.lblSeleccionMoneda.Visible = true;
                this.btnMoneda.Visible = true;
                this.cboxMoneda.Enabled = false;
                this.cboxMoneda.Text = "";
                this.cboSimbolo.Text = "";
            }
            else
            {
                btnMoneda.Enabled = false;
                this.lblSeleccionMoneda.Visible = false;
                this.btnMoneda.Visible = false;
                this.cboxMoneda.Enabled = true;
            }
        }

        private void toolStripBtoGuardar_Click(object sender, EventArgs e)
        {
            funcionGuardar();
        }

  
        public void AplicarIdioma()
        {
            this.lblCod.Text = StringResources.Codigo;
            this.lblCodigo.Text = StringResources.Codigo;
            //
            this.lblContacto.Text = StringResources.Contacto;
            //
            this.lblDescripcion.Text = StringResources.Descripcion;
            this.lblDireccion.Text = StringResources.Direccion;
            this.lblEmail.Text = StringResources.email;
            this.lblFecha2.Text = StringResources.FechaCreacion;
            this.lblMensaje.Text = StringResources.CodigoAutogenerado;
            this.lblMoneda.Text = StringResources.moneda;
            this.lblNit.Text = StringResources.NIT;
            this.lblNom.Text = StringResources.Nombre;
            this.lblNombre.Text = StringResources.Nombre;
            this.lblPagWeb.Text = StringResources.Pagweb;
            this.lblReportes.Text = StringResources.UbicacionReportes;
            this.lblRespaldos.Text = StringResources.UbicacionRespaldos;
            this.lblRIF.Text = StringResources.RIF;
            this.lblSeleccionMoneda.Text = StringResources.SeleccionelasMonedas;
            this.lblTelefono.Text = StringResources.Telefonos;
            this.lblNombreBD.Text = StringResources.Nombre;
          //  this.lblMensajeBD.Text = StringResources.frmEmpresas_lblMensajeBD;
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
            this.lblTituloPanel.Text = StringResources.frmEmpresa_TituloPanel;
            //
            this.Text = StringResources.Empresa;
            //
            this.tabPage1.Text = StringResources.Informaciongeneral;
            this.tabPage2.Text = StringResources.frmEmpresa_TabPropiedadesEmpresa;
            this.tPagSucursales.Text = StringResources.Sucursales;
            this.tabPAlmacen.Text = StringResources.Almacenes;
            this.tbPgMonedas.Text = StringResources.frmMonedas_Monedas;
            //
            this.lblmultimoneda.Text = StringResources.Multimoneda;
            this.lblEmail.Text = StringResources.email;
            this.lblNit.Text = StringResources.NIT;
            // 
            btoBuscar.Text = StringResources.btnBuscar;
            btoSalir.Text = StringResources.btnSalir;

            //listview Mon
            this.colCodigoMon.Text= StringResources.Codigo;
            this.ColDescripc.Text = StringResources.Descripcion;
            this.Colsimbolo.Text = StringResources.frmMonedas_Simbolo;
            this.ColCodigoIso.Text = StringResources.frmMonedas_CodIso;

            //listvew sucursal
           this.colCodigo.Text= StringResources.Codigo;
            this.colDescripcion.Text= StringResources.Descripcion;
           this.colNombre.Text = StringResources.Nombre;
            // listiew DtAlmacenes
           this.ColNombreAlm.Text= StringResources.Nombre;
          this.ColDescripcionAlm.Text= StringResources.Descripcion;
           this.ColCodigoAlm.Text= StringResources.Codigo;
        }

    }
}
