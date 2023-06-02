using PPAI_IVR_2023.Entidades;
using PPAI_IVR_2023.DataAccessObjects;
using PPAI_IVR_2023.Gestores;
using PPAI_IVR_2023.Presentacion;

namespace PPAI_IVR_2023
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            //FUERA DEL CU: Crear llamada proveniente
            SubOpcionLlamada subOp = SubopcionesDao.Instancia().GetSubopciones(0)[1];
            Cliente cliente = ClientesDao.Instancia().GetClientes()[0];
            Llamada llamada = new Llamada(subOp, null, new List<CambioEstado>(), cliente);
            GestorRtaOperador gestor = new GestorRtaOperador();

            //Inicia el CU: 17
            gestor.OpOperador(cliente);
        }
    }
}