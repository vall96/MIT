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
    public partial class frmTbEmpresas : Form
    {
        private clsEmpresa lst = new clsEmpresa();
        ListViewItem lvrow;
        DataTable dt = new DataTable();
        public frmPrincipal ventPrincipal;
        //---------------------------------------------------------------------
        public string mensajeText = "", mensajeCaption = "";
        //---------------------------------------------------------------------
        public static string tipoPais = "", valido = "", existeBd = "si";
        public string estado = "";
        public static string _empr_dni = "",
            _empr_Nomb = "",
            _empr_Desc = "",
            _empr_dir = "",
            _empr_contac = "",
            _empr_telef1 = "",
            _empr_telef2 = "",
            _empr_rif = "",
            _empr_nit = "",
            _empr_moneda="",
            _empr_email = "",
            _empr_web = "",
            _empr_productoId = "",
            _empr_FechaCreacion = "",
            _empr_fax="",
            _empr_NombCorto="";
        //------------------------------------------------------------------------------
        public int num_empresas, pos, a;
        public string codigo = "", empresa = "", rif = "", direccion = "";       
        DateTime fecha;
        //------------------------------------------------------------------------------
        public string[,] datos = new string[1, 15];
        public delegate void pasar(string[,] dato);        //firma tipo de metodo
        public event pasar pasado;
        //------------------------------------------------------------------------------
        public frmTbEmpresas()
        {
            InitializeComponent();
            Cargar_listviewEmpresa();
        }
        private void frmTbEmpresas_Load(object sender, EventArgs e)
        {
            this.listviewEmpresas.FullRowSelect = true;
            listviewEmpresas.OwnerDraw = true;

            ventPrincipal = new frmPrincipal();

            funcionInicio();

            Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
            AplicarIdioma(); //falta por hacer 
        }
        //----------------------------------------------------------------------------------------------
        private void listviewEmpresas_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }
        private void listviewEmpresas_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.DarkOrange, e.Bounds);
            e.DrawText();
        }
        private void listviewEmpresas_DoubleClick(object sender, EventArgs e)
        {
            datosSeleccionados();
            this.Hide();
        }
        //------------------------------------------------EventoKeyPress------------------------------
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                listviewEmpresas.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
                funcionbuscar();
            }
        }
        private void txtEmpresa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                listviewEmpresas.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
                funcionbuscar();
            }
        }
        private void txtRif_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                listviewEmpresas.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
                funcionbuscar();
            }
        }
        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                listviewEmpresas.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
                funcionbuscar();
            }
        }
        //-------------------------------------------bto----------------------------------
        private void btoSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void btoBuscar_Click(object sender, EventArgs e)
        {
            listviewEmpresas.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
            estado = "buscar";
            funcionbuscar();
        }
        //--------------------------------------------------------------------------
        private void datosSeleccionados()
        {
            if (listviewEmpresas.SelectedItems.Count > 0)
            {
                _empr_dni = listviewEmpresas.SelectedItems[0].Text;
                _empr_NombCorto = listviewEmpresas.SelectedItems[0].SubItems[11].Text; ;
                _empr_Nomb = listviewEmpresas.SelectedItems[0].SubItems[1].Text;
                _empr_rif = listviewEmpresas.SelectedItems[0].SubItems[2].Text;
                _empr_dir = listviewEmpresas.SelectedItems[0].SubItems[3].Text;
                _empr_nit = listviewEmpresas.SelectedItems[0].SubItems[4].Text;
                _empr_telef1 = listviewEmpresas.SelectedItems[0].SubItems[5].Text;
                _empr_email = listviewEmpresas.SelectedItems[0].SubItems[6].Text;
                _empr_web = listviewEmpresas.SelectedItems[0].SubItems[7].Text;
                _empr_FechaCreacion = listviewEmpresas.SelectedItems[0].SubItems[8].Text;
                _empr_Desc = listviewEmpresas.SelectedItems[0].SubItems[9].Text;
                _empr_contac = listviewEmpresas.SelectedItems[0].SubItems[10].Text;
                //*********************VERIFICAR SI LA EMPRESA TTIENE CREADA SU BASE DE DATOS********************
                for (int i=0; i<cboEmpSinBd.Items.Count;i++)
                {
                    if (_empr_dni==cboEmpSinBd.Items[i].ToString())
                    {
                        existeBd = "no";
                       // return;
                    }
                  
                }
                //*****************Pasar Datos por evento
                datos[0, 0] = _empr_dni;
                datos[0, 1] = _empr_Nomb;
                datos[0, 2] = _empr_rif;
                datos[0, 3] = _empr_dir;
                datos[0, 4] = _empr_nit;
                datos[0, 5] = _empr_telef1;
                datos[0, 6] = _empr_email;
                datos[0, 7] = _empr_web;
                datos[0, 8] = _empr_FechaCreacion;
                datos[0, 9] = _empr_Desc;
                datos[0, 10] = _empr_contac;
                datos[0, 11] = _empr_moneda;
                datos[0, 12] = _empr_NombCorto;
                pasado(datos);
            }
            else
            {
                return;
            }
        }
        public void BuscarMoneda()
        {
            for (int i=0;i<dt.Rows.Count;i++)
            {
                if (listviewEmpresas.SelectedItems[0].Text== dt.Rows[i]["empr_dni"].ToString())
                {
                   // _empr_moneda = dt.Rows[i]["empr_moneda"].ToString();
                    //_empr_fax= dt.Rows[i]["empr_moneda"].ToString();
                    return;
                }
            }
        }
        public void Cargar_listviewEmpresa()
        {
            this.listviewEmpresas.Items.Clear();
            dt = lst.listadoEmpresa();
            num_empresas = dt.Rows.Count;
            for (int i = 0; i < num_empresas; i++)
            {
                lvrow = new ListViewItem(dt.Rows[i]["empr_dni"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["empr_nombre"].ToString());                
                lvrow.SubItems.Add(dt.Rows[i]["empr_rif"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["empr_dir"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["empr_nit"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["empr_telef1"].ToString());
               // lvrow.SubItems.Add(dt.Rows[i]["empr_telef2"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["empr_email"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["empr_web"].ToString());
               // lvrow.SubItems.Add(dt.Rows[i]["empr_productoId"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["empr_FechaCreacion"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["empr_desc"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["empr_contacto"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["empr_nombCorto"].ToString());
                this.listviewEmpresas.Items.Add(lvrow);

                if (dt.Rows[i]["empr_Bd"].ToString().Trim()=="no")
                {
                    this.cboEmpSinBd.Items.Add(dt.Rows[i]["empr_dni"].ToString());
                }
            }
        }
        //-----------------------------------------------------------------------------------
        private void funcionbuscar()
        {
            if (txtCodigo.Text == "" && txtEmpresa.Text == "" && txtDireccion.Text == "" && txtRif.Text == "")
            {
                txtCodigo.Focus();
                return;
            }
            else if (txtCodigo.Text != "" && txtEmpresa.Text != "" && txtDireccion.Text != "" && txtRif.Text != "")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.No_se_puede_realizar_la_busqueda_con_todos_los_campos_llenos;
                mensajeCaption = StringResources.ErrordeValidacion; 

                MessageBox.Show(mensajeText, mensajeCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                //MessageBox.Show("No se puede realizar la busqueda con todos los campos llenos",
                //    "Error Busqueda",
                //    MessageBoxButtons.OK,
                //    MessageBoxIcon.Error);

                this.txtCodigo.Focus();
                return;
            }
            else
            {
                if (txtCodigo.Text != "")
                {
                    codigo = txtCodigo.Text;
                    empresa = "";
                    rif = "";
                    direccion = "";
                    validar_Buscar(codigo, empresa, rif, direccion);
                    LimpiarCajas();
                }
                else if (txtEmpresa.Text != "")
                {
                    codigo = "";
                    empresa = txtEmpresa.Text;
                    rif = "";
                    direccion = "";
                    validar_Buscar(codigo, empresa, rif, direccion);

                    LimpiarCajas();
                }
                else if (txtRif.Text != "")
                {
                    codigo = "";
                    empresa = "";
                    rif = txtRif.Text;
                    direccion = "";
                    validar_Buscar(codigo, empresa, rif, direccion);
                    LimpiarCajas();
                }
                else if (txtDireccion.Text != "")
                {
                    codigo = "";
                    empresa = "";
                    rif = "";
                    direccion = txtDireccion.Text;
                    validar_Buscar(codigo, empresa, rif, direccion);
                    LimpiarCajas();
                }

                if (valido == "valido")
                {
                    listviewEmpresas.Items[pos].Selected = true;
                    listviewEmpresas.Items[pos].Focused = true;
                    listviewEmpresas.EnsureVisible(pos);
                }
                else
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    mensajeText = StringResources.NoSeEncontroInformacion;
                    mensajeCaption = StringResources.ErrordeValidacion;

                    MessageBox.Show(mensajeText, mensajeCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                    //MessageBox.Show("No se encontraron Registros con los datos suministrados","Error de Validacion",
                    //    MessageBoxButtons.OK,
                    //    MessageBoxIcon.Error);
                    this.txtCodigo.Focus();
                    LimpiarCajas();
                }
            }
        }
        public void validar_Buscar(string codigo, string empresa, string rif, string direccion)
        {
            string palabra = "";
            valido = "";

            if (codigo != "")
            {
                for (int i = 0; i < listviewEmpresas.Items.Count; i++)
                {
                    palabra = listviewEmpresas.Items[i].SubItems[0].Text.ToLower();
                    bool existe = palabra.Contains(codigo.ToLower());
                    if (existe == true)
                    {
                        a = i;
                        cargarVariables();
                        return;
                    }
                }
            }
            else if (empresa != "")
            {
                for (int i = 0; i < listviewEmpresas.Items.Count; i++)
                {
                    palabra = listviewEmpresas.Items[i].SubItems[1].Text.ToLower();
                    bool existe = palabra.Contains(empresa.ToLower());
                    if (existe == true)
                    {
                        a = i;
                        cargarVariables();
                        return;
                    }
                }
            }
            else if (rif != "")
            {
                for (int i = 0; i < listviewEmpresas.Items.Count; i++)
                {
                    palabra = listviewEmpresas.Items[i].SubItems[2].Text.ToLower();
                    bool existe = palabra.Contains(rif.ToLower());

                    if (existe == true)
                    {
                        a = i;
                        cargarVariables();
                        return;
                    }
                }
            }
            else if (direccion != "")
            {
                for (int i = 0; i < listviewEmpresas.Items.Count; i++)
                {
                    palabra = listviewEmpresas.Items[i].SubItems[3].Text.ToLower();
                    bool existe = palabra.Contains(direccion.ToLower());
                    if (existe == true)
                    {
                        a = i;
                        cargarVariables();
                        return;
                    }
                }
            }
        }
        private void cargarVariables()
        {
            valido = "valido";
            _empr_dni = listviewEmpresas.Items[a].SubItems[0].Text.ToString().Trim();
            _empr_Desc = listviewEmpresas.Items[a].SubItems[1].Text.ToString().Trim();
            _empr_rif = listviewEmpresas.Items[a].SubItems[2].Text.ToString().Trim();
            _empr_dir = listviewEmpresas.Items[a].SubItems[3].Text.ToString().Trim();
            listviewEmpresas.Items[a].SubItems[0].BackColor = Color.LightSeaGreen;
            pos = a;
            return;
        }
        //--------------------------------------------------------------------------
        private void LimpiarCajas()
        {
            txtCodigo.Text = "";
            txtEmpresa.Text = "";
            txtRif.Text = "";
            txtDireccion.Text = "";
        }
        public void funcionInicio()
        {
            if (listviewEmpresas.Items.Count == 0)
            {
                this.txtCodigo.Enabled = false;
                this.txtEmpresa.Enabled = false;
                this.txtRif.Enabled = false;
                this.txtDireccion.Enabled = false;
                this.btoBuscar.Enabled = false;
            }
        }

        //---------------------------------------- falta Idioma 31/07/2019 ------------------------------------------
        public void AplicarIdioma()
        {
            this.codigo = StringResources.Codigo;
            this.empresa = StringResources.Empresa;
            this.rif = StringResources.RIF;
            this.direccion = StringResources.Direccion;
            //
            this.colNIT.Text = StringResources.NIT;
            this.colTelf1.Text = StringResources.Telefonos;
            this.ColCodigo.Text = StringResources.Codigo;
            this.colEmpresa.Text = StringResources.Empresa;
            this.colRIF.Text = StringResources.RIF;
            this.colDireccion.Text = StringResources.Direccion;
            this.colEmail.Text = StringResources.email;
            this.colWeb.Text = StringResources.Pagweb;
            this.colFecha.Text = StringResources.FechaCreacion;
            this.colNombCorto.Text = StringResources.Nombre;
            this.colDescripcion.Text = StringResources.Descripcion;
            this.colContacto.Text = StringResources.Contacto;
            //
            this.lblCodigo.Text = StringResources.Codigo;
            this.lblEmpresa.Text = StringResources.Empresa;
            this.lblRif.Text = StringResources.RIF;
            this.lblDireccion.Text = StringResources.Direccion;
            //
            this.lblTitulo.Text = StringResources.Empresa;
            //
            this.Text = StringResources.Empresa;
            //
            this.btoAceptar.Text = StringResources.btoAceptar;
            this.btoBuscar.Text = StringResources.btnBuscar;
            this.btoSalir.Text = StringResources.btnSalir;
        }
    }
}
