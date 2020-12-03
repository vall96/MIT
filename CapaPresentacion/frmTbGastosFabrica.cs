using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using CultureResources;
using CapaLogicaNegocios;
using System.Windows.Threading;

namespace CapaPresentacion
{
    public partial class frmTbGastosFabrica : Form
    {
        //--------------2020
        public delegate void relacion(DataTable dtGastosFrab);
        public event relacion dtRelGastosFrab;
        DataTable dtGastFabr;
        int j = 0;

        //------------------------------------------

        public clsEmpresa emp=new clsEmpresa();
        ListViewItem lvrow;
        public string[,] datos = new string[1, 4];
        public delegate void pasar(string[,] dato);
        public event pasar pasado;
        public string tipoPais = "", mensajeText = "", mensajeCaption = "";
        int pos = 0, i = 0, count = 0, a, numid;
        public static string tipopais = "", _Descripcion = "", _Id = "", gasto = "", estado = "", id = "", descrip = "";
        
        //**********************  load y frmTbGastosFabrica*****************
        public frmTbGastosFabrica()
        {
            InitializeComponent();
            //cargarlstvgastos();
        }
        private void frmTbGastosFabrica_Load(object sender, EventArgs e)
        {
            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();
            if (frmCedulaDeProducto.valido == "si")
            {
                lstvGastosFabrica.CheckBoxes = true;
            }
            else
            {
                lstvGastosFabrica.CheckBoxes = false;
            }
            cargarlstvgastos();
            lstvGastosFabrica.Items[pos].SubItems[0].BackColor = Color.White;
        }
        //-----------------btos----------------------------------------------------------------
        private void btoAceptar_Click(object sender, EventArgs e)
        {
            if (lstvGastosFabrica.CheckBoxes == false)
            {
                if (lstvGastosFabrica.SelectedItems.Count > 0)
                {
                    datosSeleccionados();
                }
            }
            else if (estado == "buscar")
            {
                gasto = "Valida";
                datos[0, 0] = _Id;
                datos[0, 1] = _Descripcion;
                pasado(datos);
                this.Hide();
            }
            else if (frmCedulaDeProducto.valido == "si")
            {
                GastosSeleccionados();
                this.Hide();
            }
            else
            {
                this.Close();
            }
            frmCedulaDeProducto.valido = "no";
        }
        private void btoSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btoBuscar_Click(object sender, EventArgs e)
        {
            FuncionBuscar();
        }
        //-------------------Funciones
        public void FuncionBuscar()
        {
            estado = "buscar";
            if (txtCodigo.Text == "" && txtDescripcion.Text == "")
            {
                return;
            }
            else if (txtCodigo.Text != "" && txtDescripcion.Text != "")
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
                    validarmaquina(id, descrip, "buscar");
                    limpiarcajas();
                }
                else
                {
                    id = "";
                    descrip = txtDescripcion.Text;
                    validarmaquina(id, descrip, "buscar");
                    limpiarcajas();
                }
            }
            if (gasto != "Valida")
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
        public void limpiarcajas()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
        }

        //---------------Validaciones & listas
        public void cargarlstvgastos()
        {
            this.lstvGastosFabrica.Items.Clear();
            DataTable dt = new DataTable();
            dt = emp.listarlstvGastos(frmPrincipal.nombreBD);
            for (i = 0; i < dt.Rows.Count; i++)
            {
                lvrow = new ListViewItem(dt.Rows[i]["GastosFab_id"].ToString().Trim());
                lvrow.SubItems.Add(dt.Rows[i]["GastosFab_descripcion"].ToString().Trim());
                this.lstvGastosFabrica.Items.Add(lvrow);
            }
            FiltrarDatos();
        }
        //-------2020
        string CodGastF = "";

        private void lstvGastosFabrica_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lstvGastosFabrica.Sorting == SortOrder.Ascending)
            {
                lstvGastosFabrica.Sorting = SortOrder.Descending;
                lstvGastosFabrica.Sort();
            }
            else
            {
                lstvGastosFabrica.Sorting = SortOrder.Ascending;
                lstvGastosFabrica.Sort();
            }
        }

        private void FiltrarDatos()
        {
            if (frmCedulaDeProducto.valido == "si")
            {
                if (frmCedulaDeProducto.cont3 != 0)
                {
                    for (int a = 0; a < frmCedulaDeProducto.DtActualPerf.Rows.Count; a++)
                    {
                        CodGastF = frmCedulaDeProducto.DtActualGastFabr.Rows[a]["GastFabId"].ToString();
                        Actualizarlsv();
                    }
                }
            }
        }
        private void Actualizarlsv()
        {
            for (int i = 0; i < lstvGastosFabrica.Items.Count; i++)
            {
                if (CodGastF == lstvGastosFabrica.Items[i].SubItems[0].Text.ToString())
                {
                    lstvGastosFabrica.Items.RemoveAt(i);
                    return;
                }
            }
        }


        private void datosSeleccionados()
        {
            if (lstvGastosFabrica.SelectedItems.Count > 0)
            {
                _Id = lstvGastosFabrica.SelectedItems[0].Text;
                _Descripcion = lstvGastosFabrica.SelectedItems[0].SubItems[1].Text;
                datos[0, 0] = _Id;
                datos[0, 1] = _Descripcion;
                pasado(datos);
                gasto = "Valida";
                this.Hide();
            }

            else { return; }
        }
        public void validarmaquina(string id, string descripcion, string buscar)
        {
            lstvGastosFabrica.Items[pos].SubItems[0].BackColor = Color.White;
            string palabra = "";
            if (id != "")
            {
                for (int i = 0; i < lstvGastosFabrica.Items.Count; i++)
                {
                    palabra = lstvGastosFabrica.Items[i].SubItems[0].Text.ToLower();
                    bool existe = palabra.StartsWith(id.ToLower());
                    if (existe == true)
                    {
                        a = i;
                        cargarvariable();
                        return;
                    }

                }
            }
            else if (descripcion != "")
            {
                for (int i = 0; i < lstvGastosFabrica.Items.Count; i++)
                {
                    palabra = lstvGastosFabrica.Items[i].SubItems[1].Text.ToLower();
                    bool existe = palabra.StartsWith(descripcion.ToLower());
                    if (existe == true)
                    {
                        a = i;
                        cargarvariable();
                        return;
                    }
                }
            }
        }
        public void actualizarlstv(string accion)
        {
            switch (accion)
            {
                case "agregar":
                    lvrow = new ListViewItem(frmGastosFabrica.id);
                    lvrow.SubItems.Add(frmGastosFabrica.descrip);
                    this.lstvGastosFabrica.Items.Add(lvrow);
                    break;

                case "editar":
                    validarmaquina(frmGastosFabrica.id, "", "buscar");
                    lstvGastosFabrica.Items[pos].SubItems[0].BackColor = Color.White;
                    lstvGastosFabrica.Items[pos].SubItems[1].Text = frmGastosFabrica.descrip;
                    break;

                case "eliminar":
                    validarmaquina(frmGastosFabrica.id, "", "buscar");
                    lstvGastosFabrica.Items[pos].SubItems[0].BackColor = Color.White;
                    lstvGastosFabrica.Items.RemoveAt(pos);
                    pos = 0;
                    numid--;
                    break;
            }
        }
        //---------------eventos
        private void lstvGastosFabrica_DoubleClick(object sender, EventArgs e)
        {
            datosSeleccionados();
        }
        private void frmTbGastosFabrica_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FuncionBuscar();
            }
        }
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
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
         //2020
        private void ConstruccionDT()
        {
            dtGastFabr = new DataTable();
            dtGastFabr.Columns.Add("codigo", Type.GetType("System.String"));
            dtGastFabr.Columns.Add("descripcion", Type.GetType("System.String"));
        }
        private void GastosSeleccionados()
        {
            j = 0;
            ConstruccionDT();
            for (int i = 0; i < lstvGastosFabrica.Items.Count; i++)
            {
                if (lstvGastosFabrica.Items[i].Checked == true)
                {
                    dtGastFabr.Rows.Add();
                    dtGastFabr.Rows[j]["codigo"] = lstvGastosFabrica.Items[i].SubItems[0].Text;
                    dtGastFabr.Rows[j]["descripcion"] = lstvGastosFabrica.Items[i].SubItems[1].Text;
                    j++;
                }
            }
            dtRelGastosFrab(dtGastFabr);
        }
        public void cargarvariable()
        {
            gasto = "Valida";
            _Id = lstvGastosFabrica.Items[a].SubItems[0].Text.ToString().Trim();
            _Descripcion = lstvGastosFabrica.Items[a].SubItems[1].Text.ToString().Trim();
            lstvGastosFabrica.Items[a].SubItems[0].BackColor = Color.LightSeaGreen;
            pos = a;
        }
        
        //Idioma
        public void AplicarIdioma()
        {
            //titulo
            this.Text = StringResources.frmTbGastosFabrica;
            this.lblTitulo.Text = StringResources.frmTbGastosFabrica;
            //lbl
            this.lblCodigo.Text = StringResources.Codigo;
            this.lblDescripcion.Text = StringResources.Descripcion;
            //bto
            this.btoAceptar.Text = StringResources.btoAceptar;
            this.btoBuscar.Text = StringResources.btnBuscar;
            this.btoSalir.Text = StringResources.btnSalir;
            //lstv
            this.lstvCodigo.Text = StringResources.Codigo;
            this.lstvDescripcion.Text = StringResources.Descripcion;
        }
    }
}
