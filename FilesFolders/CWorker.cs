using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
