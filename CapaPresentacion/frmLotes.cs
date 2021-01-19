using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using CapaLogicaNegocios;
using CultureResources;
using static CapaPresentacion.frmMovDeInventario;

namespace CapaPresentacion
{
    public partial class frmLotes : Form
    {
        clsEmpresa EMP = new clsEmpresa();
        DateTime FechaVencimiento = DateTime.Now;
        DataTable dtLote = new DataTable();

        public string mensajeText = "", mensajeCaption = "", tipoPais = "";
        string msj = "";


        public frmLotes()
        {
            InitializeComponent();
            if (frmMovDeInventario.valido == "sin-lote")
            {
                MessageBox.Show("este articulo no trabaja con lotes", "Validacion de campos" );
                return;
            }
            else
            {
                MetodoForm1();
            }
        }
        private void frmLotes_Load(object sender, EventArgs e)
        {
           
        }
        public void MetodoForm1()
        {
         txtCodPro.Text  =  ClaseCompartida.Articulo1 ;
        }
        

        private void btoSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpFechaVencimiento_ValueChanged(object sender, EventArgs e)
        {
            FechaVencimiento = dtpFechaVencimiento.Value.Date;
        }
             
        private void btoAceptar_Click(object sender, EventArgs e)
          {
            EMP.codigo = txtCodPro.Text;
            EMP.m_NumLot = txtNroLote.Text;
            EMP.Fechas = FechaVencimiento;
            msj = EMP.NrodeLote(frmPrincipal.nombreBD);

            if (msj == "Ya existe")
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.YaExisteElRegistro;
                mensajeCaption = StringResources.Validacióndecampos;

                MessageBox.Show(mensajeText + " " + txtNroLote.Text.Trim(), mensajeCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                txtNroLote.Focus();
                return;
            }
            else
            {
                mensajeText = StringResources.DBRegistroexitoso;
                mensajeCaption = StringResources.Validacióndecampos;

                MessageBox.Show(mensajeText + " " + txtNroLote.Text.Trim(), mensajeCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

                EMP.m_Almacen = ClaseCompartida.AlmacenLote;
                EMP.m_cod = ClaseCompartida.Articulo1;
                EMP.m_NumLot = txtNroLote.Text;
                EMP.m_Cantidad = ClaseCompartida.CantidadLote;
                EMP.Fechas = FechaVencimiento;

                EMP.RegistarStLote(frmPrincipal.nombreBD);
            }
            this.Close();
        }
        
        public void AplicarIdioma()
        {

        }


    }
}
