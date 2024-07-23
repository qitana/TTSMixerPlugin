using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qitana.TTSMixerPlugin.Providers
{
    public class SpeechSynthesizerConfig : ProfileConfigBase
    {
        public override Type ProfileType => typeof(SpeechSynthesizer);

        public string Voice { get; set; }
        public int Volume { get; set; } // 0 to 100
        public int Rate { get; set; } // -10 to 10

        
        public SpeechSynthesizerConfig(string name): base (name)
        {
            Voice = null;
            Volume = 100;
            Rate = 0;
        }
    }
}
