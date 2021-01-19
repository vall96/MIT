using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using CultureResources;
using CapaLogicaNegocios;
using System.Windows.Threading;
using System.Windows.Forms.VisualStyles;


namespace CapaPresentacion
{
    public partial class frmPropiedadesSistema : Form
    {
        string abrir = "";

        clsConfiguracion Config = new clsConfiguracion();
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        string palabra,palabra2,palabra3;
        Boolean existe;
        public static string radio, estado = "", Id = "",Decimal;
        public string mensajeText = "", mensajeCaption = "", tipoPais = "";
        int pos = 0, i = 0, count = 0;
        string cod, cod2,decimal1;
        int Alpha;
        FrmNumeroDecimal numero;
        public frmPropiedadesSistema()
        {
            InitializeComponent();
            tipoPais = frmRegristroUsuario.tipoPais;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            AplicarIdioma();
            dt2 = Config.listaropciones();
            cargarcbo();

        }
        private void cargarcbo()
        {
            this.cboModulo.Items.Clear();
            dt = Config.listaModulo();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["mod_Descripcion"].ToString() == "Produccion")
                {
                    tipoPais = frmRegristroUsuario.tipoPais;
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    cboModulo.Items.Add(StringResources.Produccion);
                }
                else if (dt.Rows[i]["mod_Descripcion"].ToString() == "Administracion")
                {
                    tipoPais = frmRegristroUsuario.tipoPais;
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    cboModulo.Items.Add(StringResources.Administración);
                }
                else if (dt.Rows[i]["mod_Descripcion"].ToString() == "Contabilidad")
                {
                    tipoPais = frmRegristroUsuario.tipoPais;
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    cboModulo.Items.Add(StringResources.frmUsuarioPruebaEstilo_cboContabilidad);
                }
                else if (dt.Rows[i]["mod_Descripcion"].ToString() == "Opciones Generales")
                {
                    tipoPais = frmRegristroUsuario.tipoPais;
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
                    cboModulo.Items.Add(StringResources.OpcionesGenerales);
                }
                cbocodModulo.Items.Add(dt.Rows[i]["mod_Id"].ToString());

            }
            cboModulo.SelectedIndex = 0;
        }
        private void cboModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cbocodModulo.SelectedIndex = this.cboModulo.SelectedIndex;
            cargardg();
        }
        private void cargardg()
       {
            dgvPropiedades.Rows.Clear();
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                if (cbocodModulo.Text == dt2.Rows[i]["OpcionesGen_CodModulo"].ToString())
                {
                    cod = dt2.Rows[i]["OpcionesGen_Id"].ToString();
                    cod2 = dt2.Rows[i]["OpcionesGen_Valor"].ToString();
                    IdiomaNombre(cod);IdiomaValor(cod2);
                    dgvPropiedades.Rows.Add(dt2.Rows[i]["OpcionesGen_CodModulo"].ToString(),
                    dt2.Rows[i]["OpcionesGen_Id"].ToString(),palabra2,palabra3);
                    palabra3 = "";
                    dgvPropiedades.Rows[i].Cells[4].Value = "...";                    
                    if (palabra2 == "" && palabra3 == "" )
                    {
                        dgvPropiedades.Rows[i].Cells[2].Value = dt2.Rows[i]["OpcionesGen_Nombre"].ToString();
                        dgvPropiedades.Rows[i].Cells[3].Value = dt2.Rows[i]["OpcionesGen_Valor"].ToString();                        
                    }
                }
            }
            radio = dt2.Rows[0]["OpcionesGen_Valor"].ToString();
            Decimal= dt2.Rows[1]["OpcionesGen_Valor"].ToString();
        }

        private void AbrirConfiguracion()
        {
            radio = dgvPropiedades.Rows[0].Cells[3].Value.ToString();
            frmConfigurarDecimal decima = new frmConfigurarDecimal();
            decima.ShowDialog();
            if (frmConfigurarDecimal.Valor != "")
            {
                dgvPropiedades.Rows[0].Cells[3].Value = frmConfigurarDecimal.Valor.ToString();                
                Alpha = 1;
            }
        }
        private void AbrirDecimal()
        {
            Decimal = dgvPropiedades.Rows[1].Cells[3].Value.ToString().Split()[0];
            numero = new FrmNumeroDecimal();
            numero.ShowDialog();
            if (FrmNumeroDecimal.numero1 != "")
            {
                dgvPropiedades.Rows[1].Cells[3].Value = FrmNumeroDecimal.numero1;
                Alpha = 2;
            }
        }

        private void btoGuardar_Click(object sender, EventArgs e)
        {
            FuncionGuardar();
        }

        private void FuncionGuardar()
        {
            if (Alpha == 1)
            {
                string msj = "";
                if (frmConfigurarDecimal.Activo == "Punto")
                {
                    Config.c_id= dt2.Rows[0]["OpcionesGen_Id"].ToString();
                    Config.c_valor = frmConfigurarDecimal.ValorP;
                }
                else if (frmConfigurarDecimal.Activo == "Coma")
                {
                    Config.c_id = dt2.Rows[0]["OpcionesGen_Id"].ToString();
                    Config.c_valor = frmConfigurarDecimal.ValorC;
                }
                msj = Config.ActualizarDecimal();
                if (msj == "Actualizacion Exitosa")
                {
                    mensajeCaption = StringResources.ValidaciondeRegistro;
                    mensajeText = StringResources.DBActualizacionExitosa;
                    MessageBox.Show(mensajeText, mensajeCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (Alpha == 2)
            {
                string msj = "";
                if (FrmNumeroDecimal.numero1 != "")
                {
                    Config.c_id = dt2.Rows[1]["OpcionesGen_Id"].ToString();
                    Config.c_valor = FrmNumeroDecimal.numero1;
                }
                msj = Config.ActualizarDecimal();
                if (msj == "Actualizacion Exitosa")
                {
                    mensajeCaption = StringResources.ValidaciondeRegistro;
                    mensajeText = StringResources.DBActualizacionExitosa;
                    MessageBox.Show(mensajeText, mensajeCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

       

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FuncionBuscar();
            }
        }

        private void frmPropiedadesSistema_Load(object sender, EventArgs e)
        {
            this.Location = new System.Drawing.Point(0, 0);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FuncionBuscar();
        }

        private void dgvPropiedades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (cboModulo.SelectedIndex==3)
            {
                if (dgvPropiedades.Rows.Count == 1)
                {
                    return;
                }
                else if (dgvPropiedades.Rows.Count > 1)
                {
                    if (e.RowIndex == 0)
                    {
                        if (e.ColumnIndex == 4)
                        {
                            dgvPropiedades.Columns[e.ColumnIndex].ReadOnly = false;
                            abrir = "si";
                            AbrirConfiguracion();
                        }
                    }
                    if (e.RowIndex == 1)
                    {
                        if (e.ColumnIndex == 4)
                        {
                            dgvPropiedades.Columns[e.ColumnIndex].ReadOnly = false;
                            abrir = "si";
                            AbrirDecimal();
                        }
                    }
                }                
            }
        }

        private void btoSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Validar()
        {
            existe = palabra.ToLower().StartsWith(txtBuscar.Text.ToString().Trim().ToLower());
        }
        private void FuncionBuscar()
        {
            existe = false;
            for (int i = 0; i < (dgvPropiedades.Rows.Count - 1); i++)
            {
                palabra = dgvPropiedades.Rows[i].Cells[2].Value.ToString();
                Validar();
                if (existe == true)
                {
                    dgvPropiedades.Rows[i].Cells[2].Selected = true;
                    dgvPropiedades.CurrentCell = dgvPropiedades.Rows[i].Cells[2];
                    dgvPropiedades.FirstDisplayedCell = dgvPropiedades.CurrentCell;
                    pos = i;
                    return;
                }
            }
        }
        private void IdiomaNombre(string codigo)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            switch (codigo)
            {
                case "0":
                    palabra2 = StringResources.frmConfiguracionDecimal_Titulo;
                    break;
                case "1":
                    palabra2 = StringResources.NumeroDecimal;
                    break;
                case "2":
                    palabra2 = "";
                    break;
                case "3":
                    palabra2 = "";
                    break;
                case "4":
                    palabra2 = "";
                    break;
            }
        }
        private void IdiomaValor(string codigo)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(tipoPais);
            switch (codigo)
            {
                case "Punto (.)":
                    palabra3 = StringResources.Punto;
                    break;
                case "Coma (,)":
                    palabra3 = StringResources.Coma;
                    break;
                case "1":
                    palabra3 = StringResources._1Decimal;
                    break;
                case "2":
                    palabra3 = StringResources._2Decimales;
                    break;
                case "3":
                    palabra3 = StringResources._3Decimales;
                    break;
                case "4":
                    palabra3 = StringResources._4Decimales;
                    break;
                case "5":
                    palabra3 = StringResources._5Decimales;
                    break;
                case "6":
                    palabra3 = StringResources._6Decimales;
                    break;
                case "7":
                    palabra3 = StringResources._7Decimales;
                    break;
                case "8":
                    palabra3 = StringResources._8Decimales;
                    break;
                case "9":
                    palabra3 = StringResources._9Decimales;
                    break;
                case "10":
                    palabra3 = StringResources._10Decimales;
                    break;
            }
        }
        public void AplicarIdioma()
        {
            //Titulos
            this.lblTituloPanel.Text = StringResources.frmPropiedadesSistema_Titulo;
            this.Text = StringResources.frmPropiedadesSistema_Titulo;
            //Button
            this.btnBuscar.Text = StringResources.btnBuscar;
            this.btoGuardar.Text = StringResources.btoGuardar;
            this.btoSalir.Text = StringResources.btnSalir;
            //label
            lblBuscar.Text = StringResources.btnBuscar;
            lblModulo.Text = StringResources.Modulo;
            //datagridview
            this.CodigoModulo.HeaderText = StringResources.CodigoModulo;
            this.Codigo.HeaderText = StringResources.Codigo;
            this.Nombre.HeaderText = StringResources.Nombre;
            this.Valor.HeaderText = StringResources.Valor;
            //tab
            this.PropiedadesSistema.Text = StringResources.frmPropiedadesSistema_Titulo;

        }
    }
}
