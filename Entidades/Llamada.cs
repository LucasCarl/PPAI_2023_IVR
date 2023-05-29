using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR_2023.Entidades
{
    public class Llamada
    {
        private SubOpcionLlamada subopcionSeleccionada;
        private OpcionLlamada opcionSeleccionada;
        private List<CambioEstado> cambiosEstado;
        private Cliente cliente;

        public Llamada(SubOpcionLlamada subopcionSeleccionada, OpcionLlamada opcionSeleccionada, List<CambioEstado> cambiosEstado, Cliente cliente)
        {
            this.subopcionSeleccionada = subopcionSeleccionada;
            this.opcionSeleccionada = opcionSeleccionada;
            this.cambiosEstado = cambiosEstado;
            this.cliente = cliente;
        }

        public string[] GetDatos()
        {
            string[] respuesta = new string[4];     //0:cliente - 1:subOpcion - 2:Opcion - 3:Categoria
            respuesta[0] = cliente.GetNombre();
            if(subopcionSeleccionada != null)
            {
                subopcionSeleccionada.GetNombre();
            }

            return respuesta;
        }

        public void EnCurso(Estado estado)
        {
            for (int i = 0; i < cambiosEstado.Count; i++)
            {
                if (cambiosEstado[i].EsUltimo())
                {
                    cambiosEstado[i].SetFechaHoraFin(DateTime.Now);
                    break;
                }
            }

            cambiosEstado.Add(new CambioEstado(DateTime.Now, estado));
        }

        public string GetNombreCliente()
        {
            return cliente.GetNombre();
        }

        public bool TieneSubopcion()
        {
            return subopcionSeleccionada != null;
        }

        public SubOpcionLlamada GetSubOpcion()
        {
            return subopcionSeleccionada;
        }

        public OpcionLlamada GetOpcion()
        {
            return opcionSeleccionada;
        }

        public bool ValidarDatoCliente(TipoInformacion tipo, string dato)
        {
            return cliente.ValidarDato(tipo, dato);
        }
    }
}
