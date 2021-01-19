using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using CapaLogicaNegocios;
using CultureResources;

namespace CapaPresentacion
{
    public partial class frmMovDeInventario : Form
    {
        // private const string V = "";
        clsEmpresa EMP = new clsEmpresa();
        frmTbArticulos VentArticulos;
        frmTbAlmacenes VentAlmacenes;
        frmLotes VentLotes;
        //
        DataTable dtMovArt = new DataTable(); //carga los articulos seleccionados
        DataTable dtMovAlmc = new DataTable(); //carga los almacenes seleccionados
        DataTable dtclikAlmc = new DataTable(); //pasa los datos de los almacenes con doble click
        //
        DataTable dtTipoMov = new DataTable(); //carga la lista de tipo de movimiento  
        DataTable dtProc = new DataTable(); //carga la lista de los procesos
        DataTable dtUnidades = new DataTable(); //cargar la lista de unidades
        //
        DataTable Articulos = new DataTable(); //Carga la lista total Articulos
        DataTable DtAlmacenes = new DataTable(); //Carga la lista total almacenes
        DataTable DtInventario = new DataTable(); //Carga la lista de inventario
        //
        DataTable dtMInv = new DataTable(); //carga los datos generales, unifica los dtMovArt y dtMovAlmc para guardar en la base de datos.
        //
        public static string valido = "", accion = ""; //variables de validacion 
        public static int a = 0, cont = 0, posMovART = 0, posMovALM = 0; //contadores
        public string mensajeText = "", mensajeCaption = "", tipoPais = ""; //Variables de idioma
        public string dato1 = "", dato2 = "", dato3 = "";  //Datos de almacenes
        public string unidad = "", id = "";   //unidades
        DialogResult respuesta;
        //
        public int filaDGV; // recoger fila 
        public int unidadValidar; // validacion de cargas de codigos o descripcion de unidades,tipo de mov, procesos.
        public int j = 0, posPr, x; //contador
        //
        public string tipoMov, proc, art; //Variable para almacenar Descripcion
        public string Codproc, codMov, Articulo; //Variable para almacenar Codigo
        string validacion; //Variable de validacion del checkBox de Filtrar por Fechas
        //
        bool dgvCheck = false; // variable para determinar el valor con el que se inicializa el checkbox
        bool IsEmptyCell = false; // variable usada para indicar si esta vacia una celda del DataGrid, inicializada en false
        //-------------------------------------------------------------------------------------------------------------------------
        // DateTimePicker dtp = new DateTimePicker(); // variable para que aparezca el datatimepicker en el DGV
        //Rectangle _Rectangle; // recoge el tamaño de la celda
        //
        DataTable dtFechasFil = new DataTable(); // carga la lista filtrada por fechas 
        DateTime Fechafiltro = DateTime.Now; //varible que almacena las fechas para filtrar la busqueda
        //
        DateTime fecha = DateTime.UtcNow; //almacena la fecha para cagarlo en el data grid
        string eliminar;
        int ArtLot;
        //-------------------------------------------------------------------------------------------------------------------------
        public frmMovDeInventario()
        {
            InitializeComponent();
            FuncionInicio();
        }
        private void frmMovimientoDeInventario_Load(object sender, EventArgs e)
        {
            CargarCboTipoMov();

            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();

            this.Location = new System.Drawing.Point(0, 0);

            dtpInicio.Value = new DateTime((int)Fechafiltro.Year, (int)Fechafiltro.Month, 01);
            dtpFinal.Value = new DateTime((int)Fechafiltro.Year, (int)Fechafiltro.Month, DateTime.DaysInMonth(Fechafiltro.Year, Fechafiltro.Month));
        }
        //---------------------------------------------------------------------------------------------------------------------------
        public void CargarlistadoTipoMov()
        {
            dtTipoMov = EMP.Listado_TipoMovimientoInventario(frmPrincipal.nombreBD);
        }
        public void CargarCboTipoMov()
        {
            // this.ColCBOTipoMov.Items.Clear();
            CargarlistadoTipoMov();

            //if (valido == "tipomov")
            //{
            //    for (int i = 0; i < dtTipoMov.Rows.Count; i++)
            //    {
            //        ColCBOTipoMov.Items.Add(dtTipoMov.Rows[i]["TipoMov_Descrip"].ToString());
            //    }
            //}
            //else
            //{
            for (int i = 0; i < dtTipoMov.Rows.Count; i++)
            {
                cboCodTipoMov.Items.Add(dtTipoMov.Rows[i]["TipoMov_Codigo"].ToString());
                cboTipoMov.Items.Add(dtTipoMov.Rows[i]["TipoMov_Descrip"].ToString());
            }
            //}
        }
        public void CargarListadoProcesos()
        {
            dtProc = EMP.Listado_ProcesosInventario(frmPrincipal.nombreBD);
        }
        public void CargarCboProcesos()
        {
            this.ColCBOProceso.Items.Clear();
            CargarListadoProcesos();

            for (int i = 0; i < dtProc.Rows.Count; i++)
            {
                ColCBOProceso.Items.Add(dtProc.Rows[i]["Proc_Descrip"].ToString());
            }
        }
        //
        public void CargarCodigoArticulos()
        {

            Articulos = EMP.ListadoArticulos(frmPrincipal.nombreBD);

            if (unidadValidar == 0)
            {
                for (int i = 0; i < Articulos.Rows.Count; i++)
                {
                    if (Articulos.Rows[i]["art_Id"].ToString().ToLower() == Articulo.ToLower())
                    {
                        art = Articulos.Rows[i]["art_Nom"].ToString();
                        return;
                    }
                }
            }
            else if (unidadValidar == 1)
            {
                if (DgvMovDeInventario.Rows.Count != 0)
                {
                    for (int n = 0; n < Articulos.Rows.Count; n++)
                    {
                        if (Articulos.Rows[n]["art_Nom"].ToString().ToLower() == art.ToLower())
                        {
                            Articulo = Articulos.Rows[n]["art_Id"].ToString();
                            return;
                        }
                    }
                }
            }
        }
        //
        public void CargarCodigoUnidad()
        {
            CargarUnidades();
            if (unidadValidar == 0)
            {
                for (int i = 0; i < dtUnidades.Rows.Count; i++)
                {
                    if (dtUnidades.Rows[i]["UnidDes_codUni"].ToString().ToLower() == unidad.ToLower())
                    {
                        id = dtUnidades.Rows[i]["UnidDes_Descripcion"].ToString();
                        return;
                    }
                }
            }

            else if (unidadValidar == 1)
            {
                if (DgvMovDeInventario.Rows.Count != 0)
                {
                    for (int n = 0; n < dtUnidades.Rows.Count; n++)
                    {
                        if (dtUnidades.Rows[n]["UnidDes_Descripcion"].ToString().ToLower() == unidad.ToLower())
                        {
                            id = dtUnidades.Rows[n]["UnidDes_codUni"].ToString();
                            return;
                        }
                    }
                }
            }
        }
        public void CargarUnidades()
        {
            dtUnidades = EMP.ListarUnidadesDescripcionMVL("MITCore");
        }
        //
        private void ConstruccionDtInvent()
        {
            dtMInv.Rows.Clear();
            dtMInv.Columns.Clear();
            dtMInv.Columns.Add("Inv_CodArt", Type.GetType("System.String"));
            dtMInv.Columns.Add("Inv_Fecha", Type.GetType("System.String"));
            dtMInv.Columns.Add("Inv_TipoMov", Type.GetType("System.String"));
            dtMInv.Columns.Add("Inv_Almacen", Type.GetType("System.String"));
            dtMInv.Columns.Add("Inv_Cantidad", Type.GetType("System.String"));
            dtMInv.Columns.Add("Inv_Unidad", Type.GetType("System.String"));
            dtMInv.Columns.Add("Inv_Proceso", Type.GetType("System.String"));
        }
        public void CargarDatosArt(DataTable dtArticulos)
        {
            unidadValidar = 0;

            this.ColCheck.Visible = true;
            DgvMovDeInventario.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";

            if (valido == "Mov-TbArticulos")
            {
                Articulos = EMP.ListadoArticulos(frmPrincipal.nombreBD);
                if (Articulos.Rows.Count > 0) //valerie
                {
                    a = 0;
                    for (int i = 0; i < dtArticulos.Rows.Count; i++)
                    {
                        unidad = dtArticulos.Rows[i]["unidad"].ToString();
                        CargarCodigoUnidad();
                        this.DgvMovDeInventario.Rows.Add(dgvCheck,
                            dtArticulos.Rows[i]["descripcion"].ToString(),
                            "...",
                            fecha,
                            cboTipoMov.Text,
                            "",
                            "...",
                            "", //  dtArticulos.Rows[i]["medida"].ToString(),
                            id,
                            "",
                            dtArticulos.Rows[i]["LOTE"].ToString());
                        Articulo = dtArticulos.Rows[i]["codigo"].ToString();
                    }
                    posMovART = DgvMovDeInventario.Rows.Count;
                }
            }
        }
        //
        public void CargarCodProcesos()
        {
            CargarListadoProcesos();

            if (unidadValidar == 0)
            {
                for (int i = 0; i < dtProc.Rows.Count; i++)
                {
                    if (dtProc.Rows[i]["Proc_Codigo"].ToString().ToLower() == Codproc.ToLower())
                    {
                        proc = dtProc.Rows[i]["Proc_Descrip"].ToString();
                        return;
                    }
                }
            }
            if (unidadValidar == 1)
            {
                for (int i = 0; i < dtProc.Rows.Count; i++)
                {
                    if (dtProc.Rows[i]["Proc_Descrip"].ToString().ToLower() == proc.ToLower())
                    {
                        Codproc = dtProc.Rows[i]["Proc_Codigo"].ToString();
                        return;
                    }
                }
            }
        }
        public void CargarCodTipoMov()
        {
            CargarlistadoTipoMov();
            if (unidadValidar == 0)
            {
                for (int i = 0; i < dtTipoMov.Rows.Count; i++)
                {
                    if (dtTipoMov.Rows[i]["TipoMov_Codigo"].ToString().ToLower() == codMov.ToLower())
                    {
                        tipoMov = dtTipoMov.Rows[i]["TipoMov_Descrip"].ToString();

                        return;
                    }
                }
            }
            //if (unidadValidar == 1)
            //{
            //    for (int i = 0; i < dtTipoMov.Rows.Count; i++)
            //    {
            //        if (dtTipoMov.Rows[i]["TipoMov_Descrip"].ToString().ToLower() == tipoMov.ToLower())
            //        {
            //            codMov = dtTipoMov.Rows[i]["TipoMov_Codigo"].ToString();
            //            return;
            //        }
            //    }
            //}
        }
        //
        public void ConstruccionDtMovAlmacen()
        {
            dtclikAlmc.Rows.Clear();
            dtclikAlmc.Columns.Clear();
            dtclikAlmc.Columns.Add("IdDtMov", Type.GetType("System.String"));
            dtclikAlmc.Columns.Add("NombreDtMov", Type.GetType("System.String"));
            dtclikAlmc.Columns.Add("DescripcionDtMov", Type.GetType("System.String"));
        }
        public void datosdobleclickAlmacen()
        {
            j = 0;
            ConstruccionDtMovAlmacen();
            dtclikAlmc.Rows.Add();
            dtclikAlmc.Rows[j]["IdDtMov"] = dato1;
            dtclikAlmc.Rows[j]["NombreDtMov"] = dato2;
            dtclikAlmc.Rows[j]["DescripcionDtMov"] = dato3;

            filaDGV = DgvMovDeInventario.CurrentRow.Index;
            this.DgvMovDeInventario.Rows[filaDGV].Cells[5].Value = dtclikAlmc.Rows[j]["NombreDtMov"].ToString();
        }

        //DataTable dtLote = new DataTable();
        //private void ConstruccionDtLotes()
        //{
        //    dtLote.Rows.Clear();
        //    dtLote.Columns.Clear();
        //    dtLote.Columns.Add("lot_coArt", Type.GetType("System.String"));
        //    dtLote.Columns.Add("lot_nroLote", Type.GetType("System.String"));
        //    dtLote.Columns.Add("lot_fecVencimiento", Type.GetType("System.String"));
        //}

        public void ejecutarMInvAlmacenes(string[,] datoMov)
        {
            dato1 = datoMov[0, 0];
            dato2 = datoMov[0, 1];
            dato3 = datoMov[0, 2];

            datosdobleclickAlmacen();
        }
        //--------------------------------------------------------------------------------------------------------
        private void toolStripBtoAgregar_Click(object sender, EventArgs e)
        {
            accion = "agregar";
            FuncionAgregar();
        }
        private void toolStripBtoEditar_Click(object sender, EventArgs e)
        {
            accion = "editar";
            FuncionEditar();
        }
        private void toolStripBtoGuardar_Click(object sender, EventArgs e)
        {
            DgvMovDeInventario.EndEdit();
            DgvMovDeInventario.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            if (accion == "agregar" || accion == "editar" || accion == "pasado")
            {
                ValidadCampos();

                if (IsEmptyCell == true)
                {
                    mensajeCaption = StringResources.Validacióndecampos;
                    mensajeText = StringResources.ExistenCamposVacios;

                    MessageBox.Show(mensajeText, mensajeCaption,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return;
                }
                ColCheck.Visible = false;
                FuncionGuardar();
                FuncionInicio();
            }
        }
        private void toolStripBtoEliminar_Click(object sender, EventArgs e)
        {
            eliminarDgvArt();
            eliminar = "si";
        }
        private void toolStripBtoDescartar_Click(object sender, EventArgs e)
        {
            FuncionInicio();
        }
        private void BtoEliminarArticulos_Click(object sender, EventArgs e)
        {
            DgvMovDeInventario.AllowUserToAddRows = true;
            foreach (DataGridViewRow fila in DgvMovDeInventario.Rows)
            {
                if (Convert.ToBoolean(fila.Cells["ColCheck"].Value) == true)
                {
                    BtoEliminarInv.Enabled = true;
                    eliminarDgvArt();
                }
            }
            BtoEliminarInv.Enabled = false;
        }
        //
        private void btoBuscar_Click(object sender, EventArgs e)
        {
            valido = "tipomov";
            HabilitarBotones();
            CargarCboProcesos();

            DgvMovDeInventario.Enabled = true;
            DgvMovDeInventario.Rows.Clear();
            if (CBFiltarFechas.Checked == false)
            {
                if (cboTipoMov.Text != "")
                {
                    EMP.codigo = cboCodTipoMov.Text;
                    DtInventario = EMP.Listado_InvTipoMovFiltro(frmPrincipal.nombreBD);

                    for (int i = 0; i < DtInventario.Rows.Count; i++)
                    {
                        unidadValidar = 0;
                        Articulo = DtInventario.Rows[i]["Inv_CodArt"].ToString();
                        CargarCodigoArticulos();
                        //
                        unidad = DtInventario.Rows[i]["Inv_Unidad"].ToString();
                        CargarCodigoUnidad();
                        //
                        codMov = DtInventario.Rows[i]["Inv_TipoMov"].ToString();
                        CargarCodTipoMov();
                        //
                        Codproc = DtInventario.Rows[i]["Inv_Proceso"].ToString();
                        CargarCodProcesos();
                        //
                        this.DgvMovDeInventario.Rows.Add(dgvCheck,
                             art, "...",
                             DtInventario.Rows[i]["Inv_Fecha"].ToString(),
                             " ",
                             DtInventario.Rows[i]["Inv_Almacen"].ToString(), "...",
                             DtInventario.Rows[i]["Inv_Cantidad"].ToString(),
                             id,
                             " ",
                             " " );
                        DgvMovDeInventario.Rows[i].Cells[4].Value = tipoMov;
                        DgvMovDeInventario.Rows[i].Cells["ColCBOProceso"].Value = proc;
                    }
                }
            }
            if (CBFiltarFechas.Checked == true)
            {
                if (dtpInicio.Text != "" && dtpFinal.Text != "")
                {
                    if (cboTipoMov.Text == "")
                    {
                        mensajeCaption = StringResources.Validacióndecampos;
                        mensajeText = StringResources.ExistenCamposVacios;

                        MessageBox.Show(mensajeText, mensajeCaption,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        return;
                    }
                    EMP.inicio = dtpInicio.Value;
                    EMP.fin = dtpFinal.Value;
                    EMP.codigo = cboCodTipoMov.Text;

                    dtFechasFil = EMP.Listado_FechaFiltro(frmPrincipal.nombreBD);

                    for (int i = 0; i < dtFechasFil.Rows.Count; i++)
                    {
                        unidadValidar = 0;
                        //
                        Articulo = dtFechasFil.Rows[i]["Inv_CodArt"].ToString();
                        CargarCodigoArticulos();
                        //
                        unidad = dtFechasFil.Rows[i]["Inv_Unidad"].ToString();
                        CargarCodigoUnidad();
                        //
                        codMov = dtFechasFil.Rows[i]["Inv_TipoMov"].ToString();
                        CargarCodTipoMov();
                        //
                        Codproc = dtFechasFil.Rows[i]["Inv_Proceso"].ToString();
                        CargarCodProcesos();
                        //
                        this.DgvMovDeInventario.Rows.Add(dgvCheck,
                             art, "...",
                             dtFechasFil.Rows[i]["Inv_Fecha"].ToString(),
                             " ",
                             dtFechasFil.Rows[i]["Inv_Almacen"].ToString(), "...",
                             dtFechasFil.Rows[i]["Inv_Cantidad"].ToString(),
                             id,
                             " ", 
                             " ");
                        DgvMovDeInventario.Rows[i].Cells[4].Value = tipoMov;
                        DgvMovDeInventario.Rows[i].Cells["ColCBOProceso"].Value = proc;
                    }
                    j++;
                }
            }
        }
        private void btoSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //--------------------------------------------------------------------------------------------------------
        private void DgvMovDeInventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DgvMovDeInventario.CommitEdit(DataGridViewDataErrorContexts.Commit);

            if (accion == "agregar" || accion == "editar" || accion == "pasado")
            {
                foreach (DataGridViewRow fila in DgvMovDeInventario.Rows)
                {
                    if (Convert.ToBoolean(fila.Cells["ColCheck"].Value) == true)
                    {
                        BtoEliminarInv.Enabled = true;
                        return;
                    }
                    else
                    {
                        BtoEliminarInv.Enabled = false;
                    }
                }
            }
        }
        private void DgvMovDeInventario_CurrentCellChanged(object sender, EventArgs e)
        {
            if (DgvMovDeInventario.CurrentCell is System.Windows.Forms.DataGridViewCheckBoxCell)
            {
                DgvMovDeInventario.CommitEdit(DataGridViewDataErrorContexts.Commit); //permite guardar los cambios realizados en el DGV sin salir del modo edicion
            }
        }
        private void DgvMovDeInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // dtp.Location = new System.Drawing.Point(237, 51);

            filaDGV = DgvMovDeInventario.CurrentRow.Index; //recoge el valor de la fila en la que esta posicionado el cursor
            //
            if (e.ColumnIndex == 2)
            {
                if (cboTipoMov.Text == "")
                {
                    mensajeText = "ESTE MENSAJE ES TEMPORAL Debe ingresar el tipo de movimiento para poder asociar articulos";
                    mensajeCaption = StringResources.Validacióndecampos;
                    MessageBox.Show(mensajeText, mensajeCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    valido = "Mov-TbArticulos";
                    cont = DgvMovDeInventario.RowCount;
                    VentArticulos = new frmTbArticulos();
                    VentArticulos.dtRelArtic += new frmTbArticulos.relacion(CargarDatosArt);
                    VentArticulos.ShowDialog();
                    valido = "";
                }
            }
            
            if (e.ColumnIndex == 4)
            {
                valido = "tipomov";
                if (Convert.ToString(this.DgvMovDeInventario.Rows[filaDGV].Cells[1].Value) == "")
                {
                    mensajeText = "ESTE MENSAJE ES TEMPORAL Debe ingresar un articulo para poder asociar un tipo de movimiento";
                    mensajeCaption = StringResources.Validacióndecampos;
                    MessageBox.Show(mensajeText, mensajeCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    // CargarCboTipoMov();
                }
            }

            if (e.ColumnIndex == 6)
            {
                if (Convert.ToString(this.DgvMovDeInventario.Rows[filaDGV].Cells[1].Value) == "")
                {
                    mensajeText = "ESTE MENSAJE ES TEMPORAL Debe ingresar un articulo para poder asociar un almacen";
                    mensajeCaption = StringResources.Validacióndecampos;
                    MessageBox.Show(mensajeText, mensajeCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    valido = "Mov-TbAlmacenes";
                    VentAlmacenes = new frmTbAlmacenes();
                    VentAlmacenes.pasadoMov += new frmTbAlmacenes.pasarMov(ejecutarMInvAlmacenes);
                    VentAlmacenes.ShowDialog();
                    valido = "";
                }
            }
            //
            if (e.ColumnIndex == 7)
            {
                if (Convert.ToString(this.DgvMovDeInventario.Rows[filaDGV].Cells[1].Value) == "")
                {
                    mensajeText = "ESTE MENSAJE ES TEMPORAL Debe ingresar un articulo para poder asociar la cantidad";
                    mensajeCaption = StringResources.Validacióndecampos;
                    MessageBox.Show(mensajeText, mensajeCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                filaDGV = DgvMovDeInventario.CurrentRow.Index;
            }
            if (e.ColumnIndex == 9)
            {
                if (Convert.ToString(this.DgvMovDeInventario.Rows[filaDGV].Cells[1].Value) == "")
                {
                    mensajeText = "ESTE MENSAJE ES TEMPORAL Debe ingresar un articulo para poder asociar un Proceso";
                    mensajeCaption = StringResources.Validacióndecampos;
                    MessageBox.Show(mensajeText, mensajeCaption,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    CargarCboProcesos();
                }
            }
        }
        public static class ClaseCompartida  // se declara variables estaticas para compartir informacion entre formula
        {
            public static string Articulo1;
            public static string AlmacenLote;
            public static string CantidadLote;
            
        }
        private void DgvMovDeInventario_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (this.DgvMovDeInventario.Rows[filaDGV].Cells["colLoteCheck"].Value.ToString() == "1")
            {

                if (e.ColumnIndex == 7)
                {
                    filaDGV = DgvMovDeInventario.CurrentRow.Index;
                    if (this.DgvMovDeInventario.Rows[filaDGV].Cells[7].Value.ToString() == "0" || this.DgvMovDeInventario.Rows[filaDGV].Cells[7].Value.ToString() == "")
                    {
                        mensajeText = "la cantidad no puede ser igual a 0 o estar en blanco";
                        mensajeCaption = StringResources.Validacióndecampos;
                        MessageBox.Show(mensajeText, mensajeCaption,
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else if (x != 0)
                    {
                        valido = "Nro-Lote";
                        art = DgvMovDeInventario.Rows[filaDGV].Cells[1].Value.ToString().ToLower();
                        CargarCodigoArticulos();
                        ClaseCompartida.Articulo1 = Articulo;
                        ClaseCompartida.AlmacenLote = DgvMovDeInventario.Rows[filaDGV].Cells[5].Value.ToString().ToLower();
                        ClaseCompartida.CantidadLote = DgvMovDeInventario.Rows[filaDGV].Cells[7].Value.ToString().ToLower();
                        VentLotes = new frmLotes();
                        VentLotes.ShowDialog();
                        valido = "";
                    }
                }
            }
        }
        private void DgvMovDeInventario_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if(e.ColumnIndex == 7)
            {
                DgvMovDeInventario.AllowUserToAddRows = false;
               
                if (!int.TryParse(Convert.ToString(e.FormattedValue), out x))
                {
                    if (x == 0)
                    {
                        MessageBox.Show("Solo puede ingresar valores numericos", "validacion",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;

                    }
                    //e.Cancel = true;
                    
                }
            }
           
        }
        //----------------------------------------------------------------------------------------------------------------------------------
        private void cboTipoMov_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCodTipoMov.SelectedIndex = cboTipoMov.SelectedIndex;
            if (this.DgvMovDeInventario.Rows.Count - 1 != 0)
            {
                for (int i = 0; i < DgvMovDeInventario.Rows.Count - 1; i++)
                {
                    DgvMovDeInventario.Rows[i].Cells[4].Value = cboTipoMov.Text;
                }

            }
            //CargarTipoMov();
        }
        private void MovDeInventario_KeyDown(object sender, KeyEventArgs e)
        {
            if (accion == "inicio")
            {
                if (e.KeyCode == Keys.F5)
                {
                    FuncionAgregar();
                }
            }
            else if (accion == "editar" || accion == "pasado")
            {
                if (e.KeyCode == Keys.F6)
                {
                    accion = "editar";
                    FuncionEditar();
                }
            }
            else if (accion == "agregar" || accion == "editar")
            {
                if (e.KeyCode == Keys.F7)
                {
                    FuncionGuardar();
                }
            }
            else if (accion == "editar")
            {
                if (e.KeyCode == Keys.F8)
                {
                    //  FuncionEliminar();
                }
            }
            if (e.KeyCode == Keys.F9)
            {
                limpiarCajas();
                FuncionInicio();
            }
            if (e.KeyCode == Keys.F1)
            {
                if (this.DgvMovDeInventario.Rows.Count != 0)
                {
                    if (this.DgvMovDeInventario.Rows[filaDGV].Cells["colLoteCheck"].Value.ToString() == "0")
                    {
                        valido = "sin-lote";
                        VentLotes = new frmLotes();
                        VentLotes.ShowDialog();
                        valido = "";
                    }
                    else if (this.DgvMovDeInventario.Rows[filaDGV].Cells["colLoteCheck"].Value.ToString() == "1")
                    {
                        valido = "Nro-Lote";
                        art = DgvMovDeInventario.Rows[filaDGV].Cells[1].Value.ToString().ToLower();
                        CargarCodigoArticulos();
                        ClaseCompartida.Articulo1 = Articulo;
                        ClaseCompartida.AlmacenLote = DgvMovDeInventario.Rows[filaDGV].Cells[5].Value.ToString().ToLower();
                        ClaseCompartida.CantidadLote = DgvMovDeInventario.Rows[filaDGV].Cells[7].Value.ToString().ToLower();
                        VentLotes = new frmLotes();
                        VentLotes.ShowDialog();
                        valido = "";
                    }
                }
            }
        }
        private void DTPfechaRegistro_ValueChanged(object sender, EventArgs e)
        {
            fecha = DTPfechaRegistro.Value.Date;
            if (this.DgvMovDeInventario.Rows.Count - 1 != 0)
            {
                for (int i = 0; i < DgvMovDeInventario.Rows.Count - 1; i++)
                {
                    DgvMovDeInventario.Rows[i].Cells[3].Value = fecha;
                }
                DgvMovDeInventario.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }
        private void CBFiltarFechas_CheckedChanged(object sender, EventArgs e)
        {
            if (CBFiltarFechas.Checked == true)
            {
                dtpFinal.Enabled = true;
                dtpInicio.Enabled = true;
                dtpFinal.Visible = true;
                dtpInicio.Visible = true;
                lblFechaFinal.Visible = true;
                lblFechaInicial.Visible = true;

            }
            else if (CBFiltarFechas.Checked == false)
            {
                dtpFinal.Enabled = false;
                dtpInicio.Enabled = false;
                dtpFinal.Visible = false;
                dtpInicio.Visible = false;
                lblFechaFinal.Visible = false;
                lblFechaInicial.Visible = false;
            }
        }
        //--------------------------------------------------------------------------------------------------------
        public void ValidadCampos() //Indica si existen campos vacios en el data grid, i = filas , j = columnas
        {
            DgvMovDeInventario.AllowUserToAddRows = false;
            for (int i = 0; i < DgvMovDeInventario.RowCount; i++) //i
            {
                for (int j = 0; j < DgvMovDeInventario.ColumnCount; j++) //j
                {
                    if (DgvMovDeInventario.Rows[i].Cells[j].Value == null) //recoge la celda vacia
                    {
                        IsEmptyCell = true;  // cambia el valor inicial de la variable 
                        return;
                    }
                }
            }
        }
        public void HabilitarBotones()
        {
            DgvMovDeInventario.AllowUserToAddRows = false; //elimina la celda vacia al final del data grid, idicando que el usuario no puede agg filas
            DgvMovDeInventario.Enabled = false;

            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            this.toolStripBtoEliminar.Enabled = true;
            this.toolStripBtoEditar.Enabled = true;
            this.BtoEliminarInv.Enabled = false;
            this.btoBuscar.Enabled = true;
        }
        public void FuncionInicio()
        {
            limpiarCajas();
            accion = "inicio";
            this.toolStripBtoDescartar.Enabled = false;
            this.toolStripBtoEliminar.Enabled = false;
            this.toolStripBtoGuardar.Enabled = false;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoAgregar.Enabled = true;
            this.BtoEliminarInv.Enabled = false;
            this.btoBuscar.Enabled = true;
            //
            DgvMovDeInventario.AllowUserToAddRows = false;
            DgvMovDeInventario.Enabled = false;
            //----------------------------------------------------------------
            lblFechaInicial.Visible = false;
            lblFechaFinal.Visible = false;
            dtpInicio.Visible = false;
            dtpInicio.Enabled = false;
            dtpFinal.Enabled = false;
            dtpFinal.Visible = false;
            //
            lblFecha.Visible = false;
            DTPfechaRegistro.Visible = false;
            //
            CBFiltarFechas.Visible = true;
            this.cboTipoMov.Text = "";
            
        }
        public void FuncionAgregar()
        {
            accion = "agregar";

            this.txtCod.Focus();
            this.txtCod.Enabled = true;
            this.txtDescrip.Enabled = true;

            this.toolStripBtoDescartar.Enabled = true;
            this.toolStripBtoEliminar.Enabled = false;
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoGuardar.Enabled = true;
            this.toolStripBtoEditar.Enabled = false;
            this.BtoEliminarInv.Enabled = false;
            this.btoBuscar.Enabled = false;

            DgvMovDeInventario.AllowUserToAddRows = true; //AGG la celda vacia del data grid, idicando que el usuario que puede agg filas
            DgvMovDeInventario.Enabled = true;
            DgvMovDeInventario.Columns[1].ReadOnly = true;
            DgvMovDeInventario.Columns[3].ReadOnly = true;
            DgvMovDeInventario.Columns[5].ReadOnly = true;
            DgvMovDeInventario.Columns[8].ReadOnly = true;

            lblFecha.Visible = true;
            DTPfechaRegistro.Visible = true;
            DTPfechaRegistro.Value = DateTime.Now;
            //
            CBFiltarFechas.Visible = false;

        }
        public void ValidarCampos()
        {
            if (cboTipoMov.Text == "")
            {
                validacion = "no";
                Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
                mensajeText = "MENSAJE TEMPORAL" + " " + StringResources.SeleccionarTipoMov;
                mensajeCaption = StringResources.ErrordeValidacion;

                MessageBox.Show(mensajeText, mensajeCaption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            else
            {
                validacion = "si";
            }
        }
        public void FuncionGuardar()
        {
            j = 0;
            ConstruccionDtInvent();
            DgvMovDeInventario.AllowUserToAddRows = false;
            ValidarCampos();
            if (validacion == "si")
            {

                for (int i = 0; i < DgvMovDeInventario.Rows.Count; i++)
                {
                    unidadValidar = 1;
                    art = DgvMovDeInventario.Rows[i].Cells[1].Value.ToString().ToLower();
                    CargarCodigoArticulos();
                    //
                    unidad = DgvMovDeInventario.Rows[i].Cells[8].Value.ToString().ToLower();
                    CargarCodigoUnidad();
                    //
                    tipoMov = Convert.ToString(cboCodTipoMov.Text);
                    // CargarCodTipoMov();
                    //
                    proc = Convert.ToString(DgvMovDeInventario.Rows[i].Cells[9].Value);
                    CargarCodProcesos();
                    //
                    dtMInv.Rows.Add();
                    dtMInv.Rows[j]["Inv_CodArt"] = Articulo;
                    dtMInv.Rows[j]["Inv_Fecha"] = fecha;/*Convert.ToDateTime(DgvMovDeInventario.Rows[i].Cells[3].Value.ToString())*/;
                    dtMInv.Rows[j]["Inv_TipoMov"] = tipoMov;
                    dtMInv.Rows[j]["Inv_Almacen"] = DgvMovDeInventario.Rows[i].Cells[5].Value;
                    dtMInv.Rows[j]["Inv_Cantidad"] = Convert.ToInt64(DgvMovDeInventario.Rows[i].Cells[7].Value);
                    dtMInv.Rows[j]["Inv_Unidad"] = id;
                    dtMInv.Rows[j]["Inv_Proceso"] = Codproc;
                    j++;
                }
                if (j != 0)
                {
                    EMP.RegistrarMovInvetario(dtMInv, frmPrincipal.nombreBD);
                }
                if (DgvMovDeInventario.Rows.Count == 0)
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
                    mensajeText = StringResources.ExistenCamposVacios;
                    mensajeCaption = StringResources.ValidaciondeRegistro;

                    MessageBox.Show(mensajeText, mensajeCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                else
                {
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
                    mensajeText = StringResources.DBRegistroexitoso;
                    mensajeCaption = StringResources.ValidaciondeRegistro;

                    MessageBox.Show(mensajeText, mensajeCaption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
            }
        }
        public void FuncionEditar()
        {
            accion = "editar";
           
            this.txtCod.Focus();
            this.txtCod.Enabled = false;
            this.txtDescrip.Enabled = true;
           
            this.toolStripBtoGuardar.Enabled = true;
            this.toolStripBtoAgregar.Enabled = false;
            this.toolStripBtoEliminar.Enabled = true;
            this.toolStripBtoEditar.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
            this.btoBuscar.Enabled = false;
            this.ColCheck.Visible = true;

            this.BtoEliminarInv.Enabled = false;
            DgvMovDeInventario.AllowUserToAddRows = true;

            lblFecha.Visible = true;
            DTPfechaRegistro.Visible = true;
            DTPfechaRegistro.Value = DateTime.Now;
            //
            CBFiltarFechas.Visible = false;

        }
        private void limpiarCajas()
        {
            this.txtCod.Clear();

            this.txtDescrip.Clear(); 

            this.cboTipoMov.Text = " ";
            cboCodTipoMov.SelectedIndex = -1;
            cboTipoMov.SelectedIndex = -1;
            this.DgvMovDeInventario.Enabled = false;
            this.DgvMovDeInventario.Rows.Clear();

            this.BtoEliminarInv.Enabled = false;
        }
        private void eliminarDgvArt()
        {
            if (accion == "agregar" || accion == "pasado" || accion == "editar")
            {
                for (int i = 0; i < DgvMovDeInventario.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(DgvMovDeInventario.Rows[i].Cells["ColCheck"].Value) == true)
                    {
                        DgvMovDeInventario.Enabled = true;
                        DgvMovDeInventario.Rows.RemoveAt(i);
                        i--;
                    }
                }
            }
            if (eliminar == "si")
            {
                string msj = "";

                for (int i = 0; i < DgvMovDeInventario.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(DgvMovDeInventario.Rows[i].Cells["ColCheck"].Value) == true)
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
                        ConstruccionDtInvent();
                        unidadValidar = 1;

                        for (int a = 0; a < DgvMovDeInventario.Rows.Count; a++)
                        {
                            if (Convert.ToBoolean(DgvMovDeInventario.Rows[a].Cells["ColCheck"].Value) == true)
                            {
                                art = DgvMovDeInventario.Rows[i].Cells[1].Value.ToString().ToLower();
                                CargarCodigoArticulos();
                                //
                                unidad = DgvMovDeInventario.Rows[i].Cells[8].Value.ToString().ToLower();
                                CargarCodigoUnidad();
                                //
                                tipoMov = Convert.ToString(cboCodTipoMov.Text);

                                // CargarCodTipoMov();
                                //
                                proc = Convert.ToString(DgvMovDeInventario.Rows[i].Cells[9].Value);
                                CargarCodProcesos();
                                //
                                dtMInv.Rows.Add();
                                dtMInv.Rows[j]["Inv_CodArt"] = Articulo;
                                dtMInv.Rows[j]["Inv_Fecha"] = Convert.ToDateTime(DgvMovDeInventario.Rows[i].Cells[3].Value);
                                dtMInv.Rows[j]["Inv_TipoMov"] = tipoMov;
                                dtMInv.Rows[j]["Inv_Almacen"] = DgvMovDeInventario.Rows[i].Cells[5].Value;
                                dtMInv.Rows[j]["Inv_Cantidad"] = Convert.ToInt64(DgvMovDeInventario.Rows[i].Cells[7].Value);
                                dtMInv.Rows[j]["Inv_Unidad"] = id;
                                dtMInv.Rows[j]["Inv_Proceso"] = Codproc;
                                //***************************
                                j++;
                                DgvMovDeInventario.Rows.RemoveAt(i);
                                posMovART--;
                                a--;
                            }
                        }

                        if (j != 0)
                        {
                            msj = EMP.EliminarMovIn(frmPrincipal.nombreBD);
                        }
                    }
                }
            }
        }
        public void AplicarIdioma()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(tipoPais);
            this.Text = StringResources.MovimientoDeInventario;
            this.lblTituloPanel.Text = StringResources.MovimientoDeInventario;
            //
            this.toolStripBtoDescartar.Text = StringResources.btoDescartar;
            this.toolStripBtoGuardar.Text = StringResources.btoGuardar;
            this.toolStripBtoEliminar.Text = StringResources.btoEliminar;
            this.toolStripBtoAgregar.Text = StringResources.btoAgregar;
            this.toolStripBtoEditar.Text = StringResources.btoEditar;
            //
            this.toolStripBtoDescartar.ToolTipText = StringResources.btoDescartar;
            this.toolStripBtoEliminar.ToolTipText = StringResources.btoEliminar;
            this.toolStripBtoGuardar.ToolTipText = StringResources.btoGuardar;
            this.toolStripBtoAgregar.ToolTipText = StringResources.btoAgregar;
            this.toolStripBtoEditar.ToolTipText = StringResources.btoEditar;
            //
            this.lblTipoMov.Text = StringResources.TipoDeMovimiento;
            this.lblFechaInicial.Text = StringResources.Desde;
            this.lblFechaFinal.Text = StringResources.Hasta;
            this.btoBuscar.Text = StringResources.btnBuscar;
            //
            this.tpgInfoGeneral.Text = StringResources.Informaciongeneral;
            this.lblInventario.Text = StringResources.Inventario;
            //
            this.ColCBOProceso.HeaderText = StringResources.ProcesoInv;
            this.ColArticulos.HeaderText = StringResources.Articulos;
            this.ColCantidad.HeaderText = StringResources.Cantidad;
            this.ColAlmacen.HeaderText = StringResources.Almacen;
            this.ColUnidad.HeaderText = StringResources.Unidad;
            this.ColFecha.HeaderText = StringResources.fecha;
            //
            this.btoSalir.Text = StringResources.btnSalir;
        }
    }
}
