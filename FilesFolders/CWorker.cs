using System.ComponentModel;

namespace FilesFolders
{
    // Clase que inicializa el Objeto BackgrounWorker
    class CWorker
    {
        protected BackgroundWorker OWorker { get; set; }

        public CWorker()
        {
            OWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
        }
    }
}
