using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI_IVR_2023.Entidades;

namespace PPAI_IVR_2023.DataAccessObjects
{
    internal class ClientesDao
    {
        private static ClientesDao instancia;
        private Cliente[] listaClientes;
        private InformacionCliente[] listaInfoClientes;

        public ClientesDao()
        {
            listaClientes = new Cliente[3];
            listaClientes[0] = new Cliente(42678364, "Ramon Ramirez", 351789891, new InformacionCliente[0]);
            listaClientes[1] = new Cliente(35485155, "Ernesto Lopez", 351111111, new InformacionCliente[0]);
            listaClientes[2] = new Cliente(42586684, "Norberto Diaz", 123123123, new InformacionCliente[0]);

            listaInfoClientes = new InformacionCliente[6];
        }

        public static ClientesDao Instancia()
        {
            if (instancia == null)
                instancia = new ClientesDao();

            return instancia;
        }

        public Cliente[] GetClientes()
        {
            return listaClientes;
        }

        public InformacionCliente[] GetInfoClientes()
        {
            return listaInfoClientes;
        }
    }
}
