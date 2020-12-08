using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Security.Cryptography;
using CultureResources;
using CapaLogicaNegocios;


//using CultureResources;


namespace CapaPresentacion
{
    public partial class frmPrincipal : Form
    {

        public string[,] formulariosactivos = new string[2, 4];     //se va a controlar que se abrab 4 

        //ventanas, (4 filas), alli tengo el nombre del fomulario y el estado)
        public static string tipoPais = "", validar = "";
        public string usuarioRegistro = "", mensajeText = "", mensajeCaption ="";
        public int numform = 0, formX, formY, maxform = 4;
        public frmStaEliminados venStatusEliminados;     
        public frmTbUsuarioPersonalizada venTbUsuarios;        
        public frmRegristroUsuario venRegistro;
        public frmUsuarioPruebaEstilo venPruebaEstilo;
        public frmStaUsuario ventbStatus; 
        public string actvFor, valido;
        string estadoInicial = "abrir", estadoFormActivo;
        public frmPrincipal venPrincipal;
        public static string activoForm, esatadoaActiveForm,estadoPrincipal;
        public string estadoPrueba;
        public frmUsuariosEliminados venTbUsuariosElimados;
        public static string nombreBD = "";
        frmValidarClaveVieja ventClaveVieja;
        frmCambiarRespuestas ventCambiarResp;
        frmEmpresas ventEmpresas;
        frmMoneda ventMoneda;
        frmSucursales ventSucursales;
        frmAlmacenes ventAlmacenes;
        frmRelacionSucAlm ventRelacionSucAlm;
        frmProveedores ventProbedores;
        frmArticulos ventArticulos;
        frmTbSucursales ventSucursal;
        frmTbAlmacenes ventTbAlmacenes;
        frmUnidades venUnidades;
        frmCategoria ventCategoria;
        frmSubCategoria ventSubCateg;
        frmProcedencia ventprocedencia;
        frmArticulosCompuestos ventCompuestos;
        frmMaquinas venMaquinas;
        frmAtributos venAtributos;
        frmEstatusdeMaquina venEstatMaquina;
        frmFallasMaquinas venFallasMaquinas;
        frmPerfilesEmpleados venPerfilEmpleados;
        frmGastosFabrica venGatosFabrica;
        frmTareas venTareas;
        frmCedulaDeProducto ventCedulaProd;
        frmPropiedadesSistema ventPropiedades;
        MovDeInventario VentMovInventario;
        frmOrdenProduccion VentOrdProduccion;
        public frmPrincipal()
        {
            InitializeComponent();
            
            //tipoPais = idioma;
            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();
            funcionInicio();
            
        }
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            tipoPais = frmRegristroUsuario.tipoPais;
            nombreBD = "Digitel";//frmEmpresaSucursursal.nombreBd;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();
        }
        private void funcionInicio()
        {
            this.tSpBtnSucAlm.Text = "Sucursales/\nAlmacenes";
            this.tSpTablas.Visible = false;
            this.tSpnicio.Visible = false;
            this.tSpMantenimiento.Visible = false;
            this.tSpAdministracion.Visible = false;
          //  this.tSmtablas.Enabled = false;
            this.tSmMantenimiento.Enabled = false;
        }
        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            accionesFormularios("FrmTbUsuarios", "inicial");
            control_formulariosActivos("abrir", "FrmTbUsuarios", "inicio");
        }
                
        private void usuariosStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {                
            accionesFormularios("FrmTbStatus", "inicial");
            control_formulariosActivos("abrir", "FrmTbStatus", "inicio");            
        }

        private void toolStripBtoSalir_Click(object sender, EventArgs e)
        {
            accionesFormularios(actvFor, "salir");
            control_formulariosActivos("cerrar", actvFor, "");
         //   this.toolStrip1.Visible = false;
        }
        
        public static void formActivo (string formulario, string estado)
        {
            activoForm = formulario;
            esatadoaActiveForm = estado;
        }
        public void formularios (string formulario)
        {
            switch(formulario)
            {
                case "FrmTbUsuarios":
                    actvFor = "FrmTbUsuarios";

                break;

                case "FrmTbStatus":
                    actvFor = "FrmTbStatus";
                break;
            }
        }
        public void accionesFormularios(string formulario, string estado)
        {
            switch (formulario)
            {


                
                case "frmOrdProduccion":
                    if (estado == "inicial")
                {
                        VentOrdProduccion = new frmOrdenProduccion();
                Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmOrdenProduccion);
                if (frm != null)
                {
                    frm.BringToFront();
                    return;
                }
                else
                {
                    VentOrdProduccion.MdiParent = this;
                    VentOrdProduccion.Show();
                }
            }
            break;
                case "frmPropiedadesSistema":
                    if (estado == "inicial")
                    {
                        ventPropiedades = new frmPropiedadesSistema();
                        Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmPropiedadesSistema);
                        if (frm != null)
                        {
                            frm.BringToFront();
                            return;
                        }
                        else
                        {
                            ventPropiedades.MdiParent = this;
                            ventPropiedades.Show();
                        }
                    }
                    break;
                case "frmCedulaDeProducto":
                    if (estado == "inicial")
                    {
                        ventCedulaProd = new frmCedulaDeProducto();
                        Form frm2 = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCedulaDeProducto);
                        if (frm2 != null)
                        {
                            frm2.BringToFront();
                            return;
                        }
                        else
                        {
                            ventCedulaProd.MdiParent = this;
                            ventCedulaProd.Show();
                        }
                    }

                    break;

                case "frmGastosFabrica":
                    if (estado == "inicial")
                    {
                        venGatosFabrica = new frmGastosFabrica();
                        Form frm2 = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmGastosFabrica);
                        if (frm2 != null)
                        {
                            frm2.BringToFront();
                            return;
                        }
                        else
                        {
                            venGatosFabrica.MdiParent = this;
                            venGatosFabrica.Show();
                        }
                    }
                    break;

                case "frmTareas":
                    if (estado == "inicial")
                    {
                        venTareas = new frmTareas();
                        Form frm2 = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmTareas);
                        if (frm2 != null)
                        {
                            frm2.BringToFront();
                            return;
                        }
                        else
                        {
                            venTareas.MdiParent = this;
                            venTareas.Show();
                        }
                    }
                    break;

                case "frmFallasMaquinas":
                    if (estado == "inicial")
                    {
                        venFallasMaquinas = new frmFallasMaquinas();
                        Form frm2 = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmAtributos);
                        if (frm2 != null)
                        {
                            frm2.BringToFront();
                            return;
                        }
                        else
                        {
                            venFallasMaquinas.MdiParent = this;
                            venFallasMaquinas.Show();
                        }
                    }
                    break;
                case "frmPerfilEmpleados":
                    if (estado == "inicial")
                    {
                        venPerfilEmpleados = new frmPerfilesEmpleados();
                        Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmUsuarioPruebaEstilo);
                        if (frm != null)
                        {
                            frm.BringToFront();
                            return;
                        }
                        else
                        {
                            venPerfilEmpleados.MdiParent = this;
                            venPerfilEmpleados.Show();
                        }
                    }
                    break;

                case "FrmTbUsuariosPrueba":
                    if (estado == "inicial")
                    {
                        venPruebaEstilo = new frmUsuarioPruebaEstilo();
                        Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmUsuarioPruebaEstilo);
                        if (frm != null)
                        {
                            frm.BringToFront();
                            return;
                        }
                        else
                        {
                            venPruebaEstilo.MdiParent = this;
                            venPruebaEstilo.Show();
                        }
                    }
                    break;

                case "FrmTbStatus":
                    if (estado == "inicial")
                    {
                        ventbStatus = new frmStaUsuario();
                        Form frm2 = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmStaUsuario);
                        if (frm2 != null)
                        {


                            frm2.BringToFront();
                            return;
                        }
                        else
                        {
                            ventbStatus.MdiParent = this;
                            ventbStatus.Show();
                        }
                    }

                    break;

                case "FrmTbUsuariosEliminados":
                    if (estado == "inicial")
                    {
                        venTbUsuariosElimados = new frmUsuariosEliminados();
                        Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmUsuariosEliminados);
                        if (frm != null)
                        {
                            frm.BringToFront();
                            return;
                        }
                        else
                        {
                            venTbUsuariosElimados.MdiParent = this;
                            venTbUsuariosElimados.Show();
                        }

                    }

                    break;

                case "FrmStatusEliminados":
                    if (estado == "inicial")
                    {
                        venStatusEliminados = new frmStaEliminados();
                        Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmStaEliminados);
                        if (frm != null)
                        {
                            frm.BringToFront();
                            return;
                        }
                        else
                        {
                            venStatusEliminados.MdiParent = this;
                            venStatusEliminados.Show();
                        }

                    }
                    break;
                case "Frmvalidarclave":
                    if (estado == "inicial")
                    {
                        ventClaveVieja = new frmValidarClaveVieja();
                        // ventClaveVieja.MdiParent = this;
                        ventClaveVieja.ShowDialog();
                    }
                    break;
                case "FrmEmpresas":
                    if (estado == "inicial")
                    {
                        ventEmpresas = new frmEmpresas();
                        Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmEmpresas);
                        if (frm != null)
                        {
                            frm.BringToFront();
                            return;
                        }
                        else
                        {
                            ventEmpresas.MdiParent = this;
                            ventEmpresas.Show();
                        }

                    }
                    break;

                case "FrmMonedas":
                    if (estado == "inicial")
                    {
                        
                        frmEmpresas.statusLsv = 0;
                        frmSucursales.formSucursales = "";
                        ventMoneda = new frmMoneda();
                        Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmMoneda);
                        if (frm != null)
                        {
                            frm.BringToFront();
                            return;
                        }
                        else
                        {
                            ventMoneda.MdiParent = this;
                            ventMoneda.Show();
                        }

                    }
                    break;

                case "FrmSucursales":
                    if (estado == "inicial")
                    {
                        ventSucursales = new frmSucursales();
                        Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmSucursales);
                        if (frm != null)
                        {
                            frm.BringToFront();
                            return;
                        }
                        else
                        {
                            ventSucursales.MdiParent = this;
                            ventSucursales.Show();
                        }

                    }
                    break;
                case "FrmAlmaneces":
                    if (estado == "inicial")
                    {
                        ventAlmacenes = new frmAlmacenes();
                        Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmAlmacenes);
                        if (frm != null)
                        {
                            frm.BringToFront();
                            return;
                        }
                        else
                        {
                            ventAlmacenes.MdiParent = this;
                            ventAlmacenes.Show();
                        }

                    }
                    break;

                case "frmRelacionSucAlm":
                    if (estado == "inicial")
                    {
                        ventRelacionSucAlm = new frmRelacionSucAlm();
                        Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmRelacionSucAlm);
                        if (frm != null)
                        {
                            frm.BringToFront();
                            return;
                        }
                        else
                        {
                            ventRelacionSucAlm.MdiParent = this;
                            ventRelacionSucAlm.Show();
                        }
                    }
                    break;

                case "frmProveedores":
                    if (estado == "inicial")
                    {
                        ventProbedores = new frmProveedores();
                        Form frm2 = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmProveedores);
                        if (frm2 != null)
                        {
                            frm2.BringToFront();
                            return;
                        }
                        else
                        {
                            ventProbedores.MdiParent = this;
                            ventProbedores.Show();
                        }
                    }
                    break;
                case "frmArticulos":
                    if (estado == "inicial")
                    {
                        ventArticulos = new frmArticulos();
                        Form frm2 = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmArticulos);
                        if (frm2 != null)
                        {
                            frm2.BringToFront();
                            return;
                        }
                        else
                        {
                            ventArticulos.MdiParent = this;
                            ventArticulos.Show();
                        }
                    }
                    break;
                //  FrmTbSucursales
                case "FrmTbSucursales":
                    if (estado == "inicial")
                    {
                        ventSucursal = new frmTbSucursales();
                        Form frm2 = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmTbSucursales);
                        if (frm2 != null)
                        {
                            frm2.BringToFront();
                            return;
                        }
                        else
                        {
                            ventSucursal.MdiParent = this;
                            ventSucursal.Show();
                        }
                    }
                    break;

                case "FrmTbAlmacenes":
                    if (estado == "inicial")
                    {
                        ventTbAlmacenes = new frmTbAlmacenes();
                        Form frm2 = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmTbAlmacenes);
                        if (frm2 != null)
                        {
                            frm2.BringToFront();
                            return;
                        }
                        else
                        {
                            ventTbAlmacenes.MdiParent = this;
                            ventTbAlmacenes.Show();
                        }
                    }
                    break;
                //FrmUnidades

                case "FrmUnidades":
                    if (estado == "inicial")
                    {
                        venUnidades = new frmUnidades();
                        Form frm2 = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmUnidades);
                        if (frm2 != null)
                        {
                            frm2.BringToFront();
                            return;
                        }
                        else
                        {
                            venUnidades.MdiParent = this;
                            venUnidades.Show();
                        }
                    }
                    break;
                //FrmCategoria
                case "FrmCategoria":
                    if (estado == "inicial")
                    {
                        ventCategoria = new frmCategoria();
                        Form frm2 = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmCategoria);
                        if (frm2 != null)
                        {
                            frm2.BringToFront();
                            return;
                        }
                        else
                        {
                            ventCategoria.MdiParent = this;
                            ventCategoria.Show();
                        }
                    }
                    break;
                //FrmSubCategoria
                case "FrmSubCategoria":
                    if (estado == "inicial")
                    {
                        ventSubCateg = new frmSubCategoria();
                        Form frm2 = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmSubCategoria);
                        if (frm2 != null)
                        {
                            frm2.BringToFront();
                            return;
                        }
                        else
                        {
                            ventSubCateg.MdiParent = this;
                            ventSubCateg.Show();
                        }
                    }
                    break;
                //FrmProcedencia
                case "FrmProcedencia":
                    if (estado == "inicial")
                    {
                        ventprocedencia = new frmProcedencia();
                        Form frm2 = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmProcedencia);
                        if (frm2 != null)
                        {
                            frm2.BringToFront();
                            return;
                        }
                        else
                        {
                            ventprocedencia.MdiParent = this;
                            ventprocedencia.Show();
                        }
                    }
                    break;
                //FrmArtCompuestos
                case "FrmArtCompuestos":
                    if (estado == "inicial")
                    {
                        ventCompuestos = new frmArticulosCompuestos();
                        Form frm2 = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmArticulosCompuestos);
                        if (frm2 != null)
                        {
                            frm2.BringToFront();
                            return;
                        }
                        else
                        {
                            ventCompuestos.MdiParent = this;
                            ventCompuestos.Show();
                        }
                    }
                    break;
                //
                case "FrmMaquinas":
                    if (estado == "inicial")
                    {
                        venMaquinas = new frmMaquinas();
                        Form frm2 = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmMaquinas);
                        if (frm2 != null)
                        {
                            frm2.BringToFront();
                            return;
                        }
                        else
                        {
                            venMaquinas.MdiParent = this;
                            venMaquinas.Show();
                        }
                    }

                    break;

                case "FrmAtributos":
                    if (estado == "inicial")
                    {
                        venAtributos = new frmAtributos();
                        Form frm2 = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmAtributos);
                        if (frm2 != null)
                        {
                            frm2.BringToFront();
                            return;
                        }
                        else
                        {
                            venAtributos.MdiParent = this;
                            venAtributos.Show();
                        }
                    }

                    break;
                case "FrmEstatusDeMaquina":
                    if (estado == "inicial")
                    {
                        venEstatMaquina = new frmEstatusdeMaquina();
                        Form frm2 = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is frmEstatusdeMaquina);
                        if (frm2 != null)
                        {
                            frm2.BringToFront();
                            return;
                        }
                        else
                        {
                            venEstatMaquina.MdiParent = this;
                            venEstatMaquina.Show();
                        }
                    }

                    break;
                    //entrada de invntario
                    case "frmMovimientoDeInventario":
                    if (estado == "inicial")
                    {
                        VentMovInventario = new MovDeInventario();
                        Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is MovDeInventario);
                        if (frm != null)
                        {
                            frm.BringToFront();
                            return;
                        }
                        else
                        {
                            VentMovInventario.MdiParent = this;
                            VentMovInventario.Show();
                        }
                    }
                    break;
            }
        }

        public void control_formulariosActivos(string accion, string formulario, string estado)
        {
            switch (accion)
            {
                case "abrir":
                    formulariosactivos[0, numform] = formulario;            //ojo matriz [columna,fila], entonce se coloco columna=x, y fila=y
                    formulariosactivos[1, numform] = estado;
                    numform++;
                    //desabilitar el boton para evvitar que abra la misma ventana varias veces
                    desabilitarOpcionMenu(formulario);
                    actvFor = formulario;
                    estadoFormActivo = estado;
                    accionesBotones(actvFor, estado, "");
                    
                    break;

                case "cerrar":
                    if (numform == 1)
                    {
                        formulariosactivos[0, 0] = "";
                        formulariosactivos[1, 0] = "";
                        numform = 0;
                        //   habilitarOpcionMenu(formulario);
                        activoForm = "";
                        estadoFormActivo = "";
                    }
                    else
                    {
                        formX = 0; formY = 0;
                        while (formY < numform)
                        {
                            if (formulariosactivos[formX, formY] == formulario)
                            {
                                formulariosactivos[formX, formY] = "";
                                formulariosactivos[formX + 1, formY] = "";
                                numform--;
                            }
                            else
                            {
                                formY++;
                            }
                        }
                        //  habilitarOpcionMenu(formulario);
                        actvFor = formulariosactivos[formX, numform - 1];
                        estadoFormActivo = formulariosactivos[formX + 1, numform - 1];
                        accionesBotones(actvFor, estadoFormActivo, "");
                    }
                    habilitarOpcionMenu(formulario);
                    break;
            }
        }
        private void activarFormulario (string formulario)
        {
            switch (formulario)
            {
                case "FrmTbUsuarios":
                    venTbUsuarios.Activate();
                    break;
                case "FrmTbStatus":
                    ventbStatus.Activate();
                    break;
                case "FrmTbUsuariosPrueba":
                    venPruebaEstilo.Activate();
                    break;

                default:
                    break;
            }
        }
        public void habilitarOpcionMenu (string formulario)
        {
            switch (formulario)
            {
                //case "FrmTbUsuarios":
                //    this.usuariosToolStripMenuItem.Enabled = true;                    
                //break;

                //case "FrmTbStatus":
                //    this.usuariosStatusToolStripMenuItem.Enabled = true;
                //break;

                //case "FrmTbUsuaEliminados":
                //    this.toolStripusuariosEliminados.Enabled = true;
                //    break;
                case "FrmTbUsuariosPrueba":
                    estadoInicial = "reabrir";
                    //this.Hide();
                    this.tSpBtnEmpleados.Enabled = true;
                    this.tSpBtnCedula.Enabled = false;
                    this.tSpTablas.Refresh();
                    //this.toolStripBtoPrueba.Refresh();
                    this.Refresh();
                  
                    break;
            }
        }
        public void desabilitarOpcionMenu (string formulario)
        {
            switch (formulario)
            {
             
                case "FrmTbUsuariosPrueba":
                    this.tSpBtnEmpleados.Enabled = false;
                    break;

            }
                
        }

        public void accionesBotones(string formulario, string estado, string usuaValido)
        {
            switch (estado)
            { 

               case "inicio":
                    this.tSpTablas.Visible = true;
                 //   this.toolStripbtoUsuarios.Enabled = true;
                 //   this.toolStripBtoEstatus.Enabled = false;
                   
                    //ojo boton de tabla-usuario desabilitar
                 // this.usuariosToolStripMenuItem.Enabled = false;               
               break;

               case "agregar":
                    this.tSpTablas.Visible = true;
                 //   this.toolStripbtoUsuarios.Enabled = false;
                    this.tSpBtnCedula.Enabled = false;
                 
               break;

                case "buscar":
                    this.tSpTablas.Visible = true;
                    this.tSpTablas.Enabled=true;
                 //   this.toolStripbtoUsuarios.Enabled = false;
                //    this.toolStripBtoEditar.Enabled = true;

                    if (estado == "buscar")
                        
                    {
                      //  usuaValido = "usuario valido";
                        valido = usuaValido;
                        if (valido == "usuario valido")
                        {
                            
                            this.tSpBtnCedula.Enabled = true;
                        }
                        else
                        {
                            
                            this.tSpBtnCedula.Enabled = false;
                        }
                    }

                    break;

                case "editar":

                    this.tSpTablas.Visible = true;
                //    this.toolStripbtoUsuarios.Enabled = false;
                    this.tSpBtnCedula.Enabled = false;
                   
                break;

                case "cancelar":
                    this.tSpTablas.Visible = true;
                 //   this.toolStripbtoUsuarios.Enabled = true;
                    this.tSpBtnCedula.Enabled = false;
                  
                    break;

                  
               case "guardar":
                    //if (txtblanco !=1)
                    //{ 
                    this.tSpTablas.Visible = true;
                //    this.toolStripbtoUsuarios.Enabled = true;
                    this.tSpBtnCedula.Enabled = false;
                   
                    //}

                break;              
        
                case "eliminar":
                    this.tSpTablas.Visible = true;
                 //   this.toolStripbtoUsuarios.Enabled = true;
                    this.tSpBtnCedula.Enabled = false;
               
                break;
            }       
        }

        private void toolStripBtoAgregar_Click(object sender, EventArgs e)
        {
            accionesFormularios(actvFor, "agregar");
            accionesBotones(actvFor, "agregar","");
        }
        private void usuariosPruebaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //accionesFormularios("FrmTbUsuariosPrueba", "inicial");
            //control_formulariosActivos("abrir", "FrmTbUsuarios", "inicio");
        }
        private void toolStripBtnSalir_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            mensajeText = StringResources.frmRegistroUsuario_messCerrandoSistema;
            mensajeCaption = StringResources.frmRegistroUsuario_messCerrandoSistema;

            MessageBox.Show(mensajeText, mensajeCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.ExitThread();
        }
        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConrolToolBarActivo("inicio");
        }

        private void mantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConrolToolBarActivo("mantenimiento");
        }
        private void tablasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConrolToolBarActivo("tablas");
        }
        private void toolStripBtnUsuariosEliminados_Click_1(object sender, EventArgs e)
        {
            accionesFormularios("FrmTbUsuariosEliminados", "inicial");
        }

        private void toolStripBtnStatusEli_Click(object sender, EventArgs e)
        {
            accionesFormularios("FrmStatusEliminados", "inicial"); 
        }
        private void ConrolToolBarActivo(string toolbar)
        {
            switch (toolbar)
            {
                case "inicio":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);

                    this.tSpTablas.Visible = false;
                    this.tSpMantenimiento.Visible = false;
                    this.tSpnicio.Visible = true;
                    this.tSpAdministracion.Visible = false;
                    this.tSpEmpresas.Visible = false;
                    this.tSpAyuda.Visible = false;
                    this.tSpInventario.Visible = false;
                    this.tSpProcesos.Visible = false;
                    this.tSpReportes.Visible = false;
                    break;

                case "tablas":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    this.tSpTablas.Visible = true;
                    this.tSpMantenimiento.Visible = false;
                    this.tSpnicio.Visible = false;
                    this.tSpAdministracion.Visible = false;
                    this.tSpEmpresas.Visible = false;
                    this.tSpAyuda.Visible = false;
                    this.tSpInventario.Visible = false;
                    this.tSpProcesos.Visible = false;
                    this.tSpReportes.Visible = false;
                    break;

                case "mantenimiento":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);

                    this.tSpTablas.Visible = false;
                    this.tSpnicio.Visible = false;
                    this.tSpMantenimiento.Visible = true;
                    this.tSpAdministracion.Visible = false;
                    this.tSpEmpresas.Visible = false;
                    this.tSpAyuda.Visible = false;
                    this.tSpInventario.Visible = false;
                    this.tSpProcesos.Visible = false;
                    this.tSpReportes.Visible = false;
                    break;

                case "administracion":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);

                    this.tSpTablas.Visible = false;
                    this.tSpnicio.Visible = false;
                    this.tSpMantenimiento.Visible = false;
                    this.tSpAdministracion.Visible = true;
                    this.tSpEmpresas.Visible = false;
                    this.tSpAyuda.Visible = false;
                    this.tSpInventario.Visible = false;
                    this.tSpProcesos.Visible = false;
                    this.tSpReportes.Visible = false;
                    break;

                case "ninguno":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);

                    this.tSpTablas.Visible = false;
                    this.tSpnicio.Visible = false;
                    this.tSpMantenimiento.Visible = false;
                    this.tSpAdministracion.Visible = false;
                    this.tSpEmpresas.Visible = false;
                    this.tSpAyuda.Visible = false;
                    this.tSpInventario.Visible = false;
                    this.tSpProcesos.Visible = false;
                    this.tSpReportes.Visible = false;
                    break;

                case "empresas":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);

                    this.tSpTablas.Visible = false;
                    this.tSpnicio.Visible = false;
                    this.tSpMantenimiento.Visible = false;
                    this.tSpAdministracion.Visible = false;
                    this.tSpEmpresas.Visible = true;
                    this.tSpAyuda.Visible = false;
                    this.tSpInventario.Visible = false;
                    this.tSpProcesos.Visible = false;
                    this.tSpReportes.Visible = false;
                    break;

                case "ayuda":
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);

                    this.tSpTablas.Visible = false;
                    this.tSpnicio.Visible = false;
                    this.tSpMantenimiento.Visible = false;
                    this.tSpAdministracion.Visible = false;
                    this.tSpEmpresas.Visible = false;
                    this.tSpAyuda.Visible = true;
                    this.tSpInventario.Visible = false;
                    this.tSpProcesos.Visible = false;
                    this.tSpReportes.Visible = false;
                    break;

                case "inventario":
                    this.tSpTablas.Visible = false;
                    this.tSpnicio.Visible = false;
                    this.tSpMantenimiento.Visible = false;
                    this.tSpAdministracion.Visible = false;
                    this.tSpEmpresas.Visible = false;
                    this.tSpAyuda.Visible = false;
                    this.tSpInventario.Visible = true;
                    this.tSpProcesos.Visible = false;
                    this.tSpReportes.Visible = false;
                    break;

                case "procesos":
                    this.tSpTablas.Visible = false;
                    this.tSpnicio.Visible = false;
                    this.tSpMantenimiento.Visible = false;
                    this.tSpAdministracion.Visible = false;
                    this.tSpEmpresas.Visible = false;
                    this.tSpAyuda.Visible = false;
                    this.tSpInventario.Visible = false;
                    this.tSpProcesos.Visible = true;
                    this.tSpReportes.Visible = false;
                    break;

                case "reportes":
                    this.tSpTablas.Visible = false;
                    this.tSpnicio.Visible = false;
                    this.tSpMantenimiento.Visible = false;
                    this.tSpAdministracion.Visible = false;
                    this.tSpEmpresas.Visible = false;
                    this.tSpAyuda.Visible = false;
                    this.tSpInventario.Visible = false;
                    this.tSpProcesos.Visible = false;
                    this.tSpReportes.Visible = true;
                    break;


            }
        }
        private void toolStripBtnCambioSesion_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            mensajeText = StringResources.frmRegistroUsuario_messCerrandoSistema;
            mensajeCaption = StringResources.frmRegistroUsuario_messCerrandoSistema;

            MessageBox.Show(mensajeText, mensajeCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
          //  Application.ExitThread();
            venRegistro = new frmRegristroUsuario();
            venRegistro.Show();
            this.Close();
        }

        private void procesosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConrolToolBarActivo("procesos");
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConrolToolBarActivo("reportes");
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConrolToolBarActivo("ayuda");
        }

        private void TSMAdministracion_Click(object sender, EventArgs e)
        {
            ConrolToolBarActivo("administracion");
        }

        private void toSCambiarClave_Click(object sender, EventArgs e)
        {
            estadoPrincipal = "activo";
            accionesFormularios("Frmvalidarclave", "inicial");            
        }

        private void toSCambiarResp_Click(object sender, EventArgs e)
        {
            estadoPrincipal = "cambiarrespuestas";
            accionesFormularios("Frmvalidarclave", "inicial");
        }

        private void empresasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConrolToolBarActivo("empresas"); 
        }

        private void tSpBtnEmpresa_Click(object sender, EventArgs e)
        {
            accionesFormularios("FrmEmpresas", "inicial");
        }

        private void tSpBtnMoneda_Click(object sender, EventArgs e)
        {
            accionesFormularios("FrmMonedas", "inicial");
        }

        private void tSpBtnSucursal_Click(object sender, EventArgs e)
        {
            accionesFormularios("FrmTbSucursales", "inicial");
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripBtoPrueba_Click(object sender, EventArgs e)
        {
            accionesFormularios("frmPerfilEmpleados", "inicial");
        }

        private void toolStripAyuda_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ConrolToolBarActivo("ayuda");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            accionesFormularios("frmRelacionSucAlm", "inicial");
          
        }

        private void inventarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConrolToolBarActivo("inventario");
        }

        private void tSpBtnAProveedor_Click(object sender, EventArgs e)     //me queque en llamar a frmProveedores
        {
            accionesFormularios("frmProveedores", "inicial");
        }

        private void tSpBtnArticulos_Click(object sender, EventArgs e)
        {
            accionesFormularios("frmArticulos", "inicial");
        }

        private void tSpBtnSucursal2_Click(object sender, EventArgs e)
        {
            frmSucursales.nombreBd = nombreBD;     //por ahora
            accionesFormularios("FrmTbSucursales", "inicial");
        }

        private void tSpBtnMedida_Click(object sender, EventArgs e)
        {
            accionesFormularios("FrmUnidades", "inicial");

        }
     
        private void tSpBtnLinea_Click_1(object sender, EventArgs e)
        {
            accionesFormularios("FrmCategoria", "inicial");
        }

        private void tSpBtnSublinea_Click(object sender, EventArgs e)
        {
            accionesFormularios("FrmSubCategoria", "inicial");
        }

        private void tSpBtnProced_Click(object sender, EventArgs e)
        {
            accionesFormularios("FrmProcedencia", "inicial");
        }

        private void tSpBtnConfig_Click(object sender, EventArgs e)
        {

        }

        private void tSpBtnArticCom_Click(object sender, EventArgs e)
        {
            accionesFormularios("FrmArtCompuestos", "inicial");
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            accionesFormularios("FrmMaquinas", "inicial");
        }

        private void tSpBtnAtributos_Click(object sender, EventArgs e)
        {
            accionesFormularios("FrmAtributos", "inicial");
        }

        private void tSpBtnStatusMaquina_Click(object sender, EventArgs e)
        {
            accionesFormularios("FrmEstatusDeMaquina", "inicial");
        }

        private void tSpTablas_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tSpBtnFallasMaq_Click(object sender, EventArgs e)
        {
            accionesFormularios("frmFallasMaquinas", "inicial");
        }

        private void tSpBtnGastosFabri_Click(object sender, EventArgs e)
        {
            accionesFormularios("frmGastosFabrica", "inicial");
        }

        private void tSpBtnTareas_Click(object sender, EventArgs e)
        {
            accionesFormularios("frmTareas", "inicial");
        }

        private void tSpBtnPropiedadesSistema_Click(object sender, EventArgs e)
        {
            accionesFormularios("frmPropiedadesSistema", "inicial");
        }

        private void tSpBtnOrdenP_Click(object sender, EventArgs e)
        {
            accionesFormularios("frmOrdProduccion", "inicial");
        }

        private void tsbMovimientoDeInventario(object sender, EventArgs e)
        {
            accionesFormularios("frmMovimientoDeInventario", "inicial");
        }

        private void tSpBtnAlmacen2_Click(object sender, EventArgs e)
        {
            frmAlmacenes.nombreBd = nombreBD;     //por ahora
            validar = "si";
            accionesFormularios("FrmTbAlmacenes", "inicial");
            validar = "";
        }

        private void toolStripBtoBuscar_Click(object sender, EventArgs e)
        {
             accionesFormularios(actvFor,"buscar");
          //   accionesBotones(actvFor, "buscar", "");            
        }

        private void usuariosEliminadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            accionesFormularios("FrmTbUsuaEliminados", "inicial");
            control_formulariosActivos("abrir", "FrmTbUsuaEliminados", "inicio");
        }

        private void toolStripBtoEditar_Click(object sender, EventArgs e)
        {
            accionesFormularios("frmCedulaDeProducto", "inicial");
        }

        private void toolStripBtoCancelar_Click(object sender, EventArgs e)
        {
            accionesFormularios(actvFor, "cancelar");
            accionesBotones(actvFor, "cancelar", "");
        }

        private void toolStripBtoGuardar_Click(object sender, EventArgs e)
        {
            accionesFormularios(actvFor, "guardar");
            accionesBotones(actvFor, "guardar", "");
        }

        private void toolStripBtoEliminar_Click(object sender, EventArgs e)
        {
            accionesFormularios(actvFor, "eliminar");
            accionesBotones(actvFor, "eliminar", "");
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            mensajeText = StringResources.frmRegistroUsuario_messCerrandoSistema;
            mensajeCaption = StringResources.ErrordeValidacion;

            MessageBox.Show(mensajeText, mensajeCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.ExitThread();
        }

        private void AplicarIdioma()
        {
            //menu
            this.TSMAdministracion.Text = StringResources.Administración;
            this.reportesToolStripMenuItem.Text = StringResources.frmPrincipal_MenuStripReportes1;
            this.empresasToolStripMenuItem.Text = StringResources.Inicio_Empresa;
            this.inicioToolStripMenuItem.Text = StringResources.frmPrincipal_MenuStripInicio1;
            this.tSmtablas.Text = StringResources.frmPrincipal_MenuStripTablas1;
            this.procesosToolStripMenuItem.Text = StringResources.frmPrincipal_MenuStripProcesos1;
            this.tSmMantenimiento.Text = StringResources.frmPrincipal_MenuStripMantenimiento1;
            this.ayudaToolStripMenuItem.Text = StringResources.Ayuda;
            this.inventarioToolStripMenuItem.Text = StringResources.frmPrincipal_Inventario;

            //bto's
            this.toolStripBtnCambioSesion.Text = StringResources.frmPrincipalInicio_CambiarSesion;
            this.toolStripBtnUsuariosEliminados.Text = StringResources.UsuariosEliminados;
            this.toSCambiarClave.Text = StringResources.frmPrincipal_MenuStripCambiarClave;
            this.toSCambiarResp.Text = StringResources.frmPrincipal_MenuStripCambiarRespuestas;
            this.tSpBtnEmpresa.Text = StringResources.Empresa;
            this.tSpBtnMoneda.Text = StringResources.moneda;
            this.tSpBtnSucursal.Text = StringResources.Sucursales;
            this.btoAyuda.Text = StringResources.Ayuda;
            this.btoSoporte.Text = StringResources.Soporte;
            this.btoInfo.Text = StringResources.Informaciongeneral;
            this.tSpEmpresas.Text = StringResources.Empresa;
            this.toolStripBtnStatusEli.Text = StringResources.EstadosEliminados;          
            this.toolStripBtnSalir.Text = StringResources.frmPrincipalInicio_Salir;
            this.tSpBtnAlmacen.Text = StringResources.Almacenes;
            this.tSpBtnSucAlm.Text = StringResources.SucusalesAlmacenes;

            //------------------- btos VALERIE ----------------
            this.tSpBtnOrdenP.Text = StringResources.Orden_de_Produccion;
            this.tSpBtnRequisicion.Text = StringResources.Requisiciones;
            this.tspCierreOrden.Text = StringResources.CierredeOrden;
            this.tSpBtnEntregParc.Text = StringResources.EntregasParciales;
            this.tspDevoluc.Text = StringResources.Devoluciones;
            this.tSpBtnContrlMaq.Text = StringResources.ControldeMaquinas;
            this.tSpBtnFacturas.Text = StringResources.Facturas;
                this.TSMIfacturasDeVentas.Text = StringResources.FacturasdeVentas;
                this.TSMIfacturasDeCompra.Text = StringResources.FacturasdeCompra;

            this.tSpBtnCedula.Text = StringResources.CedulaDeProducto;
            this.tSpBtnCostos.Text = StringResources.CostoEstandar;
            this.tSpBtnTareas.Text = StringResources.Tarea;
            this.tspMaquina.Text = StringResources.Maquinas;
            this.tSpBtnEmpleados.Text = StringResources.PerfilesdeEmpleados;
            this.tSpBtnFallasMaq.Text = StringResources.MaquinaConFallas;
            this.tSpBtnGastosFabri.Text = StringResources.GastosDeFabricacion;
            this.tSpBtnAtributos.Text = StringResources.Atributos;
            this.tSpBtnStatusMaquina.Text = StringResources.EstatusDeMaquina;

            this.tSpBtnArticulos.Text = StringResources.Articulos;
            this.tSpBtnArticCom.Text = StringResources.ArticulosCompuestos;
            this.tSpBtnCategoria.Text = StringResources.Categoria;
            this.tSpBtnSubCategoria.Text = StringResources.SubCategoria;
            this.tSpBtnProceden.Text = StringResources.Procedencias;
            this.tSpBtnUniMedida.Text = StringResources.UnidadDeMedida;
            this.tSpBtnAlmacen2.Text = StringResources.Almacenes;
            this.tSpBtoProveedores.Text = StringResources.Proveedores;
            this.tSpBtnConfigIVA.Text = StringResources.ConfiguraciondeIVA;

            this.tSpBtnSucursal2.Text = StringResources.Sucursales;

            this.tSpBtnReportesInvent.Text = StringResources.frmPrincipal_Inventario;
            this.articulosTSMI.Text = StringResources.Articulos;
            this.TSMIherramientas.Text = StringResources.Herramientas;
            this.TSMIProducTerminados.Text = StringResources.ProductosTerminados;
            this.TSMICedulasDeProduccion.Text = StringResources.CedulasDeProduccion;

            this.tspBtoReporProducc.Text = StringResources.Produccion;
            this.TSMIOrdenesDeProduccion.Text = StringResources.Orden_de_Produccion;
            this.TSMIRequisiciones.Text = StringResources.Requisiciones;
            this.TSMIDevoluciones.Text = StringResources.Devoluciones;
            this.TSMICierredeOrdenes.Text = StringResources.CierredeOrden;
            this.TSMIEntregasParciales.Text = StringResources.EntregasParciales;


            this.tspControl.Text = StringResources.Controles;
            this.TSMIMaquinasParadas.Text = StringResources.Orden_de_Produccion;
            this.TSMILotes.Text = StringResources.Lotes;

            this.tspVentasyProduc.Text = StringResources.VentasyProduccion;
            this.TSMIPrevisionDeVentas.Text = StringResources.PrevisionDeVentas;
            this.TSMIProgramasDeProduccion.Text = StringResources.ProgramaciondeProduccion;
            this.TSMIPrecios.Text = StringResources.Precios;

            //--------------------------------------------------------------
            this.tSpBtnOrdenP.ToolTipText = StringResources.Orden_de_Produccion;
            this.tSpBtnRequisicion.ToolTipText = StringResources.Requisiciones;
            this.tspCierreOrden.ToolTipText = StringResources.CierredeOrden;
            this.tSpBtnEntregParc.ToolTipText = StringResources.EntregasParciales;
            this.tspDevoluc.ToolTipText = StringResources.Devoluciones;
            this.tSpBtnContrlMaq.ToolTipText = StringResources.ControldeMaquinas;
            this.tSpBtnFacturas.ToolTipText = StringResources.Facturas;
            this.TSMIfacturasDeVentas.Text = StringResources.FacturasdeVentas;
            this.TSMIfacturasDeCompra.Text = StringResources.FacturasdeCompra;

            this.tSpBtnCedula.ToolTipText = StringResources.CedulaDeProducto;
            this.tSpBtnCostos.ToolTipText = StringResources.CostoEstandar;
            this.tSpBtnTareas.ToolTipText = StringResources.Tarea;
            this.tspMaquina.ToolTipText = StringResources.Maquinas;
            this.tSpBtnEmpleados.ToolTipText = StringResources.PerfilesdeEmpleados;
            this.tSpBtnFallasMaq.ToolTipText = StringResources.MaquinaConFallas;
            this.tSpBtnGastosFabri.ToolTipText = StringResources.GastosDeFabricacion;
            this.tSpBtnAtributos.ToolTipText = StringResources.Atributos;
            this.tSpBtnStatusMaquina.ToolTipText = StringResources.EstatusDeMaquina;

            this.tSpBtnArticulos.ToolTipText = StringResources.Articulos;
            this.tSpBtnArticCom.ToolTipText = StringResources.ArticulosCompuestos;
            this.tSpBtnCategoria.ToolTipText = StringResources.Categoria;
            this.tSpBtnSubCategoria.ToolTipText = StringResources.SubCategoria;
            this.tSpBtnProceden.ToolTipText = StringResources.Procedencias;
            this.tSpBtnUniMedida.ToolTipText = StringResources.UnidadDeMedida;
            this.tSpBtnAlmacen2.ToolTipText = StringResources.Almacenes;
            this.tSpBtoProveedores.ToolTipText = StringResources.Proveedores;
            this.tSpBtnConfigIVA.ToolTipText = StringResources.ConfiguraciondeIVA;

            this.tSpBtnSucursal2.ToolTipText = StringResources.Sucursales;

            this.tSpBtnReportesInvent.ToolTipText = StringResources.frmPrincipal_Inventario;
                this.articulosTSMI.ToolTipText = StringResources.Articulos;
                this.TSMIherramientas.ToolTipText = StringResources.Herramientas;
                this.TSMIProducTerminados.ToolTipText = StringResources.ProductosTerminados;
                this.TSMICedulasDeProduccion.ToolTipText = StringResources.CedulasDeProduccion;

            this.tspBtoReporProducc.ToolTipText = StringResources.Produccion;
                this.TSMIOrdenesDeProduccion.ToolTipText = StringResources.Orden_de_Produccion;
                this.TSMIRequisiciones.ToolTipText = StringResources.Requisiciones;
                this.TSMIDevoluciones.ToolTipText = StringResources.Devoluciones;
                this.TSMICierredeOrdenes.ToolTipText = StringResources.CierredeOrden;
                this.TSMIEntregasParciales.ToolTipText = StringResources.EntregasParciales;


            this.tspControl.ToolTipText = StringResources.Controles;
            this.TSMIMaquinasParadas.ToolTipText = StringResources.Orden_de_Produccion;
            this.TSMILotes.ToolTipText = StringResources.Lotes;

            this.tspVentasyProduc.ToolTipText = StringResources.VentasyProduccion;
            this.TSMIPrevisionDeVentas.ToolTipText = StringResources.PrevisionDeVentas;
            this.TSMIProgramasDeProduccion.ToolTipText = StringResources.ProgramaciondeProduccion;
            this.TSMIPrecios.ToolTipText = StringResources.Precios;

            mensajeText = StringResources.MITCOREPRODUCCION;

            Text = mensajeText + "(" + frmEmpresaSucursursal.sucursal + ")";
        }

    }
}
