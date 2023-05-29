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
        private Validacion[] validacionesRequerida;

        public SubOpcionLlamada(string nombre, int nroOrden, Validacion[] validacionesRequerida)
        {
            this.nombre = nombre;
            this.nroOrden = nroOrden;
            this.validacionesRequerida = validacionesRequerida;
        }

        public string GetNombre()
        {
            return nombre;
        }

        public int GetNroOrden()
        {
            return nroOrden;
        }

        public bool EsNro(int nro)
        {
            return nro == this.nroOrden;
        }

        public string MostarSubopcion()
        {
            string txt = nroOrden + ". " + nombre;
            return txt;
        }

        public Validacion[] GetValidaciones()
        {
            return validacionesRequerida;
        }
    }
}
