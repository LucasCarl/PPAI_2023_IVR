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
        private TipoInformacion tipo;

        public InformacionCliente(string datoAValidar, Validacion validacion, TipoInformacion tipo)
        {
            this.datoAValidar = datoAValidar;
            this.validacion = validacion;
            this.tipo = tipo;
        }

        public TipoInformacion GetTipoInfo()
        {
            return tipo;
        }

        public bool CompararDato(string dato)
        {
            return dato == datoAValidar;
        }
    }
}
