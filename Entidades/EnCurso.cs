using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR_2023.Entidades
{
    public class EnCurso : Estado
    {
        public EnCurso()
        {
            SetId(1);
            SetNombre("En curso");
        }

        public override bool EsEnCurso()
        {
            return true;
        }

        public override void MarcarFinalizada(Llamada llamada, DateTime fechaHora, List<CambioEstado> listaCambiosEstado)
        {
            // Setea fecha fin del ultimo cambio estado
            CambioEstado ultimo = BuscarEstadoActual(listaCambiosEstado);
            ultimo.SetFechaHoraFin(fechaHora);

            // Crea nuevo cambio estado
            Finalizada finalizada = new Finalizada();
            CambioEstado nuevoCambioEstado = CrearCambioEstado(fechaHora, finalizada);

            llamada.AgregarCambioEstado(nuevoCambioEstado);
            llamada.SetEstadoActual(finalizada);
        }
    }
}
