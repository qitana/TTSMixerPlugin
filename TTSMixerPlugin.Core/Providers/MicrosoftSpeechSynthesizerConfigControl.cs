﻿using System;
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
        private MicrosoftSpeechSynthesizer profile;
        private MicrosoftSpeechSynthesizerConfig config;

        public MicrosoftSpeechSynthesizerConfigControl(TinyIoCContainer container, MicrosoftSpeechSynthesizer profile)
        {
            InitializeComponent();
            this.profile = profile;
            config = profile.Config;

            string[] voices = profile.GetInstalledVoices().ToArray();
            comboBoxVoiceName.Items.Clear();
            comboBoxVoiceName.Items.AddRange(voices);

            if (voices.Contains(config.Voice)) {
                comboBoxVoiceName.SelectedItem = config.Voice;
            } else {
                comboBoxVoiceName.SelectedIndex = -1;
            }

            trackBarVolume.Value = config.Volume;
            labelVolumeValue.Text = config.Volume.ToString();
            trackBarRate.Value = config.Rate;
            labelRateValue.Text = config.Rate.ToString();

            comboBoxVoiceName.SelectedIndexChanged += comboBoxVoiceName_SelectedIndexChanged;
            trackBarVolume.ValueChanged += trackBarVolume_ValueChanged;
            trackBarRate.ValueChanged += trackBarRate_ValueChanged;

        }

        private void comboBoxVoiceName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxVoiceName.SelectedIndex == -1)
            {
                config.Voice = null;
            }
            else
            {
                config.Voice = comboBoxVoiceName.SelectedItem.ToString();
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
            labelRateValue.Text = trackBarRate.Value.ToString();
        }
    }
}
