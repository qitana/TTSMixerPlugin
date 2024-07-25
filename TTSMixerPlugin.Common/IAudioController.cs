using System.IO;

namespace Qitana.TTSMixerPlugin
{
    public interface IAudioController
    {
        string ID { get; }
        string FriendlyName { get; }
        void EnqueueAudioFile(string filePath, float volume = 1.0f, bool isPriority = false);
        void PlayAudioFile(string filePath, float volume = 1.0f);
        void EnqueueWaveStream16(MemoryStream stream, float volume = 1.0f, bool isPriority = false);
        void PlayWaveStream16(MemoryStream stream, float volume = 1.0f);
        void ResetQueue();
    }
}
