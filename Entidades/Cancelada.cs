using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR_2023.Entidades
{
    public class Cancelada : Estado
    {
        private int id;
        private string nombre;

        public Cancelada()
        {
            SetId(3);
            SetNombre("Cancelada");
        }
    }
}
