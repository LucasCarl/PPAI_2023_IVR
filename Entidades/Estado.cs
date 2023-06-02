using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR_2023.Entidades
{
    public class Estado
    {
        private string nombre;

        public Estado(string nombre)
        {
            this.nombre = nombre;
        }

        public string GetNombre()
        {
            return nombre;
        }

        public bool EsIniciada()
        {
            return this.GetNombre() == "Iniciada";
        }

        public bool EsEnCurso()
        {
            return this.GetNombre() == "En Curso";
        }

        public bool EsFinalizada()
        {
            return this.GetNombre() == "Finalizada";
        }
    }
}
