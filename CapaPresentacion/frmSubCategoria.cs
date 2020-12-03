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
    public partial class frmSubCategoria : Form
    {
        public string mensajeText = "", mensajeCaption = "", tipoPais = "";
        public string codigo = "", descripcion = "",actual;

        //--------------------------------------------------------------------------
        public frmSubCategoria()
        {
            InitializeComponent();
            CargarCategoria();
            FuncionInicio();

            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();
        }
        //--------------------------------------------------------------------------
        frmTbSubCateg ventTbSubCategoria;
        ListViewItem lvrow;
        clsEmpresa M = new clsEmpresa();
        public string accion = "";
        public static string activo="";
        DataTable dt = new DataTable();
        DataTable dtc= new DataTable();
        //--------------------------------------------------------------------------
        private void frmSubCategoria1_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(0, 0);
            ventTbSubCategoria = new frmTbSubCateg();
        }
        private void CargarCategoria()
        {
            dt = M.ListadoCategoria(frmPrincipal.nombreBD);
            dtc = M.ListadoSubCategoria(frmPrincipal.nombreBD);

        }
        private void cargarCbo()
        {
            this.cboCategoria.Items.Clear();            
           
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cboCodCategoria.Items.Add(dt.Rows[i]["cat_id"].ToString());
                cboCategoria.Items.Add(dt.Rows[i]["cat_descripcion"].ToString());
               // cboCategoria.SelectedIndex = 0;
            }
        }
        public void cargarDatos()
        {
            txtCod.Text = frmTbSubCateg._Codigo;
            txtCodigo.Text = frmTbSubCateg._Codigo;
            cboCategoria.Text = frmTbSubCateg._Categoria;
            txtDescrip.Text = frmTbSubCateg._Descripcion;
            txtDescripcion.Text = frmTbSubCateg._Descripcion;
        }
        //********************************* FUNCIONES ******************************************
        private void FuncionInicio()
        {
            this.btnPuntos.Enabled = true;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoEliminar.Enabled = false;
            this.toolStripBtoGuardar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = false;
            this.toolStripBtoAgregar.Enabled = true;
            this.btoBuscar.Enabled = true;
            this.cboCategoria.SelectedItem = null;
            this.cboCategoria.Items.Clear();
            this.cboCodCategoria.Items.Clear();
            txtCod.Enabled = false;
            txtDescrip.Enabled = false;
            txtCodigo.Enabled = true;
            txtDescripcion.Enabled = true;
            cargarCbo();
            this.txtDescripcion.Focus();
            this.cboCategoria.Enabled = false;
            this.txtCodigo.Focus();
            actual = "inicio";

        }
        private void FuncionAgregar()
        {
            this.btnPuntos.Enabled = false;
            cboCategoria.SelectedIndex = 0;
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
            txtDescrip.Enabled = true;
            txtCod.Enabled = true;
            this.cboCategoria.Enabled = true;
            txtDescrip.Focus();
            //********************************
            

            lblDescripcion.Visible = true;
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
                if (this.txtDescrip.Text == "")
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    mensajeText = StringResources.ExistenCamposVacios;
                    mensajeCaption = StringResources.Validacióndecampos;

                    MessageBox.Show(mensajeText, mensajeCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                    this.txtDescrip.Focus();
                    return;
                }
                else
                {
                    Boolean existe = false;

                    for (int i = 0; i < dtc.Rows.Count; i++)
                    {
                        if (txtCod.Text.ToString().Trim().ToLower() == dtc.Rows[i]["SubCat_Id"].ToString().Trim().ToLower())
                        {
                            existe = true;
                            mensajeCaption = StringResources.ErrordeValidacion;
                            mensajeText = StringResources.YaExisteElRegistro;
                            MessageBox.Show(mensajeText, mensajeCaption,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            txtCod.Focus();
                            return;
                        }
                    }
                    if (existe == false)
                    {
                        string msj = "";
                        M.m_DescripSubCat= txtDescrip.Text;
                        M.m_CogSubCat = txtCod.Text;
                        M.m_Cat = cboCodCategoria.Text;
                        msj = M.RegistarSubCatg(frmPrincipal.nombreBD);
                        if (msj == "Registro Exitoso")
                        {
                            Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
                            mensajeText = StringResources.DBRegistroexitoso;
                            mensajeCaption = StringResources.ValidaciondeRegistro;

                            MessageBox.Show(mensajeText, mensajeCaption,
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information);
                        }
                        limpiarCajas();
                        FuncionInicio();
                    }
                }
            }
            else if(accion == "editar")
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
                
                else if (frmTbSubCateg.estado == "Valido")
                {
                    string msj = "";
                    M.m_CogSubCat = txtCod.Text;
                    M.m_DescripSubCat = txtDescrip.Text;
                    M.m_Cat = cboCodCategoria.Text;
                    msj = M.ActualizarSubCategorias(frmPrincipal.nombreBD);
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
                    ventTbSubCategoria.ValidarBuscarDT(codigo, descripcion);
                }
                else
                {
                    codigo = "";
                    descripcion = txtDescripcion.Text;
                    ventTbSubCategoria.ValidarBuscarDT(codigo, descripcion);
                }
                if (frmTbSubCateg.estado == "Valido")
                {
                    txtCod.Text = frmTbSubCateg._Codigo;
                    txtCodigo.Text = frmTbSubCateg._Codigo;
                    cboCategoria.Text = frmTbSubCateg._Categoria;
                    txtDescrip.Text = frmTbSubCateg._Descripcion;
                    txtDescripcion.Text = frmTbSubCateg._Descripcion;
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
        public void FuncionEditar()
        {
            accion = "editar";
            actual = "editar";
            this.btnPuntos.Enabled = false;
            this.txtDescripcion.Enabled = false;
            this.txtCodigo.Enabled = false;

            this.cboCategoria.Enabled = true;
            this.cboCodCategoria.Visible = false;

            this.txtDescrip.Enabled = true;

            this.txtCod.Focus();
            this.toolStripBtoGuardar.Enabled = true;
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoEliminar.Enabled = false;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            this.btoBuscar.Enabled = false;
        }
        private void funcionEliminar()
        {
            if (frmTbSubCateg.estado == "Valido")
            {
                string msj = "";

                Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.EliminarSubcategioria;
                mensajeCaption = StringResources.ValidacióndeEliminación;

                DialogResult respuesta;
                respuesta = MessageBox.Show("¿" + mensajeText + " " +
                txtDescrip.Text.ToString().Trim() + " ?", mensajeCaption,
                MessageBoxButtons.YesNo);

                if (respuesta == DialogResult.Yes)
                {
                    mensajeCaption = StringResources.ValidacióndeEliminación;
                    M.m_CogSubCat = txtCod.Text.ToString().Trim();
                    msj = M.EliminarSubCategorias(frmPrincipal.nombreBD);
                    if (msj == "Eliminacion exitosa")
                    {
                        mensajeText = StringResources.DBEliminacionexitosa;
                        mensajeCaption = StringResources.ValidacióndeEliminación;
                        MessageBox.Show(mensajeText, mensajeCaption,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    limpiarCajas();
                    FuncionInicio();
                }
            }
        }
        public void HabilitarBotones()
        {
            this.toolStripBtoEditar.Enabled = true;
            this.toolStripBtoEliminar.Enabled = true;
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
        }

        private void btnPuntos_Click(object sender, EventArgs e)
        {
            ventTbSubCategoria = new frmTbSubCateg();
            ventTbSubCategoria.pasado += new frmTbSubCateg.pasar(ejecutar);
            ventTbSubCategoria.ShowDialog();
        }
        public void ejecutar(string[,] dato)
        {
            txtCodigo.Text = dato[0, 0];
            txtCod.Text = dato[0, 0];
            cboCategoria.Text= dato[0, 2];
            txtDescrip.Text = dato[0, 1];
            txtDescripcion.Text = dato[0, 1];

            this.toolStripBtoEditar.Enabled = true;
            this.toolStripBtoEliminar.Enabled = true;
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            this.btoBuscar.Enabled = false;
            actual = "EditarEliminar";
        }
        private void btoSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
  
        private void frmSubCategoria_KeyDown(object sender, KeyEventArgs e)
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
        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCodCategoria.SelectedIndex = cboCategoria.SelectedIndex;
        }
        private void toolStripBtoDescartar_Click(object sender, EventArgs e)
        {
            limpiarCajas();
            FuncionInicio();
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

        private void toolStripBtoEditar_Click(object sender, EventArgs e)
        {
            FuncionEditar();
        }

        private void toolStripBtoEliminar_Click(object sender, EventArgs e)
        {
            funcionEliminar();
        }      
        private void toolStripBtoAgregar_Click(object sender, EventArgs e)
        {
            FuncionAgregar();
        }
        private void toolStripBtoGuardar_Click(object sender, EventArgs e)
        {
            funcionGuardar();
        }
        public void AplicarIdioma()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
            this.lblTituloPanel.Text = StringResources.SubCategoria;
            //
            this.Text = StringResources.SubCategoria;
            //
            this.lblCod.Text = StringResources.Codigo;
            this.lblCodigo.Text = StringResources.Codigo;
            this.lblDescrip.Text = StringResources.Descripcion;
            this.lblDescripcion.Text = StringResources.Descripcion;
            this.lblcategoria.Text = StringResources.Categoria;
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
