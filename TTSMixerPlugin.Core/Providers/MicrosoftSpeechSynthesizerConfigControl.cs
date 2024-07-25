using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qitana.TTSMixerPlugin.Providers
{
    public partial class MicrosoftSpeechSynthesizerConfigControl : UserControl
    {
        private MicrosoftSpeechSynthesizer _channel;
        private MicrosoftSpeechSynthesizerConfig _config;

        public MicrosoftSpeechSynthesizerConfigControl(TinyIoCContainer container, MicrosoftSpeechSynthesizer profile)
        {
            InitializeComponent();
            _channel = profile;
            _config = profile.Config;

            string[] voices = profile.GetInstalledVoices().ToArray();
            comboBoxVoiceName.Items.Clear();
            comboBoxVoiceName.Items.AddRange(voices);

            if (voices.Contains(_config.Voice)) {
                comboBoxVoiceName.SelectedItem = _config.Voice;
            } else {
                comboBoxVoiceName.SelectedIndex = -1;
            }

            trackBarVolume.Value = _config.Volume;
            labelVolumeValue.Text = _config.Volume.ToString();
            trackBarRate.Value = _config.Rate;
            labelRateValue.Text = _config.Rate.ToString();

            comboBoxVoiceName.SelectedIndexChanged += comboBoxVoiceName_SelectedIndexChanged;
            trackBarVolume.ValueChanged += trackBarVolume_ValueChanged;
            trackBarRate.ValueChanged += trackBarRate_ValueChanged;

        }

        private void comboBoxVoiceName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxVoiceName.SelectedIndex == -1)
            {
                _config.Voice = null;
            }
            else
            {
                _config.Voice = comboBoxVoiceName.SelectedItem.ToString();
            }
        }

        private void trackBarVolume_ValueChanged(object sender, EventArgs e)
        {
            _config.Volume = trackBarVolume.Value;
            labelVolumeValue.Text = trackBarVolume.Value.ToString();
        }

        private void trackBarRate_ValueChanged(object sender, EventArgs e)
        {
            _config.Rate = trackBarRate.Value;
            labelRateValue.Text = trackBarRate.Value.ToString();
        }
    }
}
