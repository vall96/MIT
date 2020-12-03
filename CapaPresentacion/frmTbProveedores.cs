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
using System.Threading;
using CultureResources;
using System.Globalization;
using System.IO;//
using System.Drawing.Drawing2D;
using System.Diagnostics;//
using System.Windows;//
using System.Windows.Data;//
using System.Windows.Input;//
using System.Windows.Media;//
using System.Windows.Media.Converters;//
using System.Collections;

namespace CapaPresentacion
{
    public partial class frmTbProveedores : Form
    {
        Random rnd = new Random();
        private ListViewColumnSorter lvwcolumnsorter;
        //
        clsEmpresa M = new clsEmpresa();
        DataTable dt = new DataTable();
        ListViewItem lvrow;
        //
        public string[,] datos = new string[1, 20];
        public delegate void pasar(string[,] dato);        //firma tipo de metodo
        public event pasar pasado;
        public delegate void relacion(DataTable dtProveedor);
        public event relacion dtRelProv;
        DataTable dtProveedor;
        //
        int pos = 0, pos2 = 0, linea = 0, linea2 = 0, valor = 0, i = 0, count = 0, a, numid;
        public string tipoPais = "", mensajeText = "", mensajeCaption = "";
        //
        public static string _provId = "", _provNomb = "", _provDesc = "", _provDir = "", _provContac = "", _provTelef1 = "", _provTelef2 = "", _provRif = "", _provEmail = "", _provWeb = ""
            , _provFechaCreacion = "", _provFax = "", estado = "", proveedor = "", _nombre = "", _tipo = "", _referencia = "", _responsable = "", _pais = "", _estado = "", _ciudad = "", _municipio = "",
            _tipopersona = "", _dias = "", _limite = "", _comentario = "", id = "", descrip = "";
        int j;
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public frmTbProveedores()
        {
            InitializeComponent();
            lvwcolumnsorter = new ListViewColumnSorter();
            this.lsvProveedores.ListViewItemSorter = lvwcolumnsorter;
            frmPrincipal.nombreBD = "Digitel";
            AplicarIdioma();
            CargarLstv();
        }
        private void fmrTbProveedores_Load(object sender, EventArgs e)
        {
            this.lsvProveedores.OwnerDraw = true;

            if (frmArticulos.valido == "Art-Prov")
            {
                lsvProveedores.CheckBoxes = true;
            }
            else
            {
                lsvProveedores.CheckBoxes = false;
            }

            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void btoBuscar_Click(object sender, EventArgs e)
        {
            FuncionBuscar();
        }
        private void btoAceptar_Click(object sender, EventArgs e)
        {
            if(frmArticulos.valido == "Art-Prov")
            {
                ProveedoresSeleccionados();
                this.Hide();
            }
            else if (lsvProveedores.SelectedItems.Count > 0)
            {
                datosSeleccionados();
                this.Hide();
            }
            else if (estado == "buscar")
            {
                proveedor = "valido";
                datos[0, 0] = _provId;
                datos[0, 1] = _provNomb;
                datos[0, 2] = _tipo;
                datos[0, 3] = _referencia;
                datos[0, 4] = _responsable;
                datos[0, 5] = _provEmail;
                datos[0, 6] = _provTelef1;
                datos[0, 7] = _provTelef2;
                datos[0, 8] = _provDir;
                datos[0, 9] = _pais;
                datos[0, 10] = _estado;
                datos[0, 11] = _ciudad;
                datos[0, 12] = _municipio;
                datos[0, 13] = _tipopersona;
                datos[0, 14] = _provFax;
                datos[0, 15] = _provFechaCreacion;
                datos[0, 16] = _dias;
                datos[0, 17] = _limite;
                datos[0, 18] = _comentario;
                datos[0, 19] = _provRif;
                pasado(datos);
                this.Hide();
            }
            else 
            {
                this.Close();
            }
            frmArticulos.valido = "no";
        }
        private void btoSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void lsvProveedores_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }
        private void lsvProveedores_DoubleClick(object sender, EventArgs e)
        {
            datosSeleccionados();
        }
        private void frmTbProveedores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FuncionBuscar();
            }
        }
        private void lsvProveedores_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.DarkOrange, e.Bounds);
            e.DrawText();
        }
        private void listViewUsurios_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwcolumnsorter.SortColumn)
            {
                if (lvwcolumnsorter.Order == SortOrder.Ascending)
                {
                    lvwcolumnsorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwcolumnsorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                lvwcolumnsorter.SortColumn = e.Column;
                lvwcolumnsorter.Order = SortOrder.Ascending;
            }
            this.lsvProveedores.Sort();
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void lsvProveedores_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lsvProveedores.Sorting == SortOrder.Ascending)
            {
                lsvProveedores.Sorting = SortOrder.Descending;
                lsvProveedores.Sort();
            }
            else
            {
                lsvProveedores.Sorting = SortOrder.Ascending;
                lsvProveedores.Sort();
            }
        }
        private void datosSeleccionados()
        {
            if (lsvProveedores.SelectedItems.Count > 0)
            {
                _provId = lsvProveedores.SelectedItems[0].Text;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (_provId == dt.Rows[i]["prov_id"].ToString())
                    {
                        datos[0, 0] = _provId;
                        datos[0, 1] = dt.Rows[i]["prov_nom"].ToString();
                        datos[0, 2] = dt.Rows[i]["prov_tipo"].ToString();
                        datos[0, 3] = dt.Rows[i]["prov_Referencia"].ToString();
                        datos[0, 4] = dt.Rows[i]["prov_resp"].ToString();
                        datos[0, 5] = dt.Rows[i]["prov_email"].ToString();
                        datos[0, 6] = dt.Rows[i]["prov_telf1"].ToString();
                        datos[0, 7] = dt.Rows[i]["prov_telf2"].ToString();
                        datos[0, 8] = dt.Rows[i]["prov_direc"].ToString();
                        datos[0, 9] = dt.Rows[i]["prov_pais"].ToString();
                        datos[0, 10] = dt.Rows[i]["prov_estado"].ToString();
                        datos[0, 11] = dt.Rows[i]["prov_ciudad"].ToString();
                        datos[0, 12] = dt.Rows[i]["prov_municipio"].ToString();
                        datos[0, 13] = dt.Rows[i]["prov_tipoPersoJ"].ToString();
                        datos[0, 14] = dt.Rows[i]["prov_Fax"].ToString();
                        datos[0, 15] = dt.Rows[i]["prov_Fecha"].ToString();
                        datos[0, 16] = dt.Rows[i]["prov_diasCred"].ToString();
                        datos[0, 17] = dt.Rows[i]["prov_limiteCred"].ToString();
                        datos[0, 18] = dt.Rows[i]["prov_Coment"].ToString();
                        datos[0, 19] = dt.Rows[i]["prov_Rif"].ToString();
                        pasado(datos);
                    }
                }
                this.Hide();
            }
            else
            {
                return;
            }
        }
        public void ProveedoresSeleccionados()
        {
            if (frmArticulos.valido == "Art-Prov")
            {
                j = 0;
                ConstruccionDt();
                for (int i = 0; i < lsvProveedores.Items.Count; i++)
                {
                    if (lsvProveedores.Items[i].Checked == true)
                    {
                        dtProveedor.Rows.Add();
                        dtProveedor.Rows[j]["codigo"] = lsvProveedores.Items[i].SubItems[0].Text;
                        dtProveedor.Rows[j]["descripcion"] = lsvProveedores.Items[i].SubItems[1].Text;
                        j++;
                    }
                }
            }
            dtRelProv(dtProveedor);
        }
        //
        private void ConstruccionDt()
        {
            if (frmArticulos.valido == "Art-Prov")
            {
                dtProveedor = new DataTable();
                dtProveedor.Columns.Add("codigo", Type.GetType("System.String"));
                dtProveedor.Columns.Add("descripcion", Type.GetType("System.String"));
            }
        }
        private void CargarLstv()
        {
            dt = M.Listado_Proveedores(frmPrincipal.nombreBD);
            for (int i=0;i<dt.Rows.Count;i++)
            {
                lvrow = new ListViewItem(dt.Rows[i]["prov_id"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["prov_nom"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["prov_tipo"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["prov_direc"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["prov_resp"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["prov_telf1"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["prov_telf2"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["prov_email"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["prov_Fecha"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["prov_Referencia"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["prov_resp"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["prov_pais"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["prov_estado"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["prov_ciudad"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["prov_municipio"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["prov_tipoPersoJ"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["prov_Fax"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["prov_diasCred"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["prov_limiteCred"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["prov_Coment"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["prov_Rif"].ToString());
                this.lsvProveedores.Items.Add(lvrow);
            }
        }
        public void ValidarProveedor(string id, string descripcion, string buscar)
        {            
            string palabra = "";
            proveedor = "";
            if (id != "")
            {
                for (int i = pos; i < lsvProveedores.Items.Count; i++)
                {
                    palabra = lsvProveedores.Items[i].SubItems[0].Text.ToLower();
                    bool existe = palabra.StartsWith(id.ToLower());
                    linea = i;
                    if (existe == true)
                    {
                        a = i;
                        proveedor = "valido";
                        _provId = lsvProveedores.Items[a].SubItems[0].Text.ToString().Trim();
                        _provNomb = lsvProveedores.Items[a].SubItems[1].Text.ToString().Trim();
                        _tipo = lsvProveedores.Items[a].SubItems[2].Text.ToString().Trim();
                        _provDir = lsvProveedores.Items[a].SubItems[3].Text.ToString().Trim();
                        _responsable = lsvProveedores.Items[a].SubItems[4].Text.ToString().Trim();
                        _provTelef1 = lsvProveedores.Items[a].SubItems[5].Text.ToString().Trim();
                        _provTelef2 = lsvProveedores.Items[a].SubItems[6].Text.ToString().Trim();
                        _provEmail = lsvProveedores.Items[a].SubItems[7].Text.ToString().Trim();
                        _provFechaCreacion = lsvProveedores.Items[a].SubItems[8].Text.ToString().Trim();
                        _referencia = lsvProveedores.Items[a].SubItems[9].Text.ToString().Trim();
                        _responsable = lsvProveedores.Items[a].SubItems[10].Text.ToString().Trim();
                        _pais = lsvProveedores.Items[a].SubItems[11].Text.ToString().Trim();
                        _estado = lsvProveedores.Items[a].SubItems[12].Text.ToString().Trim();
                        _ciudad = lsvProveedores.Items[a].SubItems[13].Text.ToString().Trim();
                        _municipio = lsvProveedores.Items[a].SubItems[14].Text.ToString().Trim();
                        _tipopersona = lsvProveedores.Items[a].SubItems[15].Text.ToString().Trim();
                        _provFax = lsvProveedores.Items[a].SubItems[16].Text.ToString().Trim();
                        _dias = lsvProveedores.Items[a].SubItems[17].Text.ToString().Trim();
                        _limite = lsvProveedores.Items[a].SubItems[18].Text.ToString().Trim();
                        _comentario = lsvProveedores.Items[a].SubItems[19].Text.ToString().Trim();
                        _provRif = lsvProveedores.Items[a].SubItems[20].Text.ToString().Trim();
                        lsvProveedores.Items[a].SubItems[0].BackColor = Color.LightSeaGreen;
                        pos = a;
                        return;
                    }
                }
            }
            else
            {
                if (descripcion != "")
                {
                    for (int i = pos2; i < lsvProveedores.Items.Count; i++)
                    {
                        palabra = lsvProveedores.Items[i].SubItems[1].Text.ToLower();
                        bool existe = palabra.StartsWith(descripcion.ToLower());
                        linea2 = i;
                        if (existe == true)
                        {
                            a = i;
                            proveedor = "valido";
                            _provId = lsvProveedores.Items[a].SubItems[0].Text.ToString().Trim();
                            _provNomb = lsvProveedores.Items[a].SubItems[1].Text.ToString().Trim();
                            _tipo = lsvProveedores.Items[a].SubItems[2].Text.ToString().Trim();
                            _provDir = lsvProveedores.Items[a].SubItems[3].Text.ToString().Trim();
                            _responsable = lsvProveedores.Items[a].SubItems[4].Text.ToString().Trim();
                            _provTelef1 = lsvProveedores.Items[a].SubItems[5].Text.ToString().Trim();
                            _provTelef2 = lsvProveedores.Items[a].SubItems[6].Text.ToString().Trim();
                            _provEmail = lsvProveedores.Items[a].SubItems[7].Text.ToString().Trim();
                            _provFechaCreacion = lsvProveedores.Items[a].SubItems[8].Text.ToString().Trim();
                            _referencia = lsvProveedores.Items[a].SubItems[9].Text.ToString().Trim();
                            _responsable = lsvProveedores.Items[a].SubItems[10].Text.ToString().Trim();
                            _pais = lsvProveedores.Items[a].SubItems[11].Text.ToString().Trim();
                            _estado = lsvProveedores.Items[a].SubItems[12].Text.ToString().Trim();
                            _ciudad = lsvProveedores.Items[a].SubItems[13].Text.ToString().Trim();
                            _municipio = lsvProveedores.Items[a].SubItems[14].Text.ToString().Trim();
                            _tipopersona = lsvProveedores.Items[a].SubItems[15].Text.ToString().Trim();
                            _provFax = lsvProveedores.Items[a].SubItems[16].Text.ToString().Trim();
                            _dias = lsvProveedores.Items[a].SubItems[17].Text.ToString().Trim();
                            _limite = lsvProveedores.Items[a].SubItems[18].Text.ToString().Trim();
                            _comentario = lsvProveedores.Items[a].SubItems[19].Text.ToString().Trim();
                            _provRif = lsvProveedores.Items[a].SubItems[20].Text.ToString().Trim();
                            lsvProveedores.Items[a].SubItems[0].BackColor = Color.LightSeaGreen;
                            pos2 = a;
                            return;
                        }
                    }
                }
            }
            if (proveedor != "valido")
            {
                if (pos2 == 0)
                {
                    valor = 1;
                }
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void FuncionBuscar()
        {
            lsvProveedores.Items[linea].SubItems[0].BackColor = Color.White;
            lsvProveedores.Items[linea2].SubItems[0].BackColor = Color.White;
            estado = "buscar";
            if (txtCodigo.Text == "" && txtProveedor.Text == "")
            {
                return;
            }
            else if (txtCodigo.Text != "" && txtProveedor.Text != "")
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.No_se_puede_realizar_la_busqueda_con_todos_los_campos_llenos;
                mensajeText = StringResources.ErrordeValidacion;

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
                    id = txtCodigo.Text;
                    descrip = "";
                    ValidarProveedor(id, descrip, "buscar");
                    limpiarcajas();
                }
                if (txtProveedor.Text != "")
                {
                    id = "";
                    descrip = txtProveedor.Text;
                    ValidarProveedor(id, descrip, "buscar");
                    pos2++;
                    limpiarcajas();
                }
            }
            if (proveedor == "valido")
            {
                lsvProveedores.Items[pos].Selected = true;
                lsvProveedores.Items[pos].Focused = true;
                lsvProveedores.EnsureVisible(pos);
            }
            else
            {
                if (valor!=1)
                {
                    pos = 0;
                    pos2 = 0;
                    MessageBox.Show("Ya no hay más registros", "Ya no hay más registros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (valor == 1)
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
                    mensajeText = StringResources.NoSeEncontroInformacion;
                    mensajeCaption = StringResources.ErrordeValidacion;

                    MessageBox.Show(mensajeText, mensajeCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                    this.txtCodigo.Focus();
                    limpiarcajas();
                }
            }
        }
        public void limpiarcajas()
        {
            txtCodigo.Text = "";
            txtProveedor.Text = "";
        }
        public void actualizarlstv(string accion)
        {
            switch (accion)
            {
                case "agregar":
                    lvrow = new ListViewItem(frmProveedores.id);
                    lvrow.SubItems.Add(frmProveedores.nombre);
                    lvrow.SubItems.Add(frmProveedores.tipo);
                    lvrow.SubItems.Add(frmProveedores.responsable);
                    lvrow.SubItems.Add(frmProveedores.email);
                    lvrow.SubItems.Add(frmProveedores.telefono1);
                    lvrow.SubItems.Add(frmProveedores.telefono2);
                    lvrow.SubItems.Add(frmProveedores.direccion);
                    lvrow.SubItems.Add(frmProveedores.fechacreacion);
                    this.lsvProveedores.Items.Add(lvrow);
                    break;
                case "editar":
                    ValidarProveedor(frmProveedores.id, "", "buscar");
                    lsvProveedores.Items[pos].SubItems[0].BackColor = Color.White;
                    lsvProveedores.Items[pos].SubItems[1].Text = frmProveedores.nombre;
                    lsvProveedores.Items[pos].SubItems[2].Text = frmProveedores.tipo;
                    lsvProveedores.Items[pos].SubItems[4].Text = frmProveedores.responsable;
                    lsvProveedores.Items[pos].SubItems[7].Text = frmProveedores.email;
                    lsvProveedores.Items[pos].SubItems[5].Text = frmProveedores.telefono1;
                    lsvProveedores.Items[pos].SubItems[6].Text = frmProveedores.telefono2;
                    lsvProveedores.Items[pos].SubItems[3].Text = frmProveedores.direccion;
                    lsvProveedores.Items[pos].SubItems[8].Text = frmProveedores.fechacreacion;
                    break;
                case "eliminar":
                    ValidarProveedor(frmProveedores.id, "", "buscar");
                    lsvProveedores.Items[pos].SubItems[0].BackColor = Color.White;
                    lsvProveedores.Items.RemoveAt(pos);
                    pos = 0;
                    numid--;
                    break;
            }
        }
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void AplicarIdioma()
        {
            //TiTulo
            this.lblTitulo.Text = StringResources.Proveedores;
            this.Text = StringResources.Proveedores;
            //Label
            this.lblCodigo.Text = StringResources.Codigo;
            this.lblProveedor.Text = StringResources.proveedor;
            //Button
            this.btoAceptar.Text = StringResources.btoAceptar;
            this.btoBuscar.Text = StringResources.btnBuscar;
            this.btoSalir.Text = StringResources.btnSalir;
            //ListView
            this.ColCodigo.Text = StringResources.Codigo;
            this.colContacto.Text = StringResources.Contacto;
            this.colProveedor.Text = StringResources.proveedor;
            this.colDescripcion.Text = StringResources.Descripcion;
            this.colDireccion.Text = StringResources.Direccion;
            this.colContacto.Text = StringResources.Contacto;
            this.colTelf1.Text = StringResources.Telefonos;
            this.colTelf2.Text = StringResources.Telefonos;
            this.colEmail.Text = StringResources.email;
            this.colFecha.Text = StringResources.fecha;
        }
        //-------------------------------------
        string codProv;
       
        private void Actualizarlsv()
        {
            for (int i = 0; i < lsvProveedores.Items.Count; i++)
            {
                if (codProv == lsvProveedores.Items[i].SubItems[0].Text.ToString())
                {
                    lsvProveedores.Items.RemoveAt(i);
                    return;
                }
            }
        }
        private void FiltrarDatos()
        {
            if (frmArticulos.valido == "si")
            {
                if (frmArticulos.cont != 0)
                {
                    for (int a = 0; a < frmArticulos.DtActualProv.Rows.Count; a++)
                    {
                        codProv = frmArticulos.DtActualProv.Rows[a]["ArticuloId"].ToString();
                        Actualizarlsv();
                    }
                }
            }
        }
        //-----------------------------------
        //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //ListViewColumnSorter
        public class ListViewColumnSorter : IComparer
        {
            private int ColumnToSort;
            private SortOrder OrderOfSort;
            private CaseInsensitiveComparer ObjectCompare;
            public ListViewColumnSorter()
            {
                ColumnToSort = 0;
                OrderOfSort = SortOrder.None;
                ObjectCompare = new CaseInsensitiveComparer();
            }
            public int Compare(object x, object y)
            {
                int compareResult;
                ListViewItem listViewX, listViewY;
                listViewX = (ListViewItem)x;
                listViewY = (ListViewItem)y;
                decimal num = 0;
                if (decimal.TryParse(listViewX.SubItems[ColumnToSort].Text, out num))
                {
                    compareResult = decimal.Compare(num, Convert.ToDecimal(listViewY.SubItems[ColumnToSort].Text));
                }
                else
                {
                    compareResult = ObjectCompare.Compare(listViewX.SubItems[ColumnToSort].Text, listViewY.SubItems[ColumnToSort].Text);
                }
                if (OrderOfSort == SortOrder.Ascending)
                {
                    return compareResult;
                }
                else if (OrderOfSort == SortOrder.Descending)
                {
                    return (-compareResult);
                }
                else
                {
                    return 0;
                }
            }
            public int SortColumn
            {
                set
                {
                    ColumnToSort = value;
                }
                get
                {
                    return ColumnToSort;
                }
            }
            public SortOrder Order
            {
                set
                {
                    OrderOfSort = value;
                }
                get
                {
                    return OrderOfSort;
                }
            }
        }
    }
}
