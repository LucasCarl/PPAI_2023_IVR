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
    internal class GestorRtaOperador
    {
        private Llamada llamadaEnCurso;
        private CategoriaLlamada[] listaCategorias;
        private PantallaRtaOperador pantalla;

        public GestorRtaOperador()
        {
            listaCategorias = CategoriasDao.Instancia().ObtenerTodasCategorias();
            pantalla = new PantallaRtaOperador();
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
    }
}
