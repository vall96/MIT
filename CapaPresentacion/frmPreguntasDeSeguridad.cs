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
    public partial class frmPreguntasDeSeguridad : Form
    {
        public static string IdiomaPais = "", UsuarioRegistrado = "";

        private clsUsuario user = new clsUsuario();
        public clsStatus stat = new clsStatus();

        int num_preguntas;

        ListViewItem lvrow;

        public string estadoactual, usuaValido;

        public int textBlanco = 0;
        public string preguntas;

        public string preg = "";

        public static string tipoPais = "";

        public string mensajeText = "", mensajeCaption = "";

        public frmPreguntasDeSeguridad()
        {
            InitializeComponent();

            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();

        }
        public void Cargar_lvPreguntas()
        {
            this.lvPreguntasSeguridad.Items.Clear();
            DataTable dt = new DataTable();
            dt = user.ListadoPreguntas();
            num_preguntas = dt.Rows.Count;

            for (int i = 0; i < num_preguntas; i++)
            {
                lvrow = new ListViewItem(dt.Rows[i]["pr_cod"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["pr_pregunta"].ToString());
                this.lvPreguntasSeguridad.Items.Add(lvrow);
            }
        }


        /// <summary>
        ///+++++++++++++++ Acciones del formulario +++++++++++++++++++++++++++++
        /// </summary>
        public void Validar_editar()  //REVISAR 
        {
            if (usuaValido == "usuario valido")
            {
                string msj = "";
                string preg = "";
                user.m_Pregunta = txtPregunta.Text.ToString().Trim();
                msj = "";
                preg = user.m_Pregunta;
            }
        }
        public void validar_Agregar()
        {

            if (this.txtPregunta.Text == "")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.frmPreguntasDeSeguridad_messDebeIngresarUnaPregunta;
                mensajeCaption = StringResources.ErrordeValidacion;

                MessageBox.Show(mensajeText, mensajeCaption,
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Error);

                this.txtPregunta.Focus();
                textBlanco = 1;
                return;
            }
            else
            {
                //pruebas
                string msj = "";
                user.m_Pregunta = txtPregunta.Text.ToString().Trim();
                msj = user.RegistrarPreguntas();
                preg = user.preg; //me trae el codigo para cargarlo en el lst

                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                mensajeCaption = StringResources.ValidaciondeRegistro;

                MessageBox.Show(msj, mensajeCaption,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                                              
                lvrow = new ListViewItem(preg.ToString().Trim());
                lvrow.SubItems.Add(this.txtPregunta.Text.ToString().Trim());
                this.lvPreguntasSeguridad.Items.Add(lvrow);
                funcion_cancelar();
                num_preguntas++;
            }
        }
        public void validar_Eliminar()
        {

            if (this.txtPregunta.Text == "")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.frmPreguntasDeSeguridad_messDebeIngresarUnaPregunta;
                mensajeCaption = StringResources.ErrordeValidacion;

                MessageBox.Show(mensajeText, mensajeCaption,
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Error);

                this.txtPregunta.Focus();
                textBlanco = 1;
                return;
            }
            else
            {
                usuaValido = "usuario valido";
                if (usuaValido == "usuario valido")
                {
                    string msj = "";
                    DialogResult respuesta;

                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    mensajeText = StringResources.frmPreguntasDeSeguridad_messEliminarPregunta;
                    mensajeCaption = StringResources.ValidacióndeEliminación;

                    respuesta = MessageBox.Show(mensajeText, mensajeCaption, MessageBoxButtons.YesNo);
                    if (respuesta == DialogResult.Yes)
                    {
                        preg = txtCodigo.Text.ToString().Trim();
                        user.m_codPregunta = Int32.Parse(preg.ToString());
                        user.eliminar_Preguntas();
                        msj = user.eliminar_Preguntas();

                        Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                        mensajeCaption = StringResources.ValidacióndeEliminación;
                        MessageBox.Show(msj, mensajeCaption,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        for (int i = 0; i < num_preguntas; i++)
                        {
                            if (lvPreguntasSeguridad.Items[i].SubItems[0].Text.ToString().Trim()
                                == this.txtCodigo.Text.ToString().Trim())
                            {
                                lvPreguntasSeguridad.Items.RemoveAt(i);
                                num_preguntas--;
                            }
                        }
                        funcion_cancelar();
                    }
                }
            }
        }
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public void cambiarEstado(string estado)
        {
            switch (estado)
            {
                case "inicio":
                    estadoactual = estado;
                    funcion_inicio();
                    break;

                
                case "cancelar":
                    funcion_cancelar();
                    break;

                case "agregar":
                    estadoactual = estado;
                    funcion_agregar();
                    break;

                case "eliminar":
                   // eliminar_Preguntas();
                    break;

                case "guardar":
                    if (estadoactual == "agregar")
                    {
                        validar_Agregar();
                    }
                    else
                    if (estadoactual == "editar")
                    {
                        //Validar_editar();     //pendiente
                    }

                    break;
            }

        }

        //++++++++++++++++++++++++++++++++++ funciones del Formulario +++++++++++++++++++++++++++++++++++++++++
        public void funcion_editar()
        {
            this.txtCodigo.Enabled = false;
            this.txtPregunta.Enabled = true;
        }
        public void funcion_buscar()
        {
            this.txtPregunta.Enabled = false;
        }
        public void funcion_cancelar()
        {
            this.txtPregunta.Text = "";
            this.txtCodigo.Text = "";
        }
        private void funcion_agregar()
        {
            this.txtCodigo.Enabled = true;
            this.txtPregunta.Enabled = false;
        }
        private void funcion_inicio()
        {
            this.txtCodigo.Enabled = true;
            this.txtPregunta.Enabled = false;
            //    this.lstViewStaUsuarios.Enabled = false;
            this.txtCodigo.Text = "";
            this.txtPregunta.Text = "";
        }
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private void frmPreguntasDeSeguridad_Load(object sender, EventArgs e)
        {
            Cargar_lvPreguntas();
            txtCodigo.Enabled = false;
            txtCodigo.Text = "";
            txtPregunta.Text = "";
               
        }
        private void lvPreguntasSeguridad_DoubleClick(object sender, EventArgs e)
        {
            string cod = lvPreguntasSeguridad.SelectedItems[0].SubItems[0].Text;
            string descripcion = lvPreguntasSeguridad.SelectedItems[0].SubItems[1].Text;

            txtCodigo.Text = cod;
            txtPregunta.Text = descripcion;
        }
        private void btoAgregar_Click(object sender, EventArgs e)
        {
            validar_Agregar();
            txtCodigo.Enabled = false;
            txtPregunta.Enabled = true;
        }
        private void btoCancelar_Click(object sender, EventArgs e)
        {
            //fmrOlvidarContraseña prueba = new fmrOlvidarContraseña();
            //prueba.MdiParent = this;
            //prueba.Show();
            //return;
            txtPregunta.Text = "";
            txtCodigo.Text = "";
        }
        private void btoEliminar_Click(object sender, EventArgs e)
        {
            validar_Eliminar();
        }

        public void AplicarIdioma()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);

            this.Text = StringResources.frmPreguntasDeSeguridad_TITULO;

            this.lblCodigo.Text = StringResources.Codigo;
            this.lblPregunta.Text = StringResources.frmPreguntasDeSeguridad_lblPregunta;

            this.btoAgregar.Text = StringResources.agregar;
            this.btoEliminar.Text = StringResources.btoEliminar;
            this.btoCancelar.Text = StringResources.btoCancelar;
        }

    }
}
