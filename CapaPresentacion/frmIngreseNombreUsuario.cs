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
    public partial class frmIngreseNombreUsuario : Form
    {
        public static string user = "", bduser = "";
        int cant=0;
        private clsUsuario Usua = new clsUsuario();
        string pregunta = "";
        string respuesta = "";
        string estado = "";
        public static string tipoPais = "";
        public string mensajeText = "", mensajeCaption = "";

        int a = 0, b = 0, cont=0;
        public frmIngreseNombreUsuario()
        {
            InitializeComponent();
            this.ActiveControl = txtNombreUsuario;
            tipoPais = frmRegristroUsuario.tipoPais;
            AplicarIdioma();

        }
        DataTable dt = new DataTable();
        frmCambiarClave venCambioClave = new frmCambiarClave();
        frmRegristroUsuario venRegistro;
 
        private void btoCancelar_Click(object sender, EventArgs e)
        {
            venRegistro = new frmRegristroUsuario();
            this.Close();
            venRegistro.Show();
        }

        private void frmIngreseNombreUsuario_Load(object sender, EventArgs e)
        {
            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();
        }

        private void btoAceptar_Click(object sender, EventArgs e)
        {
            if (txtNombreUsuario.Text == "")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);

                mensajeText = StringResources.frmIngreseNombreUsuario_messNombreEnBlanco;
                mensajeCaption = StringResources.Validacióndecampos;

                MessageBox.Show(mensajeText, mensajeCaption,
                MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                user = txtNombreUsuario.Text.Trim().ToString();                
                Usua.m_username = user;                
                dt = Usua.BuscarUsuarioRespuestas();
                if  (dt.Rows.Count==0)
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    mensajeText = StringResources.frmIngreseNombreUsuario_messElUsuarioNoExiste;
                    mensajeCaption = StringResources.Validacióndecampos;

                    MessageBox.Show(mensajeText, mensajeCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    PreguntasRandom();
                    if  (estado != "valido")
                    {
                        this.Close();
                    }
                    else 
                    {
                        frmCambiarClave.preguntas = "no";
                        this.Close();
                        venCambioClave.Show();
                    }
                }
            }

        }
        public void PreguntasRandom()
        {
            for (int i = 0; i < 2; i++)
            {
                Random R = new Random();
                a = R.Next(1, 4);
                if (i == 0)
                {
                    b = a;
                }
                else if (a == b)
                {
                    i--;
                }
            }

            do
            {
                // pregunta = dt.Rows[b]["pr_pregunta"].ToString();
                // HacerPreguntas();
                IdiomaPreguntas(b.ToString());
                respuesta = Microsoft.VisualBasic.Interaction.InputBox(pregunta);

                if (respuesta == "")
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    mensajeText = StringResources.IntroducirRespuesta;
                    mensajeCaption = StringResources.Validacióndecampos;


                    MessageBox.Show(mensajeText, mensajeCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (respuesta.Trim().ToString() == dt.Rows[b - 1]["res_resp"].ToString())
                    {
                        cont = 0;
                        b = a;
                        do
                        {
                            //HacerPreguntas();
                            IdiomaPreguntas(b.ToString());
                            respuesta = Microsoft.VisualBasic.Interaction.InputBox(pregunta);
                            if (respuesta.Trim().ToString() == dt.Rows[a - 1]["res_resp"].ToString())
                            {
                                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                                mensajeText = StringResources.frmIngreseNombreUsuario_messValidacionExitosa;
                                mensajeCaption = StringResources.Validacióndecampos;

                                MessageBox.Show(mensajeText, mensajeCaption,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);

                                estado = "valido";
                                //venCambioClave.Show();
                                cont = 2;
                            }
                            else
                            {
                                error();
                                cont++;
                            }
                        } while (cont < 2);
                    }
                    else
                    {
                        error();
                        cont++;
                    }
                }
            } while (cont < 2);
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
        private void HacerPreguntas()
        {
            pregunta = dt.Rows[b]["pr_pregunta"].ToString();
            return;
        }
        private void error()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            mensajeText = StringResources.frmIngreseNombreUsuario_messRespuestaErrada;
            mensajeText = StringResources.ErrordeValidacion;

            MessageBox.Show(mensajeText, mensajeCaption,
            MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation);

            //MessageBox.Show("Su respuesta no coincide con la informacion almacenada en la base de datos", "Error de Validacion",
            //MessageBoxButtons.OK,
            //MessageBoxIcon.Exclamation);
        }
        public void AplicarIdioma()
        {
            this.Text = StringResources.frmIngreseNombreUsuario_TituloFormulario;

            this.lblIngreseNombre.Text = StringResources.frmIngreseNombreUsuario_lblIngreseNombre;

            this.lblUsuario.Text = StringResources.frmRegistroUsuario_lblUsuario;

            this.btoAceptar.Text = StringResources.btoAceptar;
            this.btoCancelar.Text = StringResources.btoCancelar;

            this.lblTitulo.Text = StringResources.Nombre;
        }

    }
}
