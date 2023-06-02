using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR_2023.Entidades
{
    public class Validacion
    {
        private string nombre;
        private int nroOrden;

        public Validacion(string nombre, int nroOrden)
        {
            this.nombre = nombre;
            this.nroOrden = nroOrden;
        }

        /// <summary> Obtiene el nombre de la validacion </summary>
        public string GetNombre()
        {
            return nombre;
        }

        /// <summary> Obtiene el numero de orden de la validacion </summary>
        public int GetNroOrden()
        {
            return nroOrden;
        }
    }
}
