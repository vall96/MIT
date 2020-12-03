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
    public partial class frmTbCategoria : Form
    {
        //--------------VALERIE-----------------

        public static string estado = "";
        public static string _Codigo, _Descripcion;
        int pos = 0;
        public string cod, des, mensajeText, mensajeCaption, tipoPais = "";
        frmCategoria venCategoria;

        //--------------------------------------
        public frmTbCategoria()
        {
            InitializeComponent();
            cargarlsv();
            //vale
            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();

        }
        clsEmpresa M = new clsEmpresa();
        ListViewItem lvrow;
        public delegate void pasar(string[,] dato);
        public event pasar pasado;
        public string[,] datos = new string[1, 4];
        //--------------------------------------------------
        private void cargarlsv()
        {
            this.lsvCategoria.Items.Clear();
            DataTable dt = new DataTable();
            dt = M.ListadoCategoria(frmPrincipal.nombreBD);
            for (int i=0; i<dt.Rows.Count;i++)
            {
                lvrow = new ListViewItem(dt.Rows[i]["cat_id"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["cat_descripcion"].ToString());
                this.lsvCategoria.Items.Add(lvrow);
            }
        }
        private void datosSeleccionados()
        {
            if (lsvCategoria.SelectedItems.Count > 0)
            {
                _Codigo = lsvCategoria.SelectedItems[0].Text.ToString().Trim();
                _Descripcion = lsvCategoria.SelectedItems[0].SubItems[1].Text.ToString().Trim();

                datos[0, 0] = _Codigo;
                datos[0, 1] = _Descripcion;
                pasado(datos);
                estado = "valido";
                this.Hide();

            }
        }

        //BOTONES 
        private void btoSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btoAceptar_Click(object sender, EventArgs e)
        {
            if (lsvCategoria.SelectedItems.Count > 0)
            {
                datosSeleccionados();
            }
            else
            {
                this.Close();
            }
        }

        //-----------------------FUNCIONES------------------.
        public void FuncionInicio()
        {
            if (lsvCategoria.Items.Count == 0)
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
                if (frmTbCategoria.estado == "Valido")
                {
                    venCategoria.cargarDatos();
                    lsvCategoria.Items[pos].Selected = true;
                    lsvCategoria.Items[pos].Focused = true;
                    lsvCategoria.EnsureVisible(pos);
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
        private void btoBuscar_Click(object sender, EventArgs e)
        {
            FuncionBuscar();
        }
        private void LimpiarCajas()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
        }
        public void ValidarBuscar(string CodigoP, string DescP)
        {
            lsvCategoria.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
            string palabra = "";
            estado = "";
            if (CodigoP != "")
            {
                for (int i = 0; i < lsvCategoria.Items.Count; i++)
                {
                    palabra = lsvCategoria.Items[i].SubItems[0].Text.ToLower();
                    bool existe = palabra.StartsWith(CodigoP.ToLower());

                    if (existe == true)
                    {
                        estado = "Valido";
                        _Codigo = lsvCategoria.Items[i].SubItems[0].Text.ToString().Trim();
                        _Descripcion = lsvCategoria.Items[i].SubItems[1].Text.ToString().Trim();
                        lsvCategoria.Items[i].SubItems[0].BackColor = Color.LightSeaGreen;
                        pos = i;
                        return;
                    }

                }
            }
            else if (DescP != "")
            {
                for (int i = 0; i < lsvCategoria.Items.Count; i++)
                {
                    palabra = lsvCategoria.Items[i].SubItems[1].Text.ToLower();
                    bool existe = palabra.StartsWith(DescP.ToLower());

                    if (existe == true)
                    {
                        estado = "Valido";
                        _Codigo = lsvCategoria.Items[i].SubItems[0].Text.ToString().Trim();
                        _Descripcion = lsvCategoria.Items[i].SubItems[1].Text.ToString().Trim();
                        lsvCategoria.Items[i].SubItems[0].BackColor = Color.LightSeaGreen;
                        pos = i;
                        return;
                    }
                }
            }
        }

        private void lsvCategoria_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lsvCategoria.Sorting == SortOrder.Ascending)
            {
                lsvCategoria.Sorting = SortOrder.Descending;
                lsvCategoria.Sort();
            }
            else
            {
                lsvCategoria.Sorting = SortOrder.Ascending;
                lsvCategoria.Sort();
            }
        }

        //----------------------------------------------------
        private void frmTbCategoria_Load(object sender, EventArgs e)
        {
            venCategoria = new frmCategoria();
        }

        
        // -----------eventos --------------------------------------

        private void lsvCategoria_DoubleClick(object sender, EventArgs e)
        {
            datosSeleccionados();
        }
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                lsvCategoria.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
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
                lsvCategoria.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
                FuncionBuscar();
            }
        }
        public void AplicarIdioma()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
            this.lblTituloPanel.Text = StringResources.Categoria;
            //
            this.Text = StringResources.Categoria;
            //
            this.lblCodiog.Text = StringResources.Codigo;
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
