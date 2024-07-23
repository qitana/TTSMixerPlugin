using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qitana.TTSMixerPlugin
{
    public interface IProfile
    {
        string Name { get; set; }

        string TypeFriendlyName { get; }

        IProfileConfig Config { get; set; }

        Control CreateConfigControl();

        string ConvertTextToAudioFile(string text, bool canUseCache = true, bool canSaveToCache = true);

        void PlayText(string text);

        void PlayFile(string filePath);

    }
}
