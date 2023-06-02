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
        private string descripcion;
        private GestorAcciones gestorAcciones;
        private Accion[] listaAcciones;
        private int indexAccion;

        public GestorRtaOperador()
        {
            listaCategorias = CategoriasDao.Instancia().ObtenerTodasCategorias();
            pantalla = new PantallaRtaOperador(this);
            gestorAcciones = new GestorAcciones();
        }

        public void OpOperador(Cliente cliente)
        {
            //Identifica la llamada del cliente
            IdentificarLlamada(cliente);

            //Marcar en curso a la llamada
            MarcarEnCurso();

            //Mostrar los datos de la llamada
            BuscarDatosLlamada();

            //Muestra la pantalla
            HabilitarPantalla();
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
                    }
                }
            }

            pantalla.HabilitarPantalla();
            pantalla.MostrarDatosLlamada(nombreCliente, datosOpciones);
        }

        /// <summary>
        /// Controla las validaciones de la subopcion / opcion elegida de la llamada
        /// </summary>
        /// <param name="fechaNacimiento">Respuesta a la validacion de tipo Fecha Nacimiento</param>
        /// <param name="hijos">Respuesta a la validacion de tipo Cantidad de Hijos</param>
        /// <param name="codigoPostal">Respuesta a la validacion de tipo Codigo Postal</param>
        public void ControlarValidaciones(string fechaNacimiento, string hijos, string codigoPostal)
        {
            Validacion[] listaValidacionesLlamada;
            //Si la llamada tiene subopcion se consultan las validaciones de la subopcion, sino se pregunta a la opcion elegida
            if (llamadaEnCurso.TieneSubopcion())
            {
                listaValidacionesLlamada = llamadaEnCurso.GetSubOpcionSeleccionada().GetValidaciones();
            }
            else
            {
                listaValidacionesLlamada = llamadaEnCurso.GetOpcionSeleccionada().GetValidaciones();
            }

            int validacionesCorrectas = 0;
            for (int i = 0; i < listaValidacionesLlamada.Length; i++)
            {
                //Primero busca de que tipo es para mandar dato de validacion
                //TipoInformacion tipoInfo = listaValidacionesLlamada[i].GetTipoInfo();
                //string tipoDescr = tipoInfo.GetDescripcion();
                string dato = "";
                switch (tipoDescr)
                {
                    case "Fecha de Nacimiento":
                        dato = fechaNacimiento;
                        break;

                    case "Numero de Hijos":
                        dato = hijos;
                        break;

                    case "Codigo Postal":
                        dato = codigoPostal;
                        break;
                }

                //Le dice a llamada que valide el dato
                bool resultado = llamadaEnCurso.ValidarDato(tipoInfo, dato);

                if (resultado)
                {
                    //Si la validacion es positiva, se suma el contador
                    validacionesCorrectas++;
                }
                else
                {
                    //Si la validacion es negativa, se avisa al operador y corta el ciclo
                    pantalla.ErrorValidacion();
                    break;
                }
            }

            //Comprueba que todas las validaciones sean correctas
            if(validacionesCorrectas == listaValidacionesLlamada.Length)
            {
                listaAcciones = AccionesDao.Instancia().GetAcciones();
                string[] nombreAcciones = new string[listaAcciones.Length + 1];
                nombreAcciones[0] = "--------";
                for (int i = 0; i < listaAcciones.Length; i++)
                {
                    nombreAcciones[i] = listaAcciones[i + 1].GetNombre();
                }
                pantalla.MostrarAccion(nombreAcciones);
            }
        }

        public int[] BuscarValidaciones()
        {
            return llamadaEnCurso.ObtenerValidaciones();
        }

        public void ValidarDato(string dato, int nroValidacion)
        {

        }

        public void ControlarValidacion()
        {

        }

        public string[] BuscarAcciones()
        {
            return new string[3];
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
                Accion accionLlamada;
                if (indexAccion == 0)
                    accionLlamada = null;
                else
                    accionLlamada = listaAcciones[indexAccion - 1];
                gestorAcciones.RegistarAccion(accionLlamada);

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
        }
    }
}
