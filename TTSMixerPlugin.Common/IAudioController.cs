using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qitana.TTSMixerPlugin
{
    public interface IAudioController
    {
        string ID { get; }
        string FriendlyName { get; }
        void EnqueueAudioFile(string filePath, float volume = 1.0f, bool isPriority = false);
        void PlayAudioFile(string filePath, float volume = 1.0f);
        void ResetQueue();
    }
}
