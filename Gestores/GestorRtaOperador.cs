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

        public GestorRtaOperador()
        {
            listaCategorias = CategoriasDao.Instancia().ObtenerTodasCategorias();
            pantalla = new PantallaRtaOperador(this);
        }

        public void OpOperador(Llamada llamada)
        {
            llamadaEnCurso = llamada;

            //Marcar en curso a la llamada
            MarcarEnCurso();

            //Mostrar los datos de la llamada
            MostrarDatosLlamada();

            //Muestra la pantalla
            HabilitarPantalla();
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

            llamadaEnCurso.EnCurso(enCurso);
        }

        private void MostrarDatosLlamada()
        {
            string[] respuesta = new string[4];     //0:cliente - 1:Categoria - 2:Opcion - 3:Subopcion
            //Obtiene el nombre del cliente
            respuesta[0] = llamadaEnCurso.GetNombreCliente();

            if (llamadaEnCurso.TieneSubopcion())
            {
                //Si la llamada tiene subopcion
                for (int cat = 0; cat < listaCategorias.Length; cat++)
                {
                    OpcionLlamada[] listaOpciones = listaCategorias[cat].GetOpciones();
                    for (int op = 0; op < listaOpciones.Length; op++)
                    {
                        if (listaOpciones[op].ContieneSubopcion(llamadaEnCurso.GetSubOpcion()))
                        {
                            respuesta[1] = listaCategorias[cat].MostarCategoria();
                            respuesta[2] = listaOpciones[op].MostarOpcion();
                            respuesta[3] = llamadaEnCurso.GetSubOpcion().MostarSubopcion();
                        }
                    }
                }
            }
            else
            {
                //Si la llamada no tiene subopcion
                for (int cat = 0; cat < listaCategorias.Length; cat++)
                {
                    if (listaCategorias[cat].ContieneOpcion(llamadaEnCurso.GetOpcion()))
                    {
                        respuesta[1] = listaCategorias[cat].MostarCategoria();
                        respuesta[2] = llamadaEnCurso.GetOpcion().MostarOpcion();
                        respuesta[3] = "---";
                    }
                }
            }

            pantalla.PasarDatosLlamada(respuesta);
        }

        private void HabilitarPantalla()
        {
            //Crea la ventana
            Application.Run(pantalla);
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
                listaValidacionesLlamada = llamadaEnCurso.GetSubOpcion().GetValidaciones();
            }
            else
            {
                listaValidacionesLlamada = llamadaEnCurso.GetOpcion().GetValidaciones();
            }

            int validacionesCorrectas = 0;
            for (int i = 0; i < listaValidacionesLlamada.Length; i++)
            {
                //Primero busca de que tipo es para mandar dato de validacion
                TipoInformacion tipoInfo = listaValidacionesLlamada[i].GetTipoInfo();
                string tipoDescr = tipoInfo.GetDescripcion();
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
                bool resultado = llamadaEnCurso.ValidarDatoCliente(tipoInfo, dato);

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
                pantalla.TomarDescripcion();
            }
        }
    }
}
