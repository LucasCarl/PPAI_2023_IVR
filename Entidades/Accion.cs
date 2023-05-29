using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR_2023.Entidades
{
    public class Accion
    {
        private string descripcion;

        public Accion(string descripcion)
        {
            this.descripcion = descripcion;
        }

        public string GetDescripcion()
        {
            return descripcion;
        }
    }
}
