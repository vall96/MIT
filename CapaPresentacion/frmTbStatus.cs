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

namespace CapaPresentacion
{
    public partial class frmTbStatus : Form
    {
        public frmTbStatus()
        {
            InitializeComponent();
            cargarLsvStatus();

            tipoPais = frmRegristroUsuario.tipoPais;

            Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);

            AplicarIdioma();
            LimpiarCajas();
        }
        public string estadoactual;
        private clsStatus lstview = new clsStatus();
        private clsStatus Stat = new clsStatus();
        ListViewItem lvrow;
        public frmPrincipal ventPrincipal = new frmPrincipal();
        public frmStaUsuario ventStatus;
        int num_status,a,pos=0;
        public static string usuaValido = "", estado = "", _codigo, _descripcion = "";
        public static string status = "", descrip = "";
        //+++++++++++++++++++++++++++++++++++++++++
        public string mensajeText = "", mensajeCaption = "";
        public static string tipoPais = "";
        //*************PARA EL DELEGATE/*******************
        public delegate void pasar(string[,] dato);        //firma tipo de metodo
        public event pasar pasado;
        public string[,] datos = new string[1, 4];
        //***************************************************
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            lsvStatus.Items[pos].SubItems[0].BackColor = Color.White;
            funcionBuscar();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                lsvStatus.Items[pos].SubItems[0].BackColor = Color.White;
                funcionBuscar();
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                lsvStatus.Items[pos].SubItems[0].BackColor = Color.White;
                funcionBuscar();
            }
        }

        private void btoSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            //ventStatus.Show();
        }

        private void lsvStatus_DoubleClick(object sender, EventArgs e)
        {
          datosSeleccionados();
        }

        private void datosSeleccionados()
        {
           // pasado = new pasar (datos);
            if (lsvStatus.SelectedItems.Count > 0)
            {

                _codigo = lsvStatus.SelectedItems[0].Text.ToString().Trim();
                _descripcion = lsvStatus.SelectedItems[0].SubItems[1].Text.ToString().Trim();
               // ventStatus.cargarDatos();
             //   ventStatus.Show();
                usuaValido = "estado valido";

                datos[0, 0] = _codigo;
                datos[0, 1] = _descripcion;                
                pasado(datos);

                // ventStatus.HabilitarBotones();
                this.Hide();
            }
        }

        private void btoAceptar_Click(object sender, EventArgs e)
        {
            if (lsvStatus.SelectedItems.Count > 0)
            {
                datosSeleccionados();
            }
            else if (estado == "buscar")
            {
                usuaValido = "estado valido";
                //ventStatus.HabilitarBotones();
                //ventStatus.cargarDatos();
                //ventStatus.Show();
                datos[0, 0] = _codigo;
                datos[0, 1] = _descripcion;
                estado = "";
                pasado(datos);
            }
            else
            {
                //ventStatus.Show();
            }
            this.Hide();
        }

        private void frmTbStatus_Load(object sender, EventArgs e)
        {
            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();

            ventStatus = new frmStaUsuario();

            this.lsvStatus.FullRowSelect = true;
            this.lsvStatus.OwnerDraw = true;

            this.Location = new System.Drawing.Point(710, 130);

            FuncionInicio();
            lsvStatus.SelectedItems.Clear();
        }

        private void FuncionInicio()
        {
            if (lsvStatus.Items.Count == 0)
            {
                this.txtCodigo.Enabled = false;
                this.txtDescripcion.Enabled = false;
            }
            else
            {
                lsvStatus.Items[pos].SubItems[0].BackColor = Color.White;
            }
        }
        private void lsvStatus_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.DarkOrange, e.Bounds);
            e.DrawText();
        }

        private void lsvStatus_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lsvStatus_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lsvStatus.Sorting == SortOrder.Ascending)
            {
                lsvStatus.Sorting = SortOrder.Descending;
                lsvStatus.Sort();
            }
            else
            {
                lsvStatus.Sorting = SortOrder.Ascending;
                lsvStatus.Sort();
            }
        }

        public void cargarLsvStatus()
        {
            this.lsvStatus.Items.Clear();
            DataTable dt = new DataTable();
            dt = lstview.Listado_status();
            num_status = dt.Rows.Count;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lvrow = new ListViewItem(dt.Rows[i]["st_status"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["st_descripcion"].ToString());
                this.lsvStatus.Items.Add(lvrow);
            }
        }

        public void funcionBuscar()
        {
            estado = "buscar";
            if (txtCodigo.Text == "" && txtDescripcion.Text == "")
            {
                return;
            }
            else if (txtCodigo.Text!="" && txtDescripcion.Text!="")
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
                if (txtCodigo.Text!="")
                {
                    status = txtCodigo.Text;
                    descrip = "";
                    ValidarStatus_Buscar(status, descrip,"buscar");
                    LimpiarCajas();
                }
                else
                {
                    status = "";
                    descrip = txtDescripcion.Text;
                    ValidarStatus_Buscar(status, descrip, "buscar");
                    LimpiarCajas();
                }
            }
            //***********Parte para cargar datos al otro formulario*********************************
            if (usuaValido== "estado valido")
            {
                //***********Cargaras datos otro form
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.NoSeEncontroInformacion;
                mensajeCaption = StringResources.ErrordeValidacion;

                MessageBox.Show(mensajeText, mensajeCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                this.txtCodigo.Focus();
                LimpiarCajas();
            }
        }

        private void LimpiarCajas()
        {
            txtCodigo.Text = "";
           txtDescripcion.Text = "";
        }
        public void ValidarStatus_Buscar(string codigo, string descripcion, string buscar)
        {
            lsvStatus.Items[pos].SubItems[0].BackColor = Color.White;
            usuaValido = "";
            string palabra = "";

            if (codigo != "")
            {
                for (int i = 0; i < lsvStatus.Items.Count; i++)
                {
                    if (lsvStatus.Items[i].SubItems[0].Text.ToLower() == codigo.ToLower())
                    {
                        a = i;
                        cargarVariables();
                        return;
                    }
                }

            }
            else if (descripcion != "")
            {
                lsvStatus.Items[pos].SubItems[0].BackColor = Color.White;
                for (int i = 0; i < lsvStatus.Items.Count; i++)
                {
                    palabra = lsvStatus.Items[i].SubItems[1].Text.ToLower();
                    bool existe = palabra.StartsWith(descripcion.ToLower());

                    if (existe == true)
                    {
                        a = i;
                        cargarVariables();
                        return;
                    }

                    //if (lsvStatus.Items[i].SubItems[1].Text == descripcion)
                    //{
                    //    a = i;
                    //    cargarVariables();
                    //}
                }
            }
        }

        public void ActualizarListview(string accion)
        {
            switch (accion)
            {
                case "agregar":
                    lvrow = new ListViewItem(frmStaUsuario.codigo);
                    lvrow.SubItems.Add(frmStaUsuario.descrip);
                    this.lsvStatus.Items.Add(lvrow);
                    num_status++;
                    break;

                case "editar":
                    ValidarStatus_Buscar(frmStaUsuario.codigo, "", "buscar");
                    lsvStatus.Items[pos].SubItems[0].BackColor = Color.White;
                    lsvStatus.Items[pos].SubItems[1].Text = frmStaUsuario.descrip;
                    break;
                case "eliminar":
                    ValidarStatus_Buscar(frmStaUsuario.codigo, "", "buscar");
                    lsvStatus.Items[pos].SubItems[0].BackColor = Color.White;
                    lsvStatus.Items.RemoveAt(pos);
                    pos = 0;
                    num_status--;
                    break;
            }
        }
        public void cargarVariables()
        {
            
            usuaValido = "estado valido";
            _codigo = lsvStatus.Items[a].SubItems[0].Text.ToString().Trim();
            _descripcion = lsvStatus.Items[a].SubItems[1].Text.ToString().Trim();
            lsvStatus.Items[a].SubItems[0].BackColor = Color.LightSeaGreen;
            pos = a;
        }

        public void AplicarIdioma()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);

            this.Text = StringResources.TablaStatus;

            this.lblTituloPanel.Text = StringResources.TablaStatus;
            //label's
            this.lblCodiog.Text = StringResources.Codigo;
            this.lblDescripcion.Text = StringResources.Descripcion;
            //bto's
            this.btoBuscar.Text = StringResources.btnBuscar;
            this.btoAceptar.Text = StringResources.btoAceptar;
            this.btoSalir.Text = StringResources.btnSalir;
            //list 
            this.codigo.Text = StringResources.Codigo;
            this.descripcion.Text = StringResources.Descripcion;
        }
    }
}
