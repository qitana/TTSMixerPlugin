using Advanced_Combat_Tracker;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Qitana.TTSMixerPlugin.Providers

{
    public class SpeechSynthesizer : ProfileBase<SpeechSynthesizerConfig>
    {

        public override string TypeFriendlyName => "Speech Synthesizer";

        PluginConfig PluginConfig => _container.Resolve<PluginConfig>();

        public SpeechSynthesizer(TinyIoCContainer container, SpeechSynthesizerConfig config) : base(container, config)
        {
        }

        public SpeechSynthesizer(TinyIoCContainer container, string name) : base(container, name)
        {
        }


        public override string ConvertTextToAudioFile(string text, bool canUseCache = true, bool canSaveToCache = true)
        {
            throw new NotImplementedException();
        }

        private MemoryStream ConvertTextToMemoryStream(string text)
        {
            var stream = new MemoryStream();
            var synthesizer = new System.Speech.Synthesis.SpeechSynthesizer();
            if (Config.Voice != null)
            {
                try
                {
                    synthesizer.SelectVoice(Config.Voice);
                }
                catch (Exception)
                {
                }
            }
            synthesizer.SetOutputToWaveStream(stream);
            synthesizer.Volume = Config.Volume;
            synthesizer.Rate = Config.Rate;
            synthesizer.Speak(text);
            synthesizer.SetOutputToNull();
            synthesizer.Dispose();

            stream.Position = 0;
            return stream;
        }

        public override void PlayText(string text)
        {
            ActGlobals.oFormActMain.Invoke((Action)(() =>
            {
                var stream = ConvertTextToMemoryStream(text);
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
                                controller.EnqueueWaveStream16(stream, audioConfig.Volume);
                                break;
                            case PlaybackMode.EnqueuePriority:
                                controller.EnqueueWaveStream16(stream, audioConfig.Volume, true);
                                break;
                            case PlaybackMode.PlayImmediately:
                                controller.EnqueueWaveStream16(stream, audioConfig.Volume);
                                break;
                        }
                    }
                }
            }));
        }

        public override Control CreateConfigControl()
        {
            return new SpeechSynthesizerConfigControl(_container, this);
        }

        public List<string> GetInstalledVoices()
        {
            using (var synthesizer = new System.Speech.Synthesis.SpeechSynthesizer())
            {
                return synthesizer.GetInstalledVoices().Select(v => v.VoiceInfo.Name).ToList();
            }
        }

    }
}
