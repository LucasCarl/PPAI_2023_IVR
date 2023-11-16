using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR_2023.Entidades
{
    public class Iniciada : Estado
    {
        private int id;
        private string nombre;

        public Iniciada()
        {
            SetId(0);
            SetNombre("Iniciada");
        }

        public override bool EsIniciada()
        {
            return true;
        }

        public override void MarcarEnCurso(Llamada llamada, DateTime fechaHora, List<CambioEstado> listaCambiosEstado)
        {
            // Setea fecha fin del ultimo cambio estado
            CambioEstado ultimo = BuscarEstadoActual(listaCambiosEstado);
            ultimo.SetFechaHoraFin(fechaHora);

            // Crea nuevo cambio estado
            EnCurso enCurso = new EnCurso();
            CambioEstado nuevoCambioEstado = CrearCambioEstado(fechaHora, enCurso);

            llamada.AgregarCambioEstado(nuevoCambioEstado);
            llamada.SetEstadoActual(enCurso);
        }
    }
}
