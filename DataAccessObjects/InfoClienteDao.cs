using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI_IVR_2023.Entidades;

namespace PPAI_IVR_2023.DataAccessObjects
{
    internal class InfoClienteDao
    {
        private static InfoClienteDao instancia;

        public static InfoClienteDao Instancia()
        {
            if (instancia == null)
                instancia = new InfoClienteDao();

            return instancia;
        }

        public List<InformacionCliente> ObtenerInfoDeCliente(int dni_cliente)
        {
            List<InformacionCliente> listaInfoCliente = new List<InformacionCliente>();

            // Consulta SQL
            string sqlComando = String.Concat("SELECT I.dato, I.id_validacion, I.id_validacion ",
                                    "FROM \"Informaciones Clientes\" I WHERE dni_cliente = @dni");
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("dni", dni_cliente);
            DataRowCollection resultadoConsulta = DataManager.Instancia().ConsultaSQL(sqlComando, parametros).Rows;

            // Mapeo de respuestas
            foreach (DataRow fila in resultadoConsulta)
            {
                listaInfoCliente.Add(MapeoOpcion(fila));
            }

            return listaInfoCliente;
        }

        private InformacionCliente MapeoOpcion(DataRow fila)
        {
            int id_validacion = Convert.ToInt32(fila["id_validacion"].ToString());
            InformacionCliente info = new InformacionCliente(
                fila["dato"].ToString(),
                ValidacionesDao.Instancia().ObtenerValidacion(id_validacion));

            return info;
        }
    }
}
