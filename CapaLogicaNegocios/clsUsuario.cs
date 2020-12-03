using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEnlaceD;
using System.Data;

namespace CapaLogicaNegocios
{
    public class clsUsuario
    {
        private clsManejador M = new clsManejador();
        //************************Valerie*******************
        public int m_codPregunta { get; set; }
        public string m_Pregunta { get; set; }

        public string preg; //variable declarada preguntas

        //**************************************************
        //atributos
        public string m_username { get; set; }
        public string m_password { get; set; }
        public int m_status { get; set; }
        public string m_nombre { get; set; }

        //**************************DATOSS PARAAAAAA GUARDAR AUDITORIA*******************
        //*******************************************************************************
        public DateTime m_fecha { get; set; }

        public string m_modificacion { get; set; }
        //*********************************************************************************
        //*********************************************************************************
        public DataTable Listado()
        {
            return M.Listado("sp_listadoUsuarios", null);
        }

        public string actualizar_usuarios()
        {
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            try
            {
                lst.Add(new clsParametros("@username", m_username));
                lst.Add(new clsParametros("@status", m_status));
                lst.Add(new clsParametros("@nombre", m_nombre));

                //pasamos datos de salida 

                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 100));
                M.EjecutarSP("sp_ActualizarUsuario", ref lst);
                mensaje = lst[3].m_valor.ToString();
                

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public string BuscarEstatus_Activo()        //para buscar si existe el resgistro activo
        {
            List<clsParametros> lst = new List<clsParametros>();
            string estatusExistente = "";
            try
            {
                //pasamos parametros de entrada                  
                lst.Add(new clsParametros("@status", m_status));              

                //pasamos datos de salida 

                lst.Add(new clsParametros("@status_activo", SqlDbType.VarChar, 100));
                M.EjecutarSP("sp_BuscarEstatus_Activo", ref lst);
                estatusExistente = lst[1].m_valor.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return estatusExistente;

        }
        public void registro_auditoria()
        {
            List<clsParametros> lst = new List<clsParametros>();
            
            try
            {
                lst.Add(new clsParametros("@username", m_username));
                lst.Add(new clsParametros("@fecha",m_fecha ));
                lst.Add(new clsParametros("@mofificacion",m_modificacion ));

                M.EjecutarSP("sp_InsertarAuditoria", ref lst);
               


            }
            catch (Exception ex)
            {
                throw ex;
            }

            
        }
        public string registar_usuarios()

        {
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";


            try
            {
                //pasamos parametros de entrada
                lst.Add(new clsParametros("@username", m_username));             //a que le voy a enviar y cual es el valor
                                                                                 //       lst.Add(new clsParametros("@password", m_password));
                lst.Add(new clsParametros("@status", m_status));
                lst.Add(new clsParametros("@nombre", m_nombre));

                //pasamos datos de salida 

                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 100));
                M.EjecutarSP("sp_RegistroUsuario", ref lst);
                mensaje = lst[3].m_valor.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;

        }
        //Rutina para Actualizar usuarios

        public DataTable Listado_Eliminados()
        {
            return M.Listado("sp_listadoUsuariosEliminados", null);
        }

        //rutina para eliminar usuarios
        public string EliminarUsuario()
        {
        List<clsParametros> lst = new List<clsParametros>();
        string mensaje = "";
        
            try
            {
                //pasamos parametros de entrada
                lst.Add(new clsParametros("@username", m_username));

                //pasamos datos de salida 
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 100));
                M.EjecutarSP("sp_eliminarUsuario", ref lst);
                mensaje = lst[1].m_valor.ToString();
                               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;

        }

        //Rutina para buscar usuarios

        public DataTable buscarUsuario (string objDni)
        {
            DataTable dt = new DataTable();
            List<clsParametros> lst = new List<clsParametros>();
            try
            {
                lst.Add(new clsParametros("@username", objDni));
                dt = M.Listado("sp_ValidarUsuario", lst);

            }
            catch(Exception ex)
            {
                throw ex;
            }


            return dt;

        }

        public string restaurar_Usuario()
        {
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            try
            {
                lst.Add(new clsParametros("@username", m_username));

                //pasamos datos de salida 
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 100));
                M.EjecutarSP("sp_RestaurarUsuario", ref lst);
                mensaje = lst[1].m_valor.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;

        }

        public string EliminarUsuario_Permanente()
        {
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";

            try
            {
                lst.Add(new clsParametros("@username", m_username));
                //pasamos datos de salida 
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 100));
                M.EjecutarSP("sp_EliminarUserDefinitivo", ref lst);
                mensaje = lst[1].m_valor.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;

        }

        public string EliminarUsuarios_Todos()
        {
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";

            try
            {
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 100));

                M.EjecutarSP("sp_EliminarUserTodos", ref lst);
                mensaje = lst[0].m_valor.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return mensaje;
        }

        public string restaurarUsuario_Todos()
        {
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            try
            {
                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 100));
                M.EjecutarSP("sp_RestaurarUserTodos", ref lst);
                mensaje = lst[0].m_valor.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }

       
        public void insertarRespuestas(DataTable dt)
        {
            
            M.InsertarDt(dt, "dbo.sp_InsertarRespuestas", "@dtRespuestas");
        }
       
        public DataTable BuscarUsuarioRespuestas()
        {
            List<clsParametros> lst = new List<clsParametros>();
            
            try
            {
                lst.Add(new clsParametros("@username", m_username));
                return M.Listado("sp_BuscarUsuarioRespuestas", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void ActualizarRespuestas(DataTable dt)
        {
            M.ActualizarDt(dt);
        }

       


        //*******HECHO POR VALERIEEEEE PARA LA CLAVE***************************//
        public DataTable ListadoPreguntas()
        {
            return M.Listado("sp_TablaPreguntas", null);
        }
        public string RegistrarPreguntas()
        {
            List<clsParametros> lst = new List<clsParametros>();
            string mensaje = "";
            try
            {
                // parametros de entrada

                lst.Add(new clsParametros("@Preguntas", m_Pregunta));

                // de salida 

                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 100));
                lst.Add(new clsParametros("@CodPregunta", SqlDbType.Int, 1));

                // ejecutamos el procedimiento de almacenado 

                M.EjecutarSP("sp_AgregarPreguntas", ref lst);

                mensaje = lst[1].m_valor.ToString();
                preg = lst[2].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        public string eliminar_Preguntas()
        {
            string mensaje = "";
            List<clsParametros> lst = new List<clsParametros>();

            try
            {
                //pasamos parametros de entrada
                lst.Add(new clsParametros("@CodPregunta", m_codPregunta));

                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 100));

                //Ejecuta el procedimiento de almacenado 
                M.EjecutarSP("sp_eliminarPreguntas", ref lst);

                //Retorna el mensaje
                mensaje = lst[1].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return (mensaje);
        }

        //++++++++++++++++++++++++++++++++ Rutina de Claves ++++++++++++++++++++++++++++++++++++++++

        public string validar_Cambioclave()
        {
            string mensaje = "";
            List<clsParametros> lst = new List<clsParametros>();
            try
            {
                lst.Add(new clsParametros("@usuario", m_username));
                lst.Add(new clsParametros("@password", m_password));

                lst.Add(new clsParametros("@mensaje", SqlDbType.VarChar, 100));

                M.EjecutarSP("sp_CambiarClaveUser", ref lst);

                mensaje = lst[2].m_valor.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return mensaje;
        }
        //**************************FIN HECHO POR VALERIE*********************************************
    }
}
