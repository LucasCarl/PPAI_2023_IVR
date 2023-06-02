using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI_IVR_2023.Entidades;
using PPAI_IVR_2023.DataAccessObjects;
using PPAI_IVR_2023.Presentacion;

namespace PPAI_IVR_2023.Gestores
{
    public class GestorRtaOperador
    {
        private Llamada llamadaEnCurso;
        private CategoriaLlamada[] listaCategorias;
        private PantallaRtaOperador pantalla;
        private int[] listaValidaciones;
        private int validacionesBuenas = 0;
        private string descripcion;
        private GestorAcciones gestorAcciones;
        private Accion[] listaAcciones;
        private int indexAccion;

        public GestorRtaOperador()
        {
            listaCategorias = CategoriasDao.Instancia().ObtenerTodasCategorias();
            pantalla = new PantallaRtaOperador(this);
            gestorAcciones = new GestorAcciones();
            listaAcciones = AccionesDao.Instancia().GetAcciones();
        }

        public void OpOperador(Cliente cliente)
        {
            //Identifica la llamada del cliente
            IdentificarLlamada(cliente);

            //Marcar en curso a la llamada
            MarcarEnCurso();

            //Mostrar los datos de la llamada
            BuscarDatosLlamada();

            //Busca las validaciones de la subopcion
            listaValidaciones = BuscarValidaciones();

            //Valida cada una de las validaciones encontradas
            ValidarDatos();
        }

        private void IdentificarLlamada(Cliente cliente)
        {
            //Busca el estado iniciada
            Estado[] estados = EstadosDao.Instancia().GetEstados();
            Estado iniciada = null;
            foreach (Estado est in estados)
            {
                if (est.EsIniciada())
                {
                    iniciada = est;
                    break;
                }
            }

            //Busca la llamada que sea del cliente y que este iniciada
            Llamada[] listaLlamadas = LlamadasDao.Instancia().GetLlamadas();
            foreach (Llamada llamada in listaLlamadas)
            {
                if (llamada.EsDeCliente(cliente) && llamada.EstaIniciada(iniciada))
                {
                    llamadaEnCurso = llamada;
                    break;
                }
            }
        }

        private void MarcarEnCurso()
        {
            Estado[] estados = EstadosDao.Instancia().GetEstados();
            Estado enCurso = null;
            foreach (Estado est in estados)
            {
                if (est.EsEnCurso())
                {
                    enCurso = est;
                    break;
                }
            }

            DateTime fechaHoraActual = GetFechaHoraActual();
            llamadaEnCurso.MarcarEnCurso(enCurso, fechaHoraActual);
        }

        private DateTime GetFechaHoraActual()
        {
            return DateTime.Now;
        }

        private void BuscarDatosLlamada()
        {
            //Obtiene el nombre del cliente
            string nombreCliente = llamadaEnCurso.ObtenerNombreCliente();

            //Dependiendo de si la llamada tiene subopcion o solo opcion se pide los datos necesarios
            string[] datosOpciones = new string[3];
            if(llamadaEnCurso.TieneSubopcion())
            {
                SubOpcionLlamada subOpcion = llamadaEnCurso.GetSubOpcionSeleccionada();
                for (int i = 0; i < listaCategorias.Length; i++)
                {
                    int[] ops = listaCategorias[i].ContieneSubOpcion(subOpcion);
                    if (ops.Length > 1)
                    {
                        datosOpciones = listaCategorias[i].ObtenerNombresCategoriaOpcionSubOpcion(ops[0], ops[1]);
                        break;
                    }
                }
            }
            else
            {
                OpcionLlamada opcion = llamadaEnCurso.GetOpcionSeleccionada();
                for (int i = 0; i < listaCategorias.Length; i++)
                {
                    int op = listaCategorias[i].ContieneOpcion(opcion);
                    if(op != -1)
                    {
                        datosOpciones = listaCategorias[i].ObtenerNombresCategoriaOpcion(op);
                        break;
                    }
                }
            }

            pantalla.HabilitarPantalla();
            pantalla.MostrarDatosLlamada(nombreCliente, datosOpciones);
        }

        public int[] BuscarValidaciones()
        {
            return llamadaEnCurso.ObtenerValidaciones();
        }

        public void ValidarDatos()
        {
            pantalla.MostrarValidacion(listaValidaciones[validacionesBuenas]);
            pantalla.SolicitarValidacion(listaValidaciones[validacionesBuenas]);
        }

        public void ControlarValidacion(int validacion, string dato)
        {
            //Controla si el dato ingresado es correcto o no
            bool control = llamadaEnCurso.ValidarDato(validacion, dato);
            if (control)
            {
                pantalla.ValidacionBuena(validacion);
                validacionesBuenas++;
            }
            else
            {
                pantalla.ErrorValidacion();
            }

            //Controla que la cantidad de validaciones buenas sean las necesarias
            if(validacionesBuenas == listaValidaciones.Length)
            {
                BuscarAcciones();
            }
            else
            {
                ValidarDatos();
            }
        }

        public void BuscarAcciones()
        {
            string[] nombresAcciones = new string[listaAcciones.Length];
            for (int i = 0; i < listaAcciones.Length; i++)
            {
                nombresAcciones[i] = listaAcciones[i].GetNombre();
            }

            pantalla.MostrarAcciones(nombresAcciones);
            pantalla.SolicitarAccion();
        }

        public void TomarAccion(int accion, string descr)
        {
            indexAccion = accion;
            descripcion = descr;
            pantalla.SolicitarConfirmacion();
        }

        public void TomarConfirmacion(bool confirmacion)
        {
            if (confirmacion)
            {
                llamadaEnCurso.SetDescripcionOperador(descripcion);
                //Envia accion al Gestor Acciones para hacer el CU26
                Accion accionLlamada = listaAcciones[indexAccion];
                gestorAcciones.RegistarAccion(accionLlamada);

                //Finaliza la llamada
                FinalizarLlamada();
            }
        }

        private void FinalizarLlamada()
        {
            //Marca la llamada como finalizada
            Estado[] estados = EstadosDao.Instancia().GetEstados();
            Estado finalizada = null;
            foreach (Estado est in estados)
            {
                if (est.EsEnCurso())
                {
                    finalizada = est;
                    break;
                }
            }

            //Marca la llamada como finalizada
            DateTime fechaHoraActual = GetFechaHoraActual();
            llamadaEnCurso.MarcarFinalizar(finalizada, fechaHoraActual);
            //Calcula la duracion de la llamada
            llamadaEnCurso.CalcularDuracion();
            //Registrar llamada en BD

            //Avisa a operador que se termino el registro
            pantalla.AvisoFinRegistro();

            FinDeCU();
        }

        private void FinDeCU()
        {
            Application.Exit();
        }
    }
}
