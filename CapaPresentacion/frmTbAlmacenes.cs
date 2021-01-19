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
using System.IO;//
using System.Drawing.Drawing2D;
using System.Diagnostics;//
using System.Windows;//
using System.Windows.Data;//
using System.Windows.Input;//
using System.Windows.Media;//
using System.Windows.Media.Converters;//
using System.Collections;//

namespace CapaPresentacion
{
    public partial class frmTbAlmacenes : Form
    {
        private clsEmpresa lst = new clsEmpresa();
        ListViewItem lvrow;
        DataTable dt = new DataTable();
        //-----------------------------------------------------------------------------------------------
        public string mensajeText = "", mensajeCaption = "";
        //--------------------------------------------------------------------------------------------
        public static string tipoPais = "", valido = "";
        public string estado = "";
        //----------------------------------------------------------------------------------------------
        Boolean existe;
        public static string
           _alm_cod = "",
           _alm_nombre = "",
           _alm_desc = "",
           _alm_dir = "",
           _alm_contacto = "",
           _alm_telef1 = "",
           _alm_telef2 = "",
           _alm_fechaCreacion = "";
        //------------------------------------------------------------------------------------------
        public int num_almacen, pos,j,x;
        public string codigo = "", almacen = "", Contacto = "", codAlmacen="", Coincidencia;
        DataTable dtalmacenes;
        DateTime fecha;
        string cod = "";
        //--------------------------------------------------------------------------------------------
        public static string[,] almAsoacidos;
        public string[,] datos = new string[1, 10];
        public delegate void pasar(string[,] dato);        //firma tipo de metodo
        public delegate void relacion(DataTable dtAlmAsociados);
        public event pasar pasado;
        public event relacion AlmAsociados;
        //------------------------------------------------Pasar con dobleclick DtAlmacenes-------------------------------------------------
        public event pasarMov pasadoMov;
        public string[,] datosMov = new string[1, 10];
        public delegate void pasarMov(string[,] datoMov);

        //--------------------------------------------------------------------------------------------
        public frmTbAlmacenes()
        {
            InitializeComponent();
            dt = lst.Listado_Almacenes(frmPrincipal.nombreBD);
        }
        private void frmTbAlmacenes_Load(object sender, EventArgs e)
        {
            lstvAlmacenes.OwnerDraw = true;
            this.txtEmpresa.Text = frmAlmacenes.nombreBd;
            this.lstvAlmacenes.FullRowSelect = true;
            Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
            AplicarIdioma();
            funcionInicio();

            if (frmRelacionSucAlm.activarChek == "si" /*|| frmMovimientoDeInventario.valido == "Mov-TbAlmacenes"*/)
            {
                lstvAlmacenes.CheckBoxes = true;
            }
            else
            {
                lstvAlmacenes.CheckBoxes = false;
            }

            if (frmRelacionSucAlm.dta.Rows.Count>0)
            {
                almAsoacidos = new string[1, frmRelacionSucAlm.b];      //buscar almecenes que ya estan 
                almAsoacidos = frmRelacionSucAlm.codAlmAsociados;                                                    //asociados y no colocar en lstview
            }
            CargarListviewAlmacenes();
        }
        //---------------------------------------------- eventos textbox -------------------------------------------------------
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
               lstvAlmacenes.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
                funcionbuscar();
            }
        }
        private void txtAlmacen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                lstvAlmacenes.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
                funcionbuscar();
            }
        }
        private void lstvAlmacenes_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.DarkOrange, e.Bounds);
            e.DrawText();
        }
        private void lstvAlmacenes_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }
        private void txtContacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                lstvAlmacenes.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
                funcionbuscar();
            }
        }

        private void lstvAlmacenes_DoubleClick(object sender, EventArgs e)
        {
            if (frmMovDeInventario.valido == "Mov-TbAlmacenes")
            {
                DatosSeleccionadosMov();
                this.Hide();
            }
            else
            {
                DatosSeleccionado();
                this.Hide();
            }
        }

        //--------------------------------------------- EVENTOS LISTVIEW  ----------------------------------------------------

        //-----------------------------------------------------------------------------------------------------------
        public void CargarListviewAlmacenes()
        {            
            if (frmRelacionSucAlm.statusLsv==0)
            {
                for (int a = 0; a < dt.Rows.Count; a++)
                {                      
                    lvrow = new ListViewItem(dt.Rows[a]["alm_cod"].ToString());
                    lvrow.SubItems.Add(dt.Rows[a]["alm_nombre"].ToString());
                    lvrow.SubItems.Add(dt.Rows[a]["alm_desc"].ToString());
                    lvrow.SubItems.Add(dt.Rows[a]["alm_dir"].ToString());
                    lvrow.SubItems.Add(dt.Rows[a]["alm_contacto"].ToString());
                    lvrow.SubItems.Add(dt.Rows[a]["alm_telef1"].ToString());
                    lvrow.SubItems.Add(dt.Rows[a]["alm_telef2"].ToString());
                    lvrow.SubItems.Add(dt.Rows[a]["alm_fechaCreacion"].ToString());
                    this.lstvAlmacenes.Items.Add(lvrow);
                }
            }
            else
            {
                int c = frmRelacionSucAlm.b;
                this.lstvAlmacenes.Items.Clear();
                num_almacen = dt.Rows.Count;
                if (dt.Rows.Count == 0)
                {
                    btoAceptar.Enabled = false;
                    btoBuscar.Enabled = false;
                }
                else
                {
                    for (int a = 0; a < dt.Rows.Count; a++)
                    {
                        x = a;
                        buscarCoincidencia();                        
                        if (existe != true)
                        {
                            lvrow = new ListViewItem(dt.Rows[a]["alm_cod"].ToString());
                            lvrow.SubItems.Add(dt.Rows[a]["alm_nombre"].ToString());
                            lvrow.SubItems.Add(dt.Rows[a]["alm_desc"].ToString());
                            lvrow.SubItems.Add(dt.Rows[a]["alm_dir"].ToString());
                            lvrow.SubItems.Add(dt.Rows[a]["alm_contacto"].ToString());
                            lvrow.SubItems.Add(dt.Rows[a]["alm_telef1"].ToString());
                            lvrow.SubItems.Add(dt.Rows[a]["alm_telef2"].ToString());
                            lvrow.SubItems.Add(dt.Rows[a]["alm_fechaCreacion"].ToString());
                            this.lstvAlmacenes.Items.Add(lvrow);
                        }                        
                    }
                }
            }
        }
        private void DatosSeleccionadosMov()
        {
            if (frmMovDeInventario.valido == "Mov-TbAlmacenes")
            {
                _alm_cod = lstvAlmacenes.SelectedItems[0].Text.ToString();
                _alm_nombre = lstvAlmacenes.SelectedItems[0].SubItems[1].Text.ToString();
                _alm_desc = lstvAlmacenes.SelectedItems[0].SubItems[2].Text.ToString();

                datosMov[0, 0] = _alm_cod;
                datosMov[0, 1] = _alm_nombre;
                datosMov[0, 2] = _alm_desc;

                pasadoMov(datosMov);
            }
        }
      

        private void buscarCoincidencia()
        {
            for (int i=0; i< frmRelacionSucAlm.b; i++)
            {
                cod = almAsoacidos[0, i];
                existe = cod.Contains(dt.Rows[x]["alm_cod"].ToString());
                if (existe==true)
                {
                    return;
                }

            }
        }
        private void ConstruccionDt()
        {
            dtalmacenes = new DataTable();
            dtalmacenes.Columns.Add("codigo", Type.GetType("System.Int32"));
            dtalmacenes.Columns.Add("nombre", Type.GetType("System.String"));
            dtalmacenes.Columns.Add("descripcion", Type.GetType("System.String"));
        }

        private void cargarDatos()
        {
           // dtalmacenes.Rows.Clear();
            dtalmacenes.Rows.Add();
            dtalmacenes.Rows[j]["codigo"] = _alm_cod;
            dtalmacenes.Rows[j]["nombre"] = _alm_nombre;
            dtalmacenes.Rows[j]["descripcion"] = _alm_desc;
        }

        private void DatosSeleccionado()
        {
            if (frmPrincipal.validar == "si")
            {
                _alm_cod = lstvAlmacenes.SelectedItems[0].Text.ToString();
                _alm_nombre = lstvAlmacenes.SelectedItems[0].SubItems[1].Text.ToString();
                _alm_desc = lstvAlmacenes.SelectedItems[0].SubItems[2].Text.ToString();
                _alm_dir = lstvAlmacenes.SelectedItems[0].SubItems[3].Text.ToString();
                _alm_contacto = lstvAlmacenes.SelectedItems[0].SubItems[4].Text.ToString();
                _alm_telef1 = lstvAlmacenes.SelectedItems[0].SubItems[5].Text.ToString();
                _alm_telef2 = lstvAlmacenes.SelectedItems[0].SubItems[6].Text.ToString();
                _alm_fechaCreacion = lstvAlmacenes.SelectedItems[0].SubItems[7].Text.ToString();

                //*****************Pasar Datos por evento ******************************
                datos[0, 0] = _alm_cod;
                datos[0, 1] = _alm_nombre;
                datos[0, 2] = _alm_desc;
                datos[0, 3] = _alm_dir;
                datos[0, 4] = _alm_contacto;
                datos[0, 5] = _alm_telef1;
                datos[0, 6] = _alm_telef2;
                datos[0, 7] = _alm_fechaCreacion;
                pasado(datos);
            }

            //if(frmMovimientoDeInventario.valido == "Mov-TbAlmacenes")
            //{
            //    _alm_cod = lstvAlmacenes.SelectedItems[0].Text.ToString();
            //    _alm_nombre = lstvAlmacenes.SelectedItems[0].SubItems[1].Text.ToString();
            //    _alm_desc = lstvAlmacenes.SelectedItems[0].SubItems[2].Text.ToString();
            //    cargarDatos();
            //    //datos[0, 0] = _alm_cod;
            //    //datos[0, 1] = _alm_nombre;

            //    //pasado(datos);
            //}
        }
     
        private void AlmacenesSeleccionado()
        {
            j = 0;
            ConstruccionDt();
                for (int i = 0; i < lstvAlmacenes.Items.Count; i++)
                {
                    if (lstvAlmacenes.Items[i].Checked == true)
                    {
                        _alm_cod = lstvAlmacenes.Items[i].SubItems[0].Text;
                        _alm_nombre = lstvAlmacenes.Items[i].SubItems[1].Text;
                        _alm_desc = lstvAlmacenes.Items[i].SubItems[2].Text;
                        cargarDatos();
                        j++;
                    }
                }
            AlmAsociados(dtalmacenes);
        }
        //---------------------------------------------- FUNCIONES -----------------------------------
        
        public void funcionInicio()
        {
            if (lstvAlmacenes.Items.Count == 0)
            {
                this.txtCodigo.Enabled = false;
                this.txtAlmacen.Enabled = false;
              //this.txtContacto.Enabled = false;
              //this.btoBuscar.Enabled = false;
              //  this.btoAceptar.Enabled = false;
            }
        }
        private void funcionbuscar()
        {

            if (txtCodigo.Text == "" && txtAlmacen.Text == "" )
            {
                txtCodigo.Focus();
                return;
            }
            else if (txtCodigo.Text != "" && txtAlmacen.Text != "")
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
                almacen = "";
                Contacto = "";

                validar_Buscar(codigo, almacen, Contacto);
                LimpiarCajas();
            }
            else if (txtAlmacen.Text != "")
            {
                codigo = "";
                almacen = txtAlmacen.Text;

                validar_Buscar(codigo, almacen, Contacto);
                LimpiarCajas();
            }          
            else
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.NoSeEncontroInformacion;
                mensajeCaption = StringResources.ErrordeValidacion;

                MessageBox.Show(mensajeText, mensajeCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                LimpiarCajas();
            }

        }
        public void validar_Buscar(string codigo, string sucursal, string Contacto)
        {
            valido = "";

            if (codigo != "")
            {
               num_almacen = lstvAlmacenes.Items.Count;

                for (int i = 0; i < num_almacen; i++)
                {
                    if (lstvAlmacenes.Items[i].SubItems[0].Text.ToLower() == codigo.ToLower())
                    {
                        valido = "valido";
                        _alm_cod = lstvAlmacenes.Items[i].SubItems[0].Text.ToString().Trim();
                        _alm_nombre = lstvAlmacenes.Items[i].SubItems[1].Text.ToString().Trim();
                        _alm_contacto = lstvAlmacenes.Items[i].SubItems[4].Text.ToString().Trim();

                       lstvAlmacenes.Items[i].SubItems[0].BackColor = Color.LightSeaGreen;
                        pos = i;
                        return;
                    }
                }
            }
            else if (sucursal != "")
            {
                num_almacen = lstvAlmacenes.Items.Count;

                for (int i = 0; i < num_almacen; i++)
                {
                    if (lstvAlmacenes.Items[i].SubItems[0].Text.ToLower() == almacen.ToLower())
                    {
                        valido = "valido";
                        _alm_cod = lstvAlmacenes.Items[i].SubItems[0].Text.ToString().Trim();
                        _alm_nombre = lstvAlmacenes.Items[i].SubItems[1].Text.ToString().Trim();
                        _alm_contacto = lstvAlmacenes.Items[i].SubItems[4].Text.ToString().Trim();
                        lstvAlmacenes.Items[i].SubItems[0].BackColor = Color.LightSeaGreen;
                        pos = i;
                        return;
                    }
                }
            }
            if (Contacto != "")
            {
                num_almacen = lstvAlmacenes.Items.Count;

                for (int i = 0; i < num_almacen; i++)
                {
                    if (lstvAlmacenes.Items[i].SubItems[0].Text.ToLower() == Contacto.ToLower())
                    {
                        valido = "valido";
                        _alm_cod = lstvAlmacenes.Items[i].SubItems[0].Text.ToString().Trim();
                        _alm_nombre = lstvAlmacenes.Items[i].SubItems[1].Text.ToString().Trim();
                        _alm_contacto = lstvAlmacenes.Items[i].SubItems[4].Text.ToString().Trim();
                        lstvAlmacenes.Items[i].SubItems[0].BackColor = Color.LightSeaGreen;
                        pos = i;
                        return;
                    }
                }
            }
        }
        public void LimpiarCajas()
        {
            codigo = "";
            almacen = "";
            Contacto = "";
        }

        //------------------------------ btos ----------------------------------------------
        private void btoBuscar_Click(object sender, EventArgs e)
        {
            lstvAlmacenes.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
            estado = "buscar";
            funcionbuscar();
        }

        private void btoSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRelacionSucAlm.activarChek = "no";
        }

        private void btoAceptar_Click(object sender, EventArgs e)
        {
            if (lstvAlmacenes.CheckedItems.Count>0)
            {
                 AlmacenesSeleccionado();
                this.Hide();
                frmRelacionSucAlm.activarChek = "no";
            }
            else
            {
                if (lstvAlmacenes.SelectedItems.Count>0)
                {                
              //  DatosSeleccionado();
                this.Hide();
                 frmRelacionSucAlm.activarChek = "no";
                }
                else
                {
                    this.Hide();
                    frmRelacionSucAlm.activarChek = "no";
                }
         
            }            
        }
        private void lstvAlmacenes_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lstvAlmacenes.Sorting == SortOrder.Ascending)
            {
                lstvAlmacenes.Sorting = SortOrder.Descending;
                lstvAlmacenes.Sort();
            }
            else
            {
                lstvAlmacenes.Sorting = SortOrder.Ascending;
                lstvAlmacenes.Sort();
            }
        }
        //------------------------------------- IDIOMA ---------------------------------------------
        public void AplicarIdioma()
        {
            this.codigo = StringResources.Codigo;

            //
            this.ColCodigo.Text = StringResources.Codigo;
            this.colNomAlmacen.Text = StringResources.Almacen;
            this.colDescripcion.Text = StringResources.Descripcion;
            this.colDireccion.Text = StringResources.Direccion;
            this.colContacto.Text = StringResources.Contacto;
            this.colTelf1.Text = StringResources.Telefonos;
            this.colTelf2.Text = StringResources.Telefonos;
            this.colFecha.Text = StringResources.FechaCreacion;
            //
            this.lblCodigo.Text = StringResources.Codigo;
            this.lblAlmacen.Text = StringResources.Almacen;
            this.lblEmpresa.Text = StringResources.Empresa;
            //
            this.lblTitulo.Text = StringResources.Almacenes;
            //
            this.Text = StringResources.Almacenes;
            //
            this.btoAceptar.Text = StringResources.btoAceptar;
            this.btoBuscar.Text = StringResources.btnBuscar;
            this.btoSalir.Text = StringResources.btnSalir;
        }
    }
}
