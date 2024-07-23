using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace Qitana.TTSMixerPlugin
{
    internal class AudioController: IAudioController
    {
        MMDevice _audioDevice;

        private ConcurrentQueue<Func<Task>> normalTaskQueue = new ConcurrentQueue<Func<Task>>();
        private ConcurrentQueue<Func<Task>> priorityTaskQueue = new ConcurrentQueue<Func<Task>>();

        private int isProcessingQueue = 0; // This is Interlocked flag. 0: false, 1: true
        private int isResettingQueue = 0; // This is Interlocked flag. 0: false, 1: true

        public string ID => _audioDevice.ID;
        public string FriendlyName => _audioDevice.FriendlyName;

        public AudioController(string audioDeviceID)
        {
            // Initialize the audio playback controller
            var enumerator = new MMDeviceEnumerator();
            var devices = enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);
            foreach (var device in devices)
            {
                if (device.ID == audioDeviceID)
                {
                    _audioDevice = device;
                    break;
                }
            }

            if (_audioDevice == null)
            {
                throw new AudioDeviceNotFountException($"Audio device {audioDeviceID} not found.");
            }
        }

        public void EnqueueAudioFile(string filePath, float volume = 1.0f, bool isPriority = false)
        {
            // throw exception if resetting the queue
            if (Interlocked.CompareExchange(ref isResettingQueue, 0, 0) == 1)
            {
                throw new InvalidOperationException("Cannot enqueue audio file while resetting the queue.");
            }

            // add the task to the queue
            if (isPriority)
            {
                priorityTaskQueue.Enqueue(() => PlayAudioFileAsync(filePath, volume));
            }
            else
            {
                normalTaskQueue.Enqueue(() => PlayAudioFileAsync(filePath, volume));
            }

            // process the queue if it is not processing
            if (Interlocked.CompareExchange(ref isProcessingQueue, 1, 0) == 0)
            {
                ProcessQueue();
            }
        }

        public void PlayAudioFile(string filePath, float volume = 1.0f) => PlayAudioFileAsync(filePath, volume);

        public void ResetQueue()
        {
            // set resetting flag
            Interlocked.Exchange(ref isResettingQueue, 1);

            // clear the queue
            ClearQueue(priorityTaskQueue);
            ClearQueue(normalTaskQueue);

            // reset the flag
            Interlocked.Exchange(ref isResettingQueue, 0);
        }


        private async void ProcessQueue()
        {
            while (priorityTaskQueue.Count > 0 || normalTaskQueue.Count > 0)
            {
                if (Interlocked.CompareExchange(ref isResettingQueue, 0, 0) == 1)
                {
                    break;
                }

                Func<Task> task;
                if (priorityTaskQueue.TryDequeue(out task) || normalTaskQueue.TryDequeue(out task))
                {
                    try
                    {
                        await task();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"再生中にエラーが発生しました: {ex.Message}");
                    }
                }
            }

            Interlocked.Exchange(ref isProcessingQueue, 0);
        }

        private void ClearQueue(ConcurrentQueue<Func<Task>> queue)
        {
            while (queue.TryDequeue(out _)) { }
        }

        private Task PlayAudioFileAsync(string filePath, float volume)
        {
            return Task.Run(async () =>
            {
                try
                {
                    using (var audioFile = new AudioFileReader(filePath))
                    using (var outputDevice = new WasapiOut(AudioClientShareMode.Shared, 10))
                    {
                        // set volume level between 0.0 and 1.0
                        audioFile.Volume = volume < 0.0f ? 0.0f : volume > 1.0f ? 1.0f : volume;

                        // set audio file to output device
                        outputDevice.Init(audioFile);

                        // start playback
                        outputDevice.Play();

                        // wait until the playback is finished
                        while (outputDevice.PlaybackState == PlaybackState.Playing)
                        {
                            await Task.Delay(50);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"再生中にエラーが発生しました: {ex.Message}");
                }
            });
        }
    }
}
