using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI_IVR_2023.Entidades;

namespace PPAI_IVR_2023.DataAccessObjects
{
    internal class SubopcionesDao
    {
        private static SubopcionesDao instancia;
        private SubOpcionLlamada[][] listasSubopciones;

        public SubopcionesDao()
        {
            listasSubopciones = new SubOpcionLlamada[3][];

            listasSubopciones[0] = new SubOpcionLlamada[3];
            listasSubopciones[0][0] = new SubOpcionLlamada("Cuenta con los datos", 1, new Validacion[0]);
            listasSubopciones[0][1] = new SubOpcionLlamada("No cuenta con los datos", 2, new Validacion[0]);
            listasSubopciones[0][2] = new SubOpcionLlamada("Desea comunicarse con responsable", 3, new Validacion[0]);

            listasSubopciones[1] = new SubOpcionLlamada[3];
            listasSubopciones[1][0] = new SubOpcionLlamada("Informar motivos de bloqueo", 1, new Validacion[0]);
            listasSubopciones[1][1] = new SubOpcionLlamada("Comunicarse con responsable", 2, new Validacion[0]);

            listasSubopciones[2] = new SubOpcionLlamada[4];
            listasSubopciones[2][0] = new SubOpcionLlamada("SubOp 1", 1, new Validacion[0]);
            listasSubopciones[2][1] = new SubOpcionLlamada("SubOp 2", 2, new Validacion[0]);
            listasSubopciones[2][2] = new SubOpcionLlamada("SubOp 3", 3, new Validacion[0]);
            listasSubopciones[2][3] = new SubOpcionLlamada("SubOp 4", 4, new Validacion[0]);
        }

        public static SubopcionesDao Instancia()
        {
            if (instancia == null)
                instancia = new SubopcionesDao();

            return instancia;
        }

        public SubOpcionLlamada[] GetSubopciones(int n)
        {
            if (n >= listasSubopciones.Length)
                return new SubOpcionLlamada[2];

            return listasSubopciones[n];
        }
    }
}
