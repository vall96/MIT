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
    public partial class frmTbUsuariosElimi : Form
    {
        public frmPrincipal ventPrincipal = new frmPrincipal();
        private clsUsuario lstview = new clsUsuario();
        private clsUsuario Usua = new clsUsuario();
        frmUsuariosEliminados ventUsuariosElimi;
        int pos=0, num_usuarios = 0;
        ListViewItem lvrow;
        string nomb = "", usua = "";
        public static string estadoactual = "", usuaValido = "";
        public static string estado = "", _usuario, _nombre = "", _descripion = "";
        ListView.SelectedListViewItemCollection cot_lv;

        public string mensajeText = "", mensajeCaption = "";
        public static string tipoPais = "";
        public string[,] datos = new string[1, 4];

        public delegate void pasar(string[,] dato);        //firma tipo de metodo
        public event pasar pasado;
        public frmTbUsuariosElimi()
        {
            InitializeComponent();
            this.txtUsuario.Enabled = true;        
            this.BtoEliminarTodo.Enabled = true;            
            Cargar_listViewUsuaEliminados();

            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();
        }

        public void cambiarEstado(string estado, string fomulario)
        {
            switch (estado)
            {
                case "inicio":
                    estadoactual = estado;
                    //funcion_inicio();
                    break;


                case "salir":
                    this.Close();
                    break;

                case "buscar":
                   // BuscarUsuario_Eliminado();
                    break;

                case "cancelar":
                    funcion_cancelar();
                    break;
            }


        }
        public void BuscarUsuario_Eliminado(string usuario, string nombre, string buscar)
        {
            string palabra = "";
            usuaValido = "";
            estadoactual = "buscar";
            if (usuario != "")
            {       
    
                //BUSCAR DESDE LIST VIEW
                for (int i = 0; i <lstViewUsuaElimi.Items.Count; i++)
                {
                    palabra = lstViewUsuaElimi.Items[i].SubItems[0].Text.ToLower();
                    bool existe = palabra.StartsWith(usuario.ToLower());
                    if (existe == true)
                    {
                        _usuario = lstViewUsuaElimi.Items[i].SubItems[0].Text;
                        _nombre = lstViewUsuaElimi.Items[i].SubItems[1].Text;
                        _descripion = lstViewUsuaElimi.Items[i].SubItems[3].Text;
                        usuaValido = "usuario valido";
                        lstViewUsuaElimi.Items[i].SubItems[0].BackColor = Color.LightSeaGreen;
                        pos = i;
                        return;
                    }
                    //if (lstViewUsuaElimi.Items[i].SubItems[0].Text == usuario)
                    //{
                    //    _usuario = lstViewUsuaElimi.Items[i].SubItems[0].Text;
                    //    _nombre = lstViewUsuaElimi.Items[i].SubItems[1].Text;
                    //    _descripion = lstViewUsuaElimi.Items[i].SubItems[3].Text;
                    //    usuaValido = "usuario valido";
                    //    lstViewUsuaElimi.Items[i].SubItems[0].BackColor = Color.LightSeaGreen;
                    //    pos = i;
                    //}

                }

            }
            else if (nombre != "")
            {
                for (int i = 0; i < lstViewUsuaElimi.Items.Count; i++)
                {
                    palabra = lstViewUsuaElimi.Items[i].SubItems[1].Text.ToLower();
                    bool existe = palabra.StartsWith(nombre.ToLower());

                    if (existe == true)
                    {
                        _usuario = lstViewUsuaElimi.Items[i].SubItems[0].Text;
                        _nombre = lstViewUsuaElimi.Items[i].SubItems[1].Text;
                        _descripion = lstViewUsuaElimi.Items[i].SubItems[3].Text;
                        usuaValido = "usuario valido";
                        lstViewUsuaElimi.Items[i].SubItems[0].BackColor = Color.LightSeaGreen;
                        pos = i;
                        return;
                    }


                    //if (lstViewUsuaElimi.Items[i].SubItems[1].Text == nombre)
                    //{
                    //    _usuario = lstViewUsuaElimi.Items[i].SubItems[0].Text;
                    //    _nombre = lstViewUsuaElimi.Items[i].SubItems[1].Text;
                    //    _descripion = lstViewUsuaElimi.Items[i].SubItems[3].Text;
                    //    usuaValido = "usuario valido";
                    //    lstViewUsuaElimi.Items[i].SubItems[0].BackColor = Color.LightSeaGreen;
                    //    pos = i;
                    //}

                }
            }

        }   
    
        public void Cargar_listViewUsuaEliminados()
        {
            this.lstViewUsuaElimi.Items.Clear();
            DataTable dt = new DataTable();
            dt = lstview.Listado_Eliminados();
            num_usuarios = dt.Rows.Count;

            for (int i = 0; i < num_usuarios; i++)
            {
                lvrow = new ListViewItem(dt.Rows[i]["us_username"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["us_nombre"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["us_status"].ToString());
                lvrow.SubItems.Add(dt.Rows[i]["st_descripcion"].ToString());
                this.lstViewUsuaElimi.Items.Add(lvrow);
            }

        }

        private void funcion_cancelar()
        {
            txtUsuario.Text = "";
            //txtStatusElim.Text = "";
            //txtNombreElim.Text = "";
            //this.btoEliminar.Enabled = false;
            //this.btoRestaurar.Enabled = false;
        }         
     
    
        public void DesabilitarBotones()
        {
            this.txtUsuario.Enabled = false;
            this.BtoEliminarTodo.Enabled = false;
            //this.txtStatusElim.Enabled = false;
        }     
        
        private void btoEliminar_Click(object sender, EventArgs e)
        {
            if (usuaValido == "usuario valido")
            {
                string msj = "";

                DialogResult respuesta;
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.frmUsuariosEliminados_messDeseaEliminarUsuario;
                mensajeCaption = StringResources.ValidacióndeEliminación;

                respuesta = MessageBox.Show(mensajeText + txtUsuario.Text.ToString().Trim() + " ?", mensajeCaption,
                MessageBoxButtons.YesNo);

                if (respuesta == DialogResult.Yes)
                {
                    Usua.m_username = txtUsuario.Text.ToString().Trim();
                    msj = Usua.EliminarUsuario_Permanente();

                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    mensajeCaption = StringResources.ValidacióndeEliminación;

                    MessageBox.Show(msj, mensajeCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    for (int i = 0; i < num_usuarios; i++)
                    {
                        if (lstViewUsuaElimi.Items[i].SubItems[0].Text == this.txtUsuario.Text)
                        {
                            lstViewUsuaElimi.Items.RemoveAt(i);
                            num_usuarios--;
                            // listViewUsurios.Items.Refresh();
                            funcion_cancelar();
                        }
                    }
                }
            }
        }


        private void btoSalir_Click(object sender, EventArgs e)
        {
            //ventUsuariosElimi = new frmUsuariosEliminados();
            //ventUsuariosElimi.Show();
            frmUsuariosEliminados.ventana++;
            this.Hide();
        }

        private void lstViewUsuaElimi_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.DarkOrange, e.Bounds);
            e.DrawText();
        }

        private void lstViewUsuaElimi_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            if (estado == "cerrar")
            {
                this.Hide();
                return;
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void btoAceptar_Click(object sender, EventArgs e)
        {
            if (lstViewUsuaElimi.SelectedItems.Count > 0)
            {
                datosSeleccionados();
            }
            else
            {
                if (estado == "buscar")
                {
                    //frmUsuarioPruebaEstilo.MdiParent = ventPrincipal;           //OJOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                    usuaValido = "usuario valido";
                    ventUsuariosElimi.HabilitarBotones();
                    //ventPrincipal.accionesFormularios("FrmTbUsuariosPrueba", "inicial");
                    // ventUsuariosElimi.Show();
                    datos[0, 0] = _usuario;
                    datos[0, 1] = _nombre;
                    datos[0, 2] = _descripion;
                    pasado(datos);
                   
                }
                else
                {
                    //frmUsuarioPruebaEstilo.Location = new System.Drawing.Point(0, 75);
                   // ventUsuariosElimi.Show();
                    ventUsuariosElimi.FuncionInicio();
                }
            }

            this.Hide();
        }

        public void datosSeleccionados()
        {
            if (lstViewUsuaElimi.SelectedItems.Count > 0)
            {
                _usuario = lstViewUsuaElimi.SelectedItems[0].Text;
                _nombre = lstViewUsuaElimi.SelectedItems[0].SubItems[1].Text;
                _descripion = lstViewUsuaElimi.SelectedItems[0].SubItems[3].Text;

                //ventUsuariosElimi.cargarDatos();
                //frmUsuarioPruebaEstilo.MdiParent = ventPrincipal;           //OJOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                // ventUsuariosElimi.Show();
                datos[0, 0] = _usuario;
                datos[0, 1] = _nombre;
                datos[0, 2] = _descripion;
                pasado(datos);
                usuaValido = "usuario valido";
                //ventUsuariosElimi.HabilitarBotones();
                this.Hide();

            }
            else
            {
               // ventUsuariosElimi.MdiParent = ventPrincipal;           //OJOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                //ventUsuariosElimi.Show();
                return;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                lstViewUsuaElimi.Items[pos].SubItems[0].BackColor = Color.White;
                FuncionBuscar();
                
            }
        }

        private void lstViewUsuaElimi_SelectedIndexChanged(object sender, EventArgs e)
        {
            cot_lv = this.lstViewUsuaElimi.SelectedItems;  //llevar el item seleccionado
            foreach (ListViewItem campos_lv in cot_lv)      //realiza la busqueda
            {               
                _usuario = txtUsuario.Text;
                _nombre = txtNombre.Text;
                _descripion = campos_lv.SubItems[3].Text;          
            }
        }

        private void BtoEliminarTodo_Click(object sender, EventArgs e)
        {
            string msj = "";
            DialogResult respuesta;

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            mensajeText = StringResources.frmUsuariosEliminados_messDeseaEliminarTODOSlosUsuarios;
            mensajeCaption = StringResources.ValidacióndeEliminación;


            respuesta = MessageBox.Show(mensajeText, mensajeCaption,
            MessageBoxButtons.YesNo);

            if (respuesta == DialogResult.Yes)
            {
                msj = Usua.EliminarUsuarios_Todos();
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                mensajeCaption = StringResources.ValidacióndeEliminación;

                MessageBox.Show(msj, mensajeCaption,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                lstViewUsuaElimi.Items.Clear();
                this.BtoEliminarTodo.Enabled = false;
            }
        }

        private void lstViewUsuaElimi_DoubleClick(object sender, EventArgs e)
        {
            datosSeleccionados();
        }
        

        private void txtUsuarioElim_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            
            {
                lstViewUsuaElimi.Items[pos].SubItems[0].BackColor = Color.White;
                FuncionBuscar();
                //BuscarUsuario_Eliminado();
                
                
            }
        }

        private void lstViewUsuaElimi_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if(lstViewUsuaElimi.Sorting == SortOrder.Ascending)
            {
                lstViewUsuaElimi.Sorting = SortOrder.Descending;
                lstViewUsuaElimi.Sort();
            }
            else
            {
                lstViewUsuaElimi.Sorting = SortOrder.Ascending;
                lstViewUsuaElimi.Sort();
            }
        }

        private void botBuscar_Click(object sender, EventArgs e)
        {
            lstViewUsuaElimi.Items[pos].SubItems[0].BackColor = Color.White;
            FuncionBuscar();
            ventUsuariosElimi.cargarDatos();
        }

        private void FuncionBuscar()
        {
            estado = "buscar";
            if (txtUsuario.Text == "" && txtNombre.Text == "")
            {
                // MessageBox.Show("Debe ingresar un Usuario o nombre para realizar la busqueda",
                //"Error de Validacion", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                // this.txtUsuario.Focus();
                return;
                // usuaValido = "no";
            }
            else if ((txtUsuario.Text != "" && txtNombre.Text != ""))
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                mensajeText = StringResources.No_se_puede_realizar_la_busqueda_con_todos_los_campos_llenos;
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
                    usua = txtUsuario.Text;
                    nomb = "";
                    BuscarUsuario_Eliminado(usua, nomb, estado);
                }
                else
                {
                    usua = "";
                    nomb = txtNombre.Text;
                    BuscarUsuario_Eliminado(usua, nomb, estado);

                }
                if (usuaValido == "usuario valido")
                {
                   // frmUsuarioPruebaEstilo.cargarDatos();
             
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
            txtNombre.Text = "";
            txtUsuario.Text = "";
        }
        private void frmUsuariosEliminados_Load(object sender, EventArgs e)
        {
            LimpiarCajas();
            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();
            FuncionInicio();
            this.lstViewUsuaElimi.SelectedItems.Clear();
            this.Location = new System.Drawing.Point(710, 100);
            this.lstViewUsuaElimi.FullRowSelect = true;
            lstViewUsuaElimi.OwnerDraw = true;
            ventUsuariosElimi = new frmUsuariosEliminados();
            
        }

        public void FuncionInicio()
        {
            if (lstViewUsuaElimi.Items.Count > 0)
            {
                lstViewUsuaElimi.Items[pos].SubItems[0].BackColor = Color.White;    //si existe alguna fila subrayada limpiar el resaltado
                return;
            }
            else
            {
                this.BtoEliminarTodo.Enabled = false;
                this.btoBuscar.Enabled = false;
                this.txtNombre.Enabled = false;
                this.txtUsuario.Enabled = false;
            }
        }
        public void actualizarlsv(string accion)
        {
            switch (accion)
            {
                case "eliminar":
                    BuscarUsuario_Eliminado(frmUsuariosEliminados.user, "", "buscar");
                    lstViewUsuaElimi.Items[pos].SubItems[0].BackColor = Color.White;
                    lstViewUsuaElimi.Items.RemoveAt(pos);
                    pos = 0;
                    num_usuarios--;
                    break;
            }
        }

        public void AplicarIdioma()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);

            this.lblUsuario.Text = StringResources.Usuario;
            this.lblNombre.Text = StringResources.Nombre;

            this.lblTituloPanel.Text = StringResources.UsuariosEliminados;

            this.Text = StringResources.UsuariosEliminados;

            this.BtoEliminarTodo.Text = StringResources.BtoEliminarTodo_Text;
            this.btoAceptar.Text = StringResources.btoAceptar;
            this.btoSalir.Text = StringResources.btnSalir;
            this.btoBuscar.Text = StringResources.btnBuscar;

            this.usuario.Text = StringResources.Usuario;
            this.nombre.Text = StringResources.Nombre;
            this.Descripcion.Text = StringResources.Nombre;
        }

    }
}
