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
    public partial class frmTbUnidades : Form
    {
        DataTable dt = new DataTable();
        public static string estado = "", tipoPais = "";
        public string mensajeText, mensajeCaption;
        public static string _Codigo, _Descripcion;
        frmUnidades VentUnidades;
        public string cod, des;
        int pos = 0;
        //--------------------------------------------------------------------------
        public frmTbUnidades()
        {
            InitializeComponent();
            cargarlsv();

            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();
        }
        //-----------------------------------------------------------------------------
        clsEmpresa M = new clsEmpresa();
        ListViewItem lvrow;
        public delegate void pasar(string[,] dato);
        public event pasar pasado;
        public string[,] datos = new string[1, 4];
        private void cargarlsv()
        {
            //this.lsvUnidades.Items.Clear();
            dt = M.ListadoUnidades(frmPrincipal.nombreBD);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lvrow = new ListViewItem(dt.Rows[i]["Uni_Id"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["Uni_Desc"].ToString());
                this.lsvUnidades.Items.Add(lvrow);
            }
        }
        private void datosSeleccionados()
        {
            if (lsvUnidades.SelectedItems.Count > 0)
            {
               _Codigo = lsvUnidades.SelectedItems[0].Text.ToString().Trim();
               _Descripcion= lsvUnidades.SelectedItems[0].SubItems[1].Text.ToString().Trim();

                datos[0, 0] = _Codigo;
                datos[0, 1] = _Descripcion;
                pasado(datos);
                estado = "valido";
                this.Hide();
            }
        }
        private void frmTbUnidades_Load(object sender, EventArgs e)
        {
            VentUnidades = new frmUnidades();
            //this.Location = new System.Drawing.Point(530, 130);
        }
        private void btoSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                lsvUnidades.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
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
                lsvUnidades.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
                FuncionBuscar();
            }
        }

        public void FuncionBuscar()
        {
            estado = "buscar";
            if (txtCodigo.Text == "" && txtDescripcion.Text == "")
            {
                return;
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
                if (frmTbUnidades.estado == "Valido")
                {
                    VentUnidades.cargarDatos();
                    lsvUnidades.Items[pos].Selected = true;
                    lsvUnidades.Items[pos].Focused = true;
                    lsvUnidades.EnsureVisible(pos);
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

        private void lsvUnidades_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lsvUnidades.Sorting == SortOrder.Ascending)
            {
                lsvUnidades.Sorting = SortOrder.Descending;
                lsvUnidades.Sort();
            }
            else
            {
                lsvUnidades.Sorting = SortOrder.Ascending;
                lsvUnidades.Sort();
            }
        }

        private void lsvUnidades_DoubleClick(object sender, EventArgs e)
        {
            datosSeleccionados();
        }
        public void AplicarIdioma()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
            this.lblTituloPanel.Text = StringResources.Unidades;
            //
            this.Text = StringResources.Unidades;
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
        }  //valerie 

        //-------------------------------------------------------------------------------------------
        public void ValidarBuscar(string CodigoP, string DescP)
        {
            lsvUnidades.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
            string palabra = "";
            estado = "";
            if (CodigoP != "")
            {
                for (int i = 0; i < lsvUnidades.Items.Count; i++)
                {
                    palabra = lsvUnidades.Items[i].SubItems[0].Text.ToLower();
                    bool existe = palabra.StartsWith(CodigoP.ToLower());

                    if (existe == true)
                    {
                        estado = "Valido";
                        _Codigo = lsvUnidades.Items[i].SubItems[0].Text.ToString().Trim();
                        _Descripcion = lsvUnidades.Items[i].SubItems[1].Text.ToString().Trim();
                        lsvUnidades.Items[i].SubItems[0].BackColor = Color.LightSeaGreen;
                        pos = i;
                        return;
                    }

                }
            }
            else if (DescP != "")
            {
                for (int i = 0; i < lsvUnidades.Items.Count; i++)
                {
                    palabra = lsvUnidades.Items[i].SubItems[1].Text.ToLower();
                    bool existe = palabra.StartsWith(DescP.ToLower());

                    if (existe == true)
                    {
                        estado = "Valido";
                        _Codigo = lsvUnidades.Items[i].SubItems[0].Text.ToString().Trim();
                        _Descripcion = lsvUnidades.Items[i].SubItems[1].Text.ToString().Trim();
                       lsvUnidades.Items[i].SubItems[0].BackColor = Color.LightSeaGreen;
                        pos = i;
                        return;
                    }
                }
            }
        }
        private void LimpiarCajas()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
        }

    }
}
