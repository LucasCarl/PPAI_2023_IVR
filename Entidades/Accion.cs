using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR_2023.Entidades
{
    public class Accion
    {
        private int id;
        private string nombre;

        public Accion(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        /// <summary> Obtiene el nombre de la accion </summary>
        public string GetNombre()
        {
            return nombre;
        }

        public int GetId()
        {
            return id;
        }
    }
}
