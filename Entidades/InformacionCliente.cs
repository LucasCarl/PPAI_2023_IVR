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

        /// <summary> Pregunta si tiene la validacion con el numero de orden indicado </summary>
        public bool TieneValidacion(int nroOrden)
        {
            return validacion.GetNroOrden() == nroOrden;
        }

        /// <summary> Comprueba que el dato sea el correcto </summary>
        /// <param name="dato"> Informacion a comparar </param>
        public bool EsDatoCorrecto(string dato)
        {
            return dato == datoAValidar;
        }
    }
}
