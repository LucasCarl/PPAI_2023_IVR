using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR_2023.Entidades
{
    public class SubOpcionLlamada
    {
        private int id;
        private string nombre;
        private int nroOrden;
        private List<Validacion> validacionesRequeridas;

        public SubOpcionLlamada(int id, string nombre, int nroOrden, List<Validacion> validacionesRequerida)
        {
            this.id = id;
            this.nombre = nombre;
            this.nroOrden = nroOrden;
            this.validacionesRequeridas = validacionesRequerida;
        }

        /// <summary> Comprueba que la subopcion sea la misma </summary>
        /// <param name="subOpcion"> Subopcion que se desea comparar </param>
        public bool EsSubOpcion(SubOpcionLlamada subOpcion)
        {
            return subOpcion.id == this.id;
        }

        /// <summary> Obtiene el nombre de la subopcion, sumando su nroOrden y su nombre </summary>
        public string ObtenerNombreSubOpcion()
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
