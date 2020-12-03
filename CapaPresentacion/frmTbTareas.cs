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
using System.Windows.Threading;

namespace CapaPresentacion
{
    public partial class frmTbTareas : Form
    {
        public frmTbTareas()
        {
            InitializeComponent();
            tipoPais = frmRegristroUsuario.tipoPais;
            cargarLista();
        }
        private void frmTbTareas_Load(object sender, EventArgs e)
        {
            lsvTareas.Items.Clear();
            cargarlsv();
            VenTareas = new frmTareas();

            if (frmCedulaDeProducto.accion == "inicio")
            {
                lsvTareas.CheckBoxes = false;
            }
            if (frmCedulaDeProducto.valido == "si")
            {
                lsvTareas.CheckBoxes = true;
            }
            else
            {
                lsvTareas.CheckBoxes = false;
            }

        }
        //------------------------------------------------------------------------------------------------
        clsEmpresa M = new clsEmpresa();
        public static string estado = "";
        public static string _Codigo, _Descripcion;
        int pos = 0;
        public string cod, des, mensajeText, mensajeCaption, tipoPais = "";
        DataTable dt = new DataTable();
        ListViewItem lvrow;
        public delegate void pasar(string[,] dato);
        public event pasar pasado;
        public string[,] datos = new string[1, 4];
        public delegate void relacion(DataTable dtTareas);
        public event relacion DtRelTbTareas;
        frmTareas VenTareas;
        public string codTarea;
        DataTable dtTareas;
        int j = 0, num_usuarios;
        //------------------------------------------------------------------------------------------------------
        private void lsvTareas_DoubleClick(object sender, EventArgs e)
        {
            datosSeleccionados();
            this.Hide();
        }
        private void btoAceptar_Click(object sender, EventArgs e)
        {
            if (lsvTareas.SelectedItems.Count > 0)
            {
                if (lsvTareas.CheckBoxes == false)
                {
                    datosSeleccionados();
                    this.Hide();
                }
            }
            if (frmCedulaDeProducto.valido == "si")
            {
                TareasSeleccion();
                this.Hide();
            }
            else
            {
                this.Close();
            }
            frmCedulaDeProducto.valido = "no";
        }
        private void btoSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btoBuscar_Click(object sender, EventArgs e)
        {
            FuncionBuscar();
        }

        //-----------------------------------------------------------------------------------------------------
        private void TareasSeleccion()
        {
            j = 0;
            ConstruccionDt();
            for (int i = 0; i < lsvTareas.Items.Count; i++)
            {
                if (lsvTareas.Items[i].Checked == true)
                {
                    dtTareas.Rows.Add();
                    dtTareas.Rows[j]["codigo"] = lsvTareas.Items[i].SubItems[0].Text;
                    dtTareas.Rows[j]["descripcion"] = lsvTareas.Items[i].SubItems[1].Text;
                    j++;
                }
            }
            DtRelTbTareas(dtTareas);
        }
        private void cargarLista()
        {
            dt = M.listarTareas(frmPrincipal.nombreBD);
        }

        //-----------------------------------------------------------------------------------------------------
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionBuscar();
        }
        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            FuncionBuscar();
        }
        //----------------------------------------------------------------------------------------------------
        private void cargarlsv()
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lvrow = new ListViewItem(dt.Rows[i]["Tareas_Id"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["Tareas_Descripcion"].ToString());
                this.lsvTareas.Items.Add(lvrow);
            }
            FiltrarDatos();
        }

        string CodTar = "";
        private void FiltrarDatos()
        {
            if (frmCedulaDeProducto.valido == "si")
            {
                if (frmCedulaDeProducto.cont != 0)
                {
                    for (int a = 0; a < frmCedulaDeProducto.DtActualTar.Rows.Count; a++)
                    {
                        CodTar = frmCedulaDeProducto.DtActualTar.Rows[a]["TareaId"].ToString();
                        Actualizarlsv();
                    }
                }
            }
        }

        private void Actualizarlsv()
        {
            for (int i = 0; i < lsvTareas.Items.Count; i++)
            {
                if (CodTar == lsvTareas.Items[i].SubItems[0].Text.ToString())
                {
                    lsvTareas.Items.RemoveAt(i);
                    return;
                }
            }
        }

        private void datosSeleccionados()
        {
            if (lsvTareas.SelectedItems.Count > 0)
            {
                _Codigo = lsvTareas.SelectedItems[0].Text.ToString().Trim();
                _Descripcion = lsvTareas.SelectedItems[0].SubItems[1].Text.ToString().Trim();

                datos[0, 0] = _Codigo;
                datos[0, 1] = _Descripcion;
                estado = "valido";
                pasado(datos);

            }
        }

        private void lsvTareas_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if(lsvTareas.Sorting == SortOrder.Descending)
            {
                lsvTareas.Sorting = SortOrder.Ascending;
                lsvTareas.Sort();
            }
            else
            {
                lsvTareas.Sorting = SortOrder.Descending;
                lsvTareas.Sort();
            }
        }

        private void LimpiarCajas()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
        }
        private void FuncionBuscar()
        {
            estado = "buscar";
            if (txtCodigo.Text == "" && txtDescripcion.Text == "")
            {
                return;
            }
            else if (txtCodigo.Text != "" && txtDescripcion.Text != "")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.No_se_puede_realizar_la_busqueda_con_todos_los_campos_llenos;
                mensajeCaption = StringResources.ErrordeValidacion;

                MessageBox.Show(mensajeText, mensajeCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                this.txtCodigo.Focus();
                return;
            }
            else
            {
                if (txtCodigo.Text != "")
                {
                    cod = txtCodigo.Text;
                    des = "";
                    ValidarBuscar(cod, des);
                }
                else
                {
                    cod = "";
                    des = txtDescripcion.Text;
                    ValidarBuscar(cod, des);
                }
            }
            if (estado == "Valido")
            {
                // venMaquinas.cargarDatos();
                lsvTareas.Items[pos].Selected = true;
                lsvTareas.Items[pos].Focused = true;
                lsvTareas.EnsureVisible(pos);
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.NoSeEncontroInformacion;
                mensajeCaption = StringResources.ErrordeValidacion;

                MessageBox.Show(mensajeText, mensajeCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                this.txtCodigo.Focus();
                // LimpiarCajas();
            }
        }
        public void ValidarBuscar(string CodigoP, string DescP)
        {
            lsvTareas.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;

            string palabra = "";
            estado = "";
            if (CodigoP != "")
            {
                for (int i = 0; i < lsvTareas.Items.Count; i++)
                {
                    palabra = lsvTareas.Items[i].SubItems[0].Text.ToLower();
                    bool existe = palabra.StartsWith(CodigoP.ToLower());

                    if (existe == true)
                    {
                        estado = "Valido";
                        _Codigo = lsvTareas.Items[i].SubItems[0].Text.ToString().Trim();
                        _Descripcion = lsvTareas.Items[i].SubItems[1].Text.ToString().Trim();
                        lsvTareas.Items[i].SubItems[0].BackColor = Color.LightSeaGreen;
                        pos = i;
                        return;
                    }

                }
            }
            else if (DescP != "")
            {
                for (int i = 0; i < lsvTareas.Items.Count; i++)
                {
                    palabra = lsvTareas.Items[i].SubItems[1].Text.ToLower();
                    bool existe = palabra.StartsWith(DescP.ToLower());

                    if (existe == true)
                    {
                        estado = "Valido";
                        _Codigo = lsvTareas.Items[i].SubItems[0].Text.ToString().Trim();
                        _Descripcion = lsvTareas.Items[i].SubItems[1].Text.ToString().Trim();
                        lsvTareas.Items[i].SubItems[0].BackColor = Color.LightSeaGreen;
                        pos = i;
                        return;
                    }
                }
            }
        }
        private void ConstruccionDt()
        {
            dtTareas = new DataTable();
            dtTareas.Columns.Add("codigo", Type.GetType("System.String"));
            dtTareas.Columns.Add("descripcion", Type.GetType("System.String"));
        }
        private void TareasSeleccionadas()
        {
            j = 0;
            ConstruccionDt();
            for (int i = 0; i < lsvTareas.Items.Count; i++)
            {
                if (lsvTareas.Items[i].Checked == true)
                {
                    dtTareas.Rows.Add();
                    dtTareas.Rows[j]["codigo"] = lsvTareas.Items[i].SubItems[0].Text;
                    dtTareas.Rows[j]["descripcion"] = lsvTareas.Items[i].SubItems[1].Text;
                    j++;
                }
            }
            DtRelTbTareas(dtTareas);
        }
        public void ActualizarLista(string accion)
        {
            switch (accion)
            {
                //case "agregar":
                //    lvrow = new ListViewItem(frmTareas.codigo.ToString().Trim());
                //    lvrow.SubItems.Add(frmTareas.descripcion.ToString().Trim());
                //    lsvTareas.Items.Add(lvrow);
                //    num_usuarios++;
                //    break;

                //case "editar":
                //    lsvTareas.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
                //    lsvTareas.Items[pos].SubItems[1].Text = frmTareas.codigo.ToString().Trim();
                //    lsvTareas.Items[pos].SubItems[2].Text = frmTareas.descripcion.ToString().Trim();
                //    break;

                //case "eliminar":
                //    break;
            }

        }
    }
}
