using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Configuration;

namespace CapaEnlaceD
{
    public class clsManejador
    {

        public ParameterDirection m_direccion { get; set; }

        public SqlParameter ParameterName;
        public SqlDbType m_tipoDato { get; set; }

        public SqlConnection conexionP;// new SqlConnection("Data Source = 10.64.80.112; Initial Catalog = MITCore; Integrated Security = True");
        //SqlConnection conexion = new SqlConnection("Data Source =  "+ mensaje + "; "+
        //   "Initial Catalog = MITCore; Integrated Security = True");
        string NombreBD = "MITCore";
        int inicio = 0;
        string servidor = ConfigurationManager.AppSettings["server"];
        string puerto = ConfigurationManager.AppSettings["port"];
        string user = ConfigurationManager.AppSettings["user"];
        string password = ConfigurationManager.AppSettings["password"];

        //string servidor = ConfigurationSettings.AppSettings["mensaje"];
        public SqlConnection GenerarConexion()
        {
            SqlConnection conexion;
            if (servidor== "localhost")
            {
                conexion = new SqlConnection("Data Source = " + servidor + "; " +
                                            "Initial Catalog = MITCore;" + "Integrated Security = True");
                return conexion;
            }
            else
            {
                conexion = new SqlConnection("Data Source = " + servidor + "," + puerto + ";" + " Initial Catalog = MITCore; " +
                                             " user id = " + user + "; password =" + password);
                return conexion;
            }
        }

        public void CambiarBD(string nombreBD)
        {
            NombreBD = nombreBD;           
        }
        public SqlConnection CambiarConexion()
        {
            SqlConnection conexion;
            if (servidor == "localhost")
            {
                conexion = new SqlConnection("Data Source = " + servidor + "; Initial Catalog = " +
                                            NombreBD + " ;" + "Integrated Security = True");
                return conexion;
            }
            else
            {
                conexion = new SqlConnection("Data Source = " + servidor + "," + 
                                              puerto + ";" + " Initial Catalog = " + NombreBD + ";" + 
                                                "user id = " + user + "; password =" + password);
                return conexion;
            }
           // SqlConnection conexion = new SqlConnection("Data Source = " + servidor  + "; Initial Catalog = " + NombreBD + " ;" + "Integrated Security = True");
           // SqlConnection conexion = new SqlConnection("Data Source = " + servidor + ","+puerto + ";" + " Initial Catalog = "+NombreBD+ ";"+  "user id = "+ user+ "; password ="+password);
           // return conexion;
           // conexion = new SqlConnection("Data Source = DESARROLLO_2; " +
           // "Initial Catalog = " +nombreBD +" ;" + "Integrated Security = True");
        }
       

        public void conectar()
        {
            if (conexionP.State == ConnectionState.Closed)
            {
                conexionP.Open();
            }
        }

        public void desconectar()
        {
            if (conexionP.State == ConnectionState.Open)
            {
                conexionP.Close();
            }

        }

        //retina para los listados op consultas (select*from, consultas,etc...)
        //lo primero a crear es una tabla para los parametros para ello uso el dt

        public DataTable Listado(string NombreSP, List<clsParametros> lst)
        {
            if (NombreBD != "MITCore")
            {                
                conexionP = CambiarConexion();
            }
            else
            {
                conexionP = GenerarConexion();
            }
            DataTable dt = new DataTable();
            SqlDataAdapter da;                      // es como el cmd me va a permitir ejecutar el 
                                                    //procedimiento almacenaado para listar pasa la informacion de la base de datos, al dt            
            try
            {
                
                conectar();
                da = new SqlDataAdapter(NombreSP, conexionP);                
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                if (lst != null)           //si la lista tiene valor 
                {

                    for (int i = 0; i < lst.Count; i++)
                    {
                        da.SelectCommand.Parameters.AddWithValue(lst[i].m_nombre, lst[i].m_valor);              //como aqui estoy pidiendo un listado mis parametro son nombre y valor (entrada)
                    }

                }
                da.Fill(dt);
            }

            catch (Exception ex)
            {
                throw ex;
            }
            desconectar();
            NombreBD = "MITCore";        
            return dt;


        }

        //proceso para ejecutar un procedimiento almacenado 
        public void EjecutarSP(string NombreSP, ref List<clsParametros> lst)
        {           
           if (NombreBD != "MITCore")
            {
                conexionP = CambiarConexion();
            } 
           else
            {
                conexionP = GenerarConexion();
            }
            SqlCommand cmd;
            try
            {
                conectar();
                cmd = new SqlCommand(NombreSP, conexionP);
                cmd.CommandType = CommandType.StoredProcedure;
                //verificando si la lista no esta vacia

                if (lst != null)
                //recorremos la lista
                {
                    for (int i = 0; i < lst.Count; i++)
                    {
                        if (lst[i].m_direccion == ParameterDirection.Input)
                        {
                            cmd.Parameters.AddWithValue(lst[i].m_nombre, lst[i].m_valor);
                        }
                        if (lst[i].m_direccion == ParameterDirection.Output)
                        {
                            cmd.Parameters.Add(lst[i].m_nombre, lst[i].m_tipoDato, lst[i].m_tamano).Direction = ParameterDirection.Output;
                        }

                    }
                    cmd.ExecuteNonQuery();

                    //Recuperamos los datos de Salida
                    for (int i = 0; i < lst.Count; i++)
                    {
                        if (cmd.Parameters[i].Direction == ParameterDirection.Output)
                        {
                            lst[i].m_valor = cmd.Parameters[i].Value;
                        }

                    }
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
            desconectar();
            NombreBD = "MITcore";
            //RegresarCadenaConexion();
        }
        public void InsertarDt(DataTable dt,string nombreSP, string tablaTemp)
        {
            // NombreBD = "MITcore";
            if (NombreBD != "MITCore")
            {
                conexionP = CambiarConexion();
            }
            else
            {
                conexionP = GenerarConexion();
            }
            try
            {
                conectar();
                SqlCommand cmd = new SqlCommand(nombreSP, conexionP);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(tablaTemp, dt);
                cmd.ExecuteNonQuery();
                desconectar();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void ActualizarDt(DataTable dt)
        {
           // GenerarConexion();
            try
            {
                conectar();
                SqlCommand cmd = new SqlCommand("sp_ActualizarRespuestas", conexionP);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@dtRespuestasT", dt);
                cmd.ExecuteNonQuery();
                desconectar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void crearBD(string nombreBD)
        {
            ProcessStartInfo cmd;
            cmd = new ProcessStartInfo("sqlcmd", "-S. -i " + 
           "C:\\Users\\desarrollo2\\Documents\\prueba.sql -v dbname = " + nombreBD);
            cmd.UseShellExecute = false;
            cmd.CreateNoWindow = true;
            cmd.RedirectStandardOutput = true;

            Process ejecutar = new Process();
            ejecutar.StartInfo = cmd;
            ejecutar.Start();
        }
    }
}
