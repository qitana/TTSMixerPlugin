using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Qitana.TTSMixerPlugin.Providers
{
    public class AzureAISpeech : ProfileBase<AzureAISpeechConfig>
    {

        public static HttpClient httpClient = new HttpClient();
        public VoiceInfo[] Voices { get; set; } = new VoiceInfo[0];

        public override string TypeFriendlyName => "Azure AI Speech";


        public override string ConvertTextToAudioFile(string text, bool canUseCache = true, bool canSaveToCache = true)
        {
            if (String.IsNullOrEmpty(Config.Voice))
            {
                throw new Exception("Voice must be set");
            }

            var voice = Voices.FirstOrDefault(v => v.ShortName == Config.Voice);
            if(voice == null)
            {
                throw new Exception("Voice not found");
            }

            var ssml = $"<speak version='1.0' xml:lang='en-US'><voice name='{voice.ShortName}'><prosody volume='{Config.Volume}%' rate='{Config.Rate}%' pitch='{Config.Pitch}%'>{text}</prosody></voice></speak>";
            var fileName = GetWaveFilePath(ssml);

            if(canUseCache && System.IO.File.Exists(fileName))
            {
                _logger.Log(LogLevel.Debug, $"Using cached file {fileName}");
                return fileName;
            }


            if (String.IsNullOrEmpty(Config.AzureAISpeechResouceKey) || String.IsNullOrEmpty(Config.AzureAISpeechRegion))
            {
                throw new Exception("AzureAISpeechResouceKey and AzureAISpeechRegion must be set");
            }


            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri($"https://{Config.AzureAISpeechRegion}.tts.speech.microsoft.com/cognitiveservices/v1"),
                Headers = {
                    { "Ocp-Apim-Subscription-Key", Config.AzureAISpeechResouceKey },
                    { "X-Microsoft-OutputFormat", "riff-16khz-16bit-mono-pcm" },
                    { "User-Agent", "System.Net.Http.HttpClient" },
                },
                Content = new StringContent(ssml, Encoding.UTF8, "application/ssml+xml")
            };
            var response = httpClient.SendAsync(request).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to get voices: {response.ReasonPhrase}");
            }
            var responseBytes = response.Content.ReadAsByteArrayAsync().Result;
            System.IO.File.WriteAllBytes(fileName, responseBytes);
            return fileName;
        }

        private string GetWaveFilePath(string ssml)
        {
            var dir = System.IO.Path.Combine(PluginConfig.PluginCachePath, "AzureAISpeech");
            if (!System.IO.Directory.Exists(dir))
            {
                System.IO.Directory.CreateDirectory(dir);
            }
            using (var sha = SHA256.Create())
            {
                var cachePath = PluginConfig.PluginCachePath;
                var hashBytes = sha.ComputeHash(Encoding.UTF8.GetBytes(ssml));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return System.IO.Path.Combine(dir, $"{sb.ToString()}.wav");
            }

        }

        public override Control CreateConfigControl()
        {
            return new AzureAISpeechConfigPanel(_container, this);
        }


        public AzureAISpeech(TinyIoCContainer container, AzureAISpeechConfig config) : base(container, config)
        {
        }

        public AzureAISpeech(TinyIoCContainer container, string name) : base(container, name)
        {
        }

    }
}
