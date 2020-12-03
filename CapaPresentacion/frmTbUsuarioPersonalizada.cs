using System;
using System.Collections.Generic;
using System.Collections;
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
    public partial class frmTbUsuarioPersonalizada : Form
    {
       
        private clsUsuario Usua = new clsUsuario();
        ListViewItem lvrow;
        frmUsuarioPruebaEstilo frmUsuarioPruebaEstilo;

        int num_usuarios, i = 0, cantUsuaInicial = 0, pos = 0;
        //public string[,] formulariosactivos = new string[2, 4];
        public static string usuaValido = "",
            estado = "",
            _usuario,
            _nombre = "",
            _descripion = "";

        ListView.SelectedListViewItemCollection cot_lv;

        frmPrincipal ventPrincipal;

        string nombre = "", usuario = "";

        public string[,] datos = new string[1, 4];

        public delegate void pasar(string[,] dato);        //firma tipo de metodo
        public event pasar pasado;

        public string usuarioRegistro = "", mensajeText = "", mensajeCaption = "", existeBd = "";
        public static string tipoPais = "";
        public frmTbUsuarioPersonalizada()
        {
            InitializeComponent();
            cargar_listviewUsuario();
            //cboStatus.Enabled = false;
          //  listViewUsurios.CheckBoxes = true;
           
        }
       
        private void listViewUsurios_DrawItem_1(object sender, DrawListViewItemEventArgs e)
        {
            if (estado=="cerrar")
            {
                this.Hide();
                return;
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void listViewUsurios_SelectedIndexChanged(object sender, EventArgs e)
        {
            cot_lv = this.listViewUsurios.SelectedItems;  //llevar el item seleccionado
            foreach (ListViewItem campos_lv in cot_lv)      //realiza la busqueda
            {
                _usuario = txtUsuario.Text;
                _nombre = txtNombre.Text;
                _descripion = campos_lv.SubItems[3].Text;
            }
        }

        private void btoAceptar_Click(object sender, EventArgs e)
        {
            if (listViewUsurios.SelectedItems.Count > 0)
            {
                datosSeleccionados();
            }
            else
            {
                if(estado=="buscar")
                {
                    //frmUsuarioPruebaEstilo.MdiParent = ventPrincipal;           //OJOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                    usuaValido = "usuario valido";
                    datos[0, 0] = _usuario;
                    datos[0, 1] = _nombre;
                    datos[0, 2] = _descripion;
                    pasado(datos);
                    
                }
                else
                {
                    //frmUsuarioPruebaEstilo.Location = new System.Drawing.Point(0, 75);
                    //frmUsuarioPruebaEstilo.Show();
                    
                }
            }
            estado = "";
            listViewUsurios.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
            this.Hide();
        }
        private void listViewUsurios_DrawColumnHeader_1(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.DarkOrange, e.Bounds);
            e.DrawText();
        }

        private void btoSalir_Click(object sender, EventArgs e)
        {
            frmUsuarioPruebaEstilo.ventana++;
            this.Hide();
        }

        private void botBuscar_Click(object sender, EventArgs e)
        {
            //FuncionBuscar();
            listViewUsurios.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
            estado = "buscar";
            FuncionBuscar();
           // frmUsuarioPruebaEstilo.cargarDatos();
           
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                listViewUsurios.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
                FuncionBuscar();
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                listViewUsurios.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
                FuncionBuscar();        
            }
        }

        private void listViewUsurios_DoubleClick(object sender, EventArgs e)
        {
            datosSeleccionados();
            listViewUsurios.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
        }

        private void listViewUsurios_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (listViewUsurios.Sorting == SortOrder.Ascending)
            {
                listViewUsurios.Sorting = SortOrder.Descending;
                listViewUsurios.Sort();
            }
            else
            {
                listViewUsurios.Sorting = SortOrder.Ascending;
                listViewUsurios.Sort();
            }
        }

        private void listViewUsurios_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)   //para que el usuario no 
                                                                                                            //pueda variar el ancho de las colunnas
        {
            //e.Cancel = true;
            //e.NewWidth = listViewUsurios.Columns[e.ColumnIndex].Width;
        }

       
        private void datosSeleccionados()
        {
            //pasado = new pasar(frmUsuarioPruebaEstilo.ejecutar);
            if (listViewUsurios.SelectedItems.Count> 0)
            {
                //pasado = new pasar("");
               
                _usuario = listViewUsurios.SelectedItems[0].Text; 
                _nombre = listViewUsurios.SelectedItems[0].SubItems[1].Text;
                _descripion = listViewUsurios.SelectedItems[0].SubItems[3].Text;
                //frmUsuarioPruebaEstilo.cargarDatos();
                //usuaValido = "usuario valido";
                //frmUsuarioPruebaEstilo.HabilitarBotones();
                //this.Hide();
                //********* PROBANDO*****
                // pasado(_usuario);
                datos[0, 0] = _usuario;
                datos[0, 1] = _nombre;
                datos[0, 2] = _descripion;
                pasado(datos);                
                usuaValido = "usuario valido";
               // frmUsuarioPruebaEstilo.HabilitarBotones();
                this.Hide();

                //*******************************************
            }
            else
            {
                //frmUsuarioPruebaEstilo.MdiParent = ventPrincipal;           //OJOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                //frmUsuarioPruebaEstilo.Show();
                return;
            }
        }
        private void FuncionBuscar()
        {            
            estado = "buscar";


            if (txtUsuario.Text == "" && txtNombre.Text == "")
            {
                return;
                // usuaValido = "no";
            }
            else if ((txtUsuario.Text != "" && txtNombre.Text != ""))
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.NoSeEncontroInformacion;
                mensajeCaption = StringResources.ErrordeValidacion;

                MessageBox.Show(mensajeText, mensajeCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

                this.txtUsuario.Focus();
                return;
            }
            else
            {
                if (txtUsuario.Text != "")
                {
                    usuario = txtUsuario.Text;
                    nombre = "";
                    validarUsuario_Buscar(usuario, nombre, estado);
                    LimpiarCajas();
                }
                else
                {
                    usuario = "";
                    nombre = txtNombre.Text;
                    validarUsuario_Buscar(usuario, nombre, estado);
                    LimpiarCajas();

                }
                if (frmTbUsuarioPersonalizada.usuaValido == "usuario valido")
                {
                    frmUsuarioPruebaEstilo.cargarDatos();
                    listViewUsurios.Items[pos].Selected = true;
                    listViewUsurios.Items[pos].Focused = true;
                    listViewUsurios.EnsureVisible(pos);
                //    frmUsuarioPruebaEstilo.MdiParent = ventPrincipal;           //OJOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                //   frmUsuarioPruebaEstilo.Show();


                    // this.Close();
                }
                else
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    mensajeText = StringResources.NoSeEncontroInformacion;
                    mensajeCaption = StringResources.ErrordeValidacion;

                    MessageBox.Show(mensajeText, mensajeCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                    this.txtUsuario.Focus();
                    LimpiarCajas();

                }
            }
        }

        private void LimpiarCajas()
        {
            txtUsuario.Text = "";
            txtNombre.Text = "";
        }
        private void frmTbUsuarioPersonalizada_Load(object sender, EventArgs e)
        {
            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();
            listViewUsurios.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
            this.listViewUsurios.FullRowSelect = true;                 //agregado sara
            listViewUsurios.OwnerDraw = true;
            frmUsuarioPruebaEstilo = new frmUsuarioPruebaEstilo();
            ventPrincipal = new frmPrincipal();
            this.Location = new System.Drawing.Point(730, 130);
            listViewUsurios.SelectedItems.Clear();
            funcionInicio();

        }
        public void funcionInicio()
        {
            if (listViewUsurios.Items.Count==0)
            {
                this.txtNombre.Enabled = false;
                this.txtUsuario.Enabled = false;
                this.btoBuscar.Enabled = false;
            }
        }
        public void cargar_listviewUsuario()
        {            
            this.listViewUsurios.Items.Clear();
            DataTable dt = new DataTable();
            dt =Usua.Listado();
            num_usuarios = dt.Rows.Count;       //cuantos usuarios hay en la base de datos
            cantUsuaInicial = dt.Rows.Count;
            for (i = 0; i < num_usuarios; i++)
            {
                lvrow = new ListViewItem(dt.Rows[i]["us_username"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["us_nombre"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["us_status"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["st_descripcion"].ToString());
                this.listViewUsurios.Items.Add(lvrow);
            }
        }
        public void validarUsuario_Buscar(string usuario,string nombre, string buscar)
        {
            string palabra = "";
            usuaValido = "";
                  
            if (usuario != "")  
            {
                for (int i = 0; i < listViewUsurios.Items.Count; i++)
                {
                    palabra = listViewUsurios.Items[i].SubItems[0].Text.ToLower();
                    bool existe = palabra.StartsWith(usuario.ToLower());

                    if (existe == true)
                    {
                        usuaValido = "usuario valido";
                        _nombre = listViewUsurios.Items[i].SubItems[1].Text.ToString().Trim();
                        _descripion = listViewUsurios.Items[i].SubItems[3].Text.ToString().Trim();
                        _usuario = listViewUsurios.Items[i].SubItems[0].Text.ToString().Trim();
                        listViewUsurios.Items[i].SubItems[0].BackColor = Color.LightSeaGreen;
                        pos = i;
                        return;

                    }
                }
            } 
            else if (nombre != "")
            {
                for (int i = 0; i < listViewUsurios.Items.Count; i++)
                {
                    palabra = listViewUsurios.Items[i].SubItems[1].Text.ToLower();
                    bool existe = palabra.StartsWith(nombre.ToLower());

                    if (existe == true)
                    {
                        usuaValido = "usuario valido";
                        _usuario = listViewUsurios.Items[i].SubItems[0].Text.ToString().Trim();
                        _nombre = listViewUsurios.Items[i].SubItems[1].Text.ToString().Trim();
                        _descripion = listViewUsurios.Items[i].SubItems[3].Text.ToString().Trim();
                        listViewUsurios.Items[i].SubItems[0].BackColor = Color.LightSeaGreen;
                        pos = i;
                        return;
                    }
                    
                }
            }
        }
      

        public void cerrar()
        {
            estado = "cerrar";
            this.Hide();
        }
        public void ActualizarListview(string accion)
        {
            switch (accion)
            {

                case "agregar":
                    lvrow = new ListViewItem(frmUsuarioPruebaEstilo.user.ToString().Trim());
                    lvrow.SubItems.Add(frmUsuarioPruebaEstilo.nomb.ToString().Trim());
                    lvrow.SubItems.Add(frmUsuarioPruebaEstilo.estad.ToString().Trim());
                    lvrow.SubItems.Add(frmUsuarioPruebaEstilo.descripcion.ToString().Trim());
                    listViewUsurios.Items.Add(lvrow);
                    num_usuarios++;
                    break;

                case "editar":
                    validarUsuario_Buscar(frmUsuarioPruebaEstilo.user, "", "buscar");
                    listViewUsurios.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
                    listViewUsurios.Items[pos].SubItems[1].Text = frmUsuarioPruebaEstilo.nomb.ToString().Trim();
                    listViewUsurios.Items[pos].SubItems[2].Text = frmUsuarioPruebaEstilo.estad.ToString().Trim();
                    listViewUsurios.Items[pos].SubItems[3].Text = frmUsuarioPruebaEstilo.descripcion.ToString().Trim();
                    break;
                case "eliminar":
                    validarUsuario_Buscar(frmUsuarioPruebaEstilo.user, "", "buscar");
                    listViewUsurios.Items[pos].SubItems[0].BackColor = Color.WhiteSmoke;
                    listViewUsurios.Items.RemoveAt(pos);
                    pos = 0;
                    num_usuarios--;
                    break;

            }
        }

        public void AplicarIdioma()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
            //Titulo Formulario
            this.Text = StringResources.TablaUsuario;

            //Titulo
            this.lblTitulo.Text = StringResources.TablaUsuario;

            //Label
            this.lblUsuario.Text = StringResources.Usuario;
            this.lblNombre.Text = StringResources.Nombre;

            //Botones
            this.btoBuscar.Text = StringResources.btnBuscar;
            this.btoAceptar.Text = StringResources.btoAceptar;
            this.btoSalir.Text = StringResources.btnSalir;

            //listview
            this.Usuario.Text = StringResources.Usuario;
            this.Nombre.Text = StringResources.Nombre;
            // this.Estatus = StringResources.
            this.Descripcion.Text = StringResources.Nombre;
        }
    }
}
