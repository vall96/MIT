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
using System.Configuration;
namespace CapaPresentacion
{
    public partial class frmSucursales : Form
    {
        public frmSucursales()
        {
            InitializeComponent();
            this.cboNombreCorto.Enabled = false;
            cargar_CboEmpresa();
            funcionInicio();
           // cargar_CboMoneda();
            cargar_MonedasAsociadasSuc();
        }
        DataTable dt = new DataTable();
        public static DataTable dtrm = new DataTable();  //relacion con monedas guaradadas en empresa, MITCore (para agregar)
        public static DataTable dtrmR= new DataTable();  //relacion con monedas guaradadas en sucursal (para editar o para ver)
        int j = 0,codMone,codSuc,pos,count=0;
        DateTime fecha;
        clsEmpresa Suc = new clsEmpresa();
        string estado = "",emp="",existeBD="";
        ListViewItem lvrow;
        public static string[,] codMonAsociados;
        public string mensajeText = "", mensajeCaption = "";
        public static string tipoPais = "", accion = "", emprBD = "",
                                    nombreBd,nomCompleto="",codEmp,
                                    codMon,formSucursales;
        public static int b = 0, statusLsvSuc=0;
        DataTable dts = new DataTable();
        DataTable dte = new DataTable();
        DataTable dtm = new DataTable();
        frmMoneda ventMoneda;
        frmTbSucursales ventSucursales;
        private void funcionPincipal()          //antes dee que elija una empresa, luego si funcion de inicio
        {
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = false;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoGuardar.Enabled = false;
            this.toolStripBtoEliminar.Enabled = false;
            txtCodigo.Enabled = false;
            txtNombre.Enabled = false;
        }
        private void funcionInicio()
        {
            dtrm = Suc.Listado_EmpMonedas();
            this.cboxEmpresas.SelectedIndex = 0;
            this.lblNohaySucursales.Visible = false;
            this.toolStripBtoAgregar.Enabled = true;
            this.toolStripBtoDescartar.Enabled = false;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoGuardar.Enabled = false;
            this.toolStripBtoEliminar.Enabled = false;
            //****************************************
            
            this.cboxEmpresas.Enabled = true;
           // this.cboxEmpresas.SelectedIndex = 4;
            this.btnPuntos.Enabled = true;
            //***Cajas************
            txtCodigo.Enabled = true;
            txtNombre.Enabled = true;
            lblMensaje.Visible = false;
            this.lblMoneda.Text = StringResources.moneda;
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
           // this.txtRIF.Enabled = false;
            this.cboxMoneda.Enabled = false;
            this.txtEmail.Enabled = false;
            this.txtFax.Enabled = false;
           // this.txtPagWeb.Enabled = false;
            //  this.txtCodigoMoneda.Enabled = false;
            //  this.txtMoneda.Enabled = false;
            this.txtFechaCreacion.Enabled = false;
            this.dtimeFecha.Visible = false;
            this.cboSimbolo.Enabled = false;
            ckbMon.Checked = false;
            //this.txtReportes.Enabled = false;
            //this.txtRespaldos.Enabled = false;
            // this.txtSimboloMoneda.Enabled = false;
            //this.btnMoneda.Enabled = false;
            this.lblSeleccionMoneda.Visible = false;
            this.btnMoneda.Visible = false;
           // this.txtNIT.Enabled = false;
            this.ckbMon.Enabled = false;
            //tab3
           // this.txtSucursales.Enabled = false;
         //   this.txtAlmacenes.Enabled = false;
            this.dtimeFecha.Value = DateTime.Now;

        }

        private void MonSelecionadas()
        {
           // codSuc = Int32.Parse(txtCod.Text);
            contrunccionDtMonedas();
            if (ckbMon.Checked == false)
            {
                codMone = Int32.Parse(cboCodMoneda.Text);
                cargarDtMonedas();
            }
            else
            {
                for (int i = 0; i < lstvMoneda.Items.Count; i++)
                {
                    codMone = Int32.Parse(lstvMoneda.Items[i].SubItems[0].Text.ToString());
                    cargarDtMonedas();
                    j++;
                }
            }
        }
        private void cargarDtMonedas()
        {

            dtm.Rows.Add();
            dtm.Rows[j]["SucMon_codSuc"] = codSuc;
            dtm.Rows[j]["SucMon_codMon"] = codMone;

        }
        private void contrunccionDtMonedas()
        {
            dtm.Columns.Add("SucMon_codSuc", Type.GetType("System.Int32"));
            dtm.Columns.Add("SucMon_codMon", Type.GetType("System.Int32"));
           
        }

        private void cargar_CboEmpresa()
        {
         //  int a=0;
            dte = Suc.listadoEmpresa();
            for (int i = 0; i < dte.Rows.Count; i++)
            {
                this.cboxEmpresas.Items.Add(dte.Rows[i]["empr_nombre"].ToString());
                this.cboxCodEmp.Items.Add(dte.Rows[i]["empr_dni"].ToString());
                this.cboNombreCorto.Items.Add(dte.Rows[i]["empr_nombCorto"].ToString());               
            }
            //emprBD = dt.Rows[i]["empr_nombCorto"].ToString();
        }

        private void cboxEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblNohaySucursales.Visible = false;
            this.cboxCodEmp.SelectedIndex = this.cboxEmpresas.SelectedIndex;            
            this.cboNombreCorto.SelectedIndex = this.cboxEmpresas.SelectedIndex;
            nombreBd = cboNombreCorto.Text;
            nomCompleto = cboxEmpresas.Text;           
        }

      
        private void funcionAgregar()
        {
            cargar_CboMoneda();
            codMonAsociados = new string[1, 6];
           estado = "agregar";
            //**************************************
            this.cboxEmpresas.Enabled = false;
            this.cboxMoneda.SelectedIndex = 0;
            //--------------------------------------------       
            this.btnPuntos.Enabled = false;
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
            this.lblMensaje.Visible = true;
            this.txtNom.Enabled = true;
            this.txtDescripcion.Enabled = true;
            this.txtContacto.Enabled = true;
            this.txtFechaCreacion.Enabled = true;
            this.txtTelefono1.Enabled = true;
            this.txtTelefono2.Enabled = true;
            this.txtDireccion.Enabled = true;
            //tab2          
            this.cboxMoneda.Enabled = true;
            this.txtEmail.Enabled = true;
            this.txtFax.Enabled = true;           
            this.txtFechaCreacion.Enabled = false;
            this.dtimeFecha.Visible = true;
           //      
            this.txtNom.Focus();
            // this.btnMoneda.Enabled = true;
            this.ckbMon.Enabled = true;
            //tab
            this.tbControlEmpresa.SelectedIndex = 0;
            //----------------
            this.cboxMoneda.Visible = true;
            this.cboSimbolo.Visible = true;
            this.ckbMon.Visible = true;
            this.ckbMon.Enabled = true;
            this.lblmultimoneda.Visible = true;
        }

        private void dtimeFecha_ValueChanged(object sender, EventArgs e)
        {
            fecha = dtimeFecha.Value.Date;
            txtFechaCreacion.Text = fecha.ToString("dd/MM/yyyy");
        }

       
        private void cargar_CboMoneda()
        {
            this.cboxMoneda.Items.Clear();         
           
            for (int i = 0; i < frmSucursales.dtrm.Rows.Count; i++)
            {
                if (codEmp == dtrm.Rows[i]["EmpM_codEmp"].ToString())
                {
                    codMon = dtrm.Rows[i]["EmpM_codMon"].ToString();
                    for (int a = 0; a < dt.Rows.Count; a++)
                    {
                        if (codMon == dt.Rows[a]["mon_codID"].ToString())
                        {
                            this.cboxMoneda.Items.Add(dt.Rows[a]["mon_cod"].ToString());
                            this.cboCodMoneda.Items.Add(dt.Rows[a]["mon_codID"].ToString());
                            this.cboSimbolo.Items.Add(dt.Rows[a]["mon_simbolo"].ToString());
                            this.cboxMoneda.SelectedIndex = 0;
                        }
                    }
                }
            }

        }

        private void toolStripBtoDescartar_Click(object sender, EventArgs e)
        {
            funcionInicio();
            limpiarcajas();
        }
        private void toolStripBtoGuardar_Click(object sender, EventArgs e)
        {
            funcionGuardar();
        }
        
        private void frmSucursales_Load(object sender, EventArgs e)
        {
            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();
            this.lstvMoneda.OwnerDraw = true;
            this.Location = new System.Drawing.Point(0, 0);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            funcionBuscarBd();
            funcionAgregar();
            cargar_CboMoneda();
        }

        private void toolStripBtoEditar_Click(object sender, EventArgs e)
        {
           // funcionGuardar();
        }

        private void toolStripBtoGuardar_Click_1(object sender, EventArgs e)
        {
            funcionGuardar();
        }

        private void toolStripBtoEliminar_Click(object sender, EventArgs e)
        {
            accion = "eliminar";
            funcionEliminar();

            limpiarcajas();
            funcionInicio();
        }

        private void toolStripBtoDescartar_Click_1(object sender, EventArgs e)
        {
            limpiarcajas();
            funcionInicio();
        }

        private void cboxMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cboCodMoneda.SelectedIndex = this.cboxMoneda.SelectedIndex;
            cboSimbolo.SelectedIndex = this.cboxMoneda.SelectedIndex;
        }

        private void btnMoneda_Click(object sender, EventArgs e)
        {
            formSucursales = "activo";
             statusLsvSuc = lstvMoneda.Items.Count;   //para prueba pendiente(caambiar)
            frmEmpresas.activarChek = "activar";
            ventMoneda = new frmMoneda();
            ventMoneda.MonAsociados += new frmMoneda.relacion(relacionMon);
            ventMoneda.ShowDialog();
        }

        public void relacionMon(DataTable dtMon)
        {
           // this.cboxMoneda.Items.Clear();
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
                //this.cboxMoneda.Items.Add(dt.Rows[a]["mon_cod"].ToString());
                //this.cboCodMoneda.Items.Add(dt.Rows[a]["mon_codID"].ToString());
                //this.cboSimbolo.Items.Add(dt.Rows[a]["mon_simbolo"].ToString());
            }

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
                lstvMoneda.Visible = true;
            }
            else
            {
                btnMoneda.Enabled = false;
                this.lblSeleccionMoneda.Visible = false;
                this.btnMoneda.Visible = false;
                this.cboxMoneda.Enabled = true;
                lstvMoneda.Visible = false;
            }
        }
        private void btnPuntos_Click(object sender, EventArgs e)
        {
            funcionBuscarBd();
            this.lblMoneda.Text = StringResources.moneda;
            if (existeBD == "no")
            {
                this.lblNohaySucursales.Visible = true;
                this.lblNohaySucursales.Text = this.cboNombreCorto.Text + " " + StringResources.Nohaysucursal;
                ;
            }
            else if (existeBD == "si")
            {
                ventSucursales = new frmTbSucursales();
                ventSucursales.pasado += new frmTbSucursales.pasar(ejecutar);
                if (frmTbSucursales.Sucursales == 0)
                {
                    this.lblNohaySucursales.Visible = true;
                    this.lblNohaySucursales.Text = this.cboNombreCorto.Text + " " + StringResources.Nohaysucursal;
                }
                else
                {
                    ventSucursales.ShowDialog();
                    // ventSucursales.Show();
                }
            }
        }
        public void ejecutar(string[,] dato)
        {
            txtCodigo.Text = dato[0, 0];
            txtCod.Text = dato[0, 0];
            txtNombre.Text = dato[0, 1];
            txtNom.Text = dato[0, 1];
            txtDescripcion.Text = dato[0, 2];
            txtDireccion.Text = dato[0, 3];
            txtContacto.Text = dato[0, 4];
            txtTelefono1.Text = dato[0, 5];
            txtTelefono2.Text = dato[0, 6];
            txtEmail.Text = dato[0, 8];
            txtFechaCreacion.Text = dato[0, 9];

            this.toolStripBtoEditar.Enabled = true;
            this.toolStripBtoEliminar.Enabled = true;
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            this.cboxMoneda.Visible = false;
            this.ckbMon.Visible = false;
            this.lblmultimoneda.Visible = false;
            this.cboSimbolo.Visible = false;
            this.lblMoneda.Visible = true;
            buscarMonAsociadas();

        }
        private void lstvMoneda_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lstvMoneda_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (lstvMoneda.CheckedItems.Count > 0)
            {
                this.btoEliminar.Visible = true;
            }
            else
            {
                this.btoEliminar.Visible = false;
            }
        }

        private void btoEliminar_Click(object sender, EventArgs e)
        {
            if (count==0)   //controlar que solo se contruya una vez
            {
                contrunccionDtMonedas();
                count++;
            }
           
            j = 0;
            if (this.lstvMoneda.CheckedItems.Count > 0)
            {
                for (int i = pos; i < lstvMoneda.Items.Count; i++)
                {
                    if (lstvMoneda.Items[i].Checked == true)
                    {
                        codMon= lstvMoneda.Items[i].SubItems[0].Text.ToString();
                        actualizarArray();
                        lstvMoneda.Items.RemoveAt(i);
                        i--;
                    }
                }

            }
            if (this.lstvMoneda.CheckedItems.Count > 0)
            {
                //****************PENDIENTE POR TRADUCIR LOS MENSAJE BOX*****************************************
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.frmMonedas_EliminaMon;
                mensajeCaption = StringResources.ValidacióndeEliminación;
                 DialogResult respuesta = MessageBox.Show(mensajeText, mensajeCaption,
                 MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    for (int i = 0; i < pos; i++)
                    {
                        if (lstvMoneda.Items[i].Checked == true)
                        {
                            codSuc = Int32.Parse(txtCodigo.Text);
                            codMone= Int32.Parse(lstvMoneda.Items[i].SubItems[0].Text.ToString());
                            cargarDtMonedas();
                            j++;
                            codMon = lstvMoneda.Items[i].SubItems[0].Text.ToString();
                            lstvMoneda.Items.RemoveAt(i);
                            pos--;
                            i--;
                        }
                    }
                    if (j != 0)
                    {
                      Suc.eliminarRelacionSucMon(dtm, cboNombreCorto.Text);
                        mensajeText = StringResources.DBEliminacionexitosa;
                        MessageBox.Show(mensajeText, mensajeCaption,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dtm.Clear();
                        actualizarArray();
                        this.btoEliminar.Visible = false;
                    }
                }
                else
                {
                    return;
                }
            }

        }

        private void actualizarArray()
        {
            if (lstvMoneda.Items.Count > 0)
            {
                b = 0;
                for (int i = 0; i < lstvMoneda.Items.Count; i++)
                {
                    codMonAsociados[0, b] = lstvMoneda.Items[i].SubItems[0].Text.ToString();
                    b++;
                }
                if (b != dt.Rows.Count)
                {
                    for (int i = b; i < dt.Rows.Count; i++)
                    {
                        codMonAsociados[0, i] = "";
                    }
                }
            }
            else
            {
                b = 0;
            }
        }

        private void lstvMoneda_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.DarkOrange, e.Bounds);
            e.DrawText();
        }

        private void frmSucursales_FormClosed(object sender, FormClosedEventArgs e)
        {
            formSucursales = "";
        }

        private void cboxCodEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            codEmp = cboxCodEmp.Text;
        }
        private void frmSucursales_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                funcionAgregar();
                accion = "agregar";
            }
            if (e.KeyCode == Keys.F6)
            {
               // funcionEditar();
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

                funcionInicio();
                limpiarcajas();
            }
            if (e.KeyCode == Keys.F9)
            {
                funcionInicio();
                limpiarcajas();
            }
        }
        private void cargar_MonedasAsociadasSuc()       //monedas asociadas por sucursal
        {
            dt = Suc.Listado_monedas();
            dtrmR = Suc.Listado_RelacionSucMon(cboNombreCorto.Text);
        }

        private void buscarMonAsociadas()
        {
            codMonAsociados = new string[1, dt.Rows.Count];
            int cont=0;
            this.lstvMoneda.Visible = true;
            this.lstvMoneda.Items.Clear();
            b = 0;
            string codSuc=txtCod.Text;
                for (int i = 0; i < dtrmR.Rows.Count; i++)
                {
                    if (codSuc == dtrmR.Rows[i]["SucMon_codSuc"].ToString())
                    {
                        codMon = dtrmR.Rows[i]["SucMon_codMon"].ToString();
                        for (int a = 0; a < dt.Rows.Count; a++)
                        {
                            if (codMon == dt.Rows[a]["mon_codID"].ToString())
                            {
                            codMonAsociados[0,b]= dt.Rows[a]["mon_codID"].ToString().Trim();
                            lvrow = new ListViewItem(dt.Rows[a]["mon_codID"].ToString().Trim());
                            lvrow.SubItems.Add(dt.Rows[a]["mon_cod"].ToString().Trim());
                            lvrow.SubItems.Add(dt.Rows[a]["mon_Descripcion"].ToString().Trim());
                            lvrow.SubItems.Add(dt.Rows[a]["mon_simbolo"].ToString().Trim());
                            this.lstvMoneda.Items.Add(lvrow);
                            cont++;
                            b++;
                            }
                        }
                    }
                }
            if (cont>1) //mas de una moneda es multimoneda
            {
                this.lblmultimoneda.Visible = true;
                this.ckbMon.Visible = true;
                this.ckbMon.Enabled = false;
                this.ckbMon.Checked = true;
            }
            else if (cont==0)
            {
                this.lstvMoneda.Visible = false;
                this.lblMoneda.Text = StringResources.frmSucursales_NoHayMonedas;
            }
            if (cont > 0)
            {
                this.lstvMoneda.CheckBoxes = true;
                pos = lstvMoneda.Items.Count;
            }

        }
        private void btoSalir_Click(object sender, EventArgs e)
        {
            formSucursales = "";
            this.Close();
        }

        private void funcionBuscarBd()
        {
            emp = cboxCodEmp.Text;
            for (int i = 0; i < dte.Rows.Count; i++)
            {
                if (emp== dte.Rows[i]["empr_dni"].ToString())
                {
                    emprBD = dte.Rows[i]["empr_Bd"].ToString().Trim();
                    existeBD = dte.Rows[i]["empr_Bd"].ToString().Trim();
                    return;
                }
            }
        }
        private void funcionGuardar()
        {
            if (estado == "agregar")
            {
                if (txtNom.Text == "" || txtDescripcion.Text == "" ||
                    txtDescripcion.Text == "" || txtContacto.Text == "" ||
                    txtTelefono2.Text == ""  || txtEmail.Text == ""
                    || txtFechaCreacion.Text == "")
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
                    GenerarBdEmpresa();                   
                    string msj = "";
                    string codigoEmp = "";
                    codigoEmp= cboxCodEmp.Text.ToString().Trim();
                    Suc.m_emprCodigo= Int32.Parse(codigoEmp);
                    Suc.m_emprNomb = txtNom.Text.ToString().Trim();
                    Suc.m_emprDesc = txtDescripcion.Text.ToString().Trim();
                    Suc.m_emprDir = txtDireccion.Text.ToString().Trim();
                    Suc.m_empContacto = txtContacto.Text.ToString().Trim();
                    Suc.m_emprTelf1 = txtTelefono1.Text.ToString().Trim();
                    Suc.m_emprTelf2 = txtTelefono2.Text.ToString().Trim();
                    //---------------------------------
                   
                    //pasamos la codmoneda a int
                   // moneda = cboCodMoneda.Text.ToString().Trim();
                  //  Suc.m_emprMoneda = Int32.Parse(moneda);
                    Suc.m_emprEmail = txtEmail.Text.ToString().Trim();
                    Suc.m_emprNombCorto = cboNombreCorto.Text;
                    Suc.m_emprFechaCreacion = fecha;
                    //Suc.registar_monedaSuc(dtm,cboNombreCorto.Text);
                    msj = Suc.registar_empresaSucursal(cboNombreCorto.Text);
                    codSuc = Int32.Parse(Suc.codigo);
                    MonSelecionadas();
                    Suc.registar_monedaSuc(dtm, cboNombreCorto.Text);
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

        private void funcionEliminar()  // FALTA POR TERMINAR
        {
            if (frmTbUsuarioPersonalizada.usuaValido == "usuario valido")             // si en buscar encontro un usuario valido
            {
                string msj = "";

                //Preguntar al usuario si esta seguro de eliminar el resgistro
                DialogResult respuesta;

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.DeseaEliminarLaSucursal;
                mensajeCaption = StringResources.ValidacióndeEliminación;
                respuesta = MessageBox.Show(mensajeText + "" + txtNombre.Text.ToString().Trim() + " ?", mensajeCaption, MessageBoxButtons.YesNo);

                if (respuesta == DialogResult.Yes)
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    mensajeCaption = StringResources.ValidacióndeEliminación;

                    //msj de la base de datos cambiar
                    if (msj == "Eliminacion exitosa")
                    {
                        msj = StringResources.DBEliminacionexitosa;
                        MessageBox.Show(msj, mensajeCaption,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
        }

        private void GenerarBdEmpresa()
        {
            if (emprBD == "no")
            {
                emp = cboNombreCorto.Text;
                Suc.CrearBD(emp);
            }
        }
        private void limpiarcajas()
        {
            this.txtCodigo.Clear();
            this.txtNombre.Clear();
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
           
            this.txtEmail.Clear();
            this.txtFax.Clear();          
            this.txtFechaCreacion.Clear();
            this.cboSimbolo.Text = "";
            this.cboxMoneda.Text = "";
            this.txtFechaCreacion.Text = "";
            this.cboxMoneda.Text = "";
            //tab3           
            //this.btnAgregarMoneda.Clear();
            lstvMoneda.Items.Clear();
            lstvMoneda.Visible = false;
            if (b!=0)
            {
                for (int i = 0; i == b; i++)
                {
                    codMonAsociados[0, i] = null;
                }
                b = 0;
            }            
        }

        public void AplicarIdioma()
        {
            this.lblSeleccionarEmpresa.Text = StringResources.SeleccionarEmpresa;
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
            this.lblNombreCorto.Text = StringResources.Nombre;
            this.lblCodigo.Text = StringResources.Codigo;
            this.lblCod.Text = StringResources.Codigo;
            this.lblContacto.Text = StringResources.Contacto;
            this.lblDescripcion.Text = StringResources.Descripcion;
            this.lblFecha2.Text = StringResources.FechaCreacion;
            this.lblMensaje.Text = StringResources.CodigoAutogenerado;
            this.lblNom.Text = StringResources.Nombre;
            this.lblNombre.Text = StringResources.Nombre;
            this.lblTelefono.Text = StringResources.Telefonos;
            //
            this.Text = StringResources.Sucursales;
            this.lblTituloPanel.Text = StringResources.Sucursales;
            //
            this.tPgInfoGeneral.Text = StringResources.Informaciongeneral;
            this.tPgPopiedades.Text = StringResources.PropiedadesdeSucursal;
            this.tPgMonedas.Text = StringResources.moneda;
            //
            this.btoBuscar.Text = StringResources.btnBuscar;
            this.btoSalir.Text = StringResources.btnSalir;
            this.btoEliminar.Text = StringResources.btoEliminar;
            //
            this.lbldireccion.Text = StringResources.Direccion;
            //
            this.lblMoneda.Text = StringResources.moneda;
            this.lblRespaldos.Text = StringResources.UbicacionRespaldos;
            this.lblSeleccionMoneda.Text = StringResources.SeleccionelasMonedas;
            this.lblmultimoneda.Text = StringResources.Multimoneda;
            //
            this.lblmultimoneda.Text = StringResources.Multimoneda;
            this.lblEmail.Text = StringResources.email;
            this.lblFax.Text = StringResources.FAX;
            //listview
            this.ColCodigoMon.Text = StringResources.Codigo;
            this.Coldescripcion.Text = StringResources.Descripcion;
            this.Colsimbolo.Text = StringResources.frmMonedas_Simbolo;
            this.ColCodigoIso.Text = StringResources.frmMonedas_CodIso;
        }

    }
}
