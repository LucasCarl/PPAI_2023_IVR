using PPAI_IVR_2023.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR_2023.DataAccessObjects
{
    internal class EstadosDao
    {
        private static EstadosDao instancia;
        private Estado[] listaEstados;

        public EstadosDao()
        {
            listaEstados = new Estado[4];
            listaEstados[0] = new Estado("Iniciada");
            listaEstados[1] = new Estado("En Curso");
            listaEstados[2] = new Estado("Finalizada");
            listaEstados[3] = new Estado("Cancelada");
        }

        public static EstadosDao Instancia()
        {
            if (instancia == null)
                instancia = new EstadosDao();

            return instancia;
        }

        public Estado[] GetEstados()
        {
            return listaEstados;
        }
    }
}
