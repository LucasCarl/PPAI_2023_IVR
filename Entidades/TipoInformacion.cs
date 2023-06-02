using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR_2023.Entidades
{
    public class TipoInformacion
    {
        private string descripcion;

        public TipoInformacion(string descripcion)
        {
            this.descripcion = descripcion;
        }

        /// <summary> Obtiene la descripcion del tipo </summary>
        public string GetDescripcion()
        {
            return descripcion;
        }
    }
}
