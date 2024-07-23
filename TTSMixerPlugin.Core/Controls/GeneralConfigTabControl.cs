using Advanced_Combat_Tracker;
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
using System.Xml.Serialization;

namespace Qitana.TTSMixerPlugin
{
    public partial class GeneralConfigTabControl : UserControl
    {
        private readonly TinyIoCContainer container;
        private readonly ILogger logger;
        readonly PluginConfig config;
        readonly PluginMain pluginMain;

        private readonly FormActMain.PlayTtsDelegate originaPlayTTSMethod;
        private readonly FormActMain.PlaySoundDelegate originalPlaySoundMethod;


        public GeneralConfigTabControl(TinyIoCContainer container)
        {
            InitializeComponent();
            Dock = DockStyle.Fill;

            this.container = container;
            logger = container.Resolve<ILogger>();
            config = container.Resolve<PluginConfig>();
            pluginMain = container.Resolve<PluginMain>();

            originaPlayTTSMethod = pluginMain.OriginaPlayTTSMethod;
            originalPlaySoundMethod = pluginMain.OriginalPlaySoundMethod;

            cbOverrideOriginalPlayTTS.Checked = config.OverrideOriginalPlayTTS;
            cbOverrideOriginalPlaySound.Checked = config.OverrideOriginalPlaySound;
            RefreshDefaultProfileComboBox();
            CheckEnableDisableComboBoxDefaultProfile();
        }

        public void RefreshDefaultProfileComboBox()
        {
            logger.Log(LogLevel.Debug, "Refreshing combo box");
            comboBoxDefaultProfile.SelectedIndexChanged -= comboBoxDefaultProfile_SelectedIndexChanged;
            comboBoxDefaultProfile.Items.Clear();
            comboBoxDefaultProfile.Items.AddRange(pluginMain.Config.Profiles.Select(p => p.Name).ToArray());
            comboBoxDefaultProfile.SelectedIndexChanged += comboBoxDefaultProfile_SelectedIndexChanged;

            logger.Log(LogLevel.Debug, $"config.DefaultProfile: {config.DefaultProfile}");
            if (!string.IsNullOrEmpty(config.DefaultProfile) && pluginMain.Config.Profiles.Where(p => p.Name == config.DefaultProfile).Any())
            {
                logger.Log(LogLevel.Debug, $"Selecting default profile: {config.DefaultProfile}");
                comboBoxDefaultProfile.SelectedItem = config.DefaultProfile;
            }
        }

        private void cbOverrideOriginalPlayTTS_CheckedChanged(object sender, EventArgs e)
        {
            // check if the value has changed
            logger.Log(LogLevel.Debug, $"Override original PlayTTS: {cbOverrideOriginalPlayTTS.Checked}");
            ActGlobals.oFormActMain.PlayTtsMethod = cbOverrideOriginalPlayTTS.Checked ? pluginMain.PlayText : originaPlayTTSMethod;
            if (cbOverrideOriginalPlayTTS.Checked != config.OverrideOriginalPlayTTS)
            {
                logger.Log(LogLevel.Debug, $"Set config: Override original PlayTTS: {cbOverrideOriginalPlayTTS.Checked}");
                config.OverrideOriginalPlayTTS = cbOverrideOriginalPlayTTS.Checked;
                config.MarkDirty();
            }

            CheckEnableDisableComboBoxDefaultProfile();
        }

        private void cbOverrideOriginalPlaySound_CheckedChanged(object sender, EventArgs e)
        {
            // check if the value has changed
            logger.Log(LogLevel.Debug, $"Override original PlaySound: {cbOverrideOriginalPlaySound.Checked}");
            ActGlobals.oFormActMain.PlaySoundMethod = cbOverrideOriginalPlaySound.Checked ? pluginMain.PlayFile : originalPlaySoundMethod;
            if (cbOverrideOriginalPlaySound.Checked != config.OverrideOriginalPlaySound)
            {
                logger.Log(LogLevel.Debug, $"Set config: Override original PlaySound: {cbOverrideOriginalPlaySound.Checked}");
                config.OverrideOriginalPlaySound = cbOverrideOriginalPlaySound.Checked;
                config.MarkDirty();
            }

            CheckEnableDisableComboBoxDefaultProfile();
        }

        private void comboBoxDefaultProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedProfile = comboBoxDefaultProfile.SelectedItem as string;
            if (selectedProfile != config.DefaultProfile)
            {
                logger.Log(LogLevel.Debug, $"Set config: Default profile: {selectedProfile}");
                config.DefaultProfile = selectedProfile;
                config.MarkDirty();
            }
        }

        private void CheckEnableDisableComboBoxDefaultProfile()
        {
            if (cbOverrideOriginalPlayTTS.Checked || cbOverrideOriginalPlaySound.Checked)
            {
                comboBoxDefaultProfile.Enabled = true;
            }
            else
            {
                comboBoxDefaultProfile.Enabled = false;
            }
        }
    }
}
