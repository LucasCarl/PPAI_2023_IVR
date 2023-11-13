using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI_IVR_2023.Entidades;

namespace PPAI_IVR_2023.DataAccessObjects
{
    internal class ClientesDao
    {
        private static ClientesDao instancia;
        private List<Cliente> listaClientesHard;
        private InformacionCliente[][] listasInfoClientes;

        /*
        public ClientesDao()
        {
            List<Validacion> listaValidaciones = ValidacionesDao.Instancia().ObtenerValidaciones();

            listasInfoClientes = new InformacionCliente[3][];
            listasInfoClientes[0] = new InformacionCliente[3];
            listasInfoClientes[0][0] = new InformacionCliente("25/10/1973", listaValidaciones[0]);
            listasInfoClientes[0][1] = new InformacionCliente("3", listaValidaciones[1]);
            listasInfoClientes[0][2] = new InformacionCliente("5004", listaValidaciones[2]);
            listasInfoClientes[1] = new InformacionCliente[3];
            listasInfoClientes[1][0] = new InformacionCliente("3/5/1985", listaValidaciones[0]);
            listasInfoClientes[1][1] = new InformacionCliente("0", listaValidaciones[1]);
            listasInfoClientes[1][2] = new InformacionCliente("5012", listaValidaciones[2]);
            listasInfoClientes[2] = new InformacionCliente[3];
            listasInfoClientes[2][0] = new InformacionCliente("13/7/1968", listaValidaciones[0]);
            listasInfoClientes[2][1] = new InformacionCliente("1", listaValidaciones[1]);
            listasInfoClientes[2][2] = new InformacionCliente("5000", listaValidaciones[2]);

            listaClientesHard = new List<Cliente>();
            listaClientesHard.Add(new Cliente(42678364, "Ramon Ramirez", 351789891, listasInfoClientes[0]));
            listaClientesHard.Add(new Cliente(35485155, "Ernesto Lopez", 351111111, listasInfoClientes[1]));
            listaClientesHard.Add(new Cliente(42586684, "Norberto Diaz", 123123123, listasInfoClientes[2]));
        }
        */

        public static ClientesDao Instancia()
        {
            if (instancia == null)
                instancia = new ClientesDao();

            return instancia;
        }

        public List<Cliente> GetClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();

            // Consulta SQL
            string sqlComando = "SELECT C.dni, C.nombre, C.Celular FROM Clientes C";
            DataRowCollection resultadoConsulta = DataManager.Instancia().ConsultaSQL(sqlComando).Rows;

            // Mapeo de respuestas
            foreach (DataRow fila in resultadoConsulta)
            {
                listaClientes.Add(MapeoCliente(fila));
            }

            return listaClientes;
        }

        private Cliente MapeoCliente(DataRow fila)
        {
            int dni = Convert.ToInt32(fila["dni"].ToString());

            Cliente cliente = new Cliente(
                dni,
                fila["nombre"].ToString(),
                fila["celular"].ToString(),
                InfoClienteDao.Instancia().ObtenerInfoDeCliente(dni));

            return cliente;
        }

        public InformacionCliente[][] GetInfoClientes()
        {
            return listasInfoClientes;
        }
    }
}
