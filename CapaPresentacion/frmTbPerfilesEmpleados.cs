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
    public partial class frmTbPerfilesEmpleados : Form
    {
        //********Valerie
        public delegate void relacion(DataTable dtPerfilEmp);
        public event relacion dtRelPerfilEmp;

        DataTable DtPerfilEmp;
        string CodPerf = "";
        int j=0;

        //-------------------------------------------------------------------------

        public clsEmpresa emp = new clsEmpresa();
        ListViewItem lvrow;
        public string[,] datos = new string[1, 4];
        public delegate void pasar(string[,] dato);
        public event pasar pasado;
        public string tipoPais = "", mensajeText = "", mensajeCaption = "";
        public static string tipopais = "", _Descripcion = "", _Id = "",_Sueldo="", perfil = "", estado = "", id = "", descrip = "";
        int pos = 0, i = 0, count = 0, a, numid;
        //********************************************************************************
        private void frmTbPerfilesEmpleados_Load(object sender, EventArgs e)
        {
            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();

            if (frmCedulaDeProducto.accion == "inicio")
            {
                lstvPerfilesEmpleados.CheckBoxes = false;
            }
            if (frmCedulaDeProducto.valido == "si")
            {
                lstvPerfilesEmpleados.CheckBoxes = true;
            }
            else
            {
                lstvPerfilesEmpleados.CheckBoxes = false;
            }
            cargarlstvperfil();
        }
        public frmTbPerfilesEmpleados()
        {
            InitializeComponent();
            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();
        }
        //-------------------------------------------------------------------------------
        private void frmTbPerfilesEmpleados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FuncionBuscar();
            }
        }
        private void lstvPerfilesEmpleados_DoubleClick(object sender, EventArgs e)
        {
            datosSeleccionados();
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

        private void btoAceptar_Click(object sender, EventArgs e)
        {
            if (lstvPerfilesEmpleados.CheckBoxes == false)
            {
                if (lstvPerfilesEmpleados.SelectedItems.Count > 0)
                {
                    datosSeleccionados();
                }
            }
            else if (estado == "buscar")
            {
                perfil = "Valido";
                datos[0, 0] = _Id;
                datos[0, 1] = _Descripcion;
                datos[0, 2] = _Sueldo;
                pasado(datos);
                this.Hide();
            }
            else if (frmCedulaDeProducto.valido == "si")
            {
                PerfilSeleccionado();
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

        private void lstvPerfilesEmpleados_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lstvPerfilesEmpleados.Sorting == SortOrder.Ascending)
            {
                lstvPerfilesEmpleados.Sorting = SortOrder.Descending;
                lstvPerfilesEmpleados.Sort();
            }
            else
            {
                lstvPerfilesEmpleados.Sorting = SortOrder.Ascending;
                lstvPerfilesEmpleados.Sort();
            }
        }

        private void btoBuscar_Click(object sender, EventArgs e)
        {
            FuncionBuscar();
        }

        public void cargarlstvperfil()
        {
            this.lstvPerfilesEmpleados.Items.Clear();
            DataTable dt = new DataTable();
            dt = emp.listarlstvPerfilesEmpleados(frmPrincipal.nombreBD);
            for (i = 0; i < dt.Rows.Count; i++)
            {
                lvrow = new ListViewItem(dt.Rows[i]["PerfilesEmp_Id"].ToString().Trim());
                lvrow.SubItems.Add(dt.Rows[i]["PerfilesEmp_Descripcion"].ToString().Trim());
                lvrow.SubItems.Add(dt.Rows[i]["PefilEmp_Sueldo"].ToString().Trim());
                this.lstvPerfilesEmpleados.Items.Add(lvrow);
            }
            FiltrarDatos();
        }
        public void cargarvariable()
        {
            perfil = "Valido";
            _Id = lstvPerfilesEmpleados.Items[a].SubItems[0].Text.ToString().Trim();
            _Descripcion = lstvPerfilesEmpleados.Items[a].SubItems[1].Text.ToString().Trim();
            _Sueldo = lstvPerfilesEmpleados.Items[a].SubItems[2].Text.ToString().Trim();
            lstvPerfilesEmpleados.Items[a].SubItems[0].BackColor = Color.LightSeaGreen;
            pos = a;
        }
        private void FiltrarDatos()
        {
            if (frmCedulaDeProducto.valido == "si")
            {
                if (frmCedulaDeProducto.cont1 != 0)
                {
                    for (int a = 0; a < frmCedulaDeProducto.DtActualPerf.Rows.Count; a++)
                    {
                        CodPerf = frmCedulaDeProducto.DtActualPerf.Rows[a]["PerfilId"].ToString();
                        Actualizarlsv();
                    }
                }
            }
        }

        private void Actualizarlsv()
        {
            for (int i = 0; i < lstvPerfilesEmpleados.Items.Count; i++)
            {
                if (CodPerf == lstvPerfilesEmpleados.Items[i].SubItems[0].Text.ToString())
                {
                    lstvPerfilesEmpleados.Items.RemoveAt(i);
                    return;
                }
            }
        }
        public void actualizarlstv(string accion)
        {
            switch (accion)
            {
                case "agregar":
                    lvrow = new ListViewItem(frmPerfilesEmpleados.id);
                    lvrow.SubItems.Add(frmFallasMaquinas.descrip);
                    this.lstvPerfilesEmpleados.Items.Add(lvrow);
                    break;

                case "editar":
                    validarperfil(frmPerfilesEmpleados.id, "", "buscar");
                    lstvPerfilesEmpleados.Items[pos].SubItems[0].BackColor = Color.White;
                    lstvPerfilesEmpleados.Items[pos].SubItems[1].Text = frmPerfilesEmpleados.descrip;
                    lstvPerfilesEmpleados.Items[pos].SubItems[0].Text = frmPerfilesEmpleados.Sueldo;
                    break;

                case "eliminar":
                    validarperfil(frmPerfilesEmpleados.descripcion, "", "buscar");
                    lstvPerfilesEmpleados.Items[pos].SubItems[0].BackColor = Color.White;
                    lstvPerfilesEmpleados.Items.RemoveAt(pos);
                    pos = 0;
                    numid--;
                    break;
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
                    validarperfil(id, descrip, "buscar");
                    limpiarcajas();
                }
                else
                {
                    id = "";
                    descrip = txtDescripcion.Text;
                    validarperfil(id, descrip, "buscar");
                    limpiarcajas();
                }
            }
            if (perfil != "Valido")
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
        public void limpiarcajas()
        {
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
        }

        private void datosSeleccionados()
        {
            if (lstvPerfilesEmpleados.SelectedItems.Count > 0)
            {
                _Id = lstvPerfilesEmpleados.SelectedItems[0].Text;
                _Descripcion = lstvPerfilesEmpleados.SelectedItems[0].SubItems[1].Text;
                _Sueldo= lstvPerfilesEmpleados.SelectedItems[0].SubItems[2].Text;
                datos[0, 0] = _Id;
                datos[0, 1] = _Descripcion;
                datos[0, 2] = _Sueldo;
                pasado(datos);
                perfil = "Valido";
                this.Hide();
            }
            else { return; }
        }    
        public void validarperfil(string id, string descripcion, string buscar)
        {
            lstvPerfilesEmpleados.Items[pos].SubItems[0].BackColor = Color.White;
            string palabra = "";
            if (id != "")
            {
                for (int i = 0; i < lstvPerfilesEmpleados.Items.Count; i++)
                {
                    palabra = lstvPerfilesEmpleados.Items[i].SubItems[0].Text.ToLower();
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
                for (int i = 0; i < lstvPerfilesEmpleados.Items.Count; i++)
                {
                    palabra = lstvPerfilesEmpleados.Items[i].SubItems[1].Text.ToLower();
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
      
        //Idioma
        public void AplicarIdioma()
        {
            //titulo
            this.Text = StringResources.frmTbPerfilesEmpleados_Titulo;
            this.lblTitulo.Text=StringResources.frmTbPerfilesEmpleados_Titulo;
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
            this.lstvSueldo.Text = StringResources.Sueldo;
        }

        //2020
        private void ConstruccionDT()
        {
            DtPerfilEmp = new DataTable();
            DtPerfilEmp.Columns.Add("codigo", Type.GetType("System.String"));
            DtPerfilEmp.Columns.Add("descripcion", Type.GetType("System.String"));
        }
        private void PerfilSeleccionado()
        {
            j = 0;
            ConstruccionDT();
            for (int i = 0; i < lstvPerfilesEmpleados.Items.Count; i++)
            {
                if (lstvPerfilesEmpleados.Items[i].Checked == true)
                {
                    DtPerfilEmp.Rows.Add();
                    DtPerfilEmp.Rows[j]["codigo"] = lstvPerfilesEmpleados.Items[i].SubItems[0].Text;
                    DtPerfilEmp.Rows[j]["descripcion"] = lstvPerfilesEmpleados.Items[i].SubItems[1].Text;
                    j++;
                }
            }
            dtRelPerfilEmp(DtPerfilEmp);
        }



    }
}
