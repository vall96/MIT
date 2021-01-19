using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogicaNegocios;
using System.Threading;
using System.Globalization;
using CultureResources;

namespace CapaPresentacion
{
    public partial class frmProveedores : Form
    {
        public frmProveedores()
        {
            InitializeComponent();
            frmPrincipal.nombreBD = "Digitel";
            ventTbProvedores = new frmTbProveedores();
            AplicarIdioma();
            funcionInicio();
            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
        }
        public class Validar
        {
            public static void SoloLetrasNumerosyRayita(KeyPressEventArgs N)
            {
                if (Char.IsLetterOrDigit(N.KeyChar))
                {
                    N.Handled = false;
                }
                else if (Char.IsControl(N.KeyChar))
                {
                    N.Handled = false;
                }
                else if (N.KeyChar.ToString().Equals("-"))
                {
                    N.Handled = false;
                }
                else
                {
                    N.Handled = true;
                }
            }
        }
        clsEmpresa M = new clsEmpresa();
        string actual;
        public string tipoPais = "", cod = "", Descrip = "", mensajeText = "", mensajeCaption = "";
        public static string estado = "",id="",nombre = "",tipo="",referencia="",responsable="",
                             email="",telefono1="",telefono2="",direccion="",pais="",estadop="",
                             ciudad="",municipio="",tipopersona="",fax="",fechacreacion="",dias="",
                             limite="",comentario="",rif="", valido = "";
        frmTbProveedores ventTbProvedores;        
        DateTime fecha;

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTelefono1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTelefono2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
      
        private void txtRIF_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetrasNumerosyRayita(e);
        }

        private void txtFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDias_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtLimite_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        Boolean error;

        private void btoBuscar_Click(object sender, EventArgs e)
        {
            FuncionBuscar();
        }

        private void frmProveedores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FuncionBuscar();
            }
            if (e.KeyCode == Keys.F5)
            {
                if (actual == "inicio")
                {
                    funcionAgregar();
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
                        FuncionGuardar();
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
                LimpiarCajas();
                funcionInicio();
            }
        }
        private void toolStripBtoEliminar_Click(object sender, EventArgs e)
        {
            funcionEliminar();
        }        
        private void btnPuntos_Click(object sender, EventArgs e)
        {
            ventTbProvedores = new frmTbProveedores();
            ventTbProvedores.pasado += new frmTbProveedores.pasar(ejecutar);
            ventTbProvedores.ShowDialog();
        }       
        public void ejecutar(string[,] datos)
        {
            txtCod.Text = datos[0, 0];
            txtCodigo.Text = datos[0, 0];
            txtNom.Text = datos[0, 1];
            txtNombre.Text = datos[0, 1];           
            CboTipo.Text= datos[0, 2];
            txtReferencia.Text= datos[0, 3];
            txtResponsable.Text= datos[0, 4];
            txtEmail.Text = datos[0, 5];
            txtTelefono1.Text = datos[0, 6];
            txtTelefono2.Text = datos[0, 7];
            txtDireccion.Text = datos[0, 8];
            txtPais.Text = datos[0, 9];
            txtEstado.Text = datos[0, 10];
            txtCiudad.Text = datos[0, 11];
            txtMunicipio.Text = datos[0, 12];
            CboTipoPersona.Text = datos[0, 13];
            txtFax.Text = datos[0, 14];
            txtFechaCreacion.Text = datos[0, 15];
            txtDias.Text = datos[0, 16];
            txtLimite.Text = datos[0, 17];
            txtComentario.Text = datos[0, 18];
            txtRIF.Text = datos[0, 19];

            //******del toolStrip****
            this.toolStripBtoEditar.Enabled = true;
            this.toolStripBtoEliminar.Enabled = true;
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            this.btoBuscar.Enabled = false;
            //Boxs
            txtCodigo.Enabled = true;
            txtNombre.Enabled = true;
            lblMensaje.Visible = false;
            this.txtCod.Enabled = false;
            this.txtNom.Enabled = false;
            this.txtResponsable.Enabled = false;
            this.txtFechaCreacion.Enabled = false;
            this.txtTelefono1.Enabled = false;
            this.txtTelefono2.Enabled = false;
            this.lblSepador.Visible = false;
            this.txtDireccion.Enabled = false;
            this.CboTipo.Enabled = false;
            this.txtEmail.Enabled = false;
            this.txtReferencia.Enabled = false;
            this.txtPais.Enabled = false;
            this.txtEstado.Enabled = false;
            this.txtCiudad.Enabled = false;
            this.txtMunicipio.Enabled = false;
            //Boxs2
            this.txtRIF.Enabled = false;
            this.txtEmail.Enabled = false;
            this.txtFechaCreacion.Enabled = false;
            this.dtimeFecha.Enabled = false;
            this.CboTipoPersona.Enabled = false;
            this.txtFax.Enabled = false;
            this.txtDias.Enabled = false;
            this.txtLimite.Enabled = false;
            txtComentario.Enabled = false;
            actual="EditarEliminar";
        }
        private void btoSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(0, 0);
            valido = "si";
        }
       
        private void dtimeFecha_ValueChanged(object sender, EventArgs e)
        {            
            fecha = dtimeFecha.Value.Date;
            txtFechaCreacion.Text = fecha.ToShortDateString();
        }

        private void toolStripBtoAgregar_Click(object sender, EventArgs e)
        {
            funcionAgregar();
        }

        private void toolStripBtoGuardar_Click(object sender, EventArgs e)
        {
            FuncionGuardar();
        }

        private void funcionInicio()
        {
            this.toolStripBtoAgregar.Enabled = true;
            this.toolStripBtoDescartar.Enabled = false;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoGuardar.Enabled = false;
            this.toolStripBtoEliminar.Enabled = false;
            this.btnPuntos.Enabled = true;
            this.btoBuscar.Enabled = true;
            //---------------------------
            CboTipo.SelectedItem = null;
            CboTipoPersona.SelectedItem = null;
            //--------------------------            
            //***Cajas************
            txtCodigo.Enabled = true;
            txtNombre.Enabled = true;
            lblMensaje.Visible = false;
            this.txtCod.Enabled = false;
            this.txtNom.Enabled = false;
            this.txtResponsable.Enabled = false;
            this.txtFechaCreacion.Enabled = false;
            this.txtTelefono1.Enabled = false;
            this.txtTelefono2.Enabled = false;
            this.lblSepador.Visible = true;
            this.txtDireccion.Enabled = false;
            this.CboTipo.Enabled = false;
            this.txtEmail.Enabled = false;
            this.txtReferencia.Enabled = false;
            this.txtPais.Enabled = false;
            this.txtEstado.Enabled = false;
            this.txtCiudad.Enabled = false;
            this.txtMunicipio.Enabled = false;
            //tab2
            this.txtRIF.Enabled = false;
            this.txtEmail.Enabled = false;
            this.txtFechaCreacion.Enabled = false;
            this.dtimeFecha.Visible = false;
            this.dtimeFecha.Value = DateTime.Now;
            this.CboTipoPersona.Enabled = false;
            this.txtFax.Enabled = false;
            this.txtDias.Enabled = false;
            this.txtLimite.Enabled = false;
            txtComentario.Enabled = false;
            //*******************************
            this.errPv.Clear();
            actual = "inicio";
        }
        private void funcionAgregar()
        {
            estado = "agregar";
            actual = "agregar";
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoGuardar.Enabled = true;
            this.toolStripBtoEliminar.Enabled = false;
            //***Cajas************
            this.btnPuntos.Enabled = false;
            txtCodigo.Enabled = false;
            txtNombre.Enabled = false;
            lblMensaje.Visible = true;
            this.txtCod.Enabled = false;
            this.txtNom.Enabled = true;
            this.txtNom.Focus();
            this.txtResponsable.Enabled = true;
            this.txtFechaCreacion.Enabled = true;
            this.txtTelefono1.Enabled = true;
            this.txtTelefono2.Enabled = true;
            this.lblSepador.Visible = true;
            this.txtDireccion.Enabled = true;
            this.CboTipo.Enabled = true;
            this.txtEmail.Enabled = true;
            this.txtReferencia.Enabled = true;
            this.txtPais.Enabled = true;
            this.txtEstado.Enabled = true;
            this.txtCiudad.Enabled = true;
            this.txtMunicipio.Enabled = true;
            //tab2
            this.txtRIF.Enabled = true;
            this.txtEmail.Enabled = true;
            this.txtFechaCreacion.Enabled = false;
            this.dtimeFecha.Visible = true;
            this.dtimeFecha.Value = DateTime.Now;
            this.CboTipoPersona.Enabled = true;
            this.txtFax.Enabled = true;
            this.txtDias.Enabled = true;
            this.txtLimite.Enabled = true;
            txtComentario.Enabled = true;
            //---------------------------
            this.CboTipo.SelectedIndex = 0;
            this.CboTipoPersona.SelectedIndex = 0;
        }
        private void FuncionEditar()
        {
            estado = "editar";
            actual = "editar";
            //Buttons
            this.btnPuntos.Enabled = false;
            this.toolStripBtoGuardar.Enabled = true;
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoEliminar.Enabled = false;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            this.btoBuscar.Enabled = false;
            //Boxs
            txtCodigo.Enabled = false;
            txtNombre.Enabled = false;
            lblMensaje.Visible = false;
            this.txtCod.Enabled = false;
            this.txtNom.Enabled = true;
            this.txtNom.Focus();
            this.txtResponsable.Enabled = true;
            this.txtFechaCreacion.Enabled = true;
            this.txtTelefono1.Enabled = true;
            this.txtTelefono2.Enabled = true;
            this.lblSepador.Visible = true;
            this.txtDireccion.Enabled = true;
            this.CboTipo.Enabled = true;
            this.txtEmail.Enabled = true;
            this.txtReferencia.Enabled = true;
            this.txtPais.Enabled = true;
            this.txtEstado.Enabled = true;
            this.txtCiudad.Enabled = true;
            this.txtMunicipio.Enabled = true;
            //Boxs2
            this.txtRIF.Enabled = true;
            this.txtEmail.Enabled = true;
            this.txtFechaCreacion.Enabled = false;
            this.dtimeFecha.Visible = false;
            this.CboTipoPersona.Enabled = true;
            this.txtFax.Enabled = true;
            this.txtDias.Enabled = true;
            this.txtLimite.Enabled = true;
            txtComentario.Enabled = true;

        }
        private void FuncionGuardar()
        {
            if (estado == "agregar")
            {
                string mensaje = "";
                ValidarCajas();
                if (error == false)       //si no existen cajas vacias, guardar en db
                {
                    M.m_emprNomb = txtNom.Text;
                    M.m_emprTipo = CboTipo.Text.ToString().Trim();
                    M.m_emprRefe = txtReferencia.Text.Trim();
                    M.m_empContacto = txtResponsable.Text.Trim();
                    M.m_emprEmail = txtEmail.Text.Trim();
                    M.m_emprTelf1 = txtTelefono1.Text.Trim();
                    M.m_emprTelf2 = txtTelefono2.Text.Trim();
                    M.m_emprDir = txtDireccion.Text.Trim();
                    M.m_emprPais = txtPais.Text.Trim();
                    M.m_empEstado = txtEstado.Text.Trim();
                    M.m_emprCiudad = txtCiudad.Text.Trim();
                    M.m_emprMunicipio = txtMunicipio.Text.Trim();
                    //tab2
                    M.m_emprTipoP = CboTipoPersona.Text;
                    M.m_emprRif = txtRIF.Text.Trim();
                    M.m_emprFax = txtFax.Text.Trim();
                    M.m_emprFechaCreacion = fecha;
                    M.m_emprDias = txtDias.Text.Trim();
                    M.m_emprLimite = txtLimite.Text.Trim();
                    M.m_emprComen = txtComentario.Text.Trim();
                    M.m_emprRefe = txtReferencia.Text.Trim();
                    mensaje = M.RegistarProveedor(frmPrincipal.nombreBD);
                    if (mensaje == "Registro Exitoso")
                    {
                        mensajeCaption = StringResources.ValidaciondeRegistro;
                        mensajeText = StringResources.DBRegistroexitoso;
                        MessageBox.Show(mensajeText, mensajeCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                id = txtCod.Text.ToString().Trim();
                nombre = txtNom.Text.ToString().Trim();
                tipo = CboTipo.Text.ToString().Trim();
                responsable = txtResponsable.Text.ToString().Trim();
                email = txtEmail.Text.ToString().Trim();
                telefono1 = txtTelefono1.Text.ToString().Trim();
                telefono2 = txtTelefono2.Text.ToString().Trim();
                direccion = txtDireccion.Text.ToString().Trim();
                fechacreacion = txtFechaCreacion.Text.ToString().Trim();
                ventTbProvedores.actualizarlstv("agregar");
                LimpiarCajas();
                funcionInicio();
            }
            else if (estado == "editar")
            {
                string msj = "";
                ValidarCajas();
                if (error == false)
                {
                    M.m_cod = txtCodigo.Text;
                    M.m_emprNomb = txtNom.Text;
                    M.m_emprTipo = CboTipo.Text.ToString().Trim();
                    M.m_emprRefe = txtReferencia.Text.Trim();
                    M.m_empContacto = txtResponsable.Text.Trim();
                    M.m_emprEmail = txtEmail.Text.Trim();
                    M.m_emprTelf1 = txtTelefono1.Text.Trim();
                    M.m_emprTelf2 = txtTelefono2.Text.Trim();
                    M.m_emprDir = txtDireccion.Text.Trim();
                    M.m_emprPais = txtPais.Text.Trim();
                    M.m_empEstado = txtEstado.Text.Trim();
                    M.m_emprCiudad = txtCiudad.Text.Trim();
                    M.m_emprMunicipio = txtMunicipio.Text.Trim();
                    //tab2
                    M.m_emprTipoP = CboTipoPersona.Text;
                    M.m_emprRif = txtRIF.Text.Trim();
                    M.m_emprFax = txtFax.Text.Trim();
                    M.m_emprDias = txtDias.Text.Trim();
                    M.m_emprLimite = txtLimite.Text.Trim();
                    M.m_emprComen = txtComentario.Text.Trim();
                    M.m_emprRefe = txtReferencia.Text.Trim();
                    msj = M.ActualizarProveedor(frmPrincipal.nombreBD);
                    if (msj == "Actualizacion Exitosa")
                    {
                        mensajeCaption = StringResources.ValidaciondeRegistro;
                        mensajeText = StringResources.DBActualizacionExitosa;
                        MessageBox.Show(mensajeText, mensajeCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }                    
                }
                id = txtCod.Text.ToString().Trim();
                nombre = txtNom.Text.ToString().Trim();
                tipo = CboTipo.Text.ToString().Trim();
                responsable = txtResponsable.Text.ToString().Trim();
                email = txtEmail.Text.ToString().Trim();
                telefono1 = txtTelefono1.Text.ToString().Trim();
                telefono2 = txtTelefono2.Text.ToString().Trim();
                direccion = txtDireccion.Text.ToString().Trim();
                fechacreacion = txtFechaCreacion.Text.ToString().Trim();
                ventTbProvedores.actualizarlstv("editar");
                LimpiarCajas();
                funcionInicio();
            }
        }

        private void LimpiarCajas()
        {
            this.txtCodigo.Clear();
            this.txtNombre.Clear();
            this.txtCod.Clear();
            this.txtNom.Clear();
            this.txtResponsable.Clear();
            this.txtFechaCreacion.Clear();
            this.txtTelefono1.Clear();
            this.txtTelefono2.Clear();
            this.lblSepador.Visible = true;
            this.txtDireccion.Clear();
            this.CboTipo.Enabled = false;
            this.txtEmail.Clear();
            this.txtReferencia.Clear();
            this.txtPais.Clear();
            this.txtEstado.Clear();
            this.txtCiudad.Clear();
            this.txtMunicipio.Clear();
            //tab2
            this.txtRIF.Clear();
            this.txtEmail.Clear();
            this.txtFechaCreacion.Clear();
            this.dtimeFecha.Value = DateTime.Now;
            this.txtFax.Clear();
            this.txtDias.Clear();
            this.txtLimite.Clear();
            txtComentario.Clear();
        }
        public void HabilitarBotones()
        {
            this.toolStripBtoEditar.Enabled = true;
            this.toolStripBtoEliminar.Enabled = true;
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            this.btoBuscar.Enabled = true;
            this.btnPuntos.Enabled = true;
        }
        private void ValidarCajas()
        {
            error = false;
            errPv.Clear();
            //----tab 1---------
            if (txtNom.Text == "")
            {
                errPv.SetError(txtNom, "Item Vacío");
                error = true;
            }
            if (txtReferencia.Text == "")
            {
                errPv.SetError(txtReferencia, "Item Vacío");
                error = true;
            }
            if (txtResponsable.Text == "")
            {
                errPv.SetError(txtResponsable, "Item Vacío");
                error = true;
            }
            if (txtEmail.Text == "")
            {
                errPv.SetError(txtEmail, "Item Vacío");
                error = true;
            }
            if (txtTelefono1.Text == "")
            {
                errPv.SetError(txtTelefono1, "Item Vacío");
                error = true;
            }
            if (txtTelefono2.Text == "")
            {
                errPv.SetError(txtTelefono2, "Item Vacío");
                error = true;
            }
            if (txtDireccion.Text == "")
            {
                errPv.SetError(txtDireccion, "Item Vacío");
                error = true;
            }
            if (txtPais.Text == "")
            {
                errPv.SetError(txtPais, "Item Vacío");
                error = true;
            }
            if (txtEstado.Text == "")
            {
                errPv.SetError(txtEstado, "Item Vacío");
                error = true;
            }
            if (txtCiudad.Text == "")
            {
                errPv.SetError(txtCiudad, "Item Vacío");
                error = true;
            }
            if (txtMunicipio.Text == "")
            {
                errPv.SetError(txtMunicipio, "Item Vacío");
                error = true;
            }
            //---------Tab 2//

            if (txtRIF.Text == "")
            {
                errPv.SetError(txtRIF, "Item Vacío");
                error = true;
            }
            //falta fax, preguntar si es necesario
            if (txtFechaCreacion.Text == "")
            {
                errPv.SetError(txtFechaCreacion, "Item Vacío");
                error = true;
            }
            if (txtDias.Text == "")
            {
                errPv.SetError(txtDias, "Item Vacío");
                txtDias.Text = "0";
                // error = true;
            }
            if (txtLimite.Text == "")
            {
                errPv.SetError(txtLimite, "Item Vacío");
                txtLimite.Text = "0";
                // error = true;
            }
            //if (txtComentario.Text == "")
            //{
            //    errPv.SetError(txtComentario, "Item Vacío");
            //    txtComentario.Text = "sin comentarios...";
            //    // error = true;
            //}
        }
      
        private void tbControlEmpresa_Click(object sender, EventArgs e)
        {
            if (tbControlEmpresa.SelectedIndex==0)
            {
                txtNom.Focus();
            }
            else if (tbControlEmpresa.SelectedIndex == 1)
            {
                CboTipo.Focus();
            }
        }

        private void toolStripBtoDescartar_Click(object sender, EventArgs e)
        {
            funcionInicio();
            LimpiarCajas();
        }

        private void toolStripBtoEditar_Click(object sender, EventArgs e)
        {
            FuncionEditar();
        }
        public void FuncionBuscar()
        {
            if (txtCodigo.Text == "" && txtNombre.Text == "")
            {
                return;
            }
            else if (txtCodigo.Text != "" && txtNombre.Text != "")
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
                    id = txtCodigo.Text;
                    Descrip = "";
                    ventTbProvedores.ValidarProveedor(id, Descrip, "buscar");
                }
                else
                {
                    id = "";
                    Descrip = txtNombre.Text;
                    ventTbProvedores.ValidarProveedor(id, Descrip, "buscar");
                }
            }
            if (frmTbProveedores.proveedor == "valido")
            {
                txtCod.Text = frmTbProveedores._provId;
                txtCodigo.Text = frmTbProveedores._provId;
                txtNombre.Text = frmTbProveedores._provNomb;
                txtNom.Text = frmTbProveedores._provNomb;
                CboTipo.Text = frmTbProveedores._tipo;
                txtReferencia.Text = frmTbProveedores._referencia;
                txtResponsable.Text = frmTbProveedores._responsable;
                txtEmail.Text = frmTbProveedores._provEmail;
                txtTelefono1.Text = frmTbProveedores._provTelef1;
                txtTelefono2.Text = frmTbProveedores._provTelef2;
                txtDireccion.Text = frmTbProveedores._provDir;
                txtPais.Text = frmTbProveedores._pais;
                txtEstado.Text = frmTbProveedores._estado;
                txtCiudad.Text = frmTbProveedores._ciudad;
                txtMunicipio.Text = frmTbProveedores._municipio;
                CboTipoPersona.Text = frmTbProveedores._tipopersona;
                txtFax.Text = frmTbProveedores._provFax;
                txtFechaCreacion.Text = frmTbProveedores._provFechaCreacion;
                txtDias.Text = frmTbProveedores._dias;
                txtLimite.Text = frmTbProveedores._limite;
                txtComentario.Text = frmTbProveedores._comentario;
                HabilitarBotones();
                actual = "EditarEliminar";
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
                LimpiarCajas();
            }
        }
        private void funcionEliminar()
        {
            string msj = "";
            DialogResult respuesta;
            mensajeText = StringResources.frmFallaMaquia_msjDeseaEliminar_mt;
            mensajeCaption = StringResources.ValidacióndeEliminación;            
            respuesta = MessageBox.Show(mensajeText + " " + txtNombre.Text.ToString().Trim() + " ?", mensajeCaption, MessageBoxButtons.YesNo);
            if (respuesta == DialogResult.Yes)
            {
                M.m_cod = txtCod.Text.ToString().Trim();
                msj = M.EliminarProveedor(frmPrincipal.nombreBD);
                if (msj== "Eliminacion Exitosa")
                {
                    mensajeText = StringResources.DBEliminacionexitosa;
                    mensajeCaption = StringResources.ValidacióndeEliminación;
                    MessageBox.Show(mensajeText, mensajeCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                id = txtCod.Text.ToString().Trim();
                ventTbProvedores.actualizarlstv("eliminar");
                LimpiarCajas();
                funcionInicio();
            }
        }
        public void AplicarIdioma()
        {
            //Titulo
            this.lblTituloPanel.Text = StringResources.Proveedores;
            this.Text = StringResources.Proveedores;
            //Labels
            this.lblCod.Text = StringResources.Codigo;
            this.lblCodigo.Text = StringResources.Codigo;
            this.lblNom.Text = StringResources.Nombre;
            this.lblNombre.Text = StringResources.Nombre;
            this.lblMensaje.Text = StringResources.CodigoAutogenerado;
            this.lblTipo.Text = StringResources.Tipo;
            this.lblReferencia.Text = StringResources.Referencia;
            this.lblResposable.Text = StringResources.Responsable;
            this.lblEmail.Text = StringResources.email;
            this.lblTelefono.Text = StringResources.Telefonos;
            this.lbldireccion.Text = StringResources.Direccion;
            this.lblpais.Text = StringResources.Pais;
            this.lblEstado.Text = StringResources.Estado;
            this.lblCiudad.Text = StringResources.Ciudad;
            this.lblMunicipio.Text = StringResources.Municipio;
            this.lblPersonaJuridica.Text = StringResources.PersonaJuridica;
            this.lblRIF.Text = StringResources.RIF;
            this.lblFax.Text = StringResources.FAX;
            this.lblFecha2.Text = StringResources.FechaCreacion;
            this.lblCredito.Text = StringResources.Credito;
            this.lblDias.Text = StringResources.Dias;
            this.lblLimite.Text = StringResources.Limite;
            this.lblComentario.Text = StringResources.AgregarComentario;
            //Buttons
            this.btoBuscar.Text = StringResources.btnBuscar;
            this.btoSalir.Text = StringResources.btnSalir;
            //ToolStrip
            this.toolStripBtoAgregar.Text = StringResources.btoAgregar;
            this.toolStripBtoDescartar.Text = StringResources.btoDescartar;
            this.toolStripBtoEditar.Text = StringResources.btoEditar;
            this.toolStripBtoEliminar.Text = StringResources.btoEliminar;
            this.toolStripBtoGuardar.Text = StringResources.btoGuardar;
            //ToolTip
            this.toolStripBtoAgregar.ToolTipText = StringResources.btoAgregar;
            this.toolStripBtoDescartar.ToolTipText = StringResources.btoDescartar;
            this.toolStripBtoEditar.ToolTipText = StringResources.btoEditar;
            this.toolStripBtoEliminar.ToolTipText = StringResources.btoEliminar;
            this.toolStripBtoGuardar.ToolTipText = StringResources.btoGuardar;
            //Tab
            this.tPgInfoGeneral.Text = StringResources.Informaciongeneral;
            this.tPgPopiedades.Text = StringResources.OtrasPropiedades;
        }
    }
}
