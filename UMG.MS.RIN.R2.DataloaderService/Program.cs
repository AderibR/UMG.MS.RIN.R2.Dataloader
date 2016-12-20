using System.ServiceProcess;

namespace UMG.MS.RIN.R2.DataloaderService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new RinR2DataLoaderService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
