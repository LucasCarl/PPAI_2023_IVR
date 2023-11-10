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
        private Validacion[] listaValidacionesHard;

        public ValidacionesDao()
        {
            listaValidacionesHard = new Validacion[3];
            listaValidacionesHard[0] = new Validacion("Fecha", 1);
            listaValidacionesHard[1] = new Validacion("Hijos", 2);
            listaValidacionesHard[2] = new Validacion("Cod Postal", 3);
        }

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

        private Validacion MapeoValidacion(DataRow fila)
        {
            Validacion validacion = new Validacion(fila["nombre"].ToString(), Convert.ToInt32(fila["orden"].ToString()));

            return validacion;
        }
    }
}
