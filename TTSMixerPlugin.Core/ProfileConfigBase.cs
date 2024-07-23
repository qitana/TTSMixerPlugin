using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qitana.TTSMixerPlugin
{
    public abstract class ProfileConfigBase : IProfileConfig
    {
        public string Name { get; set; }

        public Guid Uuid { get; set; }

        public List<IAudioDeviceConfig> AudioDevices { get; set; }

        [JsonIgnore]
        public abstract Type ProfileType { get; }

        protected ProfileConfigBase(string name)
        {
            this.Name = name;
            this.Uuid = Guid.NewGuid();
            this.AudioDevices = new List<IAudioDeviceConfig>();
        }
    }
}
