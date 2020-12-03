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

namespace CapaPresentacion
{
    public partial class frmTbSucursales : Form
    {
        private clsEmpresa lst = new clsEmpresa();
        ListViewItem lvrow;
        DataTable dt = new DataTable();
        //---------------------------------------------------------------------------------------
        public string mensajeText = "", mensajeCaption = "";
        //---------------------------------------------------------------------
        public static string tipoPais = "", valido = "";
        public string estado = "";

        public static string
            _suc_cod = "",
            _suc_nombre = "",
            _suc_descripcion = "",
            _esuc_dir = "",
            _suc_contacto = "",
            _suc_telf1 = "",
            _suc_telf2 = "",
            _suc_mon = "",
            _suc_email = "",
            _suc_fechaCreacion = "",
            _emp_Cod = "";
        //-----------------------------------------------------------------------------
        public static int  Sucursales=0;
        public int num_sucursales, pos;
        public string codigo = "", sucursal = "", Contacto = "";
        //------------------------------------------------------------------------------
        DateTime fecha;
        //------------------------------------------------------------------------------
        public string[,] datos = new string[1, 15];
        public delegate void pasar(string[,] dato);        //firma tipo de metodo
        public event pasar pasado;
        //public event pasar relacionSucursal;
        public frmTbSucursales()
        {
            InitializeComponent();
            CargarListviewSucursales();
        }

        private void frmTbSucursales_Load(object sender, EventArgs e)
        {
           // txtEmpresa.Text=
            this.lsvSucursales.OwnerDraw = true;
            this.txtEmpresa.Text = frmSucursales.nombreBd;
            this.lsvSucursales.FullRowSelect = true;
            Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
            AplicarIdioma(); 
            funcionInicio();
            this.lsvSucursales.Enabled = false;
        }

        private void lsvSucursales_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.DarkOrange, e.Bounds);
            e.DrawText();
        }

        private void lsvSucursales_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lsvSucursales_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lsvSucursales.Sorting == SortOrder.Descending)
            {
                lsvSucursales.Sorting = SortOrder.Ascending;
                lsvSucursales.Sort();
            }
            else
            {
                lsvSucursales.Sorting = SortOrder.Descending;
                lsvSucursales.Sort();
            }
        }

        //---------------------------------------------- eventos textbox -------------------------------------------------------
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                lsvSucursales.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
                funcionbuscar();
            }
        }

        private void txtSucursal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                lsvSucursales.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
                funcionbuscar();
            }
        }

        private void txtContacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                lsvSucursales.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
                funcionbuscar();
            }
        }

        //--------------------------------------------- DATOS LISTVIEW  ----------------------------------------------------
        public void CargarListviewSucursales()
        {
           // frmSucursales.nombreBd = "tecnoRed";
            this.lsvSucursales.Items.Clear();
            dt = lst.Listado_sucursules(frmSucursales.nombreBd);
            if (dt.Rows.Count == 0)
            {
                Sucursales = 0;
                return;
            }
            else
            {
                num_sucursales = dt.Rows.Count;
                Sucursales = dt.Rows.Count;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lvrow = new ListViewItem(dt.Rows[i]["suc_cod"].ToString());
                    lvrow.SubItems.Add(dt.Rows[i]["suc_nombre"].ToString());
                    lvrow.SubItems.Add(dt.Rows[i]["suc_descripcion"].ToString());
                    lvrow.SubItems.Add(dt.Rows[i]["suc_dir"].ToString());
                    lvrow.SubItems.Add(dt.Rows[i]["suc_contacto"].ToString());
                    lvrow.SubItems.Add(dt.Rows[i]["suc_telf1"].ToString());
                    lvrow.SubItems.Add(dt.Rows[i]["suc_telf2"].ToString());
                   // lvrow.SubItems.Add(dt.Rows[i]["suc_mon"].ToString());
                    lvrow.SubItems.Add(dt.Rows[i]["suc_email"].ToString());
                    lvrow.SubItems.Add(dt.Rows[i]["suc_fechaCreacion"].ToString());
                    //lvrow.SubItems.Add(dt.Rows[i]["emp_Cod"].ToString());
                    this.lsvSucursales.Items.Add(lvrow);
                }
            }
        }
        private void DatosSeleccionado()
        {
            _suc_cod = lsvSucursales.SelectedItems[0].Text;
            _suc_nombre = lsvSucursales.SelectedItems[0].SubItems[1].Text;
            _suc_descripcion = lsvSucursales.SelectedItems[0].SubItems[2].Text;
            _esuc_dir = lsvSucursales.SelectedItems[0].SubItems[3].Text;
            _suc_contacto = lsvSucursales.SelectedItems[0].SubItems[4].Text;
            _suc_telf1 = lsvSucursales.SelectedItems[0].SubItems[5].Text;
            _suc_telf2 = lsvSucursales.SelectedItems[0].SubItems[6].Text;
          //  _suc_mon = listviewSucursales.SelectedItems[0].SubItems[7].Text;
            _suc_email = lsvSucursales.SelectedItems[0].SubItems[7].Text;
            _suc_fechaCreacion = lsvSucursales.SelectedItems[0].SubItems[8].Text;
           // _emp_Cod = listviewSucursales.SelectedItems[0].SubItems[10].Text; ;
            //----------------------------Agrega La parte que te fumaste Sara----------------------------------------
            //*****************Pasar Datos por evento ↓↓↓↓↓↓↑↑↑↑↑↑↑↑☻☻☻☻↑↑↑↑↑↑↑↑↑↓↓↓
            datos[0, 0] = _suc_cod;
            datos[0, 1] = _suc_nombre;
            datos[0, 2] = _suc_descripcion;
            datos[0, 3] = _esuc_dir;
            datos[0, 4] = _suc_contacto;
            datos[0, 5] = _suc_telf1;
            datos[0, 6] = _suc_telf2;
           // datos[0, 7] = _suc_mon;
            datos[0, 8] = _suc_email;
            datos[0, 9] = _suc_fechaCreacion;

            pasado(datos);
        }

        //--------------------------------------------- EVENTOS LISTVIEW  ----------------------------------------------------
        private void listviewSucursales_DoubleClick(object sender, EventArgs e)
        {
            DatosSeleccionado();
            this.Hide();
        }
        //-----------------------------------------------------------------------------------
        public void BuscarMoneda()
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (lsvSucursales.SelectedItems[0].Text == dt.Rows[i]["suc_cod"].ToString())
                {
                    _suc_mon = dt.Rows[i]["suc_mon"].ToString();
                    return;
                }
            }
        }
        //---------------------------------------------- FUNCIONES -----------------------------------
        public void funcionInicio()
        {
            if (lsvSucursales.Items.Count == 0)
            {
                this.txtEmpresa.Enabled = false;
                this.txtCodigo.Enabled = false;
                this.txtSucursal.Enabled = false;
                this.txtContacto.Enabled = false;
                this.btoBuscar.Enabled = false;
                this.btoAceptar.Enabled = false;
            }
        }
        private void funcionbuscar()
        {

            if (txtCodigo.Text == "" && txtSucursal.Text == "" && txtContacto.Text == "")
            {
                txtCodigo.Focus();
                return;
            }
            else if (txtCodigo.Text != "" && txtSucursal.Text != "" && txtContacto.Text != "")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.No_se_puede_realizar_la_busqueda_con_todos_los_campos_llenos;
                mensajeCaption = StringResources.ErrordeValidacion;

                MessageBox.Show(mensajeText, mensajeCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

               // this.txtCodigo.Focus();
                return;
            }
            else if (txtCodigo.Text != "")
            {
                codigo = txtCodigo.Text;
                sucursal = "";
                Contacto = "";

                validar_Buscar(codigo, sucursal, Contacto);
                LimpiarCajas();
            }
            else if (txtSucursal.Text != "")
            {
                codigo = "";
                sucursal = txtSucursal.Text;

                validar_Buscar(codigo, sucursal, Contacto);
                LimpiarCajas();
            }
            else if (txtContacto.Text != "")
            {
                codigo = "";
                sucursal = "";
                Contacto = txtContacto.Text;

                validar_Buscar(codigo, sucursal, Contacto);
                LimpiarCajas();
            }
            if (valido == "valido")
            {
                lsvSucursales.Items[pos].Selected = true;
                lsvSucursales.Items[pos].Focused = true;
                lsvSucursales.EnsureVisible(pos);
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.NoSeEncontroInformacion;
                mensajeCaption = StringResources.ErrordeValidacion;

                MessageBox.Show(mensajeText, mensajeCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                // this.txtCodigo.Focus();
                LimpiarCajas();
            }
            
        }
        public void validar_Buscar(string codigo, string sucursal, string Contacto)
        {
            valido = "";

            if (codigo != "")
            {
                num_sucursales = lsvSucursales.Items.Count;

                for (int i = 0; i < num_sucursales; i++)
                {
                    if (lsvSucursales.Items[i].SubItems[0].Text.ToLower() == codigo.ToLower())
                    {
                        valido = "valido";
                        _suc_cod = lsvSucursales.Items[i].SubItems[0].Text.ToString().Trim();
                        _suc_nombre = lsvSucursales.Items[i].SubItems[1].Text.ToString().Trim();
                        _suc_contacto = lsvSucursales.Items[i].SubItems[4].Text.ToString().Trim();

                       // _esuc_dir = listviewSucursales.Items[i].SubItems[3].Text.ToString().Trim();
                        lsvSucursales.Items[i].SubItems[0].BackColor = Color.LightSeaGreen;
                        pos = i;
                        return;
                    }
                }
            }
            else if(sucursal != "")
            {
                num_sucursales = lsvSucursales.Items.Count;

                for (int i = 0; i < num_sucursales; i++)
                {
                    if (lsvSucursales.Items[i].SubItems[1].Text.ToLower() == codigo.ToLower())
                    {
                        valido = "valido";
                        _suc_cod = lsvSucursales.Items[i].SubItems[0].Text.ToString().Trim();
                        _suc_nombre = lsvSucursales.Items[i].SubItems[1].Text.ToString().Trim();
                        _suc_contacto = lsvSucursales.Items[i].SubItems[4].Text.ToString().Trim();

                        // _esuc_dir = listviewSucursales.Items[i].SubItems[3].Text.ToString().Trim();
                        lsvSucursales.Items[i].SubItems[0].BackColor = Color.LightSeaGreen;
                        pos = i;
                        return;
                    }
                }
            }
            if (Contacto != "")
            {
                num_sucursales = lsvSucursales.Items.Count;

                for (int i = 0; i < num_sucursales; i++)
                {
                    if (lsvSucursales.Items[i].SubItems[2].Text.ToLower() == codigo.ToLower())
                    {
                        valido = "valido";
                        _suc_cod = lsvSucursales.Items[i].SubItems[0].Text.ToString().Trim();
                        _suc_nombre = lsvSucursales.Items[i].SubItems[1].Text.ToString().Trim();
                        _suc_contacto = lsvSucursales.Items[i].SubItems[4].Text.ToString().Trim();

                        // _esuc_dir = listviewSucursales.Items[i].SubItems[3].Text.ToString().Trim();
                        lsvSucursales.Items[i].SubItems[0].BackColor = Color.LightSeaGreen;
                        pos = i;

                        return;
                    }
                }
            }
        }
        public void LimpiarCajas()
        {
            codigo = "";
            sucursal = "";
            Contacto = "";
        }

        //------------------------------ btos ----------------------------------------------
        private void btoSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void btoBuscar_Click(object sender, EventArgs e)
        {
            lsvSucursales.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
            estado = "buscar";
            funcionbuscar();
        }
        private void btoAceptar_Click(object sender, EventArgs e)
        {
            if (lsvSucursales.SelectedItems.Count>0)
            {
                DatosSeleccionado();
            }
            this.Hide();
        }

        //------------------------------------- IDIOMA ---------------------------------------------
        public void AplicarIdioma()
        {
            this.codigo = StringResources.Codigo;

            //
            this.ColCodigo.Text = StringResources.Codigo;
            this.colNomSucursal.Text = StringResources.Sucursal;
            this.colDescripcion.Text = StringResources.Descripcion;
            this.colDireccion.Text = StringResources.Direccion;
            this.colContacto.Text = StringResources.Contacto;
            this.colTelf1.Text = StringResources.Telefonos;
            this.colTelf2.Text = StringResources.Telefonos;
        //    this.colMoneda.Text = StringResources.moneda;
            this.colEmail.Text = StringResources.email;
            this.colFecha.Text = StringResources.FechaCreacion;
            //
            this.lblCodigo.Text = StringResources.Codigo;
            this.lblSucursal.Text = StringResources.Sucursal;
            this.lblContacto.Text = StringResources.Contacto;
            this.lblEmpresa.Text = StringResources.Empresa;
            //
            this.lblTitulo.Text = StringResources.Sucursales;
            //
            this.Text = StringResources.Sucursales;
            //
            this.btoAceptar.Text = StringResources.btoAceptar;
            this.btoBuscar.Text = StringResources.btnBuscar;
            this.btoSalir.Text = StringResources.btnSalir;
        }
    }
}
