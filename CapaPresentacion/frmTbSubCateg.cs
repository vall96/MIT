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

namespace CapaPresentacion
{
    public partial class frmTbSubCateg : Form
    {
        public static string _Codigo, _Descripcion, _Categoria, estado = "";
        int pos = 0;
        frmSubCategoria ventSubCat;
        //---------------------------------------------------------------
        public frmTbSubCateg()
        {
            InitializeComponent();
            CargarSubCatg();
            CargarCatg();
            cargarlsv();
        }
        //-------------------------------------------------------------------
        ListViewItem lvrow;
        clsEmpresa M = new clsEmpresa();
        public delegate void pasar(string[,] dato);
        public event pasar pasado;
        public string[,] datos = new string[1, 4];
        DataTable dt = new DataTable();
        DataTable dtc = new DataTable();
        //-----------------------------------------------------------------------------------
        private void cargarlsv()
        {
            this.lsvSubCatg.Items.Clear();
            if (frmArticulos.formActivo == "activo")
            {
                this.cboCategoria.SelectedItem = frmArticulos.categoria;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["SubCat_codCat"].ToString() == frmArticulos.codCategoria)
                    {
                        lvrow = new ListViewItem(dt.Rows[i]["SubCat_Id"].ToString());
                        lvrow.SubItems.Add(dt.Rows[i]["SubCat_Descripcion"].ToString());                       
                        this.lsvSubCatg.Items.Add(lvrow);
                    }
                }
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (cboCodCategoria.Text== dt.Rows[i]["SubCat_codCat"].ToString())
                    {
                        lvrow = new ListViewItem(dt.Rows[i]["SubCat_Id"].ToString());
                        lvrow.SubItems.Add(dt.Rows[i]["SubCat_Descripcion"].ToString());
                        this.lsvSubCatg.Items.Add(lvrow);
                    }
                }
            }
        }

        private void cargarCbo()
        {
            this.cboCategoria.Items.Clear();
            this.cboCodCategoria.Items.Clear();

            for (int i = 0; i < dtc.Rows.Count; i++)
            {
                cboCategoria.Items.Add(dtc.Rows[i]["cat_descripcion"].ToString().Trim());
                cboCodCategoria.Items.Add(dtc.Rows[i]["cat_id"].ToString().Trim());
                cboCategoria.SelectedIndex = 0;
            }
        }
        private void CargarSubCatg()
        {
            dt = M.ListadoSubCategoria(frmPrincipal.nombreBD);
        }
        private void CargarCatg()
        {
            dtc = M.ListadoCategoria(frmPrincipal.nombreBD);
        }
        private void datosSeleccionados()
        {
            if (lsvSubCatg.SelectedItems.Count > 0)
            {
                datos[0, 0] = lsvSubCatg.SelectedItems[0].Text.ToString().Trim();
                datos[0, 1] = lsvSubCatg.SelectedItems[0].SubItems[1].Text.ToString().Trim();
                datos[0, 2] = cboCategoria.Text;
                pasado(datos);
                estado = "Valido";
                this.Hide();
            }
        }
        private void btoSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTbSubCateg_Load(object sender, EventArgs e)
        {
            ventSubCat = new frmSubCategoria();
            cargarCbo();
            
            if (frmArticulos.formActivo != "activo")
            {
                this.cboCategoria.Enabled = true;                         
            }
            else if (frmArticulos.formActivo == "activo")
            {
                this.cboCategoria.Enabled = false;
                cargarlsv();
            }
                
        }

        private void lsvSubCatg_DoubleClick(object sender, EventArgs e)
        {
            datosSeleccionados();
        }

        private void btoBuscar_Click(object sender, EventArgs e)
        {

        }

        private void lsvSubCatg_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lsvSubCatg.Sorting == SortOrder.Descending)
            {
                lsvSubCatg.Sorting = SortOrder.Ascending;
                lsvSubCatg.Sort();
            }
            else
            {
                lsvSubCatg.Sorting = SortOrder.Descending;
                lsvSubCatg.Sort();
            }
        }

        private void btoAceptar_Click(object sender, EventArgs e)
        {
            datosSeleccionados();
        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (frmArticulos.formActivo != "activo")
            {
                this.cboCodCategoria.SelectedIndex = this.cboCategoria.SelectedIndex;
                cargarlsv();
            }
                
        }

        //public void ValidarBuscar(string CodigoP, string DescP)
        //{
        //    //lsvSubCatg.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
        //    string palabra = "";
        //    estado = "";
        //    if (CodigoP != "")
        //    {
        //        for (int i = 0; i < lsvSubCatg.Items.Count; i++)
        //        {
        //            palabra = lsvSubCatg.Items[i].SubItems[0].Text.ToLower();
        //            bool existe = palabra.StartsWith(CodigoP.ToLower());

        //            if (existe == true)
        //            {
        //                estado = "Valido";
        //                _Codigo = lsvSubCatg.Items[i].SubItems[0].Text.ToString().Trim();
        //                _Categoria = cboCategoria.Text;
        //                _Descripcion = lsvSubCatg.Items[i].SubItems[1].Text.ToString().Trim();
        //                lsvSubCatg.Items[i].SubItems[0].BackColor = Color.LightSeaGreen;
        //                pos = i;
        //                return;
        //            }
        //        }
        //    }
        //    else if (DescP != "")
        //    {
        //        for (int i = 0; i < lsvSubCatg.Items.Count; i++)
        //        {
        //            palabra = lsvSubCatg.Items[i].SubItems[1].Text.ToLower();
        //            bool existe = palabra.StartsWith(DescP.ToLower());

        //            if (existe == true)
        //            {
        //                estado = "Valido";
        //                _Codigo = lsvSubCatg.Items[i].SubItems[0].Text.ToString().Trim();
        //                _Categoria = cboCategoria.Text;
        //                _Descripcion = lsvSubCatg.Items[i].SubItems[1].Text.ToString().Trim();
        //                lsvSubCatg.Items[i].SubItems[0].BackColor = Color.LightSeaGreen;
        //                pos = i;
        //                return;
        //            }
        //        }
        //    }
        //}

        public void ValidarBuscarDT(string CodigoP, string DescP)
        {
            string palabra = "";
            estado = "";

            if (CodigoP != "")
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    palabra = dt.Rows[i]["SubCat_Id"].ToString().ToLower();
                    bool existe = palabra.StartsWith(CodigoP.ToLower());

                    if (existe == true)
                    {
                        estado = "Valido";
                        _Codigo = dt.Rows[i]["SubCat_Id"].ToString();
                        _Categoria = dt.Rows[i]["cat_descripcion"].ToString();
                        _Descripcion = dt.Rows[i]["SubCat_Descripcion"].ToString();
                        pos = i;
                        return;
                    }
                }
            }
            if (DescP != "")
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    palabra = dt.Rows[i]["SubCat_Descripcion"].ToString().ToLower();
                    bool existe = palabra.StartsWith(DescP.ToLower());

                    if (existe == true)
                    {
                        estado = "Valido";
                        _Codigo = dt.Rows[i]["SubCat_Id"].ToString();
                        _Categoria = dt.Rows[i]["cat_descripcion"].ToString();
                        _Descripcion = dt.Rows[i]["SubCat_Descripcion"].ToString();
                        pos = i;
                        return;
                    }
                }
            }

        }




    }
}
