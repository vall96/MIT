using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CultureResources; 
using System.Threading; 
using System.Globalization;
using CapaLogicaNegocios;

namespace CapaPresentacion
{
    public partial class frmTareas : Form
    {
        //valerie
        int n, m;
        //var para validar campos vacios Y para almacenar comparar el cod de unidad y long
        string unidad ="", longitud = "", id = "", CampoV = "";

        public static string[,] codMaquinasAs;
        public static int b = 0, a = 0, c = 0, y = 0, j = 0,
                          pos = 0, posA = 0, posAr = 0, posTM = 0, 
                          cont, cont2, cont3;

        public static string valido;
      
        string accion = "", mensajeText = "", mensajeCaption = "",
        tareaCod, maqCod, Valordescripcion, cod, ValordescripcionA, actual, longID, msj;

        public static string tipoPais = ""; //var Idioma

        int unidadValidar = 0, ValorTM = 0, ValorCU = 0; //var para Buscar Cod-Unidad

        //Variables de suma para factor Conversion
        public decimal FU_Factor = 0, suma = 0; /*totalseg = 0*/
        public int  cantU = 0 ;
        //************************************** declaracion de DATATABLE'S *******************************************
        public static DataTable DtActualTar = new DataTable();
        public static DataTable DtActualAtr = new DataTable();
        public static DataTable DtActualTiempo = new DataTable(); //valerie

        frmTbMaquinas ventMaquinas;
        frmTbAtributos ventAtributos;
        frmTbTareas venTareas;
        //
        ListViewItem lvrow;
        //
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dtA = new DataTable();
        DataTable FAC = new DataTable();
        DataTable dtTM = new DataTable();
        DataTable DtFac = new DataTable();
        DataTable dtTM2 = new DataTable();
        DataTable dtUTrab = new DataTable();
        //
        DialogResult respuesta;
        clsEmpresa M = new clsEmpresa();
        
        //load
        public frmTareas()
        {
            InitializeComponent();
            FuncionInicio();
            dtActuales();

        }
        private void frmTareas_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(0, 0);
            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();

            //valerie
            CargarCBOunidad();
            cargarCBOFactor();
            CargarcboUnidadesDeTrabajo();
            
            

        }
        //*************************************FUNCIONES ****************************************************
        private void FuncionInicio()
        {
            this.btnPuntos.Enabled = true;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoEliminar.Enabled = false;
            this.toolStripBtoGuardar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = false;
            this.toolStripBtoAgregar.Enabled = true;
            this.btoBuscar.Enabled = true;

            txtCod.Enabled = false;
            txtDescrip.Enabled = false;
            txtCodigo.Enabled = true;
            txtDescripcion.Enabled = true;

            this.txtDescripcion.Focus();
            this.txtCodigo.Focus();
            this.lstvAtributos.Enabled = false;
            this.btnAsociarAtributos.Enabled = false;
            this.btnAsociarMaq.Enabled = false;
            this.btnEliminarAtrib.Enabled = false;
            this.btnEliminarMaq.Enabled = false;
            //******************************
            this.lsvMaquin.Enabled = false;
            actual = "inicio";
            pos = 0;
            posA = 0;
          //  posAr = 0;
            posTM = 0;

            //------------valerie--------------------------------
            this.txtTiempoTotal.Enabled = false;
            this.DgVTiempoMaquina.Enabled = false;
        }
        private void FuncionAgregar()
        {
            this.btnPuntos.Enabled = false;
            accion = "agregar";
            actual = "agregar";

            limpiarCajas();

            cboFactorConv.SelectedIndex = 9;

            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoEliminar.Enabled = false;
            this.toolStripBtoGuardar.Enabled = true;
            this.toolStripBtoDescartar.Enabled = true;
            this.btoBuscar.Enabled = false;

            //***Cajas******
            txtCodigo.Enabled = false;
            txtDescripcion.Enabled = false;
            this.txtCod.Enabled = true;
            txtDescrip.Enabled = true;
            txtCod.Focus();
            //********************************
          
            this.lstvAtributos.Enabled = true;
            this.btnAsociarAtributos.Enabled = true;
            this.btnAsociarMaq.Enabled = true;
            this.lsvMaquin.Enabled = true;

            //------------valerie--------------------------------
            if (DgVTiempoMaquina.Rows.Count == 0)
            {
                this.DgVTiempoMaquina.Enabled = false;
            }
            else
            {
                this.DgVTiempoMaquina.Enabled = true;
            }
            this.txtTiempoTotal.Enabled = false;
          
        }
        private void limpiarCajas()
        {
            txtCodigo.Clear();
            txtDescripcion.Clear();
            txtDescrip.Clear();
            txtCod.Clear();
            this.lstvAtributos.Items.Clear();
            this.lsvMaquin.Items.Clear();
            //------------valerie
            this.txtTiempoTotal.Clear();
            this.DgVTiempoMaquina.Rows.Clear();
            this.txtTiempoTotal.Clear();
            cboFactorConv.SelectedIndex = -1;
        }
        public void funcionGuardar()
        {
            DgVTiempoMaquina.EndEdit();
            string msj = "";
            if (accion == "agregar" || accion == "editar")
            {
                if (this.txtCod.Text == "" || this.txtDescrip.Text == "")
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
                    mensajeText = StringResources.ExistenCamposVacios;
                    mensajeCaption = StringResources.ValidaciondeRegistro;
                    MessageBox.Show(mensajeText, mensajeCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                    if (this.txtCod.Text == "")
                    {
                        this.txtCod.Focus();
                        return;
                    }
                    else
                    {
                        this.txtDescrip.Focus();
                        return;
                    }
                }

                else if (lsvMaquin.Items.Count == 0)
                {
                    mensajeText = StringResources.msjAsociarMaquinas;
                    mensajeCaption = StringResources.ValidaciondeRegistro;
                    MessageBox.Show(mensajeText, mensajeCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return;
                }
               
                else
                {
                    for (int a = 0; a < DgVTiempoMaquina.Rows.Count; a++) //rutina para vaidar que no se ingresen valores null en las columnas de cantidad y tiempo
                    {
                        if (DgVTiempoMaquina.Rows[a].Cells[2].Value.ToString() == "" || DgVTiempoMaquina.Rows[a].Cells[4].Value.ToString() == "" ||
                            DgVTiempoMaquina.Rows[a].Cells[4].Value.ToString() == null || DgVTiempoMaquina.Rows[a].Cells[2].Value.ToString() == null )
                        {
                            mensajeText = StringResources.ExistenCamposVacios;
                            mensajeCaption = StringResources.ValidaciondeRegistro;
                            MessageBox.Show(mensajeText, mensajeCaption,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            ValorTM = Convert.ToInt32(DgVTiempoMaquina.Rows[a].Cells[2].Value);

                            ValorCU = Convert.ToInt32(DgVTiempoMaquina.Rows[a].Cells[4].Value);

                            if (ValorTM == 0 || ValorCU == 0)
                            {
                                //mensajeText = StringResources.msjAsociarMaquinas; asociar en el strigresourse
                                //mensajeCaption = StringResources.ValidaciondeRegistro;
                                MessageBox.Show("Imposible tomar Valor '0' como referencia, indique el tiempo de uso o la Cantidad", "",  /*mensajeText, mensajeCaption,*/
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    //
                    ConstruccionDt();

                    if (accion == "agregar")
                    {
                        M.codigo = txtCod.Text.ToString().Trim().ToUpper();
                        M.m_DescripCategorias = txtDescrip.Text;
                        msj = M.RegistarTarea(frmPrincipal.nombreBD);
                        if (msj == "Ya existe")
                        {
                            mensajeText = StringResources.YaExisteElRegistro;
                            mensajeCaption = StringResources.ValidaciondeRegistro;
                            MessageBox.Show(mensajeText + " " + txtCod.Text.Trim(), mensajeCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtCod.Focus();
                            return;
                        }
                    }
                    else if (accion == "editar")
                    {
                        if (Valordescripcion != txtDescrip.Text)
                        {
                            M.codigo = txtCod.Text.ToString().Trim();
                            M.m_DescripCategorias = txtDescrip.Text;
                            msj = M.ActualizarTarea(frmPrincipal.nombreBD);
                            if (msj == "Actualizacion Exitos")
                            {
                                cod = M.codigo;
                                ValordescripcionA = txtDescrip.Text;
                            }
                        }
                        else
                        {
                            msj = "Actualizacion Exitos";
                        }
                    }

                    if (msj == "Registro Exitoso" || msj == "Actualizacion Exitos")
                    {
                        ConstrucciondtTM();
                        cargarRelacion();

                        if (lstvAtributos.Items.Count != 0)
                        {
                            M.codigo = txtCod.Text.ToString().Trim();
                            ConstruccionDtA();
                            cargarRelacionAtrb();
                        }

                        mensajeCaption = StringResources.ValidaciondeRegistro;

                        if (msj == "Registro Exitoso")
                        {
                            mensajeText = StringResources.DBRegistroexitoso;
                            MessageBox.Show(mensajeText, mensajeCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (msj == "Actualizacion Exitos")
                        {
                            mensajeText = StringResources.DBActualizacionExitosa;
                            MessageBox.Show(mensajeText, mensajeCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        txtCod.Focus();
                        limpiarCajas();
                        FuncionInicio();
                    }
                }
            }
        }
        private void Funcioneditar()
        {
            accion = "editar";
            actual = "editar";
            DgVTiempoMaquina.Columns[1].ReadOnly = false; //VALERIE
            DgVTiempoMaquina.Columns[2].ReadOnly = false;  //VALERIE
            DgVTiempoMaquina.Columns[3].ReadOnly = false; //VALERIE
            DgVTiempoMaquina.Columns[4].ReadOnly = false;  //VALERIE

            this.toolStripBtoEliminar.Enabled = false;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoGuardar.Enabled = true;

            lstvAtributos.CheckBoxes = true;
            lsvMaquin.CheckBoxes = true;
            btnAsociarMaq.Enabled = true;
            btnAsociarAtributos.Enabled = true;
            Valordescripcion = txtDescrip.Text;
            txtDescrip.Enabled = true;
            /*******************************/
            txtCodigo.Enabled = false;
            txtDescripcion.Enabled = false;
            //------------valerie--------------------------------
            this.txtTiempoTotal.Enabled = false;
            this.DgVTiempoMaquina.Enabled = true;
        }
        private void FuncionBuscar()
        {
            string palabra = "";
            if (txtCodigo.Text == "" && txtDescripcion.Text == "")
            {
                return;
            }
            if (Valordescripcion != txtDescrip.Text && accion == "editar")
            {
                if (y != 0) //actualizar para no ir a bd nuevamente
                {
                    for (int i = 0; i < dt2.Rows.Count; i++)
                    {
                        if (cod == dt2.Rows[i]["Tareas_Id"].ToString())
                        {
                            dt2.Rows[i]["Tareas_Descripcion"] = ValordescripcionA;
                            accion = "";
                        }
                    }
                }
            }
            if (y == 0)               //Validacion para ir solo uina vezz a la BD
            {
                dt2 = M.listarTareas(frmPrincipal.nombreBD);
                y++;
            }
            if (txtCodigo.Text != "")     //buscarpor cod
            {
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    palabra = dt2.Rows[i]["Tareas_Id"].ToString().ToLower();
                    bool existe = palabra.StartsWith(txtCodigo.Text.ToLower().Trim());
                    if (existe == true)
                    {
                        txtCodigo.Text = dt2.Rows[i]["Tareas_Id"].ToString();
                        txtCod.Text = dt2.Rows[i]["Tareas_Id"].ToString();
                        txtDescripcion.Text = dt2.Rows[i]["Tareas_Descripcion"].ToString();
                        txtDescrip.Text = dt2.Rows[i]["Tareas_Descripcion"].ToString();
                        ItemsAsociadosTareas();
                        ActivarBotenes();
                        valido = "valido";
                        actual = "EditarEliminar";
                        return;
                    }
                }
            }
            if (txtDescripcion.Text != "")     //buscarpor des
            {
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    palabra = dt2.Rows[i]["Tareas_Descripcion"].ToString().ToLower();
                    bool existe = palabra.StartsWith(txtDescripcion.Text.ToLower().Trim());
                    if (existe == true)
                    {
                        txtCodigo.Text = dt2.Rows[i]["Tareas_Id"].ToString();
                        txtCod.Text = dt2.Rows[i]["Tareas_Id"].ToString();
                        txtDescripcion.Text = dt2.Rows[i]["Tareas_Descripcion"].ToString();
                        txtDescrip.Text = dt2.Rows[i]["Tareas_Descripcion"].ToString();
                        ItemsAsociadosTareas();
                        ActivarBotenes();
                        actual = "EditarEliminar";
                        valido = "valido";
                        return;
                    }
                }
            }
            if (valido != "valido")
            {
                mensajeText = StringResources.NoSeEncontroInformacion;
                mensajeCaption = StringResources.NoSeEncontroInformacion;
                MessageBox.Show(mensajeText, mensajeCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        //*******************************Construit DT's************************************************
        private void ConstruccionDt()
        {
            dt.Rows.Clear();
            dt.Columns.Clear();
            dt.Columns.Add("TareaMaq_TareaId", Type.GetType("System.String"));
            dt.Columns.Add("TareaMaq_MaqId", Type.GetType("System.String"));
        }
        private void ConstruccionDtA()
        {
            dtA.Rows.Clear();
            dtA.Columns.Clear();
            dtA.Columns.Add("TareaAtrib_TareaId", Type.GetType("System.String"));
            dtA.Columns.Add("TareaAtrib_AtribId", Type.GetType("System.String"));
            //dtAtc
        }
        private void ConstrucciondtTM() //valerie
        {
            dtTM2 = new DataTable();
            dtTM2.Columns.Clear();
            dtTM2.Columns.Add("TareasMaq_TareaId", Type.GetType("System.String"));
            dtTM2.Columns.Add("TareasMaq_MaqId", Type.GetType("System.String"));
            dtTM2.Columns.Add("TareasMaq_CodUnidad", Type.GetType("System.String"));
            dtTM2.Columns.Add("TareasMaq_CantUnidad", Type.GetType("System.String"));
            dtTM2.Columns.Add("TareasMaq_CodUnidadTrab", Type.GetType("System.String"));
            dtTM2.Columns.Add("TareasMaq_CantUnidadTrab", Type.GetType("System.String"));
        }

        //**********************************Cargar Realaciones*****************************************
        private void cargarRelacionAtrb()
        {
            if (lstvAtributos.Items.Count > 0)
            {
                j = 0;
                for (int a = posA; a <lstvAtributos.Items.Count ; a++)
                {
                    maqCod = lstvAtributos.Items[a].SubItems[0].Text.ToString();
                    dtA.Rows.Add();
                    dtA.Rows[j]["TareaAtrib_TareaId"] = txtCod.Text;
                    dtA.Rows[j]["TareaAtrib_AtribId"] = lstvAtributos.Items[a].SubItems[0].Text.ToString();
                    j++;
                }
                if (j != 0)
                {
                    M.registar_TareasAtrib(dtA, frmPrincipal.nombreBD);
                }
            }
            j = 0;
        }
        public void cargarRelacion()   //valerie //antes de enviar dt a la bd, debo saber si la relacion //a guardar ya existe, y agregar solo las nuevas                                           
        {
            DgVTiempoMaquina.Enabled = true;
            tareaCod = txtCod.Text;

            if (lsvMaquin.Items.Count > 0)
            {
                j = 0;
                for (int i = pos; i < lsvMaquin.Items.Count; i++)
                {
                    maqCod = lsvMaquin.Items[i].SubItems[0].Text.ToString();
                    dt.Rows.Add();
                    dt.Rows[j]["TareaMaq_TareaId"] = txtCod.Text;
                    dt.Rows[j]["TareaMaq_MaqId"] = lsvMaquin.Items[i].SubItems[0].Text.ToString();
                    j++;
                }
            }
            //registra el tiempo de las maquinas y las maquinas relacionadas
            if (DgVTiempoMaquina.Rows.Count > 0)
            {
                j = 0;
               // dt = M.ListarMaqTarea(frmPrincipal.nombreBD);

                for (int i = posTM; i < DgVTiempoMaquina.Rows.Count; i++)
                {
                    unidadValidar = 0;

                    unidad = DgVTiempoMaquina.Rows[i].Cells[1].Value.ToString().ToLower();
                    CargarCodigoUnidad();

                    longitud = DgVTiempoMaquina.Rows[i].Cells[3].Value.ToString().ToLower();
                    CargarCodigoUnidadTrabajo();
                  //  ConvertidorSegundos();

                    dtTM2.Rows.Add();
                    dtTM2.Rows[j]["TareasMaq_TareaId"] = txtCod.Text;
                    dtTM2.Rows[j]["TareasMaq_MaqId"] = lsvMaquin.Items[i].SubItems[0].Text.ToString();
                    dtTM2.Rows[j]["TareasMaq_CodUnidad"] = id;
                    dtTM2.Rows[j]["TareasMaq_CantUnidad"] = DgVTiempoMaquina.Rows[i].Cells[2].Value.ToString();
                    dtTM2.Rows[j]["TareasMaq_CodUnidadTrab"] = longID;
                    dtTM2.Rows[j]["TareasMaq_CantUnidadTrab"] = Convert.ToInt32(DgVTiempoMaquina.Rows[i].Cells[4].Value);
                    j++;
                }

                if (j != 0)
                {
                    M.RegistrarTiempoMaquinaTarea(dtTM2, frmPrincipal.nombreBD);
                }

                if (accion == "editar")
                {
                    j = 0;
                    ConstrucciondtTM();
                  //  dtTM2 = M.ListarMaqTiempo(frmPrincipal.nombreBD);

                    for (int i = 0; i < lsvMaquin.Items.Count; i++)
                    {
                        unidadValidar = 0;

                        unidad = DgVTiempoMaquina.Rows[i].Cells[1].Value.ToString().ToLower();
                        CargarCodigoUnidad();

                        longitud = DgVTiempoMaquina.Rows[i].Cells[3].Value.ToString().ToLower();
                        CargarCodigoUnidadTrabajo();

                        dtTM2.Rows.Add();
                        dtTM2.Rows[j]["TareasMaq_TareaId"] = txtCod.Text;
                        dtTM2.Rows[j]["TareasMaq_MaqId"] = lsvMaquin.Items[i].SubItems[0].Text.ToString(); 
                        dtTM2.Rows[j]["TareasMaq_CodUnidad"] = id;
                        dtTM2.Rows[j]["TareasMaq_CantUnidad"] = DgVTiempoMaquina.Rows[i].Cells[2].Value.ToString();
                        dtTM2.Rows[j]["TareasMaq_CodUnidadTrab"] = longID; 
                        dtTM2.Rows[j]["TareasMaq_CantUnidadTrab"] = Convert.ToInt32(DgVTiempoMaquina.Rows[i].Cells[4].Value);
                        j++;
                    }

                    if (j != 0)
                    {
                        M.ActualizarTiempoMaquina(dtTM2, frmPrincipal.nombreBD);
                    }

                    if (msj == "Actualizacion Exitos")
                    {
                        Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
                        mensajeText = StringResources.DBActualizacionExitosa;
                        mensajeCaption = StringResources.frmUsuarioEstiloPrueba_TituloValidacionDeActualizacion;

                        MessageBox.Show(mensajeText, mensajeCaption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                }
            }
            return;
        }
        public void CargarCodigoUnidad()
        {
            string prueba;
            if (unidadValidar == 1)
            {
                for (int i = 0; i < dtTM.Rows.Count; i++)
                {
                    prueba = dtTM.Rows[i]["UnidDes_codUni"].ToString().ToLower();
                    if (prueba == Utiem)
                    {
                        id = dtTM.Rows[i]["UnidDes_Descripcion"].ToString();
                        return;
                    }

                }
            }
            
            if (unidadValidar == 0) // antes de gusardar recoge el codigo de la unidad para llevarla a la base de datos
            {
                if (DgVTiempoMaquina.Rows.Count != 0)
                {
                    for (int n = 0; n < dtTM.Rows.Count; n++)
                    {
                        //unidad = DgVTiempoMaquina.Rows[2].Cells[1].Value.ToString().ToLower();

                        prueba = dtTM.Rows[n]["UnidDes_Descripcion"].ToString().ToLower();
                        if (prueba == unidad)
                        {
                            id = dtTM.Rows[n]["UnidDes_codUni"].ToString();
                            return;
                        }
                    }
                }
            }
        }
        public void CargarCodigoUnidadTrabajo()
        {
            string validarLong;
            if (unidadValidar == 1)
            {
                for (int i = 0; i < dtTM.Rows.Count; i++)
                {
                    validarLong = dtUTrab.Rows[i]["UnidDes_codUni"].ToString().ToLower();

                    if (validarLong == Utrab)
                    {
                        longID = dtUTrab.Rows[i]["UnidDes_Descripcion"].ToString();
                        return;
                    }
                }
            }
            if (unidadValidar == 0) // antes de gusardar recoge el codigo de la unidad para llevarla a la base de datos
            {
                if (DgVTiempoMaquina.Rows.Count != 0)
                {
                    for (int n = 0; n < dtUTrab.Rows.Count; n++)
                    {
                        validarLong = dtUTrab.Rows[n]["UnidDes_Descripcion"].ToString().ToLower();
                        if (validarLong == longitud)
                        {
                            longID = dtUTrab.Rows[n]["UnidDes_codUni"].ToString();
                            return;
                        }
                    }
                }
            }
        }

        //*******************************************************************************************
        private void eliminarLsv()
        {
            if (accion=="agregar")
            {
                for (int i = pos; i < lsvMaquin.Items.Count; i++)
                {
                    if (lsvMaquin.Items[i].Checked == true)
                    {
                        lsvMaquin.Items.RemoveAt(i);
                        this.DgVTiempoMaquina.Rows.RemoveAt(i); // Valerie
                        i--;
                    }                   
                }
                actualizarDtMaqui();
                return;
            }
            if (accion=="editar")
            {
                if (this.lsvMaquin.CheckedItems.Count>0)
                {
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                        mensajeText = StringResources.msjEliminarItems;
                        mensajeCaption = StringResources.ValidacióndeEliminación;
                        respuesta = MessageBox.Show(mensajeText,
                        mensajeCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                
                    if (respuesta == DialogResult.Yes)
                    {
                        j = 0;
                        ConstruccionDt();
                        for (int i = 0; i < pos; i++)
                        {
                            if (lsvMaquin.Items[i].Checked == true)
                            {
                                dt.Rows.Add();
                                dt.Rows[j]["TareaMaq_TareaId"] = txtCod.Text;
                                dt.Rows[j]["TareaMaq_MaqId"] = lsvMaquin.Items[i].SubItems[0].Text.ToString();
                                j++;
                                lsvMaquin.Items.RemoveAt(i);
                                DgVTiempoMaquina.Rows.RemoveAt(i);//valerie
                                pos--;
                                posTM--;
                                i--;
                            }
                        }
                        if (j != 0)
                        {
                            M.eliminarMaqTarea(dt, frmPrincipal.nombreBD);

                            mensajeText = StringResources.DBEliminacionexitosa;
                            mensajeCaption = StringResources.frmRegistroUsuario_messValidacionCorrecta;
                            MessageBox.Show(mensajeText, mensajeCaption,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            actualizarDtMaqui();
                        }
                    }
                }
                if (this.lsvMaquin.CheckedItems.Count > 0)
                {                   
                    for (int i = pos; i < lsvMaquin.Items.Count; i++)
                    {
                        if (lsvMaquin.Items[i].Checked == true)
                        {
                            lsvMaquin.Items.RemoveAt(i);
                            this.DgVTiempoMaquina.Rows.RemoveAt(i);//valerie
                            pos--;
                            i--;
                        }
                    }
                    actualizarDtMaqui();
                }
            }
        }
        private void eliminarLsvAtrb()
        {
            if (accion == "agregar")
            {
                for (int i = 0; i < lstvAtributos.Items.Count; i++)
                {
                    if (lstvAtributos.Items[i].Checked == true)
                    {
                        lstvAtributos.Items.RemoveAt(i);
                        i--;
                    }
                }
                actualizarDtAtrib();
            }
            if (accion == "editar")
            {

                if (this.lstvAtributos.CheckedItems.Count > 0)
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    mensajeText = StringResources.msjEliminarItems;
                    mensajeCaption = StringResources.ValidacióndeEliminación;
                    respuesta = MessageBox.Show(mensajeText,
                    mensajeCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                }

                if (respuesta == DialogResult.Yes)
                {
                    j = 0;
                    ConstruccionDtA();
                    for (int i = 0; i < posA; i++)
                    {
                        if (lstvAtributos.Items[i].Checked == true)
                        {
                            dtA.Rows.Add();
                            dtA.Rows[j]["TareaAtrib_TareaId"] = txtCod.Text;
                            dtA.Rows[j]["TareaAtrib_AtribId"] = lstvAtributos.Items[i].SubItems[0].Text.ToString();
                            j++;
                            lstvAtributos.Items.RemoveAt(i);
                            posA--;
                            i--;
                        }
                    }
                    if (j != 0)
                    {
                        M.eliminarAtriTarea(dtA, frmPrincipal.nombreBD);

                        mensajeText = StringResources.DBEliminacionexitosa;
                        mensajeCaption = StringResources.frmRegistroUsuario_messValidacionCorrecta;
                        MessageBox.Show(mensajeText, mensajeCaption,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        actualizarDtAtrib();
                    }
                }

                if (this.lstvAtributos.CheckedItems.Count > 0)
                {
                    for (int i = posA; i < lstvAtributos.Items.Count; i++)
                    {
                        if (lstvAtributos.Items[i].Checked == true)
                        {
                            lstvAtributos.Items.RemoveAt(i);
                            posA--;
                            i--;
                        }
                    }
                }
            }
        }
        private void EliminarTarea()
        {
            string msj;
            if (lsvMaquin.Items.Count != 0 || lstvAtributos.Items.Count != 0)
            {
                mensajeCaption = StringResources.ValidacióndeEliminación;
                MessageBox.Show(StringResources.msjEliminarTarea + txtCod.Text + StringResources.msjRegistroAsociados,
                mensajeCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                M.codigo = txtCod.Text.ToString();
                msj = M.EliminarTarea(frmPrincipal.nombreBD);
                if (msj== "Eliminacion exitosa")
                {
                    mensajeText = StringResources.DBEliminacionexitosa;
                    mensajeCaption = StringResources.ValidacionExitosa;
                    MessageBox.Show(mensajeText, mensajeCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                limpiarCajas();
                FuncionInicio();
            }
        }
        //******************************************************************************************
        private void actualizarDtMaqui()
        {
            DtActualTar.Rows.Clear();
            {
                for (int i = 0; i < lsvMaquin.Items.Count; i++)
                {
                    DtActualTar.Rows.Add();
                    DtActualTar.Rows[i]["MaqId"] = lsvMaquin.Items[i].SubItems[0].Text.ToString();
                }
            }
        }
        private void actualizarDtAtrib()
        {
            DtActualAtr.Rows.Clear();
            {
                for (int i = 0; i < lstvAtributos.Items.Count; i++)
                {
                    DtActualAtr.Rows.Add();
                    DtActualAtr.Rows[i]["AtrbId"] = lstvAtributos.Items[i].SubItems[0].Text.ToString();
                }
            }
        }
         private void lsvMaquin_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvMaquin.Items.Count==0)
            {
                btnEliminarMaq.Enabled = false;
            }
        }
        private void lsvMaquin_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (lsvMaquin.CheckedItems.Count > 0)
            {
                this.btnEliminarMaq.Enabled = true;
            }
            else
            {
                this.btnEliminarMaq.Enabled = false;
            }
        }
        private void lstvAtributos_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (lstvAtributos.CheckedItems.Count > 0)
            {
                this.btnEliminarAtrib.Enabled = true;
            }
            else
            {
                this.btnEliminarAtrib.Enabled = false;
            }
        }
       
        //*************************Botones**********************************************************
        private void btnAsociarAtributos_Click(object sender, EventArgs e)
        {
            valido = "si";
            cont2 = lstvAtributos.Items.Count;
            ventAtributos = new frmTbAtributos();
            ventAtributos.dtRelAtributos += new frmTbAtributos.relacion(TareasAtributos);
            ventAtributos.ShowDialog();
        }
        private void btnEliminarMaq_Click(object sender, EventArgs e)
        {
            eliminarLsv();
        }
        private void btnEliminarAtrib_Click(object sender, EventArgs e)
        {
            eliminarLsvAtrb();
        }
        private void btnPuntos_Click(object sender, EventArgs e)
        {
            venTareas = new frmTbTareas();
            venTareas.pasado += new frmTbTareas.pasar(ejecutar);
            venTareas.ShowDialog();
        }
        private void btoBuscar_Click(object sender, EventArgs e)
        {
            FuncionBuscar();            
        }
        private void btnAsociarMaq_Click(object sender, EventArgs e)
        {
            valido = "si";
            cont = lsvMaquin.Items.Count;
            ventMaquinas = new frmTbMaquinas();
            ventMaquinas.dtRelMaquinas += new frmTbMaquinas.relacion(TareasMaquinas);
            ventMaquinas.ShowDialog();

        }
        private void btoSalir_Click(object sender, EventArgs e)
        {
            valido = "";
            this.Close();
        }
       //********************************************************************************************
        public void ejecutar(string[,] dato)
        {
            txtCodigo.Text = dato[0, 0];
            txtCod.Text = dato[0, 0];
            txtDescrip.Text = dato[0, 1];
            txtDescripcion.Text = dato[0, 1];
            ActivarBotenes();
            ItemsAsociadosTareas();
            actual = "EditarEliminar";
        }
        string Utiem, Utrab;
        private void ItemsAsociadosTareas() //buscar maquinas, atributos y Articulos asociados a la tarea 
        {
            M.codigo = txtCod.Text.ToUpper();

            dt = M.ListarMaqTarea(frmPrincipal.nombreBD);
            dtA= M.ListarMaqAtrib(frmPrincipal.nombreBD);
            dtTM2 = M.ListarMaqTiempo(frmPrincipal.nombreBD);//val

            DgVTiempoMaquina.Rows.Clear();
            DgVTiempoMaquina.Enabled = true;

            lstvAtributos.Items.Clear();
            lstvAtributos.Enabled = true;

            lsvMaquin.Items.Clear();
            lsvMaquin.Enabled = true;
        
            if (dt.Rows.Count > 0)
            {
                b = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DtActualTar.Rows.Add();
                    DtActualTar.Rows[b]["MaqId"] = dt.Rows[i]["TareasMaq_MaqId"].ToString();
                    lvrow = new ListViewItem(dt.Rows[i]["TareasMaq_MaqId"].ToString());
                    lvrow.SubItems.Add(dt.Rows[i]["Maq_descripcion"].ToString());
                    this.lsvMaquin.Items.Add(lvrow);
                    b++;
                }
                pos = lsvMaquin.Items.Count;
            }

            if (dtA.Rows.Count > 0)
            {
                c = 0;
                for (int i = 0; i < dtA.Rows.Count; i++)
                {
                    DtActualAtr.Rows.Add();
                    DtActualAtr.Rows[c]["AtrbId"] = dtA.Rows[i]["TareasAtrib_AtribId"].ToString();
                    lvrow = new ListViewItem(dtA.Rows[i]["TareasAtrib_AtribId"].ToString());
                    lvrow.SubItems.Add(dtA.Rows[i]["Atrib_descripcion"].ToString());
                    this.lstvAtributos.Items.Add(lvrow);
                    c++;
                }
                posA= lstvAtributos.Items.Count;
            }

            if (dtTM2.Rows.Count > 0) //valerie
            {
                //b = 0;
                unidadValidar = 1;
                DgVTiempoMaquina.Rows.Clear();
                DgVTiempoMaquina.Columns[1].ReadOnly = true;
                DgVTiempoMaquina.Columns[2].ReadOnly = true;
                DgVTiempoMaquina.Columns[3].ReadOnly = true;
                DgVTiempoMaquina.Columns[4].ReadOnly = true;

                for (int i = 0; i < dtTM2.Rows.Count; i++)
                {
                    Utiem = dtTM2.Rows[i]["TareasMaq_CodUnidad"].ToString();
                    CargarCodigoUnidad();
                    Utrab = dtTM2.Rows[i]["TareasMaq_CodUnidadTrab"].ToString();
                    CargarCodigoUnidadTrabajo();

                    DgVTiempoMaquina.Rows.Add(
                    dtTM2.Rows[i]["Maq_descripcion"].ToString(),
                    "",
                    dtTM2.Rows[i]["TareasMaq_CantUnidad"].ToString(),
                    "",
                    dtTM2.Rows[i]["TareasMaq_CantUnidadTrab"].ToString()
                    );

                    DgVTiempoMaquina.Rows[i].Cells["CBOunidadTM"].Value = id;
                    DgVTiempoMaquina.Rows[i].Cells["CBOUnidadDeTrabajo"].Value = longID;

                }

                //this.DgVTiempoMaquina.AutoGenerateColumns = false;
                //n = DgVTiempoMaquina.Rows.Count - 1;
                posTM = DgVTiempoMaquina.Rows.Count;
                //if (dtTM2.Rows.Count == n)
                //{
                //    DgVTiempoMaquina.AllowUserToAddRows = false;
                //}
            }
        }
        private void ActivarBotenes()
        {
            this.toolStripBtoEditar.Enabled = true;
            this.toolStripBtoEliminar.Enabled = true;
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            this.btoBuscar.Enabled = false;
            lstvAtributos.CheckBoxes = false;
            lsvMaquin.CheckBoxes = false;
        }

        //****************** eventos ****************************************************************
        private void cboFactorConv_SelectedIndexChanged(object sender, EventArgs e)
        {
           CboCodFactConv.SelectedIndex = cboFactorConv.SelectedIndex  ;
        } //valerie
        private void frmTareas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                if (actual == "inicio")
                {
                    FuncionAgregar();
                }
            }
            if (e.KeyCode == Keys.F6)
            {
                if (actual != "inicio")
                {
                    if (actual != "agregar")
                    {                       
                        Funcioneditar();
                    }                        
                }                   
            }
            if (e.KeyCode == Keys.F7)
            {
                if (actual != "inicio")
                {
                    if (actual != "EditarEliminar")
                    {
                        funcionGuardar();
                    }
                   
                }                    
            }
            if (e.KeyCode == Keys.F8)
            {
                if (actual != "inicio")
                {
                    if (actual != "agregar")
                    {
                        if (actual != "editar")
                        {
                            EliminarTarea();
                        }                            
                    }                        
                }                    
            }
            if (e.KeyCode == Keys.F9)
            {
                limpiarCajas();
                FuncionInicio();
            }
        }
        private void txtCod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || (e.KeyChar >= 97 && e.KeyChar <= 122) || (e.KeyChar >= 65 && e.KeyChar <= 90) || (e.KeyChar == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                FuncionBuscar();
            }
            else if ((e.KeyChar >= 48 && e.KeyChar <= 57) || (e.KeyChar >= 97 && e.KeyChar <= 122) || (e.KeyChar >= 65 && e.KeyChar <= 90) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }                
        }
        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                FuncionBuscar();
            }
        }
        private void lstvAtributos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvAtributos.Items.Count==0)
            {
                btnEliminarAtrib.Enabled = false;
            }
        }
        //*********************************************************************************************
        private void dtActuales() //pase por aqui Valerie
        {
            DtActualTar = new DataTable();
            DtActualTar.Columns.Add("MaqId", Type.GetType("System.String"));
            DtActualAtr= new DataTable();
            DtActualAtr.Columns.Add("AtrbId", Type.GetType("System.String"));
            DtActualTiempo = new DataTable(); 
            DtActualTiempo.Columns.Add("TimeId", Type.GetType("System.String"));
        }
        //**********************************************************************************************
        private void toolStripBtoEditar_Click(object sender, EventArgs e)
        {
            Funcioneditar();
        }
        private void toolStripBtoEliminar_Click(object sender, EventArgs e)
        {
            EliminarTarea();
        }
        private void toolStripBtoDescartar_Click(object sender, EventArgs e)
        {
            limpiarCajas();
            FuncionInicio();
        }
        private void toolStripBtoAgregar_Click(object sender, EventArgs e)
        {
            FuncionAgregar();
        }
        private void toolStripBtoGuardar_Click(object sender, EventArgs e)
        {
            funcionGuardar();
        }

        //************************************************************************************************
        public void TareasMaquinas(DataTable dtMaquinas)
        {
            b = lsvMaquin.Items.Count;      //guardar pos para = cargar dt

            this.lsvMaquin.Enabled = true;
            for (int a = 0; a < dtMaquinas.Rows.Count; a++)
            {
                DtActualTar.Rows.Add();
                DtActualTar.Rows[b]["MaqId"] = dtMaquinas.Rows[a]["codigo"].ToString();
                lvrow = new ListViewItem(dtMaquinas.Rows[a]["codigo"].ToString());
                lvrow.SubItems.Add(dtMaquinas.Rows[a]["descripcion"].ToString());
                this.lsvMaquin.Items.Add(lvrow);
                //Valerie
                this.DgVTiempoMaquina.Enabled = true;
                this.DgVTiempoMaquina.Rows.Add(dtMaquinas.Rows[a]["descripcion"].ToString());
                
                b++;               
            }
            //int n = DgVTiempoMaquina.Rows.Count - 1;
            //if (DgVTiempoMaquina.Rows.Count - 1 == n)
            //{
            //    DgVTiempoMaquina.AllowUserToAddRows = false;
            //}
            this.toolStripBtoGuardar.Enabled = true;
            this.lsvMaquin.CheckBoxes = true;
            valido = "";

        } //pase por aqui Valerie
        public void TareasAtributos(DataTable dtMAtributos)
        {
            c = lstvAtributos.Items.Count;
            this.lstvAtributos.Enabled = true;
            for (int a = 0; a < dtMAtributos.Rows.Count; a++)
            {
                DtActualAtr.Rows.Add();
                DtActualAtr.Rows[c]["AtrbId"] = dtMAtributos.Rows[a]["codigo"].ToString();
                lvrow = new ListViewItem(dtMAtributos.Rows[a]["codigo"].ToString());
                lvrow.SubItems.Add(dtMAtributos.Rows[a]["descripcion"].ToString());
                this.lstvAtributos.Items.Add(lvrow); 
                c++;
            }
            this.toolStripBtoGuardar.Enabled = true;
            this.lstvAtributos.CheckBoxes = true;
            valido = "";
        }
        public void AplicarIdioma()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
            //Titulos
            this.lblTituloPanel.Text = StringResources.Tarea;
            this.Text = StringResources.Tarea;
            //labels
            this.lblCod.Text = StringResources.Codigo;
            this.lblCodigo.Text = StringResources.Codigo;
            this.lblDescrip.Text = StringResources.Descripcion;
            this.lblDescripcion.Text = StringResources.Descripcion;
            this.lblAtributos.Text = StringResources.Atributos;
            this.lblMaquinas.Text = StringResources.Maquinas;
            //Buttons
            this.toolStripBtoAgregar.Text = StringResources.btoAgregar;
            this.toolStripBtoDescartar.Text = StringResources.btoDescartar;
            this.toolStripBtoEditar.Text = StringResources.btoEditar;
            this.toolStripBtoEliminar.Text = StringResources.btoEliminar;
            this.toolStripBtoGuardar.Text = StringResources.btoGuardar;
            this.btoBuscar.Text = StringResources.btnBuscar;
            this.btoSalir.Text = StringResources.btnSalir;
            //ToolStrip
            this.toolStripBtoAgregar.ToolTipText = StringResources.btoAgregar;
            this.toolStripBtoDescartar.ToolTipText = StringResources.btoDescartar;
            this.toolStripBtoEditar.ToolTipText = StringResources.btoEditar;
            this.toolStripBtoEliminar.ToolTipText = StringResources.btoEliminar;
            this.toolStripBtoGuardar.ToolTipText = StringResources.btoGuardar;

            //tab
            this.tpgInfoGeneral.Text = StringResources.Informaciongeneral;

            //ListView
            this.ColcodigoA.Text = StringResources.Codigo;
            this.ColDescripA.Text = StringResources.Codigo;
            this.ColDescripM.Text = StringResources.Descripcion;

            //TiempoMaquina
            this.tpTiempomaquina.Text = StringResources.TiempoDeMaquina;
            this.lblTiempoTotal.Text = StringResources.TiempoTotal;
            this.ColDescripcion.HeaderText = StringResources.Maquinas;
            this.colTiempo.HeaderText = StringResources.TiempoDeMaquina;
            this.lblTiempo.Text = StringResources.TiempoDeMaquina;
        }

        //---------------------------------------------VALERIE-------------------------------------------
        public void CargarUnidades()
        {
            dtTM = M.ListarTiempoMaquinaTarea("MITCore");
        }
        public void CargarCBOunidad()
        {
            this.DgVTiempoMaquina.AutoGenerateColumns = false;
            this.CBOunidadTM.Items.Clear();
            CargarUnidades();
            for (int i = 0; i < dtTM.Rows.Count; i++)
            {
                CBOunidadTM.Items.Add(dtTM.Rows[i]["UnidDes_Descripcion"].ToString());
            }
        }
        public void CargarUnidadesdeTrabajo()
        {
            dtUTrab = M.ListarUnidadesDeLongitud("MITCore");
        }
        public void CargarcboUnidadesDeTrabajo()
        {
            this.DgVTiempoMaquina.AutoGenerateColumns = false;
            this.CBOUnidadDeTrabajo.Items.Clear();
            CargarUnidadesdeTrabajo();
            for (int i = 0; i < dtUTrab.Rows.Count; i++)
            {
                CBOUnidadDeTrabajo.Items.Add(dtUTrab.Rows[i]["UnidDes_Descripcion"].ToString());
            }
        }
        public void CargarUnidadTiempo()
        {
            DtFac = M.ListarUnidadesDeTiempo("MITCore");
        }
        public void cargarCBOFactor()
        {
            this.cboFactorConv.Items.Clear();
            CargarUnidadTiempo();
            for (int i = 0; i < DtFac.Rows.Count; i++)
            {
                CboCodFactConv.Items.Add(DtFac.Rows[i]["UnidDes_codUni"].ToString());
                cboFactorConv.Items.Add(DtFac.Rows[i]["UnidDes_Descripcion"].ToString());
            }
        }
        public void CargarFactorTiempo()
        {
            FAC = M.ListarFactorDeConversionSeg("MITCore");
        }
        //FACTOR CONVERSION
      //val
        decimal totalseg = 0;
        int horas, minutos, segundos;
        public void ConvertidorSegundos()
        {
            CargarFactorTiempo();
            string FU_U1;
            for (int i = 0; i < lsvMaquin.Items.Count; i++)
            {
                if (DgVTiempoMaquina.Rows.Count != 0)
                {
                    unidadValidar = 0;
                    unidad = DgVTiempoMaquina.Rows[i].Cells[1].Value.ToString().ToLower();
                    CargarCodigoUnidad();

                    for (int n = 0; n < FAC.Rows.Count; n++)
                    {
                        FU_U1 = FAC.Rows[n]["FU_U1"].ToString().ToLower();
                        if (FU_U1 == id)
                        {
                            decimal a = Convert.ToDecimal(FAC.Rows[n]["FU_Factor"]);
                            FU_Factor = a;
                            suma = FU_Factor * Convert.ToInt32(DgVTiempoMaquina.Rows[i].Cells[2].Value);
                        }
                        totalseg += suma;
                        suma = 0;
                    }
                }
            }
        }
        private void CalcularTiempo()
        {
            horas = Convert.ToInt32(totalseg / 3600);
            minutos = Convert.ToInt32((totalseg - horas * 3600) / 60);
            segundos = Convert.ToInt32(totalseg - (horas * 3600 + minutos * 60));
        }
        
        private void BtoCalcularTotal_Click(object sender, EventArgs e)
        {
            txtTiempoTotal.Text = "";
            totalseg = 0;
            ConvertidorSegundos();
            CalcularTiempo();
            txtTiempoTotal.Text = " h: " + horas.ToString()+ " m: "  + minutos.ToString() + " s: "+ segundos.ToString() ; //totalseg.ToString();
        } 
        private void DgVTiempoMaquina_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (DgVTiempoMaquina.Columns[e.ColumnIndex].Name == "colTiempo")
            {
                DgVTiempoMaquina.CellValueChanged += new DataGridViewCellEventHandler(DgVTiempoMaquina_CellValidated);
                //
                // Si el campo esta vacio no lo marco como error, solo lo retorno para ingresar el valor
                //
                if (string.IsNullOrWhiteSpace(e.ToString()))
                    MessageBox.Show("error");
                    return;
            }
        }

    }
}
