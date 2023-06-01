using System;
using System.Collections.Generic;
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
            Cliente[] clientes = ClientesDao.Instancia().GetClientes();
            listaLlamadas = new Llamada[3];
            listaLlamadas[0] = new Llamada(SubopcionesDao.Instancia().GetSubopciones(0)[1], null, new List<CambioEstado>(), clientes[0]);
            listaLlamadas[1] = new Llamada(null, OpcionesDao.Instancia().GetOpciones(1)[0], new List<CambioEstado>(), clientes[1]);
            listaLlamadas[2] = new Llamada(SubopcionesDao.Instancia().GetSubopciones(2)[2], null, new List<CambioEstado>(), clientes[2]);
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

    }
}
