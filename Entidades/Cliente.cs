using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_IVR_2023.Entidades
{
    public class Cliente
    {
        private int dni;
        private string nombreCompleto;
        private int nroCelular;
        private InformacionCliente[] info;

        public Cliente(int dni, string nombreCompleto, int nroCelular, InformacionCliente[] info)
        {
            this.dni = dni;
            this.nombreCompleto = nombreCompleto;
            this.nroCelular = nroCelular;
            this.info = info;
        }

        /// <summary> Obtiene el nombre del cliente </summary>
        public string GetNombre()
        {
            return nombreCompleto;
        }

        public void SetNombre(string nombre)
        {
            this.nombreCompleto = nombre;
        }

        /// <summary> Valida que el dato sea el correcto </summary>
        /// <param name="validacion"> Numero de orden de la validacion </param>
        /// <param name="dato"> Informacion a comprobar </param>
        public bool ValidarDato(int validacion, string dato)
        {
            bool resultado = false;
            for (int i = 0; i < info.Length; i++)
            {
                if (info[i].TieneValidacion(validacion))
                    resultado = info[i].EsDatoCorrecto(dato);
            }
           
            return resultado;
        }

        public bool esCliente(Cliente cliente)
        {
            return cliente == this;
        }

        public int GetDni()
        {
            return dni;
        }

        public void SetDni(int dni)
        {
            this.dni = dni;
        }

        public int GetNroCelular()
        {
            return nroCelular;
        }

        public void SetNroCelular(int nro)
        {
            this.nroCelular = nro;
        }

        public InformacionCliente[] GetInfo()
        {
            return info;
        }

        public void SetInfo(InformacionCliente[] info)
        {
            this.info = info;
        }
    }
}
