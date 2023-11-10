using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI_IVR_2023.Entidades;

namespace PPAI_IVR_2023.DataAccessObjects
{
    internal class OpcionesDao
    {
        private static OpcionesDao instancia;
        private OpcionLlamada[][] listasOpciones;

        public OpcionesDao()
        {
            List<Validacion> listaValidaciones = ValidacionesDao.Instancia().ObtenerValidaciones();
            listasOpciones = new OpcionLlamada[3][];
            
            listasOpciones[0] = new OpcionLlamada[2];
            listasOpciones[0][0] = new OpcionLlamada("Nueva Tarjeta", 1, SubopcionesDao.Instancia().GetSubopciones(0), null);
            listasOpciones[0][1] = new OpcionLlamada("Anular Tarjeta", 2, SubopcionesDao.Instancia().GetSubopciones(0), null);

            listasOpciones[1] = new OpcionLlamada[2];
            listasOpciones[1][0] = new OpcionLlamada("Conoce motivo bloqueo", 1, null, new Validacion[2] { listaValidaciones[0], listaValidaciones[2] });
            listasOpciones[1][1] = new OpcionLlamada("Desconoce motivo bloqueo", 2, SubopcionesDao.Instancia().GetSubopciones(1), null);

            listasOpciones[2] = new OpcionLlamada[3];
            listasOpciones[2][0] = new OpcionLlamada("Op1", 1, SubopcionesDao.Instancia().GetSubopciones(2), null);
            listasOpciones[2][1] = new OpcionLlamada("Op2", 2, null, new Validacion[1] { listaValidaciones[2] });
            listasOpciones[2][2] = new OpcionLlamada("Op3", 3, null, new Validacion[3] { listaValidaciones[0], listaValidaciones[1], listaValidaciones[2] });
        }

        public static OpcionesDao Instancia()
        {
            if (instancia == null)
                instancia = new OpcionesDao();

            return instancia;
        }

        public OpcionLlamada[] GetOpciones(int n)
        {
            if (n >= listasOpciones.Length)
                return new OpcionLlamada[0];

            return listasOpciones[n];
        }
    }
}
