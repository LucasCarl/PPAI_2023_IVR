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

        /// <summary> Obtiene el nombre del estado </summary>
        public string GetNombre()
        {
            return nombre;
        }

        /// <summary> Comprueba que sea el estado "Iniciada" </summary>
        public bool EsIniciada()
        {
            return this.GetNombre() == "Iniciada";
        }

        /// <summary> Comprueba que sea el estado "En Curso" </summary>
        public bool EsEnCurso()
        {
            return this.GetNombre() == "En Curso";
        }

        /// <summary> Comprueba que sea el estado "Finalizada" </summary>
        public bool EsFinalizada()
        {
            return this.GetNombre() == "Finalizada";
        }
    }
}
