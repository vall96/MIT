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
        //
        public string mensajeText = "", mensajeCaption = "", tipoPais = "";
        //
        public delegate void pasar(string[,] dato);
        public event pasar pasado;
        public string[,] datos = new string[1, 4];
        public delegate void relacion(DataTable dtLot);
        public event relacion relLotes;
        DataTable dt;
        //clase creada para la validacion de campos 
        public class Validar
        {
            public static void SoloLetrasyNumerosSinEspacios(KeyPressEventArgs N)
            {
                if (Char.IsLetterOrDigit(N.KeyChar))
                {
                    N.Handled = false;
                }
                else if (Char.IsControl(N.KeyChar))
                {
                    N.Handled = false;
                }
                else
                {
                    N.Handled = true;
                }
            }
        }
        //
        public frmLotes()
        {
            InitializeComponent();
            //se cargo el codigo aqui en lugar del load ya que se necesita ejecutar las acciones al momento que cargue el formulario 
            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();

            mensajeText = StringResources.SinLotes;
            mensajeCaption = StringResources.Validacióndecampos;

            if (frmMovDeInventario.valido == "sin-lote")
            {
                MessageBox.Show(mensajeText, mensajeCaption,
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            if (frmMovDeInventario.valido == "lotes-cargados")
            {
                Metodo2();
            }
        }
        private void frmLotes_Load(object sender, EventArgs e)
        {
        }
        //---------------------------------------Funciones y metodos-----------------------------
        public void Metodo2()
        {
            txtNroLote.Text = ClaseCompartida.Mov_Lote;
            dtpFechaVencimiento.Value = ClaseCompartida.Mov_FechaV;
            btoSalir.Focus();
        }
        public void CargarDatos()
        {
            int j = 0;
            if (txtNroLote.Text != "")
            {
                ConstruccionDt();
                dt.Rows.Add();
                dt.Rows[j]["lote"] = txtNroLote.Text;
                dt.Rows[j]["fechaV"] = dtpFechaVencimiento.Value;
                j++;
                relLotes(dt);
                this.Close();
            }
        }
        private void ConstruccionDt()
        {
            dt = new DataTable();
            dt.Columns.Add("lote", Type.GetType("System.String"));
            dt.Columns.Add("fechaV", Type.GetType("System.String"));
        }
        //----------------------------------------------------------------------------------------
        private void dtpFechaVencimiento_ValueChanged(object sender, EventArgs e)
        {
            FechaVencimiento = dtpFechaVencimiento.Value.Date;
        }
        //---------------------------------- EVENTOS ------------------------------------------------------
        private void btoSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btoAceptar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }
        private void frmLotes_KeyDown(object sender, KeyEventArgs e)
        {
            if (frmMovDeInventario.valido == "Nro-Lote")
            {
                CargarDatos();
                btoAceptar.Focus();
            }
            if (frmMovDeInventario.valido == "lotes-cargados")
            {
                Metodo2();
                btoSalir.Focus();
            }
        }
        private void txtNroLote_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetrasyNumerosSinEspacios(e);
        }
        //--------------------------------- IDIOMAS -------------------------------------------------------
        public void AplicarIdioma()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
            this.Text = StringResources.LotesDeEntrada;
            this.lblNroLote.Text = StringResources.NumerodeLote;
            this.lblFechaVencimiento.Text = StringResources.FechaDeVencimiento;
            this.btoAceptar.Text = StringResources.btoAceptar;
            this.btoSalir.Text = StringResources.btnSalir;
        }
    }
}
