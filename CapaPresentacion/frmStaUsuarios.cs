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
using System.Windows.Forms;
using CultureResources;
using CapaLogicaNegocios;

namespace CapaPresentacion
{
    public partial class frmStaUsuario : Form

    {
        public string estadoactual = "", usuaValido = "", accion = "";
       // private clsStatus lstview = new clsStatus();
        private clsStatus Stat = new clsStatus();
        private clsUsuario Usua = new clsUsuario();
        frmTbStatus ventTbSatus;
        ListViewItem lvrow;
        public frmPrincipal ventPrincipal = new frmPrincipal();
        int num_status;
        public int textBlanco = 0;
        public static string status = "", descrip = "", codigo;
        public static int ventana = 0;


        public string mensajeText = "", mensajeCaption = "";
        public static string tipoPais = "";

        public frmStaUsuario()
        {
            InitializeComponent();
            FuncionInicio();

            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();

        }

        private void frmStaUsuario_Load(object sender, EventArgs e)
        {
            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();

            //lblDescripcion.Visible = false;
            this.Location = new System.Drawing.Point(0, 0);
            //lstViewStaUsuarios.OwnerDraw = true;

            ventTbSatus = new frmTbStatus();
            ventTbSatus.cargarLsvStatus();
        }


        public void EliminarStatus()
        {
            if (frmTbStatus.usuaValido == "estado valido")
            {
                string msj = "";
                string status = "";
                string statusExistente="";
                DialogResult respuesta;
                
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.frmStaUsuarios_messDeseaEliminarStatus;
                mensajeCaption = StringResources.ValidacióndeEliminación;

                respuesta = MessageBox.Show(mensajeText + "" + txtDescripcion.Text.ToString().Trim() + " ?", mensajeCaption, MessageBoxButtons.YesNo);

                if (respuesta == DialogResult.Yes)
                {
                    status = txtCodigo.Text.ToString().Trim();
                    //Stat.m_status = Int32.Parse(status.ToString());
                    //*******debo asegurarme de que el estatus no pertenezca aun usuario activo***************
                    Usua.m_status = Int32.Parse(status.ToString());
                    statusExistente = Usua.BuscarEstatus_Activo();

                    if (statusExistente == "no")
                    {
                        Stat.m_status = Int32.Parse(status.ToString());
                        Stat.eliminar_status();
                        msj = Stat.eliminar_status();

                        Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                        mensajeCaption = StringResources.ValidacióndeEliminación;

                        if (msj == "Eliminacion exitosa")
                        {
                            msj = StringResources.DBEliminacionexitosa;
                            MessageBox.Show(msj, mensajeCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        //*************ACTUALIZAR LIST VIEW****************************///

                        codigo = status;
                        descrip = txtDescrip.Text.ToString().Trim();
                        ventTbSatus.ActualizarListview("eliminar");
                        limpiarCajas();
                        FuncionInicio();
                        return;
                    }
                    else if (statusExistente == "activo")
                    {
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                        mensajeText = StringResources.ElEstadoEstaAsociadoaUsuarios;
                        mensajeCaption = StringResources.ValidacióndeEliminación;
                        MessageBox.Show(mensajeText, mensajeCaption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                        //  MessageBox.Show("El Estado no se puede eliminar porque esta asociado a usuarios existentes", "Error de Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else if (statusExistente == "desactivado")
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                         mensajeText = StringResources.ElEstadoNoSePuede_liminarPorqueEsta_AsociadoaUsuariosEnMantenimiento;
                         mensajeCaption = StringResources.ValidacióndeEliminación;

                         MessageBox.Show(mensajeText, mensajeCaption,
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error);
                   // MessageBox.Show("El Estado no se puede eliminar porque esta asociado a usuarios en mantenimiento", "Error de Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
        }
        public void funcionGuardar()
        {
            if (accion == "agregar")
            {
                if (this.txtDescrip.Text == "")
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    mensajeText = StringResources.frmStaUsuarios_messAgregarDescripcion_Codigo;
                    mensajeCaption = StringResources.ErrordeValidacion;


                    MessageBox.Show(mensajeText, mensajeCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    this.txtDescrip.Focus();
                    return;
                }
                else
                {
                    string msj = "";
                    string status = "";
                    Stat.m_descripcion = txtDescrip.Text.ToString().Trim();
                    msj = Stat.registrar_status();
                    status = Stat.status;

                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    mensajeCaption = StringResources.ValidaciondeRegistro;

                    if (msj == "Registro exitoso")
                    {
                        msj = StringResources.DBRegistroexitoso;
                        MessageBox.Show(msj, mensajeCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                    //*******Actualizar lstview**************
                    codigo = status;
                    descrip = txtDescrip.Text.ToString().Trim();
                    ventTbSatus.ActualizarListview("agregar");
                    limpiarCajas();
                    FuncionInicio();
                }
            }
            else if (accion == "editar")
            {
                if (this.txtDescrip.Text == "")
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    mensajeText = StringResources.ElCampoDescripcion_NoPuede_EstarVacio;
                    mensajeCaption = StringResources.ErrordeValidacion;


                    MessageBox.Show(mensajeText, mensajeCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                    //MessageBox.Show("El campo Descripcion no puede estar vacio", mensajeCaption,
                    //MessageBoxButtons.OK,
                    //MessageBoxIcon.Error);
                    this.txtDescrip.Focus();
                    return;
                }
                else
                {
                    if (frmTbStatus.usuaValido == "estado valido")
                    {
                        string msj = "";
                        string status = "";
                        status = txtCod.Text.ToString().Trim();
                        Stat.m_status = Int32.Parse(status.ToString());
                        Stat.m_descripcion = txtDescrip.Text.ToString().Trim();
                        msj = Stat.Actualizar_status();
                        codigo = txtCod.Text;

                        Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                        mensajeCaption = StringResources.ValidaciondeRegistro;

                        if (msj == "Actualizacion Exitosa" )
                        {
                            msj = StringResources.DBActualizacionExitosa;

                            MessageBox.Show(msj, mensajeCaption,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        }

                        descrip = txtDescrip.Text.ToString().Trim();
                        ventTbSatus.ActualizarListview("editar");
                        limpiarCajas();
                        FuncionInicio();
                    }
                }
            }
        }

        public void FuncionEditar()
        {
            this.btnPuntos.Enabled = false;
            this.txtDescripcion.Enabled = false;
            this.txtCodigo.Enabled = false;
            this.txtDescrip.Enabled = true;
            this.txtDescrip.Focus();

            toolStripBtoGuardar.Enabled = true;
            toolStripBtoAgregar.Enabled = false;
            toolStripBtoEliminar.Enabled = false;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            this.btoBuscar.Enabled = false;
        }

        public void funcion_cancelar_tbStatus()
        {
            this.txtCodigo.Text = "";
            this.txtDescripcion.Text = "";
        }

        private void lstViewStaUsuarios_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.DarkOrange, e.Bounds);
            e.DrawText();
        }

        private void lstViewStaUsuarios_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void botBuscar_Click(object sender, EventArgs e)
        {
            FuncionBuscar();
        }
        private void FuncionInicio()
        {
            this.btnPuntos.Enabled = true;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoEliminar.Enabled = false;
            this.toolStripBtoGuardar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = false;
            this.toolStripBtoAgregar.Enabled = true;
            this.btoBuscar.Enabled = true;
            txtCod.Enabled = false;
            txtDescrip.Enabled = false;
            txtCodigo.Enabled = true;
            txtDescripcion.Enabled = true;
            this.txtDescripcion.Focus();
            lblMensaje.Visible = false;
            this.txtCodigo.Focus();
        }
        private void btnPuntos_Click(object sender, EventArgs e)
        {
            //this.Location = new System.Drawing.Point(0, 175);

            // this.Hide();
            if (ventana == 0)
            {
                ventTbSatus = new frmTbStatus();
                ventTbSatus.pasado += new frmTbStatus.pasar(ejecutar);
                ventTbSatus.ShowDialog();

                ventana++;
            }
            else
            {
                ventTbSatus.pasado += new frmTbStatus.pasar(ejecutar);
                ventTbSatus.ShowDialog();
            }
        }
        public void ejecutar(string[,] dato)
        {
            txtCodigo.Text = dato[0, 0];
            txtCod.Text = dato[0, 0];
            txtDescrip.Text = dato[0, 1];
            txtDescripcion.Text = dato[0, 1];


            this.toolStripBtoEditar.Enabled = true;
            this.toolStripBtoEliminar.Enabled = true;
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            this.btoBuscar.Enabled = false;
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

        private void limpiarCajas()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            txtDescrip.Text = "";
            txtCod.Text = "";
        }

        private void toolStripBtoDescartar_Click(object sender, EventArgs e)
        {
            limpiarCajas();
            FuncionInicio();
        }

        private void toolStripBtoAgregar_Click(object sender, EventArgs e)
        {
            FuncionAgregar();
        }

        private void toolStripBtoGuardar_Click(object sender, EventArgs e)
        {
            funcionGuardar();
        }

        private void toolStripBtoEditar_Click(object sender, EventArgs e)
        {
            FuncionEditar();
            accion = "editar";
        }

        private void toolStripBtoEliminar_Click(object sender, EventArgs e)
        {
            EliminarStatus();
        }

        private void FuncionAgregar()
        {
            this.btnPuntos.Enabled = false;
            accion = "agregar";
            limpiarCajas();
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoEliminar.Enabled = false;
            this.toolStripBtoGuardar.Enabled = true;
            this.toolStripBtoDescartar.Enabled = true;
            this.btoBuscar.Enabled = false;
            //***Cajas******
            txtCodigo.Enabled = false;
            txtDescripcion.Enabled = false;
            lblMensaje.Visible = true;
            txtDescrip.Enabled = true;
            //this.ActiveControl = txtDescrip;
            txtDescrip.Focus();
            //********************************
            txtCod.Enabled = false;
            
            lblDescripcion.Visible = true;
        }

        private void frmStaUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                FuncionAgregar();
            }
            if (e.KeyCode == Keys.F6)
            {
                FuncionEditar();
                accion = "editar";
            }
            if(e.KeyCode == Keys.F7)
            {
                funcionGuardar();
            }
            if (e.KeyCode == Keys.F8)
            {
                EliminarStatus();
            }
            if (e.KeyCode == Keys.F9)
            {
                limpiarCajas();
                FuncionInicio();
            }
        }

        private void toolStripBtoAgregar_Click_1(object sender, EventArgs e)
        {
            FuncionAgregar();
        }

        private void toolStripBtoEditar_Click_1(object sender, EventArgs e)
        {
            FuncionEditar();
            accion = "editar";

        }

        private void toolStripBtoGuardar_Click_1(object sender, EventArgs e)
        {
            funcionGuardar();
        }

        private void toolStripBtoEliminar_Click_1(object sender, EventArgs e)
        {
            EliminarStatus();

        }

        private void toolStripBtoDescartar_Click_1(object sender, EventArgs e)
        {
            limpiarCajas();
            FuncionInicio();
        }

        private void btoSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            //ventTbSatus.Show();
        }

        public void cargarDatos()
        {
            txtDescripcion.Text = frmTbStatus._descripcion;
            txtDescrip.Text = frmTbStatus._descripcion;
            txtCodigo.Text = frmTbStatus._codigo;
            txtCod.Text = frmTbStatus._codigo;
            this.Refresh();
        }
        private void FuncionBuscar()
        {
            if (txtCodigo.Text == "" && txtDescripcion.Text == "")
            {
                return;
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
                    status = txtCodigo.Text;
                    descrip = "";
                    ventTbSatus.ValidarStatus_Buscar(status, descrip, "buscar");
                }
                else
                {
                    status = "";
                    descrip = txtDescripcion.Text;
                    ventTbSatus.ValidarStatus_Buscar(status, descrip, "buscar");
                }
            }
            //***********Parte para cargar datos al otro formulario*********************************
            if (frmTbStatus.usuaValido == "estado valido")
            {
                txtDescripcion.Text = frmTbStatus._descripcion;
                txtCodigo.Text = frmTbStatus._codigo;
                txtDescrip.Text = frmTbStatus._descripcion;
                txtCod.Text = frmTbStatus._codigo;
                HabilitarBotones();
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.NoSeEncontroInformacion;
                mensajeCaption = StringResources.ValidaciondeRegistro;

                MessageBox.Show(mensajeText, mensajeCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                this.txtCodigo.Focus();
                limpiarCajas();
            }
        }
        public void HabilitarBotones()
        {
            this.toolStripBtoEditar.Enabled = true;
            this.toolStripBtoEliminar.Enabled = true;
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            this.btoBuscar.Enabled = false;
        }

        public void AplicarIdioma()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);

            this.Text = StringResources.TablaUsuario;
            //
            this.lblTituloPanel.Text = StringResources.frmStaUsuarios_lblTituloPanel;
            //
            this.lblCodigo.Text = StringResources.Codigo;
            this.lblDescripcion.Text = StringResources.Descripcion;
            this.lblCodigo2.Text = StringResources.Codigo;
            this.lblDescripcion2.Text = StringResources.Descripcion;
            //
            this.lblMensaje.Text = StringResources.EstatusdeUsuario;
            //
            this.btoBuscar.Text = StringResources.btnBuscar;
            this.btoSalir.Text = StringResources.btnSalir;
            //
            this.tabPage1.Text = StringResources.Status;
            this.tabPage2.Text = StringResources.PropiedadesdeStatus;
            //
            this.toolStripBtoAgregar.Text = StringResources.btoAgregar;
            this.toolStripBtoDescartar.Text = StringResources.btoDescartar;
            this.toolStripBtoEditar.Text = StringResources.btoEditar;
            this.toolStripBtoEliminar.Text = StringResources.btoEliminar;
            this.toolStripBtoGuardar.Text = StringResources.btoGuardar;
            //
            this.toolStripBtoAgregar.ToolTipText = StringResources.btoAgregar;
            this.toolStripBtoDescartar.ToolTipText = StringResources.btoDescartar;
            this.toolStripBtoEditar.ToolTipText = StringResources.btoEditar;
            this.toolStripBtoEliminar.ToolTipText = StringResources.btoEliminar;
            this.toolStripBtoGuardar.ToolTipText = StringResources.btoGuardar;
        }
    }
}
