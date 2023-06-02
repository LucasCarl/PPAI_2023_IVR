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

        /// <summary> Comprueba que la llamada sea del cliente </summary>
        /// <param name="cli"> Cliente a comprobar </param>
        public bool EsDeCliente(Cliente cli)
        {
            return this.cliente == cli;
        }

        /// <summary> Pregunta si la llamada esta en el estado iniciada </summary>
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

        /// <summary> Crea un nuevo estado de la llamada con el estado "En Curso" </summary>
        public void MarcarEnCurso(Estado enCurso, DateTime fechaHora)
        {
            NuevoEstado(enCurso, fechaHora);
        }

        /// <summary> Crea un nuevo estado de la llamada </summary>
        /// <param name="estado"> Estado a asignar </param>
        /// <param name="fechaHora"> Fecha hora actual </param>
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

        /// <summary> Obtiene el nombre del cliente de la llamada </summary>
        public string ObtenerNombreCliente()
        {
            return cliente.GetNombre();
        }

        /// <summary> Pregunta si la llamada tiene subopcion seleccionada o no </summary>
        public bool TieneSubopcion()
        {
            return subopcionSeleccionada != null;
        }

        /// <summary> Obtiene la subopcion seleccionada </summary>
        public SubOpcionLlamada GetSubOpcionSeleccionada()
        {
            return subopcionSeleccionada;
        }

        /// <summary> Obtiene la opcion seleccionada </summary>
        public OpcionLlamada GetOpcionSeleccionada()
        {
            return opcionSeleccionada;
        }

        /// <summary> Busca las validaciones que requiera la llamada. </summary>
        /// <returns> Los numero de orden de las validaciones </returns>
        public int[] ObtenerValidaciones()
        {
            // Obtiene las validaciones necesarias para la subopcion u opcion
            Validacion[] validaciones = new Validacion[0];
            if (TieneSubopcion())
                validaciones = subopcionSeleccionada.GetValidaciones();
            else
                validaciones = opcionSeleccionada.GetValidaciones();

            // Obtiene el nroOrden de cada una
            int[] nroValidaciones = new int[validaciones.Length];
            for (int i = 0; i < validaciones.Length; i++)
            {
                nroValidaciones[i] = validaciones[i].GetNroOrden();
            }
            return nroValidaciones;
        }

        /// <summary> Valida que el dato sea correcto </summary>
        /// <param name="validacion"> Numero de orden de la validacion a comprobar </param>
        /// <param name="dato"> Informacion a comprobar </param>
        public bool ValidarDato(int validacion, string dato)
        {
            return cliente.ValidarDato(validacion, dato);
        }

        /// <summary> Asigna la descripcion del operador a la llamada </summary>
        public void SetDescripcionOperador(string descripcion)
        {
            descripcionOperador = descripcion;
        }

        /// <summary> Crea un nuevo estado de la llamada con el estado "Finalizada" </summary>
        public void MarcarFinalizar(Estado finalizada, DateTime fechaHora)
        {
            NuevoEstado(finalizada, fechaHora);
        }

        /// <summary> Calcula la duracion total de la llamada </summary>
        public void CalcularDuracion()
        {
            // Se les da valores para que en la resta no de error de null
            CambioEstado primero = cambiosEstado[0];
            CambioEstado ultimo = cambiosEstado[cambiosEstado.Count - 1];

            DateTime fechaInicio = ObtenerInicioLlamada();
            // Busca los cambioEstados primero y ultimo
            for (int i = 0; i < cambiosEstado.Count; i++)
            {
                // Encuentra el primer CambioEstado
                if(cambiosEstado[i].GetFechaHoraInicio() == fechaInicio)
                {
                    primero = cambiosEstado[i];
                }
                // Encuentra el ultimo cambioEstado
                if (cambiosEstado[i].EsUltimo())
                {
                    ultimo = cambiosEstado[i];
                }
            }

            // Realiza la resta
            duracion = ultimo.GetFechaHoraInicio() - primero.GetFechaHoraInicio();
        }

        /// <summary> Obtiene la fecha hora inicio de la llamada </summary>
        private DateTime ObtenerInicioLlamada()
        {
            DateTime fechaInicio = DateTime.MaxValue;
            for (int i = 0; i < cambiosEstado.Count; i++)
            {
                // Encuentra el primer CambioEstado
                if (cambiosEstado[i].GetFechaHoraInicio() < fechaInicio)
                {
                    fechaInicio = cambiosEstado[i].GetFechaHoraInicio();
                }
            }

            return fechaInicio;
        }
    }
}
