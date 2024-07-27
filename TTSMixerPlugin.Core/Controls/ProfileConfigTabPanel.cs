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
    public partial class ProfileConfigTabPanel : UserControl
    {
        private readonly TinyIoCContainer _container;
        private IProfile _profile;
        private Control _control;
        private List<IAudioController> _audioControllers;

        public ProfileConfigTabPanel(TinyIoCContainer container, IProfile profile, Control control)
        {
            _container = container;
            _profile = profile;
            _control = control;
            _audioControllers = container.Resolve<List<IAudioController>>();

            InitializeComponent();

            InitializeTextToSpeechTab();
            InitializeAudioDevicesTab();
        }

        private void InitializeTextToSpeechTab()
        {
            tabPageTextToSpeechSettings.Controls.Add(_control);

        }

        private void InitializeAudioDevicesTab()
        {
            var pluginConfig = _container.Resolve<PluginConfig>();
            var audioDevceConfigurations = _profile.Config.AudioDevices;

            // Add missing audio device configurations
            var isAdded = AddMissingConfigs(_audioControllers, audioDevceConfigurations);
            if (isAdded)
            {
                pluginConfig.MarkDirty();
            }

            foreach (var audioConfig in audioDevceConfigurations)
            {
                flowLayoutPanelAudioDevices.Controls.Add(new AudioDeviceConfigPanel(_container, audioConfig));
            }
        }

        private bool AddMissingConfigs(List<IAudioController> controllers, List<IAudioDeviceConfig> config)
        {
            HashSet<string> configIDs = new HashSet<string>(config.Select(c => c.ID));
            bool isAdded = false;
            foreach (var controller in controllers)
            {
                if (!configIDs.Contains(controller.ID))
                {
                    config.Add(new AudioDeviceConfig
                    {
                        ID = controller.ID,
                        FriendlyName = controller.FriendlyName,
                        Enabled = false,
                        Volume = 1.0f,
                        PlaybackMode = PlaybackMode.Enqueue
                    });
                    isAdded = true;
                }
            }

            return isAdded;
        }

        private void buttonRunTest_Click(object sender, EventArgs e)
        {
            _profile.PlayText(textBoxTestText.Text);
        }
    }
}
