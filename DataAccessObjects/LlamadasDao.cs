using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI_IVR_2023.Entidades;

namespace PPAI_IVR_2023.DataAccessObjects
{
    internal class LlamadasDao
    {
        private static LlamadasDao instancia;
        private Llamada[] listaLlamadas;

        public LlamadasDao()
        {
            List<Cliente> clientes = ClientesDao.Instancia().GetClientes();
            Estado iniciada = EstadosDao.Instancia().GetEstados()[0];
            listaLlamadas = new Llamada[3];
            listaLlamadas[0] = new Llamada(SubopcionesDao.Instancia().ObtenerSubopcionesDeOpcion(0)[1], null, new List<CambioEstado>() { new CambioEstado(DateTime.Now, iniciada) }, clientes[0]);
            listaLlamadas[1] = new Llamada(null, OpcionesDao.Instancia().ObtenerOpcionesDeCategoria(1)[0], new List<CambioEstado>() { new CambioEstado(DateTime.Now, iniciada) }, clientes[1]);
            listaLlamadas[2] = new Llamada(SubopcionesDao.Instancia().ObtenerSubopcionesDeOpcion(4)[2], null, new List<CambioEstado>() { new CambioEstado(DateTime.Now, iniciada) }, clientes[2]);
        }

        public static LlamadasDao Instancia()
        {
            if (instancia == null)
                instancia = new LlamadasDao();

            return instancia;
        }

        public Llamada[] GetLlamadas()
        {
            return listaLlamadas;
        }

        public int ObtenerUltimoId()
        {
            int id = -1;

            // Consulta SQL
            string sqlComando = "SELECT TOP id_llamada FROM Llamadas ORDER BY id_llamada DESC";
            DataRowCollection resultadoConsulta = DataManager.Instancia().ConsultaSQL(sqlComando).Rows;

            if (resultadoConsulta[0]["id_llamada"] != null)
            {
                id = Convert.ToInt32(resultadoConsulta[0]["id_llamada"].ToString());
            }

            return id++;
        }

        public void GuardarLlamada(Llamada llamada)
        {
            // Instruccion SQL
            string comandoSql = String.Concat("INSERT INTO Llamadas ", 
                        "(id_llamada, dni_cliente, duracion, id_accion, detalle_accion, descripcion_operador, id_opcion, id_subopcion) ",
                        "VALUES (@id, @dni, @duracion, @accion, @detalleAccion, @descOperador, @idOp, @idSubop)");

            int idOpcion = llamada.TieneSubopcion() ? -1 : llamada.GetOpcionSeleccionada().GetId();
            int idSubopcion = llamada.TieneSubopcion() ? llamada.GetSubOpcionSeleccionada().GetId() : -1;

            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("id", ObtenerUltimoId());
            parametros.Add("dni", llamada.GetCliente().GetDni());
            parametros.Add("duracion", (int)llamada.GetDuracion().TotalMinutes);
            parametros.Add("accion", llamada.GetAccion().GetId());
            parametros.Add("detalleAccion", llamada.GetDetalleAccion());
            parametros.Add("descOperador", llamada.GetDescOperador());
            parametros.Add("idOp", idOpcion != -1 ? idOpcion : null);
            parametros.Add("idSubop", idSubopcion != -1 ? idSubopcion : null);
        }
    }
}
