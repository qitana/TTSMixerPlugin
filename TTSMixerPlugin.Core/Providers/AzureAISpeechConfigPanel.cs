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
using Newtonsoft.Json;

namespace Qitana.TTSMixerPlugin.Providers
{
    public partial class AzureAISpeechConfigPanel : UserControl
    {
        private AzureAISpeech profile;
        private AzureAISpeechConfig config;
        private readonly ILogger logger;

        private bool isApiConnected = false;

        public AzureAISpeechConfigPanel(TinyIoCContainer container, AzureAISpeech profile)
        {
            InitializeComponent();
            this.profile = profile;
            config = profile.Config;
            logger = container.Resolve<ILogger>();

            textBoxRegion.Text = config.AzureAISpeechRegion;
            textBoxKey.Text = config.AzureAISpeechResouceKey;
            trackBarVolume.Value = config.Volume;
            labelVolumeValue.Text = config.Volume.ToString();
            trackBarRate.Value = config.Rate;
            labelRateValue.Text = config.Rate.ToString() + "%";
            trackBarPitch.Value = config.Pitch;
            labelPitchValue.Text = config.Pitch.ToString() + "%";

            trackBarVolume.ValueChanged += trackBarVolume_ValueChanged;
            trackBarRate.ValueChanged += trackBarRate_ValueChanged;
            trackBarPitch.ValueChanged += trackBarPitch_ValueChanged;

            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            try
            {
                VoiceInfo[] voices = new VoiceInfo[0];
                try
                {
                    voices = await GetVoices();
                    isApiConnected = true;
                }
                catch (Exception ex)
                {
                    isApiConnected = false;
                }

                profile.Voices = voices;
                comboBoxVoice.Items.Clear();
                comboBoxVoice.Items.AddRange(voices);

                if (voices.Any(v => v.ShortName == config.Voice))
                {
                    comboBoxVoice.SelectedItem = voices.First(v => v.ShortName == config.Voice);
                }
                else
                {
                    logger.Log(LogLevel.Warning, $"Voice {config.Voice} is not found in the list of voices");
                    var configVoice = new VoiceInfo(config.Voice);
                    comboBoxVoice.Items.Add(configVoice);
                    comboBoxVoice.SelectedItem = configVoice;
                }
            }
            catch (Exception ex)
            {
            }

            comboBoxVoice.SelectedIndexChanged += comboBoxVoice_SelectedIndexChanged;


        }


        private async Task<VoiceInfo[]> GetVoices()
        {
            if (String.IsNullOrEmpty(config.AzureAISpeechResouceKey) || String.IsNullOrEmpty(config.AzureAISpeechRegion))
            {
                throw new Exception("AzureAISpeechResouceKey and AzureAISpeechRegion must be set");
            }
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://{config.AzureAISpeechRegion}.tts.speech.microsoft.com/cognitiveservices/voices/list"),
                Headers = {
                    { "Ocp-Apim-Subscription-Key", config.AzureAISpeechResouceKey }
                }
            };
            var response = await AzureAISpeech.httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to get voices: {response.ReasonPhrase}");
            }
            var responseString = await response.Content.ReadAsStringAsync();
            var voices = JsonConvert.DeserializeObject<VoiceInfo[]>(responseString);
            return voices;
        }

        private void comboBoxVoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxVoice.SelectedIndex == -1)
            {
                config.Voice = null;
            }
            else
            {
                config.Voice = ((VoiceInfo)comboBoxVoice.SelectedItem).ShortName;
                logger.Log(LogLevel.Info, $"Selected voice: {config.Voice}");
                logger.Log(LogLevel.Info, $"{String.Join(",", ((VoiceInfo)comboBoxVoice.SelectedItem).StyleList)}");
                logger.Log(LogLevel.Info, $"{String.Join(",", ((VoiceInfo)comboBoxVoice.SelectedItem).RolePlayList)}");

            }
        }

        private void buttonSetCredentials_Click(object sender, EventArgs e)
        {
            var setCredentialsDialog = new AzureAISpeechSetCredentialsDialog();
            if (setCredentialsDialog.ShowDialog(this.ParentForm) == DialogResult.OK)
            {
                textBoxKey.Text = setCredentialsDialog.AISpeechKEy;
                textBoxRegion.Text = setCredentialsDialog.AISpeechRegion;
                config.AzureAISpeechRegion = textBoxRegion.Text;
                config.AzureAISpeechResouceKey = textBoxKey.Text;

                InitializeAsync();
            }
        }

        private void trackBarVolume_ValueChanged(object sender, EventArgs e)
        {
            config.Volume = trackBarVolume.Value;
            labelVolumeValue.Text = trackBarVolume.Value.ToString();
        }

        private void trackBarRate_ValueChanged(object sender, EventArgs e)
        {
            config.Rate = trackBarRate.Value;
            labelRateValue.Text = trackBarRate.Value.ToString() + "%";
        }

        private void trackBarPitch_ValueChanged(object sender, EventArgs e)
        {
            config.Pitch = trackBarPitch.Value;
            labelPitchValue.Text = trackBarPitch.Value.ToString() + "%";
        }
    }

    public class VoiceInfo
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Gender { get; set; }
        public string Locale { get; set; }
        public string LocalName { get; set; }
        public string[] StyleList { get; set; }
        public string[] RolePlayList { get; set; }

        public VoiceInfo(string shortName)
        {
            ShortName = shortName;
            StyleList = new string[0];
            RolePlayList = new string[0];
        }

        public override string ToString()
        {
            return ShortName;
        }
    }
}
