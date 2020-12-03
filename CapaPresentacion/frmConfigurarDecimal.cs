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
    public partial class frmConfigurarDecimal : Form
    {
        public static string Valor = "", ValorP = "Punto (.)", ValorC = "Coma (,)", Activo="";
        public string tipoPais = "";
        public frmConfigurarDecimal()
        {
            InitializeComponent();
            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();
           
        }

        private void frmConfigurarDecimal_Load(object sender, EventArgs e)
        {
            Verificacion();
        }

        private void Verificacion()
        {
            string radio = frmPropiedadesSistema.radio;
            if (radio!="")
            {
                string dt = radio.ToString();
                switch (dt)
                {
                    case "Punto (.)":
                        rbtnPunto.Checked = true;
                        rbtnComa.Checked = false;
                        break;
                    case "Coma (,)":
                        rbtnPunto.Checked = false;
                        rbtnComa.Checked = true;
                        break;
                }
            }
        }
        private void btoGuardar_Click(object sender, EventArgs e)
        {
            if (rbtnPunto.Checked == true)
            {
                Valor = this.rbtnPunto.Text.ToString();      
                Activo = "Punto";
            }
            else if (rbtnComa.Checked == true)
            {
                Valor = this.rbtnComa.Text.ToString();
                Activo = "Coma";
            }
            this.Close();
        }
        public void AplicarIdioma()
        {
            ////Titulo
            //this.lblTitulo.Text = StringResources.frmConfiguracionDecimal_Titulo;
            //this.Text = StringResources.frmConfiguracionDecimal_Titulo;
            ////RadioButton
            //this.rbtnPunto.Text = StringResources.Punto;
            //this.rbtnComa.Text = StringResources.Coma;
            ////Button
            //this.btoGuardar.Text = StringResources.Guardar;
        }
    }
}
