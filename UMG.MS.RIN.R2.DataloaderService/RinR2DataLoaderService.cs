using System.ServiceProcess;

namespace UMG.MS.RIN.R2.DataloaderService
{
    public partial class RinR2DataLoaderService : ServiceBase
    {
        private readonly ServiceHelper _serviceHelper;
        public RinR2DataLoaderService()
        {
            InitializeComponent();
            _serviceHelper = new ServiceHelper();
        }

        protected override void OnStart(string[] args)
        {
            _serviceHelper.OnStart(args);
        }

        protected override void OnStop()
        {
            _serviceHelper.OnStop();
        }
    }
}
