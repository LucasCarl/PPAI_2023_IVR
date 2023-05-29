using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI_IVR_2023.Entidades;

namespace PPAI_IVR_2023.DataAccessObjects
{
    internal class AccionesDao
    {
        private static AccionesDao instancia;
        private Accion[] listaAcciones;

        public AccionesDao()
        {
            listaAcciones = new Accion[5];
            listaAcciones[0] = new Accion("Accion 1");
            listaAcciones[1] = new Accion("Accion 2");
            listaAcciones[2] = new Accion("Accion 3");
            listaAcciones[3] = new Accion("Accion 4");
            listaAcciones[4] = new Accion("Accion 5");
        }

        public static AccionesDao Instancia()
        {
            if (instancia == null)
                instancia = new AccionesDao();

            return instancia;
        }

        public Accion[] GetAcciones()
        {
            return listaAcciones;
        }
    }
}
