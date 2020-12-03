using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogicaNegocios;
using System.Threading;
using CultureResources;
using System.Globalization;
namespace CapaPresentacion
{
    public partial class FrmTbOrdenProduccion : Form
    {
        public clsEmpresa emp = new clsEmpresa();
        DataTable dt = new DataTable();
        ListViewItem lvrow;
        public string[,] datos = new string[1, 15];
        public delegate void pasar(string[,] dato);
        public event pasar pasado;
        int pos = 0, pos2 = 0, i = 0, count = 0, linea = 0, linea2 = 0, valor = 0, a = 0;
        public string tipoPais = "", mensajeText = "", mensajeCaption = "", id = "", descrip = "",
        estado = "";

        private void lstvOrdenProduccion_DoubleClick(object sender, EventArgs e)
        {
            datosseleccionados();
        }

        public static string validar = "";
        private void FrmTbOrdenProduccion_Load(object sender, EventArgs e)
        {

        }

        public static string tipopais = "", IdOrden = "", Unidado = "", Unidadc = "", DescripcionOrden = "", IdCedula = "", FechaCreacion = "",
            FechaInicio = "", FechaFin = "", Prioridad = "", Status = "", CostoEst = "", Canpt = "", Orden = "", CodProduc = "";

        private void btoAceptar_Click(object sender, EventArgs e)
        {
            if (lstvOrdenProduccion.SelectedItems.Count > 0)
            {
                datosseleccionados();
            }
            else if (estado == "buscar")
            {
                Orden = "valido";

            }
        }
        private void lstvOrdenProduccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btoSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }       
        public FrmTbOrdenProduccion()
        {
            InitializeComponent();
            frmPrincipal.nombreBD = "Digitel";
            CargarlstvOrden();
        }
        public void LimpiarCajas()
        {
            txtCodigo.Text = "";
            txtDescrip.Text = "";
        }
        public void CargarlstvOrden()
        {
            this.lstvOrdenProduccion.Items.Clear();
            dt = emp.Listar_OrdenProduccion(frmPrincipal.nombreBD);
            for (i = 0; i < dt.Rows.Count; i++)
            {
                lvrow = new ListViewItem(dt.Rows[i]["OrdProd_Cod"].ToString().Trim());
                lvrow.SubItems.Add(dt.Rows[i]["OrdProd_desc"].ToString().Trim());
                lvrow.SubItems.Add(dt.Rows[i]["OrdProd_status"].ToString().Trim());
                lvrow.SubItems.Add(dt.Rows[i]["OrdProd_CodCed"].ToString().Trim());
                lvrow.SubItems.Add(dt.Rows[i]["OrdProd_CodProd"].ToString().Trim());
                lvrow.SubItems.Add(dt.Rows[i]["OrdProd_FechaCrea"].ToString().Trim());
                lvrow.SubItems.Add(dt.Rows[i]["OrdProd_FechaInicio"].ToString().Trim());
                lvrow.SubItems.Add(dt.Rows[i]["OrdProd_FechaFin"].ToString().Trim());
                lvrow.SubItems.Add(dt.Rows[i]["OrdProd_Prioridad"].ToString().Trim());
                lvrow.SubItems.Add(dt.Rows[i]["OrdProd_CostoEst"].ToString().Trim());
                lvrow.SubItems.Add(dt.Rows[i]["OrdProd_Canpt"].ToString().Trim());
                lvrow.SubItems.Add(dt.Rows[i]["OrdProd_UniOrd"].ToString().Trim());
                lvrow.SubItems.Add(dt.Rows[i]["OrdProd_UniCed"].ToString().Trim());
                this.lstvOrdenProduccion.Items.Add(lvrow);
            }
        }
        private void datosseleccionados()
        {
            validar = "valido";
            if (lstvOrdenProduccion.SelectedItems.Count > 0)
            {
                IdOrden = lstvOrdenProduccion.SelectedItems[0].Text;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (IdOrden == dt.Rows[i]["OrdProd_Cod"].ToString())
                    {
                        datos[0, 1] = IdOrden;
                        datos[0, 2] = dt.Rows[i]["OrdProd_desc"].ToString();
                        datos[0, 3] = dt.Rows[i]["OrdProd_status"].ToString();
                        datos[0, 4] = dt.Rows[i]["OrdProd_CodCed"].ToString();
                        datos[0, 5] = dt.Rows[i]["OrdProd_FechaCrea"].ToString();
                        datos[0, 6] = dt.Rows[i]["OrdProd_FechaInicio"].ToString();
                        datos[0, 7] = dt.Rows[i]["OrdProd_FechaFin"].ToString();
                        datos[0, 8] = dt.Rows[i]["OrdProd_Prioridad"].ToString();
                        datos[0, 9] = dt.Rows[i]["OrdProd_CostoEst"].ToString();
                        datos[0, 10] = dt.Rows[i]["OrdProd_Canpt"].ToString();
                        datos[0, 11] = dt.Rows[i]["OrdProd_UniOrd"].ToString();
                        datos[0, 12] = dt.Rows[i]["OrdProd_UniCed"].ToString();
                        datos[0,13]= dt.Rows[i]["OrdProd_CodProd"].ToString();
                        pasado(datos);
                    }
                }
                this.Hide();
            }
            else { return; }
        }
        public void ValidarOrden(string id, string descripcion, string buscar)
        {
            string palabra = "";
            Orden = "";
            if (id != "")
            {
                for (int i = pos; i < lstvOrdenProduccion.Items.Count; i++)
                {
                    palabra = lstvOrdenProduccion.Items[i].SubItems[0].Text.ToLower();
                    bool existe = palabra.StartsWith(id.ToLower());
                    linea = i;
                    if (existe == true)
                    {
                        a = i;
                        Orden = "valido";
                        IdOrden = lstvOrdenProduccion.Items[a].SubItems[0].Text.ToString().Trim();
                        DescripcionOrden = lstvOrdenProduccion.Items[a].SubItems[1].Text.ToString().Trim();
                        Status = lstvOrdenProduccion.Items[a].SubItems[2].Text.ToString().Trim();
                        IdCedula = lstvOrdenProduccion.Items[a].SubItems[3].Text.ToString().Trim();
                        CodProduc = lstvOrdenProduccion.Items[a].SubItems[4].Text.ToString().Trim();
                        FechaCreacion = lstvOrdenProduccion.Items[a].SubItems[5].Text.ToString().Trim();
                        FechaInicio = lstvOrdenProduccion.Items[a].SubItems[6].Text.ToString().Trim();
                        FechaFin = lstvOrdenProduccion.Items[a].SubItems[7].Text.ToString().Trim();
                        Prioridad = lstvOrdenProduccion.Items[a].SubItems[8].Text.ToString().Trim();
                        CostoEst = lstvOrdenProduccion.Items[a].SubItems[9].Text.ToString().Trim();
                        Canpt = lstvOrdenProduccion.Items[a].SubItems[10].Text.ToString().Trim();
                        Unidado = lstvOrdenProduccion.Items[a].SubItems[11].Text.ToString().Trim();
                        Unidadc = lstvOrdenProduccion.Items[a].SubItems[12].Text.ToString().Trim();
                        lstvOrdenProduccion.Items[a].SubItems[0].BackColor = Color.LightSeaGreen;
                        pos = a;
                        return;
                    }
                }
            }
            else
            {
                if (descripcion != "")
                {
                    for (int i = pos2; i < lstvOrdenProduccion.Items.Count; i++)
                    {
                        palabra = lstvOrdenProduccion.Items[i].SubItems[1].Text.ToLower();
                        bool existe = palabra.StartsWith(id.ToLower());
                        linea2 = i;
                        if (existe == true)
                        {
                            a = i;
                            Orden = "valido";
                            IdOrden = lstvOrdenProduccion.Items[a].SubItems[0].Text.ToString().Trim();
                            DescripcionOrden = lstvOrdenProduccion.Items[a].SubItems[1].Text.ToString().Trim();
                            Status = lstvOrdenProduccion.Items[a].SubItems[2].Text.ToString().Trim();
                            IdCedula = lstvOrdenProduccion.Items[a].SubItems[3].Text.ToString().Trim();
                            CodProduc = lstvOrdenProduccion.Items[a].SubItems[4].Text.ToString().Trim();
                            FechaCreacion = lstvOrdenProduccion.Items[a].SubItems[5].Text.ToString().Trim();
                            FechaInicio = lstvOrdenProduccion.Items[a].SubItems[6].Text.ToString().Trim();
                            FechaFin = lstvOrdenProduccion.Items[a].SubItems[7].Text.ToString().Trim();
                            Prioridad = lstvOrdenProduccion.Items[a].SubItems[8].Text.ToString().Trim();
                            CostoEst = lstvOrdenProduccion.Items[a].SubItems[9].Text.ToString().Trim();
                            Canpt = lstvOrdenProduccion.Items[a].SubItems[10].Text.ToString().Trim();
                            Unidado = lstvOrdenProduccion.Items[a].SubItems[11].Text.ToString().Trim();
                            Unidadc = lstvOrdenProduccion.Items[a].SubItems[12].Text.ToString().Trim();
                            lstvOrdenProduccion.Items[a].SubItems[0].BackColor = Color.LightSeaGreen;
                            pos2 = a;
                            return;
                        }
                    }
                }
            }
            if (Orden != "valido")
            {
                if (pos2 == 0)
                {
                    valor = 1;
                }
            }
        }
        public void funcionBuscar()
        {
            lstvOrdenProduccion.Items[linea].SubItems[0].BackColor = Color.White;
            lstvOrdenProduccion.Items[linea2].SubItems[0].BackColor = Color.White;
            estado = "buscar";
            if (txtCodigo.Text == "" && txtDescrip.Text == "")
            {
                return;
            }
            else
            {
                if (txtCodigo.Text != "" && txtDescrip.Text != "")
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
                    mensajeText = StringResources.No_se_puede_realizar_la_busqueda_con_todos_los_campos_llenos;
                    mensajeText = StringResources.ErrordeValidacion;

                    MessageBox.Show(mensajeText, mensajeCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                    this.txtCodigo.Focus();
                    return;
                }
            }
            if (txtCodigo.Text != "")
            {
                id = txtCodigo.Text;
                descrip = "";
                ValidarOrden(id, descrip, "buscar");
                LimpiarCajas();
            }
            else
            {
                if (txtDescrip.Text != "")
                {
                    id = "";
                    descrip = txtDescrip.Text;
                    ValidarOrden(id, descrip, "buscar");
                    pos2++;
                    LimpiarCajas();
                }
            }
            if (Orden == "valido")
            {
                lstvOrdenProduccion.Items[pos].Selected = true;
                lstvOrdenProduccion.Items[pos].Selected = true;
                lstvOrdenProduccion.EnsureVisible(pos);
            }
            else
            {
                if (valor != 1)
                {
                    pos = 0;
                    pos2 = 0;
                    MessageBox.Show("Ya no hay más registros", "Ya no hay más registros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (valor == 1)
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
                    mensajeText = StringResources.NoSeEncontroInformacion;
                    mensajeCaption = StringResources.ErrordeValidacion;

                    MessageBox.Show(mensajeText, mensajeCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                    this.txtCodigo.Focus();
                    LimpiarCajas();
                }
            }

        }
    }
}
