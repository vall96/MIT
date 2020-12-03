using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using CultureResources;
using CapaLogicaNegocios;
using System.Windows.Threading;

namespace CapaPresentacion
{
    public partial class frmFallasMaquinas : Form
    {
        public static string id, descrip = "", modulo = "", descripcion = "";
        public string tipoPais = "", cod = "", Descrip = "";
        public static string codigo = "", descripccion = "",maquina="";
        public string accion = "", mensajeText = "", mensajeCaption = "", actual;
        public clsUsuario usua = new clsUsuario();
        public clsEmpresa emp = new clsEmpresa();
        frmTbFallaMquinas ventTbFallaMaquinas;
        DataTable dt = new DataTable();
        private void frmFallasMaquinas_Load(object sender, EventArgs e)
        {
            frmPrincipal.nombreBD = "Digitel";
            this.Location = new System.Drawing.Point(0, 0);
            ventTbFallaMaquinas = new frmTbFallaMquinas();
            cargar();

        }
        public void cargar()
        {
            dt = emp.CargarLstv(frmPrincipal.nombreBD);
        }

        public frmFallasMaquinas()
        {
            InitializeComponent();
            FuncionInicio();
            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();
        }
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

        private void btoPuntos_Click(object sender, EventArgs e)
        {
            ventTbFallaMaquinas = new frmTbFallaMquinas();
            ventTbFallaMaquinas.pasado += new frmTbFallaMquinas.pasar(ejecutar);
            ventTbFallaMaquinas.ShowDialog();
        }

        private void limpiarCajas()
        {
            txtCodigo.Clear();
            txtDescripcion.Clear();
            txtDescrip.Clear();
            txtCod.Clear();
        }

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
        }

        private void toolStripBtoEliminar_Click(object sender, EventArgs e)
        {
            funcionEliminar();
        }

        private void btoSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btoBuscar_Click(object sender, EventArgs e)
        {
            FuncionBuscar();
        }

        private void frmFallasMaquinas_KeyDown(object sender, KeyEventArgs e)
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

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                FuncionBuscar();
            }
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || (e.KeyChar >= 97 && e.KeyChar <= 122) || (e.KeyChar >= 65 && e.KeyChar <= 90) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
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

        private void toolStripBtoDescartar_Click(object sender, EventArgs e)
        {
            limpiarCajas();
            FuncionInicio();
        }
        public void HabilitarBotones()
        {
            this.toolStripBtoEditar.Enabled = true;
            this.toolStripBtoEliminar.Enabled = true;
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            this.btoBuscar.Enabled = true;
            this.btoPuntos.Enabled = true;
        }

        private void FuncionInicio()
        {
            this.btoPuntos.Enabled = true;
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
        public void FuncionBuscar()
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
                    id = txtCodigo.Text;
                    descrip = "";
                    ventTbFallaMaquinas.validarmaquina(id, descrip, "buscar");
                }
                else
                {
                    id = "";
                    descrip = txtDescripcion.Text;
                    ventTbFallaMaquinas.validarmaquina(id, descrip, "buscar");
                }
            }
            if (frmTbFallaMquinas.maquina == "Valida")
            {
                txtCod.Text = frmTbFallaMquinas._Id;
                txtCodigo.Text = frmTbFallaMquinas._Id;
                txtDescrip.Text = frmTbFallaMquinas._Descripcion;
                txtDescripcion.Text = frmTbFallaMquinas._Descripcion;
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
                limpiarCajas();
            }
        }
        private void FuncionAgregar()
        {
            this.btoPuntos.Enabled = false;
            accion = "agregar";
            actual = "agregar";
            limpiarCajas();
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoEliminar.Enabled = false;
            this.toolStripBtoGuardar.Enabled = true;
            this.toolStripBtoDescartar.Enabled = true;
            this.btoBuscar.Enabled = false;
            txtCodigo.Enabled = false;
            txtDescripcion.Enabled = false;
            txtCod.Enabled = true;
            txtDescrip.Enabled = true;
            txtCod.Focus();
        }
        public void FuncionEditar()
        {
            accion = "editar";
            this.btoPuntos.Enabled = false;
            this.txtDescripcion.Enabled = false;
            this.txtCodigo.Enabled = false;
            this.txtCod.Enabled = false;
            this.txtDescrip.Enabled = true;
            this.txtDescrip.Focus();
            this.toolStripBtoGuardar.Enabled = true;
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoEliminar.Enabled = false;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            this.btoBuscar.Enabled = false;
            actual = "editar";

        }
        private void funcionEliminar()
        {
            if (frmTbFallaMquinas.maquina == "Valida")
            {
                string msj = "";
                DialogResult respuesta;
                mensajeText = StringResources.frmFallaMaquia_msjDeseaEliminar_mt;
                mensajeCaption = StringResources.ValidacióndeEliminación;
                respuesta = MessageBox.Show(mensajeText+" "+txtDescrip.Text.ToString().Trim() + " ?", mensajeCaption,MessageBoxButtons.YesNo);
                if (respuesta == DialogResult.Yes)
                {
                    emp.m_cod = txtCod.Text.ToString().Trim();
                    msj = emp.EliminarFalla(frmPrincipal.nombreBD);
                    if (msj == "Eliminacion Exitosa")
                    {
                        mensajeText = StringResources.DBEliminacionexitosa;
                        mensajeCaption = StringResources.ValidacióndeEliminación;
                        MessageBox.Show(mensajeText, mensajeCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    ventTbFallaMaquinas.actualizarlstv(accion);
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
                    mensajeText = StringResources.ExistenCamposVacios;
                    mensajeCaption = StringResources.ValidaciondeRegistro;
                    MessageBox.Show(mensajeText, mensajeCaption,MessageBoxButtons.OK,MessageBoxIcon.Error);
                    this.txtDescrip.Focus();
                    if (this.txtCod.Text == "")
                    {
                        this.txtCod.Focus();
                        return;
                    }
                    else
                    {
                        this.txtDescrip.Focus();
                        return;
                    }
                }
                else
                {
                    string msj = "";

                    Boolean existe = false;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (txtCod.Text.ToString().Trim().ToLower() == dt.Rows[i]["FallasMaq_Id"].ToString().Trim().ToLower())
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
                        emp.m_Descripcion = txtDescrip.Text;
                        emp.m_cod = txtCod.Text;
                        msj = emp.RegistarFalla(frmPrincipal.nombreBD);
                        if (msj == "Registro Exitoso")
                        {
                            mensajeCaption = StringResources.ValidaciondeRegistro;
                            mensajeText = StringResources.DBRegistroexitoso;
                            MessageBox.Show(mensajeText, mensajeCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }

                }
                ventTbFallaMaquinas.actualizarlstv("agregar");
                limpiarCajas();
                FuncionInicio();
            }
            else if (accion == "editar")
            {
                if (this.txtDescrip.Text == "")
                {
                    mensajeText = StringResources.ExistenCamposVacios;
                    mensajeCaption = StringResources.ValidaciondeRegistro;
                    MessageBox.Show(mensajeText,mensajeCaption,MessageBoxButtons.OK,MessageBoxIcon.Error);
                    this.txtDescrip.Focus();
                    return;
                }
                else if (frmTbFallaMquinas.maquina == "Valida")
                {
                    string msj = "";

                    emp.m_Descripcion = txtDescrip.Text.ToString().Trim();
                    emp.m_cod = txtCod.Text.ToString().Trim();
                    msj = emp.ActualizarFalla(frmPrincipal.nombreBD);
                    if (msj == "Actualizacion Exitosa")
                    {
                        mensajeCaption = StringResources.frmFallaMaquinas_msjActualizacionExitosa;
                        mensajeText = StringResources.frmFallaMaquinas_msjActualizacionExitosa;
                        MessageBox.Show(mensajeText, mensajeCaption, MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }
                ventTbFallaMaquinas.actualizarlstv("editar");
                limpiarCajas();
                FuncionInicio();
            }
        }
        public void AplicarIdioma()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
            //
            this.Text = StringResources.frmFallaMaquinas_Titulo;
            this.lblTituloPanel.Text = StringResources.frmFallaMaquinas_Titulo;
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
            this.tabIformacionG.Text = StringResources.Informaciongeneral;
        }
    }
}
