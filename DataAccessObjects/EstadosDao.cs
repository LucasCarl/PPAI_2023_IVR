using PPAI_IVR_2023.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR_2023.DataAccessObjects
{
    internal class EstadosDao
    {
        private static EstadosDao instancia;

        public static EstadosDao Instancia()
        {
            if (instancia == null)
                instancia = new EstadosDao();

            return instancia;
        }

        public void GuardarCambiosEstado(int id_llamada, List<CambioEstado> listaCambiosEstado)
        {
            // Instruccion SQL
            string comandoSql = String.Concat("INSERT INTO \"Cambios Estado\" ",
                                "(id_llamada, fecha_hora_inicio, fecha_hora_fin, id_estado) ",
                                "VALUES (@llamada, @inicio, @fin, @estado)");

            foreach (CambioEstado cambio in listaCambiosEstado)
            {
                Dictionary<string, object> parametros = new Dictionary<string, object>();
                parametros.Add("llamada", id_llamada);
                parametros.Add("inicio", cambio.GetFechaHoraInicio());
                parametros.Add("fin", cambio.GetFechaHoraFin() != DateTime.MinValue ? cambio.GetFechaHoraFin() : DBNull.Value);
                parametros.Add("estado", cambio.GetEstado().GetId());

                DataManager.Instancia().EjecutarSQL(comandoSql, parametros);
            }

        }
    }
}
