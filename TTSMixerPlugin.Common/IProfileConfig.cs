using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Qitana.TTSMixerPlugin
{
    public interface IProfileConfig
    {
        string Name { get; set; }

        List<IAudioDeviceConfig> AudioDevices { get; set; }

        Type ProfileType { get; }
    }
}
