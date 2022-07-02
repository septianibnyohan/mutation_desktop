using MutationChecker.Model.DTO.API;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MutationChecker
{
    public partial class FormVerify : Form
    {

        public FormVerify()
        {
            InitializeComponent();
        }

        private async void btnVerify_Click(object sender, EventArgs e)
        {
            var token = tbxToken.Text;

            string contents = "";

            var handler = new HttpClientHandler();
            handler.UseCookies = false;
            using (var httpClient = new HttpClient(handler))
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://app.mooba.id/api/user_info"))
                {
                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {token}");
                    request.Headers.TryAddWithoutValidation("Cookie", "ci_session=90ugaogjqdbfl3pts09dcq5leu81v7ui");

                    var response = await httpClient.SendAsync(request);
                    contents = await response.Content.ReadAsStringAsync();
                }
            }

            var user_info = JsonConvert.DeserializeObject<UserInfoResp>(contents);

            if (!user_info.status)
            {
                MessageBox.Show("Token tidak valid/expired", user_info.msg);
            }
            else
            {
                this.Hide();
                var frmTransaction = new FormTransaction();
                frmTransaction.Closed += (s, args) => this.Close();
                frmTransaction.Show();
            }

        }

        private void FormVerify_FormClosed(object sender, FormClosedEventArgs e)
        {
            //_frm.Close();
            Environment.Exit(1);
        }
    }
}
