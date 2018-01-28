using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesFolders
{
    class CWorker
    {
        public BackgroundWorker OWorker { get; set; }

        public CWorker()
        {
            OWorker = new BackgroundWorker();
            OWorker.WorkerReportsProgress = true;
            OWorker.WorkerSupportsCancellation = true;
        }
    }
}
