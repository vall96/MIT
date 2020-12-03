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
    public partial class frmArticulos : Form
    {
        public static string estado = "", formActivo, codCategoria, categoria, tipoPais;
        //
        clsEmpresa M = new clsEmpresa();
        //
        frmTbCategoria ventTbCategoria;
        frmTbSubCateg venTbSucCatg;
        frmTbArticulos ventTbArticulos;
        frmTbProveedores ventTbProvedores;
        //
        DataTable dtm = new DataTable();
        DataTable dtp = new DataTable();
        DataTable dtc = new DataTable();
        DataTable dt = new DataTable();
        DataTable dtProv = new DataTable();
        //
        Boolean error;
        Decimal valor, disponible;
        //datatable para filtrado
        DataTable dtUV = new DataTable();
        DataTable dtUM = new DataTable();
        DataTable dtUL = new DataTable();
        //
        DataTable listaArt = new DataTable();
        //variables filtro
        public string Estandar, CargarDesc, CargarUE, CargarUD, codU, idUD;
        public string mensajeText = "", mensajeCaption = "";
        public static string valido = "", accion = "";
        public static int cont = 0;
        //
        DataTable Proveedores = new DataTable();
        int a = 0, b = 0;
        public static DataTable DtActualProv;
        int iva, lote;
        //-------------------------------------------------------------------------------------------------------------------------------------------------------
        public frmArticulos()
        {
            InitializeComponent();

            dtActuales();

            ColumnaCostos();
            CargarCodigos();

        }
        private void frmArticulos_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(0, 0);

            FuncionInicio();

            CargarcboUnidades();

            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------
        private void FuncionInicio()
        {
            LimpiarCajas();
            //
            this.btnPuntos.Enabled = true;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoEliminar.Enabled = false;
            this.toolStripBtoGuardar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = false;
            this.toolStripBtoAgregar.Enabled = true;
            this.btoBuscar.Enabled = true;
            //----gridview-------------
            dGvPrecios.Columns[0].ReadOnly = true;
            dgvCostos.Columns[0].ReadOnly = true;
            dGvStock.Columns[0].ReadOnly = true;
            //
            dGvStock2.Columns[0].ReadOnly = true;
            dGvStock2.Columns[1].ReadOnly = true;
            dGvStock2.Columns[5].ReadOnly = true;
            //
            dgvAsociarProv.Enabled = false;
            dGvPrecios.Enabled = false;
            dGvStock2.Enabled = false;
            dgvCostos.Enabled = false;
            dGvStock.Enabled = false;
            //--------------------------
            cboUnidadesFiltradas.Enabled = false;
            txtCategoria.Enabled = false;
            txtSubCatg.Enabled = false;
            txtModelo.Enabled = false;
            cboUnidad.Enabled = false;
            txtSerial.Enabled = false;
            txtDias.Enabled = false;
            txtCod.Enabled = false;
            txtNom.Enabled = false;
            //
            rbtoRedondearPreImpuesto.Enabled = false;
            rbtoUtilidad.Enabled = false;
            btoSubCatg.Enabled = false;
            btoDescu.Enabled = false;
            btoCatg.Enabled = false;
            //
            cboMetodoCosto.Enabled = false;
            cboTipoArt.Enabled = false;
            //
            CBIva.Enabled = false;
            CBLote.Enabled = false;
        }
        private void FuncionAgregar()
        {
            estado = "agregar";
            accion = "agregar";
            this.btnPuntos.Enabled = false;
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoGuardar.Enabled = true;
            this.toolStripBtoEliminar.Enabled = false;
            this.btoBuscar.Enabled = true;
            //----gridview-------------
            dGvPrecios.Columns[0].ReadOnly = true;
            dgvCostos.Columns[0].ReadOnly = true;
            dGvStock.Columns[0].ReadOnly = true;
            //
            dgvAsociarProv.Enabled = true;
            dGvPrecios.Enabled = true;
            dGvStock2.Enabled = true;
            dgvCostos.Enabled = true;
            dGvStock.Enabled = true;
            //--------------------------
            txtDescripcion.Enabled = false;
            txtCategoria.Enabled = false;
            txtSubCatg.Enabled = false;
            txtCodigo.Enabled = false;
            //
            cboUnidadesFiltradas.Enabled = true;
            cboMetodoCosto.Enabled = true;
            cboTipoArt.Enabled = true;
            txtModelo.Enabled = true;
            cboUnidad.Enabled = true;
            txtSerial.Enabled = true;
            txtDias.Enabled = true;
            txtCod.Enabled = true;
            txtNom.Enabled = true;
            //
            rbtoRedondearPreImpuesto.Enabled = true;
            rbtoUtilidad.Enabled = true;
            btoSubCatg.Enabled = true;
            btoDescu.Enabled = true;
            btoCatg.Enabled = true;
            this.txtNom.Focus();
            //----------------------------
            cboTipoArt.SelectedIndex = 0;
            cboUnidad.SelectedItem = 0;
            //----------------------
            CBIva.Enabled = true;
            CBLote.Enabled = true;
            CargarcboUnidades();
        }
        private void FuncionGuardar()  //modificar
        {
            string msj = "";
            dgvCostos.EndEdit();
            dGvStock.EndEdit();
            dGvStock2.EndEdit();
            dGvPrecios.EndEdit();
            dgvAsociarProv.EndEdit();

            if (accion == "agregar" || accion == "editar" || accion == "pasado")
            {
                ValidarCajas();
                if(error == true)
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
                    mensajeText = StringResources.ExistenCamposVacios;
                    mensajeCaption = StringResources.ValidaciondeRegistro;
                    MessageBox.Show(mensajeText, mensajeCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
                if (error == false)
                {
                    M.m_emprNomb = txtNom.Text.ToString().Trim();
                    M.m_Serial = txtSerial.Text.ToString().Trim();
                    M.m_Cat = txtCodCatg.Text.ToString().Trim();
                    M.m_CogSubCat = txtCodSCatg.Text.ToString().Trim();
                    M.m_CodUnidad = cboCodUnidad.Text.ToString().Trim();
                    M.m_codUnidades = cboCodUnidFiltro.Text.ToString().Trim();
                    //
                    M.m_garantia = txtDias.Text;
                    M.m_modelo = txtModelo.Text;
                    M.m_codCedulaProd = txtCodArt.Text + txtCod.Text;
                    M.m_cod = txtCodArt.Text;
                    M.m_IVA = iva;
                    M.m_LOTE = lote;
                    msj = M.RegistrarArtuculos(frmPrincipal.nombreBD);
                   
                    if (msj == "Registro Exitoso")
                    {
                       // cargarRelacionProv(); // FUNCIONANDO inabilitado por espera de instrucciones
                        
                        if (msj == "Registro Exitoso")
                        {
                            Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
                            mensajeText = StringResources.DBRegistroexitoso;
                            mensajeCaption = StringResources.ValidaciondeRegistro;

                            MessageBox.Show(mensajeText, mensajeCaption,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        }
                    }
                    FuncionInicio();
                }
            }
        }
        //--------------------------------------------
        public void cargarRelacionProv()
        {
           int j = 0;
            ConstruccionDtProv();
            dgvAsociarProv.AllowUserToAddRows = false;
            if (dgvAsociarProv.Rows.Count >= 1)
            {
                for (int i = 0; i < dgvAsociarProv.Rows.Count; i++)
                {
                    dtProv.Rows.Add();
                    dtProv.Rows[j]["artprov_ArtId"] = txtCodArt.Text + txtCod.Text;
                    dtProv.Rows[j]["artprov_Id"] = dgvAsociarProv.Rows[i].Cells[0].Value.ToString();
                    dtProv.Rows[j]["artprov_Nom"] = dgvAsociarProv.Rows[i].Cells[2].Value.ToString(); 
                    dtProv.Rows[j]["artprov_Fcompra"] = dgvAsociarProv.Rows[i].Cells[3].Value.ToString();
                    dtProv.Rows[j]["artprov_cost"] = dgvAsociarProv.Rows[i].Cells[4].Value.ToString();
                    dtProv.Rows[j]["artprov_cant"] = dgvAsociarProv.Rows[i].Cells[5].Value.ToString();

                    j++;
                }
            }
            if (j != 0)
            {
                M.RegistrarArticulo_Prov(dtProv, frmPrincipal.nombreBD);
            }

            if (accion == "editar")
            {
                for (int i = 0; i < dgvAsociarProv.Rows.Count; i++)
                {
                    dtProv.Rows.Add();
                    dtProv.Rows[j]["artprov_ArtId"] = txtCodArt.Text + txtCod.Text;
                    dtProv.Rows[j]["artprov_Id"] = dgvAsociarProv.Rows[i].Cells[0].Value.ToString();
                    dtProv.Rows[j]["artprov_Nom"] = dgvAsociarProv.Rows[i].Cells[2].Value.ToString();
                    dtProv.Rows[j]["artprov_Fcompra"] = dgvAsociarProv.Rows[i].Cells[3].Value.ToString();
                    dtProv.Rows[j]["artprov_cost"] = dgvAsociarProv.Rows[i].Cells[4].Value.ToString();
                    dtProv.Rows[j]["artprov_cant"] = dgvAsociarProv.Rows[i].Cells[5].Value.ToString();

                    j++;
                }
            }
            if (j != 0)
            {
                M.ActualizarArticulo_Prov(dtProv, frmPrincipal.nombreBD);
            }
        }

        public void ConstruccionDtProv()
        {
            dtProv.Rows.Clear();
            dtProv.Columns.Clear();
            dtProv.Columns.Add("artprov_ArtId", Type.GetType("System.String"));
            dtProv.Columns.Add("artprov_Id", Type.GetType("System.String"));
            dtProv.Columns.Add("artprov_Nom", Type.GetType("System.String"));
            dtProv.Columns.Add("artprov_Fcompra", Type.GetType("System.String"));
            dtProv.Columns.Add("artprov_cost", Type.GetType("System.String"));
            dtProv.Columns.Add("artprov_cant", Type.GetType("System.String"));
        }
        //---------------------------------------------
        private void LimpiarCajas()
        {
            this.btnPuntos.Enabled = true;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoEliminar.Enabled = false;
            this.toolStripBtoGuardar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = false;
            this.toolStripBtoAgregar.Enabled = true;
            this.btoBuscar.Enabled = true;
            //----gridview-----------------
            dgvCostos.Rows.Clear();
            dGvPrecios.Rows.Clear();
            dGvStock.Rows.Clear();
            dGvStock2.Rows.Clear();
            ColumnaCostos();
            //-----------------------------    
            cboUnidadesFiltradas.Items.Clear();
            cboUnidad.Items.Clear();
            txtDescripcion.Clear();
            txtCategoria.Clear();
            txtSubCatg.Clear();
            txtCodigo.Clear();
            txtModelo.Clear();
            txtSerial.Clear();
            txtDias.Clear();
            txtNom.Clear();
            txtCod.Clear();
            //---------------------------------
            rbtoRedondearPreImpuesto.Checked = false;
            cboTipoArt.SelectedItem = null;
            cboUnidad.SelectedItem = null;
            cboUnidad.SelectedItem = null;
            rbtoUtilidad.Checked = false;
            //----------------------------------
            dgvAsociarProv.Rows.Clear();
            CBIva.Checked = false;
            CBLote.Checked = false;
        }
        private void ValidarCajas()
        {
            error = false;
            errPv.Clear();
            //--------------tab 1-----------------
            if (cboTipoArt.Text == "Servicio")
            {
                txtModelo.Text = "N/A";
                txtSerial.Text = "N/A"; 
                txtDias.Text = "N/A";
                cboUnidad.Text = "N/A";
                cboUnidadesFiltradas.Text = "N/A";
            }
            else if (cboTipoArt.Text != "Servicio")
            {

                if (txtNom.Text == "")
                {
                    errPv.SetError(txtNom, "Item Vacío");
                    error = true;
                }
                if (txtDias.Text == "")
                {
                    errPv.SetError(txtDias, "Item Vacío");
                    error = true;
                }
                if (txtModelo.Text == "")
                {
                    errPv.SetError(txtModelo, "Item Vacío");
                    error = true;
                }
                if (txtSerial.Text == "")
                {
                    errPv.SetError(txtSerial, "Item Vacío");
                    error = true;
                }

                if (txtCategoria.Text == "")
                {
                    errPv.SetError(txtCategoria, "Item Vacío");
                    error = true;
                }
                if (txtSubCatg.Text == "")
                {
                    errPv.SetError(txtSubCatg, "Item Vacío");
                    error = true;
                }
                //if (txtCostoProve.Text == "")
                //{
                //    errPv.SetError(txtCostoProve, "Item Vacío");
                //    error = true;
                //}
                if (cboUnidad.Text == "")
                {
                    errPv.SetError(cboUnidad, "Item Vacío");
                    error = true;
                }
                if (cboUnidadesFiltradas.Text == "")
                {
                    errPv.SetError(cboUnidadesFiltradas, "Item Vacío");
                    error = true;
                }
            }

            if(CBIva.Checked == false)
            {
                iva = 0;
            }
            else if (CBIva.Checked == true)
            {
                iva = 1;
            }
            if (CBLote.Checked == false)
            {
                lote = 0;
            }
            else if (CBLote.Checked == true)
            {
                lote = 1;
            }
        }
        public void FuncionEliminar()
        {
            if (dgvCostos.RowCount != 0 || dGvPrecios.RowCount != 0 || dGvStock.RowCount != 0 || dGvStock2.RowCount != 0)
            {
                mensajeCaption = StringResources.ValidacióndeEliminación;
                MessageBox.Show(StringResources.NoSePuedeEliminarCedulaPro + " " + txtCod.Text + " " + StringResources.msjRegistroAsociados,
                mensajeCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.DeseaEliminarCeduladeProducto;
                mensajeCaption = StringResources.ValidacióndeEliminación;

                DialogResult respuesta;

                respuesta = MessageBox.Show("¿" + mensajeText + " " +
                txtDescripcion.Text.ToString().Trim() + " ?", mensajeCaption,
                MessageBoxButtons.YesNo);

                if (respuesta == DialogResult.Yes)
                {
                    string msj = "";
                    M.m_cod = txtCodigo.Text;
                    msj = M.EliminarArticulos(frmPrincipal.nombreBD);
                    if (msj == "No se puede eliminar")
                    {
                        mensajeText = "No es posible eliminar, ya que existen registros asociados a este articulo";
                        mensajeCaption = StringResources.ValidacióndeEliminación;
                        MessageBox.Show(mensajeText, mensajeCaption,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (msj == "Eliminacion exitosa")
                    {
                        mensajeText = StringResources.DBEliminacionexitosa;
                        mensajeCaption = StringResources.ValidacióndeEliminación;
                        MessageBox.Show(mensajeText, mensajeCaption,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    LimpiarCajas();
                    FuncionInicio();
                }
            }
        }
        public void FuncionEditar()
        {
            accion = "editar";
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoGuardar.Enabled = true;
            this.toolStripBtoEliminar.Enabled = false;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            //
            this.btoBuscar.Enabled = false;
            this.btnPuntos.Enabled = false;
            this.txtCodigo.Enabled = false;
            this.txtCodArt.Enabled = false;
            this.txtCod.Enabled = false;
            //
            this.cboUnidadesFiltradas.Enabled = true;
            this.txtDescripcion.Enabled = true;
            this.txtCategoria.Enabled = true;
            this.txtSubCatg.Enabled = true;
            this.cboTipoArt.Enabled = true;
            this.btoSubCatg.Enabled = true;
            this.cboUnidad.Enabled = true;
            this.txtSerial.Enabled = true;
            this.txtModelo.Enabled = true;
            this.txtDias.Enabled = true;
            this.btoCatg.Enabled = true;
            this.txtNom.Enabled = true;
        }
        //-------------------------------------------------------------------------FILTRADO DE UNIDADES listo-------------------------------------------------------------------------------
        public void CargarUnidades()
        {
            dt = M.ListarUnidadesEstandarMVL("MITCore");//vall
        }
        private void CargarcboUnidades()
        {
            this.cboUnidad.Items.Clear();
            this.cboCodUnidad.Items.Clear();
            CargarUnidades();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cboCodUnidad.Items.Add(dt.Rows[i]["UniEstandar_Cod"].ToString());
                cboUnidad.Items.Add(dt.Rows[i]["UniEstandar_Desc"].ToString());
            }
        }
        public void CargarCboFriltado()
        {
            this.cboUnidadesFiltradas.Items.Clear();
            this.cboCodUnidFiltro.Items.Clear();

            CargarUnidadesFiltrado();
            if (accion == "ejecutar")
            {
                if (CargarUE == "")
                {
                    cboUnidad.Text = "";
                    cboUnidadesFiltradas.Text = "";
                    return;
                }
                else
                {
                    cboUnidad.SelectedIndex = Convert.ToInt32(CargarUE);
                }
            }
            if (cboUnidad.SelectedIndex == 0)
            {
                for (int i = 0; i < dtUM.Rows.Count; i++)
                {
                    cboCodUnidFiltro.Items.Add(dtUM.Rows[i]["UnidDes_codUni"].ToString());
                    cboUnidadesFiltradas.Items.Add(dtUM.Rows[i]["UnidDes_Descripcion"].ToString());
                }
                if (accion == "ejecutar")
                {
                    for (int i = 0; i < cboUnidadesFiltradas.Items.Count; i++)
                    {
                        string comparar = dtUM.Rows[i]["UnidDes_codUni"].ToString();
                        if (CargarUD == comparar)
                        {
                            cboUnidadesFiltradas.SelectedIndex = i;
                            return;
                        }
                    }
                }
            }
            if (cboUnidad.SelectedIndex == 1)
            {
                for (int i = 0; i < dtUV.Rows.Count; i++)
                {
                    cboCodUnidFiltro.Items.Add(dtUV.Rows[i]["UnidDes_codUni"].ToString());
                    cboUnidadesFiltradas.Items.Add(dtUV.Rows[i]["UnidDes_Descripcion"].ToString());
                }
                if (accion == "ejecutar")
                {

                    for (int i = 0; i < cboUnidadesFiltradas.Items.Count; i++)
                    {
                        string comparar = dtUV.Rows[i]["UnidDes_codUni"].ToString();
                        if (CargarUD == comparar)
                        {
                            cboUnidadesFiltradas.SelectedIndex = i;
                            return;
                        }
                    }
                }
            }
            if (cboUnidad.SelectedIndex == 2)
            {
                for (int i = 0; i < dtUL.Rows.Count; i++)
                {
                    cboCodUnidFiltro.Items.Add(dtUL.Rows[i]["UnidDes_codUni"].ToString());
                    cboUnidadesFiltradas.Items.Add(dtUL.Rows[i]["UnidDes_Descripcion"].ToString());
                }
                if (accion == "ejecutar")
                {
                    for (int i = 0; i < cboUnidadesFiltradas.Items.Count; i++)
                    {
                        string comparar = dtUL.Rows[i]["UnidDes_Descripcion"].ToString();
                        if (CargarUD == comparar)
                        {
                            cboUnidadesFiltradas.SelectedIndex = i;
                            return;
                        }
                    }
                }
            }
        }
        public void CargarUnidadesFiltrado()//filtrado
        {
            dtUM = M.ListarUnidadesDeMasa("MITCore");
            dtUV = M.ListarUnidadesDeVolumen("MITCore");
            dtUL = M.ListarUnidadesDeLongitud("MITCore");
        }
        public void CargarDescripStan()
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                codU = dt.Rows[i]["UniEstandar_Cod"].ToString().ToLower();
                if (codU == CargarUE)
                {
                    CargarDesc = dt.Rows[i]["UniEstandar_Desc"].ToString();
                    return;
                }
            }
        }
        //
        private void cboUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cboCodUnidad.SelectedIndex = this.cboUnidad.SelectedIndex;
            if (accion == "agregar" || accion == "editar")
            {
                CargarCboFriltado();
            }
        }
        private void cboUnidadesFiltradas_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCodUnidFiltro.SelectedIndex = cboUnidadesFiltradas.SelectedIndex;
        }
        //----------------------------------------------------------BOTONES (BTO)----------------------------------------------------------------------------------------------
        private void btoSalir_Click(object sender, EventArgs e)
        {
            formActivo = "";
            this.Close();
        }
        private void btoLinea_Click(object sender, EventArgs e)
        {
            ventTbCategoria = new frmTbCategoria();
            ventTbCategoria.pasado += new frmTbCategoria.pasar(ejecutarCag);
            ventTbCategoria.ShowDialog();
        }
        private void btoSubLinea_Click(object sender, EventArgs e)
        {
            formActivo = "activo";
            codCategoria = txtCodCatg.Text;
            venTbSucCatg = new frmTbSubCateg();
            venTbSucCatg.pasado += new frmTbSubCateg.pasar(ejecutarSub);
            venTbSucCatg.ShowDialog();
        }
        private void btoProveedor_Click(object sender, EventArgs e)
        {
            ventTbProvedores = new frmTbProveedores();
            ventTbProvedores.pasado += new frmTbProveedores.pasar(Ejecutar);
            ventTbProvedores.ShowDialog();
        }
        //-------------------------------------------------------------TOOLSTRIP-------------------------------------------------------------------------------------------
        private void toolStripBtoAgregar_Click(object sender, EventArgs e)
        {
            accion = "agregar";
            FuncionAgregar();
        }
        private void toolStripBtoDescartar_Click(object sender, EventArgs e)
        {
            FuncionInicio();
        }
        private void toolStripBtoGuardar_Click(object sender, EventArgs e)
        {
            FuncionGuardar();
        }
        private void toolStripBtoEditar_Click(object sender, EventArgs e)
        {
            accion = "editar";
            FuncionEditar();
        }
        private void toolStripBtoEliminar_Click(object sender, EventArgs e)
        {
            FuncionEliminar();
        }
        //---------------------------------------------------------------------bto puntos-----------------------------------------------------------------------------------
        private void btnPuntos_Click(object sender, EventArgs e)
        {
            valido = "si";
            ventTbArticulos = new frmTbArticulos();
            ventTbArticulos.pasado += new frmTbArticulos.pasar(Ejecutar);
            ventTbArticulos.Show();
            valido = "";
        }
        public void Ejecutar(string[,] dato)
        {
            accion = "ejecutar";
            this.toolStripBtoEditar.Enabled = true;
            this.toolStripBtoEliminar.Enabled = true;
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            this.btoBuscar.Enabled = false;
            this.cboCodUnidFiltro.Enabled = false;
            //
            txtCodigo.Text = dato[0, 0];
            txtCod.Text = dato[0, 0];
            txtNom.Text = dato[0, 1];
            txtDescripcion.Text = dato[0, 1];
            txtDias.Text = dato[0, 2];
            txtModelo.Text = dato[0, 3];
            //
            CargarUE = dato[0, 5];
            CargarDescripStan();
            cboCodUnidad.Text = CargarDesc;
            //
            CargarUD = dato[0, 6];
            CargarCboFriltado();
            //
            txtCategoria.Text = dato[0, 8];
            txtSubCatg.Text = dato[0, 9];
            txtSerial.Text = dato[0, 11];
            iva = Convert.ToInt16(dato[0, 12]);
            lote = Convert.ToInt16(dato[0, 13]);
            ValidarCheckBox();

            this.btoSubCatg.Enabled = false;
           // ItemAsociados(); 
        }
        
        public void ValidarCheckBox()
        {
            if (iva == 1)
            {
                CBIva.Checked = true;
            }
            else
            {
                CBIva.Checked = false;
            }
            if (lote == 1)
            {
                CBLote.Checked = true;
            }
            else
            {
                CBLote.Checked = false;
            }

        }

        public void ItemAsociados()
        {
            dgvAsociarProv.Rows.Clear();
            dgvAsociarProv.Enabled = true;

            for (int i = 0; i < dgvAsociarProv.Rows.Count; i++)
            {
                DtActualProv.Rows.Add();
                DtActualProv.Rows[b]["ProvId"] = dgvAsociarProv.Rows[i].Cells[0].ToString();
            }
        }
        //------------------------------------------------------CBO--------------------------------------------------------------------------------------------------
        private void cboUnidadCedulaProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cboCodUnidFiltro.SelectedIndex = this.cboUnidadesFiltradas.SelectedIndex;
            this.dGvStock2.Rows[0].Cells[0].Value = this.cboUnidad.Text;
        }
        
        private void cboTipoArt_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cboCodArt.SelectedIndex = this.cboTipoArt.SelectedIndex;
            if (cboTipoArt.Text == "Servicio")
            {
                txtModelo.Enabled = false;
                txtSerial.Enabled = false;
                txtDias.Enabled = false;
                cboUnidad.Enabled = false;
                cboUnidadesFiltradas.Enabled = false;
            }
        }
        
        private void cboCodArt_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtCodArt.Text = this.cboCodArt.Text;
        }
        //---------------------------------------------Cajas de Texto-------------------------TXT----------------------------------------------------------------------------------
        private void txtCodCatg_TextChanged(object sender, EventArgs e)
        {
            codCategoria = txtCodCatg.Text;
        }
        private void txtCod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || (e.KeyChar >= 97 && e.KeyChar <= 122) || (e.KeyChar >= 65 && e.KeyChar <= 90) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void txtDias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtMedida_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumeros(e);
        }
        private void txtLinea_TextChanged(object sender, EventArgs e)
        {
            categoria = txtCategoria.Text;
            if (txtCategoria.Text != "" || txtCategoria.Text != null)
            {
                btoSubCatg.Enabled = true;
            }
            else
            {
                btoSubCatg.Enabled = false;
            }
        }
        //------------------------------------------------DGV EVENTOS--------------------------------------------------------------------------------------------------------
        private void dGvStock2_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            Decimal valor2;
            if (dGvStock2.Columns[e.ColumnIndex].Name == "Comprometidos" || dGvStock2.Columns[e.ColumnIndex].Name == "PorDespachar")
            {
                valor = Decimal.Parse(dGvStock2.Rows[0].Cells[2].Value.ToString());
                valor2 = Decimal.Parse(dGvStock2.Rows[0].Cells[4].Value.ToString());
                disponible = Decimal.Parse(dGvStock2.Rows[0].Cells[1].Value.ToString());
                valor2 = valor + valor2;

                if (valor2 < disponible)
                {
                    disponible = disponible - valor2;
                    dGvStock2.Rows[0].Cells[5].Value = disponible;
                }
                else
                {
                    //pendiente
                }
            }
        }
        private void dGvStock2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox)
            {
                TextBox tb = e.Control as TextBox;
                tb.KeyPress += new KeyPressEventHandler(tbc_KeyPress);
            }
        }
        private void dGvStock_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox)
            {
                TextBox tb = e.Control as TextBox;
                tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
            }
        }
        private void dgvAsociarProv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 1)
            {
                valido = "Art-Prov";
                ventTbProvedores = new frmTbProveedores();
                ventTbProvedores.dtRelProv += new frmTbProveedores.relacion(CargarDatosProv);
                ventTbProvedores.ShowDialog();
                valido = "";
            }
        }
        private void btoBuscar_Click(object sender, EventArgs e)
        {

        }
        public void CargarDatosProv(DataTable dtProveedor)
        {
            accion = "pasado";
            if (frmArticulos.valido == "Art-Prov")
            {
                Proveedores = M.Listado_Proveedores(frmPrincipal.nombreBD);
                if (Proveedores.Rows.Count > 0)
                {
                    a = 0;
                    for (int i = 0; i < dtProveedor.Rows.Count; i++)
                    {
                        this.dgvAsociarProv.Rows.Add
                            (
                            dtProveedor.Rows[i]["codigo"].ToString(),
                            "...",
                            dtProveedor.Rows[i]["descripcion"].ToString()
                            );
                    }
                }
                else
                {
                    mensajeText = "ESTE MENSAJE ES TEMPORAL No existen proveedores registrados";
                    mensajeCaption = StringResources.Validacióndecampos;
                    MessageBox.Show(mensajeText, mensajeCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }
        //------------------------------------------------------Cargar Datos--------------------------------------------------------------------------------------------------
       
        private void CargarCodigos()
        {
            dtc = M.ListadoCodigos(frmPrincipal.nombreBD);
            for (int i = 0; i < dtc.Rows.Count; i++)
            {
                cboTipoArt.Items.Add(dtc.Rows[i]["CodArt_Descrip"].ToString());
                cboCodArt.Items.Add(dtc.Rows[i]["CodArt_Cod"].ToString());
            }
        }
        private void Cargar_MonedasAsociadasSuc()       //monedas asociadas por sucursal
        {
            dtm = M.Listado_monedas();
        }
        //------------------------------------------------------------------Eventos--------------------------------------------------------------------------------------
        void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)))
            {
                if (e.KeyChar != '\b') //allow the backspace key

                {
                    e.Handled = true;
                }
            }
        }
        void tbc_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarNumeros(e);
        }
        //-----------------------------------------------------------ACCION EJECUTAR---------------------------------------------------------------------------------------------
        public void ejecutarCag(string[,] dato)
        {
            txtCodCatg.Text = dato[0, 0];
            txtCategoria.Text = dato[0, 1];
            btoSubCatg.Enabled = true;
        }
        public void ejecutarSub(string[,] dato)
        {
            txtCodSCatg.Text = dato[0, 0];
            txtSubCatg.Text = dato[0, 1];
        }
        //-------------------------------------------------------------------------------------------------------------------------------
        void ValidarNumeros(KeyPressEventArgs e)
        {
            Boolean valor;
            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;
            if (char.IsNumber(e.KeyChar) || e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator
                || e.KeyChar == 8)
            {
                e.Handled = false;
            }
           
            else
            {
                e.Handled = true;
            }
        }
        private void ColumnaCostos()
        {
            dgvCostos.Rows.Add("Costo Proveedor", 0, 0.00);
            dgvCostos.Rows.Add("Otros Costos", 0.00, 0.00);
            dgvCostos.Rows.Add("Costo Calculado", 0.00, 0.00);
            dgvCostos.Rows.Add("Ultimo Costo", 0.00, 0.00);
            dgvCostos.Rows.Add("Costo Promedio", 0.00, 0.00);
            //****************************
            dGvPrecios.Rows.Add("Maximo", 0.00, 0.00);
            dGvPrecios.Rows.Add("Oferta", 0.00, 0.00);
            dGvPrecios.Rows.Add("Mayor", 0.00, 0.00);
            dGvPrecios.Rows.Add("Minimo", 0.00, 0.00);
            //*****************************
            dGvStock.Rows.Add("Stock", 0, 0.00);
            dGvStock.Rows.Add("Dias de inventario", 0.00, 0.00);
            dGvStock.Rows.Add("Tiempo de Despacho", 0.00, 0.00);
            dGvStock.Rows.Add("Punto de Pedido", 0.00, 0.00);
            dGvStock.Rows.Add("Punto de Reorden", 0.00, 0.00);
            //
            dGvStock2.Rows.Add(0, 0, 0, 0, 0, 0);
        }
        private void frmArticulos_FormClosed(object sender, FormClosedEventArgs e)
        {
            formActivo = "";
        }
        //------------------------------------------------IDIOMA-------------------------------------------------------------------------------
        public void AplicarIdioma()
        {
            this.Text = StringResources.Articulos;
            this.lblTituloPanel.Text = StringResources.Articulos;
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
            this.lblCod.Text = StringResources.Codigo;
            this.lblCodigo.Text = StringResources.Codigo;
            this.lblDescripcion.Text = StringResources.Descripcion;
            this.lblNom.Text = StringResources.Descripcion;
            this.lblModelo.Text = StringResources.Modelo;
            this.lblSerial.Text = StringResources.Serial;
            this.lblCategoria.Text = StringResources.Categoria;
            this.lblSubCategoria.Text = StringResources.SubCategoria;
            this.lblUnidad.Text = StringResources.Unidad;
            //this.lblCantidad.Text = StringResources.Cantidad;
            //this.lblCostoPro.Text = StringResources.CostoProveedor;
            //this.lblProcedencia.Text = StringResources.Procedencia;
            //this.lblIvaCom.Text = StringResources.IVAcompra;
            //this.lblIvaVent.Text = StringResources.IvaVenta;
            //this.lblTipoRedon.Text = StringResources.TipodeRedondeo;
            //this.lblPrecioV.Text = StringResources.PreciodeVenta_;
            //
            this.tPgCostosyPrecios.Text = StringResources.CostoyPrecio;
            this.lblMetodoCosto.Text = StringResources.SeleccioneElMetodoDeCosto;
            this.Costos.HeaderText = StringResources.Costo;
            this.SinImpuesto.HeaderText = StringResources.SinImpuesto;
            this.conImpuesto.HeaderText = StringResources.ConImpuesto;
            //
            this.rbtoUtilidad.Text = StringResources.Tomar_utilidad;
            this.rbtoRedondearPreImpuesto.Text = StringResources.RedondearPreciosconImpuestos;
            this.lblConfigurarDesc.Text = StringResources.ConfigurarDescuento_;
            this.precios2.HeaderText = StringResources.Precios;
            this.conImpuesto2.HeaderText = StringResources.ConImpuesto;
            this.sinImpuesto2.HeaderText = StringResources.SinImpuesto;
            //
            this.tpgStock.Text = StringResources.Stock;
            this.lblDefinicionStock.Text = StringResources.DefinicióndeStocks;
            this.stock.HeaderText = StringResources.Stock;
            this.Minima1.HeaderText = StringResources.Minima;
            this.Maxima1.HeaderText = StringResources.Maxima;
            //
            this.lblStatArticulo.Text = StringResources.EstatusdeArtículo;
            this.Unidad.HeaderText = StringResources.Unidad;
            this.CantUnidades.HeaderText = StringResources.Actual;
            this.Comprometidos.HeaderText = StringResources.Comprometidos;
            this.PorAdquirir.HeaderText = StringResources.PorAdquirir;
            this.PorDespachar.HeaderText = StringResources.PorDespachar;

            //
            this.tpgAsociarProve.Text = StringResources.AsociarProveedor;
            this.Codigo.HeaderText = StringResources.Codigo;
            this.Nombre.HeaderText = StringResources.Nombre;
            this.ultCompra.HeaderText = StringResources.UltimaFechadeCompra;
            this.CostoUni.HeaderText = StringResources.CostoUnitario;
            this.CantComprada.HeaderText = StringResources.UltimaCantidadComprada;
            //
        }
        //--------------------------------
        private void actualizarDtProv()
        {
            DtActualProv.Rows.Clear();
            {
                for (int i = 0; i < dgvAsociarProv.Rows.Count; i++)
                {
                    DtActualProv.Rows.Add();
                    DtActualProv.Rows[i]["ProvId"] = dgvAsociarProv.Rows[i].Cells[0].ToString();
                }
            }
            return;
        }
        private void dtActuales()
        {
            DtActualProv = new DataTable();
            DtActualProv.Columns.Add("ProvId", Type.GetType("System.String"));
        }
    }
}
