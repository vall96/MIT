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
using System.Windows.Forms.VisualStyles;

namespace CapaPresentacion
{
    public partial class FrmNumeroDecimal : Form
    {
        public FrmNumeroDecimal()
        {
            InitializeComponent();
        }
        public static string numero1, Decimal, numero;
        public string tipoPais="";
        private void FrmNumeroDecimal_Load(object sender, EventArgs e)
        {
            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();
            Validar();
        }
       
        private void btoGuardar_Click(object sender, EventArgs e)
        {           
            if (dudNumeroDecimal.Text == "1")
            {
               // numero = StringResources._1Decimal;
                numero1 ="1";
            }
            if (dudNumeroDecimal.Text == "2")
            {
             //   numero = StringResources._2Decimales;
                numero1 = "2";
            }
            if (dudNumeroDecimal.Text == "3")
            {
               // numero = StringResources._3Decimales;
                numero1 = "3";
            }
            if (dudNumeroDecimal.Text == "4")
            {
               // numero = StringResources._4Decimales;
                numero1 = "4";
            }            
            if (dudNumeroDecimal.Text == "5")
            {
               // numero = StringResources._5Decimales;
                numero1 = "5";
            }
            if (dudNumeroDecimal.Text == "6")
            {
              //  numero = StringResources._6Decimales;
                numero1 = "6";
            }
            if (dudNumeroDecimal.Text == "7")
            {
              //  numero = StringResources._7Decimales;
                numero1 = "7";
            }
            if (dudNumeroDecimal.Text == "8")
            {
              //  numero = StringResources._8Decimales;
                numero1 = "8";
            }
            if (dudNumeroDecimal.Text == "9")
            {
               // numero = StringResources._9Decimales;
                numero1 = "9";
            }
            if (dudNumeroDecimal.Text == "10")
            {
               // numero = StringResources._10Decimales;
                numero1 = "10";
            }            
            this.Close();
        }          
        public void Validar()
        {
            if (frmPropiedadesSistema.Decimal == "1")
            {                
                dudNumeroDecimal.SelectedIndex = 0;
            }
            else if (frmPropiedadesSistema.Decimal == "2")
            {
                dudNumeroDecimal.SelectedIndex = 1;
            }
            else if (frmPropiedadesSistema.Decimal == "3")
            {
                dudNumeroDecimal.SelectedIndex = 2;
            }
            else if (frmPropiedadesSistema.Decimal == "4")
            {
                dudNumeroDecimal.SelectedIndex = 3;
            }
            else if (frmPropiedadesSistema.Decimal == "5")
            {
                dudNumeroDecimal.SelectedIndex = 4;
            }
            else if (frmPropiedadesSistema.Decimal == "6")
            {
                dudNumeroDecimal.SelectedIndex = 5;
            }
            else if (frmPropiedadesSistema.Decimal == "7")
            {
                dudNumeroDecimal.SelectedIndex = 6;
            }
            else if (frmPropiedadesSistema.Decimal == "8")
            {
                dudNumeroDecimal.SelectedIndex = 7;
            }
            else if (frmPropiedadesSistema.Decimal == "9")
            {
                dudNumeroDecimal.SelectedIndex = 8;
            }
            else if (frmPropiedadesSistema.Decimal == "9")
            {
                dudNumeroDecimal.SelectedIndex = 8;
            }
            else if (frmPropiedadesSistema.Decimal == "10")
            {
                dudNumeroDecimal.SelectedIndex = 9;
            }
        }
        public void AplicarIdioma()
        {
            ////Titulos
            //this.lblTitulo.Text = StringResources.DecimalesConfigurar;
            //this.Text = StringResources.DecimalesConfigurar;
            ////Labels
            //this.lblConfigurarNumeros.Text = StringResources.ConfiguracionNumero;
            ////Buttons
            //this.btoGuardar.Text = StringResources.Guardar;
        }
    }
}
