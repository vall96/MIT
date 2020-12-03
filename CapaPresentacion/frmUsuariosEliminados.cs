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
    public partial class frmUsuariosEliminados : Form
    {
        public frmUsuariosEliminados()
        {
            InitializeComponent();
            this.toolStripBtoRestaurar.Enabled = false;
            this.toolStripBtoEliminar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = false;
            this.txtDescripcion.Enabled = false;
            this.txtNom.Enabled = false;
            this.txtUsua.Enabled = false;

            //tipoPais = frmRegristroUsuario.tipoPais;
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            //AplicarIdioma();

        }

        public string mensajeText = "", mensajeCaption = "";
        public static string tipoPais = "";

        private clsUsuario Usua = new clsUsuario();
        frmTbUsuariosElimi ventTbUsuariosElim;
        public static int ventana = 0;
        public string usuario = "", nombre = "", estado = "", accion;
        public static string user="";
        private void frmUsuariosEliminados_Load(object sender, EventArgs e)
        {
            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();

            this.Location = new System.Drawing.Point(0, 0);
            ventTbUsuariosElim = new frmTbUsuariosElimi();
        }

        private void btnPuntos_Click(object sender, EventArgs e)
        {
            //this.Hide();
            if (ventana == 0)
            {
                ventTbUsuariosElim = new frmTbUsuariosElimi();
                ventTbUsuariosElim.pasado += new frmTbUsuariosElimi.pasar(ejecutar);
                ventTbUsuariosElim.ShowDialog();
                ventana++;
            }
            else
            {
                ventTbUsuariosElim.pasado += new frmTbUsuariosElimi.pasar(ejecutar);
                ventTbUsuariosElim.ShowDialog();
            }
        }

        public void ejecutar(string[,] dato)
        {
            txtUsuario.Text = dato[0, 0];
            txtUsua.Text = dato[0, 0];
            txtNom.Text = dato[0, 1];
            txtNombre.Text = dato[0, 1];
            txtDescripcion.Text = dato[0, 2];
           // this.toolStripBtoEditar.Enabled = true;
            this.toolStripBtoEliminar.Enabled = true;
            this.toolStripBtoDescartar.Enabled = true;
            this.toolStripBtoRestaurar.Enabled = true;
            this.btnBuscar.Enabled = false;
           // this.toolStripBtoAgregar.Enabled = false;
        }

        private void botBuscar_Click(object sender, EventArgs e)
        {            
             FuncionBuscar();            
        }
        public void cargarDatos()
        {

            txtUsuario.Text = frmTbUsuariosElimi._usuario;
            txtUsua.Text = frmTbUsuariosElimi._usuario;
            txtNom.Text = frmTbUsuariosElimi._nombre;
            txtNombre.Text = frmTbUsuariosElimi._nombre;
            txtDescripcion.Text = frmTbUsuariosElimi._descripion;
            this.Refresh();
        }
        public void FuncionInicio()
        {
            this.toolStripBtoRestaurar.Enabled = false;
            this.toolStripBtoEliminar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = false;
            this.btnBuscar.Enabled = true;
          //  this.cboCodStatus.Visible = false;
           // this.cboStatus.Visible = false;

            txtNom.Enabled = false;
            txtUsua.Enabled = false;
            txtDescripcion.Enabled = false;
           // cboStatus.Visible = false;
            txtNombre.Enabled = true;
            txtUsuario.Enabled = true;
        }

        private void toolStripBtoDescartar_Click(object sender, EventArgs e)
        {
            LimpiarCajas();
            FuncionInicio();
        }

        private void btoSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripBtoRestaurar_Click(object sender, EventArgs e)
        {
            FuncionRestaurar();
        }

        private void FuncionRestaurar()
        {
            accion = "eliminar";
            if (frmTbUsuariosElimi.usuaValido == "usuario valido")
            {
                string msj = "";
                // string status = "";
                Usua.m_username = txtUsuario.Text.ToString().Trim();
                msj = Usua.restaurar_Usuario();

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                mensajeCaption = StringResources.frmUsuarioEstiloPrueba_TituloValidacionDeActualizacion;

                MessageBox.Show(msj, mensajeCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                user = txtUsuario.Text.ToString().Trim();
                ventTbUsuariosElim.actualizarlsv(accion);
                LimpiarCajas();
                FuncionInicio();

            }
        }
        private void funcionEliminar()
        {
            accion = "eliminar";
            if (frmTbUsuariosElimi.usuaValido == "usuario valido")
            {
                string msj = "";

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.frmUsuariosEliminados_messDeseaEliminarUsuario;
                mensajeCaption = StringResources.ValidacióndeEliminación;

                DialogResult respuesta;
                respuesta = MessageBox.Show(mensajeText +
                txtUsuario.Text.ToString().Trim() + " ?", mensajeCaption,
                MessageBoxButtons.YesNo);

                if (respuesta == DialogResult.Yes)
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    //mensajeText = StringResources.frmUsuariosEliminados_messDeseaEliminarUsuario;
                    mensajeCaption = StringResources.ValidacióndeEliminación;

                    Usua.m_username = txtUsuario.Text.ToString().Trim();
                    msj = Usua.EliminarUsuario_Permanente();
                    MessageBox.Show(msj, mensajeCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    user = txtUsuario.Text.ToString().Trim();
                    ventTbUsuariosElim.actualizarlsv(accion);
                    LimpiarCajas();
                    FuncionInicio();
                }
            }
        }
        private void toolStripBtoEliminar_Click(object sender, EventArgs e)
        {
            funcionEliminar();
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                FuncionBuscar();
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                FuncionBuscar();
            }
        }

        private void frmUsuariosEliminados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                funcionEliminar();
            }

            if (e.KeyCode == Keys.F5)
            {
                FuncionRestaurar();
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

        

        public void HabilitarBotones()
        {
            this.txtUsuario.Enabled = false;
            this.txtNombre.Enabled = false;
            this.toolStripBtoRestaurar.Enabled = true;
            this.toolStripBtoEliminar.Enabled = true;
            this.toolStripBtoDescartar.Enabled = true;
            this.btnBuscar.Enabled = false;
        }
        private void LimpiarCajas()
        {
            txtDescripcion.Text = "";
            txtUsua.Text = "";
            txtUsuario.Text = "";
            txtNom.Text = "";
            txtNombre.Text = "";
           //cboStatus.Text = "";
          //  cboCodStatus.Text = "";

        }
        private void FuncionBuscar()
        {

            usuario = txtUsuario.Text;
            estado = "buscar";


            if (txtUsuario.Text == "" && txtNombre.Text == "")
            {
                this.txtUsuario.Focus();
                return;                
            }
            else if ((txtUsuario.Text != "" && txtNombre.Text != ""))
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.No_se_puede_realizar_la_busqueda_con_todos_los_campos_llenos;
                mensajeCaption = StringResources.ErrordeValidacion;
                ;

                MessageBox.Show(mensajeText, mensajeCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                this.txtUsuario.Text = "";
                this.txtNombre.Text = "";
                this.txtUsuario.Focus();
                return;
            }
            else
            {
                if (txtUsuario.Text != "")
                {
                    usuario = txtUsuario.Text;
                    nombre = "";
                    ventTbUsuariosElim.BuscarUsuario_Eliminado(usuario, nombre, estado);
                }
                else
                {
                    usuario = "";
                    nombre = txtNombre.Text;
                    ventTbUsuariosElim.BuscarUsuario_Eliminado(usuario, nombre, estado);

                }
                if (frmTbUsuariosElimi.usuaValido == "usuario valido")
                {
                    txtUsua.Text = frmTbUsuariosElimi._usuario;
                    txtUsuario.Text = frmTbUsuariosElimi._usuario;
                    txtNom.Text = frmTbUsuariosElimi._nombre;
                    txtNombre.Text = frmTbUsuariosElimi._nombre;
                    txtDescripcion.Text = frmTbUsuariosElimi._descripion;
                  //  cboStatus.Text = txtDescripcion.Text;
                    HabilitarBotones();
                }
                else
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    mensajeText = StringResources.NoSeEncontroInformacion;
                    mensajeCaption = StringResources.ErrordeValidacion;
                    ;

                    MessageBox.Show(mensajeText, mensajeCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    this.txtUsuario.Focus();
                    LimpiarCajas();

                }
            }
        }

        public void AplicarIdioma()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            //tite panel 
            this.lblTituloPanel.Text = StringResources.UsuariosEliminados;

            //label's
            this.lblUsuario.Text = StringResources.Usuario;
            this.lblNombre.Text = StringResources.Nombre;
            this.lblUsuario1.Text = StringResources.Usuario;
            this.lblNombre1.Text = StringResources.Nombre;

            this.lblTituloPanel.Text = StringResources.UsuariosEliminados;
            this.lblDescripcion.Text = StringResources.Nombre;
            //tite Form
            this.Text = StringResources.UsuariosEliminados;
            //bto's
            this.btoSalir.Text = StringResources.btnSalir;
            this.btnBuscar.Text = StringResources.btnBuscar;
            //tap
            this.tabPage1.Text = StringResources.DetallesDeUsuario;
            this.tabPage2.Text = StringResources.PropiedadesdeUsuario;
            //bto
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
