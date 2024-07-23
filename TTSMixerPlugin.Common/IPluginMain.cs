using Advanced_Combat_Tracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qitana.TTSMixerPlugin
{
    public interface IPluginMain
    {
        void PlayText(string text, string profileName);
        void PlayText(string text); 

        void PlayFile(string file, int volumePercent, string profileName);
        void PlayFile(string file, int volumePercent);
    }
}
