using MutationChecker.Model.Context;
using MutationChecker.Model.DTO.API;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MutationChecker
{
    public partial class FrmLoading : Form
    {
        public UserInfoResp user_info;

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
            //for (int i = 1; i <= 98; i++)
            //{
            //    // Wait 50 milliseconds.  
            //    Thread.Sleep(50);
            //    // Report progress.  
            //    bwrLoading.ReportProgress(i);
            //}
            var sleep = 1;

            // Get Token
            
            var token = GeneralSetting.GetToken();
            bwrLoading.ReportProgress(8); Thread.Sleep(sleep);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            bwrLoading.ReportProgress(16); Thread.Sleep(sleep);
            var handler = new HttpClientHandler();
            bwrLoading.ReportProgress(24); Thread.Sleep(sleep);
            handler.UseCookies = false;
            bwrLoading.ReportProgress(32); Thread.Sleep(sleep);

            // In production code, don't destroy the HttpClient through using, but better use IHttpClientFactory factory or at least reuse an existing HttpClient instance
            // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests
            // https://www.aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/
            string contents = "";
            bwrLoading.ReportProgress(40); Thread.Sleep(sleep);
            using (var httpClient = new HttpClient(handler))
            {
                bwrLoading.ReportProgress(48); Thread.Sleep(sleep);
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://app.mooba.id/api/user_info"))
                {
                    bwrLoading.ReportProgress(56); Thread.Sleep(sleep);
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {token.GsValue}");
                    bwrLoading.ReportProgress(64); Thread.Sleep(sleep);
                    request.Headers.TryAddWithoutValidation("Cookie", "ci_session=90ugaogjqdbfl3pts09dcq5leu81v7ui");
                    bwrLoading.ReportProgress(72); Thread.Sleep(sleep);

                    var response = httpClient.SendAsync(request).Result;
                    bwrLoading.ReportProgress(80); Thread.Sleep(sleep);
                    contents = response.Content.ReadAsStringAsync().Result;
                    bwrLoading.ReportProgress(88); Thread.Sleep(sleep);
                }
            }

            bwrLoading.ReportProgress(96); Thread.Sleep(sleep);
            this.user_info = JsonConvert.DeserializeObject<UserInfoResp>(contents);
            bwrLoading.ReportProgress(100); Thread.Sleep(sleep);


            // show form verification

        }

        private void bwrLoading_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbrLoading.Value = e.ProgressPercentage;

            if (e.ProgressPercentage == 100)
            {
                if (!user_info.status)
                {
                    this.Hide();
                    var frmVerify = new FormVerify();
                    frmVerify.Closed += (s, args) => this.Close();
                    frmVerify.Show();
                }
                else
                {
                    var frmTransaction = new FormTransaction();
                    frmTransaction.ShowDialog();
                }
            }
        }

        private void FrmLoading_Load(object sender, EventArgs e)
        {
            //for (int i = 1; i <= 100; i++)
            //{
            //    // Wait 50 milliseconds.  
            //    Thread.Sleep(50);
            //    // Report progress.  
            //    //bwrLoading.ReportProgress(i);
            //    pbrLoading.Value = i;
            //}
        }

        private void FrmLoading_Activated(object sender, EventArgs e)
        {
            //for (int i = 1; i <= 100; i++)
            //{
            //    // Wait 50 milliseconds.  
            //    Thread.Sleep(50);
            //    // Report progress.  
            //    //bwrLoading.ReportProgress(i);
            //    pbrLoading.Value = i;
            //}
        }
    }
}
