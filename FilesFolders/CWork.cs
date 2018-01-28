using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesFolders
{
    class CWork : CWorker
    {
        public void ODoWorker(DoWorkEventHandler DoWork, ProgressChangedEventHandler ProgressChanged, RunWorkerCompletedEventHandler RunWorkerCompleted)
        {

            OWorker.DoWork += new DoWorkEventHandler(DoWork);
            OWorker.ProgressChanged += new ProgressChangedEventHandler(ProgressChanged);
            OWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(RunWorkerCompleted);
            OWorker.RunWorkerAsync();


        }

        public void ReportProgress(int percentProgress)
        {
            OWorker.ReportProgress(percentProgress);
        }
    }
}
