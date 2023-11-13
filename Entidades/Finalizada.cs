using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR_2023.Entidades
{
    public class Finalizada : Estado
    {
        private int id;
        private string nombre;

        public Finalizada()
        {
            id = 2;
            nombre = "Finalizada";
        }

        public override bool EsFinalizada()
        {
            return true;
        }
    }
}
