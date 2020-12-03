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
    public partial class frmTbStatusdeMaquinas : Form
    {
        ListViewItem lvrow;
        DataTable dt = new DataTable();
        clsEmpresa M = new clsEmpresa();

        public delegate void pasar(string[,] dato);
        public event pasar pasado;
        public string[,] datos = new string[1, 8];

        int pos = 0;

        public static string _Codigo, _Descripcion;

        public static string estado = "", tipoPais = "";

        public string cod, des, mensajeText, mensajeCaption;

        frmEstatusdeMaquina venEstatusMaquina;

        public frmTbStatusdeMaquinas()
        {
            InitializeComponent();
            CargarListview();

            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();
        }
        
        private void frmTbStatusdeMaquinas_Load(object sender, EventArgs e)
        {
            lsvEstatusMaquina.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
           // this.lsvEstatusMaquina.FullRowSelect = true;
            //this.lsvEstatusMaquina.OwnerDraw = true;
         
            FuncionInicio();

            venEstatusMaquina = new frmEstatusdeMaquina();
        }

        public void FuncionInicio()
        {
            if (lsvEstatusMaquina.Items.Count == 0)
            {
                this.txtCodigo.Enabled = false;
                this.txtDescripcion.Enabled = false;
            }
            
        }

        private void CargarListview()
        {
            dt = M.ListadoStatusMaquina(frmPrincipal.nombreBD);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lvrow = new ListViewItem(dt.Rows[i]["EstMaq_id"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["EstMaq_descripcion"].ToString());
                this.lsvEstatusMaquina.Items.Add(lvrow);
            }
        }

        private void btoAceptar_Click(object sender, EventArgs e)
        {
            if (lsvEstatusMaquina.SelectedItems.Count > 0)
            {
                datosSeleccionados();
            }
            else
            {
                this.Close();
            }
        }

        private void btoSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lsvCategoria_DoubleClick(object sender, EventArgs e)
        {
            datosSeleccionados();
        }

        private void datosSeleccionados()
        {
            if (lsvEstatusMaquina.SelectedItems.Count > 0)
            {
                _Codigo = lsvEstatusMaquina.SelectedItems[0].Text.ToString().Trim();
                _Descripcion = lsvEstatusMaquina.SelectedItems[0].SubItems[1].Text.ToString().Trim();

                datos[0, 0] = _Codigo;
                datos[0, 1] = _Descripcion;
                pasado(datos);
                estado = "valido";
                this.Hide();

            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                lsvEstatusMaquina.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
                FuncionBuscar();
            }
        }

        private void btoBuscar_Click(object sender, EventArgs e)
        {
            FuncionBuscar();
        }

        private void lsvEstatusMaquina_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lsvEstatusMaquina.Sorting == SortOrder.Descending)
            {
                lsvEstatusMaquina.Sorting = SortOrder.Ascending;
                lsvEstatusMaquina.Sort();
            }
            else
            {
                lsvEstatusMaquina.Sorting = SortOrder.Descending;
                lsvEstatusMaquina.Sort();
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                lsvEstatusMaquina.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
                FuncionBuscar();
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
                 mensajeText = StringResources.No_se_puede_realizar_la_busqueda_con_todos_los_campos_llenos;
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
                if (frmTbStatusdeMaquinas.estado == "Valido")
                {
                    venEstatusMaquina.cargarDatos();
                    lsvEstatusMaquina.Items[pos].Selected = true;
                    lsvEstatusMaquina.Items[pos].Focused = true;
                    lsvEstatusMaquina.EnsureVisible(pos);
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

        public void ValidarBuscar(string CodigoP, string DescP)
        {
            lsvEstatusMaquina.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
            string palabra = "";
            estado = "";
            if (CodigoP != "")
            {
                for (int i = 0; i < lsvEstatusMaquina.Items.Count; i++)
                {
                    palabra = lsvEstatusMaquina.Items[i].SubItems[0].Text.ToLower();
                    bool existe = palabra.StartsWith(CodigoP.ToLower());

                    if (existe == true)
                    {
                        estado = "Valido";
                        _Codigo = lsvEstatusMaquina.Items[i].SubItems[0].Text.ToString().Trim();
                        _Descripcion = lsvEstatusMaquina.Items[i].SubItems[1].Text.ToString().Trim();
                        lsvEstatusMaquina.Items[i].SubItems[0].BackColor = Color.LightSeaGreen;
                        pos = i;
                        return;
                    }

                }
            }
            else if (DescP != "")
            {
                for (int i = 0; i < lsvEstatusMaquina.Items.Count; i++)
                {
                    palabra = lsvEstatusMaquina.Items[i].SubItems[1].Text.ToLower();
                    bool existe = palabra.StartsWith(DescP.ToLower());                      //aquiiiiiiiiiiiiiiiiiiiiiii

                    if (existe == true)
                    {
                        estado = "Valido";
                        _Codigo = lsvEstatusMaquina.Items[i].SubItems[0].Text.ToString().Trim();
                        _Descripcion = lsvEstatusMaquina.Items[i].SubItems[1].Text.ToString().Trim();
                        lsvEstatusMaquina.Items[i].SubItems[0].BackColor = Color.LightSeaGreen;
                        pos = i;
                        return;
                    }
                }
            }
        }
            public void AplicarIdioma()
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
                this.lblTituloPanel.Text = StringResources.EstatusDeMaquina;
                //
                this.Text = StringResources.EstatusDeMaquina;
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
