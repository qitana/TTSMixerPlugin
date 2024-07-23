using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qitana.TTSMixerPlugin
{
    public interface IPluginConfig
    {
        string DefaultProfile { get; set; }
        bool OverrideOriginalPlayTTS { get; set; }
        bool OverrideOriginalPlaySound { get; set; }
        bool FollowLatestLog { get; set; }
        List<IProfileConfig> Profiles { get; set; }

        void MarkDirty();
    }
}
