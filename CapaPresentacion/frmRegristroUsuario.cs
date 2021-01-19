using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Threading;
using System.Globalization;
using CultureResources;
using CapaLogicaNegocios;

namespace CapaPresentacion
{
    public partial class frmRegristroUsuario : Form
    {
        
        private clsUsuario Usua = new clsUsuario();

        internal static string UsuarioRegistrado = "", ClaveInicial = "";
    //    public fmrOlvidarContraseña olvContra = new fmrOlvidarContraseña(ClaveInicial, bdpass);
        public frmRegristroUsuario()
        {
           InitializeComponent();
           cboIdioma.SelectedIndex = 0;
        }
        public static string tipoPais = "";
        public static string bduser, bdpass, bdstatus, bdnombre, bdactivo;
        //FrmTbUsuarios ventUsuarios;
        frmPrincipal ventPrincipal;
        frmEmpresaSucursursal ventEmpresa;
        //Variables
        int num_intentos = 0, usuario_valido = 0;
        public string tmppassword, mensajeText="", mensajeCaption="";

        private void frmRegristroUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            mensajeText = StringResources.frmRegistroUsuario_messCerrandoSistema;
            mensajeCaption = StringResources.ErrordeValidacion;

            MessageBox.Show(mensajeText, mensajeCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.ExitThread();
        }

        private void textUsuario_KeyPress(object sender, KeyPressEventArgs e)
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

       

        private void frmRegristroUsuario_Load(object sender, EventArgs e)
        {
            AplicarIdioma();
            ventPrincipal = new frmPrincipal();
            //ventPrincipal.Enabled = false;
            //ventPrincipal.Show();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            UsuarioRegistrado = frmRegristroUsuario.bduser;

            frmIngreseNombreUsuario nom = new frmIngreseNombreUsuario();
            nom.Show();
            
            return;
        }

        private void cboIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pais = "";

            pais = Convert.ToString(cboIdioma.SelectedItem); //valerie

            if (pais == "Español")
            {
                tipoPais = "es-VE";
                this.cboIdioma.SelectedIndex = 0;
            }
            else
            if (pais == "Ingles")
            {
                tipoPais = "en-US";
                this.cboIdioma.SelectedIndex = 1;
            }
            else
            if (pais == "Frances")
            {
                tipoPais = "fr-FR";
                this.cboIdioma.SelectedIndex = 2;
            }
            else
            if (pais == "Ruso")
            {
                tipoPais = "ru-RU";
                this.cboIdioma.SelectedIndex = 3;
            }
            //else
            //if (pais == "Japones")
            //{
            //    tipoPais = "ja-JP";
            //    this.cboIdioma.SelectedIndex = 4;
            //}

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();
         
        }
        private void btoSalir_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            mensajeText = StringResources.frmRegistroUsuario_messCerrandoSistema;
            mensajeCaption = StringResources.frmRegistroUsuario_messCerrandoSistema;

            MessageBox.Show(mensajeText, mensajeCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.ExitThread();
            //MessageBox.Show("Cerrando el sistema");
            //this.Close();
        }

        private void frmRegristroUsuario_Shown(object sender, EventArgs e)
        {
            this.textUsuario.Focus();
        }
        private void btoValidar_Click_1(object sender, EventArgs e)
        {
           
            //Validacion de campo nulo
            do
            {
                if (this.textUsuario.Text == "")       //si el campo eta vacio
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    mensajeText = StringResources.IngresarNombreDeUsuario;
                    mensajeCaption = StringResources.ErrordeValidacion;
                    MessageBox.Show(mensajeText, mensajeCaption, System.Windows.Forms.MessageBoxButtons.OK,
                   System.Windows.Forms.MessageBoxIcon.Error);
                   this.textUsuario.Focus();
                
                   return;
                }
                //num_intentos = num_intentos + 1;
                if (this.txtClave.Text == "")      //si el campo eta vacio
                {

                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    mensajeText = StringResources.frmRegistroUsuario_messPedirClave;
                    mensajeCaption = StringResources.ErrordeValidacion;
                    MessageBox.Show(mensajeText, mensajeCaption, System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
                    this.textUsuario.Focus();
                    return;
                }
                tmppassword = txtClave.Text;
                //Encriptacion de la clave 
                tmppassword = this.generarClaveSHA1(this.txtClave.Text.ToString());
                try
                {
                    DataTable dt = new DataTable();
                    Usua.m_username = textUsuario.Text;
                    Usua.m_password = txtClave.Text;

                    dt = Usua.buscarUsuario(Usua.m_username);

                    if (dt.Rows.Count > 0)
                    {
                        bduser = dt.Rows[0]["us_username"].ToString().Trim();
                        bdpass = dt.Rows[0]["us_password"].ToString().Trim();
                        bdstatus = dt.Rows[0]["us_status"].ToString().Trim();
                        bdnombre = dt.Rows[0]["us_nombre"].ToString().Trim();
                        bdactivo= dt.Rows[0]["us_eliminados"].ToString().Trim();

                        //recordar q usuario valido es =0, sino esta desabilitado u otros
                        if (bdstatus != "0" || bdactivo!="0")
                        {
                            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                            mensajeText = StringResources.UsuarioBloqueado;
                            mensajeCaption = StringResources.ValidaciónDeUsuario;
                            MessageBox.Show(mensajeText, mensajeCaption,
                            System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Exclamation);
                            this.txtClave.Text = "";
                            this.textUsuario.Text = "";
                            this.textUsuario.Focus();
                            
                          //  ventUsuarios.userRegistrado = bduser;
                            return;
                        }
                        else
                        {
                            //validacion de clave 
                            if (bdpass == tmppassword)
                            {
                                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                                mensajeText = StringResources.frmRegistroUsuario_messBienvenida;
                                mensajeCaption = StringResources.ValidaciónDeUsuario;
                                MessageBox.Show(mensajeText + " " + bdnombre, mensajeCaption,
                                System.Windows.Forms.MessageBoxButtons.OK,
                                System.Windows.Forms.MessageBoxIcon.Exclamation);
                                //ventPrincipal = new frmPrincipal(bduser,tipoPais);
                                this.Hide();
                                // usuario_valido = 1;

                                //********OJO VALIDACION DE SI ES LA PRIMERA VEZ QUE ENTRA AL SISTEMA******
                                if (bdpass == "40BD001563085FC35165329EA1FF5C5ECBDBBEEF")
                                {
                                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                                    mensajeText = StringResources.CambiarClave;
                                    mensajeCaption = StringResources.ValidaciónDeUsuario;
                                    //mensajeText= StringResources.frmRegristr
                                    System.Windows.Forms.MessageBox.Show(bdnombre + " , " + mensajeText, mensajeCaption,
                                    System.Windows.Forms.MessageBoxButtons.OK,
                                    System.Windows.Forms.MessageBoxIcon.Exclamation);
                                    frmCambiarClave cambioclave = new frmCambiarClave();
                                    //cambioclave.MdiParent = this;
                                    cambioclave.Show();
                                    if (frmCambiarClave.contrasena == 1)
                                    {
                                        usuario_valido = 1;
                                    }
                                    else
                                    {
                                        return;
                                    }
                                    //usuario_valido = 0;
                                }
                                else
                                {
                                    usuario_valido = 1;
                                }
                            }

                            else
                            {
                                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                                mensajeText = StringResources.frmRegistroUsuario_messClaveInvalida;
                                mensajeCaption = StringResources.ValidaciónDeUsuario;
                                MessageBox.Show(mensajeText, mensajeCaption,
                                System.Windows.Forms.MessageBoxButtons.OK,
                                System.Windows.Forms.MessageBoxIcon.Exclamation);

                                txtClave.Text = ""; //valerie
                                txtClave.Focus();

                                num_intentos++;
                                if (num_intentos != 3) return;
                            }
                        }
                    }

                    else
                    {
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                        mensajeText = StringResources.frmRegistroUsuario_UsuarioInvalido;
                        mensajeCaption = StringResources.ValidaciónDeUsuario;
                        MessageBox.Show(mensajeText, mensajeCaption,
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Error);
                        num_intentos++;
                        if (num_intentos != 3) return;
                    }
                    if (num_intentos == 3)
                    {
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                        mensajeText = StringResources.frmRegistroUsuario_messCerrandoSistema;
                        mensajeCaption = StringResources.frmRegistroUsuario_messSalidaSistema;
                        MessageBox.Show(mensajeText, mensajeCaption,
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Error);                        
                        this.Close();
                    }
                }

                catch (Exception ex)
                {
                    throw ex;
                }

            } while ((num_intentos < 3)&& (usuario_valido == 0));
            {
                if (usuario_valido == 1)
                {
                    this.Hide();
                    frmEmpresaSucursursal ventEmpresa = new frmEmpresaSucursursal();
                    ventEmpresa.Show();
                    //frmPrincipal ventPrincipal = new frmPrincipal();
                    //ventPrincipal.Show();
                }
                else
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    mensajeText = StringResources.frmRegistroUsuario_messCerrandoSistema;
                    mensajeCaption = StringResources.frmRegistroUsuario_messCerrandoSistema;

                    MessageBox.Show(mensajeText, mensajeCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.ExitThread();
                }             
            }
        }

        private void AplicarIdioma()
        {
            //Cambiamos las etiquetas
            this.lblIdioma.Text = StringResources.frmRegistroUsuario_lblIdioma;
            this.lblTitulo.Text = StringResources.ValidaciónDeUsuario;
            this.lblClave.Text = StringResources.frmRegistroUsuario_lblClave;
            this.lblUsuario.Text = StringResources.frmRegistroUsuario_lblUsuario;
            this.Text = StringResources.ValidaciónDeUsuario;
            //Cambiamos botones
            this.btoValidar.Text = StringResources.btoValidar;
            this.btoSalir.Text = StringResources.btnSalir;
            this.lblOlvidoClave.Text = StringResources.frmRegistroUsuario_lblOlvidoContrasena;
        }
        private string generarClaveSHA1(string nombre)
        {
            // Crear una clave SHA1 como la generada por
            // FormsAuthentication.HashPasswordForStoringInConfigFile
            // Adaptada del ejemplo de la ayuda en la descripción de SHA1 (Clase)
            UTF8Encoding enc = new UTF8Encoding();
            byte[] data = enc.GetBytes(nombre);
            byte[] result;

            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
            // This is one implementation of the abstract class SHA1.
            result = sha.ComputeHash(data);
            //
            // Convertir los valores en hexadecimal
            // cuando tiene una cifra hay que rellenarlo con cero
            // para que siempre ocupen dos dígitos.
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] < 16)
                {
                    sb.Append("0");
                }
                sb.Append(result[i].ToString("x"));
            }
            //
            return sb.ToString().ToUpper();
        }
    }
}
