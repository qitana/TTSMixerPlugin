using NAudio.CoreAudioApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qitana.TTSMixerPlugin
{
    public class AudioDeviceConfig: IAudioDeviceConfig
    {
        public string ID { get; set; }
        public string FriendlyName { get; set; }
        public bool Enabled { get; set; }
        public float Volume { get; set; }
        public PlaybackMode PlaybackMode { get; set; }


        public AudioDeviceConfig(string id, string friendlyName, bool enabled = false, float volume = 0, PlaybackMode playbackMode = default)
        {
            ID = id;
            FriendlyName = friendlyName;
            Enabled = enabled;
            Volume = volume;
            PlaybackMode = playbackMode;
        }

        public AudioDeviceConfig(MMDevice device, bool enabled = false, float volume = 0, PlaybackMode playbackMode = default)
        {
            if(device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }

            ID = device.ID;
            FriendlyName = device.FriendlyName;
            Enabled = enabled;
            Volume = volume;
            PlaybackMode = playbackMode;
        }
        public AudioDeviceConfig() 
        { 
        }
    }
}
