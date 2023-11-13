using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR_2023.Entidades
{
    public class EnCurso : Estado
    {
        public EnCurso()
        {
            SetId(1);
            SetNombre("En curso");
        }

        public override bool EsEnCurso()
        {
            return true;
        }

        public override void MarcarFinalizada(Llamada llamada, DateTime fechaHora)
        {
            Estado finalizada = new Finalizada();
            llamada.NuevoEstado(finalizada, fechaHora);
        }
    }
}
