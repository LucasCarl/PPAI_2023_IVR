using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR_2023.Entidades
{
    public class Llamada
    {
        private string descripcionOperador;
        private TimeSpan duracion;
        private SubOpcionLlamada subopcionSeleccionada;
        private OpcionLlamada opcionSeleccionada;
        private List<CambioEstado> cambiosEstado;
        private Cliente cliente;

        public Llamada(SubOpcionLlamada subopcionSeleccionada, OpcionLlamada opcionSeleccionada, List<CambioEstado> cambiosEstado, Cliente cliente)
        {
            this.descripcionOperador = "";
            this.subopcionSeleccionada = subopcionSeleccionada;
            this.opcionSeleccionada = opcionSeleccionada;
            this.cambiosEstado = cambiosEstado;
            this.cliente = cliente;
        }

        public bool EsDeCliente(Cliente cli)
        {
            return this.cliente == cli;
        }

        public bool EstaIniciada(Estado ini)
        {
            for (int i = 0; i < cambiosEstado.Count; i++)
            {
                if (cambiosEstado[i].EsUltimo())
                {
                    return cambiosEstado[i].EsIniciada(ini);
                }
            }

            return false;
        }

        //borrar
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

        public void MarcarEnCurso(Estado enCurso, DateTime fechaHora)
        {
            NuevoEstado(enCurso, fechaHora);
        }

        private void NuevoEstado(Estado estado, DateTime fechaHora)
        {
            for (int i = 0; i < cambiosEstado.Count; i++)
            {
                if (cambiosEstado[i].EsUltimo())
                {
                    cambiosEstado[i].SetFechaHoraFin(DateTime.Now);
                    break;
                }
            }

            cambiosEstado.Add(new CambioEstado(fechaHora, estado));
        }

        public string ObtenerNombreCliente()
        {
            return cliente.GetNombre();
        }

        public bool TieneSubopcion()
        {
            return subopcionSeleccionada != null;
        }

        public SubOpcionLlamada GetSubOpcionSeleccionada()
        {
            return subopcionSeleccionada;
        }

        public OpcionLlamada GetOpcionSeleccionada()
        {
            return opcionSeleccionada;
        }

        /// <summary> Busca las validaciones que requiera la llamada. </summary>
        /// <returns> Los numero de orden de las validaciones </returns>
        public int[] ObtenerValidaciones()
        {
            //Obtiene las validaciones necesarias para la subopcion u opcion
            Validacion[] validaciones = new Validacion[0];
            if (TieneSubopcion())
                validaciones = subopcionSeleccionada.GetValidaciones();
            else
                validaciones = opcionSeleccionada.GetValidaciones();

            //Obtiene el nroOrden de cada una
            int[] nroValidaciones = new int[validaciones.Length];
            for (int i = 0; i < validaciones.Length; i++)
            {
                nroValidaciones[i] = validaciones[i].GetNroOrden();
            }
            return nroValidaciones;
        }

        public bool ValidarDato(int validacion, string dato)
        {
            return cliente.ValidarDato(validacion, dato);
        }

        public void SetDescripcionOperador(string descripcion)
        {
            descripcionOperador = descripcion;
        }

        public void MarcarFinalizar(Estado finalizada, DateTime fechaHora)
        {
            NuevoEstado(finalizada, fechaHora);
        }

        public void CalcularDuracion()
        {
            //Se les da valores para que en la resta no de error de null
            CambioEstado primero = cambiosEstado[0];
            CambioEstado ultimo = cambiosEstado[cambiosEstado.Count - 1];

            DateTime fechaInicio = DateTime.MaxValue;
            //Busca los cambioEstados primero y ultimo
            for (int i = 0; i < cambiosEstado.Count; i++)
            {
                //Encuentra el primer CambioEstado
                if(cambiosEstado[i].GetFechaHoraInicio() < fechaInicio)
                {
                    primero = cambiosEstado[i];
                    fechaInicio = primero.GetFechaHoraInicio();
                }
                //Encuentra el ultimo cambioEstado
                if (cambiosEstado[i].EsUltimo())
                {
                    ultimo = cambiosEstado[i];
                }
            }

            //Realiza la resta
            duracion = ultimo.GetFechaHoraInicio() - primero.GetFechaHoraInicio();
        }

        private void ObtenerInicioLlamada()
        {

        }
    }
}
