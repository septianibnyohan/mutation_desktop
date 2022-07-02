using MutationChecker.Model.Context;
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


namespace MutationChecker
{
    public partial class FrmLoading : Form
    {
        public FrmLoading()
        {
            InitializeComponent();

            //pbrLoading.Maximum = 100;
            //pbrLoading.Step = 1;
            //pbrLoading.Value = 0;
            //bwrLoading.RunWorkerAsync();

            bwrLoading.WorkerReportsProgress = true;
            bwrLoading.RunWorkerAsync();
        }

        private void Calculate(int i)
        {
            double pow = Math.Pow(i, i);
        }

        private void bwrLoading_DoWork(object sender, DoWorkEventArgs e)
        {
            //for (int i = 1; i <= 100; i++)
            //{
            //    // Wait 50 milliseconds.  
            //    Thread.Sleep(50);
            //    // Report progress.  
            //    bwrLoading.ReportProgress(i);
            //}

            // Get Token
            var token = GeneralSetting.GetToken();

            // show form verification

        }

        private void bwrLoading_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbrLoading.Value = e.ProgressPercentage;
        }
    }
}
