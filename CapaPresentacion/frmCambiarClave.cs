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
    public partial class frmCambiarClave : Form
    {
        //  public static string actualuser, actualpass, actualnombre;
        private clsUsuario user = new clsUsuario();
        public static string ClaveActual = "",preguntas="", clavenueva="", primeraVez = "";            //clave Inicial:123
        public string[,] respuestas = new string[3, 4];

        public frmRegristroUsuario ventRegistroUsua;  
        public frmPrincipal Principal = new frmPrincipal();

        public static int contrasena = 0;
        int  i = 0, pos = 0, codigo = 0;
        private DataTable dtRespuestas;
        string respuesta = "",pregunta = "";
      
        //IDIOMA
        public static string tipoPais = "", UsuarioRegistrado = "";
        public string mensajeText, mensajeCaption;

        public frmCambiarClave()
        {
           InitializeComponent();         
           UsuarioRegistrado = frmRegristroUsuario.bduser;
           tipoPais = frmRegristroUsuario.tipoPais;
           ClaveActual = frmRegristroUsuario.bdpass;
           AplicarIdioma();
        }
        private void frmCambiarClave_Load(object sender, EventArgs e)
        {
            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();
        }
        private void btoAceptar_Click(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "" || txtConfirmarContraseña.Text == "")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                mensajeCaption = StringResources.frmCambiarClave_messContraseñaEnBlanco;
                mensajeText = StringResources.Validacióndecampos;

                MessageBox.Show(mensajeCaption, mensajeText,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

                txtContraseña.Focus();
                
                return;
            }
            else
            {
                if (txtContraseña.Text != txtConfirmarContraseña.Text)
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    mensajeText = StringResources.frmCambiarClave_messContraseñasIguales;
                    mensajeCaption = StringResources.ErrordeValidacion;

                    // errorProvider1.SetError(txtConfirmarContraseña, mensajeText);
                    MessageBox.Show(mensajeText, mensajeCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);

                    //txtContraseña.Text = "";
                    txtConfirmarContraseña.Text = "";
                    txtContraseña.Focus();
                    return;
                }
               
                else
                {
                    if (txtContraseña.Text == "123" || txtContraseña.Text == "40BD001563085FC35165329EA1FF5C5ECBDBBEEF")
                    {
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                        mensajeText = StringResources.frmCambiarClave_messContraseña123;
                        mensajeCaption = StringResources.ErrordeValidacion;

                        MessageBox.Show(mensajeText, mensajeCaption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                        txtContraseña.Text = "";
                        txtConfirmarContraseña.Text = "";
                        txtContraseña.Focus();
                        return;
                    }
                    else
                    {
                       clavenueva = txtContraseña.Text.Trim().ToString();
                       clavenueva  = this.generarClaveSHA1(clavenueva);
                        if (ClaveActual == "40BD001563085FC35165329EA1FF5C5ECBDBBEEF")
                        {
                            primeraVez = "si";
                        }
                        if (ClaveActual == clavenueva)
                        {
                            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                            mensajeText = StringResources.frmCambiarClave_messValidaciondeContraseña;
                            mensajeCaption = StringResources.ErrordeValidacion;

                            MessageBox.Show(mensajeText, mensajeCaption,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                            txtContraseña.Text = "";
                            txtConfirmarContraseña.Text = "";
                            txtContraseña.Focus();
                            return;
                        }
                        else
                        {
                            if (primeraVez != "si")
                            {
                                guardarCambios();
                            }
                            primeraVez = "";
                            frmRegristroUsuario.bdpass = clavenueva;
                        }

                    }
                }
                  
            }
             
            if (preguntas !="no")
            {
                Preguntas();
                Principal.Show();
                this.Close();
            }
            else
            {
                if (frmPrincipal.estadoPrincipal =="activo")
                {
                    this.Close();
                }
                else
                {
                    ventRegistroUsua= new frmRegristroUsuario();
                    ventRegistroUsua.Show();
                }            
            }            
            
            return;
        }
        public void guardarCambios()
        {
            if (UsuarioRegistrado==null)
            {
                UsuarioRegistrado = frmIngreseNombreUsuario.user;
                preguntas = "no";
            }
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            mensajeText = StringResources.DBContraseñaActualizada;
            string msj = "";            
            user.m_username = UsuarioRegistrado;
            user.m_password = clavenueva.ToString().Trim();
            msj = user.validar_Cambioclave();

            if (msj == "Contraseña Actualizada")
            {
                msj = StringResources.DBContraseñaActualizada;
                MessageBox.Show(msj, mensajeCaption, 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //MessageBox.Show(mensajeText, "",
            //MessageBoxButtons.OK,
            //MessageBoxIcon.Information);

            contrasena = 1;

            txtContraseña.Text = "";
            txtConfirmarContraseña.Text = "";
            this.Hide();
        }
        public void Preguntas()
        {
            int num_preguntas;
            string cod;
            DataTable DT = new DataTable();
            DT = user.ListadoPreguntas();
            num_preguntas = DT.Rows.Count;
            ConstruccionDt();

            do
            {
                for (i = 1; i < (num_preguntas + 1); i++)
                {
                    cod = DT.Rows[i - 1]["pr_cod"].ToString();
                    IdiomaPreguntas(cod);
                    //pregunta = DT.Rows[(i - 1)]["pr_pregunta"].ToString();
                    // string codigo = DT.Rows[i]["pr_cod"].ToString();
                    respuesta = Microsoft.VisualBasic.Interaction.
                           InputBox(pregunta);
                    //Validar_BotonInput();
                    if (respuesta == "")
                    {
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                        mensajeCaption = StringResources.Validacióndecampos;
                        mensajeText = StringResources.frmCambiarClave_messPreguntasenBlanco;

                        MessageBox.Show(mensajeText, mensajeCaption,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        i--;
                    }
                    else
                    {
                        cod = DT.Rows[i - 1]["pr_cod"].ToString();
                        codigo = Int32.Parse(cod.ToString());
                        pos = (i - 1);
                        cargarDatos();
                    }

                    //return;
                }
                dtRespuestas.Rows[pos]["usua_clave"] = clavenueva.ToString().Trim();
            } while (i < num_preguntas + 1);

            // ****FALTA LLAMAR PROCEDIMIENTO******************
            user.insertarRespuestas(dtRespuestas);
        }

        private void IdiomaPreguntas(string codigo)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            switch (codigo)
            {
                case "1":
                    pregunta = StringResources.preguntaSeguridad_1;
                    break;

                case "2":
                    pregunta = StringResources.preguntaSeguridad_2;
                    break;

                case "3":
                    pregunta = StringResources.preguntaSeguridad_3;
                    break;

                case "4":
                    pregunta = StringResources.preguntaSeguridad_4;
                    break;
            }

        }
        private void ConstruccionDt()
        {
            dtRespuestas = new DataTable();
            dtRespuestas.Columns.Add("us_cod_usuario", Type.GetType("System.String"));
            dtRespuestas.Columns.Add("pr_cod_Pregunta", Type.GetType("System.Int32"));
            dtRespuestas.Columns.Add("rs_Respuesta", Type.GetType("System.String"));
            dtRespuestas.Columns.Add("usua_clave", Type.GetType("System.String"));
        }
        private void cargarDatos()
        {
            dtRespuestas.Rows.Add();
            dtRespuestas.Rows[pos]["us_cod_usuario"] = UsuarioRegistrado;
            dtRespuestas.Rows[pos]["pr_cod_Pregunta"] = codigo;
            dtRespuestas.Rows[pos]["rs_Respuesta"] = respuesta;
        }
        private void Validar_BotonInput()
        {
            if (respuesta==null)
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.frmCambiarClave_messUstedPresionoCancel;
                mensajeCaption  = StringResources.Validacióndecampos;

                MessageBox.Show(mensajeText, mensajeCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
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

            this.Text = StringResources.frmCambiarClave_Titulo;

            this.lblTitulo.Text = StringResources.frmCambiarClave_Titulo;

            this.lblContraseña.Text = StringResources.frmCambiarClave_lblContraseña;
            this.lblConfirmarContraseña.Text = StringResources.frmCambiarClave_lblConfirmarContraseña;

            this.btoAceptar.Text = StringResources.btoAceptar;
            this.btoCancelar.Text = StringResources.btoCancelar;

        }

    }
}
