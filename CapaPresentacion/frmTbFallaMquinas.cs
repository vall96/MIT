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
    public partial class frmTbFallaMquinas : Form
    {
       
        public clsEmpresa emp = new clsEmpresa();
        ListViewItem lvrow;
        public string[,] datos = new string[1, 4];
        public delegate void pasar(string[,] dato);
        public event pasar pasado;
        public string tipoPais = "", mensajeText = "", mensajeCaption = "";
        public static string tipopais = "", _Descripcion = "", _Id = "", maquina = "", estado = "", id = "", descrip = "";
        int pos = 0, i = 0, count = 0,a,numid;

        private void btoBuscar_Click(object sender, EventArgs e)
        {
            FuncionBuscar();
        }

        private void frmTbFallaMquinas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FuncionBuscar();
            }
        }

        private void frmTbFallaMquinas_Load(object sender, EventArgs e)
        {
            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || (e.KeyChar >= 97 && e.KeyChar <= 122) || (e.KeyChar >= 65 && e.KeyChar <= 90) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void lstvFallasMaquinas_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lstvFallasMaquinas.Sorting == SortOrder.Ascending)
            {
                lstvFallasMaquinas.Sorting = SortOrder.Descending;
                lstvFallasMaquinas.Sort();
            }
            else
            {
                lstvFallasMaquinas.Sorting = SortOrder.Ascending;
                lstvFallasMaquinas.Sort();
            }
        }

        private void btoSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstvFallasMaquinas_DoubleClick(object sender, EventArgs e)
        {
            datosSeleccionados();
        }

        private void btoAceptar_Click(object sender, EventArgs e)
        {
            if (lstvFallasMaquinas.SelectedItems.Count > 0)
            {
                datosSeleccionados();
            }
            else if (estado == "buscar")
            {
                maquina = "Valida";
                datos[0, 0] = _Id;
                datos[0, 1] = _Descripcion;
                pasado(datos);                
                this.Hide();
            }
            else
            {
                this.Close();
            }
        }

        public frmTbFallaMquinas()
        {
            InitializeComponent();
            cargarlstvFallas();
        }

        public void limpiarcajas()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
        }
        public void cargarlstvFallas()
        {
            this.lstvFallasMaquinas.Items.Clear();
            DataTable dt = new DataTable();
            dt = emp.CargarLstv(frmPrincipal.nombreBD);
            for (i = 0; i < dt.Rows.Count; i++)
            {
                lvrow = new ListViewItem(dt.Rows[i]["FallasMaq_Id"].ToString().Trim());
                lvrow.SubItems.Add(dt.Rows[i]["FallaMaq_Descripcion"].ToString().Trim());
                this.lstvFallasMaquinas.Items.Add(lvrow);
            }
        }
        private void datosSeleccionados()
        {
            if (lstvFallasMaquinas.SelectedItems.Count > 0)
            {
                _Id = lstvFallasMaquinas.SelectedItems[0].Text;
                _Descripcion = lstvFallasMaquinas.SelectedItems[0].SubItems[1].Text;
                datos[0, 0] = _Id;
                datos[0, 1] = _Descripcion;
                pasado(datos);
                maquina = "Valida";
                this.Hide();
            }
            else { return; }
        }
        public void cargarvariable()
        {
            maquina = "Valida";
            _Id = lstvFallasMaquinas.Items[a].SubItems[0].Text.ToString().Trim();
            _Descripcion = lstvFallasMaquinas.Items[a].SubItems[1].Text.ToString().Trim();
            lstvFallasMaquinas.Items[a].SubItems[0].BackColor = Color.LightSeaGreen;
            pos = a;
        }
        public void validarmaquina(string id, string descripcion, string buscar)
        {
            lstvFallasMaquinas.Items[pos].SubItems[0].BackColor = Color.White;
            string palabra = "";
            if (id != "")
            {
                for (int i = 0; i < lstvFallasMaquinas.Items.Count; i++)
                {                    
                    palabra = lstvFallasMaquinas.Items[i].SubItems[0].Text.ToLower();
                    bool existe = palabra.StartsWith(id.ToLower());
                    if (existe == true)
                    {
                        a = i;
                        cargarvariable();
                        return;
                    }
                        
                }
            }
            else if (descripcion != "")
            {
                for (int i = 0; i < lstvFallasMaquinas.Items.Count; i++)
                {
                    palabra = lstvFallasMaquinas.Items[i].SubItems[1].Text.ToLower();
                    bool existe = palabra.StartsWith(descripcion.ToLower());
                    if (existe == true)
                    {
                        a = i;
                        cargarvariable();
                        return;
                    }
                }
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
                Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.No_se_puede_realizar_la_busqueda_con_todos_los_campos_llenos;
                mensajeText = StringResources.ErrordeValidacion;

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
                    id = txtCodigo.Text;
                    descrip = "";
                    validarmaquina(id, descrip, "buscar");
                    limpiarcajas();
                }
                else
                {
                    id = "";
                    descrip = txtDescripcion.Text;
                    validarmaquina(id, descrip, "buscar");
                    limpiarcajas();
                }
            }
            if (maquina != "Valida")
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.NoSeEncontroInformacion;
                mensajeCaption = StringResources.ErrordeValidacion;

                MessageBox.Show(mensajeText, mensajeCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                this.txtCodigo.Focus();
                limpiarcajas();
            }
        }
        public void actualizarlstv(string accion)
        {
            switch (accion)
            {
                case "agregar":
                    lvrow = new ListViewItem(frmFallasMaquinas.id);
                    lvrow.SubItems.Add(frmFallasMaquinas.descrip);
                    this.lstvFallasMaquinas.Items.Add(lvrow);
                    break;

                case "editar":
                    validarmaquina(frmFallasMaquinas.id, "", "buscar");
                    lstvFallasMaquinas.Items[pos].SubItems[0].BackColor = Color.White;
                    lstvFallasMaquinas.Items[pos].SubItems[1].Text = frmFallasMaquinas.descrip;
                    break;

                case "eliminar":
                    validarmaquina(frmFallasMaquinas.descripcion, "", "buscar");
                    lstvFallasMaquinas.Items[pos].SubItems[0].BackColor = Color.White;
                    lstvFallasMaquinas.Items.RemoveAt(pos);
                    pos = 0;
                    numid--;
                    break;
            }
        }
        //Idioma
        public void AplicarIdioma()
        {
            //titulo
            this.Text = StringResources.frmTbFallaMaquina_Titulo;
            this.lblTitulo.Text = StringResources.frmTbFallaMaquina_Titulo;
            //lbl
            this.lblCodigo.Text = StringResources.Codigo;
            this.lblDescripcion.Text = StringResources.Descripcion;
            //bto
            this.btoAceptar.Text = StringResources.btoAceptar;
            this.btoBuscar.Text = StringResources.btnBuscar;
            this.btoSalir.Text = StringResources.btnSalir;
            //lstv
            this.lstvCodigo.Text = StringResources.Codigo;
            this.lstvDescripcion.Text = StringResources.Descripcion;
        }
    }
}
