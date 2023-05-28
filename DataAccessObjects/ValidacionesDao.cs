using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI_IVR_2023.Entidades;

namespace PPAI_IVR_2023.DataAccessObjects
{
    internal class ValidacionesDao
    {
        private static ValidacionesDao instancia;
        private Validacion[] listaValidaciones;

        public ValidacionesDao()
        {
            TipoInformacion[] listaTipos = TiposInfoDao.Instancia().GetTipos();
            listaValidaciones = new Validacion[3];
            listaValidaciones[0] = new Validacion("Fecha", 1, listaTipos[0]);
            listaValidaciones[1] = new Validacion("Hijos", 2, listaTipos[1]);
            listaValidaciones[2] = new Validacion("Cod Postal", 3, listaTipos[2]);
        }

        public static ValidacionesDao Instancia()
        {
            if (instancia == null)
                instancia = new ValidacionesDao();

            return instancia;
        }

        public Validacion[] GetValidaciones()
        {
            return listaValidaciones;
        }
    }
}
