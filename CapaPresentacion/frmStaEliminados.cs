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
    public partial class frmStaEliminados : Form
    {
        public frmStaEliminados()
        {
            InitializeComponent();
            this.toolStripBtoRestaurar.Enabled = false;
            this.toolStripBtoEliminar.Enabled = false;
            FuncionInicio();

            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();

        }

        public static string tipoPais = "";
        public string mensajeText = "", mensajeCaption = "";

        private clsUsuario Usua = new clsUsuario();
        public static int ventana = 0;
        public static string cod;
        frmTbStaEliminados ventStaElimi;
        frmPrincipal venPrincipal;
        public string usuario = "", nombre = "", estado = "", accion, codigo="";
        private clsStatus Stat = new clsStatus();
        private void frmStaEliminados_Load(object sender, EventArgs e)
        {
            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();

            this.Location = new System.Drawing.Point(0, 0);
            ventStaElimi = new frmTbStaEliminados();
            venPrincipal = new frmPrincipal();
          //  venPrincipal.MdiChildren = this;
        }

        private void btnPuntos_Click(object sender, EventArgs e)
        {
            //this.Hide();
            if (ventana == 0)
            {
                //venPrincipal.accionesFormularios("frmtbStaEliminados", "inicial");
                ventStaElimi = new frmTbStaEliminados();
                ventStaElimi.pasado += new frmTbStaEliminados.pasar(ejecutar);
                ventStaElimi.ShowDialog();
                ventana++;
            }
            else
            {
                ventStaElimi.pasado += new frmTbStaEliminados.pasar(ejecutar);
                ventStaElimi.ShowDialog();
            }
        }

        public void ejecutar(string[,] dato)
        {
            txtCodigo.Text = dato[0, 0];
            txtCod.Text = dato[0, 0];
            txtDescrip.Text = dato[0, 1];
            txtDescripcion.Text = dato[0, 1];
            this.toolStripBtoDescartar.Enabled = true;
            this.toolStripBtoEliminar.Enabled = true;
            this.toolStripBtoRestaurar.Enabled= true;
            this.btnBuscar.Enabled = false;
        }
        public void FuncionInicio()
        {
            this.toolStripBtoRestaurar.Enabled = false;
            this.toolStripBtoEliminar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = false;
            this.btnBuscar.Enabled = true;
            txtCod.Enabled = false;
            txtDescrip.Enabled = false;
            // cboStatus.Visible = false;
            txtDescripcion.Enabled = true;
            txtCodigo.Enabled = true;
            this.txtCodigo.Focus();
        }

        private void btoSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void cargarDatos()
        {

            txtCodigo.Text = frmTbStaEliminados._codigo;
            txtCod.Text = frmTbStaEliminados._codigo;
            txtDescrip.Text = frmTbStaEliminados._descripion;
            txtDescripcion.Text = frmTbStaEliminados._descripion;
            this.Refresh();
        }
        private void toolStripBtoDescartar_Click(object sender, EventArgs e)
        {
            LimpiarCajas();
            FuncionInicio();
        }

        private void botBuscar_Click(object sender, EventArgs e)
        {
            FuncionBuscar();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                FuncionBuscar();
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                FuncionBuscar();
            }
        }

        private void frmStaEliminados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                if (frmTbStaEliminados.usuaValido == "estado valido")
                {
                    accion = "eliminar";
                    string msj = "";
                    string status = "";
                    status = txtCod.Text.ToString().Trim();
                    Stat.m_status = Int32.Parse(status.ToString());
                    msj = Stat.restaurar_Status();

                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    mensajeCaption = StringResources.frmUsuarioEstiloPrueba_TituloValidacionDeActualizacion;
                    if (msj == "Eliminacion exitosa")
                    {
                        msj = StringResources.DBEliminacionexitosa;
                        MessageBox.Show(msj, mensajeCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                    cod = status;
                    //user = txtCodigo.Text.ToString().Trim();
                    ventStaElimi.actualizarlsv(accion);
                    LimpiarCajas();
                    FuncionInicio();
                }
            }
            if (e.KeyCode == Keys.F8)
            {
                accion = "eliminar";
                if (frmTbStaEliminados.usuaValido == "estado valido")
                {
                    string msj = "";
                    string status = "";

                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    mensajeText = StringResources.frmStaEliminados_messDeseaEliminarUser;
                    mensajeCaption = StringResources.ValidacióndeEliminación;

                    DialogResult respuesta;

                    respuesta = MessageBox.Show("¿" + mensajeText + "" +
                    txtCodigo.Text.ToString().Trim() + " ?", mensajeCaption,
                    MessageBoxButtons.YesNo);

                    if (respuesta == DialogResult.Yes)
                    {
                        status = txtCod.Text.ToString().Trim();
                        Stat.m_status = Int32.Parse(status.ToString());
                        msj = Stat.EliminarStatus_Permanente();

                        Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                        mensajeCaption = StringResources.ValidacióndeEliminación;
                        if (msj == "Eliminacion exitosa")
                        {
                            msj = StringResources.DBEliminacionexitosa;
                            MessageBox.Show(msj, mensajeCaption,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        }
                                                
                        cod = status;
                        //user = txtCodigo.Text.ToString().Trim();
                        ventStaElimi.actualizarlsv(accion);
                        LimpiarCajas();
                        FuncionInicio();
                    }
                }
            }
            if (e.KeyCode == Keys.F9)
            {
                LimpiarCajas();
                FuncionInicio();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (frmTbStaEliminados.usuaValido == "estado valido")
            {
                accion = "eliminar";
                string msj = "";
                string status = "";
                status = txtCod.Text.ToString().Trim();
                Stat.m_status = Int32.Parse(status.ToString());
                msj = Stat.restaurar_Status();

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                mensajeCaption = StringResources.frmUsuarioEstiloPrueba_TituloValidacionDeActualizacion;

                if (msj == "Restauracion Exitosa")
                {
                    msj = StringResources.DBRestauracionExitosa;
                    MessageBox.Show(msj, mensajeCaption, 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                cod = status;
                //user = txtCodigo.Text.ToString().Trim();
                ventStaElimi.actualizarlsv(accion);
                LimpiarCajas();
                FuncionInicio();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            accion = "eliminar";
            if (frmTbStaEliminados.usuaValido == "estado valido")
            {
                string msj = "";
                string status = "";

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.frmStaEliminados_messDeseaEliminarUser;
                mensajeCaption = StringResources.ValidacióndeEliminación;

                DialogResult respuesta;

                respuesta = MessageBox.Show("¿" + mensajeText +
                txtCodigo.Text.ToString().Trim() + " ?", mensajeCaption,
                MessageBoxButtons.YesNo);

                if (respuesta == DialogResult.Yes)
                {
                    status = txtCod.Text.ToString().Trim();
                    Stat.m_status = Int32.Parse(status.ToString());
                    msj = Stat.EliminarStatus_Permanente();

                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    mensajeCaption = StringResources.ValidacióndeEliminación;

                    if (msj == "Eliminacion exitosa")
                    {
                        msj = StringResources.DBEliminacionexitosa;
                        MessageBox.Show(msj, mensajeCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    cod = status;
                    //user = txtCodigo.Text.ToString().Trim();
                    ventStaElimi.actualizarlsv(accion);
                    LimpiarCajas();
                    FuncionInicio();
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            LimpiarCajas();
            FuncionInicio();
        }

       
        public void HabilitarBotones()
        {
            this.txtCodigo.Enabled = false;
            this.txtDescripcion.Enabled = false;
            this.toolStripBtoRestaurar.Enabled = true;
            this.toolStripBtoEliminar.Enabled = true;
            this.toolStripBtoDescartar.Enabled = true;
            this.btnBuscar.Enabled = false;
        }
        private void LimpiarCajas()
        {
            txtDescripcion.Text = "";
            txtCod.Text = "";
            txtCodigo.Text = "";
            txtDescrip.Text = "";          
        }
        private void FuncionBuscar()
        {
            usuario = txtCodigo.Text;
            estado = "buscar";

            if (txtCodigo.Text == "" && txtDescripcion.Text == "")
            {
                this.txtCodigo.Focus();
                return;
            }
            else if ((txtCodigo.Text != "" && txtDescripcion.Text != ""))
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
                    usuario = txtCodigo.Text;
                    nombre = "";
                    ventStaElimi.BuscarEstados_Eliminado(usuario, nombre, estado);
                }
                else
                {
                    usuario = "";
                    nombre = txtDescripcion.Text;
                    ventStaElimi.BuscarEstados_Eliminado(usuario, nombre, estado);
                }
                if (frmTbStaEliminados.usuaValido == "estado valido")
                {
                    txtCod.Text = frmTbStaEliminados._codigo;
                    txtDescripcion.Text = frmTbStaEliminados._codigo;
                    txtDescrip.Text = frmTbStaEliminados._descripion;
                    txtDescripcion.Text = frmTbStaEliminados._descripion;
                    //  cboStatus.Text = txtDescripcion.Text;
                    HabilitarBotones();
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
        public void AplicarIdioma()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            //tite
            this.Text = StringResources.frmStaEliminados_TituloFORMUALRIO;
            //paneltit
            this.lblTitulo.Text = StringResources.frmStaEliminados_TituloFORMUALRIO;
            //label's
            this.lblCodigo.Text = StringResources.Codigo;
            this.lblDescripcion.Text = StringResources.Descripcion;
            //
            this.lblCodigo1.Text = StringResources.Codigo;
            this.lblDescripcion1.Text = StringResources.Descripcion;
            //bto's
            this.btnBuscar.Text = StringResources.btnBuscar;
            this.btoSalir.Text = StringResources.btnSalir;
            //tab
            this.tabPage1.Text = StringResources.Status;
            this.tabPage2.Text = StringResources.PropiedadesdeStatus;
            //btostrip
            this.toolStripBtoDescartar.Text = StringResources.btoDescartar;
            this.toolStripBtoEliminar.Text = StringResources.btoEliminar;
            this.toolStripBtoRestaurar.Text = StringResources.btoRestaurar;
            //tooltip
            this.toolStripBtoDescartar.ToolTipText = StringResources.btoDescartar;
            this.toolStripBtoEliminar.ToolTipText = StringResources.btoEliminar;
            this.toolStripBtoRestaurar.ToolTipText = StringResources.btoRestaurar;
            //
        }

    }
}
