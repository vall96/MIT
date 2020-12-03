using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using CultureResources;
using System.Threading;
using System.Globalization;
using CapaLogicaNegocios;

namespace CapaPresentacion
{
    public partial class frmValidarClaveVieja : Form
    {
        int num_intentos = 0, max_intentos = 3;
        public static int usuario_validado = 0;
        public static string  ClaveInicial = "", UsuarioRegistrado = "";
        public string tmppassword, tipoPais = "";
        string estado = "2";

        public string mensajeText = "", mensajeCaption = "";

        frmCambiarRespuestas ventCambiarResp;
        frmPrincipal ventprincipal = new frmPrincipal();

        private void frmValidarClaveVieja_Load(object sender, EventArgs e)
        {
            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();
            //this.Location = new System.Drawing.Point(0, 0);
        }

        public frmValidarClaveVieja()
        {
            InitializeComponent();
            txtClaveVieja.Focus();
            ClaveInicial = frmRegristroUsuario.bdpass;
            UsuarioRegistrado = frmRegristroUsuario.bduser;
            this.ActiveControl = txtClaveVieja;

            tipoPais = frmRegristroUsuario.tipoPais;
        }

        private void btoValidar_Click(object sender, EventArgs e)
        {
            do
            {
                if (this.txtClaveVieja.Text == "")
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    mensajeText = StringResources.frmValidarClaveVieja_lblIngreseClaveActual;
                    mensajeCaption = StringResources.ErrordeValidacion;

                    MessageBox.Show(mensajeText, mensajeCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                    this.txtClaveVieja.Focus();
                    return;
                }
                else
                {
                    // ClaveInicial = frmRegristroUsuario.bdpass;
                    ClaveInicial= this.generarClaveSHA1(this.txtClaveVieja.Text.ToString()); //PARA LA ENCRIPTACION
                    if (frmRegristroUsuario.bdpass != ClaveInicial )  // el 123 es para pruebas  //tmppassword != frmPrincipal.actualpass.ToString()) probando
                    {
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                        mensajeText = StringResources.frmValidarClaveVieja_messClaveInvalida;
                        mensajeCaption = StringResources.ErrordeValidacion;
                        ;
                        MessageBox.Show(mensajeText, mensajeCaption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                        this.txtClaveVieja.Focus();
                        num_intentos++;
                        if (num_intentos != 3) return;
                    }
                    else
                    {
                        usuario_validado = 1;
                        // Incluir el formulario de cambio de clave

                        Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                        mensajeText = StringResources.frmIngreseNombreUsuario_messValidacionExitosa;
                        mensajeCaption = StringResources.Validacióndecampos;

                        MessageBox.Show(mensajeText, mensajeCaption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);

                    }
                }
                if (num_intentos == max_intentos)
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    mensajeText = StringResources.frmValidarClaveVieja_messMaximoDeIntentos;
                    mensajeCaption = StringResources.ErrordeValidacion;

                    MessageBox.Show(mensajeText, mensajeCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                    // dat = con.Capturar_Datos("sp_CambiarStatusUsuario", new object[] { frmPrincipal.actualuser.ToString(), estado });
                    this.Close();
                    // Se debe sacar del sistema
                 usuario_validado = 0;
                }
            }
            while ((num_intentos < max_intentos) && (usuario_validado == 0));
            if (usuario_validado == 0)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.frmValidarClaveVieja_messMaximoDeIntentos;
                mensajeCaption = StringResources.ErrordeValidacion;

                MessageBox.Show(mensajeText, mensajeCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                Application.Exit();
                //break;
            }
            else
            {

                //***********Permitir que cambie su contrasena***********************//
                if (frmPrincipal.estadoPrincipal == "principal")
                {
                    this.Close();
                }
                else if (frmPrincipal.estadoPrincipal == "cambiarrespuestas")
                {
                    ventCambiarResp = new frmCambiarRespuestas();
                    ventCambiarResp.ShowDialog();
                    this.Close();
                }
                else
                {
                    frmCambiarClave Cambioclave = new frmCambiarClave();
                //  Cambioclave.MdiParent = this;
                    frmCambiarClave.preguntas = "no";
                    this.Close();
                    Cambioclave.ShowDialog();
                // ventprincipal.abrirVentVclave();
                    

                }
            }
        }

        private void btoCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        public void AplicarIdioma()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            //tite form
            this.Text = StringResources.ValidacionClaveActual;
            //tite panel
            this.lblValidaciondeClave.Text = StringResources.ValidacionClaveActual;
            //label's
            this.lblSubTite.Text = StringResources.frmValidarClaveVieja_lblIngreseClaveActual;
            this.lblClave.Text = StringResources.frmValidarClaveVieja_lblContraseña;
            //bto's
            this.btoValidar.Text = StringResources.btoValidar;
            this.btoCancelar.Text = StringResources.btoCancelar;
        }
    }
}
