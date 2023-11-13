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
            this.fechaHoraFin = DateTime.MinValue;      //MinValue porque DateTime no permite null
            this.estado = estado;
        }

        /// <summary> Obtiene la fecha hora cuando se creo el cambio estado </summary>
        public DateTime GetFechaHoraInicio()
        {
            return fechaHoraInicio;
        }

        /// <summary> Coloca la fecha hora cuando se termina el cambio estado </summary>
        public void SetFechaHoraFin(DateTime fechaHora)
        {
            this.fechaHoraFin = fechaHora;
        }

        /// <summary> Detecta si es el ultimo cambio de estado </summary>
        public bool EsUltimo()
        {
            // Compara por MinValue porque DateTime nunca es null
            return fechaHoraFin == DateTime.MinValue;
        }

        /// <summary> Detecta si el cambio de estado tiene el estado iniciada </summary>
        public bool EsIniciada()
        {
            return estado.EsIniciada();
        }

        public DateTime GetFechaHoraFin()
        {
            return fechaHoraFin;
        }

        public Estado GetEstado()
        {
            return estado;
        }
    }
}
