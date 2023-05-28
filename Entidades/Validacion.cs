using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR_2023.Entidades
{
    internal class Validacion
    {
        //private string audioMensajeValidacion;
        private string nombre;
        private int nroOrden;
        private TipoInformacion tipo;

        public Validacion(string nombre, int nroOrden, TipoInformacion tipo)
        {
            //this.audioMensajeValidacion = audioMensajeValidacion;
            this.nombre = nombre;
            this.nroOrden = nroOrden;
            this.tipo = tipo;
        }
    }
}
