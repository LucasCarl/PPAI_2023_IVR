using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI_IVR_2023.Entidades;

namespace PPAI_IVR_2023.DataAccessObjects
{
    internal class AccionesDao
    {
        private static AccionesDao instancia;

        public static AccionesDao Instancia()
        {
            if (instancia == null)
                instancia = new AccionesDao();

            return instancia;
        }

        public List<Accion> GetAcciones()
        {
            List<Accion> listaAcciones = new List<Accion>();

            // Consulta SQL
            string sqlComando = "SELECT A.nombre FROM Acciones A";
            DataRowCollection resultadoConsulta = DataManager.Instancia().ConsultaSQL(sqlComando).Rows;

            // Mapeo de respuestas
            foreach (DataRow fila in resultadoConsulta)
            {
                listaAcciones.Add(MapeoAccion(fila));
            }

            return listaAcciones;
        }

        private Accion MapeoAccion(DataRow fila)
        {
            Accion accion = new Accion(fila["nombre"].ToString());

            return accion;
        }
    }
}
