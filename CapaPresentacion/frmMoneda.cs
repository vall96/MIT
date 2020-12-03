using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using CultureResources;
using System.Threading;
using System.Globalization;
using CapaLogicaNegocios;

namespace CapaPresentacion
{
    public partial class frmMoneda : Form
    {
        public frmMoneda()
        {
            InitializeComponent();
            //cargarLsvMoneda();
            CargarMonedas();
        }

        ListViewItem lvrow;
        private clsEmpresa Emp = new clsEmpresa();
        DataTable dt = new DataTable();
        int num_momendas = 0, pos=0,j,x;
        //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public string mensajeText = "", mensajeCaption = "",
            _monCodId,_moCod,_monDesc,_monSimb, cod = "";
        public static string tipoPais = "";
        Boolean existe;
        //-----------------------------------------------------------------
        public static string[,] codMonedas;
        DataTable dtmonedas;
        public delegate void relacion(DataTable dtMonAsociados);
        public event relacion MonAsociados;

        private void frmMoneda_Load(object sender, EventArgs e)
        {
            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();

            lsvMoneda.OwnerDraw = true;
            if (frmEmpresas.activarChek == "activar")
            {
                lsvMoneda.CheckBoxes = true;
            }
            else
            {
                this.Location = new System.Drawing.Point(0, 0);
            }
            if (frmEmpresas.statusLsv > 0)
            {
                codMonedas = new string[1, frmEmpresas.b];
                codMonedas = frmEmpresas.codMonAsociados;
                num_momendas = frmEmpresas.b;
            }
            if (frmSucursales.formSucursales=="activo")
            {
                codMonedas = new string[1, frmSucursales.b];
                codMonedas = frmSucursales.codMonAsociados;
                num_momendas = frmSucursales.b;
            }
            cargarLsvMoneda();
        }

        public void cargarLsvMoneda()
        {
            string codMon;
            this.lsvMoneda.Items.Clear();
            //-----------CUANDO SE TRATA DE SUCURSALES----------------------------

            if (frmSucursales.formSucursales== "activo")
            {
                string codEmp = frmSucursales.codEmp;
                if (frmSucursales.statusLsvSuc == 0)         //formulario Scurusales activo
                {
                   
                    for (int i = 0; i < frmSucursales.dtrm.Rows.Count; i++)
                    {
                        if (codEmp == frmSucursales.dtrm.Rows[i]["EmpM_codEmp"].ToString())
                        {
                            codMon = frmSucursales.dtrm.Rows[i]["EmpM_codMon"].ToString();
                            for (int a = 0; a < dt.Rows.Count; a++)
                            {
                                if (codMon == dt.Rows[a]["mon_codID"].ToString())
                                {
                                    lvrow = new ListViewItem(dt.Rows[a]["mon_cod"].ToString());
                                    lvrow.SubItems.Add(dt.Rows[a]["mon_Descripcion"].ToString());
                                    lvrow.SubItems.Add(dt.Rows[a]["mon_simbolo"].ToString());
                                    lvrow.SubItems.Add(dt.Rows[a]["mon_codID"].ToString());
                                    this.lsvMoneda.Items.Add(lvrow);
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < frmSucursales.dtrm.Rows.Count; i++)
                    {
                        if (codEmp == frmSucursales.dtrm.Rows[i]["EmpM_codEmp"].ToString())
                        {
                            codMon = frmSucursales.dtrm.Rows[i]["EmpM_codMon"].ToString();
                            for (int a = 0; a < dt.Rows.Count; a++)
                            {
                                if (codMon == dt.Rows[a]["mon_codID"].ToString())
                                {
                                    x = a;
                                    buscarCoincidencia();
                                    if (existe != true)
                                    {
                                        lvrow = new ListViewItem(dt.Rows[a]["mon_cod"].ToString());
                                        lvrow.SubItems.Add(dt.Rows[a]["mon_Descripcion"].ToString());
                                        lvrow.SubItems.Add(dt.Rows[a]["mon_simbolo"].ToString());
                                        lvrow.SubItems.Add(dt.Rows[a]["mon_codID"].ToString());
                                        this.lsvMoneda.Items.Add(lvrow);

                                    }
                                }
                            }

                        }


                    }
                }
            }
            

            //----------------PARA CUANDO SE TRATA DE EMPRESA
            else if(frmEmpresas.statusLsv == 0)   //formulario empresas activo
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lvrow = new ListViewItem(dt.Rows[i]["mon_cod"].ToString());
                    lvrow.SubItems.Add(dt.Rows[i]["mon_Descripcion"].ToString());
                    lvrow.SubItems.Add(dt.Rows[i]["mon_simbolo"].ToString());
                    lvrow.SubItems.Add(dt.Rows[i]["mon_codID"].ToString());
                    this.lsvMoneda.Items.Add(lvrow);
                }
            }
            else
            {
                for (int a = 0; a < dt.Rows.Count; a++)
                {
                    x = a;
                    buscarCoincidencia();
                    if (existe!=true)
                    {
                        lvrow = new ListViewItem(dt.Rows[a]["mon_cod"].ToString());
                        lvrow.SubItems.Add(dt.Rows[a]["mon_Descripcion"].ToString());
                        lvrow.SubItems.Add(dt.Rows[a]["mon_simbolo"].ToString());
                        lvrow.SubItems.Add(dt.Rows[a]["mon_codID"].ToString());
                        this.lsvMoneda.Items.Add(lvrow);

                    }
                }
            }
           
        }
        private void buscarCoincidencia()
        {
            for (int i = 0; i < num_momendas; i++)
            {
                cod = codMonedas[0, i];
                existe = cod.Contains(dt.Rows[x]["mon_codID"].ToString());
                if (existe==true)
                {
                    return;
                }
            }
        }
        private void CargarMonedas()
        {          
            dt = Emp.Listado_monedas();
           // num_momendas = dt.Rows.Count;
        }
        private void MonSeleccionas()
        {
            j = 0;
            
            if (lsvMoneda.CheckedItems.Count>0)
            {
                ConstruccionDt();
                for (int i = 0; i < lsvMoneda.Items.Count; i++)
                {
                    if (lsvMoneda.Items[i].Checked == true)
                    {
                        _moCod= lsvMoneda.Items[i].SubItems[0].Text.ToString();
                        _monDesc = lsvMoneda.Items[i].SubItems[1].Text.ToString();
                        _monSimb= lsvMoneda.Items[i].SubItems[2].Text.ToString();
                        _monCodId= lsvMoneda.Items[i].SubItems[3].Text.ToString();
                        cargarDatos();
                        j++;
                    }
                }
                 MonAsociados(dtmonedas);
            }
            else
            {
                return;
            }
        }
        private void ConstruccionDt()
        {
            dtmonedas = new DataTable();
            dtmonedas.Columns.Add("codMon", Type.GetType("System.String"));
            dtmonedas.Columns.Add("codigo", Type.GetType("System.String"));
            dtmonedas.Columns.Add("descripcion", Type.GetType("System.String"));
            dtmonedas.Columns.Add("simbolo", Type.GetType("System.String"));
        }
        private void cargarDatos()
        {
            //  dtalmacenes.Rows.Clear();
            dtmonedas.Rows.Add();
            dtmonedas.Rows[j]["codMon"] = _monCodId;
            dtmonedas.Rows[j]["codigo"] = _moCod;
            dtmonedas.Rows[j]["descripcion"] = _monDesc;
            dtmonedas.Rows[j]["simbolo"] = _monSimb;
        }

        private void FuncionBuscar()
        {
            if (txtCodigo.Text=="" && txtDescripcion.Text=="")
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

                // MessageBox.Show("No se puede realizar la busqueda con Codigo y Descripcion a la vez, utilice solo uno de estos campos", "Error de Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtCodigo.Focus();
                return;
            }
            else if (txtCodigo.Text != "")
            {
                buscarMoneda(txtCodigo.Text.ToString(), "");
            }
            else if (txtDescripcion.Text != "")
            {
                buscarMoneda( "",txtDescripcion.Text.ToString());
            }
        }

        private void buscarMoneda(string codigo, string descripcion)
        {
            string palabra = "";
            lsvMoneda.Items[pos].SubItems[0].BackColor = Color.White;
            if (codigo != "")
            {
                for (int i = 0; i < lsvMoneda.Items.Count; i++)
                {
                    palabra = lsvMoneda.Items[i].SubItems[0].Text.ToLower();
                    bool existe = palabra.StartsWith(codigo.ToLower());
                    if (existe == true)
                    {
                        lsvMoneda.Items[i].SubItems[0].BackColor = Color.LightSeaGreen;
                        pos = i;
                        return;
                    }
               
                }
            }
            else if (descripcion!="")
            {
                for (int i = 0; i < lsvMoneda.Items.Count; i++)
                {

                    palabra = lsvMoneda.Items[i].SubItems[1].Text.ToLower();
                    bool existe = palabra.StartsWith(descripcion.ToLower());
                    if (existe == true)
                    {
                        lsvMoneda.Items[i].SubItems[0].BackColor = Color.LightSeaGreen;
                        pos = i;
                        return;
                    }
                    
                }
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FuncionBuscar();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                FuncionBuscar();
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                FuncionBuscar();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            frmEmpresas.activarChek = "";
            MonSeleccionas();
            this.Close();
        }

        private void lsvMoneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (lsvMoneda.SelectedItems.Count >0 )
            //{

            //}
        }

        private void lsvMoneda_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.DarkOrange, e.Bounds);
            e.DrawText();
        }

        private void lsvMoneda_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        
        public void AplicarIdioma()
        {
            this.lblCodigo.Text = StringResources.Codigo;
            this.lblDescripcion.Text = StringResources.Descripcion;
            this.lblTituloPanel.Text = StringResources.frmMonedas_tituloPanel; ;
            //
            this.Codigo.Text = StringResources.Codigo;
            this.descripcion.Text = StringResources.Descripcion;
            this.Simbolo.Text = StringResources.frmMonedas_Simbolo;
            //
            this.btnBuscar.Text = StringResources.btnBuscar;
            this.btnAceptar.Text = StringResources.btoAceptar;
            //
            this.Text = StringResources.frmMonedas_Monedas;
            //

        }
    }
}
