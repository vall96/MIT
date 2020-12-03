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
using CultureResources; //Oscar
using System.Threading; //Oscar
using System.Globalization; //Oscar

namespace CapaPresentacion
{
    public partial class frmRelacionSucAlm : Form
    {
        public frmRelacionSucAlm()
        {
            InitializeComponent();
            funcionInicio();
            cargar_CboEmpresa();
            
        }
        clsEmpresa Suc = new clsEmpresa();
        string existeBD = "", emp = "", emprBD = "";
        public static string tipoPais = "";
        public static string nombreBd, nomCompleto = "", activarChek = "";
        public string mensajeText = "", sucursal = "", mensajeCaption = "";
        int a, tab = 0, cont = 0, codigoSuc, codigoAlm,j, pos, count=0;
        public static int  b = 0, statusLsv;
        public static string[,] codAlmAsociados;
        //string[,] codAlmAsociados = new string[1,20];                   //pendiente con este tamano
        string almacen;
        ListViewItem lvrow;
        DataTable dts = new DataTable();
        DataTable dte = new DataTable();
        DataTable dtr = new DataTable();
        public static DataTable dta = new DataTable();
        DataTable dt = new DataTable();
        frmTbSucursales ventSucursales;
        frmTbAlmacenes ventAlmacenes;
        Boolean existe;
        private void funcionInicio()
        {
            tab = 0;
            //this.lblSinAlmacen.Enabled = false;
            this.cboxEmpresas.Enabled = true;
            this.cboxEmpresas.Enabled = true;
            //----------------------------------------
            this.toolStripBtoDescartar.Enabled = false;
            this.toolStripBtoGuardar.Enabled = false;
            //this.cboxEmpresas.SelectedIndex = 0;
            this.lblNohaySucursales.Visible = false;
            //****************************************
            this.cboxEmpresas.Enabled = true;
            this.btnPuntos.Enabled = true;
            //***Cajas************
            txtCodigo.Enabled = true;
            txtNombre.Enabled = true;
            //-------------------------
            this.txtCod.Enabled = false;
            this.txtNom.Enabled = false;
            this.txtDescripcion.Enabled = false;
            this.txtContacto.Enabled = false;
            this.cboNombreCorto.Enabled = false;
            this.tbCRelacionSucAlm.TabPages.Remove(tbpgAlmAsociados);
        }

        private void btoSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPuntos_Click(object sender, EventArgs e)
        {
            this.lblNohaySucursales.Visible = false;
            funcionBuscarBd();
            if (existeBD == "no")
            {
                this.lblNohaySucursales.Visible = true;
                this.lblNohaySucursales.Text = this.cboNombreCorto.Text + " No tiene\nSucursales Asociadas";
            }
            else
                if (existeBD == "si")
            {
                frmSucursales.nombreBd = cboNombreCorto.Text;
                frmSucursales.nomCompleto = cboxEmpresas.Text;
                ventSucursales = new frmTbSucursales();
                if (frmTbSucursales.Sucursales == 0)
                {
                    this.lblNohaySucursales.Visible = true;
                    this.lblNohaySucursales.Text = this.cboNombreCorto.Text + " No tiene\nSucursales Asociadas";
                }
                else
                {
                    ventSucursales.pasado += new frmTbSucursales.pasar(ejecutar);                  
                    ventSucursales.ShowDialog();
                }
            }
        }

        public void ejecutar(string[,] dato)
        {
            txtCodigo.Text = dato[0, 0];
            txtCod.Text = dato[0, 0];
            sucursal = dato[0, 0];
            txtNom.Text = dato[0, 1];
            txtNombre.Text = dato[0, 1];
            txtDescripcion.Text = dato[0, 2];
            txtContacto.Text = dato[0, 4];
            this.btoBuscar.Enabled = false;
            this.cboxEmpresas.Enabled = false;
            this.toolStripBtoDescartar.Enabled = true;
          

            if (tab == 0)
            {
                this.tbCRelacionSucAlm.TabPages.Add(tbpgAlmAsociados);
                tab++;
            }
            else if (tab > 0)
            {
               // this.tbCRelacionSucAlm.TabPages.Remove(tbpgAlmAsociados);
            }
            txtCodigo.Enabled = false;
            txtNombre.Enabled = false;

            cargar_listadoAlmacenes();  ///--------carga de DtAlmacenes Asociados a esta sucursal
            cargar_listadoRelacionSucAlm();
            if (dta.Rows.Count != 0)
            {
                this.lstvAlmacenes.Items.Clear();
                buscarAlmaneces();
            }
            else
            {
                sinAlmacenes();
            }
        }

        public void relacionSucAlmacen(DataTable dtAlmAsociados)
        {
            //codAlmAsociados = new string[1, dtAlmAsociados.Rows.Count];

                for (int a = 0; a < dtAlmAsociados.Rows.Count; a++)
                {
                codAlmAsociados[0, b] = dtAlmAsociados.Rows[a]["codigo"].ToString();
                lvrow = new ListViewItem(dtAlmAsociados.Rows[a]["codigo"].ToString());
                lvrow.SubItems.Add(dtAlmAsociados.Rows[a]["nombre"].ToString());
                lvrow.SubItems.Add(dtAlmAsociados.Rows[a]["descripcion"].ToString());
                this.lstvAlmacenes.Items.Add(lvrow);
                b++;
                }
                this.toolStripBtoGuardar.Enabled = true;
           // b = dtAlmAsociados.Rows.Count;
        }


        public void sinAlmacenes()
        {
            this.lblSinAlmacen.Visible = true;
            this.lblSinAlmacen.Text = cboNombreCorto.Text + " No tiene DtAlmacenes Asociados";
        }


        private void toolStripBtoDescartar_Click(object sender, EventArgs e)
        {
            funcionInicio();
            limpiarcajas();
        }

        private void btoDetalleA_Click(object sender, EventArgs e)
        {
            statusLsv = lstvAlmacenes.Items.Count;
            frmAlmacenes.nombreBd = cboNombreCorto.Text;
            activarChek = "si";
            ventAlmacenes = new frmTbAlmacenes();
            ventAlmacenes.AlmAsociados += new frmTbAlmacenes.relacion(relacionSucAlmacen);
            ventAlmacenes.ShowDialog();
           // buscarAlmaneces();
        }

        private void toolStripBtoGuardar_Click(object sender, EventArgs e)
        {           
            funcionGuardar();
        }

        private void btoEliminar_Click(object sender, EventArgs e)
        {
            if (count == 0)   //controlar que solo se contruya una vez
            {
                ConstruccionDt();
                count++;
            }            
            j = 0;
            if (this.lstvAlmacenes.CheckedItems.Count>0)
            {
                for (int i = pos; i < lstvAlmacenes.Items.Count; i++)
                {
                    if (lstvAlmacenes.Items[i].Checked == true)
                    {
                        almacen = lstvAlmacenes.Items[i].SubItems[0].Text.ToString();
                        actualizarArray();
                        lstvAlmacenes.Items.RemoveAt(i);
                        i--;
                    }
                }

                if (this.lstvAlmacenes.CheckedItems.Count > 0)
                {
                    //****************PENDIENTE POR TRADUCIR LOS MENSAJE BOX*****************************************
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    mensajeText = StringResources.frmRelacionSucAlm_mssElimRelacion;
                    mensajeCaption = StringResources.ValidacióndeEliminación;
                    DialogResult respuesta = MessageBox.Show(mensajeText,
                    mensajeCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (respuesta == DialogResult.Yes)
                    {
                        for (int i = 0; i < pos; i++)
                        {
                            if (lstvAlmacenes.Items[i].Checked == true)
                            {
                                codigoSuc = Int32.Parse(txtCodigo.Text);
                                codigoAlm = Int32.Parse(lstvAlmacenes.Items[i].SubItems[0].Text.ToString());
                                cargarDatos();
                                j++;
                                almacen = lstvAlmacenes.Items[i].SubItems[0].Text.ToString();                               
                                lstvAlmacenes.Items.RemoveAt(i);
                                pos--;
                                i--;
                            }
                        }
                        if (j != 0)
                        {
                            Suc.eliminarRelacionSucAlm(dt, cboNombreCorto.Text);

                            mensajeText = StringResources.DBEliminacionexitosa;
                            mensajeCaption = StringResources.frmRegistroUsuario_messValidacionCorrecta;
                            MessageBox.Show("Eliminacion Exitosa", "Validacion de eliminacion",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            actualizarArray();
                            this.btoEliminar.Visible = false;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
        private void actualizarArray()
        {
            if (lstvAlmacenes.Items.Count>0)
            {                
                b =0;
                for (int i = 0; i < lstvAlmacenes.Items.Count; i++)
                {
                    codAlmAsociados[0, b] = lstvAlmacenes.Items[i].SubItems[0].Text.ToString();
                    b++;
                }
                if (b!=dta.Rows.Count)
                {
                    for (int i=b;i< dta.Rows.Count;i++)
                    {
                        codAlmAsociados[0, i] = "";
                    }
                }
            }
            else
            {
                b = 0;
            }
            
        }
        private void frmRelacionSucAlm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7)
            {
                funcionGuardar();
            }
            if (e.KeyCode == Keys.F9)
            {
                funcionInicio();
                limpiarcajas();
            }
        }

        private void frmRelacionSucAlm_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(0, 0);
            //*************************
            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();
        }

        private void lstvAlmacenes_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (lstvAlmacenes.CheckedItems.Count>0)
            {
                this.btoEliminar.Visible = true;
            }
            else
            {
                this.btoEliminar.Visible = false;
            }
        }

        private void cboxEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblNohaySucursales.Visible = false;
            this.cboxCodEmp.SelectedIndex = this.cboxEmpresas.SelectedIndex;
            this.cboNombreCorto.SelectedIndex = this.cboxEmpresas.SelectedIndex;
            nombreBd = cboNombreCorto.Text;
            nomCompleto = cboxEmpresas.Text;
        }

        private void cargar_listadoAlmacenes()
        {
            dta = Suc.Listado_Almacenes(cboNombreCorto.Text);       //almacenes
        }
        private void cargar_listadoRelacionSucAlm()
        {
            dtr = Suc.Listado_RelacionSucAlm(cboNombreCorto.Text);       //almacenes
        }
        private void cargar_CboEmpresa()
        {
           // int a = 0;
            dte = Suc.listadoEmpresa();
            if (dte.Rows.Count>0)
            {
                for (int i = 0; i < dte.Rows.Count; i++)
                {
                    this.cboxEmpresas.Items.Add(dte.Rows[i]["empr_nombre"].ToString());
                    this.cboxCodEmp.Items.Add(dte.Rows[i]["empr_dni"].ToString());
                    this.cboNombreCorto.Items.Add(dte.Rows[i]["empr_nombCorto"].ToString());

                }
                cboxEmpresas.SelectedIndex = 0;
            }
            
            //emprBD = dt.Rows[i]["empr_nombCorto"].ToString();
        }
        private void limpiarcajas()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            //------------------------
            this.txtCod.Clear();
            this.txtNom.Clear();
            this.txtDescripcion.Clear();
            this.txtContacto.Clear();
           
            //tab3
            //     this.txtSucursales.Clear();
            //    this.txtAlmacenes.Clear();
            //this.btnAgregarMoneda.Clear();
        }

        private void ConstruccionDt()
        {
            dt = new DataTable();
            dt.Columns.Add("alm_succod", Type.GetType("System.Int32"));
            dt.Columns.Add("alm_almcod", Type.GetType("System.Int32"));
               
        }

        private void cargarDatos()
        {
            dt.Rows.Add();
            dt.Rows[j]["alm_succod"] = codigoSuc;
            dt.Rows[j]["alm_almcod"] = codigoAlm;
        }
        private void funcionGuardar()
        {
            {   //enviar relacion Almacen Sucursal en un datatable 
                ConstruccionDt();
                cargarRelacion();
                Suc.insertarRelacionSucAlm(dt, cboNombreCorto.Text);
                j = 0;
                mensajeText = StringResources.DBRegistroexitoso;//"Registro exitoso";
                mensajeCaption = StringResources.ValidacionExitosa;
                MessageBox.Show(mensajeText, mensajeCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                lstvAlmacenes.CheckBoxes = true;
                pos = lstvAlmacenes.Items.Count;
            }
        }

        private void cargarRelacion()       //antes de enviar dt a la bd, debo saber si la relacion //a guardar ya existe, y agregar solo las nuevas                                           
        {
            codigoSuc =Int32.Parse(txtCodigo.Text);
            for(int i=pos; i<lstvAlmacenes.Items.Count;i++)
            {
                codigoAlm = Int32.Parse(lstvAlmacenes.Items[i].SubItems[0].Text.ToString());                
                cargarDatos();
                j++;
            }  
        }
        private void funcionBuscarBd()
        {
            emp = cboxCodEmp.Text;
            for (int i = 0; i < dte.Rows.Count; i++)
            {
                if (emp == dte.Rows[i]["empr_dni"].ToString())
                {
                    emprBD = dte.Rows[i]["empr_Bd"].ToString().Trim();
                    existeBD = dte.Rows[i]["empr_Bd"].ToString().Trim();
                    return;
                }
            }
        }
        private void buscarAlmaneces()
        {
            codAlmAsociados = new string[1, dta.Rows.Count];
            int cont = 0;
            string almacen;
            lstvAlmacenes.Items.Clear();
            if (dtr.Rows.Count==0)      //no se han creado relaciones entre almacen y sucursal
            {
                lblSinAlmacen.Visible = true;
                lblSinAlmacen.Text = txtNombre.Text + " No posee almacenes asociados";
            }
            else
            {
                b = 0;
                              
                for (int i = 0; i < dtr.Rows.Count; i++)
                {
                    sucursal = txtCodigo.Text;
                    if (sucursal == dtr.Rows[i]["alm_succod"].ToString())
                    {
                        cont++;
                        almacen = dtr.Rows[i]["alm_almcod"].ToString();

                        for (int a = 0; a < dta.Rows.Count; a++)
                        {
                            if (almacen == dta.Rows[a]["alm_cod"].ToString())
                            {
                                codAlmAsociados[0, b] = dta.Rows[a]["alm_cod"].ToString();
                                lvrow = new ListViewItem(dta.Rows[a]["alm_cod"].ToString());
                                lvrow.SubItems.Add(dta.Rows[a]["alm_nombre"].ToString());
                                lvrow.SubItems.Add(dta.Rows[a]["alm_dir"].ToString());
                                lvrow.SubItems.Add(dta.Rows[a]["alm_contacto"].ToString());
                                this.lstvAlmacenes.Items.Add(lvrow);
                                b++;                                
                            }
                        }
                    }
                }
            }

            if (cont==0)
            {
                this.lblSinAlmacen.Visible = true;
                lblSinAlmacen.Text = txtNombre.Text + " No posee almacenes asociados";
                pos = 0;
            }
            else
            {
                lstvAlmacenes.CheckBoxes = true;
                this.lblSinAlmacen.Visible = false;
                pos = lstvAlmacenes.Items.Count;
            }
        }

        public void AplicarIdioma() //*******************OSCAR********************
        {
            //Titulo
            this.lblTituloPanel.Text = StringResources.frmRelacionSucAlm_lblTitulo;
            //label
            this.lblSeleccionarEmpresa.Text = StringResources.SeleccionarEmpresa;
            this.lblNombreCorto.Text = StringResources.lblNombeDosPuntos;
            this.lblCod.Text = StringResources.Codigo;
            this.lblNombre.Text = StringResources.Nombre;
            this.lblNom.Text = StringResources.Nombre;
            this.lblDescripcion.Text = StringResources.Nombre;
            this.lblContacto.Text = StringResources.Responsable;

            //toolpage
            this.tbPgInfoGeneral.Text = StringResources.Informaciongeneral;
            this.tbpgAlmAsociados.Text = StringResources.frmRelacionSucAlm_lblAlmacenesAsociados;

            //ListView
            this.ColCodigo.Text = StringResources.Codigo;
            this.colNomSucursal.Text = StringResources.Almacen;
            this.colDescripcion.Text = StringResources.Descripcion;

            //button
            this.btoBuscar.Text = StringResources.btnBuscar;
            this.btoEliminar.Text = StringResources.Eliminar;
            this.btoDetalleA.Text = StringResources.frmRelacionSucAlm_btoAsociarAlmacenes;
            this.btoSalir.Text = StringResources.btnSalir;

            //toolstrip
            this.toolStripBtoGuardar.Text = StringResources.btoGuardar;
            this.toolStripBtoDescartar.Text = StringResources.Descartar;
            this.Text= StringResources.SucusalesAlmacenes;
        }
    }
}
