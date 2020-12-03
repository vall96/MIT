using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEnlaceD;
using System.Data;


namespace CapaLogicaNegocios
{
    public class clsStatus
    {
        private clsManejador M = new clsManejador();

        public string m_descripcion { get; set; }
        public int m_status { get; set; }

        public string status;
        public DataTable Listado_status()
        {
            return M.Listado("sp_TablaStatus", null);
        }

        public DataTable Listado_statusEliminados()
        {
            return M.Listado("sp_ListadoEstadosEliminados", null);
        }
        public string registrar_status()
        {
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            //  string status;
            try
            {
                //pasamos parametros de entrada
                //     lst.Add(new clsParametros("@status", m_status));
                lst.Add(new clsParametros("@descripcion", m_descripcion));

                //pasamos datos de salida 
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 100));
                lst.Add(new clsParametros("@status", SqlDbType.Int, 1));
                M.EjecutarSP("sp_agregarStatus", ref lst);

                mensaje = lst[1].m_valor.ToString();
                status = lst[2].m_valor.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }

        public string Actualizar_status()
        {
            string mensaje = "";
            List<clsParametros> lst = new List<clsParametros>();
            try
            {
                lst.Add(new clsParametros("@status", m_status));
                lst.Add(new clsParametros("@descripcion", m_descripcion));

                //datos de salida

                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 100));
                M.EjecutarSP("Sp_ActualizarStatus", ref lst);
                mensaje = lst[2].m_valor.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }

        public string eliminar_status()
        {
            string mensaje = "";
            List<clsParametros> lst = new List<clsParametros>();

            try
            {
                //pasamos parametros de entrada
                lst.Add(new clsParametros("@status", m_status));
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 100));
                M.EjecutarSP("sp_eliminarStatus", ref lst);
                mensaje = lst[1].m_valor.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return (mensaje);
        }
        public string EliminarStatus_Permanente()
        {
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";

            try
            {
                lst.Add(new clsParametros("@status", m_status));
                //pasamos datos de salida 
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 100));
                M.EjecutarSP("sp_EliminarStatusDefinitivo", ref lst);
                mensaje = lst[1].m_valor.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;

        }
        public string EliminarStatus_Todos()
        {
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";

            try
            {
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 100));

                M.EjecutarSP("sp_EliminarStatusTodos", ref lst);
                mensaje = lst[0].m_valor.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mensaje;
        }

        public string restaurarStatus_Todos()
        {
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            try
            {
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 100));
                M.EjecutarSP("sp_RestaurarStatusTodos", ref lst);
                mensaje = lst[0].m_valor.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public string restaurar_Status()
        {
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            try
            {
                lst.Add(new clsParametros("@status", m_status));

                //pasamos datos de salida 
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 100));
                M.EjecutarSP("sp_RestaurarStatus", ref lst);
                mensaje = lst[1].m_valor.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;

        }
    }
}
