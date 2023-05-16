using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgressBarThreads
{
    public partial class Form1 : Form
    {
        Report r = new Report();
      
        public Form1()
        {
           
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            r.Progress_changed += r_Progress_changed;
            r.DoWork();
                       
        }

        void r_Progress_changed(object sender, ProgressChangedEventArgs e)
        {
            prgrsBar.Value = e.ProgressPercentage;
        }
        
        private void Cancel_Click(object sender, EventArgs e)
        {
            r.Cancel();
            
        }
    }
}
