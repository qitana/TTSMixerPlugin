using Advanced_Combat_Tracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Qitana.TTSMixerPlugin
{
    public abstract class ProfileBase<TConfig> : IProfile where TConfig : ProfileConfigBase
    {
        protected readonly TinyIoCContainer _container;
        protected readonly ILogger _logger;
        protected readonly List<IAudioController> _audioControllers;


        protected ProfileBase(TinyIoCContainer container, TConfig config)
        {
            _container = container;
            _logger = container.Resolve<ILogger>();
            Config = config;
            Name = Config.Name;
            _audioControllers = container.Resolve<List<IAudioController>>();
            OutputAudioDevices = new List<IAudioDeviceConfig>();
        }

        protected ProfileBase(TinyIoCContainer container, string name)
        {
            _container = container;
            Config = (TConfig)Activator.CreateInstance(typeof(TConfig), name);
            Name = Config.Name;
            _audioControllers = container.Resolve<List<IAudioController>>();
            OutputAudioDevices = new List<IAudioDeviceConfig>();
        }

        public string Name { get; set; }

        public abstract string TypeFriendlyName { get; }

        public List<IAudioDeviceConfig> OutputAudioDevices { get; set; }

        public abstract Control CreateConfigControl();

        public TConfig Config { get; private set; }


        IProfileConfig IProfile.Config
        {
            get => Config;
            set => Config = (TConfig)value;
        }

        public abstract string ConvertTextToAudioFile(string text, bool canUseCache = true, bool canSaveToCache = true);

        public virtual void PlayText(string text)
        {
            ActGlobals.oFormActMain.Invoke((Action)(() =>
            {
                var file = ConvertTextToAudioFile(text);
                HashSet<string> controllerIDs = new HashSet<string>(_audioControllers.Select(c => c.ID));
                foreach (var audioConfig in Config.AudioDevices)
                {
                    if (audioConfig.Enabled && controllerIDs.Contains(audioConfig.ID))
                    {
                        var controller = _audioControllers.First(c => c.ID == audioConfig.ID);
                        if (controller == null)
                        {
                            return;
                        }
                        switch (audioConfig.PlaybackMode)
                        {
                            case PlaybackMode.Enqueue:
                                controller.EnqueueAudioFile(file, audioConfig.Volume);
                                break;
                            case PlaybackMode.EnqueuePriority:
                                controller.EnqueueAudioFile(file, audioConfig.Volume, true);
                                break;
                            case PlaybackMode.PlayImmediately:
                                controller.PlayAudioFile(file, audioConfig.Volume);
                                break;
                        }
                    }
                }
            }));

        }

        public virtual void PlayFile(string filePath)
        {
            ActGlobals.oFormActMain.Invoke((Action)(() =>
            {
                HashSet<string> controllerIDs = new HashSet<string>(_audioControllers.Select(c => c.ID));
                foreach (var audioConfig in Config.AudioDevices)
                {
                    if (audioConfig.Enabled && controllerIDs.Contains(audioConfig.ID))
                    {
                        var controller = _audioControllers.First(c => c.ID == audioConfig.ID);
                        if (controller == null)
                        {
                            return;
                        }
                        switch (audioConfig.PlaybackMode)
                        {
                            case PlaybackMode.Enqueue:
                                controller.EnqueueAudioFile(filePath, audioConfig.Volume);
                                break;
                            case PlaybackMode.EnqueuePriority:
                                controller.EnqueueAudioFile(filePath, audioConfig.Volume, true);
                                break;
                            case PlaybackMode.PlayImmediately:
                                controller.PlayAudioFile(filePath, audioConfig.Volume);
                                break;
                        }
                    }
                }
            }));
        }
    }
}
