using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qitana.TTSMixerPlugin.Providers
{
    public class AzureAISpeechConfig : ProfileConfigBase
    {
        public override Type ProfileType => typeof(AzureAISpeech);

        public string AzureAISpeechRegion { get; set; }
        public string AzureAISpeechResouceKey { get; set; }
        public string Voice { get; set; }

        public int Volume { get; set; } // 0 to 100
        public int Rate { get; set; } // -50 to +100
        public int Pitch { get; set; } // -50 to +50

        public AzureAISpeechConfig(string name) : base(name)
        {
            AzureAISpeechRegion = null;
            AzureAISpeechResouceKey = null;
            Voice = null;
            Volume = 100;
            Rate = 0;
            Pitch = 0;
        }
    }
}
