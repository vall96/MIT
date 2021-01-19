using System;
using System.Data;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using CapaLogicaNegocios;
using CultureResources;

namespace CapaPresentacion
{
    public partial class frmCedulaDeProducto : Form
    {
        clsEmpresa EMP = new clsEmpresa();
        DataTable dt = new DataTable();
        // VENTANAS
        frmTbCedulaProductos ventTbCedulaProducto;
        frmTbArticulosdeProduccion VentTbProductos;
        frmTbTareas VentTbTareas;
        //
        Boolean validar = true;
        DateTime fecha = DateTime.UtcNow;
        //
        public static string accion = "";
        public static string estado = "", valido = "";
        public static int cont = 0, cont1 = 0, cont2 = 0, cont3 = 0, cont4 = 0;
        string CodCedula = "", tareaCod = "";
        //
        public static int b = 0, d = 0, j = 0, a = 0, p = 0, c = 0, la = 0;
        public static int pos = 0, posAtr = 0, posGF = 0, posPE = 0, posART = 0;
        //
        int unidadValidar = 0;
        string unidad = "", id = "", CodGf = "", CodPE = "", CodAt = "";
        public string Unidad;
        //
        bool dgvCheck = false;
        //
        ListViewItem lvrow;
        DialogResult respuesta;
        //
        public string mensajeText = "", mensajeCaption = "", tipoPais = "";
        public string codigo = "", descripcion = "", Valor = "";
        // variables para cargar CBO Friltrados al caga datos desde la base de datos
        public string Estandar, CargarDesc, CargarUE, CargarUD, codU, idUD;
        string limpiar = ""; // limpiar CBO FILTRO
        //----------------------------------------------------
        public static DataTable DtActualTar = new DataTable();
        public static DataTable DtActualPerf = new DataTable();
        public static DataTable DtActualGastFabr = new DataTable();
        public static DataTable DtActualAtrib = new DataTable();
        public static DataTable DtActualArt = new DataTable();
        //
        frmTbPerfilesEmpleados VentPerfEmpleado;
        frmTbGastosFabrica VentGastFab;
        frmTbAtributos VentAtrib;
        frmTbArticulos VentArticulos;
        //
        DataTable dtAt = new DataTable();
        DataTable dtGF = new DataTable();
        DataTable dtPE = new DataTable();
        //
        DataTable dtArt = new DataTable();
        DataTable dtArtUni = new DataTable();
        DataTable dtCed = new DataTable();
        //DT PARA CARGAR UNIDADES AL CBO FRILTADO
        DataTable dtUT = new DataTable();
        DataTable dtUV = new DataTable();
        DataTable dtUM = new DataTable();
        DataTable dtUL = new DataTable();
        //
        DataTable dtCeP = new DataTable();
        DataTable dtUniDes = new DataTable();
        //--------------------------------------------------------
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
            public static void SoloLetrasyNumeros(KeyPressEventArgs N)
            {
                if (Char.IsLetterOrDigit(N.KeyChar))
                {
                    N.Handled = false;
                }
                else if (Char.IsControl(N.KeyChar))
                {
                    N.Handled = false;
                }
                else if (Char.IsSeparator(N.KeyChar))
                {
                    N.Handled = false;
                }
                else
                {
                    N.Handled = true;
                }
            }
            public static void SoloLetrasyNumerosSinEspacios(KeyPressEventArgs N)
            {
                if (Char.IsLetterOrDigit(N.KeyChar))
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
            public static void SoloLetras(KeyPressEventArgs N)
            {
                if (Char.IsLetter(N.KeyChar))
                {
                    N.Handled = false;
                }
                else if (Char.IsControl(N.KeyChar))
                {
                    N.Handled = false;
                }
                else if (Char.IsSeparator(N.KeyChar))
                {
                    N.Handled = false;
                }
                else
                {
                    N.Handled = true;
                }
            }
        }
        public frmCedulaDeProducto()
        {
            InitializeComponent();
            dtActuales();
            FuncionInicio();

        }
        private void frmCedulaDeProducto_Load(object sender, EventArgs e)
        {
            CargarCbo();
            CargarcboArt();
           // CargarCboFriltado();
            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();

            this.Location = new System.Drawing.Point(0, 0);
            ventTbCedulaProducto = new frmTbCedulaProductos();
        }
        //----------------------------------------------------------------------------------
        public void CargarUnidadesArt()
        {
            dtArtUni = EMP.ListarUnidadesDeLongitud("MITCore");
        }
        public void CargarUnidades()
        {
            dtCed = EMP.ListarUnidadesEstandarMVL("MITCore"); //filtrado
        }
        public void CargarCbo()
        {
            this.cboUnidadCedulaProd.Items.Clear();
            CargarUnidades();
            for (int i = 0; i < dtCed.Rows.Count; i++)
            {
                cboCodUnidadCedulaProd.Items.Add(dtCed.Rows[i]["UniEstandar_Cod"].ToString());
                cboUnidadCedulaProd.Items.Add(dtCed.Rows[i]["UniEstandar_Desc"].ToString());
            }
        }
        public void CargarcboArt()
        {
            this.CBOUnidadDGV.Items.Clear();
            CargarUnidadesArt();
            for (int i = 0; i < dtArtUni.Rows.Count; i++)
            {
                CBOUnidadDGV.Items.Add(dtArtUni.Rows[i]["UnidDes_Descripcion"].ToString());
            }
        }

        //-------------------------------------------------------------------------------------------------------------
        private void frmCedulaDeProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (accion == "inicio")
            {
                if (e.KeyCode == Keys.F5)
                {
                    FuncionAgregar();
                }
            }
            else if (accion == "editar")
            {
                if (e.KeyCode == Keys.F6)
                {
                    accion = "editar";
                    FuncionEditar();
                }
            }
            else if (accion == "agregar" || accion == "editar")
            {
                if (e.KeyCode == Keys.F7)
                {
                    FuncionGuardar();
                }
            }
            else if (accion == "editar")
            {
                if (e.KeyCode == Keys.F8)
                {
                    FuncionEliminar();
                }
            }
            if (e.KeyCode == Keys.F9)
            {
                limpiarCajas();
                FuncionInicio();
            }
        }
        private void cboUnidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCodUnidadCedulaProd.SelectedIndex = cboUnidadCedulaProd.SelectedIndex;
            CargarCboFriltado();
        }
        public void CargarUnidadesFiltrado()//filtrado
        {
            dtUM = EMP.ListarUnidadesDeMasa("MITCore"); 
        //    dtUT = EMP.ListarUnidadesDeTiempo("MITCore");
            dtUV = EMP.ListarUnidadesDeVolumen("MITCore");
            dtUL = EMP.ListarUnidadesDeLongitud("MITCore");
        }
     
        public void CargarCboFriltado()
        {
            this.cboUnidadesFiltradas.Items.Clear();
            this.cboCodUnidFriltro.Items.Clear();

            CargarUnidadesFiltrado();
            if (accion == "ejecutar")
            {
                cboCodUnidadCedulaProd.SelectedIndex = Convert.ToInt32(Estandar);
            }
            if (cboCodUnidadCedulaProd.SelectedIndex == 0)
            {
                for (int i = 0; i < dtUM.Rows.Count; i++)
                {
                    cboCodUnidFriltro.Items.Add(dtUM.Rows[i]["UnidDes_codUni"].ToString());
                    cboUnidadesFiltradas.Items.Add(dtUM.Rows[i]["UnidDes_Descripcion"].ToString());
                }
            }
            if (cboCodUnidadCedulaProd.SelectedIndex == 1)
            {
                for (int i = 0; i < dtUV.Rows.Count; i++)
                {
                    cboCodUnidFriltro.Items.Add(dtUV.Rows[i]["UnidDes_codUni"].ToString());
                    cboUnidadesFiltradas.Items.Add(dtUV.Rows[i]["UnidDes_Descripcion"].ToString());
                }
            }
            if (cboCodUnidadCedulaProd.SelectedIndex == 2)
            {
                for (int i = 0; i < dtUL.Rows.Count; i++)
                {
                    cboCodUnidFriltro.Items.Add(dtUL.Rows[i]["UnidDes_codUni"].ToString());
                    cboUnidadesFiltradas.Items.Add(dtUL.Rows[i]["UnidDes_Descripcion"].ToString());
                }
            }
            //if (cboCodUnidadCedulaProd.SelectedIndex == 3)
            //{
            //    for (int i = 0; i < dtUT.Rows.Count; i++)
            //    {
            //        cboCodUnidFriltro.Items.Add(dtUT.Rows[i]["UnidDes_codUni"].ToString());
            //        cboUnidadesFiltradas.Items.Add(dtUT.Rows[i]["UnidDes_Descripcion"].ToString());
            //    }
            //}

            if (accion == "ejecutar")
            {
                if (Estandar == "0")
                {
                    for (int i = 0; i < cboUnidadesFiltradas.Items.Count; i++)
                    {
                        string comparar = dtUM.Rows[i]["UnidDes_Descripcion"].ToString();
                        if (CargarUD == comparar)
                        {
                            cboUnidadesFiltradas.SelectedIndex = i;
                            return;
                        }
                    }
                }
                if (Estandar == "1")
                {
                    for (int i = 0; i < cboUnidadesFiltradas.Items.Count; i++)
                    {
                        string comparar = dtUV.Rows[i]["UnidDes_Descripcion"].ToString();
                        if (CargarUD == comparar)
                        {
                            cboUnidadesFiltradas.SelectedIndex = i;
                            return;
                        }
                    }
                }
              
                if (Estandar == "2")
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
                //if (Estandar == "3")
                //{
                //    for (int i = 0; i < cboUnidadesFiltradas.Items.Count; i++)
                //    {
                //        string comparar = dtUT.Rows[i]["UnidDes_Descripcion"].ToString();
                //        if (CargarUD == comparar)
                //        {
                //            cboUnidadesFiltradas.SelectedIndex = i;
                //            return;
                //        }
                //    }
                //}
            }
        }

        //-----------------------------------funciones------------------------------------------------
        private void FuncionInicio()
        {
            accion = "inicio";
            this.btnPuntos.Enabled = true;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoEliminar.Enabled = false;
            this.toolStripBtoGuardar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = false;
            this.toolStripBtoAgregar.Enabled = true;
            this.btoBuscar.Enabled = true;

            this.txtCod.Enabled = false;
            this.txtDescrip.Enabled = false;
            this.txtDescrip.Enabled = false;
            this.dTpFecha.Enabled = false;
            this.txtProducto.Enabled = false;
            this.txtCantidad.Enabled = false;
            this.txtDuracion.Enabled = false;

            this.cboUnidadCedulaProd.Enabled = false;
            this.btoPuntosProdructos.Enabled = false;

            this.cboUnidadCedulaProd.Items.Clear();
            CargarCbo();

            if (txtCodigo.Text == "" || txtDescripcion.Text == "")
            {
                txtCodigo.Enabled = true;
                txtDescripcion.Enabled = true;
            }

            this.txtDescripcion.Focus();
            this.txtCodigo.Focus();

            RbDias.Enabled = false;
            RbHoras.Enabled = false;

            this.lsvTareasProd.Enabled = false;
            this.btnAsociarTar.Enabled = false;
            this.btnEliminarTar.Enabled = false;

            this.lsvTareasProd.CheckBoxes = false;
            lsvAtributos.CheckBoxes = false;
            lsvGastosdeFabrica.CheckBoxes = false;
            lsvPerfilEmpleado.CheckBoxes = false;

            lsvAtributos.Enabled = false;
            btnEliminarAtrib.Enabled = false;
            btnAsociarAtrib.Enabled = false;

            lsvGastosdeFabrica.Enabled = false;
            btnAsociarGastFab.Enabled = false;
            btnEliminarGastFab.Enabled = false;

            lsvPerfilEmpleado.Enabled = false;
            btnAsociarPerf.Enabled = false;
            btnEliminarPerf.Enabled = false;
            //
            BtoEliminarArticulos.Enabled = false;
            BtoAsociarArticulos.Enabled = false;
            DgvArticulos.Enabled = false;
            cboUnidadesFiltradas.Enabled = false;
            pos = 0;
            posART = 0;
            posAtr = 0;
            posGF = 0;
            posPE = 0;
            this.dTpFecha.Value = DateTime.Now;

        }
        public void FuncionEditar()
        {
            accion = "editar";
            this.btnPuntos.Enabled = false;
            this.btoPuntosProdructos.Enabled = false;
            this.txtDescripcion.Enabled = false;
            this.txtCodigo.Enabled = false;

            this.cboUnidadCedulaProd.Enabled = true;
            this.cboCodUnidadCedulaProd.Visible = false;

            this.txtCod.Focus();
            this.txtCod.Enabled = false;
            this.txtDescrip.Enabled = true;
            this.txtProducto.Enabled = false;
            this.dTpFecha.Enabled = false;
            this.txtCantidad.Enabled = true;
            this.txtDuracion.Enabled = true;

            this.toolStripBtoGuardar.Enabled = true;
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoEliminar.Enabled = false;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            this.btoBuscar.Enabled = false;

            RbDias.Enabled = true;
            RbHoras.Enabled = true;

            this.lsvTareasProd.Enabled = true;
            this.btnAsociarTar.Enabled = true;
            this.btnEliminarTar.Enabled = true;

            this.btnEliminarPerf.Enabled = true; //2020
            this.btnEliminarGastFab.Enabled = true;
            this.btnEliminarAtrib.Enabled = true;
            this.BtoEliminarArticulos.Enabled = true;


            this.btnAsociarPerf.Enabled = true; //2020
            this.btnAsociarGastFab.Enabled = true;
            this.btnAsociarAtrib.Enabled = true;

            lsvTareasProd.CheckBoxes = true;

            //2020 Valerie
            lsvAtributos.CheckBoxes = true;
            lsvGastosdeFabrica.CheckBoxes = true;
            lsvPerfilEmpleado.CheckBoxes = true;
            //
            BtoAsociarArticulos.Enabled = true;
          
            DgvArticulos.Enabled = true;
            ColCheck.Visible = true;

            cboUnidadesFiltradas.Enabled = true;
            //
            DgvArticulos.Columns[1].ReadOnly = false;
            DgvArticulos.Columns[2].ReadOnly = false;
            DgvArticulos.Columns[3].ReadOnly = false;
            DgvArticulos.Columns[4].ReadOnly = false;

        }
        public void FuncionAgregar()
        {
            this.btnPuntos.Enabled = false;
            accion = "agregar";
            limpiarCajas();

            this.txtDescripcion.Enabled = false;
            this.txtCodigo.Enabled = false;
            this.btoPuntosProdructos.Enabled = true;
            this.cboUnidadCedulaProd.Enabled = true;
            this.cboCodUnidadCedulaProd.Visible = false;

            this.txtCod.Focus();
            this.txtCod.Enabled = true;
            this.txtDescrip.Enabled = true;
            this.dTpFecha.Enabled = true;
            this.txtProducto.Enabled = false;
            this.txtCantidad.Enabled = true;
            this.txtDuracion.Enabled = true;

            this.toolStripBtoGuardar.Enabled = true;
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoEliminar.Enabled = false;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            this.btoBuscar.Enabled = false;

            fecha = dTpFecha.Value.Date;
            fecha.ToShortDateString();

            RbDias.Enabled = true;
            RbHoras.Enabled = true;
            //------------------------------2020--------------------
            this.lsvTareasProd.Enabled = true;
            this.btnAsociarTar.Enabled = true;
            this.btnEliminarTar.Enabled = true;

            lsvAtributos.Enabled = true;
            btnEliminarAtrib.Enabled = true;
            btnAsociarAtrib.Enabled = true;

            lsvGastosdeFabrica.Enabled = true;
            btnAsociarGastFab.Enabled = true;
            btnEliminarGastFab.Enabled = true;

            lsvPerfilEmpleado.Enabled = true;
            btnAsociarPerf.Enabled = true;
            btnEliminarPerf.Enabled = true;

            this.lsvTareasProd.CheckBoxes = true;

            if (this.lsvTareasProd.Items.Count == 0)
            {
                btnEliminarTar.Enabled = false;
            }

            //2020 Valerie
            lsvAtributos.CheckBoxes = true;
            lsvGastosdeFabrica.CheckBoxes = true;
            lsvPerfilEmpleado.CheckBoxes = true;

            if (this.lsvAtributos.Items.Count == 0)
            {
                btnEliminarAtrib.Enabled = false;
            }

            if (this.lsvGastosdeFabrica.Items.Count == 0)
            {
                btnEliminarGastFab.Enabled = false;
            }

            if (this.lsvPerfilEmpleado.Items.Count == 0)
            {
                btnEliminarPerf.Enabled = false;
            }
            if (this.DgvArticulos.Rows.Count == 0)
            {
                BtoEliminarArticulos.Enabled = false;
            }
            //
            ColCheck.Visible = true;
            BtoAsociarArticulos.Enabled = true;
            DgvArticulos.Enabled = true;
            cboUnidadesFiltradas.Enabled = true;

            DgvArticulos.Columns[1].ReadOnly = false;
            DgvArticulos.Columns[2].ReadOnly = false;
            DgvArticulos.Columns[3].ReadOnly = false;
            DgvArticulos.Columns[4].ReadOnly = false;
        }
        public void FuncionGuardar()
        {
            DgvArticulos.EndEdit();
            string msj = "";
            if (accion == "agregar" || accion == "editar")
            {
                ValidadCampos();
                ValidarRadioBtn();
                if (validar == false)
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
                    mensajeText = StringResources.ExistenCamposVacios;
                    mensajeCaption = StringResources.ValidaciondeRegistro;
                    MessageBox.Show(mensajeText, mensajeCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    validar = true;
                    if (this.txtCod.Text == "")
                    {
                        this.txtCod.Focus();
                        return;
                    }
                    else if (this.txtDescrip.Text == "")
                    {
                        this.txtDescrip.Focus();
                        return;
                    }
                    else
                    if (lsvTareasProd.Items.Count == 0 || this.lsvPerfilEmpleado.Items.Count == 0
                       || this.lsvGastosdeFabrica.Items.Count == 0 || this.lsvAtributos.Items.Count == 0)
                    {
                        mensajeText = StringResources.AsociarItem;
                        mensajeCaption = StringResources.Validacióndecampos;
                        MessageBox.Show(mensajeText, mensajeCaption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    ConstruccionDt();
                    if (accion == "agregar")
                    {
                        EMP.m_codCedulaProd = txtCod.Text;
                        EMP.m_DescripCedulaProd = txtDescrip.Text;
                        EMP.m_CantidadCedulaProd = txtCantidad.Text;
                        EMP.m_DuracionCedulaProd = txtDuracion.Text;
                        EMP.m_UnidadCedulaProd = cboCodUnidFriltro.Text;
                        EMP.m_FechaCedulaProd = fecha;
                        EMP.m_DuracionHoraDiaCedulaProd = Valor;
                        EMP.m_ProductoCedulaProd = txtProducto.Text;
                        EMP.m_DescripUnidades = cboCodUnidadCedulaProd.Text;

                        msj = EMP.RegistarCedulaProducto(frmPrincipal.nombreBD);

                        if (msj == "Ya existe")
                        {
                            Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
                            mensajeText = StringResources.YaExisteElRegistro;
                            mensajeCaption = StringResources.Validacióndecampos;

                            MessageBox.Show(mensajeText + " " + txtCod.Text.Trim(), mensajeCaption,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                            txtCod.Focus();
                            return;
                        }
                        else if (msj == "Registro Exitoso")
                        {
                            cargarRelacion();
                            cargarRelacionAtrib();
                            cargarRelacionPerfEmple();
                            cargarRelacionGastFab();
                            CargarRelacionArticulos();

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
                        limpiarCajas();
                        FuncionInicio();
                    }
                   
                }
            }

            if (accion == "editar")
            {
                if (frmTbCedulaProductos.estado == "valido")
                {
                    EMP.m_codCedulaProd = txtCod.Text;
                    EMP.m_DescripCedulaProd = txtDescrip.Text;
                    EMP.m_CantidadCedulaProd = txtCantidad.Text;
                    EMP.m_DuracionCedulaProd = txtDuracion.Text;
                    EMP.m_UnidadCedulaProd = cboCodUnidFriltro.Text;
                    EMP.m_DuracionHoraDiaCedulaProd = Valor;
                    EMP.m_DescripUnidades = cboCodUnidadCedulaProd.Text;

                    msj = EMP.ActualizarCedulaProducto(frmPrincipal.nombreBD);

                    if (msj == "Actualizacion Exitos")
                    {
                        cargarRelacion();
                        cargarRelacionAtrib();
                        cargarRelacionPerfEmple();
                        cargarRelacionGastFab();
                        CargarRelacionArticulos();

                        Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
                        mensajeText = StringResources.DBActualizacionExitosa;
                        mensajeCaption = StringResources.frmUsuarioEstiloPrueba_TituloValidacionDeActualizacion;

                        MessageBox.Show(mensajeText, mensajeCaption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                    limpiarCajas();
                }
                FuncionInicio();
            }
        }
        public void FuncionBuscar()
        {
            accion = "buscar";
            if (txtCodigo.Text == "" && txtDescripcion.Text == "")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.ExistenCamposVacios;
                mensajeCaption = StringResources.Validacióndecampos;

                MessageBox.Show(mensajeText, mensajeCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                this.txtCodigo.Focus();
                return;
            }
            else if (txtCodigo.Text != "" && txtDescripcion.Text != "")
            {
                mensajeText = StringResources.No_se_puede_realizar_la_busqueda_con_todos_los_campos_llenos;
                mensajeCaption = StringResources.Validacióndecampos;

                MessageBox.Show(mensajeText, mensajeCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                this.txtCodigo.Focus();
                return;
            }
            else
            if (txtCodigo.Text != "")
            {
                codigo = txtCodigo.Text;
                descripcion = "";
                ventTbCedulaProducto.ValidarBuscar(codigo, descripcion);
            }
            else
            {
                codigo = "";
                descripcion = txtDescripcion.Text;
                ventTbCedulaProducto.ValidarBuscar(codigo, descripcion);
            }
            if (frmTbCedulaProductos.estado == "Valido")
            {
                txtCod.Text = frmTbCedulaProductos._codigo;
                txtCodigo.Text = frmTbCedulaProductos._codigo;
                txtDescrip.Text = frmTbCedulaProductos._descripcion;
                txtDescripcion.Text = frmTbCedulaProductos._descripcion;
                txtProducto.Text = frmTbCedulaProductos._producto;
                cboUnidadCedulaProd.Text = frmTbCedulaProductos._unidad;
                txtDuracion.Text = frmTbCedulaProductos._duracion;

                if (frmTbCedulaProductos._horaDia == "Días")
                {
                    RbDias.Checked = true;
                    RbHoras.Checked = false;
                }
                else if (frmTbCedulaProductos._horaDia == "Horas")
                {
                    RbDias.Checked = false;
                    RbHoras.Checked = true;
                }

                txtCantidad.Text = frmTbCedulaProductos._cantidad;

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

                this.txtCodigo.Focus();
                limpiarCajas();
            }
        }
        public void FuncionEliminar()
        {
            if (lsvAtributos.Items.Count != 0 || lsvTareasProd.Items.Count != 0 || lsvPerfilEmpleado.Items.Count != 0 || lsvGastosdeFabrica.Items.Count != 0 || DgvArticulos.Rows.Count != 0)
            {
                mensajeCaption = StringResources.ValidacióndeEliminación;
                MessageBox.Show(StringResources.NoSePuedeEliminarCedulaPro + " " + txtCod.Text + " " +StringResources.msjRegistroAsociados,
                mensajeCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (frmTbCedulaProductos.estado == "valido")
            {
                string msj = "";

                Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.DeseaEliminarCeduladeProducto;
                mensajeCaption = StringResources.ValidacióndeEliminación;

                DialogResult respuesta;

                respuesta = MessageBox.Show("¿" + mensajeText + " " +
                txtDescrip.Text.ToString().Trim() + " ?", mensajeCaption,
                MessageBoxButtons.YesNo);

                if (respuesta == DialogResult.Yes)
                {
                    mensajeCaption = StringResources.ValidacióndeEliminación;
                    EMP.m_codCedulaProd = txtCod.Text.ToString().Trim();
                    msj = EMP.EliminarCedulaProducto(frmPrincipal.nombreBD);

                    if (msj == "Eliminacion exitosa")
                    {
                        mensajeText = StringResources.DBEliminacionexitosa;
                        mensajeCaption = StringResources.ValidacióndeEliminación;
                        MessageBox.Show(mensajeText, mensajeCaption,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    limpiarCajas();
                    FuncionInicio();
                }
            }
        }
        public void HabilitarBotones()
        {
            this.toolStripBtoEditar.Enabled = true;
            this.toolStripBtoEliminar.Enabled = true;
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            this.btoBuscar.Enabled = false;

            lsvAtributos.CheckBoxes = false;
            lsvGastosdeFabrica.CheckBoxes = false;
            lsvPerfilEmpleado.CheckBoxes = false;
        }
        private void limpiarCajas()
        {
            this.txtCodigo.Clear();
            this.txtDescripcion.Clear();

            this.txtCod.Clear();
            this.txtDescrip.Clear();
            this.cboUnidadCedulaProd.Text = "";
            cboUnidadesFiltradas.SelectedIndex = -1;

            this.txtProducto.Clear();
            this.txtCantidad.Clear();
            this.txtDuracion.Clear();

            this.lsvTareasProd.Items.Clear();
            this.lsvAtributos.Items.Clear();
            this.lsvGastosdeFabrica.Items.Clear();
            this.lsvPerfilEmpleado.Items.Clear();

            RbDias.Checked = false;
            RbHoras.Checked = false;
            //
            this.DgvArticulos.Enabled = false;
            this.DgvArticulos.Rows.Clear();
        }
        public void ValidadCampos()
        {
            if (this.txtCod.Text == "")
            {
                validar = false;
                txtCod.Focus();
            }
            if (this.txtDescrip.Text == "")
            {
                validar = false;
            }
            if (this.txtDuracion.Text == "")
            {
                validar = false;
            }
            if (this.txtCantidad.Text == "")
            {
                validar = false;
            }
            if (this.txtProducto.Text == "")
            {
                validar = false;
            }
            if (this.dTpFecha.Text == "")
            {
                validar = false;
            }
            if (this.cboUnidadCedulaProd.Text == "")
            {
                validar = false;
            }
            if (this.lsvTareasProd.Items.Count == 0)
            {
                validar = false;
            }
            if (this.lsvPerfilEmpleado.Items.Count == 0)
            {
                validar = false;
            }
            if (this.lsvGastosdeFabrica.Items.Count == 0)
            {
                validar = false;
            }
            if (this.lsvAtributos.Items.Count == 0)
            {
                validar = false;
            }
            return;
        }

        //----------------------------------------------------------------
        private void cargarRelacion()            //antes de enviar dt a la bd, debo saber si la relacion //a guardar ya existe, y agregar solo las nuevas                                           
        {
            CodCedula = txtCod.Text;
            if (lsvTareasProd.Items.Count > 0)
            {
                j = 0;
                if (accion == "agregar")
                {
                    pos = 0;
                }
                for (int i = pos; i < lsvTareasProd.Items.Count; i++)
                {
                    tareaCod = lsvTareasProd.Items[i].SubItems[0].Text.ToString();
                    dt.Rows.Add();
                    dt.Rows[j]["CedTarea_IdCedProd"] = txtCod.Text;
                    dt.Rows[j]["CedTarea_IdTarea"] = lsvTareasProd.Items[i].SubItems[0].Text.ToString();
                    j++;
                }
                if (j != 0)
                {
                    EMP.registar_CedulaTarea(dt, frmPrincipal.nombreBD);
                }
                j = 0;
            }

        }
        private void cargarRelacionGastFab()
        {
            ConstruccionDtGastFab();
            if (lsvGastosdeFabrica.Items.Count > 0)
            {
                j = 0;
                if (accion == "agregar")
                {
                    posGF = 0;
                }
                for (int i = posGF; i < lsvGastosdeFabrica.Items.Count; i++)
                {
                    CodGf = lsvGastosdeFabrica.Items[i].SubItems[0].Text.ToString();
                    dtGF.Rows.Add();
                    dtGF.Rows[j]["cedula_CedulaID"] = txtCod.Text;
                    dtGF.Rows[j]["cedula_GastFabId"] = lsvGastosdeFabrica.Items[i].SubItems[0].Text.ToString();
                    j++;
                }
                if (j != 0)
                {
                    EMP.registar_CedulaGastFab(dtGF, frmPrincipal.nombreBD);
                }
                j = 0;
            }

        } //2020
        private void cargarRelacionPerfEmple()
        {
            ConstruccionDtPerfEmpl();
            if (accion == "agregar")
            {
                posPE = 0;
            }
            if (lsvPerfilEmpleado.Items.Count > 0)
            {
                j = 0;
                for (int i = posPE; i < lsvPerfilEmpleado.Items.Count; i++)
                {
                    CodPE = lsvPerfilEmpleado.Items[i].SubItems[0].Text.ToString();
                    dtPE.Rows.Add();
                    dtPE.Rows[j]["cedula_CedulaID"] = txtCod.Text;
                    dtPE.Rows[j]["cedula_perfilID"] = lsvPerfilEmpleado.Items[i].SubItems[0].Text.ToString();
                    j++;
                }
                if (j != 0)
                {
                    EMP.registar_CedulaPerfEmpl(dtPE, frmPrincipal.nombreBD);
                }
                j = 0;
            }

        }
        private void cargarRelacionAtrib()
        {
            ConstruccionDtAtrib();
            if (accion == "agregar")
            {
                posAtr = 0;
            }
            if (lsvAtributos.Items.Count > 0)
            {
                j = 0;
                for (int i = posAtr; i < lsvAtributos.Items.Count; i++)
                {
                    CodAt = lsvAtributos.Items[i].SubItems[0].Text.ToString();
                    dtAt.Rows.Add();
                    dtAt.Rows[j]["cedula_CedulaID"] = txtCod.Text;
                    dtAt.Rows[j]["cedula_AtribId"] = lsvAtributos.Items[i].SubItems[0].Text.ToString();
                    j++;
                }
                if (j != 0)
                {
                    EMP.registar_CedulaAtrib(dtAt, frmPrincipal.nombreBD);
                }
                j = 0;
            }
        }
        private void CargarRelacionArticulos()
        {
            j = 0;
            ConstruccionDtArtic();
           
            if (DgvArticulos.Rows.Count >= 1)
            {
                for (int i = posART; i < DgvArticulos.Rows.Count; i++)
                {
                    unidadValidar = 0;

                    unidad = DgvArticulos.Rows[i].Cells[3].Value.ToString().ToLower();
                    CargarCodigoUnidad();

                    dtArt.Rows.Add();
                    dtArt.Rows[j]["CedArt_CedulaID"] = txtCod.Text;
                    dtArt.Rows[j]["CedArt_ArticuloId"] = DgvArticulos.Rows[i].Cells[1].Value.ToString();
                    dtArt.Rows[j]["CedArt_CodUnidad"] = id;
                    dtArt.Rows[j]["CedArt_CantUnidad"] = Convert.ToInt16(DgvArticulos.Rows[i].Cells[4].Value);

                    j++;
                }

                if (j != 0)
                {
                    EMP.RegistrarCedulaProArticulo(dtArt, frmPrincipal.nombreBD);
                }

                if (accion == "editar")
                {
                    j = 0;
                    ConstruccionDtArtic();
                    for (int i = 0; i < DgvArticulos.Rows.Count; i++)
                    {
                        unidadValidar = 0;

                        unidad = DgvArticulos.Rows[i].Cells[3].Value.ToString().ToLower();
                        CargarCodigoUnidad();

                        dtArt.Rows.Add();
                        dtArt.Rows[j]["CedArt_CedulaID"] = txtCod.Text;
                        dtArt.Rows[j]["CedArt_ArticuloId"] = DgvArticulos.Rows[i].Cells[1].Value.ToString();
                        dtArt.Rows[j]["CedArt_CodUnidad"] = id;
                        dtArt.Rows[j]["CedArt_CantUnidad"] = Convert.ToInt32(DgvArticulos.Rows[i].Cells[4].Value);

                        j++;
                    }
                    if (j != 0)
                    {
                        EMP.ActualizarCedArtic(dtArt, frmPrincipal.nombreBD);
                    }
                }
            }
        }
        public void CargarCodigoUnidad()
        {
            string cargarUni;
            if (unidadValidar == 1)
            {
                for (int i = 0; i < dtArtUni.Rows.Count; i++)
                {
                    cargarUni = dtArtUni.Rows[i]["UnidDes_codUni"].ToString().ToLower();
                    if (cargarUni == Unidad)
                    {
                        id = dtArtUni.Rows[i]["UnidDes_Descripcion"].ToString();
                        return;
                    }
                }
            }

            else if (unidadValidar == 0)
            {
                if (DgvArticulos.Rows.Count != 0)
                {
                    for (int n = 0; n < dtArtUni.Rows.Count; n++)
                    {
                        cargarUni = dtArtUni.Rows[n]["UnidDes_Descripcion"].ToString().ToLower();
                        if (cargarUni == unidad)
                        {
                            id = dtArtUni.Rows[n]["UnidDes_codUni"].ToString();
                            return;
                        }
                    }
                }
            }
        }

        //---------------------------------------------PUNTOS --------------------------------------
        private void btoPuntosProdructos_Click(object sender, EventArgs e)
        {
            valido = "si";
            accion = "agregar";
            VentTbProductos = new frmTbArticulosdeProduccion();
            VentTbProductos.pasado += new frmTbArticulosdeProduccion.pasar(ejecutar);
            VentTbProductos.ShowDialog();
            valido = "";
        }
        private void btnPuntos_Click(object sender, EventArgs e)
        {
            valido = "si";
            ventTbCedulaProducto = new frmTbCedulaProductos();
            ventTbCedulaProducto.pasado += new frmTbCedulaProductos.pasar(ejecutar);
            ventTbCedulaProducto.ShowDialog();
            valido = "";
            accion = "pasado";
            if (accion == "pasado")
            {
                ColCheck.Visible = false;
                //DgvArticulos.Enabled = false;
                DgvArticulos.Columns[1].ReadOnly = true;
                DgvArticulos.Columns[2].ReadOnly = true;
                DgvArticulos.Columns[3].ReadOnly = true;
                DgvArticulos.Columns[4].ReadOnly = true;
            }
        }
        //------------------------------------ btos ------------------------------------------
        private void toolStripBtoGuardar_Click(object sender, EventArgs e)
        {
            FuncionGuardar();
        }
        private void toolStripBtoDescartar_Click(object sender, EventArgs e)
        {
            limpiarCajas();
            FuncionInicio();
        }
        private void toolStripBtoEliminar_Click(object sender, EventArgs e)
        {
            FuncionEliminar();
        }
        private void toolStripBtoAgregar_Click(object sender, EventArgs e)
        {
            accion = "agregar";
            FuncionAgregar();
        }
        private void toolStripBtoEditar_Click(object sender, EventArgs e)
        {
            accion = "editar";
            FuncionEditar();
        }
        //
        private void btoSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btoBuscar_Click(object sender, EventArgs e)
        {
            FuncionBuscar();
            ItemsAsociados();
        }
        //---------------------------------EVENTOS-------------------------------------------------------
        private void txtDuracion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
        }
        private void txtCod_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetrasyNumerosSinEspacios(e);
        }
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e) //Evento para Cantidad, CantMax, CantMin
        {
            Validar.SoloNumeros(e);
        }
        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetrasyNumeros(e);
        }
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                FuncionBuscar();
            }
            else if ((e.KeyChar >= 48 && e.KeyChar <= 57) || (e.KeyChar >= 97 && e.KeyChar <= 122) || (e.KeyChar >= 65 && e.KeyChar <= 90) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                FuncionBuscar();
            }
        }
        //------------------------------------------fecha------------------------------------------------
        private void dTpFecha_ValueChanged(object sender, EventArgs e)
        {
            fecha = dTpFecha.Value.Date;
            fecha.ToShortDateString();
        }
        //---------------------------------------btoEliminar       f---------------------------------------------------------
        private void btnEliminarTarea_Click(object sender, EventArgs e)
        {
            if (lsvTareasProd.CheckedItems.Count > 0)
            {
                this.btnEliminarTar.Enabled = true;
            }
            else
            {
                this.btnEliminarTar.Enabled = false;
            }

            eliminarLsvTarea();
        }
        private void btnEliminarAtrib_Click(object sender, EventArgs e)
        {
            eliminarLsvAtrb();
        }//2020
        private void btnEliminarGastFab_Click(object sender, EventArgs e)
        {
            eliminarLsvGastosFab();
        }
        private void btnEliminarPerf_Click(object sender, EventArgs e)
        {
            eliminarLsvPerfEmp();
        }
        public void BtoEliminarArticulos_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow fila in DgvArticulos.Rows)
            {
                if (Convert.ToBoolean(fila.Cells["ColCheck"].Value) == true)
                {
                    BtoEliminarArticulos.Enabled = true;
                    eliminarDgvArt();
                }

            }
            BtoEliminarArticulos.Enabled = false;
        }
        //-----------------------------------------------------------------------------------------------
        private void lsvGastosdeFabrica_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvGastosdeFabrica.Items.Count == 0)
            {
                btnEliminarGastFab.Enabled = false;
            }
        }
        private void lsvPerfilEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvPerfilEmpleado.Items.Count == 0)
            {
                btnEliminarPerf.Enabled = false;
            }
        }
        private void lsvAtributos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvAtributos.Items.Count == 0)
            {
                btnEliminarAtrib.Enabled = false;
            }
        }
        //-*-------------------------------------------------------------------------------------------
        private void btnAsociarMaq_Click(object sender, EventArgs e)
        {
            valido = "si";
            cont = lsvTareasProd.Items.Count;
            VentTbTareas = new frmTbTareas();
            VentTbTareas.DtRelTbTareas += new frmTbTareas.relacion(CedulaProdTareas);
            VentTbTareas.ShowDialog();
            valido = "";
        }
        private void btnAsociarGastFab_Click(object sender, EventArgs e)
        {
            valido = "si";
            cont3 = lsvGastosdeFabrica.Items.Count;
            VentGastFab = new frmTbGastosFabrica();
            VentGastFab.dtRelGastosFrab += new frmTbGastosFabrica.relacion(CedulaGastos);
            VentGastFab.ShowDialog();
            valido = "";
        } //2020
        private void btnAsociarAtrib_Click(object sender, EventArgs e)
        {
            valido = "si";
            cont2 = lsvAtributos.Items.Count;
            VentAtrib = new frmTbAtributos();
            VentAtrib.dtRelAtributos += new frmTbAtributos.relacion(CedulaAtributos);
            VentAtrib.ShowDialog();
            valido = "";
        }
        private void btnAsociarPerf_Click(object sender, EventArgs e)
        {
            valido = "si";
            cont1 = lsvPerfilEmpleado.Items.Count;
            VentPerfEmpleado = new frmTbPerfilesEmpleados();
            VentPerfEmpleado.dtRelPerfilEmp += new frmTbPerfilesEmpleados.relacion(CedulaPerfilEmpl);
            VentPerfEmpleado.ShowDialog();
            valido = "";
        }
        private void BtoAsociarArticulos_Click(object sender, EventArgs e)
        {
            valido = "si";
            cont4 = DgvArticulos.Rows.Count;
            VentArticulos = new frmTbArticulos();
            VentArticulos.dtRelArtic += new frmTbArticulos.relacion(CedulaArticulos);
            VentArticulos.ShowDialog();
            valido = "";
        }
        //---------------------------------------------------------------------------------------------
        private void lsvTareasProd_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (lsvTareasProd.CheckedItems.Count > 0)
            {
                this.btnEliminarTar.Enabled = true;
            }
            else
            {
                this.btnEliminarTar.Enabled = false;
            }
        }
        private void lsvPerfilEmpleado_ItemChecked(object sender, ItemCheckedEventArgs e) //2020
        {
            if (lsvPerfilEmpleado.CheckedItems.Count > 0)
            {
                this.btnEliminarPerf.Enabled = true;
                this.btnAsociarPerf.Enabled = true;
            }
            else
            {
                this.btnEliminarPerf.Enabled = false;
                this.btnAsociarPerf.Enabled = true;
            }
        }
        private void lsvGastosdeFabrica_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (lsvGastosdeFabrica.CheckedItems.Count > 0)
            {
                this.btnEliminarGastFab.Enabled = true;
            }
            else
            {
                this.btnEliminarGastFab.Enabled = false;
            }
        }
        private void lsvAtributos_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            //eliminarDgvArt();
            if (lsvAtributos.CheckedItems.Count > 0)
            {
                this.btnEliminarAtrib.Enabled = true;
            }
            else
            {
                this.btnEliminarAtrib.Enabled = false;
            }
        }
        private void DgvArticulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
          {
            DgvArticulos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            
            if (accion == "agregar" || accion == "editar")
            {
                foreach (DataGridViewRow fila in DgvArticulos.Rows)
                {
                    if (Convert.ToBoolean(fila.Cells["ColCheck"].Value) == true)
                    {
                        BtoEliminarArticulos.Enabled = true;
                        return;
                    }
                    else
                    {
                        BtoEliminarArticulos.Enabled = false;
                    }
                }
            }
        }

        private void cboCodUnidFriltro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboCodUnidadCedulaProd_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //
        private void dtActuales()
        {
            DtActualTar = new DataTable();
            DtActualTar.Columns.Add("TareaId", Type.GetType("System.String"));

            DtActualPerf = new DataTable();
            DtActualPerf.Columns.Add("PerfilId", Type.GetType("System.String"));

            DtActualGastFabr = new DataTable();
            DtActualGastFabr.Columns.Add("GastFabId", Type.GetType("System.String"));

            DtActualAtrib = new DataTable();
            DtActualAtrib.Columns.Add("AtributoId", Type.GetType("System.String"));

            DtActualArt = new DataTable();
            DtActualArt.Columns.Add("ArticuloId", Type.GetType("System.String"));
        }
        private void ItemsAsociados()
        {
            EMP.codigo = txtCod.Text.ToUpper();

            dt = EMP.ListarCedulaTarea(frmPrincipal.nombreBD);

            dtAt = EMP.ListarCedulaAtrib(frmPrincipal.nombreBD); //2020 
            dtGF = EMP.ListarCedulaGastosFab(frmPrincipal.nombreBD);
            dtPE = EMP.ListarCedulaPerfilEmp(frmPrincipal.nombreBD);
            dtArt = EMP.ListarCedulaProArt(frmPrincipal.nombreBD); //2020 valerie

            lsvTareasProd.Items.Clear();
            lsvTareasProd.Enabled = true;

            lsvPerfilEmpleado.Items.Clear();
            lsvPerfilEmpleado.Enabled = true;

            lsvAtributos.Items.Clear();
            lsvAtributos.Enabled = true;

            lsvGastosdeFabrica.Items.Clear();
            lsvGastosdeFabrica.Enabled = true;

            DgvArticulos.Rows.Clear();
            DgvArticulos.Enabled = true;

            if (dt.Rows.Count > 0)
            {
                b = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DtActualTar.Rows.Add();
                    DtActualTar.Rows[b]["TareaId"] = dt.Rows[i]["CedTarea_IdTarea"].ToString();
                    lvrow = new ListViewItem(dt.Rows[i]["CedTarea_IdTarea"].ToString());
                    lvrow.SubItems.Add(dt.Rows[i]["Tareas_Descripcion"].ToString());
                    this.lsvTareasProd.Items.Add(lvrow);
                    b++;
                }
                pos = lsvTareasProd.Items.Count;
            }

            if (dtAt.Rows.Count > 0) //2020
            {
                c = 0;
                for (int i = 0; i < dtAt.Rows.Count; i++)
                {
                    DtActualAtrib.Rows.Add();
                    DtActualAtrib.Rows[c]["AtributoId"] = dtAt.Rows[i]["cedula_AtribId"].ToString();
                    lvrow = new ListViewItem(dtAt.Rows[i]["cedula_AtribId"].ToString());
                    lvrow.SubItems.Add(dtAt.Rows[i]["Atrib_descripcion"].ToString());
                    this.lsvAtributos.Items.Add(lvrow);
                    c++;
                }
                posAtr = lsvAtributos.Items.Count;
            }

            if (dtGF.Rows.Count > 0)
            {
                d = 0;
                for (int i = 0; i < dtGF.Rows.Count; i++)
                {
                    DtActualGastFabr.Rows.Add();
                    DtActualGastFabr.Rows[d]["GastFabId"] = dtGF.Rows[i]["cedula_GastFabId"].ToString();
                    lvrow = new ListViewItem(dtGF.Rows[i]["cedula_GastFabId"].ToString());
                    lvrow.SubItems.Add(dtGF.Rows[i]["GastosFab_descripcion"].ToString());
                    this.lsvGastosdeFabrica.Items.Add(lvrow);
                    d++;
                }
                posGF = lsvGastosdeFabrica.Items.Count;
            }

            if (dtPE.Rows.Count > 0)
            {
                p = 0;
                for (int i = 0; i < dtPE.Rows.Count; i++)
                {
                    DtActualPerf.Rows.Add();
                    DtActualPerf.Rows[p]["PerfilId"] = dtPE.Rows[i]["cedula_perfilID"].ToString();
                    lvrow = new ListViewItem(dtPE.Rows[i]["cedula_perfilID"].ToString());
                    lvrow.SubItems.Add(dtPE.Rows[i]["PerfilesEmp_Descripcion"].ToString());
                    this.lsvPerfilEmpleado.Items.Add(lvrow);
                    p++;
                }
                posPE = lsvPerfilEmpleado.Items.Count;
            }


            if (dtArt.Rows.Count > 0) //valerie
            {
                a = 0;
                unidadValidar = 1;

                DgvArticulos.Rows.Clear();
                DtActualArt.Rows.Clear();
                DgvArticulos.Columns[1].ReadOnly = true;
                DgvArticulos.Columns[2].ReadOnly = true;

                for (int i = 0; i < dtArt.Rows.Count; i++)
                {
                    Unidad = dtArt.Rows[i]["CedArt_CodUnidad"].ToString().ToLower();
                    CargarCodigoUnidad();

                    DgvArticulos.Rows.Add(dgvCheck,
                        dtArt.Rows[i]["CedArt_ArticuloId"].ToString(),
                        dtArt.Rows[i]["art_Nom"].ToString(),
                        "",
                        dtArt.Rows[i]["CedArt_CantUnidad"].ToString());

                    DgvArticulos.Rows[i].Cells["CBOUnidadDGV"].Value = id;

                    DtActualArt.Rows.Add();
                    DtActualArt.Rows[a]["ArticuloId"] = dtArt.Rows[i]["CedArt_ArticuloId"].ToString();
                }
                posART = DgvArticulos.Rows.Count;

                //this.DgvArticulos.AutoGenerateColumns = false;
                //n = DgvArticulos.Rows.Count - 1;
                //if (DgvArticulos.Rows.Count - 1 == n)
                //{
                //    DgvArticulos.AllowUserToAddRows = false;
                //}
            }
        }
        private void cboUnidadesFiltradas_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCodUnidFriltro.SelectedIndex = cboUnidadesFiltradas.SelectedIndex;
        }
        public void ejecutar(string[,] dato)
        {
            if (frmTbArticulosdeProduccion.ValidarPro == "si")
            {
                accion = "inicio"; // "agregar";
                txtProducto.Text = dato[0, 9];  //prueba
                valido = "";
            }
            else
            {
                accion = "editar";
                this.toolStripBtoEditar.Enabled = true;
                this.toolStripBtoEliminar.Enabled = true;
                this.toolStripBtoAgregar.Enabled = false;
                this.toolStripBtoDescartar.Enabled = true;
                this.btoBuscar.Enabled = false;

                if (dato[0, 4] == "Días")
                {
                    RbDias.Checked = true;
                    RbHoras.Checked = false;
                }
                else if (dato[0, 4] == "Horas")
                {
                    RbDias.Checked = false;
                    RbHoras.Checked = true;
                }
                Estandar = dato[0, 8];
                accion = "ejecutar";
                CargarUD = dato[0, 2];
                CargarCboFriltado();
                
                CargarUE = dato[0, 8];
                CargarDescripStan();
               
                txtCodigo.Text = dato[0, 0];
                txtCod.Text = dato[0, 0];
                txtDescripcion.Text = dato[0, 1];
                txtDescrip.Text = dato[0, 1];
                
                txtDuracion.Text = dato[0, 3];

                txtCantidad.Text = dato[0, 5];

                dTpFecha.Text = dato[0, 6];
                txtProducto.Text = dato[0, 9];
                cboUnidadCedulaProd.Text = CargarDesc;
                accion = "editar";
                ItemsAsociados();
            }
            //valido = "";

        }
        public void DgvArticulos_CurrentCellChanged(object sender, EventArgs e) // vaidacion de los datos editados en datagrid
        {
            if (DgvArticulos.CurrentCell is System.Windows.Forms.DataGridViewCheckBoxCell)
            {
                DgvArticulos.CommitEdit(DataGridViewDataErrorContexts.Commit); //permite guardar los cambios realizados en el DGV sin salir del modo edicion
            }
        }
        //----------------------------------------------------------------------
        private void ConstruccionDt()
        {
            dt.Rows.Clear();
            dt.Columns.Clear();
            dt.Columns.Add("CedTarea_IdCedProd", Type.GetType("System.String"));
            dt.Columns.Add("CedTarea_IdTarea", Type.GetType("System.String"));
        }
        private void ConstruccionDtPerfEmpl()
        {
            dtPE.Rows.Clear();
            dtPE.Columns.Clear();
            dtPE.Columns.Add("cedula_CedulaID", Type.GetType("System.String"));
            dtPE.Columns.Add("cedula_perfilID", Type.GetType("System.String"));
        } //2020
        private void ConstruccionDtGastFab()
        {
            dtGF.Rows.Clear();
            dtGF.Columns.Clear();
            dtGF.Columns.Add("cedula_GastFabId", Type.GetType("System.String"));
            dtGF.Columns.Add("cedula_CedulaID", Type.GetType("System.String"));
        }
        private void ConstruccionDtAtrib()
        {
            dtAt.Rows.Clear();
            dtAt.Columns.Clear();
            dtAt.Columns.Add("cedula_AtribId", Type.GetType("System.String"));
            dtAt.Columns.Add("cedula_CedulaID", Type.GetType("System.String"));
        }
        private void ConstruccionDtArtic()
        {
            dtArt.Rows.Clear();
            dtArt.Columns.Clear();
            dtArt.Columns.Add("CedArt_CedulaID", Type.GetType("System.String"));
            dtArt.Columns.Add("CedArt_ArticuloId", Type.GetType("System.String"));
            dtArt.Columns.Add("CedArt_CodUnidad", Type.GetType("System.String"));
            dtArt.Columns.Add("CedArt_CantUnidad", Type.GetType("System.String"));

        }

        //---------------------------------------------radio Button--------------------------------
        private void ValidarRadioBtn()
        {
            if (RbDias.Checked == true)
            {
                Valor = RbDias.Text.ToString();
            }
            else if (RbHoras.Checked == true)
            {
                Valor = RbHoras.Text.ToString();
            }
            else
            {
                mensajeText = StringResources.Debe_especificar_el_tipo_de_duracion;
                mensajeCaption = StringResources.Validacióndecampos;
                MessageBox.Show(mensajeText, mensajeCaption,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        public void cargarDatos()
        {
            txtProducto.Text = frmTbArticulosdeProduccion._DescripcionPro;
        }
        //---------------------------------------------2020----------------------
        private void actualizarDtTareas()
        {
            DtActualTar.Rows.Clear();
            {
                for (int i = 0; i < lsvTareasProd.Items.Count; i++)
                {
                    DtActualTar.Rows.Add();
                    DtActualTar.Rows[i]["TareaId"] = lsvTareasProd.Items[i].SubItems[0].Text.ToString();
                }
            }
            return;
        }
        private void actualizarDtAtrib()
        {
            DtActualAtrib.Rows.Clear();
            {
                for (int i = 0; i < lsvAtributos.Items.Count; i++)
                {
                    DtActualAtrib.Rows.Add();
                    DtActualAtrib.Rows[i]["AtributoId"] = lsvAtributos.Items[i].SubItems[0].Text.ToString();
                }
            }
        }//2020
        private void actualizarDtGastFabri()
        {
            DtActualGastFabr.Rows.Clear();
            {
                for (int i = 0; i < lsvGastosdeFabrica.Items.Count; i++)
                {
                    DtActualGastFabr.Rows.Add();
                    DtActualGastFabr.Rows[i]["GastFabId"] = lsvGastosdeFabrica.Items[i].SubItems[0].Text.ToString();
                }
            }
        }
        private void actualizarDtPerfil()
        {
            DtActualPerf.Rows.Clear();
            {
                for (int i = 0; i < lsvPerfilEmpleado.Items.Count; i++)
                {
                    DtActualPerf.Rows.Add();
                    DtActualPerf.Rows[i]["PerfilId"] = lsvPerfilEmpleado.Items[i].SubItems[0].Text.ToString();
                }
            }
        }
        private void ActualizarDtArticulos()
        {
            DtActualArt.Rows.Clear();
            {
                for (int i = 0; i < DgvArticulos.Rows.Count; i++)
                {
                    DtActualArt.Rows.Add();
                    DtActualArt.Rows[i]["ArticuloId"] = DgvArticulos.Rows[i].Cells[1].ToString();
                }
            }
        }
        //
        public void CedulaProdTareas(DataTable dtTareas)
        {
            b = lsvTareasProd.Items.Count;
            this.lsvTareasProd.Enabled = true;

            for (int i = 0; i < dtTareas.Rows.Count; i++)
            {
                DtActualTar.Rows.Add();
                DtActualTar.Rows[b]["TareaId"] = dtTareas.Rows[i]["codigo"].ToString();
                lvrow = new ListViewItem(dtTareas.Rows[i]["codigo"].ToString());
                lvrow.SubItems.Add(dtTareas.Rows[i]["descripcion"].ToString());
                this.lsvTareasProd.Items.Add(lvrow);
                b++;
            }
            this.toolStripBtoGuardar.Enabled = true;
            this.lsvTareasProd.CheckBoxes = true;
            valido = "";
        }
        public void CedulaPerfilEmpl(DataTable DtPerfilEmp)
        {
            p = lsvPerfilEmpleado.Items.Count;      //guardar pos para = cargar dt
            this.lsvPerfilEmpleado.Enabled = true;

            for (int a = 0; a < DtPerfilEmp.Rows.Count; a++)
            {
                DtActualPerf.Rows.Add();
                DtActualPerf.Rows[p]["PerfilId"] = DtPerfilEmp.Rows[a]["codigo"].ToString();
                lvrow = new ListViewItem(DtPerfilEmp.Rows[a]["codigo"].ToString());
                lvrow.SubItems.Add(DtPerfilEmp.Rows[a]["descripcion"].ToString());
                this.lsvPerfilEmpleado.Items.Add(lvrow);

                p++;
            }
            this.toolStripBtoGuardar.Enabled = true;
            this.lsvAtributos.CheckBoxes = true;
            valido = "";

        } //2020
        public void CedulaAtributos(DataTable dtAtributos)
        {
            c = lsvAtributos.Items.Count;
            this.lsvAtributos.Enabled = true;
            for (int a = 0; a < dtAtributos.Rows.Count; a++)
            {
                DtActualAtrib.Rows.Add();
                DtActualAtrib.Rows[c]["AtributoId"] = dtAtributos.Rows[a]["codigo"].ToString();
                lvrow = new ListViewItem(dtAtributos.Rows[a]["codigo"].ToString());
                lvrow.SubItems.Add(dtAtributos.Rows[a]["descripcion"].ToString());
                this.lsvAtributos.Items.Add(lvrow);
                c++;
            }
            this.toolStripBtoGuardar.Enabled = true;
            this.lsvAtributos.CheckBoxes = true;
            valido = "";
        }
        public void CedulaGastos(DataTable dtGastFabr)
        {
            d = lsvGastosdeFabrica.Items.Count;
            this.lsvGastosdeFabrica.Enabled = true;
            for (int i = 0; i < dtGastFabr.Rows.Count; i++)
            {
                DtActualGastFabr.Rows.Add();
                DtActualGastFabr.Rows[d]["GastFabId"] = dtGastFabr.Rows[i]["codigo"].ToString();
                lvrow = new ListViewItem(dtGastFabr.Rows[i]["codigo"].ToString());
                lvrow.SubItems.Add(dtGastFabr.Rows[i]["descripcion"].ToString());
                this.lsvGastosdeFabrica.Items.Add(lvrow);
                d++;
            }
            this.toolStripBtoGuardar.Enabled = true;
            this.lsvGastosdeFabrica.CheckBoxes = true;
            valido = "";
        }
        public void CedulaArticulos(DataTable dtArticulos)
        {
            la = DgvArticulos.Rows.Count;
            this.DgvArticulos.Enabled = true;
            for (int a = 0;    a < dtArticulos.Rows.Count; a++)
            {
                DtActualArt.Rows.Add();
                DtActualArt.Rows[la]["ArticuloId"] = dtArticulos.Rows[a]["codigo"].ToString();
                this.DgvArticulos.Rows.Add(
                     dgvCheck,
                     dtArticulos.Rows[a]["codigo"].ToString(),
                     dtArticulos.Rows[a]["descripcion"].ToString()
                     );

                la++;

            }
        }
        //
        private void eliminarLsvTarea()
        {
            if (accion == "agregar")
            {
                for (int i = pos; i < lsvTareasProd.Items.Count; i++)
                {
                    if (lsvTareasProd.Items[i].Checked == true)
                    {
                        lsvTareasProd.Items.RemoveAt(i);
                        i--;
                    }
                }
                actualizarDtTareas();
                return;
            }
            if (accion == "editar")
            {
                if (this.lsvTareasProd.CheckedItems.Count > 0)
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    mensajeText = StringResources.msjEliminarItems;
                    mensajeCaption = StringResources.ValidacióndeEliminación;
                    //
                    respuesta = MessageBox.Show(mensajeText,
                    mensajeCaption, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);
                    //
                    if (respuesta == DialogResult.Yes)
                    {
                        j = 0;
                        ConstruccionDt();
                        for (int i = 0; i < pos; i++)
                        {
                            if (lsvTareasProd.Items[i].Checked == true)
                            {
                                dt.Rows.Add();
                                dt.Rows[j]["CedTarea_IdCedProd"] = txtCod.Text;
                                dt.Rows[j]["CedTarea_IdTarea"] = lsvTareasProd.Items[i].SubItems[0].Text.ToString();
                                j++;
                                lsvTareasProd.Items.RemoveAt(i);
                                pos--;
                                i--;
                            }
                        }
                        //if (this.lsvTareasProd.CheckedItems.Count > 0)
                        //{
                        //    for (int i = pos; i < lsvTareasProd.Items.Count; i++)
                        //    {
                        //        if (lsvTareasProd.Items[i].Checked == true)
                        //        {
                        //            lsvTareasProd.Items.RemoveAt(i);
                        //            pos--;
                        //            i--;
                        //        }
                        //    }
                            actualizarDtTareas();
                       // }
                        if (j != 0)
                        {
                            EMP.eliminarTareaCedul(dt, frmPrincipal.nombreBD);

                            //mensajeText = StringResources.DBEliminacionexitosa;
                            //mensajeCaption = StringResources.frmRegistroUsuario_messValidacionCorrecta;

                            //MessageBox.Show(mensajeText, mensajeCaption,
                            //MessageBoxButtons.OK, MessageBoxIcon.Information);
                            actualizarDtTareas();
                        }
                    }
                }
            }
        }
        private void eliminarLsvPerfEmp()
        {
            if (accion == "agregar")
            {
                for (int i = posPE; i < lsvPerfilEmpleado.Items.Count; i++)
                {
                    if (lsvPerfilEmpleado.Items[i].Checked == true)
                    {
                        lsvPerfilEmpleado.Items.RemoveAt(i);
                        i--;
                    }
                }
                actualizarDtPerfil();
                return;
            }
            if (accion == "editar")
            {
                if (this.lsvPerfilEmpleado.CheckedItems.Count > 0)
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    mensajeText = StringResources.msjEliminarItems;
                    mensajeCaption = StringResources.ValidacióndeEliminación;

                    respuesta = MessageBox.Show(mensajeText,
                    mensajeCaption, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                    if (respuesta == DialogResult.Yes)
                    {
                        j = 0;
                        ConstruccionDtPerfEmpl();
                        for (int i = 0; i < posPE; i++)
                        {
                            if (lsvPerfilEmpleado.Items[i].Checked == true)
                            {
                                dtPE.Rows.Add();
                                dtPE.Rows[j]["cedula_CedulaID"] = txtCod.Text;
                                dtPE.Rows[j]["cedula_perfilID"] = lsvPerfilEmpleado.Items[i].SubItems[0].Text.ToString();
                                j++;
                                lsvPerfilEmpleado.Items.RemoveAt(i);
                                posPE--;
                                i--;
                            }
                        }
                        
                        if (j != 0)
                        {
                            EMP.eliminarCedulaPerfEmp(dtPE, frmPrincipal.nombreBD);

                            //mensajeText = StringResources.DBEliminacionexitosa;
                            //mensajeCaption = StringResources.frmRegistroUsuario_messValidacionCorrecta;

                            //MessageBox.Show(mensajeText, mensajeCaption,
                            //MessageBoxButtons.OK, MessageBoxIcon.Information);
                            actualizarDtPerfil();
                        }

                        if (this.lsvPerfilEmpleado.CheckedItems.Count > 0)
                        {
                            for (int i = posPE; i < lsvPerfilEmpleado.Items.Count; i++)
                            {
                                if (lsvPerfilEmpleado.Items[i].Checked == true)
                                {
                                    lsvPerfilEmpleado.Items.RemoveAt(i);
                                    posPE--;
                                    i--;
                                }
                            }
                            actualizarDtPerfil();
                        }
                    }
                }
            }
        }//2020
        private void eliminarLsvAtrb()
        {
            if (accion == "agregar")
            {
                for (int i = 0; i < lsvAtributos.Items.Count; i++)
                {
                    if (lsvAtributos.Items[i].Checked == true)
                    {
                        lsvAtributos.Items.RemoveAt(i);
                        i--;
                    }
                }
                actualizarDtAtrib();
            }
            if (accion == "editar")
            {

                if (this.lsvAtributos.CheckedItems.Count > 0)
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    mensajeText = StringResources.msjEliminarItems;
                    mensajeCaption = StringResources.ValidacióndeEliminación;
                    respuesta = MessageBox.Show(mensajeText,
                    mensajeCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                }
                if (respuesta == DialogResult.Yes)
                {
                    j = 0;
                    ConstruccionDtAtrib();
                    for (int i = 0; i < posAtr; i++)
                    {
                        if (lsvAtributos.Items[i].Checked == true)
                        {
                            dtAt.Rows.Add();
                            dtAt.Rows[j]["cedula_CedulaID"] = txtCod.Text;
                            dtAt.Rows[j]["cedula_AtribId"] = lsvAtributos.Items[i].SubItems[0].Text.ToString();
                            j++;
                            lsvAtributos.Items.RemoveAt(i);
                            posAtr--;
                            i--;
                        }
                    }
                    if (j != 0)
                    {
                        EMP.eliminarCedulaAtrib(dtAt, frmPrincipal.nombreBD);

                        //mensajeText = StringResources.DBEliminacionexitosa;
                        //mensajeCaption = StringResources.frmRegistroUsuario_messValidacionCorrecta;
                        //MessageBox.Show(mensajeText, mensajeCaption,
                        //MessageBoxButtons.OK, MessageBoxIcon.Information);
                        actualizarDtAtrib();
                    }
                }
                if (this.lsvAtributos.CheckedItems.Count > 0)
                {
                    for (int i = posAtr; i < lsvAtributos.Items.Count; i++)
                    {
                        if (lsvAtributos.Items[i].Checked == true)
                        {
                            lsvAtributos.Items.RemoveAt(i);
                            posAtr--;
                            i--;
                        }
                    }
                }
            }
        }
        private void eliminarLsvGastosFab()
        {
            if (accion == "agregar")
            {
                for (int i = 0; i < lsvGastosdeFabrica.Items.Count; i++)
                {
                    if (lsvGastosdeFabrica.Items[i].Checked == true)
                    {
                        lsvGastosdeFabrica.Items.RemoveAt(i);
                        i--;
                    }
                }
                actualizarDtGastFabri();
            }
            if (accion == "editar")
            {
                if (this.lsvGastosdeFabrica.CheckedItems.Count > 0)
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    mensajeText = StringResources.msjEliminarItems;
                    mensajeCaption = StringResources.ValidacióndeEliminación;
                    respuesta = MessageBox.Show(mensajeText, mensajeCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                }
                if (respuesta == DialogResult.Yes)
                {
                    j = 0;
                    ConstruccionDtGastFab();
                    for (int i = 0; i < posGF; i++)
                    {
                        if (lsvGastosdeFabrica.Items[i].Checked == true)
                        {
                            dtGF.Rows.Add();
                            dtGF.Rows[j]["cedula_CedulaID"] = txtCod.Text;
                            dtGF.Rows[j]["cedula_GastFabId"] = lsvGastosdeFabrica.Items[i].SubItems[0].Text.ToString();
                            j++;
                            lsvGastosdeFabrica.Items.RemoveAt(i);
                            posGF--;
                            i--;
                        }
                    }

                    if (j != 0)
                    {
                        EMP.eliminarCedulaGastFab(dtGF, frmPrincipal.nombreBD);

                        mensajeText = StringResources.DBEliminacionexitosa;
                        mensajeCaption = StringResources.frmRegistroUsuario_messValidacionCorrecta;
                        MessageBox.Show(mensajeText, mensajeCaption,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        actualizarDtAtrib();
                    }
                }

                if (this.lsvGastosdeFabrica.CheckedItems.Count > 0)
                {
                    for (int i = posGF; i < lsvGastosdeFabrica.Items.Count; i++)
                    {
                        if (lsvGastosdeFabrica.Items[i].Checked == true)
                        {
                            lsvGastosdeFabrica.Items.RemoveAt(i);
                            posGF--;
                            i--;
                        }
                    }
                }

            }
        }
        private void eliminarDgvArt()
        {
            if (accion == "agregar")
            {
                for (int i = 0; i < DgvArticulos.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(DgvArticulos.Rows[i].Cells["ColCheck"].Value) == true)
                    {
                        DgvArticulos.Enabled = true;
                        DgvArticulos.Rows.RemoveAt(i);
                        i--;
                    }
                }
                ActualizarDtArticulos();
            }
            if (accion == "editar")
            {
                for (int i = 0; i < DgvArticulos.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(DgvArticulos.Rows[i].Cells["ColCheck"].Value) == true)
                    {
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                        mensajeText = StringResources.msjEliminarItems;
                        mensajeCaption = StringResources.ValidacióndeEliminación;
                        respuesta = MessageBox.Show(mensajeText,
                        mensajeCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    }

                    if (respuesta == DialogResult.Yes)
                    {
                        j = 0;
                        ConstruccionDtArtic();
                        for (int a = 0; a < posART; a++)
                        {
                            if (Convert.ToBoolean(DgvArticulos.Rows[a].Cells["ColCheck"].Value) == true)
                            {
                                dtArt.Rows.Add();
                                dtArt.Rows[j]["CedArt_CedulaID"] = txtCod.Text;
                                dtArt.Rows[j]["CedArt_ArticuloId"] = DgvArticulos.Rows[a].Cells[1].Value.ToString();
                                dtArt.Rows[j]["CedArt_CodUnidad"] = DgvArticulos.Rows[a].Cells[3].Value.ToString();
                                dtArt.Rows[j]["CedArt_CantUnidad"] = DgvArticulos.Rows[a].Cells[4].Value.ToString();
                                j++;
                                DgvArticulos.Rows.RemoveAt(i);
                                posART--;
                                //a--;
                            }
                        }
                        if (j != 0)
                        {
                            EMP.EliminarCedulaArt(dtArt, frmPrincipal.nombreBD);
                            ActualizarDtArticulos();
                        }
                        return;
                    }
                }
            }

            for (int i = 0; i < DgvArticulos.Rows.Count; i++)
            {
                if (Convert.ToBoolean(DgvArticulos.Rows[i].Cells["ColCheck"].Value) == true)
                {
                    DgvArticulos.Rows.RemoveAt(i);
                    posART--;
                    i--;
                }
            }
        }
        //---------------------------------------------IDIOMA
        public void AplicarIdioma()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
            this.lblTituloPanel.Text = StringResources.CedulaDeProducto;
            //
            this.Text = StringResources.CedulaDeProducto;
            //
            this.lblCod.Text = StringResources.Codigo;
            this.lblCodigo.Text = StringResources.Codigo;
            this.lblDescrip.Text = StringResources.Descripcion;
            this.lblDescripcion.Text = StringResources.Descripcion;
            this.lblProducto.Text = StringResources.Producto;
            this.lblFecha.Text = StringResources.fecha;
            this.lblUnidaddeMed.Text = StringResources.UnidadDeMedida;
            this.lblDuracion.Text = StringResources.Duracion;
            this.lblCantidad.Text = StringResources.Cantidad;
            this.lblDefinicionTareas.Text = StringResources.DefiniciondeTareas;

            //RadioButton
            this.RbDias.Text = StringResources.Dias;
            this.RbHoras.Text = StringResources.Horas;

            //btos
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
            this.btoBuscar.Text = StringResources.btnBuscar;
            this.btoSalir.Text = StringResources.btnSalir;
            //
            this.tPgInfoGeneral.Text = StringResources.Informaciongeneral;
            this.tpgTareas.Text = StringResources.Tarea;
        }
        public void CargarDescripStan()
        {
            for (int i = 0; i < dtCed.Rows.Count; i++)
            {
                codU = dtCed.Rows[i]["UniEstandar_Cod"].ToString().ToLower();
                if (codU == CargarUE)
                {
                    CargarDesc = dtCed.Rows[i]["UniEstandar_Desc"].ToString();
                    return;
                }
            }

        }

    }
}





