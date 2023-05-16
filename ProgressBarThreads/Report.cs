using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgressBarThreads
{
    
    class Report
    {
       private bool _IsCancelRequested;
       public event ProgressChangedEventHandler Progress_changed;

        private void OnReportProgress_changed(int percent)
        {
            if (Progress_changed!=null)
            {
                Progress_changed(this,new ProgressChangedEventArgs(percent,null));
            }
        }

        public void DoWorkAsync()
        {
            Thread t = new Thread(DoWork);
            t.IsBackground = true;
            t.Start();
        }


        public void DoWork()
        {
           
            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(500);
                if (_IsCancelRequested == true)
                {
                    break;
                }
                OnReportProgress_changed(i);                
            
           }
        }
        public void Cancel()
        {
            
                _IsCancelRequested = true;
            
        }
    }
}
