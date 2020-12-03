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


namespace CapaPresentacion
{
    public partial class frmCambiarRespuestas : Form
    {
        public frmCambiarRespuestas()
        {
            InitializeComponent();
            usuarioActual = frmRegristroUsuario.bduser;
            clave = frmRegristroUsuario.bdpass;
            cargarCboxPreguntas();
            cboPreguntas.SelectedIndex = 0;
            txtRespuesta.Focus();
            this.ActiveControl = txtRespuesta;
            this.cboCodPreguntas.Visible = false;
            ConstruccionDt();

            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();

        }
        string usuarioActual;
        string clave, cod, respuesta;
        private clsUsuario usua = new clsUsuario();
        private DataTable dtRespuestas;
        int codigo, pos=0;

        public string mensajeText = "", mensajeCaption = "", pregunta = "";
        public static string tipoPais = "";

        private void cargarCboxPreguntas()
        {
           // string pregunta = "";
            int num_preguntas;
            string cod, respuesta;
            DataTable dt = new DataTable();
            dt = usua.ListadoPreguntas();
            num_preguntas = dt.Rows.Count;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cod = dt.Rows[i]["pr_cod"].ToString();
                this.cboCodPreguntas.Items.Add(dt.Rows[i]["pr_cod"].ToString());
                IdiomaPreguntas(cod);
               // this.cboPreguntas.Items.Add(pregunta);
            }
        }

        private void cboPreguntas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cboCodPreguntas.SelectedIndex  = this.cboPreguntas.SelectedIndex;
            txtRespuesta.Focus();
            cod = cboCodPreguntas.SelectedItem.ToString();
            codigo = Int32.Parse(cod.ToString());
        }

        private void btoCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void IdiomaPreguntas(string codigo)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(frmRegristroUsuario.tipoPais);
            switch (codigo)
            {
                case "1":
                    pregunta = StringResources.preguntaSeguridad_1;
                    this.cboPreguntas.Items.Add(pregunta);
                    break;

                case "2":
                    pregunta = StringResources.preguntaSeguridad_2;
                    this.cboPreguntas.Items.Add(pregunta);
                    break;

                case "3":
                    pregunta = StringResources.preguntaSeguridad_3;
                    this.cboPreguntas.Items.Add(pregunta);
                    break;

                case "4":
                    pregunta = StringResources.preguntaSeguridad_4;
                    this.cboPreguntas.Items.Add(pregunta);
                    break;

            }

        }
        private void ConstruccionDt()
        {
            dtRespuestas = new DataTable();
            dtRespuestas.Columns.Add("us_cod_usuario", Type.GetType("System.String"));
            dtRespuestas.Columns.Add("pr_cod_Pregunta", Type.GetType("System.Int32"));
            dtRespuestas.Columns.Add("rs_Respuesta", Type.GetType("System.String"));
        }
        private void cargarDatos()
        {
            dtRespuestas.Rows.Add();
            dtRespuestas.Rows[pos]["us_cod_usuario"] = usuarioActual;
            dtRespuestas.Rows[pos]["pr_cod_Pregunta"] = codigo;
            dtRespuestas.Rows[pos]["rs_Respuesta"] = respuesta;
        }
        private void btoGurdar_Click(object sender, EventArgs e)
        {
            Validacion();
        }

        private void frmCambiarRespuestas_Load(object sender, EventArgs e)
        {
            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();

           // this.Location = new System.Drawing.Point(0, 75);
        }

        private void btoAceptar_Click(object sender, EventArgs e)
        {
            //******GURADAR RESPUESTAS MODIFICADAS EN BASE DE DATOS*************
            usua.ActualizarRespuestas(dtRespuestas);
            this.Close();
        }

        private void txtRespuesta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Validacion();
            }
        }

        private void Validacion()
        {
            if (txtRespuesta.Text == "")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.IntroducirRespuesta;
                mensajeCaption = StringResources.frmCambiarRespuestas_tituloValidacionDeCambio;

                MessageBox.Show(mensajeText, mensajeCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                respuesta = txtRespuesta.Text;
                cargarDatos();
                pos++;

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.frmCambiarRespuestas_messRespuestaModificada;
                mensajeCaption = StringResources.frmCambiarRespuestas_tituloValidacionDeCambio;

                MessageBox.Show(mensajeText, mensajeCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                txtRespuesta.Text = "";
                cboPreguntas.Text = "";
            }
        }

        public void AplicarIdioma()
        {
            this.lblTitulo.Text = StringResources.frmCambiarRespuestas_lblTitulo;
            //
            this.Text = StringResources.frmCambiarRespuestas_lblTitulo;
            //
            this.lblSeleccionePregunta.Text = StringResources.frmCambiarRespuestas_lblSelelccionesPreguntas;
            this.lblIngreseRespuesta.Text = StringResources.IntroducirRespuesta;
            //
            this.btoAceptar.Text = StringResources.btoAceptar;
            this.btoCancelar.Text = StringResources.btoCancelar;
        }

    }

}
