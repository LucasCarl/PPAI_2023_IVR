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

        public bool ContieneOpcion(OpcionLlamada opcion)
        {
            for (int i = 0; i < opciones.Length; i++)
            {
                if (opciones[i] == opcion)
                    return true;
            }

            return false;
        }

        public string ObtenerNombreCategoria()
        {
            string txt = nroOrden + ". " + nombre;
            return txt;
        }

        public string[] ObtenerNombresCategoriaOpcionSubOpcion()
        {
            string[] nombres = new string[3];   //0: categoria - 1: opcion - 2: subopcion

            return nombres;
        }
    }
}
