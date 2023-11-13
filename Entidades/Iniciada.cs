using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR_2023.Entidades
{
    public class Iniciada : Estado
    {
        private int id;
        private string nombre;

        public Iniciada()
        {
            id = 0;
            nombre = "Iniciada";
        }

        public override bool EsIniciada()
        {
            return true;
        }

        public override void MarcarEnCurso(Llamada llamada, DateTime fechaHora)
        {
            llamada.NuevoEstado(new EnCurso(), fechaHora);
        }
    }
}
