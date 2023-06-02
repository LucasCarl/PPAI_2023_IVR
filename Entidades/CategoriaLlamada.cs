using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR_2023.Entidades
{
    public class CategoriaLlamada
    {
        private string nombre;
        private int nroOrden;
        private OpcionLlamada[] opciones;

        public CategoriaLlamada(string nombre, int nroOrden, OpcionLlamada[] opciones)
        {
            this.nombre = nombre;
            this.nroOrden = nroOrden;
            this.opciones = opciones;
        }

        public OpcionLlamada[] GetOpciones()
        {
            return opciones;
        }

        public int ContieneOpcion(OpcionLlamada opcion)
        {
            for (int i = 0; i < opciones.Length; i++)
            {
                if (opciones[i] == opcion)
                    return i;
            }

            return -1;
        }

        public int[] ContieneSubOpcion(SubOpcionLlamada subOpcion)
        {
            int[] ops = new int[2];
            for (int i = 0; i < opciones.Length; i++)
            {
                int subop = opciones[i].ContieneSubOpcion(subOpcion);
                if(subop != -1)
                {
                    ops[0] = i;
                    ops[1] = subop;
                    return ops;
                }
            }

            return new int[0];
        }

        public string ObtenerNombreCategoria()
        {
            string txt = nroOrden + ". " + nombre;
            return txt;
        }

        public string[] ObtenerNombresCategoriaOpcionSubOpcion(int op, int subop)
        {
            string[] nombres = new string[3];   //0: categoria - 1: opcion - 2: subopcion

            nombres[2] = opciones[op].ObtenerNombreSubOpcion(subop);
            nombres[1] = opciones[op].ObtenerNombreOpcion();
            nombres[0] = ObtenerNombreCategoria();

            return nombres;
        }

        public string[] ObtenerNombresCategoriaOpcion(int op)
        {
            string[] nombres = new string[3];   //0: categoria - 1: opcion - 2: subopcion

            nombres[1] = opciones[op].ObtenerNombreOpcion();
            nombres[0] = ObtenerNombreCategoria();

            return nombres;
        }
    }
}
