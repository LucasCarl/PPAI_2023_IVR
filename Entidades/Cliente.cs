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

        public int GetDni()
        {
            return dni;
        }

        public void SetDni(int dni)
        {
            this.dni = dni;
        }

        public string GetNombre()
        {
            return nombreCompleto;
        }

        public void SetNombre(string nombre)
        {
            this.nombreCompleto = nombre;
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

        public bool esCliente()
        {
            return true;
        }
    }
}
