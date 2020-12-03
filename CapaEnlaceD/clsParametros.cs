using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaEnlaceD
{
    public class clsParametros
    {

        //atributos 
        public string m_nombre { get; set; }
        public object m_valor { get; set; }
        public SqlDbType m_tipoDato { get; set; }
        public ParameterDirection m_direccion { get; set; }
        public Int32 m_tamano { get; set; }
        public SqlParameter ParameterName;

        //constructores de entrada y de salida
        //1-entrada

        public clsParametros(string objNombre, Object objValor)
        {
            m_nombre =objNombre ;
            m_valor = objValor;
            m_direccion = ParameterDirection.Input;
          
        }

        //2-parametro de salida

        public clsParametros(string objNombre, SqlDbType objtipoDato, Int32 objTamano)

        {
            m_nombre = objNombre;
            m_tipoDato = objtipoDato;
            m_tamano = objTamano;
            m_direccion = ParameterDirection.Output;
        }     
            
    }
}
