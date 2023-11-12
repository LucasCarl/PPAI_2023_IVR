using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI_IVR_2023.Entidades;

namespace PPAI_IVR_2023.DataAccessObjects
{
    internal class SubopcionesDao
    {
        private static SubopcionesDao instancia;
        private List<SubOpcionLlamada>[] listasSubopcionesHard;

        /*
        public SubopcionesDao()
        {
            List<Validacion> listaValidaciones = ValidacionesDao.Instancia().ObtenerValidaciones();
            listasSubopcionesHard = new List<SubOpcionLlamada>[3];

            listasSubopcionesHard[0] = new List<SubOpcionLlamada>();
            listasSubopcionesHard[0][0] = new SubOpcionLlamada("Cuenta con los datos", 1, new List<Validacion> { listaValidaciones[0], listaValidaciones[1] });
            listasSubopcionesHard[0][1] = new SubOpcionLlamada("No cuenta con los datos", 2, new List<Validacion> { listaValidaciones[0], listaValidaciones[1] });
            listasSubopcionesHard[0][2] = new SubOpcionLlamada("Desea comunicarse con responsable", 3, new List<Validacion> { listaValidaciones[0], listaValidaciones[1] });

            listasSubopcionesHard[1] = new List<SubOpcionLlamada>();
            listasSubopcionesHard[1][0] = new SubOpcionLlamada("Informar motivos de bloqueo", 1, new List<Validacion> { listaValidaciones[0] });
            listasSubopcionesHard[1][1] = new SubOpcionLlamada("Comunicarse con responsable", 2, new List<Validacion> { listaValidaciones[0], listaValidaciones[2] });

            listasSubopcionesHard[2] = new List<SubOpcionLlamada>();
            listasSubopcionesHard[2][0] = new SubOpcionLlamada("SubOp 1", 1, new List<Validacion> { listaValidaciones[1] });
            listasSubopcionesHard[2][1] = new SubOpcionLlamada("SubOp 2", 2, new List<Validacion> { listaValidaciones[0] });
            listasSubopcionesHard[2][2] = new SubOpcionLlamada("SubOp 3", 3, new List<Validacion> { listaValidaciones[1], listaValidaciones[2] });
            listasSubopcionesHard[2][3] = new SubOpcionLlamada("SubOp 4", 4, new List<Validacion> { listaValidaciones[0], listaValidaciones[1], listaValidaciones[2] });
        }
        */

        public static SubopcionesDao Instancia()
        {
            if (instancia == null)
                instancia = new SubopcionesDao();

            return instancia;
        }

        /*
        public SubOpcionLlamada[] GetSubopciones(int n)
        {
            if (n >= listasSubopcionesHard.Length)
                return new SubOpcionLlamada[2];

            return listasSubopcionesHard[n];
        }
        */

        public List<SubOpcionLlamada> ObtenerSubopcionesDeOpcion(int id_opcion)
        {
            List<SubOpcionLlamada> listaSubopciones = new List<SubOpcionLlamada>();

            // Consulta SQL
            string sqlComando = String.Concat("SELECT S.id_subopcion, S.nombre, S.orden FROM Subopciones S ",
                                    "WHERE id_opcion = @opcion ORDER BY S.orden");
            Dictionary<string, object> parametros = new Dictionary<string, object>();
            parametros.Add("opcion", id_opcion);
            DataRowCollection resultadoConsulta = DataManager.Instancia().ConsultaSQL(sqlComando, parametros).Rows;

            // Mapeo de respuestas
            foreach (DataRow fila in resultadoConsulta)
            {
                listaSubopciones.Add(MapeoSubopcion(fila));
            }

            return listaSubopciones;
        }

        private SubOpcionLlamada MapeoSubopcion(DataRow fila)
        {
            int id_subop = Convert.ToInt32(fila["id_subopcion"].ToString());
            SubOpcionLlamada subopcion = new SubOpcionLlamada(
                id_subop,
                fila["nombre"].ToString(),
                Convert.ToInt32(fila["orden"].ToString()),
                ValidacionesDao.Instancia().ObtenerValidacionesDeSubopcion(id_subop));

            return subopcion;
        }
    }
}
