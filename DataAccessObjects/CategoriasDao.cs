using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI_IVR_2023.Entidades;

namespace PPAI_IVR_2023.DataAccessObjects
{
    internal class CategoriasDao
    {
        private static CategoriasDao instancia;

        public static CategoriasDao Instancia()
        {
            if (instancia == null)
                instancia = new CategoriasDao();

            return instancia;
        }

        public List<CategoriaLlamada> ObtenerCategorias()
        {
            List<CategoriaLlamada> listaCategorias = new List<CategoriaLlamada>();

            // Consulta SQL
            string sqlComando = "SELECT C.id_categoria, C.nombre, C.orden FROM Categorias C ORDER BY C.orden";
            DataRowCollection resultadoConsulta = DataManager.Instancia().ConsultaSQL(sqlComando).Rows;

            // Mapeo de Respuestas
            foreach (DataRow fila in resultadoConsulta)
            {
                listaCategorias.Add(MapeoCategoria(fila));
            }
            return listaCategorias;
        }

        private CategoriaLlamada MapeoCategoria(DataRow fila)
        {
            int id_categoria = Convert.ToInt32(fila["id_categoria"].ToString());
            CategoriaLlamada categoria = new CategoriaLlamada(
                fila["nombre"].ToString(),
                Convert.ToInt32(fila["orden"].ToString()),
                OpcionesDao.Instancia().ObtenerOpcionesDeCategoria(id_categoria));

            return categoria;
        }
    }
}
