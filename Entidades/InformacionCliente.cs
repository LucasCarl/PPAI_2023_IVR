using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR_2023.Entidades
{
    public class InformacionCliente
    {
        private string datoAValidar;
        private Validacion validacion;

        public InformacionCliente(string datoAValidar, Validacion validacion)
        {
            this.datoAValidar = datoAValidar;
            this.validacion = validacion;
        }

        public bool TieneValidacion(int nroOrden)
        {
            return validacion.getNroOrden() == nroOrden;
        }

        public bool EsDatoCorrecto(string dato)
        {
            return dato == datoAValidar;
        }
    }
}
