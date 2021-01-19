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
    public partial class frmTbArticulos : Form
    {
        public static string estado = "", tipoPais = "";
        public delegate void pasar(string[,] dato);
        public event pasar pasado;
        public delegate void relacion(DataTable dtArticulo);
        public event relacion dtRelArtic;
        public string[,] datos = new string[1, 15];
        //
        ListViewItem lvrow;
        DataTable dt = new DataTable();
        DataTable dtArticulos;
        clsEmpresa M = new clsEmpresa();
        frmTareas venTareas;
        //
        string _codigo, _nombre, _modelo, _codMedida, _CodFiltro,
               _serial, _categoria, _subCateg, _garant, _iva, _lote, codArt;
        int j;
        //-----------------------------------------------------------------------------------------
        public frmTbArticulos()
        {
            InitializeComponent();
            CargarLst();
            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();
        }
        private void frmTbArticulos_Load(object sender, EventArgs e)
        {
            if (frmTareas.valido == "si" || frmCedulaDeProducto.valido == "si" || frmMovDeInventario.valido == "Mov-TbArticulos")
            {
                lstvArticulos.CheckBoxes = true;
            }
            else
            {
                lstvArticulos.CheckBoxes = false;
            }
            CargarArticuloslsv();
        }
        //-----------------------------------------------------------------------------------------
        private void btoSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btoAceptar_Click(object sender, EventArgs e)
        {
            if (frmTareas.valido == "si")
            {
                ArticulosSeleccionadas();
                this.Hide();
            }
            if (frmCedulaDeProducto.valido == "si")
            {
                ArticulosSeleccionadas();
                this.Hide();
            }
            if (frmMovDeInventario.valido == "Mov-TbArticulos")
            {
                ArticulosSeleccionadas();
                this.Hide();

            }
            else if (lstvArticulos.SelectedItems.Count > 0)
            {
                datosSeleccionados();
                this.Hide();
            }
            else
            {
                this.Close();
            }
            frmTareas.valido = "no";
            frmCedulaDeProducto.valido = "no";
            frmMovDeInventario.valido = "no";
        }
        //----------------------------------------------------------------------------------------
        private void lstvArticulos_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lstvArticulos.Sorting == SortOrder.Ascending)
            {
                lstvArticulos.Sorting = SortOrder.Descending;
                lstvArticulos.Sort();
            }
            else
            {
                lstvArticulos.Sorting = SortOrder.Ascending;
                lstvArticulos.Sort();
            }
        }
        private void lstvArticulos_DoubleClick(object sender, EventArgs e)
        {
            datosSeleccionados();
            this.Hide();
        }
        //-----------------------------------------------------------------------------------------
        private void ConstruccionDt()
        {
            if (frmTareas.valido == "si" || frmCedulaDeProducto.valido == "si")
            {
                dtArticulos = new DataTable();
                dtArticulos.Columns.Add("codigo", Type.GetType("System.String"));
                dtArticulos.Columns.Add("descripcion", Type.GetType("System.String"));
            }
            if (frmMovDeInventario.valido == "Mov-TbArticulos")
            {
                dtArticulos = new DataTable();
                dtArticulos.Columns.Add("codigo", Type.GetType("System.String"));
                dtArticulos.Columns.Add("descripcion", Type.GetType("System.String"));
                dtArticulos.Columns.Add("medida", Type.GetType("System.String"));
                dtArticulos.Columns.Add("unidad", Type.GetType("System.String"));
                dtArticulos.Columns.Add("LOTE", Type.GetType("System.String"));
            }
        }
        private void CargarLst()
        {
            dt = M.ListadoArticulos(frmPrincipal.nombreBD);
        }
        private void CargarArticuloslsv()
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lvrow = new ListViewItem(dt.Rows[i]["art_Id"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["art_Nom"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["art_serial"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["art_Modelo"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["art_Garantia"].ToString());
                this.lstvArticulos.Items.Add(lvrow);
            }
            FiltrarDatos();
        }
        private void FiltrarDatos()
        {
            if (frmCedulaDeProducto.valido == "si")
            {
                if (frmCedulaDeProducto.cont4 != 0)
                {
                    for (int a = 0; a < frmCedulaDeProducto.DtActualArt.Rows.Count; a++)
                    {
                        codArt = frmCedulaDeProducto.DtActualArt.Rows[a]["ArticuloId"].ToString();
                        Actualizarlsv();
                    }
                }
            }
        }
        //--------------------------------------------------------------------------------------------
        private void datosSeleccionados()
        {
            if (frmTareas.valido != "si")
            {
                if (lstvArticulos.SelectedItems.Count > 0)
                {
                    _codigo = lstvArticulos.SelectedItems[0].Text.ToString().Trim();
                    _nombre = lstvArticulos.SelectedItems[0].SubItems[1].Text.ToString().Trim();
                    _serial = lstvArticulos.SelectedItems[0].SubItems[2].Text.ToString().Trim();
                    _modelo = lstvArticulos.SelectedItems[0].SubItems[3].Text.ToString().Trim();
                    _garant = lstvArticulos.SelectedItems[0].SubItems[4].Text.ToString().Trim();
                    BuscarOtrosDatos();
                    datos[0, 0] = _codigo; //
                    datos[0, 1] = _nombre; //
                    datos[0, 2] = _garant; //
                    datos[0, 3] = _modelo; //
                    datos[0, 5] = _codMedida;
                    datos[0, 6] = _CodFiltro;
                    datos[0, 8] = _categoria;
                    datos[0, 9] = _subCateg;
                    datos[0, 11] = _serial; //
                    datos[0, 12] = _iva; //
                    datos[0, 13] = _lote; //

                    pasado(datos);
                }
            }
        }
        private void ArticulosSeleccionadas()
        {
            j = 0;
            ConstruccionDt();
            if (frmTareas.valido == "si" || frmCedulaDeProducto.valido == "si")
            {
                for (int i = 0; i < lstvArticulos.Items.Count; i++)
                {
                    if (lstvArticulos.Items[i].Checked == true)
                    {
                        dtArticulos.Rows.Add();
                        dtArticulos.Rows[j]["codigo"] = lstvArticulos.Items[i].SubItems[0].Text;
                        dtArticulos.Rows[j]["descripcion"] = lstvArticulos.Items[i].SubItems[1].Text;
                        j++;
                    }
                }
            }
            if (frmMovDeInventario.valido == "Mov-TbArticulos")
            {
                for (int i = 0; i < lstvArticulos.Items.Count; i++)
                {
                    if (lstvArticulos.Items[i].Checked == true)
                    {
                        dtArticulos.Rows.Add();
                        dtArticulos.Rows[j]["codigo"] = lstvArticulos.Items[i].SubItems[0].Text;
                        dtArticulos.Rows[j]["descripcion"] = lstvArticulos.Items[i].SubItems[1].Text;
                        dtArticulos.Rows[j]["unidad"] = dt.Rows[i]["art_UnidadFriltro"].ToString();
                        _codigo = lstvArticulos.Items[i].SubItems[0].Text;
                        BuscarOtrosDatos();
                        dtArticulos.Rows[j]["LOTE"] = _lote;
                        j++; 

                    }
                }
            }
            dtRelArtic(dtArticulos);
        }
        private void BuscarOtrosDatos()
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (_codigo.ToLower() == dt.Rows[i]["art_Id"].ToString().ToLower())
                {
                    _codMedida = dt.Rows[i]["art_Unidad"].ToString();
                    _CodFiltro = dt.Rows[i]["art_UnidadFriltro"].ToString(); 
                    _categoria = dt.Rows[i]["art_Catg"].ToString();
                    _subCateg = dt.Rows[i]["art_SubCatg"].ToString();
                    _iva = dt.Rows[i]["art_IVA"].ToString();
                    _lote = dt.Rows[i]["art_LOTE"].ToString();

                    return;
                }
            }
        }
        private void Actualizarlsv()
        {
            for (int i = 0; i < lstvArticulos.Items.Count; i++)
            {
                if (codArt == lstvArticulos.Items[i].SubItems[0].Text.ToString())
                {
                    lstvArticulos.Items.RemoveAt(i);
                    return;
                }
            }
        }
        //--------------------------------------------------------------------------------------------
        public void AplicarIdioma()
        {
            this.Text = StringResources.Articulos;
            this.lblTitulo.Text = StringResources.Articulos;
            //
            this.ColCodigo.Text = StringResources.Codigo;
            this.colNomArticulo.Text = StringResources.Articulos;
            this.colModelo.Text = StringResources.Modelo;
            this.colGarantia.Text = StringResources.garantia;
            this.colSerial.Text = StringResources.Serial;
            this.colProcedencia.Text = StringResources.Procedencia;
            //
            this.btoBuscar.Text = StringResources.btnBuscar;
            this.btoSalir.Text = StringResources.btnSalir;
            this.btoAceptar.Text = StringResources.btoAceptar;
            //
            this.lblCodigo.Text = StringResources.Codigo;
            this.lblArticulo.Text = StringResources.Articulo;
        }
    }
}
