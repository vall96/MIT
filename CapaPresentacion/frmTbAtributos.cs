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
    public partial class frmTbAtributos : Form
    {
        DataTable dtAt;
        //-----------------------------------------------------------
        ListViewItem lvrow;
        DataTable dt = new DataTable();
        clsEmpresa M = new clsEmpresa();
        public static string estado="", tipoPais = "";

        int pos = 0,j=0;
        string cod, des, mensajeText, mensajeCaption,codAtrib, codAt;
        frmAtributos venAtributos;
        public delegate void relacion(DataTable dtMaquina);
        public event relacion dtRelAtributos;
        public delegate void pasar(string[,] dato);
        public event pasar pasado;
        public string[,] datos = new string[1, 8];
        DataTable dtAtrib;

        public static string _Codigo, _Descripcion;
        //-----------------------------------------------
        public frmTbAtributos()
        {
            InitializeComponent();
            cargarLista();
            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();

        }
        private void frmTbAtributos_Load(object sender, EventArgs e)
        {
            CargarListview();        
            venAtributos = new frmAtributos();
            if (frmTareas.valido=="si")
            {
                lsvAtributos.CheckBoxes = true;
            }
            else if(frmCedulaDeProducto.valido == "si")
            {
                lsvAtributos.CheckBoxes = true;
            }
            else
            {
                lsvAtributos.CheckBoxes = false;
            }
        }
        
        //---------------------------------------------------

        public void FuncionInicio()
        {
            if (lsvAtributos.Items.Count == 0)
            {
                this.txtCodigo.Enabled = false;
                this.txtDescripcion.Enabled = false;
            }
        }
        public void FuncionBuscar()
        {
            estado = "buscar";
            if (txtCodigo.Text == "" && txtDescripcion.Text == "")
            {
                return;
                // usuaValido = "no";
            }
            else if (txtCodigo.Text != "" && txtDescripcion.Text != "")
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
                    des = txtDescripcion.Text;
                    ValidarBuscar(cod, des);
                    LimpiarCajas();
                }
                if (frmTbAtributos.estado == "Valido")
                {
                    venAtributos.cargarDatos();
                    lsvAtributos.Items[pos].Selected = true;
                    lsvAtributos.Items[pos].Focused = true;
                    lsvAtributos.EnsureVisible(pos);
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
        private void LimpiarCajas()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
        }

        //************************************************************************
        private void btoAceptar_Click(object sender, EventArgs e)
        {
            if (frmTareas.valido == "si")
            {
                AtribSeleccionadas();
                this.Hide();
            }
            if (frmCedulaDeProducto.valido == "si")
            {
                CedAtribSeleccionadas();
                this.Hide();
            }
            else if (lsvAtributos.SelectedItems.Count > 0)
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
        }
        private void btoBuscar_Click(object sender, EventArgs e)
        {
            FuncionBuscar();
        }
        private void btoSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        //***********************************************************************
        private void FiltrarDatos()
        {
            if (frmTareas.valido == "si")
            {
                if (frmTareas.cont2 != 0)
                {
                    for (int a = 0; a < frmTareas.DtActualAtr.Rows.Count; a++)
                    {
                        codAtrib = frmTareas.DtActualAtr.Rows[a]["AtrbId"].ToString();
                        Actualizarlsv();
                    }
                }
            }
            if (frmCedulaDeProducto.valido == "si")
            {
                if (frmCedulaDeProducto.cont2 != 0)
                {
                    for (int a = 0; a < frmCedulaDeProducto.DtActualAtrib.Rows.Count; a++)
                    {
                        codAt = frmCedulaDeProducto.DtActualAtrib.Rows[a]["AtributoId"].ToString();
                        Actualizarlsv();
                    }
                }
            }
        }
        private void Actualizarlsv()
        {
            if (frmTareas.valido == "si")
            {
                for (int i = 0; i < lsvAtributos.Items.Count; i++)
                {
                    if (codAtrib == lsvAtributos.Items[i].SubItems[0].Text.ToString())
                    {
                        lsvAtributos.Items.RemoveAt(i);
                        return;
                    }
                }
            }
            if (frmCedulaDeProducto.valido == "si")
            {
                for (int i = 0; i < lsvAtributos.Items.Count; i++)
                {
                    if (codAt == lsvAtributos.Items[i].SubItems[0].Text.ToString())
                    {
                        lsvAtributos.Items.RemoveAt(i);
                        return;
                    }
                }
            }

        }
        private void cargarLista()
        {
            dt = M.ListadoAtributos(frmPrincipal.nombreBD);
        }
        private void CargarListview()
        {
           
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lvrow = new ListViewItem(dt.Rows[i]["Atrib_id"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["Atrib_descripcion"].ToString());
                this.lsvAtributos.Items.Add(lvrow);
            }
            FiltrarDatos();
        }
        private void datosSeleccionados()
        {

            if (frmTareas.valido != "si")
            {          
                if (lsvAtributos.SelectedItems.Count > 0)
                {
                _Codigo = lsvAtributos.SelectedItems[0].Text.ToString().Trim();
                _Descripcion = lsvAtributos.SelectedItems[0].SubItems[1].Text.ToString().Trim();

                datos[0, 0] = _Codigo;
                datos[0, 1] = _Descripcion;
                pasado(datos);
                estado = "valido";
                this.Hide();
                }
            }
        }

        private void lsvAtributos_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lsvAtributos.Sorting == SortOrder.Ascending)
            {
                lsvAtributos.Sorting = SortOrder.Descending;
                lsvAtributos.Sort();
            }
            else
            {
                lsvAtributos.Sorting = SortOrder.Ascending;
                lsvAtributos.Sort();
            }
        }

        private void AtribSeleccionadas()
        {
              j = 0;
                ConstruccionDt();
                for (int i = 0; i < lsvAtributos.Items.Count; i++)
                {
                    if (lsvAtributos.Items[i].Checked == true)
                    {
                        dtAtrib.Rows.Add();
                        dtAtrib.Rows[j]["codigo"] = lsvAtributos.Items[i].SubItems[0].Text;
                        dtAtrib.Rows[j]["descripcion"] = lsvAtributos.Items[i].SubItems[1].Text;
                        j++;
                    }
                }
                dtRelAtributos(dtAtrib);
        }

        private void CedAtribSeleccionadas()
        {
            //if (frmCedulaDeProducto.valido == "si")
            //{
                j = 0;
                ConstruccionDt();
                for (int i = 0; i < lsvAtributos.Items.Count; i++)
                {
                    if (lsvAtributos.Items[i].Checked == true)
                    {
                        dtAt.Rows.Add();
                        dtAt.Rows[j]["codigo"] = lsvAtributos.Items[i].SubItems[0].Text;
                        dtAt.Rows[j]["descripcion"] = lsvAtributos.Items[i].SubItems[1].Text;
                        j++;
                    }
                }
                dtRelAtributos(dtAt);
            //}
        }

        private void ConstruccionDt()
        {
            if (frmTareas.valido == "si")
            {
                dtAtrib = new DataTable();
                dtAtrib.Columns.Add("codigo", Type.GetType("System.String"));
                dtAtrib.Columns.Add("descripcion", Type.GetType("System.String"));
            }
            if (frmCedulaDeProducto.valido == "si")
            {
                dtAt = new DataTable();
                dtAt.Columns.Add("codigo", Type.GetType("System.String"));
                dtAt.Columns.Add("descripcion", Type.GetType("System.String"));
            }
        }

        //*************************************************************************
        private void lsvAtributos_DoubleClick(object sender, EventArgs e)
        {
            datosSeleccionados();
        }
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                lsvAtributos.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
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
                lsvAtributos.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
                FuncionBuscar();
            }
        }

        //*************************************************************************
        public void ValidarBuscar(string CodigoP, string DescP)
        {
            lsvAtributos.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
            string palabra = "";
            estado = "";
            if (CodigoP != "")
            {
                for (int i = 0; i < lsvAtributos.Items.Count; i++)
                {
                    palabra = lsvAtributos.Items[i].SubItems[0].Text.ToLower();
                    bool existe = palabra.StartsWith(CodigoP.ToLower());

                    if (existe == true)
                    {
                        estado = "Valido";
                        _Codigo = lsvAtributos.Items[i].SubItems[0].Text.ToString().Trim();
                        _Descripcion = lsvAtributos.Items[i].SubItems[1].Text.ToString().Trim();
                        lsvAtributos.Items[i].SubItems[0].BackColor = Color.LightSeaGreen;
                        pos = i;
                        return;
                    }

                }
            }
            else if (DescP != "")
            {
                for (int i = 0; i < lsvAtributos.Items.Count; i++)
                {
                    palabra = lsvAtributos.Items[i].SubItems[1].Text.ToLower();
                    bool existe = palabra.StartsWith(DescP.ToLower());

                    if (existe == true)
                    {
                        estado = "Valido";
                        _Codigo = lsvAtributos.Items[i].SubItems[0].Text.ToString().Trim();
                        _Descripcion = lsvAtributos.Items[i].SubItems[1].Text.ToString().Trim();
                        lsvAtributos.Items[i].SubItems[0].BackColor = Color.LightSeaGreen;
                        pos = i;
                        return;
                    }
                }
            }
        }
        public void AplicarIdioma()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
            this.lblTituloPanel.Text = StringResources.Atributos;
            //
            this.Text = StringResources.Atributos;
            //
            this.lblCodigo.Text = StringResources.Codigo;
            this.lblDescripcion.Text = StringResources.Descripcion;
            //
            this.btoAceptar.Text = StringResources.btoAceptar;
            this.btoBuscar.Text = StringResources.btnBuscar;
            this.btoSalir.Text = StringResources.btnSalir;
            //
            this.codigo.Text = StringResources.Codigo;
            this.descripcion.Text = StringResources.Descripcion;
        }

    }
}
