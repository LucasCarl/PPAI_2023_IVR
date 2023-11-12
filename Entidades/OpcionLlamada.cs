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
        private int id;
        private string nombre;
        private int nroOrden;
        private List<SubOpcionLlamada> subOpciones;
        private List<Validacion> validacionesRequeridas;

        public OpcionLlamada(int id, string nombre, int nroOrden, List<SubOpcionLlamada> subopciones, List<Validacion> validacionesRequeridas)
        {
            this.id = id;
            this.nombre = nombre;
            this.nroOrden = nroOrden;
            this.subOpciones = subopciones;
            this.validacionesRequeridas = validacionesRequeridas;
        }

        /// <summary> Comprueba que la opcion sea la misma </summary>
        /// <param name="opcion"> Opcion que se desea comparar </param>
        public bool EsOpcion(OpcionLlamada opcion)
        {
            return opcion.id == this.id;
        }

        /// <summary> Pregunta si la opcion tiene la subopcion deseada </summary>
        /// <param name="subOpcion"> Subopcion que se desea buscar </param>
        /// <returns> Indice de la subopcion en la lista de subopciones de la opcion. Devuelve -1 si no se encuentra </returns>
        public int ContieneSubOpcion(SubOpcionLlamada subOpcion)
        {
            //Comprueba que tenga subOpciones
            if(subOpciones != null)
            {
                for (int i = 0; i < subOpciones.Count; i++)
                {
                    if (subOpciones[i].EsSubOpcion(subOpcion))
                        return i;
                }
            }

            return -1;
        }

        /// <summary> Obtiene el nombre de la subopcion deseada </summary>
        /// <param name="subop"> Indice de la subopcion </param>
        public string ObtenerNombreSubOpcion(int subop)
        {
            return subOpciones[subop].ObtenerNombreSubOpcion();
        }

        /// <summary> Obtiene el nombre de la opcion, sumando su nroOrden y su nombre </summary>
        public string ObtenerNombreOpcion()
        {
            string txt = nroOrden + ". " + nombre;
            return txt;
        }

        /// <summary> Obtiene las validaciones requeridas para la opcion </summary>
        public List<Validacion> GetValidaciones()
        {
            return validacionesRequeridas;
        }
    }
}
