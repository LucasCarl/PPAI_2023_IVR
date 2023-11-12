using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI_IVR_2023.Entidades;

namespace PPAI_IVR_2023.DataAccessObjects
{
    internal class ValidacionesDao
    {
        private static ValidacionesDao instancia;

        public static ValidacionesDao Instancia()
        {
            if (instancia == null)
                instancia = new ValidacionesDao();

            return instancia;
        }

        public List<Validacion> ObtenerValidaciones()
        {
            List<Validacion> listaValidaciones = new List<Validacion>();

            // Consulta SQL
            string sqlComando = "SELECT V.nombre, V.orden FROM Validaciones V ORDER BY V.orden";
            DataRowCollection resultadoConsulta = DataManager.Instancia().ConsultaSQL(sqlComando).Rows;

            // Mapeo de respuestas
            foreach (DataRow fila in resultadoConsulta)
            {
                listaValidaciones.Add(MapeoValidacion(fila));
            }

            return listaValidaciones;
        }

        public Validacion ObtenerValidacion(int id_validacion)
        {
            // Consulta SQL
            string sqlComando = "SELECT V.nombre, V.orden FROM Validaciones V WHERE V.id_validacion = @id";
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("id", id_validacion);
            DataRowCollection resultadoConsulta = DataManager.Instancia().ConsultaSQL(sqlComando, parametros).Rows;

            // Mapeo de respuesta
            Validacion validacion = MapeoValidacion(resultadoConsulta[0]);
            
            return validacion;
        }

        private Validacion MapeoValidacion(DataRow fila)
        {
            Validacion validacion = new Validacion(fila["nombre"].ToString(), Convert.ToInt32(fila["orden"].ToString()));

            return validacion;
        }

        public List<Validacion> ObtenerValidacionesDeSubopcion(int id_subopcion)
        {
            List<Validacion> listaValidaciones = new List<Validacion>();

            // Consulta SQL
            string sqlComando = String.Concat("SELECT V.nombre, V.orden FROM Validaciones V, \"Validaciones X Subopcion\" VS ",
                                "WHERE VS.id_subopcion = @subop AND VS.id_validacion = V.id_validacion ORDER BY V.orden");
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("subop", id_subopcion);
            DataRowCollection resultadoConsulta = DataManager.Instancia().ConsultaSQL(sqlComando, parametros).Rows;

            // Mapeo de respuestas
            foreach (DataRow fila in resultadoConsulta)
            {
                listaValidaciones.Add(MapeoValidacion(fila));
            }

            return listaValidaciones;
        }

        public List<Validacion> ObtenerValidacionesDeOpcion(int id_opcion)
        {
            List<Validacion> listaValidaciones = new List<Validacion>();

            // Consulta SQL
            string sqlComando = String.Concat("SELECT V.nombre, V.orden FROM Validaciones V, \"Validaciones X Opcion\" VO ",
                                "WHERE VO.id_opcion = @op AND VO.id_validacion = V.id_validacion ORDER BY V.orden");
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("op", id_opcion);
            DataRowCollection resultadoConsulta = DataManager.Instancia().ConsultaSQL(sqlComando, parametros).Rows;

            // Mapeo de respuestas
            foreach (DataRow fila in resultadoConsulta)
            {
                listaValidaciones.Add(MapeoValidacion(fila));
            }

            return listaValidaciones;
        }
    }
}
