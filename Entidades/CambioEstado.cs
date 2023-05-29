using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR_2023.Entidades
{
    public class CambioEstado
    {
        private DateTime fechaHoraInicio;
        private DateTime fechaHoraFin;
        private Estado estado;

        public CambioEstado(DateTime fechaHoraInicio, Estado estado)
        {
            this.fechaHoraInicio = fechaHoraInicio;
            this.fechaHoraFin = DateTime.MinValue;
            this.estado = estado;
        }

        public DateTime GetFechaHoraInicio()
        {
            return fechaHoraInicio;
        }

        public void SetFechaHoraFin(DateTime fechaHora)
        {
            this.fechaHoraFin = fechaHora;
        }

        public DateTime GetFechaHoraFin()
        {
            return fechaHoraFin;
        }

        public string GetNombreEstado()
        {
            return estado.GetNombre();
        }

        public bool EsUltimo()
        {
            //Compara por MinValue porque DateTime nunca es null
            return fechaHoraFin == DateTime.MinValue;
        }
    }
}
