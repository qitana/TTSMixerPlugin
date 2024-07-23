using System;

namespace Qitana.TTSMixerPlugin
{
    public class AudioDeviceNotFountException: Exception
    {
        public AudioDeviceNotFountException(string message): base(message)
        {
        }
    }
}
