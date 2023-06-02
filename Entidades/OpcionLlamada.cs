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
        private string nombre;
        private int nroOrden;
        private SubOpcionLlamada[] subOpciones;
        private Validacion[] validacionesRequeridas;

        public OpcionLlamada( string nombre, int nroOrden, SubOpcionLlamada[] subopciones, Validacion[] validacionesRequeridas)
        {
            this.nombre = nombre;
            this.nroOrden = nroOrden;
            this.subOpciones = subopciones;
            this.validacionesRequeridas = validacionesRequeridas;
        }

        public bool EsOpcion(OpcionLlamada opcion)
        {
            return opcion == this;
        }

        public int ContieneSubOpcion(SubOpcionLlamada subOpcion)
        {
            //Comprueba que tenga subOpciones
            if(subOpciones != null)
            {
                for (int i = 0; i < subOpciones.Length; i++)
                {
                    if (subOpciones[i].EsSubOpcion(subOpcion))
                        return i;
                }
            }

            return -1;
        }

        public string ObtenerNombreSubOpcion(int subop)
        {
            return subOpciones[subop].ObtenerNombreSubOpcion();
        }

        public string ObtenerNombreOpcion()
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
