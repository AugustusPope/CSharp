using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Concurrency
{
  
    class Program
    {
        static System.ComponentModel.BackgroundWorker _bw;
        static void BW_CountToMillion(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            for (int i = 0; i < 1000000; i++)
            {

                if (i>10000 && (i % 10000 == 0))
                {
                    _bw.ReportProgress(i / 10000);
                    System.Threading.Thread.Sleep(100);
                }
            } 
        }

        static void BW_ProgressChanged(object sender,
                               System.ComponentModel.ProgressChangedEventArgs e)
        {
            Console.WriteLine("Reached " + e.ProgressPercentage + "%");
        }

        static void BW_RunWorkerCompleted(object sender,
                                    System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                Console.WriteLine("You canceled!");
            else if (e.Error != null)
                Console.WriteLine("Worker exception: " + e.Error.ToString());
            else
                Console.WriteLine("Complete: " + e.Result);      // from DoWork
        }


        static void Main(string[] args)
        {
            _bw = new System.ComponentModel.BackgroundWorker();
           _bw.WorkerReportsProgress = true;

           _bw.WorkerSupportsCancellation = true;

           _bw.DoWork += BW_CountToMillion;
           _bw.ProgressChanged += BW_ProgressChanged;
           _bw.RunWorkerCompleted += BW_RunWorkerCompleted;

           _bw.RunWorkerAsync();
            //_bw.r


           System.Threading.Thread.Sleep(10000);


        }  
    }
}
