using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR_2023.Entidades
{
    public class Finalizada : Estado
    {
        public Finalizada()
        {
            SetId(2);
            SetNombre("Finalizada");
        }

        public override bool EsFinalizada()
        {
            return true;
        }
    }
}
