using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI_IVR_2023.Entidades;

namespace PPAI_IVR_2023.DataAccessObjects
{
    internal class CategoriasDao
    {
        private static CategoriasDao instancia;
        private CategoriaLlamada[] listaCategorias;

        public CategoriasDao()
        {
            listaCategorias = new CategoriaLlamada[3];
            listaCategorias[0] = new CategoriaLlamada("Robo", 1, OpcionesDao.Instancia().GetOpciones(0));
            listaCategorias[1] = new CategoriaLlamada("Bloqueo", 2, OpcionesDao.Instancia().GetOpciones(1));
            listaCategorias[2] = new CategoriaLlamada("Nueva Tarjeta", 3, OpcionesDao.Instancia().GetOpciones(2));
        }

        public static CategoriasDao Instancia()
        {
            if (instancia == null)
                instancia = new CategoriasDao();

            return instancia;
        }

        public CategoriaLlamada GetCategoria(int n)
        {
            return listaCategorias[n];
        }

        public CategoriaLlamada[] ObtenerTodasCategorias()
        {
            return listaCategorias;
        }
    }
}
