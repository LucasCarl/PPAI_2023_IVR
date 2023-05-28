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
            listaValidaciones = new Validacion[0];
        }

        public static ValidacionesDao Instancia()
        {
            if (instancia == null)
                instancia = new ValidacionesDao();

            return instancia;
        }
    }
}
