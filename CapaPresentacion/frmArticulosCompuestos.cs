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
    public partial class frmArticulosCompuestos : Form
    {
        public frmArticulosCompuestos()
        {
            InitializeComponent();
            FuncionInicio();
            CargarcboUnidades();

            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();

        }
        clsEmpresa M = new clsEmpresa();
        frmTbArticulos ventTbArticulos;
        public static string estado = "", tipoPais = "";

        private void FuncionInicio()
        {
            this.btnPuntos.Enabled = true;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoEliminar.Enabled = false;
            this.toolStripBtoGuardar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = false;
            this.toolStripBtoAgregar.Enabled = true;
            this.btoBuscar.Enabled = true;
            //*------------------------
            this.dGvArticulos.Enabled = false;
            //------------------------
            txtMoneda.Enabled = false;
            txtmonedaSim.Enabled = false;
            txtmonedaSim.Text = frmEmpresaSucursursal.simboloMoneda;
            txtMoneda.Text = frmEmpresaSucursursal.moneda;
            //--------------------------
            txtCod.Enabled = false;
            lblMensaje.Visible = false;
            txtNom.Enabled = false;
            txtModelo.Enabled = false;
            cboUnidad.Enabled = false;
            txtSerial.Enabled = false;
            txtMedida.Enabled = false;
            txtCategoria.Enabled = false;
            txtSubCatg.Enabled = false;
            btoLinea.Enabled = false;
            btoSubLinea.Enabled = false;
            cboMetodoCosto.Enabled = false;
            rbtoPreImpuesto.Enabled = false;
            rbtoUtilidad.Enabled = false;
            btoDescu.Enabled = false;
        }
        private void FuncionAgregar()
        {
            this.btnPuntos.Enabled = false;
            estado = "agregar";
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoGuardar.Enabled = true;
            this.toolStripBtoEliminar.Enabled = false;
            this.btoBuscar.Enabled = true;
            //----gridview-------------
            //--------------------------
           // txtCod.Enabled = true;
            lblMensaje.Visible = true;
            txtNom.Enabled = true;
            txtModelo.Enabled = true;
            cboUnidad.Enabled = true;
            txtSerial.Enabled = true;
            txtMedida.Enabled = true;
            txtCategoria.Enabled = true;
            txtSubCatg.Enabled = true;
            btoLinea.Enabled = true;
            btoSubLinea.Enabled = true;
            cboMetodoCosto.Enabled = true;
            rbtoPreImpuesto.Enabled = true;
            rbtoUtilidad.Enabled = true;
            btoDescu.Enabled = true;
            //----------------------
            this.txtNom.Focus();
        }
        private void LimpiarCajas()
        {
            txtCod.Clear();
            txtNom.Clear();
            txtModelo.Clear();
            txtSerial.Clear();
            txtMedida.Clear();
            txtCategoria.Clear();
            txtSubCatg.Clear();
            rbtoPreImpuesto.Enabled = true;
            rbtoUtilidad.Enabled = true;
            btoDescu.Enabled = true;
            //----------------------
        }
        private void CargarcboUnidades()
        {
            this.cboUnidad.Items.Clear();
            DataTable dt = new DataTable();
            dt = M.ListadoUnidades(frmPrincipal.nombreBD);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cboCodUnidad.Items.Add(dt.Rows[i]["Uni_Id"].ToString());
                cboUnidad.Items.Add(dt.Rows[i]["Uni_Desc"].ToString());
            }
        }
        private void btoSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmArticulosCompuestos_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(0, 0);
           // dGvArticulos.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ventTbArticulos = new frmTbArticulos();
          //  ventTbArticulos.pasado += new frmTbArticulos.pasar(ejecutar);
            ventTbArticulos.Show();
        }

        private void toolStripBtoAgregar_Click(object sender, EventArgs e)
        {
            FuncionAgregar();
        }

        private void toolStripBtoDescartar_Click(object sender, EventArgs e)
        {
            FuncionInicio();
            LimpiarCajas();
        }
        public void AplicarIdioma()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            //btos
            this.toolStripBtoAgregar.Text = StringResources.btoAgregar;
            this.toolStripBtoDescartar.Text = StringResources.btoDescartar;
            this.toolStripBtoEditar.Text = StringResources.btoEditar;
            this.toolStripBtoEliminar.Text = StringResources.btoEliminar;
            this.toolStripBtoGuardar.Text = StringResources.btoGuardar;
            //tooltip
            this.toolStripBtoAgregar.ToolTipText = StringResources.btoAgregar;
            this.toolStripBtoDescartar.ToolTipText = StringResources.btoDescartar;
            this.toolStripBtoEditar.ToolTipText = StringResources.btoEditar;
            this.toolStripBtoEliminar.ToolTipText = StringResources.btoEliminar;
            this.toolStripBtoGuardar.ToolTipText = StringResources.btoGuardar;
            //btos
            this.btoBuscar.Text = StringResources.btnBuscar;
            this.btoSalir.Text = StringResources.btnSalir;
            //tap
            this.tPgInfoGeneral.Text = StringResources.Informaciongeneral;
            this.tPgInfoGeneral.ToolTipText = StringResources.Informaciongeneral;
                 this.lblCod.Text = StringResources.Codigo;
                this.lblCodigo.Text = StringResources.Codigo;
                this.lblNombre.Text = StringResources.Nombre;
                this.lblNom.Text = StringResources.Nombre;
                this.lblModelo.Text = StringResources.Modelo;
                this.lblSerial.Text = StringResources.Serial;
                this.lblCategoria.Text = StringResources.Categoria;
                this.lblSubCategoria.Text = StringResources.SubCategoria;
                this.lblUnidad.Text = StringResources.Unidad;
                this.lblMedida.Text = StringResources.Medida;

                this.lblasociararticulos.Text = StringResources.AsociarArticulos;
                    this.Codigo.HeaderText = StringResources.Codigo;
                    this.Cantidad.HeaderText = StringResources.Cantidad;
                    this.Nombre.HeaderText = StringResources.Nombre;
                    this.Costos.HeaderText = StringResources.Costo;
                    this.PrecioMaximo.HeaderText = StringResources.PrecioMaximo;
                    this.PrecioOferta.HeaderText = StringResources.PrecioOferta;
                    this.PrecioMinimo.HeaderText = StringResources.PrecioMinimo;
            //
            this.tPgCostosyPrecios.Text = StringResources.CostoyPrecio;
            this.tPgCostosyPrecios.ToolTipText = StringResources.CostoyPrecio;

                this.lblMetodoCosto.Text = StringResources.SeleccioneElMetodoDeCosto;
                this.precios1.HeaderText = StringResources.CostosDeITEM;
                this.SimImpuesto1.HeaderText = StringResources.SinImpuesto;
                this.ComImpuesto1.HeaderText = StringResources.ConImpuesto;
                this.lblconfiguararDesc.Text = StringResources.ConfigurarDescuento_;

            this.rbtoUtilidad.Text = StringResources.Tomar_utilidad;
            this.rbtoPreImpuesto.Text = StringResources.RedondearPreciosconImpuestos;
            //
            this.tPgAsociarAlm.Text = StringResources.AsociarAlmacen;
            this.tPgAsociarAlm.ToolTipText = StringResources.AsociarAlmacen;

                this.lblAlmacenasoc.Text = StringResources.AlmacenesAsociados;
            //---------------------------------------------------------------------------------


        }
    }
}
