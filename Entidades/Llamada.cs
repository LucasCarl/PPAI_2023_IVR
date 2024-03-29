﻿using System;
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
        private Accion accion;
        private string detalleAccion;
        private Estado estadoActual;

        public Llamada(SubOpcionLlamada subopcionSeleccionada, OpcionLlamada opcionSeleccionada, Cliente cliente, List<CambioEstado> cambiosEstado, Estado estadoActual)
        {
            this.descripcionOperador = "";
            this.subopcionSeleccionada = subopcionSeleccionada;
            this.opcionSeleccionada = opcionSeleccionada;
            this.cambiosEstado = cambiosEstado;
            this.cliente = cliente;
            this.estadoActual = estadoActual;
        }

        /// <summary> Comprueba que la llamada sea del cliente </summary>
        /// <param name="cli"> Cliente a comprobar </param>
        public bool EsDeCliente(Cliente cli)
        {
            return this.cliente.GetDni() == cli.GetDni();
        }

        private CambioEstado GetUltimoCambioEstado()
        {
            for (int i = 0; i < cambiosEstado.Count; i++)
            {
                if (cambiosEstado[i].EsUltimo())
                {
                    return cambiosEstado[i];
                }
            }

            return cambiosEstado[0];
        }

        /// <summary> Pregunta si la llamada esta en el estado iniciada </summary>
        public bool EstaIniciada()
        {
            return estadoActual.EsIniciada();
        }

        /// <summary> Crea un nuevo estado de la llamada con el estado "En Curso" </summary>
        public void MarcarEnCurso(DateTime fechaHora)
        {
            estadoActual.MarcarEnCurso(this, fechaHora, cambiosEstado);
        }

        /// <summary> Crea un nuevo estado de la llamada </summary>
        /// <param name="estado"> Estado a asignar </param>
        /// <param name="fechaHora"> Fecha hora actual </param>
        public void NuevoEstado(Estado estado, DateTime fechaHora)
        {
            GetUltimoCambioEstado().SetFechaHoraFin(fechaHora);

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
            List<Validacion> validaciones;
            if (TieneSubopcion())
                validaciones = subopcionSeleccionada.GetValidaciones();
            else
                validaciones = opcionSeleccionada.GetValidaciones();

            // Obtiene el nroOrden de cada una
            int[] nroValidaciones = new int[validaciones.Count];
            for (int i = 0; i < validaciones.Count; i++)
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
        public void MarcarFinalizada(DateTime fechaHora)
        {
            estadoActual.MarcarFinalizada(this , fechaHora, cambiosEstado);
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

        public Cliente GetCliente()
        {
            return cliente;
        }

        public TimeSpan GetDuracion()
        {
            return duracion;
        }

        public void SetAccion(Accion a)
        {
            accion = a;
        }

        public Accion GetAccion()
        {
            return accion;
        }

        public void SetDetalleAccion(string detalle)
        {
            detalleAccion = detalle;
        }

        public string GetDetalleAccion()
        {
            return detalleAccion;
        }

        public string GetDescOperador()
        {
            return descripcionOperador;
        }

        public List<CambioEstado> GetCambiosEstado()
        {
            return cambiosEstado;
        }

        public void AgregarCambioEstado(CambioEstado cambioEstado)
        {
            cambiosEstado.Add(cambioEstado);
        }

        public void SetEstadoActual(Estado estado)
        {
            estadoActual = estado;
        }

        public void MarcarCancelada(DateTime fechaHora)
        {
            estadoActual.MarcarCancelada(this, fechaHora, cambiosEstado);
        }
    }
}
