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
    public partial class frmTbArticulosdeProduccion : Form
    {
        ListViewItem lvrow;
        DataTable dt = new DataTable();
        clsEmpresa M = new clsEmpresa();
        public static string estado = "", tipoPais = "", ValidarPro = "";

        int pos = 0;
        public string cod, des, mensajeText, mensajeCaption;
        frmCedulaDeProducto ventCedulaProducto;

        public delegate void pasar(string[,] dato);
        public event pasar pasado;
        public string[,] datos = new string[1, 10];

        public static string _CodigoPro, _DescripcionPro;
        private void btoAceptar_Click(object sender, EventArgs e)
        {
            if (lsvProductos.SelectedItems.Count > 0)
            {
                datosSeleccionados();
            }
            else
            {
                this.Close();
            }
        }
        private void lsvProductos_DoubleClick(object sender, EventArgs e)
        {
            datosSeleccionados();
        }
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                lsvProductos.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
                FuncionBuscar();
            }
        }
        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                lsvProductos.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
                FuncionBuscar();
            }
        }
        private void btoBuscar_Click(object sender, EventArgs e)
        {
            FuncionBuscar();
        }

        //---------------------------------------------------------------------------
        public frmTbArticulosdeProduccion()
        {
            InitializeComponent();
            CargarListview();

            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();
        }

        public void FuncionInicio()
        {
            if (lsvProductos.Items.Count == 0)
            {
                this.txtCodigo.Enabled = false;
                this.txtDescripcion.Enabled = false;
            }
        }

        private void frmTbArticulosdeProduccion_Load(object sender, EventArgs e)
        {
            ventCedulaProducto = new frmCedulaDeProducto();
        }

        //----------------------------------------------

        private void CargarListview()
        {
            dt = M.ListadoArticulosCedulaProducto(frmPrincipal.nombreBD);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lvrow = new ListViewItem(dt.Rows[i]["art_Id"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["art_Nom"].ToString());
                this.lsvProductos.Items.Add(lvrow);
            }
        }

        private void btoSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lsvProductos_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lsvProductos.Sorting == SortOrder.Ascending)
            {
                lsvProductos.Sorting = SortOrder.Descending;
                lsvProductos.Sort();
            }
            else
            {
                lsvProductos.Sorting = SortOrder.Ascending;
                lsvProductos.Sort();
            }
        }

        private void datosSeleccionados()
        {
            if (lsvProductos.SelectedItems.Count > 0)
            {
                _DescripcionPro = lsvProductos.SelectedItems[0].SubItems[1].Text.ToString().Trim();
                ValidarPro = "si";

                datos[0, 9] = _DescripcionPro;
                pasado(datos);
                estado = "valido";
                this.Hide();
            }
            ValidarPro = "";
        }

        private void LimpiarCajas()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
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
                if (frmTbArticulosdeProduccion.estado == "Valido")
                {
                    ventCedulaProducto.cargarDatos();
                    lsvProductos.Items[pos].Selected = true;
                    lsvProductos.Items[pos].Focused = true;
                    lsvProductos.EnsureVisible(pos);
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

        public void ValidarBuscar(string CodigoP, string DescP)
        {
            lsvProductos.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
            string palabra = "";
            estado = "";
            if (CodigoP != "")
            {
                for (int i = 0; i < lsvProductos.Items.Count; i++)
                {
                    palabra = lsvProductos.Items[i].SubItems[0].Text.ToLower();
                    bool existe = palabra.StartsWith(CodigoP.ToLower());

                    if (existe == true)
                    {
                        estado = "Valido";
                        _CodigoPro = lsvProductos.Items[i].SubItems[0].Text.ToString().Trim();
                        _DescripcionPro = lsvProductos.Items[i].SubItems[1].Text.ToString().Trim();
                        lsvProductos.Items[i].SubItems[0].BackColor = Color.LightSeaGreen;
                        pos = i;
                        return;
                    }

                }
            }
            else if (DescP != "")
            {
                for (int i = 0; i < lsvProductos.Items.Count; i++)
                {
                    palabra = lsvProductos.Items[i].SubItems[1].Text.ToLower();
                    bool existe = palabra.StartsWith(DescP.ToLower());

                    if (existe == true)
                    {
                        estado = "Valido";
                        _CodigoPro = lsvProductos.Items[i].SubItems[0].Text.ToString().Trim();
                        _DescripcionPro = lsvProductos.Items[i].SubItems[1].Text.ToString().Trim();
                        lsvProductos.Items[i].SubItems[0].BackColor = Color.LightSeaGreen;
                        pos = i;
                        return;
                    }
                }
            }
        }

        public void AplicarIdioma()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
            this.lblTituloPanel.Text = StringResources.ArticulosdeProduccion;
            //
            this.Text = StringResources.ArticulosdeProduccion;
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
