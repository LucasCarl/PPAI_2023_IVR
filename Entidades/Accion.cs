using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR_2023.Entidades
{
    public class Accion
    {
        private string nombre;

        public Accion(string nombre)
        {
            this.nombre = nombre;
        }

        /// <summary> Obtiene el nombre de la accion </summary>
        public string GetNombre()
        {
            return nombre;
        }
    }
}
