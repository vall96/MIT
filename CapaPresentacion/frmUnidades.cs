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
    public partial class frmUnidades : Form
    {
        public string tipoPais = "", cod = "", Descrip = "", mensajeText = "", mensajeCaption = "";
        DataTable dt = new DataTable();
        public string codigo = "", descripcion = "",actual;
        //------------------------------------------------------------------------------
        public frmUnidades()
        {
            InitializeComponent();
            FuncionInicio();
        }
        //--------------------------------------------------
        frmTbUnidades ventTbUnidades;
        public string accion = "";
        clsEmpresa M = new clsEmpresa();
        private void btoSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUnidades_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(0, 0);
            ventTbUnidades = new frmTbUnidades();
        }
        //Funciones----------------------------------------------
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
            txtDescrip.Enabled = true;
            txtCod.Enabled = true;
            //this.ActiveControl = txtDescrip;
            txtCod.Focus();
            //********************************
            
        }
        private void limpiarCajas()
        {
            txtCodigo.Clear();
            txtDescripcion.Clear();
            txtDescrip.Clear();
            txtCod.Clear();
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

                    this.txtCod.Focus();
                    return;
                }
                else
                {
                    Boolean existe = false;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (txtCod.Text.ToString().Trim().ToLower() == dt.Rows[i]["Uni_Id"].ToString().Trim().ToLower())
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
                        string msj = "";
                        M.m_DescripUnidades = txtDescrip.Text.ToString().Trim();
                        M.m_codUnidades = txtCod.Text.ToString().Trim();
                        msj = M.RegistarUnidades(frmPrincipal.nombreBD);
                        if (msj == "Registro Exitoso")
                        {
                            Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
                            mensajeText = StringResources.DBRegistroexitoso;
                            mensajeCaption = StringResources.ValidaciondeRegistro;
                            MessageBox.Show(mensajeText, mensajeCaption,
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information);
                            limpiarCajas();
                        }
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
                else if (frmTbUnidades.estado == "valido")
                {
                    string msj = "";

                    M.m_DescripUnidades = txtDescrip.Text.ToString().Trim();
                    M.m_codUnidades = txtCod.Text.ToString().Trim();
                    msj = M.ActualizarUnidades(frmPrincipal.nombreBD);
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
        private void funcionEliminar()
        {
            if (frmTbUnidades.estado == "valido")
            {
                string msj = "";
               
                Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.Deseaeliminarunidades;
                mensajeCaption = StringResources.ValidacióndeEliminación;

                DialogResult respuesta;
                respuesta = MessageBox.Show("¿" + mensajeText + " " +
                txtDescrip.Text.ToString().Trim() + " ?", mensajeCaption,
                MessageBoxButtons.YesNo);

                if (respuesta == DialogResult.Yes)
                {
                    mensajeCaption = StringResources.ValidacióndeEliminación;
                    M.m_codUnidades = txtCod.Text.ToString().Trim();
                    msj = M.EliminarUnidades(frmPrincipal.nombreBD);
                    if (msj == "Eliminacion exitosa")
                    {
                        mensajeText = StringResources.DBEliminacionexitosa;
                        mensajeCaption = StringResources.ValidacióndeEliminación;
                        MessageBox.Show(mensajeText, mensajeCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                    limpiarCajas();
                    FuncionInicio();
                }
            }
        }
        public void FuncionEditar()
        {
            accion = "editar";
            this.btnPuntos.Enabled = false;
            this.txtDescripcion.Enabled = false;
            this.txtCodigo.Enabled = false;
            this.txtDescrip.Enabled = true;
            this.txtCod.Enabled = false;
            this.txtDescrip.Focus();
            this.toolStripBtoGuardar.Enabled = true;
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoEliminar.Enabled = false;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            this.btoBuscar.Enabled = false;
            actual = "editar";
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
            actual = "EditarEliminar";
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
                    ventTbUnidades.ValidarBuscar(codigo, descripcion);
                }
                else 
                {
                    codigo = "";
                    descripcion = txtDescripcion.Text;
                    ventTbUnidades.ValidarBuscar(codigo, descripcion);
                }

                if (frmTbUnidades.estado == "Valido")
                {
                    txtCod.Text = frmTbUnidades._Codigo;
                    txtCodigo.Text = frmTbUnidades._Codigo;
                    txtDescrip.Text = frmTbUnidades._Descripcion;
                    txtDescripcion.Text = frmTbUnidades._Descripcion;
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

        public void HabilitarBotones()
        {
            this.toolStripBtoEditar.Enabled = true;
            this.toolStripBtoEliminar.Enabled = true;
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            // this.btoBuscar.Enabled = false;
        }


        //------------------------------------BOTONES *-----------------------------
        private void btnPuntos_Click(object sender, EventArgs e)
        {
            ventTbUnidades = new frmTbUnidades();
            ventTbUnidades.pasado += new frmTbUnidades.pasar(ejecutar);
            ventTbUnidades.ShowDialog();
        }
        private void toolStripBtoEditar_Click(object sender, EventArgs e)
        {            
            FuncionEditar();
        }
        private void btoBuscar_Click(object sender, EventArgs e)
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

        private void toolStripBtoEliminar_Click(object sender, EventArgs e)
        {
            funcionEliminar();
        }

        private void frmUnidades_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F5)
            {
                FuncionAgregar();
            }
            if (e.KeyCode == Keys.F6)
            {
                accion = "editar";
                FuncionEditar();
            }
            if (e.KeyCode == Keys.F7)
            {
                funcionGuardar();
            }
            if (e.KeyCode == Keys.F8)
            {
                funcionEliminar();
            }
            if (e.KeyCode == Keys.F9)
            {
                limpiarCajas();
                FuncionInicio();
            }
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
        private void toolStripBtoAgregar_Click(object sender, EventArgs e)
        {
            FuncionAgregar();
        }

        public void cargarDatos()
        {
            txtCod.Text = frmTbUnidades._Codigo;
            txtCodigo.Text = frmTbUnidades._Codigo;
            txtDescrip.Text = frmTbUnidades._Descripcion;
            txtDescripcion.Text = frmTbUnidades._Descripcion;
        }

        //-------------------------------------------------------------------------------------------------
        public void AplicarIdioma()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
            this.lblTituloPanel.Text = StringResources.Unidades;
            //
            this.Text = StringResources.Unidades;
            //
            this.lblCod.Text = StringResources.Codigo;
            this.lblCodigo.Text = StringResources.Codigo;
            this.lbldescrip.Text = StringResources.Descripcion;
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


    }
}
