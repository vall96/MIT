using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogicaNegocios;
using System.Globalization;
using System.Threading;
using CultureResources;

namespace CapaPresentacion
{
    public partial class frmEmpresaSucursursal : Form
    {             
        public frmEmpresaSucursursal()
        {
            InitializeComponent();            
            cargar_CboEmpresa();
            cargar_MonedasAsociadasSuc();
            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();           
            funcionInicio();
        }
        string usuario = "", pos="";
        frmRegristroUsuario venRegistro;
        DataTable dt = new DataTable();
        DataTable dts = new DataTable();            //tabla de sucursules
        DataTable dtm = new DataTable();
        DataTable dtrmR = new DataTable();
        clsEmpresa Suc = new clsEmpresa();
        public static string tipoPais = "", nombreBd = "",codMon,
            moneda,cod,simboloMoneda,sucursal;
        //int cont=0;
        
        private void cargar_MonedasAsociadasSuc()
        {
            dtm = Suc.Listado_monedas();
            dtrmR = Suc.Listado_RelacionSucMon(cboNombreCorto.Text);
        }

        private void buscarMonAsociadas()
        {
            cboCodMoneda.Items.Clear();
            cboSimboloM.Items.Clear();
            cboSimboloM.Text = "";
            cboMoneda.Items.Clear();
            string codSuc = cboxCodSuc.Text;
            for (int i = 0; i < dtrmR.Rows.Count; i++)
            {
                if (codSuc == dtrmR.Rows[i]["SucMon_codSuc"].ToString())
                {
                    codMon = dtrmR.Rows[i]["SucMon_codMon"].ToString();
                    for (int a = 0; a < dtm.Rows.Count; a++)
                    {
                        if (codMon == dtm.Rows[a]["mon_codID"].ToString())
                        {
                            cboMoneda.Items.Add(dtm.Rows[a]["mon_Descripcion"].ToString().Trim());
                            cboSimboloM.Items.Add(dtm.Rows[a]["mon_simbolo"].ToString().Trim());
                            cboCodMoneda.Items.Add(dtm.Rows[a]["mon_codID"].ToString().Trim());
                        }
                    }
                }
            }
        }
        private void frmEmpresaSucursursal_Load(object sender, EventArgs e)
        {
            usuario = frmRegristroUsuario.bduser;
            txtUsuario.Text = usuario;
        }
        private void funcionInicio()
        {
            cboNombreCorto.Enabled = false;
            txtUsuario.Enabled = false;
            this.cboMoneda.Enabled = false;
            txtRol.Enabled = false;
            txtRol.Text = "Usuario Administrador";
        }
        private void cargar_CboEmpresa()
        {
            dt = Suc.listadoEmpresa();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["empr_Bd"].ToString().Trim() == "si")
                {
                    this.cboxEmpresas.Items.Add(dt.Rows[i]["empr_nombre"].ToString());
                    this.cboxCodEmp.Items.Add(dt.Rows[i]["empr_dni"].ToString());
                    this.cboNombreCorto.Items.Add(dt.Rows[i]["empr_nombCorto"].ToString());
                    this.cboxEmpresas.SelectedIndex = 0;
                }

            }
        }
        private void cargar_CboSucursal()
        {
            dts = Suc.Listado_sucursules(nombreBd);          
            this.cboxCodSuc.Items.Clear();
            this.cboSucursales.Items.Clear();
            if (dts.Rows.Count > 0)
            {
                for (int i = 0; i < dts.Rows.Count; i++)
                {

                    this.cboSucursales.Items.Add(dts.Rows[i]["suc_nombre"].ToString());
                    this.cboxCodSuc.Items.Add(dts.Rows[i]["suc_cod"].ToString());
                    //this.cboSucursales.SelectedIndex = 0;

                }
               // cboSucursales.DroppedDown = true;
            }
            else
            {
                //this.cboSucursales.Text = nombreBd + " no tiene Sucursales Asociadas";
                this.cboSucursales.Enabled = false;
                lblNohaySucursal.Visible = true;
                this.lblNohaySucursal.Text = nombreBd + StringResources.Nohaysucursal;
               // this.toolStripBtoAgregar.Enabled = false;
            }

        }

        private void cboSimboloM_SelectedIndexChanged(object sender, EventArgs e)
        {
            simboloMoneda = cboSimboloM.Text;
        }

        private void cboCodMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            cod = cboCodMoneda.Text;
        }

        private void cboxEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblNohaySucursal.Visible = false;
            this.cboSucursales.Enabled = true;
            this.cboxCodEmp.SelectedIndex = this.cboxEmpresas.SelectedIndex;
            this.cboNombreCorto.SelectedIndex = this.cboxEmpresas.SelectedIndex;            
            nombreBd = cboNombreCorto.Text;
            cargar_CboSucursal();
        }

        private void btoValidar_Click(object sender, EventArgs e)
        {
            frmPrincipal ventPrincipal = new frmPrincipal();
            ventPrincipal.Show();
            // frmEmpresaSucursursal suc = new frmEmpresaSucursursal();
            // suc.Hide();
            this.Close();
        }

        private void btoSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            venRegistro = new frmRegristroUsuario();
            venRegistro.Show();
            //frmPrincipal ventPrincipal = new frmPrincipal();
            // ventPrincipal.Show();
            //this.Close();
        }

        private void cboMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cboCodMoneda.SelectedIndex = cboMoneda.SelectedIndex;    
            this.cboSimboloM.SelectedIndex= cboMoneda.SelectedIndex;
            moneda = cboMoneda.Text;
        }

        private void cboSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
            sucursal = cboSucursales.Text;
            this.cboxCodSuc.SelectedIndex = this.cboSucursales.SelectedIndex;
            if (cboMoneda.Text!=null)
            {               
                    this.cboMoneda.Enabled = true;
                    buscarMonAsociadas();
            }
            
        }

        public void AplicarIdioma()
        {
            //titulo
            this.Text = StringResources.frmEmpresa_Sucursal;
            this.lblTitulo.Text = StringResources.frmEmpresa_Sucursal;
            //label
            this.lblIUsuario.Text = StringResources.Usuario;
            this.lblRol.Text = StringResources.Rol;
            this.lblSeleccioneEmpresa.Text = StringResources.frmEmpresa_Sucursal_lblSeleccioneEmpresa;
            this.lblSucursalAsociada.Text = StringResources.frmEmpresa_Surcusal_lblSeleccioneSucursal;
            this.lblNombreCorto.Text = StringResources.Nombre;
            this.lblMoneda.Text = StringResources.frmMonedas_Monedas;
            //button
            this.btoValidar.Text = StringResources.btoAceptar;
            this.btoSalir.Text = StringResources.btnSalir;
            //
            this.lblMoneda.Text = StringResources.moneda;
            this.lblNohaySucursal.Text = StringResources.Nohaysucursal;


        }
    }
}
