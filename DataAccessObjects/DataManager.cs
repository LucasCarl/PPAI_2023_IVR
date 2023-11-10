using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace PPAI_IVR_2023.DataAccessObjects
{
    class DataManager
    {
        private string strgConexion;
        private static DataManager instancia;

        //Constructor
        public DataManager()
        {
            strgConexion = "Data Source=.\\SQLEXPRESS;Initial Catalog=PPAI_IVS_DB;Integrated Security=true;TrustServerCertificate=true;";
        }

        /// <summary>Obtiene instancia del DataManager, si no hay la crea</summary>
        /// <returns>Instancia del DataManager</returns>
        public static DataManager Instancia()
        {
            //Checkea si existe una instancia previa, si no hay la crea
            if (instancia == null)
                instancia = new DataManager();

            return instancia;
        }


        /// <summary>
        ///     <para>Sentencias SQL del tipo “Select” con parámetros recibidos desde la interfaz</para>
        ///     <para>Recibe una sentencia sql como string y un diccionario de objetos como parámetros</para>
        /// </summary>
        /// 
        /// <param name="consulta"> Sentencia sql como string </param>
        /// <param name="parametros"> Diccionario de objetos como parámetros </param>
        /// 
        /// <returns> DataTable con el resultado de la consulta </returns>
        /// 
        /// Exepciones: Durante la apertura de la conexión || Durante la ejecución del comando
        public DataTable ConsultaSQL(string consulta, Dictionary<string, object> parametros = null)
        {
            SqlConnection dbConexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            DataTable tabla = new DataTable();

            try
            {
                //Conexion a DB
                dbConexion.ConnectionString = strgConexion;
                dbConexion.Open();

                comando.Connection = dbConexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = consulta;

                //Añade los parametros a la consulta
                if (parametros != null)
                {
                    foreach (var item in parametros)
                    {
                        comando.Parameters.AddWithValue(item.Key, item.Value);
                    }
                }

                //Hace la consulta y carga resultados en tabla
                tabla.Load(comando.ExecuteReader());

                return tabla;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                //Cierra la conexion si se pudo abrir
                if (dbConexion.State != ConnectionState.Closed)
                {
                    dbConexion.Close();
                }
            }
        }

        /// <summary>
        /// Sentencias SQL del tipo "Instert/Update/Delete"
        /// </summary>
        /// <param name="consulta"> Sentencia sql como string </param>
        /// <param name="parametros"> Diccionario de objetos como parámetros </param>
        /// <returns>Filas afectadas</returns>
        public int EjecutarSQL(string strSql, Dictionary<string, object> parametros = null)
        {
            // Se utiliza para sentencias SQL del tipo “Insert/Update/Delete”
            SqlConnection dbConexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();

            int rtdo = 0;

            // Try Catch Finally
            // Trata de ejecutar el código contenido dentro del bloque Try - Catch
            // Si hay error lo capta a través de una excepción
            // Si no hubo error
            try
            {
                dbConexion.ConnectionString = strgConexion;
                dbConexion.Open();
                comando.Connection = dbConexion;
                comando.CommandType = CommandType.Text;
                // Establece la instrucción a ejecutar
                comando.CommandText = strSql;

                //Agregamos a la colección de parámetros del comando los filtros recibidos
                if (parametros != null)
                {
                    foreach (var item in parametros)
                    {
                        comando.Parameters.AddWithValue(item.Key, item.Value);
                    }
                }

                // Retorna el resultado de ejecutar el comando
                rtdo = comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (dbConexion.State != ConnectionState.Closed)
                    dbConexion.Close();
            }
            return rtdo;
        }


    }
}
