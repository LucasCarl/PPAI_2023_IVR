using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR_2023.Entidades
{
    public class OpcionLlamada
    {
        //private string audioMensajeSubopciones;
        //private string mensajeSubopciones;
        private string nombre;
        private int nroOrden;
        private SubOpcionLlamada[] subopcionLlamada;
        private Validacion[] validacionesRequeridas;

        public OpcionLlamada( string nombre, int nroOrden, SubOpcionLlamada[] subopcionLlamada, Validacion[] validacionesRequeridas)
        {
            //this.audioMensajeSubopciones = audioMensajeSubopciones;
            //this.mensajeSubopciones = mensajeSubopciones;
            this.nombre = nombre;
            this.nroOrden = nroOrden;
            this.subopcionLlamada = subopcionLlamada;
            this.validacionesRequeridas = validacionesRequeridas;
        }

        public bool ContieneSubopcion(SubOpcionLlamada subOpcion)
        {
            for (int i = 0; i < subopcionLlamada.Length; i++)
            {
                if (subopcionLlamada[i] == subOpcion)
                    return true;
            }

            return false;
        }

        public string MostarOpcion()
        {
            string txt = nroOrden + ". " + nombre;
            return txt;
        }

        public Validacion[] GetValidaciones()
        {
            return validacionesRequeridas;
        }
    }
}
