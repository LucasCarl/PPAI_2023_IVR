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
        private List<OpcionLlamada> opciones;

        public CategoriaLlamada(string nombre, int nroOrden, List<OpcionLlamada> opciones)
        {
            this.nombre = nombre;
            this.nroOrden = nroOrden;
            this.opciones = opciones;
        }

        /// <summary> Pregunta si la categoria tiene la opcion deseada </summary>
        /// <param name="opcion"> Opcion que se desea buscar </param>
        /// <returns> Indice de la opcion en la lista de opcioness de la categoria. Devuelve -1 si no se encuentra </returns>
        public int ContieneOpcion(OpcionLlamada opcion)
        {
            for (int i = 0; i < opciones.Count; i++)
            {
                if (opciones[i].EsOpcion(opcion))
                    return i;
            }

            return -1;
        }

        /// <summary> Pregunta si alguna de las opciones de la categoria tiene la subopcion deseada </summary>
        /// <param name="subOpcion"> Subopcion que se desea buscar </param>
        /// <returns> Vector con indices: 0-> opcion 1-> subopcion. Devuelve vector vacio si no se encuentra </returns>
        public int[] ContieneSubOpcion(SubOpcionLlamada subOpcion)
        {
            int[] ops = new int[2];
            for (int i = 0; i < opciones.Count; i++)
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

        /// <summary> Obtiene el nombre de la categoria, sumando su nroOrden y su nombre </summary>
        public string ObtenerNombreCategoria()
        {
            string txt = nroOrden + ". " + nombre;
            return txt;
        }

        /// <summary> Obtiene los nombres de: la categoria, la opcion y la subopcion </summary>
        /// <returns> Vector de string con los nombres: 0-> categoria 1-> opcion 2-> subopcion </returns>
        public string[] ObtenerNombresCategoriaOpcionSubOpcion(int op, int subop)
        {
            string[] nombres = new string[3];   //0: categoria - 1: opcion - 2: subopcion

            nombres[2] = opciones[op].ObtenerNombreSubOpcion(subop);
            nombres[1] = opciones[op].ObtenerNombreOpcion();
            nombres[0] = ObtenerNombreCategoria();

            return nombres;
        }

        /// <summary> Obtiene los nombres de: la categoria y la opcion </summary>
        /// <returns> Vector de string con los nombres: 0-> categoria 1-> opcion 2-> vacio </returns>
        public string[] ObtenerNombresCategoriaOpcion(int op)
        {
            string[] nombres = new string[3];   //0: categoria - 1: opcion - 2: subopcion

            nombres[1] = opciones[op].ObtenerNombreOpcion();
            nombres[0] = ObtenerNombreCategoria();

            return nombres;
        }
    }
}
