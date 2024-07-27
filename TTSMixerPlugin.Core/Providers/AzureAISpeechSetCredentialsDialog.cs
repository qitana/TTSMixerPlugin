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

namespace Qitana.TTSMixerPlugin.Providers
{
    public partial class AzureAISpeechSetCredentialsDialog : Form
    {
        public string AISpeechKEy { get; private set; }
        public string AISpeechRegion { get; private set; }

        public AzureAISpeechSetCredentialsDialog()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.AISpeechKEy = textBoxKey.Text;
            this.AISpeechRegion = textBoxRegeion.Text;

            DialogResult = DialogResult.OK;
        }

        private async void CheckCredential()
        {
            if (string.IsNullOrWhiteSpace(textBoxKey.Text) || string.IsNullOrWhiteSpace(textBoxRegeion.Text))
            {
                labelCredentialsStatus.Text = "Please enter both key and region";
            }

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://{textBoxRegeion.Text}.tts.speech.microsoft.com/cognitiveservices/voices/list"),
                Headers = {
                    { "Ocp-Apim-Subscription-Key", textBoxKey.Text }
                }
            };
            var response = await AzureAISpeech.httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                labelCredentialsStatus.Text = $"Failed: {response.ReasonPhrase}";
            }
            else
            {
                labelCredentialsStatus.Text = "Credentials are valid";
            }

        }

        private void buttonCheckCredentials_Click(object sender, EventArgs e)
        {
            CheckCredential();
        }
    }
}
