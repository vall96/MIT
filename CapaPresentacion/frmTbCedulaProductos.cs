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
    public partial class frmTbCedulaProductos : Form
    {
        public delegate void pasar(string[,] dato);
        public event pasar pasado;
        public string[,] datos = new string[1, 10];
        public static string estado = "", ValidarPro = "";
        int pos = 0;

        clsEmpresa M = new clsEmpresa();
        ListViewItem lvrow;
        DataTable dt = new DataTable();

        frmCedulaDeProducto ventCedulaProd;

        public string cod, des, mensajeText, mensajeCaption, tipoPais = "";
        public static string _codigo,
            _descripcion,
            _producto,
            _unidad,
            _duracion,
            _horaDia,
            _cantidad,
            _CantidadMAX,
            _cantidadMin,
            _Fecha,
            _Uestandar;
   
        public frmTbCedulaProductos()
        {
            InitializeComponent();
           
            CargarListview();

            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();
        }
        private void frmTbCedulaProductos_Load(object sender, EventArgs e)
        {
            ventCedulaProd = new frmCedulaDeProducto();
        }


        //------------------------------------------------------------------------------------
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                lsvCedulaProduccion.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
                FuncionBuscar();
            }
            else
            {
                return;
            }
        }
        private void txtDescrip_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                lsvCedulaProduccion.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
                FuncionBuscar();
            }
        }
        private void lsvCedulaProduccion_DoubleClick(object sender, EventArgs e)
        {
            ValidarPro = "si";
            datosSeleccionados();
        }

        private void btoSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btoBuscar_Click(object sender, EventArgs e)
        {
            FuncionBuscar();
        }
        private void btoAceptar_Click(object sender, EventArgs e)
        {
            if (lsvCedulaProduccion.SelectedItems.Count > 0)
            {
                datosSeleccionados();
                this.Hide();
            }
            else
            {
                this.Close();
            }
        }
        //-----------------------------------------------------------------------------------
        public void FuncionBuscar()
        {
            estado = "buscar";
            if (txtCodigo.Text == "" && txtDescrip.Text == "")
            {
                return;
                // usuaValido = "no";
            }
            else if (txtCodigo.Text != "" && txtDescrip.Text != "")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.NoSeEncontroInformacion;
                mensajeCaption = StringResources.ErrordeValidacion;

                MessageBox.Show(mensajeText, mensajeCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                this.txtCodigo.Focus();
                return;
            }
            else
            {
                if (txtCodigo.Text != "")
                {
                    cod = txtCodigo.Text;
                    des = "";
                    ValidarBuscar(cod, des);
                    LimpiarCajas();
                }
                else
                {
                    cod = "";
                    des = txtDescrip.Text;
                    ValidarBuscar(cod, des);
                    LimpiarCajas();
                }
                if (frmTbCedulaProductos.estado == "Valido")
                {
                    ventCedulaProd.cargarDatos();
                    lsvCedulaProduccion.Items[pos].Selected = true;
                    lsvCedulaProduccion.Items[pos].Focused = true;
                    lsvCedulaProduccion.EnsureVisible(pos);
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
                    LimpiarCajas();
                }
            }
        }
        public void FuncionInicio()
        {
            if (lsvCedulaProduccion.Items.Count == 0)
            {
                this.txtCodigo.Enabled = false;
                this.txtDescrip.Enabled = false;
            }
        }
        private void LimpiarCajas()
        {
            txtCodigo.Text = "";
            txtDescrip.Text = "";
        }
        public void ValidarBuscar(string CodigoP, string DescP)
        {
            lsvCedulaProduccion.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
            string palabra = "";
            estado = "";
            if (CodigoP != "")
            {
                //CargarDatosValidados(CodigoP,DescP);
                for (int i = 0; i < lsvCedulaProduccion.Items.Count; i++)
                {
                    palabra = lsvCedulaProduccion.Items[i].SubItems[0].Text.ToLower();
                    bool existe = palabra.StartsWith(CodigoP.ToLower());
                    if (existe == true)
                    {
                        estado = "Valido";
                        _codigo = lsvCedulaProduccion.Items[i].SubItems[0].Text.ToString().Trim();
                        _descripcion = lsvCedulaProduccion.Items[i].SubItems[1].Text.ToString().Trim();
                        _producto = lsvCedulaProduccion.Items[i].SubItems[2].Text.ToString().Trim();
                        _unidad = lsvCedulaProduccion.Items[i].SubItems[3].Text.ToString().Trim();
                        _duracion = lsvCedulaProduccion.Items[i].SubItems[4].Text.ToString().Trim();
                        _horaDia = lsvCedulaProduccion.Items[i].SubItems[5].Text.ToString().Trim();
                        _cantidad = lsvCedulaProduccion.Items[i].SubItems[6].Text.ToString().Trim();
                        _Fecha = lsvCedulaProduccion.Items[i].SubItems[7].Text.ToString().Trim();
                        _Uestandar = lsvCedulaProduccion.SelectedItems[0].SubItems[8].Text.ToString().Trim();

                        // frmCedulaDeProducto.ItemsAsociados();

                        lsvCedulaProduccion.Items[i].SubItems[0].BackColor = Color.LightSeaGreen;
                        pos = i;
                        return;
                    }
                }
            }
            else if (DescP != "")
            {
                for (int i = 0; i < lsvCedulaProduccion.Items.Count; i++)
                {
                    palabra = lsvCedulaProduccion.Items[i].SubItems[1].Text.ToLower();
                    bool existe = palabra.StartsWith(DescP.ToLower());

                    if (existe == true)
                    {
                        estado = "Valido";
                        _codigo = lsvCedulaProduccion.Items[i].SubItems[0].Text.ToString().Trim();
                        _descripcion = lsvCedulaProduccion.Items[i].SubItems[1].Text.ToString().Trim();
                        _producto = lsvCedulaProduccion.Items[i].SubItems[2].Text.ToString().Trim();
                        _unidad = lsvCedulaProduccion.Items[i].SubItems[3].Text.ToString().Trim();
                        _duracion = lsvCedulaProduccion.Items[i].SubItems[4].Text.ToString().Trim();
                        _horaDia = lsvCedulaProduccion.Items[i].SubItems[5].Text.ToString().Trim();
                        _cantidad = lsvCedulaProduccion.Items[i].SubItems[6].Text.ToString().Trim();
                        _Fecha = lsvCedulaProduccion.Items[i].SubItems[7].Text.ToString().Trim();
                        _Uestandar = lsvCedulaProduccion.SelectedItems[0].SubItems[8].Text.ToString().Trim();

                        lsvCedulaProduccion.Items[i].SubItems[0].BackColor = Color.LightSeaGreen;
                        pos = i;
                        return;
                    }
                }
            }
        }
        public string unidad, Ucod;
        private void CargarListview()
        {
            dt = M.ListadoCedulaProducto (frmPrincipal.nombreBD);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                unidad = dt.Rows[i]["CedPro_Unidad"].ToString();
                CargarUnidad();
                lvrow = new ListViewItem(dt.Rows[i]["CedPro_Id"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["CedPro_Descrip"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["CedPro_Producto"].ToString());
                lvrow.SubItems.Add(idUD);
                lvrow.SubItems.Add(dt.Rows[i]["CedPro_Duracion"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["CedPro_DuracionHoraDias"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["CedPro_Cantidad"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["CedPro_Fecha"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["CedPro_UnidadEstandar"].ToString());

                this.lsvCedulaProduccion.Items.Add(lvrow);
            }
        }
        DataTable dtUniDes = new DataTable();
        public string cargarUni, idUD;

        public void CargarUnidad()
        {
            dtUniDes = M.ListarUnidadesDescripcionMVL("MITCore");

            for (int i = 0; i < dtUniDes.Rows.Count; i++)
            {
                cargarUni = dtUniDes.Rows[i]["UnidDes_codUni"].ToString().ToLower();
                if (cargarUni == unidad)
                {
                    idUD = dtUniDes.Rows[i]["UnidDes_Descripcion"].ToString();
                    return;
                }
            }
        }
        //----------------------------------------------------------------------------------
        private void datosSeleccionados()
        {
            if (lsvCedulaProduccion.SelectedItems.Count > 0)
            {
                _codigo = lsvCedulaProduccion.SelectedItems[0].Text.ToString().Trim();
                _descripcion = lsvCedulaProduccion.SelectedItems[0].SubItems[1].Text.ToString().Trim();
                _producto = lsvCedulaProduccion.SelectedItems[0].SubItems[2].Text.ToString().Trim();
                _unidad = lsvCedulaProduccion.SelectedItems[0].SubItems[3].Text.ToString().Trim(); ;
                _duracion = lsvCedulaProduccion.SelectedItems[0].SubItems[4].Text.ToString().Trim();
                _horaDia = lsvCedulaProduccion.SelectedItems[0].SubItems[5].Text.ToString().Trim();
                _cantidad = lsvCedulaProduccion.SelectedItems[0].SubItems[6].Text.ToString().Trim();
                _Fecha = lsvCedulaProduccion.SelectedItems[0].SubItems[7].Text.ToString().Trim();
                _Uestandar = lsvCedulaProduccion.SelectedItems[0].SubItems[8].Text.ToString().Trim();
                
                datos[0, 0] = _codigo;
                datos[0, 1] = _descripcion;
                datos[0, 9] = _producto;
                datos[0, 2] = _unidad;
                datos[0, 3] = _duracion;
                datos[0, 4] = _horaDia;
                datos[0, 5] = _cantidad;
                datos[0, 6] = _Fecha.ToString();
                datos[0, 8] = _Uestandar;

                pasado(datos);
                estado = "valido";
                this.Hide();
            }
        }

      
        public void AplicarIdioma()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
            this.lblTituloPanel.Text = StringResources.CedulaDeProducto;
            
            this.Text = StringResources.CedulaDeProducto;
            //
            this.lblCodigo.Text = StringResources.Codigo;
            this.lblDescripcion.Text = StringResources.Descripcion;
            //
            this.colCodigo.Text = StringResources.Codigo;
            this.ColDescripcion.Text = StringResources.Descripcion;
            this.ColProducto.Text = StringResources.Producto;
            this.ColUnidad.Text = StringResources.Unidad;
            this.ColDuracion.Text = StringResources.Duracion;
            this.ColHoraDia.Text = StringResources.DuracionDiasHoras;
            this.ColCantidad.Text = StringResources.Cantidad;
            this.ColFecha.Text = StringResources.fecha;
            //
            this.btoAceptar.Text = StringResources.btoAceptar;
            this.btoBuscar.Text = StringResources.btnBuscar;
            this.btoSalir.Text = StringResources.btnSalir;
            //
         
        }
        //---------------------------------2020---------------------------------------
        private void lsvCedulaProduccion_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lsvCedulaProduccion.Sorting == SortOrder.Ascending)
            {
                lsvCedulaProduccion.Sorting = SortOrder.Descending;
                lsvCedulaProduccion.Sort();
            }
            else
            {
                lsvCedulaProduccion.Sorting = SortOrder.Ascending;
                lsvCedulaProduccion.Sort();
            }
        }
      
    }
}




       //public void CargarDataGrid()
        //{
        //    DgVCedulaProducto.Rows.Clear();
        //    dt = EMP.ListadoCedulaProducto(frmPrincipal.nombreBD);

        //    for(int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        DgVCedulaProducto.Rows.Add(dt.Rows[i]["CedPro_Id"].ToString(),
        //        dt.Rows[i]["CedPro_Descrip"].ToString(),
        //        dt.Rows[i]["CedPro_Producto"].ToString(),
        //        dt.Rows[i]["CedPro_Unidad"].ToString(),
        //        dt.Rows[i]["CedPro_Duracion"].ToString(),
        //        dt.Rows[i]["CedPro_DuracionHoraDias"].ToString(),
        //        dt.Rows[i]["CedPro_Cantidad"].ToString(),
        //        dt.Rows[i]["CedPro_CantidadMaxima"].ToString(),
        //        dt.Rows[i]["CedPro_CantidadMinima"].ToString(),
        //        dt.Rows[i]["CedPro_Fecha"].ToString());
        //    }
        //}
        //public void datosSeleccionados(DataGridViewCellEventArgs a)
        //{
        //        _codigo = DgVCedulaProducto.Rows[a.RowIndex].Cells["colCódigo"].Value.ToString().Trim();
        //        _descripcion = DgVCedulaProducto.Rows[a.RowIndex].Cells["colDescripcion"].Value.ToString().Trim();
        //        _producto = DgVCedulaProducto.Rows[a.RowIndex].Cells["ColProducto"].Value.ToString().Trim();
        //        _unidad = DgVCedulaProducto.Rows[a.RowIndex].Cells["colUnidad"].Value.ToString().Trim();
        //        _duracion = DgVCedulaProducto.Rows[a.RowIndex].Cells["ColDuracion"].Value.ToString().Trim();
        //        _horaDia = DgVCedulaProducto.Rows[a.RowIndex].Cells["ColDiasHoras"].Value.ToString().Trim();
        //        _cantidad = DgVCedulaProducto.Rows[a.RowIndex].Cells["ColCantidad"].Value.ToString().Trim();
        //        _CantidadMAX = DgVCedulaProducto.Rows[a.RowIndex].Cells["ColCantidadMAX"].Value.ToString().Trim();
        //        _cantidadMin = DgVCedulaProducto.Rows[a.RowIndex].Cells["ColCantidadMin"].Value.ToString().Trim();
        //        _Fecha = DgVCedulaProducto.Rows[a.RowIndex].Cells["ColFecha"].Value.ToString().Trim();
        //        //_codigo = DgVCedulaProducto.SelectedColumns[0].ToString().Trim();
        //        //_descripcion = DgVCedulaProducto.SelectedColumns[1].ToString().Trim();

        //        datos[0, 0] = _codigo;
        //        datos[0, 1] = _descripcion;
        //        datos[0, 9] = _producto;
        //        datos[0, 2] = _unidad;
        //        datos[0, 3] = _duracion;
        //        datos[0, 4] = _horaDia;
        //        datos[0, 5] = _cantidad;
        //        datos[0, 6] = _CantidadMAX;
        //        datos[0, 7] = _cantidadMin;
        //        datos[0, 8] = _Fecha;

        //        pasado(datos);
        //        estado = "valido";
        //        this.Hide();
        //}
