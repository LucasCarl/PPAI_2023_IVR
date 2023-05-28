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
        private InformacionCliente[][] listasInfoClientes;
        private TipoInformacion[] listaTipos;

        public ClientesDao()
        {
            TipoInformacion[] listaTipos = TiposInfoDao.Instancia().GetTipos();
            Validacion[] listaValidaciones = ValidacionesDao.Instancia().GetValidaciones();

            listasInfoClientes = new InformacionCliente[3][];
            listasInfoClientes[0] = new InformacionCliente[3];
            listasInfoClientes[0][0] = new InformacionCliente("25/10/1973", listaValidaciones[0], listaTipos[0]);
            listasInfoClientes[0][1] = new InformacionCliente("3", listaValidaciones[1], listaTipos[1]);
            listasInfoClientes[0][2] = new InformacionCliente("5004", listaValidaciones[2], listaTipos[2]);
            listasInfoClientes[1] = new InformacionCliente[3];
            listasInfoClientes[1][0] = new InformacionCliente("3/5/1985", listaValidaciones[0], listaTipos[0]);
            listasInfoClientes[1][1] = new InformacionCliente("0", listaValidaciones[1], listaTipos[1]);
            listasInfoClientes[1][2] = new InformacionCliente("5012", listaValidaciones[2], listaTipos[2]);
            listasInfoClientes[2] = new InformacionCliente[3];
            listasInfoClientes[2][0] = new InformacionCliente("13/7/1968", listaValidaciones[0], listaTipos[0]);
            listasInfoClientes[2][1] = new InformacionCliente("1", listaValidaciones[1], listaTipos[1]);
            listasInfoClientes[2][2] = new InformacionCliente("5000", listaValidaciones[2], listaTipos[2]);

            listaClientes = new Cliente[3];
            listaClientes[0] = new Cliente(42678364, "Ramon Ramirez", 351789891, listasInfoClientes[0]);
            listaClientes[1] = new Cliente(35485155, "Ernesto Lopez", 351111111, listasInfoClientes[1]);
            listaClientes[2] = new Cliente(42586684, "Norberto Diaz", 123123123, listasInfoClientes[2]);
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

        public InformacionCliente[][] GetInfoClientes()
        {
            return listasInfoClientes;
        }
    }
}
