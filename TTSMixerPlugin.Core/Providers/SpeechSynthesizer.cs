using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
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
            var cachePath = PluginConfig.PluginCachePath;
            var filePath = Path.Combine(cachePath, $"{Guid.NewGuid().ToString("N")}.wav");

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
            synthesizer.SetOutputToWaveFile(filePath);
            synthesizer.Volume = Config.Volume;
            synthesizer.Rate = Config.Rate;
            synthesizer.Speak(text);
            synthesizer.Dispose();

            return filePath;
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
