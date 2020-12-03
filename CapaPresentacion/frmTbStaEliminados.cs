using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CultureResources;
using System.Threading;
using System.Globalization;
using System.Windows.Forms;
using CapaLogicaNegocios;


namespace CapaPresentacion
{
    public partial class frmTbStaEliminados : Form
    {
        public frmTbStaEliminados()
        {
            InitializeComponent();
            cargarLsv();
            this.txtCodigo.Enabled = true;
            this.BtoEliminarTodo.Enabled = true;

            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();

        }

        public string mensajeText = "", mensajeCaption = "";
        public static string tipoPais = "";

        ListViewItem lvrow;
        int num_status, a, pos = 0;

        private clsStatus Stat = new clsStatus();
        public static string estadoactual = "", usuaValido = "";
        public static string _codigo, _descripion = "";
        string descrip = "", cod = "", estado = "";
        frmStaEliminados ventStaEliminado;
        //*************PARA EL DELEGATE/*******************
        public delegate void pasar(string[,] dato);        //firma tipo de metodo
        public event pasar pasado;
        public string[,] datos = new string[1, 4];
        //***************************************************
        private void btnSalir_Click(object sender, EventArgs e)
        {
            //ventStaEliminado.Show();
           // frmUsuariosEliminados.ventana++;
            this.Hide();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))

            {
                lsvStatusElimi.Items[pos].SubItems[0].BackColor = Color.White;
                FuncionBuscar();
                //BuscarUsuario_Eliminado();


            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                lsvStatusElimi.Items[pos].SubItems[0].BackColor = Color.White;
                FuncionBuscar();
            }
                       
        }

        private void lsvStatusElimi_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lsvStatusElimi_DoubleClick(object sender, EventArgs e)
        {
            datosSeleccionados();
        }

        private void BtoEliminarTodo_Click(object sender, EventArgs e)
        {
            string msj = "";
            DialogResult respuesta;
            Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
            mensajeText = StringResources.frmStaEliminados_messDeseaEliminarUser;
            mensajeCaption = StringResources.ValidacióndeEliminación;

            respuesta = MessageBox.Show(mensajeText, mensajeCaption,
            MessageBoxButtons.YesNo);

            if (respuesta == DialogResult.Yes)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
                msj = Stat.EliminarStatus_Todos();
                mensajeCaption = StringResources.ValidacióndeEliminación;
                if (msj== "Eliminacion exitosa")
                {
                    msj = StringResources.DBEliminacionexitosa;
                    MessageBox.Show(msj, mensajeCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }
                lsvStatusElimi.Items.Clear();
            }
        }

        private void btoAceptar_Click(object sender, EventArgs e)
        {
            if (lsvStatusElimi.SelectedItems.Count > 0)
            {
                datosSeleccionados();
            }
            else
            {
                if (estado == "buscar")
                {
                    //frmUsuarioPruebaEstilo.MdiParent = ventPrincipal;           //OJOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                    usuaValido = "usuario valido";
                    //ventStaEliminado.HabilitarBotones();
                    //ventPrincipal.accionesFormularios("FrmTbUsuariosPrueba", "inicial");
                    //ventStaEliminado.Show();
                    datos[0, 0] = _codigo;
                    datos[0, 1] = _descripion;
                    estado = "";
                    pasado(datos);
                }
                else
                {
                    //frmUsuarioPruebaEstilo.Location = new System.Drawing.Point(0, 75);
                    //ventStaEliminado.Show();
                    //ventStaEliminado.FuncionInicio();
                }
            }

            this.Hide();
        }

        private void lsvStatusElimi_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.DarkOrange, e.Bounds);
            e.DrawText();
        }

        private void frmTbStaEliminados_Load(object sender, EventArgs e)
        {
            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();
            lsvStatusElimi.SelectedItems.Clear();
            this.lsvStatusElimi.OwnerDraw = true;
            ventStaEliminado = new frmStaEliminados();
            this.Location = new System.Drawing.Point(710, 130);
            FuncionInicio();


        }

        private void frmTbStaEliminados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void lsvStatusElimi_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lsvStatusElimi.Sorting == SortOrder.Ascending)
            {
                lsvStatusElimi.Sorting = SortOrder.Descending;
                lsvStatusElimi.Sort();
            }
            else
            {
                lsvStatusElimi.Sorting = SortOrder.Ascending;
                lsvStatusElimi.Sort();
            }
        }

        public void FuncionInicio()
        {
            if (lsvStatusElimi.Items.Count > 0)
            {
                if (lsvStatusElimi.SelectedItems.Count > 0)
                {
                    lsvStatusElimi.Items[pos].SubItems[0].BackColor = Color.White;
                }
               
            }
            else
            {
                this.BtoEliminarTodo.Enabled = false;
                txtCodigo.Enabled = false;
                txtDescripcion.Enabled = false;
                this.btnBuscar.Enabled = false;
            }

        }

        public void BuscarEstados_Eliminado(string codigo, string descripcion, string buscar)
        {
            string palabra = "";
            usuaValido = "";
            estadoactual = "buscar";

            if (codigo != "")
            {
                //BUSCAR DESDE LIST VIEW
                for (int i = 0; i < lsvStatusElimi.Items.Count; i++)
                {

                    if (lsvStatusElimi.Items[i].SubItems[0].Text == codigo)
                    {
                        _codigo = lsvStatusElimi.Items[i].SubItems[0].Text;
                        _descripion = lsvStatusElimi.Items[i].SubItems[1].Text;
                        usuaValido = "estado valido";
                        lsvStatusElimi.Items[i].SubItems[0].BackColor = Color.LightSeaGreen;
                        pos = i;
                        return;
                    }
                }
            }
            else if (descripcion != "")
            {
                for (int i = 0; i < lsvStatusElimi.Items.Count; i++)
                {

                    palabra = lsvStatusElimi.Items[i].SubItems[1].Text.ToLower();
                    bool existe = palabra.StartsWith(descripcion.ToLower());
                    if (existe == true)
                    {
                        _codigo = lsvStatusElimi.Items[i].SubItems[0].Text;
                        _descripion = lsvStatusElimi.Items[i].SubItems[1].Text;
                        usuaValido = "estado valido";
                        lsvStatusElimi.Items[i].SubItems[0].BackColor = Color.LightSeaGreen;
                        pos = i;
                        return;
                    }
                    //if (lsvStatusElimi.Items[i].SubItems[1].Text == descripcion)
                    //{
                    //    _codigo = lsvStatusElimi.Items[i].SubItems[0].Text;
                    //    _descripion = lsvStatusElimi.Items[i].SubItems[1].Text;
                    //    usuaValido = "estado valido";
                    //    lsvStatusElimi.Items[i].SubItems[0].BackColor = Color.LightSeaGreen;
                    //    pos = i;
                    //}
                }
            }
        }
        private void FuncionBuscar()
        {
            estado = "buscar";
            if (txtCodigo.Text == "" && txtDescripcion.Text == "")
            {
                // MessageBox.Show("Debe ingresar un Usuario o nombre para realizar la busqueda",
                //"Error de Validacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                // this.txtUsuario.Focus();
                return;
                // usuaValido = "no";
            }
            else if ((txtCodigo.Text != "" && txtDescripcion.Text != ""))
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.No_se_puede_realizar_la_busqueda_con_todos_los_campos_llenos;
                mensajeCaption = StringResources.ErrordeValidacion;

                MessageBox.Show(mensajeText, mensajeCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error); this.txtCodigo.Focus();
                return;
            }
            else
            {
                if (txtCodigo.Text != "")
                {
                    cod = txtCodigo.Text;
                    descrip = "";
                    BuscarEstados_Eliminado(cod, descrip, estado);
                }
                else
                {
                    cod = "";
                    descrip = txtDescripcion.Text;
                    BuscarEstados_Eliminado(cod, descrip, estado);

                }
                if (usuaValido == "estado valido")
                {
                    // frmUsuarioPruebaEstilo.cargarDatos();

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
                    //LimpiarCajas();
                }
            }
        }
        public void datosSeleccionados()
        {
            if (lsvStatusElimi.SelectedItems.Count > 0)
            {
                _codigo = lsvStatusElimi.SelectedItems[0].Text;
                _descripion = lsvStatusElimi.SelectedItems[0].SubItems[1].Text;
                ventStaEliminado.cargarDatos();
                //frmUsuarioPruebaEstilo.MdiParent = ventPrincipal;           //OJOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                //ventStaEliminado.Show();
                datos[0, 0] = _codigo;
                datos[0, 1] = _descripion;
                pasado(datos);
                usuaValido = "estado valido";
               // ventStaEliminado.HabilitarBotones();
                this.Hide();
            }
            else
            {
               // ventStaEliminado.MdiParent = ventPrincipal;           //OJOOOOOOOOOOOOOOOOOOOOOOOOOOOO
               // ventStaEliminado.Show();
                return;
            }
        }
        private void cargarLsv()
        {
            this.lsvStatusElimi.Items.Clear();
            DataTable dt = new DataTable();
            dt = Stat.Listado_statusEliminados();
            num_status = dt.Rows.Count;

            for (int i = 0; i < num_status; i++)
            {
                lvrow = new ListViewItem(dt.Rows[i]["st_status"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["st_descripcion"].ToString());
                this.lsvStatusElimi.Items.Add(lvrow);
            }
        }
        public void actualizarlsv(string accion)
        {
            switch (accion)
            {
                case "eliminar":
                    BuscarEstados_Eliminado(frmUsuariosEliminados.user, "", "buscar");
                    lsvStatusElimi.Items[pos].SubItems[0].BackColor = Color.White;
                    lsvStatusElimi.Items.RemoveAt(pos);
                    num_status--;
                    break;
            }
        }

        public void AplicarIdioma()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);

            this.Text = StringResources.frmStaEliminados_TituloFORMUALRIO;

            this.lblTituloPanel.Text = StringResources.BtoEliminarTodo_Text;

            this.lblCodigo.Text = StringResources.Codigo;
            this.lblDescripcion.Text = StringResources.Descripcion;

            this.btnBuscar.Text = StringResources.btnBuscar;
            this.btoSalir.Text = StringResources.btnSalir;
            this.BtoEliminarTodo.Text = StringResources.BtoEliminarTodo_Text;
            this.btoAceptar.Text = StringResources.btoAceptar;

            // IDIOMA DEL LISTVIEW
            this.Codigo.Text = StringResources.Codigo;
            this.descripcion.Text = StringResources.Descripcion;
        }

    }
}
