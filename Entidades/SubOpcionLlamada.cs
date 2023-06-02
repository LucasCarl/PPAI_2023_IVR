using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR_2023.Entidades
{
    public class SubOpcionLlamada
    {
        private string nombre;
        private int nroOrden;
        private Validacion[] validacionesRequeridas;

        public SubOpcionLlamada(string nombre, int nroOrden, Validacion[] validacionesRequerida)
        {
            this.nombre = nombre;
            this.nroOrden = nroOrden;
            this.validacionesRequeridas = validacionesRequerida;
        }

        public string GetNombre()
        {
            return nombre;
        }

        public bool EsSubOpcion(SubOpcionLlamada subOpcion)
        {
            return subOpcion == this;
        }

        public string ObtenerNombreSubOpcion()
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
