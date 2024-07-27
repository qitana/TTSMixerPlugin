using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qitana.TTSMixerPlugin
{
    public partial class AudioDeviceConfigPanel : UserControl
    {
        IAudioDeviceConfig _config;
        PluginConfig _pluginConfig;

        public AudioDeviceConfigPanel(TinyIoCContainer container, IAudioDeviceConfig config)
        {
            InitializeComponent();
            _config = config;
            _pluginConfig = container.Resolve<PluginConfig>();

            InitializeComponentsFromConfig();
            AddEventHandlers();
        }

        private void InitializeComponentsFromConfig()
        {
            // Initialize the audio device configuration control
            groupBox1.Text = _config.FriendlyName;
            checkBoxEnabled.Checked = _config.Enabled;
            this.trackBarVolume.Value = (int)(_config.Volume * 100);
            this.labelVolumeValue.Text = this.trackBarVolume.Value.ToString();

            // set radio button for playback mode
            switch (_config.PlaybackMode)
            {
                case PlaybackMode.Enqueue:
                    radioButtonPlaybackEnqueue.Checked = true;
                    break;
                case PlaybackMode.EnqueuePriority:
                    radioButtonPlaybackEnqueuePriority.Checked = true;
                    break;
                case PlaybackMode.PlayImmediately:
                    radioButtonPlaybackImmediately.Checked = true;
                    break;
            }
        }

        private void AddEventHandlers()
        {
            checkBoxEnabled.CheckedChanged += checkBoxEnabled_CheckedChanged;
            trackBarVolume.ValueChanged += trackBarVolume_ValueChanged;
            radioButtonPlaybackEnqueue.CheckedChanged += radioButtonPlaybackEnqueue_CheckedChanged;
            radioButtonPlaybackEnqueuePriority.CheckedChanged += radioButtonPlaybackEnqueuePriority_CheckedChanged;
            radioButtonPlaybackImmediately.CheckedChanged += radioButtonPlaybackImmediately_CheckedChanged;
        }

        private void checkBoxEnabled_CheckedChanged(object sender, EventArgs e)
        {
            _config.Enabled = checkBoxEnabled.Checked;
            _pluginConfig.MarkDirty();
        }

        private void trackBarVolume_ValueChanged(object sender, EventArgs e)
        {
            _config.Volume = (float)this.trackBarVolume.Value / 100;
            this.labelVolumeValue.Text = this.trackBarVolume.Value.ToString();
            _pluginConfig.MarkDirty();
        }

        private void radioButtonPlaybackEnqueue_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPlaybackEnqueue.Checked)
            {
                _config.PlaybackMode = PlaybackMode.Enqueue;
                _pluginConfig.MarkDirty();
            }
        }

        private void radioButtonPlaybackEnqueuePriority_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPlaybackEnqueuePriority.Checked)
            {
                _config.PlaybackMode = PlaybackMode.EnqueuePriority;
                _pluginConfig.MarkDirty();
            }
        }

        private void radioButtonPlaybackImmediately_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonPlaybackImmediately.Checked)
            {
                _config.PlaybackMode = PlaybackMode.PlayImmediately;
                _pluginConfig.MarkDirty();
            }
        }


    }
}
