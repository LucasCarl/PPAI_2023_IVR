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

        public string GetNombre()
        {
            return nombre;
        }

        public int GetNroOrden()
        {
            return nroOrden;
        }
    }
}
