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
            // Identifica la llamada del cliente
            IdentificarLlamada(cliente);

            // Marcar en curso a la llamada
            MarcarEnCurso();

            // Mostrar los datos de la llamada
            BuscarDatosLlamada();

            // Busca las validaciones de la subopcion
            listaValidaciones = BuscarValidaciones();

            // Valida cada una de las validaciones encontradas
            ValidarDatos();
        }

        /// <summary> Identifica la llamada que esta iniciada y es de un cliente especifico </summary>
        /// <param name="cliente"> Cliente al que pertenece la llamada </param>
        private void IdentificarLlamada(Cliente cliente)
        {
            // Busca el estado iniciada
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

            // Busca la llamada que sea del cliente y que este iniciada
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

        /// <summary> Marca "En curso" a la llamada en curso </summary>
        private void MarcarEnCurso()
        {
            // Busca el estado "En curso"
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

            // Busca la fechaHora actual
            DateTime fechaHoraActual = GetFechaHoraActual();
            // Le dice a la llamada que se marque en curso
            llamadaEnCurso.MarcarEnCurso(enCurso, fechaHoraActual);
        }

        /// <summary> Obtiene la fechaHora actual </summary>
        private DateTime GetFechaHoraActual()
        {
            return DateTime.Now;
        }

        /// <summary> Busca los datos de la llamada en curso y los muestra en pantalla </summary>
        private void BuscarDatosLlamada()
        {
            //Obtiene el nombre del cliente
            string nombreCliente = llamadaEnCurso.ObtenerNombreCliente();

            //Dependiendo de si la llamada tiene subopcion o solo opcion se piden los datos necesarios
            string[] datosOpciones = new string[3];
            if(llamadaEnCurso.TieneSubopcion())
            {
                // Si tiene subopcion
                SubOpcionLlamada subOpcion = llamadaEnCurso.GetSubOpcionSeleccionada();
                for (int i = 0; i < listaCategorias.Length; i++)
                {
                    // Pregunta a la categoria si tiene alguna de sus opciones contiene la subopcion
                    int[] ops = listaCategorias[i].ContieneSubOpcion(subOpcion);    // 0: opcion - 1: subopcion
                    if (ops.Length > 1)
                    {
                        datosOpciones = listaCategorias[i].ObtenerNombresCategoriaOpcionSubOpcion(ops[0], ops[1]);
                        break;
                    }
                }
            }
            else
            {
                // Si tiene opcion
                OpcionLlamada opcion = llamadaEnCurso.GetOpcionSeleccionada();
                for (int i = 0; i < listaCategorias.Length; i++)
                {
                    // Pregunta a la categoria si contiene la opcion
                    int op = listaCategorias[i].ContieneOpcion(opcion);
                    if(op != -1)
                    {
                        datosOpciones = listaCategorias[i].ObtenerNombresCategoriaOpcion(op);
                        break;
                    }
                }
            }

            // Habilita la pantalla y muestra las opciones
            pantalla.HabilitarPantalla();
            pantalla.MostrarDatosLlamada(nombreCliente, datosOpciones);
        }

        /// <summary> Busca las validaciones necesarias para la llamada en curso </summary>
        /// <returns> Vector con los numero de orden de las validaciones </returns>
        public int[] BuscarValidaciones()
        {
            return llamadaEnCurso.ObtenerValidaciones();
        }

        /// <summary> Pide validar los datos de la siguiente validacion sin validar </summary>
        public void ValidarDatos()
        {
            pantalla.MostrarValidacion(listaValidaciones[validacionesBuenas]);
            pantalla.SolicitarValidacion(listaValidaciones[validacionesBuenas]);
        }

        /// <summary> Controla que el dato ingresado en la validacion sea el correcto </summary>
        /// <param name="validacion"> Numero de orden de la validacion evaluada </param>
        /// <param name="dato"> Dato a controlar que sea correcto </param>
        public void ControlarValidacion(int validacion, string dato)
        {
            // Controla si el dato ingresado es correcto o no
            bool control = llamadaEnCurso.ValidarDato(validacion, dato);
            if (control)
            {
                // Si es correcto, avisa a la pantalla y incrementa la cantidad de validaciones buenas
                pantalla.ValidacionBuena(validacion);
                validacionesBuenas++;
            }
            else
            {
                // Si no es correcto, avisa a la pantalla
                pantalla.ErrorValidacion();
            }

            //Controla que la cantidad de validaciones buenas sean las necesarias
            if(validacionesBuenas == listaValidaciones.Length)
            {
                // Si estan todas, busca las acciones
                BuscarAcciones();
            }
            else
            {
                // Si faltan, vuelve a pedir la validacion
                ValidarDatos();
            }
        }

        /// <summary> Busca las acciones que se pueden realizar a la llamada </summary>
        public void BuscarAcciones()
        {
            // Busca los nombres de las acciones
            string[] nombresAcciones = new string[listaAcciones.Length];
            for (int i = 0; i < listaAcciones.Length; i++)
            {
                nombresAcciones[i] = listaAcciones[i].GetNombre();
            }

            // Las muestra en pantalla
            pantalla.MostrarAcciones(nombresAcciones);
            pantalla.SolicitarAccion();
        }

        /// <summary> Recibe la accion seleccionada y la descripcion del operador al respecto </summary>
        /// <param name="accion"> Indice de la accion </param>
        /// <param name="descr"> Descripcion del operador respecto de la accion </param>
        public void TomarAccion(int accion, string descr)
        {
            indexAccion = accion;
            descripcion = descr;
            pantalla.SolicitarConfirmacion();
        }

        /// <summary> Recibe si la confirmacion fue positiva o negativa </summary>
        public void TomarConfirmacion(bool confirmacion)
        {
            // Si la confirmacion es positiva continua, sino no hace nada
            if (confirmacion)
            {
                llamadaEnCurso.SetDescripcionOperador(descripcion);
                // Envia accion al Gestor Acciones para hacer el CU26
                Accion accionLlamada = listaAcciones[indexAccion];
                gestorAcciones.RegistarAccion(accionLlamada);

                // Finaliza la llamada
                FinalizarLlamada();
            }
        }

        /// <summary> Finaliza la llamada, marcandola como "finalizada" y calculando su duracion </summary>
        private void FinalizarLlamada()
        {
            // Busca el estado "finalizada"
            Estado[] estados = EstadosDao.Instancia().GetEstados();
            Estado finalizada = null;
            foreach (Estado est in estados)
            {
                if (est.EsFinalizada())
                {
                    finalizada = est;
                    break;
                }
            }

            // Marca la llamada como finalizada
            DateTime fechaHoraActual = GetFechaHoraActual();
            llamadaEnCurso.MarcarFinalizar(finalizada, fechaHoraActual);

            // Calcula la duracion de la llamada
            llamadaEnCurso.CalcularDuracion();

            // Registrar llamada en BD(futuro)

            // Avisa a operador que se termino el registro
            pantalla.AvisoFinRegistro();

            // Termina el Caso de uso
            FinDeCU();
        }

        private void FinDeCU()
        {
            // Cierra el programa
            Application.Exit();
        }
    }
}
