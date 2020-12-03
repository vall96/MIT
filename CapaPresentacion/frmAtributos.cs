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
    public partial class frmAtributos : Form
    {
        clsEmpresa EMP = new clsEmpresa();
        public string accion = "";
        frmTbAtributos ventTbAtributos;
        DataTable dt = new DataTable();
        //-------------------------------------------------------------------------
        public string tipoPais = "", cod = "", Descrip = "", mensajeText = "",  mensajeCaption ="";
        public string codigo = "", descripcion = "",actual="";

        //
        public frmAtributos()
        {
            InitializeComponent();
            FuncionInicio();
            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();
        }
        public void CargarLista()
        {
            dt = EMP.ListadoAtributos(frmPrincipal.nombreBD);
        }
        private void frmAtributos_Load(object sender, EventArgs e)
        {
            CargarLista();
            this.Location = new System.Drawing.Point(0, 0);
            ventTbAtributos = new frmTbAtributos();
        }

        //--------------------------- FUNCIONES ---------------------------------------------------
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
           
            txtCod.Enabled = true;
            txtDescrip.Enabled = true;
            
            txtCod.Focus();
            //********************************
            //  txtCod.Enabled = false;
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
        private void funcionEliminar()
        {
            if (frmTbAtributos.estado == "valido")
            {
                string msj = "";
                // string id = "";
                Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.frmAtributo_EliminarAtributo;
                mensajeCaption = StringResources.ValidacióndeEliminación;
                DialogResult respuesta;
                respuesta = MessageBox.Show("¿" + mensajeText + " " +
                txtDescrip.Text.ToString().Trim() + " ?", mensajeCaption,
                MessageBoxButtons.YesNo);
                if (respuesta == DialogResult.Yes)
                {
                    mensajeCaption = StringResources.ValidacióndeEliminación;
                    EMP.m_codAtributos = txtCod.Text.ToString().Trim();
                    msj = EMP.EliminarAtributo(frmPrincipal.nombreBD);
                    if (msj == "Eliminacion exitosa")
                    {
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
                   
                        this.txtCod.Focus();
                        return;
                }
                else
                {
                    Boolean existe = false;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (txtCod.Text.ToString().Trim().ToLower() == dt.Rows[i]["Atrib_id"].ToString().Trim().ToLower())
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
                        EMP.m_DescripAtributos = txtDescrip.Text;
                        EMP.m_codAtributos = txtCod.Text;
                        msj = EMP.RegistarAtributo(frmPrincipal.nombreBD);
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
                else if (frmTbAtributos.estado == "valido")
                {
                    string msj = "";

                    EMP.m_DescripAtributos = txtDescrip.Text.ToString().Trim();
                    EMP.m_codAtributos = txtCod.Text.ToString().Trim();
                    msj = EMP.ActualizarAtributo(frmPrincipal.nombreBD);
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
        private void limpiarCajas()
        {
            txtCodigo.Clear();
            txtDescripcion.Clear();
            txtDescrip.Clear();
            txtCod.Clear();
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
                    ventTbAtributos.ValidarBuscar(codigo, descripcion);
                }
                else
                {
                    codigo = "";
                    descripcion = txtDescripcion.Text;
                    ventTbAtributos.ValidarBuscar(codigo, descripcion);
                }

                if (frmTbAtributos.estado == "Valido")
                {
                    txtCod.Text = frmTbAtributos._Codigo;
                    txtCodigo.Text = frmTbAtributos._Codigo;
                    txtDescrip.Text = frmTbAtributos._Descripcion;
                    txtDescripcion.Text = frmTbAtributos._Descripcion;
                    HabilitarBotones();
                    actual = "EditarEliminar";
                }
                else
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    mensajeText = StringResources.NoSeEncontroInformacion;
                    mensajeCaption = StringResources.ErrordeValidacion;
                    MessageBox.Show( mensajeText , mensajeCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                    this.txtCodigo.Focus();
                    limpiarCajas();
                }
            }
        }

        //------------------------ Tool Strip Bto Agg -----------------------------
        private void toolStripBtoAgregar_Click(object sender, EventArgs e)
        {
            FuncionAgregar();
        }
        private void toolStripBtoEditar_Click(object sender, EventArgs e)
        {            
            FuncionEditar();
        }
        private void toolStripBtoGuardar_Click(object sender, EventArgs e)
        {
            funcionGuardar();
           // FuncionInicio();
        }
        private void toolStripBtoDescartar_Click(object sender, EventArgs e)
        {
            limpiarCajas();
            FuncionInicio();
        }
        private void frmAtributos_KeyDown(object sender, KeyEventArgs e)
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
        private void toolStripBtoEliminar_Click(object sender, EventArgs e)
        {
            funcionEliminar();
        }
        private void btnPuntos_Click(object sender, EventArgs e)
        {
            frmTareas.valido = "no";
            ventTbAtributos = new frmTbAtributos();
            ventTbAtributos.pasado += new frmTbAtributos.pasar(ejecutar);
            ventTbAtributos.ShowDialog();
        }
        private void btoBuscar_Click(object sender, EventArgs e)
        {
            FuncionBuscar();
        }
        private void btoSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void HabilitarBotones()
        {
            this.toolStripBtoEditar.Enabled = true;
            this.toolStripBtoEliminar.Enabled = true;
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            // this.btoBuscar.Enabled = false;

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

        //----------------------------------------------------------------------------
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
            this.lblTituloPanel.Text = StringResources.Atributos;
            //
            this.Text = StringResources.Atributos;
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

        //--------------------------- TABLA -------------------------------
        public void cargarDatos()
        {
            txtCod.Text =frmTbAtributos._Codigo;
            txtCodigo.Text = frmTbAtributos._Codigo;
            txtDescrip.Text = frmTbAtributos._Descripcion;
            txtDescripcion.Text = frmTbAtributos._Descripcion;
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
