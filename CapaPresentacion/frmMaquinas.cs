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
    public partial class frmMaquinas : Form
    {
        //-----------------------------DECLARACION DE VARIABLES-------------------------------------- 
        clsEmpresa EMP = new clsEmpresa();
        public string accion = "", mensajeText, mensajeCaption;
        frmTbMaquinas ventTbMaquinas;
        public string tipoPais = "", cod = "", Descrip = "",actual;
        public static string codigo = "", descripcion = "";
        DataTable dt = new DataTable();

        //*****************************************************************************
        public frmMaquinas()
        {
            InitializeComponent();
            FuncionInicio();            
            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();
        }
        private void frmMaquinas_Load(object sender, EventArgs e)
        {
            CargarLista();
            this.Location = new System.Drawing.Point(0, 0);
            ventTbMaquinas = new frmTbMaquinas();
        }


        //**************************CARGAR LISTA *********************************
        public void  CargarLista()
        {
            dt = EMP.ListadoMaquinas(frmPrincipal.nombreBD);
        }

        //************************ FUNCIONES **********************************
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
            this.txtCodigo.Focus();
            actual = "inicio";
        }
        private void FuncionAgregar()
        {
            this.btnPuntos.Enabled = false;
            accion = "agregar";
            actual = "agregar";
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
            //lblMensaje.Visible = true;
            txtCod.Enabled = true;
            txtDescrip.Enabled = true;
            //this.ActiveControl = txtDescrip;
            txtCod.Focus();
            //********************************
            //  txtCod.Enabled = false;
            actual = "agregar";
        }
        private void limpiarCajas()
        {
            txtCodigo.Clear();
            txtDescripcion.Clear();
            txtDescrip.Clear();
            txtCod.Clear();
        }
        private void funcionEliminar()
        {
            if (frmTbMaquinas.estado == "valido")
            {
                string msj = "";
                Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.frmMaquina_EliminarMaquina;
                mensajeCaption = StringResources.ValidacióndeEliminación;

                DialogResult respuesta;
                respuesta = MessageBox.Show("¿" + mensajeText + " " +
                txtDescrip.Text.ToString().Trim() + "?", mensajeCaption,
                MessageBoxButtons.YesNo);

                if (respuesta == DialogResult.Yes)
                {
                    EMP.m_codMaquina = txtCod.Text.ToString().Trim();
                    msj = EMP.EliminarMaquina(frmPrincipal.nombreBD);
                    if (msj == "Eliminacion exitosa")
                    {
                        Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
                        mensajeText = StringResources.DBEliminacionexitosa;
                        mensajeCaption = StringResources.ValidacióndeEliminación;

                        MessageBox.Show(mensajeText, mensajeCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    // descripcion = txtDescrip.Text.ToString().Trim();
                    // listarmodulo.actualizarlstv(accion);
                    limpiarCajas();
                    FuncionInicio();
                }
            }
        }
        public void funcionGuardar()
        {
            if (accion == "agregar")
            {
                if (this.txtCod.Text == "" || this.txtDescrip.Text == "")
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
                    mensajeText = StringResources.ExistenCamposVacios;
                    mensajeCaption = StringResources.ValidaciondeRegistro;

                    MessageBox.Show(mensajeText, mensajeCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    this.txtDescrip.Focus();
                    if (this.txtCod.Text == "")
                    {
                        this.txtCod.Focus();
                    }
                    else
                    {
                        this.txtDescrip.Focus();
                    }
                    return;
                }
                else
                {
                    Boolean existe = false;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (txtCod.Text.ToString().Trim().ToLower() == dt.Rows[i]["Maq_id"].ToString().Trim().ToLower())
                        {
                            existe = true;
                            mensajeCaption = StringResources.ErrordeValidacion;
                            mensajeText = StringResources.YaExisteElRegistro;
                            MessageBox.Show(mensajeText, mensajeCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtCod.Focus();
                            return;
                        }
                    }

                    if (existe == false)
                    {
                        Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
                        mensajeText = StringResources.DBRegistroexitoso;
                        mensajeCaption = StringResources.ValidaciondeRegistro;

                        string msj = "";

                        EMP.m_DescripMaquina = txtDescrip.Text;
                        EMP.m_codMaquina = txtCod.Text;
                        msj = EMP.RegistarMaquina(frmPrincipal.nombreBD);

                        if (msj == "Registro Exitoso")
                        {
                            MessageBox.Show(mensajeText, mensajeCaption,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        }
                        limpiarCajas();
                        FuncionInicio();
                    }
                }
            }
            else if (accion == "editar")
            {
                if (this.txtDescrip.Text == "")
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
                    mensajeText = StringResources.ExistenCamposVacios;
                    mensajeCaption = StringResources.ValidaciondeRegistro;

                    MessageBox.Show(mensajeText, mensajeCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    this.txtDescrip.Focus();
                    return;
                }
                else if (frmTbMaquinas.estado == "valido")
                {
                    string msj = "";

                    EMP.m_DescripMaquina = txtDescrip.Text.ToString().Trim();
                    EMP.m_codMaquina = txtCod.Text.ToString().Trim();
                    msj = EMP.ActualizarMaquina(frmPrincipal.nombreBD);
                    if (msj == "Actualizacion Exitos")
                    {
                        Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
                        mensajeText = StringResources.DBActualizacionExitosa;
                        mensajeCaption = StringResources.frmUsuarioEstiloPrueba_TituloValidacionDeActualizacion;

                        MessageBox.Show(mensajeText, mensajeCaption,
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Information);
                    }
                    limpiarCajas();
                }
                FuncionInicio();
            }
        }
        public void FuncionEditar()
        {
            accion = "editar";
            actual = "editar";
            this.btnPuntos.Enabled = false;
            this.txtDescripcion.Enabled = false;
            this.txtCodigo.Enabled = false;
            this.txtDescrip.Enabled = true;
            this.txtDescrip.Focus();
            this.toolStripBtoGuardar.Enabled = true;
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoEliminar.Enabled = false;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            this.btoBuscar.Enabled = false;
        }
        public void FuncionBuscar()
        {
            
            accion = "buscar";
            if (txtCodigo.Text == "" && txtDescripcion.Text == "")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.ExistenCamposVacios;
                mensajeCaption = StringResources.Validacióndecampos;

                MessageBox.Show(mensajeText, mensajeCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                this.txtCodigo.Focus();
                return;
            }
            else if (txtCodigo.Text != "" && txtDescripcion.Text != "")
            {
                mensajeText = StringResources.No_se_puede_realizar_la_busqueda_con_todos_los_campos_llenos;
                mensajeCaption = StringResources.Validacióndecampos;

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
                    codigo = txtCodigo.Text;
                    descripcion = "";
                    ventTbMaquinas.ValidarBuscar(codigo, descripcion);
                }
                else
                {
                    codigo = "";
                    descripcion = txtDescripcion.Text;
                    ventTbMaquinas.ValidarBuscar(codigo, descripcion);
                }

                if (frmTbMaquinas.estado == "Valido")
                {
                    txtCod.Text = frmTbMaquinas._Codigo;
                    txtCodigo.Text = frmTbMaquinas._Codigo;
                    txtDescrip.Text = frmTbMaquinas._Descripcion;
                    txtDescripcion.Text = frmTbMaquinas._Descripcion;
                    HabilitarBotones();
                    actual = "EditarEliminar";
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
                    limpiarCajas();
                }

            }
        }
        private void actualizarListview()
        {
            cod = txtCod.Text.ToString().Trim();
            Descrip = txtDescrip.Text.ToString().Trim();
            ventTbMaquinas.ActualizarLista(accion);
        }
        private void frmMaquinas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                if (actual == "inicio")
                {
                    FuncionAgregar();
                }
            }
            if (e.KeyCode == Keys.F6)
            {
                if (actual != "inicio")
                {
                    if (actual != "agregar")
                    {
                        FuncionEditar();
                    }
                }
            }
            if (e.KeyCode == Keys.F7)
            {
                if (actual != "inicio")
                {
                    if (actual != "EditarEliminar")
                    {
                        funcionGuardar();
                    }

                }
            }
            if (e.KeyCode == Keys.F8)
            {
                if (actual != "inicio")
                {
                    if (actual != "agregar")
                    {
                        if (actual != "editar")
                        {
                            funcionEliminar();
                        }
                    }
                }
            }
            if (e.KeyCode == Keys.F9)
            {
                limpiarCajas();
                FuncionInicio();
            }
        }

        // ------------------------------ Botones del toolstrip ---------------------------
        private void toolStripBtoAgregar_Click(object sender, EventArgs e)
        {
            FuncionAgregar();
        }
        private void toolStripBtoGuardar_Click(object sender, EventArgs e)
        {
            funcionGuardar();
        }
        private void toolStripBtoDescartar_Click(object sender, EventArgs e)
        {
            limpiarCajas();
            FuncionInicio();
        }
        private void toolStripBtoEditar_Click(object sender, EventArgs e)
        {            
            FuncionEditar();
        }
        private void btoSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void toolStripBtoEliminar_Click(object sender, EventArgs e)
        {
            funcionEliminar();
        }
        private void btnPuntos_Click(object sender, EventArgs e)
        {
            ventTbMaquinas = new frmTbMaquinas();
            ventTbMaquinas.pasado += new frmTbMaquinas.pasar(ejecutar);
            ventTbMaquinas.ShowDialog();
        }
        public void HabilitarBotones()
        {
            this.toolStripBtoEditar.Enabled = true;
            this.toolStripBtoEliminar.Enabled = true;
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            // this.btoBuscar.Enabled = false;
        }
        private void btoBuscar_Click(object sender, EventArgs e)
        {
            FuncionBuscar();
        }

        private void txtCod_KeyPress(object sender, KeyPressEventArgs e)
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

        //---------------------------------------------------------------------------------
        public void ejecutar(string[,] dato)
        {
            this.toolStripBtoEditar.Enabled = true;
            this.toolStripBtoEliminar.Enabled = true;
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            this.btoBuscar.Enabled = false;

            txtCodigo.Text = dato[0, 0];
            txtCod.Text = dato[0, 0];
            txtDescripcion.Text = dato[0, 1];
            txtDescrip.Text = dato[0, 1];
            actual = "EditarEliminar";
        }
        public void AplicarIdioma()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
            this.lblTituloPanel.Text = StringResources.Maquinas;
            //
            this.Text = StringResources.Maquinas;
            //
            this.lblCod.Text = StringResources.Codigo;
            this.lblCodigo.Text = StringResources.Codigo;
            this.lblDescrip.Text = StringResources.Descripcion;
            this.lblDescripcion.Text = StringResources.Descripcion;
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
            //
            this.btoBuscar.Text = StringResources.btnBuscar;
            this.btoSalir.Text = StringResources.btnSalir;
            //
            this.tPgInfoGeneral.Text = StringResources.Informaciongeneral;
        }
        //-----------------------------------------------------------------------------------
        //--------------------------- TABLA -------------------------------
        public void cargarDatos()
        {
            txtCod.Text = frmTbMaquinas._Codigo;
            txtCodigo.Text = frmTbMaquinas._Codigo;
            txtDescrip.Text = frmTbMaquinas._Descripcion;
            txtDescripcion.Text = frmTbMaquinas._Descripcion;
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
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
                FuncionBuscar();
            }
        }

    }
}
