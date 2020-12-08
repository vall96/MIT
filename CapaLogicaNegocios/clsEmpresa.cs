using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEnlaceD;
using System.Data;
using System.IO;

namespace CapaLogicaNegocios
{
    public class clsEmpresa
    {
        private clsManejador M = new clsManejador();
        public string codEmp, status, descrip;
        public string nombredb = "", codigo;
        // string scrip = "";
        public string m_emprNombCorto { get; set; }
        public string m_emprDni { get; set; }
        public string m_emprNomb { get; set; }
        public string m_emprDesc { get; set; }
        public string m_emprDir { get; set; }
        public string m_emprRif { get; set; }
        public string m_emprNit { get; set; }
        public string m_empContacto { get; set; }
        public string m_emprTelf1 { get; set; }
        public string m_emprTelf2 { get; set; }
        public int m_emprMoneda { get; set; }
        public string m_emprEmail { get; set; }
        public string m_emprWeb { get; set; }
        public int m_emprCodigo { get; set; }
        //------para completar proveedores---
        public string m_emprRefe { get; set; }
        public string m_emprPais { get; set; }
        public string m_empEstado { get; set; }
        public string m_emprMunicipio { get; set; }
        public string m_emprCiudad { get; set; }
        public string m_emprTipoP { get; set; }
        public string m_emprTipo { get; set; }
        public string m_emprFax { get; set; }
        public string m_emprDias { get; set; }
        public string m_emprLimite { get; set; }
        public string m_emprComen { get; set; }
        public string m_emprfax { get; set; }
        public string m_Cat { get; set; }
        //----Para Articulos---------
        public string m_garantia { get; set; }
        public string m_modelo { get; set; }
        public string m_CodUnidad { get; set; }
        public string m_medida { get; set; }
        public string m_CogSubCat { get; set; }
        public string m_Procedencia { get; set; }
        public string m_Serial { get; set; }
        public string m_Cantidad { get; set; }
        public string m_cod { get; set; }
        public string m_Descripcion { get; set; }
        public Decimal m_sueldo { get; set; }
        public string m_total { get; set; }
        public DateTime m_FechaCedulaProd { get; set; }
        public string m_CantidadCedulaProd { get; set; }
        public string m_DuracionCedulaProd { get; set; }
        public string m_DuracionHoraDiaCedulaProd { get; set; }
        public string m_UnidadCedulaProd { get; set; }
        public string m_ProductoCedulaProd { get; set; }
        public DateTime m_emprFechaCreacion { get; set; }
        //Para Orden Produccion
        public string m_descrip { get; set; }
        public string m_cedula { get; set; }
        public string m_producto { get; set; }
        public DateTime m_creacion { get; set; }
        public DateTime m_inicio { get; set; }
        public DateTime m_cierre { get; set; }
        public int m_prioridad { get; set; }
        public int m_status { get; set; }
        public decimal m_costo { get; set; }
        public decimal m_cantidad { get; set; }
        public string m_unidado { get; set; }
        public string m_unidadc { get; set; }
        public string m_ordcod { get; set; }
        //-----------------------------------------------
        public int m_IVA { get; set; }
        public int m_LOTE { get; set; }
        public DateTime inicio, fin;
        //-----------------------------------------------
        public DataTable listadoEmpresa()
        {
            M.CambiarBD("MITCore");
            return M.Listado("sp_listadoEmpresas", null);
        }
        public DataTable Listado_monedas()
        {
            M.CambiarBD("MITCore");
            return M.Listado("sp__ListadoMonedas", null);
        }
        public DataTable Listado_EmpMonedas()
        {
            M.CambiarBD("MITCore");
            return M.Listado("sp_ListaEmpMoneda", null);
        }
        public DataTable Listado_sucursules(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            return M.Listado("sp_listadoSucursales", null);
        }
        public DataTable Listado_Almacenes(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            return M.Listado("sp_listarAlmacenes", null);
        }
        public DataTable Listado_Proveedores(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            return M.Listado("sp_ListarProveedores", null);
        }
        public DataTable Listado_RelacionSucAlm(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            return M.Listado("sp_ListaRelacionSucAlm", null);
        }
        public DataTable Listado_RelacionSucMon(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            return M.Listado("sp_RelacionMonSuc", null);
        }
        public DataTable Listado_SucursalEmpresa()
        {
            return M.Listado("sp_listadoEmpSucursal", null);
        }
        public DataTable Listado_Alm_Suc_Emp()
        {
            return M.Listado("sp_listadoAlm_Suc_Emp", null);
        }
        public void insertarRelacionSucAlm(DataTable dt, string nombreBd)
        {
            M.CambiarBD(nombreBd);
            M.InsertarDt(dt, "sp_RegistrarRelacioSucAlm", "@dtRelacion");
        }
        public void eliminarRelacionSucAlm(DataTable dt, string nombreBd)
        {
            M.CambiarBD(nombreBd);
            M.InsertarDt(dt, "sp_EliminarSucAlm", "@dtRelacion");
        }
        public void eliminarRelacionSucMon(DataTable dt, string nombreBd)
        {
            M.CambiarBD(nombreBd);
            M.InsertarDt(dt, "sp_EliminarSucMon", "@dtMonedas");
        }
        public void registar_moneda(DataTable dt, string nombreBd)
        {
            M.CambiarBD(nombreBd);
            M.InsertarDt(dt, "sp_RegistarMonedas", "@dtMonedas");
        }
        public void registar_monedaSuc(DataTable dt, string nombreBd)   //registro de moneda por Sucursal
        {
            M.CambiarBD(nombreBd);
            M.InsertarDt(dt, "sp_RegistarMonedas", "@dtMonedas");
        }
        public string registar_empresa()
        {
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";

            try
            {
                //pasamos parametros de entrada
                //lst.Add(new clsParametros("@username", m_username));
                lst.Add(new clsParametros("@emprDesc", m_emprDesc));
                lst.Add(new clsParametros("@emprDirec", m_emprDir));
                lst.Add(new clsParametros("@emprRif", m_emprRif));
                lst.Add(new clsParametros("@emprNit", m_emprNit));
                lst.Add(new clsParametros("@emprTelf1", m_emprTelf1));
                lst.Add(new clsParametros("@emprTelf2", m_emprTelf2));
                lst.Add(new clsParametros("@emprEmail", m_emprEmail));
                lst.Add(new clsParametros("@emprWeb", m_emprWeb));
                lst.Add(new clsParametros("@emprFechaCreacion", m_emprFechaCreacion));
                lst.Add(new clsParametros("@emprNomb", m_emprNomb));
                // lst.Add(new clsParametros("@emprMoneda", m_emprMoneda));
                lst.Add(new clsParametros("@empContacto", m_empContacto));
                lst.Add(new clsParametros("@empNombCorto", m_emprNombCorto));
                //pasamos datos de salida 

                lst.Add(new clsParametros("@empMensaje", SqlDbType.VarChar, 100));
                lst.Add(new clsParametros("@codEmp", SqlDbType.Int, 1));
                M.CambiarBD("MITCore");
                M.EjecutarSP("sp_RegistroEmpresa", ref lst);
                mensaje = lst[12].m_valor.ToString();
                codEmp = lst[13].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public string registar_empresaSucursal(string nombreBD)
        {

            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";

            try
            {
                //pasamos parametros de entrada
                //lst.Add(new clsParametros("@username", m_username));
                lst.Add(new clsParametros("@sucDesc", m_emprDesc));
                lst.Add(new clsParametros("@sucDirec", m_emprDir));
                lst.Add(new clsParametros("@sucTelf1", m_emprTelf1));
                lst.Add(new clsParametros("@sucTelf2", m_emprTelf2));
                lst.Add(new clsParametros("@sucEmail", m_emprEmail));
                lst.Add(new clsParametros("@sucFechaCreacion", m_emprFechaCreacion));
                lst.Add(new clsParametros("@sucNomb", m_emprNomb));
                // lst.Add(new clsParametros("@sucMoneda", m_emprMoneda));
                lst.Add(new clsParametros("@sucContacto", m_empContacto));
                lst.Add(new clsParametros("@empresa", m_emprCodigo));
                // lst.Add(new clsParametros("@empNombCorto", m_emprNombCorto));
                //pasamos datos de salida 

                lst.Add(new clsParametros("@sucMensaje", SqlDbType.VarChar, 100));
                lst.Add(new clsParametros("@CodSuc", SqlDbType.Int, 1));
                M.CambiarBD(nombreBD);
                M.EjecutarSP("sp_RegistroSucursal", ref lst);

                mensaje = lst[9].m_valor.ToString();
                codigo = lst[10].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public string registar_SucursalAlmacen(string nombreBD)
        {
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            string codigo;
            try
            {
                //pasamos parametros de entrada
                //lst.Add(new clsParametros("@username", m_username));
                lst.Add(new clsParametros("@almDesc", m_emprDesc));//
                lst.Add(new clsParametros("@almDirec", m_emprDir));//
                lst.Add(new clsParametros("@almTelf1", m_emprTelf1));
                lst.Add(new clsParametros("@almTelf2", m_emprTelf2));
                lst.Add(new clsParametros("@almFechaCreacion", m_emprFechaCreacion));
                lst.Add(new clsParametros("@almNomb", m_emprNomb));//
                lst.Add(new clsParametros("@almContacto", m_empContacto));//
                lst.Add(new clsParametros("@empresa", m_emprCodigo));
                // lst.Add(new clsParametros("@sucursal", m_sucCodigo));
                //pasamos datos de salida 

                lst.Add(new clsParametros("@almMensaje", SqlDbType.VarChar, 100));
                lst.Add(new clsParametros("@codAlm", SqlDbType.Int, 1));
                M.CambiarBD(nombreBD);
                M.EjecutarSP("sp_RegistroAlmacen", ref lst);

                mensaje = lst[8].m_valor.ToString();
                codigo = lst[9].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public string EliminarEmpresa()
        {
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            try
            {
                lst.Add(new clsParametros("@emp_Cod", m_emprDni));

                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 100));
                M.EjecutarSP("sp_eliminarEmpresaLogico", ref lst);
                mensaje = lst[1].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;

        }
        public void CrearBD(string nombreBD)
        {
            M.crearBD(nombreBD);
        }
        //PRODUCCION
        public string RegistarProveedor(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";

            try
            {
                //pasamos parametros de entrada
                lst.Add(new clsParametros("@nombre", m_emprNomb));
                lst.Add(new clsParametros("@tipo", m_emprTipo));
                lst.Add(new clsParametros("@responsable", m_empContacto));
                lst.Add(new clsParametros("@telefono1", m_emprTelf1));
                lst.Add(new clsParametros("@telefono2", m_emprTelf2));
                lst.Add(new clsParametros("@direccion", m_emprDir));
                lst.Add(new clsParametros("@pais", m_emprPais));
                lst.Add(new clsParametros("@estado", m_empEstado));
                lst.Add(new clsParametros("@ciudad", m_emprCiudad));
                lst.Add(new clsParametros("@municipio", m_emprMunicipio));
                lst.Add(new clsParametros("@tipoPerso", m_emprTipoP));
                lst.Add(new clsParametros("@rif", m_emprRif));
                lst.Add(new clsParametros("@fax", m_emprFax));
                lst.Add(new clsParametros("@fecha", m_emprFechaCreacion));
                lst.Add(new clsParametros("@dias", m_emprDias));
                lst.Add(new clsParametros("@limite", m_emprLimite));
                lst.Add(new clsParametros("@comentario", m_emprComen));
                lst.Add(new clsParametros("@email", m_emprEmail));
                lst.Add(new clsParametros("@referencia", m_emprRefe));
                //pasamos datos de salida 
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 20));
                M.EjecutarSP("sp_RegistrarProveedor", ref lst);
                mensaje = lst[19].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public string RegistarCategoria(string nombreBd) //modificado Valerie 
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";

            try
            {
                //pasamos parametros de entrada

                lst.Add(new clsParametros("@codigo", m_codCategorias));
                lst.Add(new clsParametros("@descripcion", m_DescripCategorias));

                //pasamos datos de salida 
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 20));
                M.EjecutarSP("sp_RegistrarCategoria", ref lst);

                mensaje = lst[2].m_valor.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public DataTable ListadoCategoria(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            return M.Listado("sp_listarCategoria", null);
        }
        //Unidades 
        public DataTable ListadoUnidades(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            return M.Listado("sp_listarUnidades", null);
        }
        //ARTICULOS
        public DataTable ListadoCodigos(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            return M.Listado("SP_ListaCodArt", null);
        }
        public string RegistrarArtuculos(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            //  string status;
            try
            {
                //pasamos parametros de entrada
                //     lst.Add(new clsParametros("@status", m_status));
                lst.Add(new clsParametros("@nombre", m_emprNomb));
                lst.Add(new clsParametros("@garantia", m_garantia));
                lst.Add(new clsParametros("@modelo", m_modelo));
                lst.Add(new clsParametros("@unidad", m_CodUnidad));
                lst.Add(new clsParametros("@unidadFiltro", m_codUnidades));
                lst.Add(new clsParametros("@categoria", m_Cat));
                lst.Add(new clsParametros("@subcategoria", m_CogSubCat));
                lst.Add(new clsParametros("@serial", m_Serial));
                lst.Add(new clsParametros("@codigo", m_cod));
                lst.Add(new clsParametros("@id", m_codCedulaProd));
                lst.Add(new clsParametros("@IVA", m_IVA));
                lst.Add(new clsParametros("@LOTE", m_LOTE));

                //pasamos datos de salida 
                //codCedulaProd
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 20));
                M.EjecutarSP("sp_RegistarArticulos", ref lst);

                mensaje = lst[12].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public DataTable ListadoArticulos(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            return M.Listado("sp_ListarArticulos", null);
        }
        //procedencia

        //sp_ListarProcedencia
        public DataTable ListadoProcedencia(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            return M.Listado("sp_ListarProcedencia", null);
        }
        //------------------ para Maquinas --------------- VALERIE ---------
        public string m_codMaquina { get; set; }
        public string m_DescripMaquina { get; set; }
        //------------------- maquinas -------------------
        public DataTable ListadoMaquinas(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            return M.Listado("sp_listarMaquina", null);
        }
        public string RegistarMaquina(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            //  string status;
            try
            {
                //pasamos parametros de entrada
                lst.Add(new clsParametros("@codigo", m_codMaquina));
                lst.Add(new clsParametros("@descripcion", m_DescripMaquina));

                //pasamos datos de salida 
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 20));
                M.EjecutarSP("sp_RegistrarMaquinas", ref lst);

                mensaje = lst[2].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public string ActualizarMaquina(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            //  string status;
            try
            {
                //pasamos parametros de entrada
                lst.Add(new clsParametros("@codigo", m_codMaquina));
                lst.Add(new clsParametros("@descripcion", m_DescripMaquina));

                //pasamos datos de salida 
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 20));
                M.EjecutarSP("sp_ActualizarMaquina", ref lst);

                mensaje = lst[2].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public string EliminarMaquina(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            //  string status;
            try
            {
                //pasamos parametros de entrada
                lst.Add(new clsParametros("@codigo", m_codMaquina));
                //pasamos datos de salida 
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 20));
                M.EjecutarSP("sp_EliminarMaquina", ref lst);

                mensaje = lst[1].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        //------------------------- Atributos ---------------------------   VALERIE
        public string m_codAtributos { get; set; }
        public string m_DescripAtributos { get; set; }
        //ATRIBUTOS----------------------------------------------------------------
        public DataTable ListadoAtributos(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            return M.Listado("sp_listarAtributos", null);
        }
        public string RegistarAtributo(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            //  string status;
            try
            {
                //pasamos parametros de entrada
                lst.Add(new clsParametros("@codigo", m_codAtributos));
                lst.Add(new clsParametros("@descripcion", m_DescripAtributos));

                //pasamos datos de salida 
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 20));
                M.EjecutarSP("sp_RegistrarAtributos", ref lst);

                mensaje = lst[2].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public string ActualizarAtributo(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            //  string status;
            try
            {
                //pasamos parametros de entrada
                lst.Add(new clsParametros("@codigo", m_codAtributos));
                lst.Add(new clsParametros("@descripcion", m_DescripAtributos));

                //pasamos datos de salida 
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 20));
                M.EjecutarSP("sp_ActualizarAtributo", ref lst);

                mensaje = lst[2].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public string EliminarAtributo(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            //  string status;
            try
            {
                //pasamos parametros de entrada
                lst.Add(new clsParametros("@codigo", m_codAtributos));
                //pasamos datos de salida 
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 20));
                M.EjecutarSP("sp_EliminarAtributo", ref lst);

                mensaje = lst[1].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        //--------------------------- status Maquina --------------------
        public string m_codStatMaquinas { get; set; }
        public string m_DescripStatMaquina { get; set; }
        //----------------------------------------------------------------
        public DataTable ListadoStatusMaquina(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            return M.Listado("sp_listarEstatusMaquina", null);
        }
        public string RegistarEstatusMaquina(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            //  string status;
            try
            {
                //pasamos parametros de entrada
                lst.Add(new clsParametros("@codigo", m_codStatMaquinas));
                lst.Add(new clsParametros("@descripcion", m_DescripStatMaquina));

                //pasamos datos de salida 
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 20));
                M.EjecutarSP("sp_RegistrarEstatusMaquina", ref lst);

                mensaje = lst[2].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public string ActualizarEstatusMaquina(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            //  string status;
            try
            {
                //pasamos parametros de entrada
                lst.Add(new clsParametros("@codigo", m_codStatMaquinas));
                lst.Add(new clsParametros("@descripcion", m_DescripStatMaquina));

                //pasamos datos de salida 
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 20));
                M.EjecutarSP("sp_ActualizarEstatusDeMaquina", ref lst);

                mensaje = lst[2].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public string EliminarEstatusMaquina(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            //  string status;
            try
            {
                //pasamos parametros de entrada
                lst.Add(new clsParametros("@codigo", m_codStatMaquinas));
                //pasamos datos de salida 
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 20));
                M.EjecutarSP("sp_EliminarEstatusMaquina", ref lst);

                mensaje = lst[1].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        //CATEGORIAS VALERIE 
        public string m_codCategorias { get; set; }
        public string m_DescripCategorias { get; set; }
        //----------------------------------------------------------
        public string ActualizarCategorias(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            //  string status;
            try
            {
                //pasamos parametros de entrada
                lst.Add(new clsParametros("@codigo", m_codCategorias));
                lst.Add(new clsParametros("@descripcion", m_DescripCategorias));

                //pasamos datos de salida 
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 20));
                M.EjecutarSP("sp_ActualizarCategoria", ref lst);

                mensaje = lst[2].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public string EliminarCategoria(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            //  string status;
            try
            {
                //pasamos parametros de entrada
                lst.Add(new clsParametros("@codigo", m_codCategorias));
                //pasamos datos de salida 
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 20));
                M.EjecutarSP("sp_EliminarCategoria", ref lst);

                mensaje = lst[1].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        // FALLAS DE MAQUINAS 
        public DataTable ListadoFALLASMaquina(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            return M.Listado("Sp_CargarlstvFallasMaquinas", null);
        }
        //oscar 
        public DataTable CargarLstv(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            return M.Listado("Sp_ListarFallasMaquinas", null);
        }
        public string EliminarFalla(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            try
            {
                lst.Add(new clsParametros("@Id", m_cod));
                lst.Add(new clsParametros("@Mensaje", SqlDbType.VarChar, 20));
                M.EjecutarSP("Sp_EliminarFallasMaquinas", ref lst);
                mensaje = lst[1].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public string RegistarFalla(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            try
            {
                lst.Add(new clsParametros("@Id", m_cod));
                lst.Add(new clsParametros("@Descripcion", m_Descripcion));
                lst.Add(new clsParametros("@Mensaje", SqlDbType.VarChar, 50));
                M.EjecutarSP("Sp_AgregarFallasMaquinas", ref lst);
                mensaje = lst[2].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public string ActualizarFalla(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            try
            {
                lst.Add(new clsParametros("@Id", m_cod));
                lst.Add(new clsParametros("@Descripcion", m_Descripcion));
                lst.Add(new clsParametros("@Mensaje", SqlDbType.VarChar, 50));
                M.EjecutarSP("Sp_ActualizarFallasMaquinas", ref lst);
                mensaje = lst[2].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        //Perfiles de Empleados
        public DataTable listarlstvPerfilesEmpleados(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            return M.Listado("Sp_ListarPerfilesEmpleados", null);
        }
        public string EliminarPerfil(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            try
            {
                lst.Add(new clsParametros("@Id", m_cod));
                lst.Add(new clsParametros("@Mensaje", SqlDbType.VarChar, 20));
                M.EjecutarSP("Sp_EliminarPerfilesEmpleados", ref lst);
                mensaje = lst[1].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public string RegistarPerfil(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            try
            {
                lst.Add(new clsParametros("@Id", m_cod));
                lst.Add(new clsParametros("@Descripcion", m_Descripcion));
                lst.Add(new clsParametros("@Sueldo", m_sueldo));
                lst.Add(new clsParametros("@Mensaje", SqlDbType.VarChar, 50));
                M.EjecutarSP("Sp_AgregarPerfilesEmpleados", ref lst);
                mensaje = lst[3].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public string ActualizarPerfil(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            try
            {
                lst.Add(new clsParametros("@Id", m_cod));
                lst.Add(new clsParametros("@Descripcion", m_Descripcion));
                lst.Add(new clsParametros("@Sueldo", m_sueldo));
                lst.Add(new clsParametros("@Mensaje", SqlDbType.VarChar, 50));
                M.EjecutarSP("Sp_ActualizarPerfilesEmpleados", ref lst);
                mensaje = lst[3].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public string m_DescripSubCat { get; set; }
        //----------------------------------------------------------
        public string ActualizarSubCategorias(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            //  string status;
            try
            {
                //pasamos parametros de entrada
                lst.Add(new clsParametros("@codigo", m_CogSubCat));
                lst.Add(new clsParametros("@descripcion", m_DescripSubCat));
                lst.Add(new clsParametros("@categoria", m_Cat));

                //pasamos datos de salida 
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 20));
                M.EjecutarSP("sp_ActualizaSubCategoria", ref lst);

                mensaje = lst[3].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public string EliminarSubCategorias(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            //  string status;
            try
            {
                //pasamos parametros de entrada
                lst.Add(new clsParametros("@codigo", m_CogSubCat));
                //pasamos datos de salida 
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 20));
                M.EjecutarSP("sp_EliminarSubCategoria", ref lst);

                mensaje = lst[1].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        //------------------------
        public string RegistarSubCatg(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            //  string status;
            try
            {
                //pasamos parametros de entrada
                lst.Add(new clsParametros("@categoria", m_Cat));
                lst.Add(new clsParametros("@descripcion", m_DescripSubCat));
                lst.Add(new clsParametros("@codigo", m_CogSubCat));

                //pasamos datos de salida 
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 20));
                // lst.Add(new clsParametros("@codigo", SqlDbType.Int, 1));
                M.EjecutarSP("sp_RegistarSubCatg", ref lst);

                mensaje = lst[3].m_valor.ToString();
                //  codigo = lst[3].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public DataTable ListadoSubCategoria(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            return M.Listado("sp_listarSubCategoria", null);
        }
        //Unidades Valerie 16102019
        public string m_codUnidades { get; set; }
        public string m_DescripUnidades { get; set; }
        public string ActualizarUnidades(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            //  string status;
            try
            {
                //pasamos parametros de entrada
                lst.Add(new clsParametros("@codigo", m_codUnidades));
                lst.Add(new clsParametros("@descripcion", m_DescripUnidades));

                //pasamos datos de salida 
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 20));
                M.EjecutarSP("sp_ActualizarUnidad", ref lst);

                mensaje = lst[2].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public string RegistarUnidades(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";

            try
            {
                //pasamos parametros de entrada
                lst.Add(new clsParametros("@codigo", m_codUnidades));
                lst.Add(new clsParametros("@descripcion", m_DescripUnidades));

                //pasamos datos de salida 
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 20));
                M.EjecutarSP("sp_RegistrarUnidades", ref lst);

                mensaje = lst[2].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public string EliminarUnidades(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            //  string status;
            try
            {
                //pasamos parametros de entrada
                lst.Add(new clsParametros("@codigo", m_codUnidades));
                //pasamos datos de salida 
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 20));
                M.EjecutarSP("sp_EliminarUnidades", ref lst);

                mensaje = lst[1].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public string m_codCedulaProd { get; set; }
        public string m_DescripCedulaProd { get; set; }
        //-----------------------------FIN Valerie 16102019 ---------------------------------------------

        //----------------Oscar------
        //GastoFabrica
        public DataTable listarlstvGastos(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            return M.Listado("Sp_ListarGastoFabrica", null);
        }
        public string EliminarGastos(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            try
            {
                lst.Add(new clsParametros("@Id", m_cod));
                lst.Add(new clsParametros("@Mensaje", SqlDbType.VarChar, 50));
                M.EjecutarSP("Sp_EliminarGastoFabrica", ref lst);
                mensaje = lst[1].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public string RegistarGastos(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            try
            {
                lst.Add(new clsParametros("@Id", m_cod));
                lst.Add(new clsParametros("@Descripcion", m_Descripcion));
                lst.Add(new clsParametros("@Mensaje", SqlDbType.VarChar, 50));
                M.EjecutarSP("Sp_AgregarGastoFabrica", ref lst);
                mensaje = lst[2].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public string ActualizarGastos(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            try
            {
                lst.Add(new clsParametros("@Id", m_cod));
                lst.Add(new clsParametros("@Descripcion", m_Descripcion));
                lst.Add(new clsParametros("@Mensaje", SqlDbType.VarChar, 50));
                M.EjecutarSP("Sp_ActualizarGastoFabrica", ref lst);
                mensaje = lst[2].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        //poscarprocedencia
        public DataTable listarlstvProcedencia(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            return M.Listado("Sp_ListarProcedencia", null);
        }
        public string EliminarProcedencia(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            try
            {
                lst.Add(new clsParametros("@Id", m_cod));
                lst.Add(new clsParametros("@Mensaje", SqlDbType.VarChar, 50));
                M.EjecutarSP("Sp_EliminarProcedencia", ref lst);
                mensaje = lst[1].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public string RegistarProcedencia(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            try
            {
                lst.Add(new clsParametros("@Id", m_cod));
                lst.Add(new clsParametros("@Descripcion", m_Descripcion));
                lst.Add(new clsParametros("@Mensaje", SqlDbType.VarChar, 50));
                M.EjecutarSP("Sp_AgregarProcedencia", ref lst);
                mensaje = lst[2].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public string ActualizarProcedencia(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            try
            {
                lst.Add(new clsParametros("@Id", m_cod));
                lst.Add(new clsParametros("@Descripcion", m_Descripcion));
                lst.Add(new clsParametros("@Mensaje", SqlDbType.VarChar, 50));
                M.EjecutarSP("Sp_ActualizarProcedencia", ref lst);
                mensaje = lst[2].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        //tareas
        public DataTable listarTareas(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            return M.Listado("sp_ListarTareas", null);
        }
        public string RegistarTarea(string nombreBd) //modificado Valerie 
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";

            try
            {
                //pasamos parametros de entrada

                lst.Add(new clsParametros("@codigo", codigo));
                lst.Add(new clsParametros("@descripcion", m_DescripCategorias));

                //pasamos datos de salida 
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 20));
                M.EjecutarSP("sp_RegistrarTarea", ref lst);

                mensaje = lst[2].m_valor.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public string EliminarTarea(string nombreBd) //modificado Valerie 
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";

            try
            {
                //pasamos parametros de entrada

                lst.Add(new clsParametros("@codigo", codigo));
                //pasamos datos de salida 
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 20));
                M.EjecutarSP("Sp_EliminarTarea", ref lst);

                mensaje = lst[1].m_valor.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public void registar_TareasMaq(DataTable dt, string nombreBd)
        {
            M.CambiarBD(nombreBd);
            M.InsertarDt(dt, "sp_RegitrarTareasMaquinas", "@dtRelacion");
        }
        public void registar_TareasAtrib(DataTable dt, string nombreBd)
        {
            M.CambiarBD(nombreBd);
            M.InsertarDt(dt, "sp_RegitrarTareasAtributos", "@dtRelacion");
        }
        public void registar_TareasArt(DataTable dt, string nombreBd)
        {
            M.CambiarBD(nombreBd);
            M.InsertarDt(dt, "sp_RegitrarTareasArt", "@dtRelacion");
        }
        //****************listar relaciones de atreas y atributos*******************************
        //TareaMaq
        public DataTable ListarMaqTarea(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            // string mensaje = "";

            try
            {
                lst.Add(new clsParametros("@codigo", codigo));
                return M.Listado("Sp_ListarTareaMaquina", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //TareaAtrib
        public DataTable ListarMaqAtrib(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            //string mensaje = "";

            try
            {
                lst.Add(new clsParametros("@codigo", codigo));
                return M.Listado("Sp_ListarTareaAtrib", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //public DataTable ListarMaqArt(string nombreBd)
        //{
        //    M.CambiarBD(nombreBd);
        //    List<clsParametros> lst = new List<clsParametros>();
        //    // string mensaje = "";

        //    try
        //    {
        //        lst.Add(new clsParametros("@codigo", codigo));
        //        return M.Listado("Sp_ListarTareaarticulo", lst);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public void eliminarMaqTarea(DataTable dt, string nombreBd)
        {
            M.CambiarBD(nombreBd);
            M.InsertarDt(dt, "sp_EliminarTareaMaq", "@dtRelacion");
        }
        public void eliminarAtriTarea(DataTable dt, string nombreBd)
        {
            M.CambiarBD(nombreBd);
            M.InsertarDt(dt, "Sp_EliminarTareaAtrib", "@dtRelacion");
        }
        //public void eliminarArtTarea(DataTable dt, string nombreBd)
        //{
        //    M.CambiarBD(nombreBd);
        //    M.InsertarDt(dt, "Sp_EliminarTareaArt", "@dtRelacion");
        //}
        public string ActualizarTarea(string nombreBd) //modificado Valerie 
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";

            try
            {
                //pasamos parametros de entrada

                lst.Add(new clsParametros("@codigo", codigo));
                lst.Add(new clsParametros("@descripcion", m_DescripCategorias));
                //pasamos datos de salida 
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 20));
                M.EjecutarSP("Sp_ActualizarTarea", ref lst);

                mensaje = lst[2].m_valor.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public string BuscarTarea(string nombreBd) //modificado Valerie 
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";

            try
            {
                //pasamos parametros de entrada

                lst.Add(new clsParametros("@codigo", codigo));
                //pasamos datos de salida 
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 20));
                lst.Add(new clsParametros("@descripcion", SqlDbType.VarChar, 200));
                M.EjecutarSP("Sp_BuscarTarea", ref lst);

                mensaje = lst[1].m_valor.ToString();
                descrip = lst[2].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        //valerie
        public string RegistarCedulaProducto(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            //  string status;
            try
            {
                //pasamos parametros de entrada
                lst.Add(new clsParametros("@codigo", m_codCedulaProd));
                lst.Add(new clsParametros("@descripcion", m_DescripCedulaProd));
                lst.Add(new clsParametros("@fecha", m_FechaCedulaProd));
                lst.Add(new clsParametros("@unidad", m_UnidadCedulaProd));
                lst.Add(new clsParametros("@Producto", m_ProductoCedulaProd));
                lst.Add(new clsParametros("@Duracion", m_DuracionCedulaProd));
                lst.Add(new clsParametros("@DuracionHoraDia", m_DuracionHoraDiaCedulaProd));
                lst.Add(new clsParametros("@cantidad", m_CantidadCedulaProd));
                lst.Add(new clsParametros("@unidadEst", m_DescripUnidades));
                //pasamos datos de salida 
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 20));
                M.EjecutarSP("sp_RegistrarCedulaProducto", ref lst);

                mensaje = lst[9].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public string ActualizarCedulaProducto(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            //  string status;
            try
            {
                //pasamos parametros de entrada
                lst.Add(new clsParametros("@codigo", m_codCedulaProd));
                lst.Add(new clsParametros("@descripcion", m_DescripCedulaProd));
                lst.Add(new clsParametros("@cantidad", m_CantidadCedulaProd));
                lst.Add(new clsParametros("@Duracion", m_DuracionCedulaProd));
                lst.Add(new clsParametros("@unidad", m_UnidadCedulaProd));
                lst.Add(new clsParametros("@DuracionHoraDia", m_DuracionHoraDiaCedulaProd));
                lst.Add(new clsParametros("@unidadEst", m_DescripUnidades));

                //pasamos datos de salida 
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 20));
                M.EjecutarSP("sp_ActualizarCedulaProducto", ref lst);

                mensaje = lst[7].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public string EliminarCedulaProducto(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            //  string status;
            try
            {
                //pasamos parametros de entrada
                lst.Add(new clsParametros("@codigo", m_codCedulaProd));
                //pasamos datos de salida 
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 20));
                M.EjecutarSP("sp_EliminarCedulaProducto", ref lst);

                mensaje = lst[1].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public DataTable ListadoCedulaProducto(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            return M.Listado("sp_listarCedulaProducto", null);
        }
        public DataTable ListadoArticulosCedulaProducto(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            return M.Listado("sp_ListarProductoCedula", null);
        }
        public void registar_CedulaTarea(DataTable dt, string nombreBd)
        {
            M.CambiarBD(nombreBd);
            M.InsertarDt(dt, "sp_RegistrarTareaCedula", "@dtRelacion");
        }
        public void eliminarTareaCedul(DataTable dt, string nombreBd)
        {
            M.CambiarBD(nombreBd);
            M.InsertarDt(dt, "sp_EliminarCedulaTarea", "@dtRelacion");
        }
        public DataTable ListarCedulaTarea(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();

            try
            {
                lst.Add(new clsParametros("@codigo", codigo));
                return M.Listado("Sp_ListarCedulaTarea", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //-------------------------------------------------------------VALERIE TIEMPO MAQUINA ------------------------------------
        public DataTable ListarTiempoMaquinaTarea(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            return M.Listado("sp_ListarUnidaddDeTiempo", null);

        }
        public void RegistrarTiempoMaquinaTarea(DataTable dt, string nombreBd)
        {
            M.CambiarBD(nombreBd);
            M.InsertarDt(dt, "sp_RegistrarTarTiempoMaquina", "@dtRelacion");
        }
        public DataTable ListarMaqTiempo(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            //string mensaje = "";

            try
            {
                lst.Add(new clsParametros("@codigo", codigo));
                return M.Listado("Sp_ListarTareaMaquinaTime", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ActualizarTiempoMaquina(DataTable dt, string nombreBd)
        {

            M.CambiarBD(nombreBd);
            M.InsertarDt(dt, "Sp_ActualizarTareaTM", "@dtRelacion");
        }
        //
        public string ActualizarProveedor(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";

            try
            {
                //pasamos parametros de entrada
                lst.Add(new clsParametros("@Id", m_cod));
                lst.Add(new clsParametros("@nombre", m_emprNomb));
                lst.Add(new clsParametros("@tipo", m_emprTipo));
                lst.Add(new clsParametros("@responsable", m_empContacto));
                lst.Add(new clsParametros("@telefono1", m_emprTelf1));
                lst.Add(new clsParametros("@telefono2", m_emprTelf2));
                lst.Add(new clsParametros("@direccion", m_emprDir));
                lst.Add(new clsParametros("@pais", m_emprPais));
                lst.Add(new clsParametros("@estado", m_empEstado));
                lst.Add(new clsParametros("@ciudad", m_emprCiudad));
                lst.Add(new clsParametros("@municipio", m_emprMunicipio));
                lst.Add(new clsParametros("@tipoPerso", m_emprTipoP));
                lst.Add(new clsParametros("@rif", m_emprRif));
                lst.Add(new clsParametros("@fax", m_emprFax));
                lst.Add(new clsParametros("@dias", m_emprDias));
                lst.Add(new clsParametros("@limite", m_emprLimite));
                lst.Add(new clsParametros("@comentario", m_emprComen));
                lst.Add(new clsParametros("@email", m_emprEmail));
                lst.Add(new clsParametros("@referencia", m_emprRefe));
                //pasamos datos de salida 
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 50));
                M.EjecutarSP("sp_ActualizarProveedor", ref lst);
                mensaje = lst[19].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public string EliminarProveedor(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            try
            {
                lst.Add(new clsParametros("@Id", m_cod));

                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 100));
                M.EjecutarSP("sp_EliminarProveedor", ref lst);
                mensaje = lst[1].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;

        }
        //-------------------2020 valerie
        public DataTable ListarCedulaAtrib(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            try
            {
                lst.Add(new clsParametros("@codigo", codigo));
                return M.Listado("SP_ListarCedulaAtrib", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ListarCedulaPerfilEmp(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();

            try
            {
                lst.Add(new clsParametros("@codigo", codigo));
                return M.Listado("SP_ListarCedulaPerfEmpl", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ListarCedulaGastosFab(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();

            try
            {
                lst.Add(new clsParametros("@codigo", codigo));
                return M.Listado("SP_ListarCedulaGastfab", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void registar_CedulaPerfEmpl(DataTable dt, string nombreBd)
        {
            M.CambiarBD(nombreBd);
            M.InsertarDt(dt, "SP_RegistrarCedulaPerfEmp", "@dtRelacion");
        }
        public void registar_CedulaGastFab(DataTable dt, string nombreBd)
        {
            M.CambiarBD(nombreBd);
            M.InsertarDt(dt, "SP_RegistrarCedulaGastFab", "@dtRelacion");
        }
        public void registar_CedulaAtrib(DataTable dt, string nombreBd)
        {
            M.CambiarBD(nombreBd);
            M.InsertarDt(dt, "SP_RegistrarCedulaAtrib", "@dtRelacion");
        }
        public void eliminarCedulaPerfEmp(DataTable dt, string nombreBd)
        {
            M.CambiarBD(nombreBd);
            M.InsertarDt(dt, "SP_EliminarCedulaPerfEmp", "@dtRelacion");
        }
        public void eliminarCedulaGastFab(DataTable dt, string nombreBd)
        {
            M.CambiarBD(nombreBd);
            M.InsertarDt(dt, "SP_EliminarCedulaGastFab", "@dtRelacion");
        }
        public void eliminarCedulaAtrib(DataTable dt, string nombreBd)
        {
            M.CambiarBD(nombreBd);
            M.InsertarDt(dt, "SP_EliminarCedulaAtrib", "@dtRelacion");
        }
        public DataTable ListarCedulaProArt(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();

            try
            {
                lst.Add(new clsParametros("@codigo", codigo));
                return M.Listado("Sp_ListarCedulaProArticulo", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void RegistrarCedulaProArticulo(DataTable dt, string nombreBd)
        {
            M.CambiarBD(nombreBd);
            M.InsertarDt(dt, "sp_RegistrarCedulaArticulo", "@dtRelacion");
        }
        public DataTable ListarUnidadesDeLongitud(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            return M.Listado("sp_ListarUnidadLongitud", null);
        }
        public void EliminarCedulaArt(DataTable dt, string nombreBd)
        {
            M.CambiarBD(nombreBd);
            M.InsertarDt(dt, "SP_EliminarCedulaArticulo", "@dtRelacion");
        }
        public DataTable ListarUnidadesEstandarMVL(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            return M.Listado("sp_ListarUnidadesEstarMVL", null);
        }
        public DataTable ListarUnidadesDeMasa(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            return M.Listado("sp_ListarUnidadesDeMasa", null);
        }
        public DataTable ListarUnidadesDeVolumen(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            return M.Listado("sp_ListarUnidadesDeVolumen", null);
        }
        public DataTable ListarUnidadesDeTiempo(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            return M.Listado("sp_ListarUnidaddDeTiempo", null);
        }
        public DataTable ListarFactorDeConversionSeg(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            return M.Listado("SP_ListarConversionSegundos", null);
        }
        public DataTable ListarUnidadesDescripcionMVL(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            return M.Listado("sp_ListarUnidadesDescripMVL", null);
        }
        public void ActualizarCedArtic(DataTable dt, string nombreBd)
        {
            M.CambiarBD(nombreBd); 
            M.InsertarDt(dt, "Sp_ActualizarCedulaArticulo", "@dtRelacion");
        }
        //SEPTIEMBRE
        public DataTable Listado_TipoMovimientoInventario(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            return M.Listado("Sp_ListarInvTipoMov", null);
        }
        public DataTable Listado_ProcesosInventario(string nombreBd)
        {
           
            M.CambiarBD(nombreBd);
            return M.Listado("Sp_ListarInvtProcesos", null);
        }
        //Orden de produccion oscar
        public DataTable Listar_OrdenProduccion(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            return M.Listado("Sp_ListarOrdenProduccion", null);
        }
        public DataTable Listado_StatusOP(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            return M.Listado("Sp_ListarStatusOP", null);
        }
        public DataTable Listar_Prioridades(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            return M.Listado("Sp_ListarPrioridades", null);
        }
        public string RegistrarOrden(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            string codigo;
            try
            {
                //Pasamos los parametros de entrada
                lst.Add(new clsParametros("@descripcion", m_descrip));
                lst.Add(new clsParametros("@cedula", m_cedula));
                lst.Add(new clsParametros("@producto", m_producto));
                lst.Add(new clsParametros("@creacion", m_creacion));
                lst.Add(new clsParametros("@inicio", m_inicio));
                lst.Add(new clsParametros("@cierre", m_cierre));
                lst.Add(new clsParametros("@prioridad", m_prioridad));
                lst.Add(new clsParametros("@status", m_status));
                lst.Add(new clsParametros("@costo", m_costo));
                lst.Add(new clsParametros("@cantidad", m_cantidad));
                lst.Add(new clsParametros("@unidado", m_unidado));
                lst.Add(new clsParametros("@unidadc", m_unidadc));
                //Parametros de salida
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 20));
                lst.Add(new clsParametros("@codord", SqlDbType.Int, 3));
                M.EjecutarSP("Sp_RegistrarOrdenProducto", ref lst);
                mensaje = lst[12].m_valor.ToString();
                codigo = lst[13].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void RegistrarMovInvetario(DataTable dt, string nombreBd)
        {
            M.CambiarBD(nombreBd);
            M.InsertarDt(dt, "Sp_RegistrarMovInventario", "@dtRelacion");
        }
        public DataTable Listado_Inventario(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            return M.Listado(" SP_ListarInventario", null);
        }
        public DataTable Listado_InvTipoMovFiltro(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();

            try
            {
                lst.Add(new clsParametros("@CodTipoMov", codigo));
                return M.Listado("SP_FiltrarTipoMov", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        public DataTable Listado_FechaFiltro(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();

            try
            {
                lst.Add(new clsParametros("@fechainicial", inicio));
                lst.Add(new clsParametros("@fechaFinal", fin));
                lst.Add(new clsParametros("@TipoMov", codigo ));
                return M.Listado("SP_FiltrarFechas", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string EliminarArticulos(string nombreBd)
        {
            M.CambiarBD(nombreBd);
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            try
            {
                //pasamos parametros de entrada
                lst.Add(new clsParametros("@codigo", m_cod));
                //pasamos datos de salida 
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 20));
                M.EjecutarSP("sp_EliminArticulos", ref lst);

                mensaje = lst[1].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public void EliminarMovIn(DataTable dt, string nombreBd)
        {
            M.CambiarBD(nombreBd);
            M.InsertarDt(dt, "SP_EliminarMovInventrio", "@dtRelacion");
        }
        public void RegistrarArticulo_Prov(DataTable dt, string nombreBd)
        {
            M.CambiarBD(nombreBd);
            M.InsertarDt(dt, "sp_Registrar_ArticuloProv", "@dtRelacion");
        }
        public void ActualizarArticulo_Prov(DataTable dt, string nombreBd)
        {
            M.CambiarBD(nombreBd); 
            M.InsertarDt(dt, "Sp_ActualizarArticulo_Prov", "@dtRelacion");
        }
    }
}

