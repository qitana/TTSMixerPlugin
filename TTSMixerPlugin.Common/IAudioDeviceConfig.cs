using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qitana.TTSMixerPlugin
{
    public interface IAudioDeviceConfig
    {
        string ID { get; set; }
        string FriendlyName { get; set; }
        bool Enabled { get; set; }
        float Volume { get; set; }
        PlaybackMode PlaybackMode { get; set; }

    }

    public enum PlaybackMode
    {
        Enqueue,
        EnqueuePriority,
        PlayImmediately,
    }
}
