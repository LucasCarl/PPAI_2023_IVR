using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR_2023.Entidades
{
    internal class CategoriaLlamada
    {
        //private string audioMensajeOpciones;
        //private string mensajeOpciones;
        private string nombre;
        private int nroOrden;
        private OpcionLlamada[] opciones;

        public CategoriaLlamada(string nombre, int nroOrden, OpcionLlamada[] opciones)
        {
            //this.audioMensajeOpciones = audioMensajeOpciones;
            //this.mensajeOpciones = mensajeOpciones;
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

        public string MostarCategoria()
        {
            string txt = nroOrden + ". " + nombre;
            return txt;
        }
    }
}
