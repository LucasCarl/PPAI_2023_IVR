using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR_2023.Entidades
{
    public abstract class Estado
    {
        private int id;
        private string nombre;

        /// <summary> Obtiene el nombre del estado </summary>
        public string GetNombre()
        {
            return nombre;
        }

        public void SetNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public int GetId()
        {
            return id;
        }

        public void SetId(int id)
        {
            this.id = id;
        }

        /// <summary> Comprueba que sea el estado "Iniciada" </summary>
        public virtual bool EsIniciada()
        {
            return false;
        }

        /// <summary> Comprueba que sea el estado "En Curso" </summary>
        public virtual bool EsEnCurso()
        {
            return false;
        }

        /// <summary> Comprueba que sea el estado "Finalizada" </summary>
        public virtual bool EsFinalizada()
        {
            return false;
        }

        public virtual void MarcarEnCurso(Llamada llamada, DateTime fechaHora, List<CambioEstado> listaCambiosEstado) { }

        public virtual void MarcarFinalizada(Llamada llamada, DateTime fechaHora, List<CambioEstado> listaCambiosEstado) { }

        public virtual void MarcarCancelada(Llamada llamada, DateTime fechaHora, List<CambioEstado> listaCambiosEstado) { }

        public CambioEstado BuscarEstadoActual(List<CambioEstado> cambiosEstado)
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

        public CambioEstado CrearCambioEstado(DateTime fechaHora, Estado estado)
        {
            CambioEstado cambioEstado = new CambioEstado(fechaHora, estado);
            return cambioEstado;
        }
    }
}
