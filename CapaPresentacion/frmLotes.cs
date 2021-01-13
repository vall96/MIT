using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using CapaLogicaNegocios;
using CultureResources;

namespace CapaPresentacion
{
    public partial class frmLotes : Form
    {
        clsEmpresa EMP = new clsEmpresa();

        DateTime FechaVencimiento = DateTime.Now;
        DataTable dtLote = new DataTable();

        public string mensajeText = "", mensajeCaption = "", tipoPais = "";
        string nroLot;
        int j = 0;

        public frmLotes()
        {
            InitializeComponent();
        }
        private void frmLotes_Load(object sender, EventArgs e)
        {
           
        }

        public void Datos()
        {
            nroLot = txtNroLote.Text;
            FechaVencimiento = dtpFechaVencimiento.Value.Date;
        }       

        private void btoSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpFechaVencimiento_ValueChanged(object sender, EventArgs e)
        {
            FechaVencimiento = dtpFechaVencimiento.Value.Date;
        }

        //private void ConstruccionDtLotes()
        //{
        //    dtLote.Rows.Clear();
        //    dtLote.Columns.Clear();
        //    dtLote.Columns.Add("lot_coArt", Type.GetType("System.String"));
        //    dtLote.Columns.Add("lot_nroLote", Type.GetType("System.String"));
        //    dtLote.Columns.Add("lot_fecVencimiento", Type.GetType("System.String"));
        //}

        private void btoAceptar_Click(object sender, EventArgs e)
        {
            //ConstruccionDtLotes();

            //for (int i = 0; i < VentInventario.posPr; i++)
            //{
            //    dtLote.Rows.Add();
            //    dtLote.Rows[j]["lot_coArt"]     =  VentInventario.CodArt;
            //    dtLote.Rows[j]["lot_nroLote"]   = txtNroLote.Text ;
            //    dtLote.Rows[j]["lot_fecVencimiento"] = dtpFechaVencimiento.Value ;
            //}
        }

    public void AplicarIdioma()
        {

        }


    }
}
