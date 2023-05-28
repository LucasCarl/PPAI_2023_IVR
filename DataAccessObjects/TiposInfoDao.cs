using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI_IVR_2023.Entidades;

namespace PPAI_IVR_2023.DataAccessObjects
{
    internal class TiposInfoDao
    {
        private static TiposInfoDao instancia;
        private TipoInformacion[] listaTipos;

        public TiposInfoDao()
        {
            listaTipos = new TipoInformacion[3];
            listaTipos[0] = new TipoInformacion("Fecha de Nacimiento");
            listaTipos[1] = new TipoInformacion("Numero de Hijos");
            listaTipos[2] = new TipoInformacion("Codigo Postal");
        }

        public static TiposInfoDao Instancia()
        {
            if (instancia == null)
                instancia = new TiposInfoDao();

            return instancia;
        }

        public TipoInformacion[] GetTipos()
        {
            return listaTipos;
        }
    }
}
