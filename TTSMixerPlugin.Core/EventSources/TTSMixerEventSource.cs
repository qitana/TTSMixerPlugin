using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RainbowMage.OverlayPlugin;

namespace Qitana.TTSMixerPlugin
{
    public class TTSMixerEventSource : EventSourceBase
    {
        private readonly PluginMain pluginMain;

        public TTSMixerEventSource(RainbowMage.OverlayPlugin.TinyIoCContainer container, PluginMain pluginMain) : base(container)
        {
            this.pluginMain = pluginMain;

            RegisterEventHandler("ttsMixerSay", (msg) =>
            {
                var text = msg["text"]?.ToString();
                var profile = msg["profile"]?.ToString();
                
                if(String.IsNullOrEmpty(text))
                {
                    return null;
                }

                if(String.IsNullOrEmpty(profile))
                {
                    this.pluginMain.PlayText(text);
                }
                else
                {
                    this.pluginMain.PlayText(text, profile);
                }

                return null;
            });

            RegisterEventHandler("ttsMixerPlaySound", (msg) =>
            {
                var file = msg["file"]?.ToString();
                var volume = msg["volume"]?.ToObject<int>() ?? 100;
                var profile = msg["profile"]?.ToString();

                //adjust volume to 0-100
                volume = Math.Max(0, Math.Min(100, volume));

                if (String.IsNullOrEmpty(file))
                {
                    return null;
                }

                if (String.IsNullOrEmpty(profile))
                {
                    this.pluginMain.PlayFile(file, volume);
                }
                else
                {
                    this.pluginMain.PlayFile(file, volume, profile);
                }

                return null;
            });


        }

        public override Control CreateConfigControl()
        {
            return null;
        }

        public override void LoadConfig(RainbowMage.OverlayPlugin.IPluginConfig config)
        {
        }

        public override void SaveConfig(RainbowMage.OverlayPlugin.IPluginConfig config)
        {
        }

        protected override void Update()
        {
        }
    }
}
