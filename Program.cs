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
            Llamada llamada = new Llamada(SubopcionesDao.Instancia().GetSubopciones(0)[1], null, new List<CambioEstado>(), new Cliente(42678364, "Ramon Ramirez", 35178989, new InformacionCliente[0]));
            GestorRtaOperador gestor = new GestorRtaOperador();

            //Inicia el CU: 17
            gestor.OpOperador(llamada);
            //Application.Run(new Form1());
        }
    }
}