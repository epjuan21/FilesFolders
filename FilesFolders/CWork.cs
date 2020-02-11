using System.ComponentModel;

namespace FilesFolders
{
    // Hereda de CWorker
    class CWork : CWorker
    {
        public object ODoWorkerbgwNuevaEPS_DoWork { get; internal set; }

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
