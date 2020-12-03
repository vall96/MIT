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
    public partial class frmTbMaquinas : Form
    {
        ListViewItem lvrow;
        DataTable dt = new DataTable();
        clsEmpresa M = new clsEmpresa();

        public delegate void pasar(string[,] dato);
        public event pasar pasado;
        public delegate void relacion(DataTable dtMaquina);
        public event relacion dtRelMaquinas;
        public string[,] datos = new string[1, 8];
        DataTable dtMaquinas;
        //---------------------------------------------------------
        int num_usuarios, pos = 0, j;
        //---------------------------------------------------------
        public static string Validar = "" , _Codigo, _Descripcion;
        public static string estado = "", tipoPais = "";
        //----------------------------------------------------------
        public string cod, des, mensajeText, mensajeCaption,codMaq;
        frmMaquinas venMaquinas;

        public frmTbMaquinas()
        {
            InitializeComponent();
            CargarLista();
            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();
        }
        //------------------------------------------------------------------------------------
        private void frmTbMaquinas_Load(object sender, EventArgs e)
        {
            venMaquinas = new frmMaquinas();
            if (frmTareas.valido=="si")
            {
                lsvMaquina.CheckBoxes = true;
            }
            else
            {
                lsvMaquina.CheckBoxes = false;
            }
            CargarListview();
        }
        private void CargarLista()
        {
            dt = M.ListadoMaquinas(frmPrincipal.nombreBD);
        }

        private void CargarListview()
        {
           
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                lvrow = new ListViewItem(dt.Rows[i]["Maq_id"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["Maq_descripcion"].ToString());
                this.lsvMaquina.Items.Add(lvrow);
            }
            FiltrarDatos();
        }
        private void FiltrarDatos()
        {
            if (frmTareas.valido == "si")
            {
                if (frmTareas.cont != 0)
                {
                    for (int a = 0; a < frmTareas.DtActualTar.Rows.Count; a++)
                    {
                        codMaq= frmTareas.DtActualTar.Rows[a]["MaqId"].ToString();
                        Actualizarlsv();
                    }
                }
            }
        }
        private void Actualizarlsv()
        {
            for (int i = 0; i < lsvMaquina.Items.Count; i++)
            {
                if (codMaq == lsvMaquina.Items[i].SubItems[0].Text.ToString())
                {
                    lsvMaquina.Items.RemoveAt(i);
                    return;
                }
            }
        }


        private void btoAceptar_Click(object sender, EventArgs e)
        {
            if (lsvMaquina.SelectedItems.Count > 0)
            {
                datosSeleccionados();
                this.Hide();
            }  
            else if (frmTareas.valido=="si")
            {
                MaquinasSeleccionadas();
                this.Hide();
            }
            else 
            {
                this.Close();
            }
            frmTareas.valido = "no";
        }

        private void btoSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lsvMaquina_DoubleClick(object sender, EventArgs e)
        {
            datosSeleccionados();
        }

        //-------------------------- KeyPress -----------------------------
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                lsvMaquina.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
                FuncionBuscar();
            }
            else if ((e.KeyChar >= 48 && e.KeyChar <= 57) || (e.KeyChar >= 97 && e.KeyChar <= 122) || (e.KeyChar >= 65 && e.KeyChar <= 90) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                lsvMaquina.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
                FuncionBuscar();
            }
        }

        private void datosSeleccionados()
        {
            if(frmTareas.valido != "si")
            {
                if (lsvMaquina.SelectedItems.Count > 0)
                {
                    _Codigo = lsvMaquina.SelectedItems[0].Text.ToString().Trim();
                    _Descripcion = lsvMaquina.SelectedItems[0].SubItems[1].Text.ToString().Trim();

                    datos[0, 0] = _Codigo;
                    datos[0, 1] = _Descripcion;
                    pasado(datos);
                    estado = "valido";

                }
            }
        }
        private void ConstruccionDt()
        {
            dtMaquinas = new DataTable();
            dtMaquinas.Columns.Add("codigo", Type.GetType("System.String"));
            dtMaquinas.Columns.Add("descripcion", Type.GetType("System.String"));
        }
        private void MaquinasSeleccionadas()
        {
            j = 0;
            ConstruccionDt();
            for (int i = 0; i < lsvMaquina.Items.Count; i++)
            {
                if (lsvMaquina.Items[i].Checked == true)
                {
                    dtMaquinas.Rows.Add();
                    dtMaquinas.Rows[j]["codigo"]= lsvMaquina.Items[i].SubItems[0].Text;
                    dtMaquinas.Rows[j]["descripcion"] = lsvMaquina.Items[i].SubItems[1].Text;                  
                    j++;
                }
            }
            dtRelMaquinas(dtMaquinas);
        }

        private void lsvMaquina_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lsvMaquina.Sorting == SortOrder.Ascending)
            {
                lsvMaquina.Sorting = SortOrder.Descending;
                lsvMaquina.Sort();
            }
            else
            {
                lsvMaquina.Sorting = SortOrder.Ascending;
                lsvMaquina.Sort();
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btoBuscar_Click(object sender, EventArgs e)
        {
            FuncionBuscar();
        }

        public void ActualizarLista(string accion)
        {
            switch (accion)
            {
                case "agregar":
                    lvrow = new ListViewItem(frmMaquinas.codigo.ToString().Trim());
                    lvrow.SubItems.Add(frmMaquinas.descripcion.ToString().Trim());
                    lsvMaquina.Items.Add(lvrow);
                    num_usuarios++;
                    break;

                case "editar":
                    lsvMaquina.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
                    lsvMaquina.Items[pos].SubItems[1].Text = frmMaquinas.codigo.ToString().Trim();
                    lsvMaquina.Items[pos].SubItems[2].Text = frmMaquinas.descripcion.ToString().Trim();
                    break;

                case "eliminar":
                    break;


            }

        }
        public void validar_Buscar(string Codigo, string Descripcion)
        {
            string palabra = "";
            Validar = "";
            if (Codigo != "")
            {
                for (int i = 0; i < lsvMaquina.Items.Count; i++)
                {
                    palabra = lsvMaquina.Items[i].SubItems[0].Text.ToLower();
                    bool existe = palabra.StartsWith(Codigo.ToLower());

                    if(existe == true)
                    {
                        Validar = "Valido";
                        _Codigo = lsvMaquina.Items[i].SubItems[0].Text.ToString().Trim();
                        _Descripcion = lsvMaquina.Items[i].SubItems[1].Text.ToString().Trim();
                        lsvMaquina.Items[i].SubItems[0].BackColor = Color.LightSeaGreen;
                        pos = i;
                        return;
                    }
                }
            }
            else if (Descripcion != "")
            {
                for (int i = 0; i < lsvMaquina.Items.Count; i++)
                {
                    palabra = lsvMaquina.Items[i].SubItems[0].Text.ToLower();
                    bool existe = palabra.StartsWith(Codigo.ToLower());

                    if (existe == true)
                    {
                        Validar = "Valido";
                        _Codigo = lsvMaquina.Items[i].SubItems[0].Text.ToString().Trim();
                        _Descripcion = lsvMaquina.Items[i].SubItems[1].Text.ToString().Trim();
                        lsvMaquina.Items[i].SubItems[0].BackColor = Color.LightSeaGreen;
                        pos = i;
                        return;
                    }
                }
            }

        }
        public void AplicarIdioma()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
            this.lblTituloPanel.Text = StringResources.Maquinas;
            //
            this.Text = StringResources.Maquinas;
            //
            this.lblCodigo.Text = StringResources.Codigo;
            this.lblDescripcion.Text = StringResources.Descripcion;
            //
            this.btoAceptar.Text = StringResources.btoAceptar;
            this.btoBuscar.Text = StringResources.btnBuscar;
            this.btoSalir.Text = StringResources.btnSalir;
            //
            this.codigo.Text = StringResources.Codigo;
            this.descripcion.Text = StringResources.Descripcion;
        }

        //------------------------------------Tabla------------------------------------------
        public void FuncionInicio()
        {
            if (lsvMaquina.Items.Count == 0)
            {
                this.txtCodigo.Enabled = false;
                this.txtDescripcion.Enabled = false;
            }
        }
        public void FuncionBuscar()
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
                    LimpiarCajas();
                }
                else
                {
                    cod = "";
                    des = txtDescripcion.Text;
                    ValidarBuscar(cod, des);
                    LimpiarCajas();
                }
                if (frmTbMaquinas.estado == "Valido")
                {
                    venMaquinas.cargarDatos();
                    lsvMaquina.Items[pos].Selected = true;
                    lsvMaquina.Items[pos].Focused = true;
                    lsvMaquina.EnsureVisible(pos);
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
                    LimpiarCajas();
                }
            }
        }

        private void LimpiarCajas()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
        }

        public void ValidarBuscar(string CodigoP, string DescP)
        {
            if (lsvMaquina.Items.Count!=0)
            {
                lsvMaquina.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
            }
            string palabra = "";
            estado = "";
            if (CodigoP != "")
           {
                for (int i = 0; i < lsvMaquina.Items.Count; i++)
                {
                    palabra = lsvMaquina.Items[i].SubItems[0].Text.ToLower();
                    bool existe = palabra.StartsWith(CodigoP.ToLower());

                    if (existe == true)
                    {
                        estado = "Valido";
                        _Codigo = lsvMaquina.Items[i].SubItems[0].Text.ToString().Trim();
                        _Descripcion = lsvMaquina.Items[i].SubItems[1].Text.ToString().Trim();
                        lsvMaquina.Items[i].SubItems[0].BackColor = Color.LightSeaGreen;
                        pos = i;
                        return;
                    }

                }
            }
            else if (DescP != "")
            {
                for (int i = 0; i < lsvMaquina.Items.Count; i++)
                {
                    palabra = lsvMaquina.Items[i].SubItems[1].Text.ToLower();
                    bool existe = palabra.StartsWith(DescP.ToLower());

                    if (existe == true)
                    {
                        estado = "Valido";
                        _Codigo = lsvMaquina.Items[i].SubItems[0].Text.ToString().Trim();
                        _Descripcion = lsvMaquina.Items[i].SubItems[1].Text.ToString().Trim();
                        lsvMaquina.Items[i].SubItems[0].BackColor = Color.LightSeaGreen;
                        pos = i;
                        return;
                    }
                }
            }
        }



    }
}
