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
    public class clsConfiguracion
    {
        private clsManejador M = new clsManejador();
        public string c_id { get; set; }
        public string c_valor { get; set; }
        //Propiedades del Sistema
        public DataTable listaModulo()
        {           
            return M.Listado("sp_ListaModulosCBO", null);
        }
        public DataTable listaropciones()
        {
            return M.Listado ("sp_ListarOpcionesGenerales",null);
        }
        public string ActualizarDecimal()
        {
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            try
            {
                lst.Add(new clsParametros("@Id", c_id));
                lst.Add(new clsParametros("@Valor", c_valor));
                lst.Add(new clsParametros("@Mensaje", SqlDbType.VarChar, 50));
                M.EjecutarSP("Sp_ActualizarDeciamal", ref lst);
                mensaje = lst[2].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
    }
}
