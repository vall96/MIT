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
    public partial class frmOrdenProduccion : Form
    {
        frmTbCedulaProductos ventCedulaprodc;
        FrmTbOrdenProduccion ventOrden;
        clsEmpresa M = new clsEmpresa();
        public string tipoPais = "", mensajeText = "", mensajeCaption = "", Producto = "";
        public static string actual = "", compa = "", idprod = "", estado = "", uni = "", Iduni = "", Status = "", prioridad = "",
                             coduni = "", cedulacod = "", Unidad = "", statusconver = "", prioridadconver = "", coduniconver = "",
                             cedulacodconver = "", productoconver = "",accion = "";
        Boolean error;
        DataTable dtArtP = new DataTable();
        DataTable dtcboOP = new DataTable();
        DataTable dtcboS = new DataTable();
        DataTable dtuni = new DataTable();

        public frmOrdenProduccion()
        {
            InitializeComponent();
            FuncionInicio();
            frmPrincipal.nombreBD = "Digitel";
            dtuni = M.ListarUnidadesDescripcionMVL("MITCore"); //filtrado
            dtArtP = M.ListadoArticulosCedulaProducto(frmPrincipal.nombreBD);
            cargarCBO();
            CargarStatusCBO();
            
        }
        public class Validar
        {
            public static void SoloNumeros(KeyPressEventArgs N)
            {
                if (Char.IsNumber(N.KeyChar))
                {
                    N.Handled = false;
                }
                else if (Char.IsControl(N.KeyChar))
                {
                    N.Handled = false;
                }
                else
                {
                    N.Handled = true;
                }
            }
        }
        /// <summary>
        /// PASAR (EJECUTAR)
        /// </summary>
        private void btoCedula_Click(object sender, EventArgs e)
        {
            ventCedulaprodc = new frmTbCedulaProductos();
            ventCedulaprodc.pasado += new frmTbCedulaProductos.pasar(ejecutar);
            ventCedulaprodc.ShowDialog();
        }
        private void btnOrden_Click(object sender, EventArgs e)
        {
            ventOrden = new FrmTbOrdenProduccion();
            ventOrden.pasado += new FrmTbOrdenProduccion.pasar(ejecutarorden);
            ventOrden.ShowDialog();
        }
        public void ejecutar(string[,] dato)
        {
            txtCodCedula.Text = dato[0, 0];
            txtDescripProducto.Text = dato[0, 9];
            txtUnidad.Text = dato[0, 2];
            cbocodUnidadesO.Items.Clear();
            cboUnidadesOrden.Items.Clear(); 
            compa = dato[0, 9];
            uni = dato[0, 8];
            CargarUnidades();                   
            Comparacion();                       
            txtCodProducto.Text = idprod.ToString();
        }
        public void ejecutarorden(string[,] dato)
        {
            this.toolStripBtoAgregar.Enabled = false;
            this.btnBuscar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            this.toolStripBtoEditar.Enabled = true;
            this.toolStripBtoEliminar.Enabled = true;
            if(FrmTbOrdenProduccion.validar == "valido") // no hace falta ponerlo 
            {
                compa = frmTbCedulaProductos._producto; // recoger estos datos directamente de labase de datos 
                uni = frmTbCedulaProductos._Uestandar; // recoger estos datos directamente de labase de datos 
                CargarUnidades(); // recorres la tabla para buscar el codigo de producto cuando lo encuentras te traes los datos que necesites que en este caso es el codigo de la unidad y la unidad estandar (la unidad estandar es para filtar la unidades y no que te salgan las 38 unidades) ;
                Comparacion(); // mañana vemos xD 
                txtCodProducto.Text = idprod.ToString();
            }
            //se  recogen los datos en variables para su posterior comparacion
            Status = dato[0, 3];
            prioridad = dato[0, 8];
            coduni = dato[0, 11];
            cedulacod = dato[0, 12];
            Producto = dato[0, 13];
            // se pasan los datos a las cajas de texto
            txtCodOrden.Text = dato[0, 1];
            txtDescripOrden.Text = dato[0, 2];
            txtCodCedula.Text = dato[0, 4];
            dtCrear.Text = dato[0, 5];
            dtInicio.Text = dato[0, 6];
            dtCierre.Text = dato[0, 7];
            txtCosto.Text = dato[0, 9];
            txtCantidad.Text = dato[0, 10];
            txtCodProducto.Text = dato[0, 13];
            //conversiones        
            ConversionStatus();
            ConversionPrioridad();
            ConversionUnidadOrden();
            ConversionUnidadCedula();
            ComparacionDescrip();
            cboStatusOP.Text = statusconver;
            cboPrioridad.Text = prioridadconver;
            CargarCBOOrden();
            cboUnidadesOrden.Text = coduniconver;
            txtUnidad.Text = cedulacodconver;
            txtDescripProducto.Text = productoconver;
        }
        /// <summary>
        /// CONVERSIONES
        /// </summary>
        public void ConversionUnidadOrden()
        {
            for (int i = 0; i < dtuni.Rows.Count; i++)
            {
                if (coduni == dtuni.Rows[i]["UnidDes_codUni"].ToString())
                {
                    coduniconver = dtuni.Rows[i]["UnidDes_Descripcion"].ToString();
                    Unidad = dtuni.Rows[i]["UnidDes_codUniEst"].ToString();
                    return;
                }
            }
        }
        public void ConversionUnidadCedula()
        {
            for (int i = 0; i < dtuni.Rows.Count; i++)
            {
                if (cedulacod == dtuni.Rows[i]["UnidDes_codUni"].ToString())
                {
                    cedulacodconver = dtuni.Rows[i]["UnidDes_Descripcion"].ToString();
                    return;
                }
            }
        }
        public void ConversionPrioridad()
        {
            for (int i = 0; i < dtcboOP.Rows.Count; i++)
            {
                if (prioridad == dtcboOP.Rows[i]["Priord_Cod"].ToString())
                {
                    prioridadconver = dtcboOP.Rows[i]["Priorid_desc"].ToString();
                    return;
                }
            }
        }
        public void ConversionStatus()
        {
            for (int i = 0; i < dtcboS.Rows.Count; i++)
            {
                if (Status == dtcboS.Rows[i]["Status_Cod"].ToString())
                {
                    statusconver = dtcboS.Rows[i]["Status_desc"].ToString();
                    return;
                }
            }
        }
        public void ConversionUnidad()
        {
            for (int i = 0; i < dtuni.Rows.Count; i++)
            {
                if (txtUnidad.Text == dtuni.Rows[i]["UnidDes_Descripcion"].ToString())
                {
                    Iduni = dtuni.Rows[i]["UnidDes_codUni"].ToString();
                    return;
                }
            }
        }
        /// <summary>
        /// COMPARACIONES
        /// </summary>
        public void Comparacion()
        {

            for (int i = 0; dtArtP.Rows.Count > i; i++)
            {
                if (compa == dtArtP.Rows[i]["art_Nom"].ToString())
                {
                    idprod = dtArtP.Rows[i]["art_Id"].ToString();
                }
            }
        }
        public void ComparacionDescrip()
        {
            for (int i = 0; dtArtP.Rows.Count > i; i++)
            {
                if (Producto == dtArtP.Rows[i]["art_Id"].ToString())
                {
                    productoconver = dtArtP.Rows[i]["art_Nom"].ToString();
                }
            }
        }
        /// <summary>
        /// CARGAS DE CBO
        /// </summary>
        public void cargarCBO()
        {
            this.cboPrioridad.Items.Clear();
            dtcboOP = M.Listar_Prioridades(frmPrincipal.nombreBD);
            for (int i = 0; i < dtcboOP.Rows.Count; i++)
            {
                cbocdoPrioridad.Items.Add(dtcboOP.Rows[i]["Priord_Cod"].ToString());
                cboPrioridad.Items.Add(dtcboOP.Rows[i]["Priorid_desc"].ToString());
            }
        }
        public void CargarCBOOrden()
        {
            for (int i = 0; i < dtuni.Rows.Count; i++)
            {
                cboUnidadesOrden.Items.Clear();
                string codU = "";
                codU = dtuni.Rows[i]["UnidDes_codUniEst"].ToString().ToLower();
                if (Unidad == codU)
                {
                    cboUnidadesOrden.Items.Add(dtuni.Rows[i]["UnidDes_Descripcion"].ToString());
                    cbocodUnidadesO.Items.Add(dtuni.Rows[i]["UnidDes_codUni"].ToString());
                }
            }
        }
        public void CargarStatusCBO()
        {
            this.cboStatusOP.Items.Clear();
            dtcboS = M.Listado_StatusOP(frmPrincipal.nombreBD);
            for (int i = 0; i < dtcboS.Rows.Count; i++)
            {
                cbocodStatusOP.Items.Add(dtcboS.Rows[i]["Status_Cod"].ToString());
                cboStatusOP.Items.Add(dtcboS.Rows[i]["Status_desc"].ToString());
            }
        }

        private void toolStripBtoEditar_Click(object sender, EventArgs e)
        {
            FuncionEditar();
        }

        private void frmOrdenProduccion_Load(object sender, EventArgs e)
        {

        }

        public void CargarUnidades()
        {
            cboUnidadesOrden.Items.Clear();
            for (int i = 0; i < dtuni.Rows.Count; i++)
            {
                string codU = "";
                codU = dtuni.Rows[i]["UnidDes_codUniEst"].ToString().ToLower();
                if (codU == uni)
                {
                    cboUnidadesOrden.Items.Add(dtuni.Rows[i]["UnidDes_Descripcion"].ToString());
                    cbocodUnidadesO.Items.Add(dtuni.Rows[i]["UnidDes_codUni"].ToString());
                }
            }
        }
        /// <summary>
        /// FUNCIONES
        /// </summary>
        public void FuncionInicio()
        {
            this.toolStripBtoAgregar.Enabled = true;
            this.toolStripBtoDescartar.Enabled = false;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoGuardar.Enabled = false;
            this.toolStripBtoEliminar.Enabled = false;
            cbocdoPrioridad.Items.Clear();
            cbocodStatusOP.Items.Clear();
            cbocodUnidadesO.Items.Clear();
            cboUnidadesOrden.Items.Clear();
            errorProvider1.Clear();
            dtCrear.Enabled = false;
            dtInicio.Enabled = false;
            dtCierre.Enabled = false;
            txtCodOrden.Enabled = true;
            txtCantidad.Enabled = false;
            txtUnidad.Enabled = false;
            txtCosto.Enabled = false;
            txtCodCedula.Enabled = false;
            txtCodProducto.Enabled = false;
            txtDescripProducto.Enabled = false;
            cboPrioridad.Enabled = false;
            cboUnidadesOrden.Enabled = false;
            cboStatusOP.Enabled = false;
            btoCedula.Enabled = false;
            btnOrden.Enabled = true;
            btnBuscar.Enabled = true;
            this.dtCrear.Value = DateTime.Now;
            this.dtInicio.Value = DateTime.Now;
            this.dtCierre.Value = DateTime.Now;
            lblMensaje.Visible = false;
        }
        public void FuncionLimpiar()
        {
            this.toolStripBtoAgregar.Enabled = true;
            this.toolStripBtoDescartar.Enabled = false;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoGuardar.Enabled = false;
            this.toolStripBtoEliminar.Enabled = false;
            errorProvider1.Clear();
            dtCrear.Enabled = false;
            dtInicio.Enabled = false;
            dtCierre.Enabled = false;
            txtCodOrden.Enabled = true;
            txtCantidad.Enabled = false;
            txtUnidad.Enabled = false;
            txtCosto.Enabled = false;
            txtCodCedula.Enabled = false;
            txtCodProducto.Enabled = false;
            txtDescripProducto.Enabled = false;
            cboPrioridad.Enabled = false;
            cboUnidadesOrden.Enabled = false;
            cboStatusOP.Enabled = false;
            btoCedula.Enabled = false;
            btnOrden.Enabled = true;
            btnBuscar.Enabled = true;
            this.dtCrear.Value = DateTime.Now;
            this.dtInicio.Value = DateTime.Now;
            this.dtCierre.Value = DateTime.Now;
            lblMensaje.Visible = false;
        }
        public void FuncionAgregar()
        {
            estado = "agregar";
            actual = "agregar";
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoGuardar.Enabled = true;
            this.toolStripBtoEliminar.Enabled = false;
            ////
            dtCrear.Enabled = true;
            dtInicio.Enabled = true;
            dtCierre.Enabled = true;
            txtCodOrden.Enabled = false;
            txtCantidad.Enabled = true;
            txtUnidad.Enabled = false;
            txtCosto.Enabled = false;
            txtCodCedula.Enabled = true;
            txtCodProducto.Enabled = false;
            txtDescripProducto.Enabled = false;
            cboPrioridad.Enabled = true;
            cboStatusOP.Enabled = false;
            cboUnidadesOrden.Enabled = true;
            btoCedula.Enabled = true;
            btnProcesar.Enabled = true;
            ////
            btnBuscar.Enabled = false;
            btnOrden.Enabled = false;
            this.cboPrioridad.SelectedIndex = 2;
            cboStatusOP.SelectedIndex = 0;
            ///
            lblMensaje.Visible = true;
        }

        public void FuncionEditar()
        {
            estado = "editar";
            actual = "editar";
            this.txtCodOrden.Enabled = false;
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoGuardar.Enabled = true;
            this.toolStripBtoEliminar.Enabled = false;
            ////
            dtCrear.Enabled = false;
            dtInicio.Enabled = true;
            dtCierre.Enabled = true;
            txtCodOrden.Enabled = false;
            txtCantidad.Enabled = true;
            txtUnidad.Enabled = false;
            txtCosto.Enabled = false;
            txtCodCedula.Enabled = false;
            txtCodProducto.Enabled = false;
            txtDescripProducto.Enabled = false;
            cboPrioridad.Enabled = true;
            cboStatusOP.Enabled = false;
            cboUnidadesOrden.Enabled = true;
            btoCedula.Enabled = false;
            btnProcesar.Enabled = true;
            ////
            btnBuscar.Enabled = false;
            btnOrden.Enabled = false;
            this.cboPrioridad.SelectedIndex = 2;
            cboStatusOP.SelectedIndex = 0;
            ///
            lblMensaje.Visible = false;

        }

        private void LimpiarCajas()
        {
            txtCodOrden.Clear();
            txtDescripOrden.Clear();
            txtCodCedula.Clear();
            txtCodProducto.Clear();
            txtDescripProducto.Clear();
            txtCantidad.Clear();
            txtUnidad.Clear();
            txtCosto.Clear();
            this.cboPrioridad.SelectedIndex = -1;
            this.cboStatusOP.SelectedIndex = -1;
            cboUnidadesOrden.SelectedIndex = -1;
            dtCrear.Value = DateTime.Now;
            dtInicio.Value = DateTime.Now;
            dtCierre.Value = DateTime.Now;
        }
        private void FuncionGuardar()
        {
            if (estado == "agregar")
            {
                string mensaje = "";
                ValidarCajas();
                if (error == false)
                {
                    ConversionUnidad();
                    M.m_descrip = txtDescripOrden.Text.ToString().Trim();
                    M.m_cedula = txtCodCedula.Text.ToString().Trim();
                    M.m_producto = txtCodProducto.Text.ToString().Trim();
                    M.m_creacion = dtCrear.Value.Date;
                    M.m_inicio = dtInicio.Value.Date;
                    M.m_cierre = dtCierre.Value.Date;
                    M.m_prioridad = Convert.ToInt32(cbocdoPrioridad.Text.ToString());
                    M.m_status = Convert.ToInt32(cbocodStatusOP.Text.ToString());
                    M.m_costo = Convert.ToDecimal(txtCosto.Text.ToString());
                    M.m_cantidad = Convert.ToInt64(txtCantidad.Text.ToString());
                    M.m_unidado = cbocodUnidadesO.Text.ToString();
                    M.m_unidadc = Iduni;
                    mensaje = M.RegistrarOrden(frmPrincipal.nombreBD);
                    if (mensaje == "Registro Exitoso")
                    {
                        mensajeCaption = StringResources.ValidaciondeRegistro;
                        mensajeText = StringResources.DBRegistroexitoso;
                        MessageBox.Show(mensajeText, mensajeCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    FuncionInicio();
                    LimpiarCajas();
                }

            }
        }
        private void FuncionDescartar()
        {
            LimpiarCajas();
            FuncionLimpiar();
            //FuncionInicio();
        }
        /// <summary>
        /// EVENTOS
        /// </summary>
        private void btoSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
        }

        private void cboPrioridad_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbocdoPrioridad.SelectedIndex = cboPrioridad.SelectedIndex;
        }

        private void cbocodStatusOP_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbocodStatusOP.SelectedIndex = cboStatusOP.SelectedIndex;
        }

        private void toolStripBtoAgregar_Click(object sender, EventArgs e)
        {
            FuncionAgregar();
        }
        private void toolStripBtoDescartar_Click(object sender, EventArgs e)
        {
            FuncionDescartar();
        }
        private void toolStripBtoGuardar_Click(object sender, EventArgs e)
        {
            FuncionGuardar();
        }
        private void cboUnidadesOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbocodUnidadesO.SelectedIndex = cboUnidadesOrden.SelectedIndex;
        }

        private void cboStatusOP_SelectedIndexChanged(object sender, EventArgs e)
        {
             this.cbocodStatusOP.SelectedIndex = cboStatusOP.SelectedIndex;
        }
        private void frmOrdenProduccion_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                //  FuncionBuscar();
            }
            if (e.KeyCode == Keys.F5)
            {
                if (actual == "inicio")
                {
                    FuncionAgregar();
                }
            }
            if (e.KeyCode == Keys.F6)
            {
                if (actual != "inicio")
                {
                    if (actual != "agregar")
                    {
                         FuncionEditar();
                    }
                }
            }
            if (e.KeyCode == Keys.F7)
            {
                if (actual != "inicio")
                {
                    if (actual != "EditarEliminar")
                    {
                        FuncionGuardar();
                    }

                }
            }
            if (e.KeyCode == Keys.F8)
            {
                if (actual != "inicio")
                {
                    if (actual != "agregar")
                    {
                        if (actual != "editar")
                        {
                            // funcionEliminar();
                        }
                    }
                }
            }
            if (e.KeyCode == Keys.F9)
            {
                FuncionDescartar();
            }
        }

        /// <summary>
        /// VALIDACIONES
        /// </summary>
        private void ValidarCajas()
        {
            error = false;
            errorProvider1.Clear();
            if (txtDescripOrden.Text == "")
            {
                errorProvider1.SetError(txtDescripOrden, "Item Vacío");
                error = true;
            }
            if (txtCodCedula.Text == "")
            {
                errorProvider1.SetError(txtCodCedula, "Item Vacío");
                error = true;
            }
            if (txtCodProducto.Text == "")
            {
                errorProvider1.SetError(txtCodProducto, "Item Vacío");
                error = true;
            }
            if (txtDescripProducto.Text == "")
            {
                errorProvider1.SetError(txtDescripProducto, "Item Vacío");
                error = true;
            }
            if (txtCantidad.Text == "")
            {
                errorProvider1.SetError(txtCantidad, "Item Vacío");
                error = true;
            }
            if (txtCosto.Text == "")
            {
                txtCosto.Text = "0";
            }
            if (cboUnidadesOrden.Text == "")
            {
                errorProvider1.SetError(cboUnidadesOrden, "Item Vacío");
                error = true;
            }
        }
    }

   
}
