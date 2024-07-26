using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Windows.Forms;

namespace Qitana.TTSMixerPlugin
{
    [Serializable]
    public class PluginConfig : IPluginConfig
    {
        const string BACKUP_SUFFIX = ".backup";

        [NonSerialized]
        [JsonIgnore]
        private TinyIoCContainer _container;

        [NonSerialized]
        [JsonIgnore]
        private ILogger _logger;

        [JsonIgnore]
        private bool _isDirty = false;
        public void MarkDirty()
        {
            _isDirty = true;
        }

        [JsonIgnore]
        private string _filePath;

        [JsonIgnore]
        private string _cachePath;
        [JsonIgnore]
        public string PluginCachePath => _cachePath;

        public string DefaultProfile { get; set; }

        public bool OverrideOriginalPlayTTS { get; set; }

        public bool OverrideOriginalPlaySound { get; set; }
        public bool FollowLatestLog { get; set; }

        public List<IProfileConfig> Profiles { get; set; }

        public PluginConfig(string configPath, string cachePath, TinyIoCContainer container)
        {
            if (configPath == null) throw new Exception("Invalid config path passed to PluginConfig!");

            _filePath = configPath;
            _cachePath = cachePath;
            _container = container;
            _logger = container.Resolve<ILogger>();

#if DEBUG
            _logger.Log(LogLevel.Debug, $"Config file path: {_filePath}");
#endif

            // Set default values
            SetDefault();

            // Load from file
            var useBackup = true;
            var initEmpty = false;
            if (File.Exists(configPath))
            {
                try
                {
                    LoadJson(configPath);
                    useBackup = false;
                }
                catch (Exception ex)
                {
                    _logger.Log(LogLevel.Error, $"LoadConfig: Failed to load configuration: {0}. {ex.Message}");
                }
            }
            else
            {
                useBackup = true;
            }

            // Load from backup if the main file is corrupted
            if (useBackup)
            {
                if (File.Exists(configPath + BACKUP_SUFFIX))
                {
                    _logger.Log(LogLevel.Info, "LoadConfig: Loading backup config...");
                    try
                    {
                        LoadJson(configPath + BACKUP_SUFFIX);
                    }
                    catch (Exception ex)
                    {
                        _logger.Log(LogLevel.Error, $"LoadConfig: Failed to load backup configuration: {0}. {ex.Message}");
                        var dialog = new ConfigErrorDialog();
                        if (dialog.ShowDialog() == DialogResult.Yes)
                        {
                            initEmpty = true;
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                else
                {
                    initEmpty = true;
                }
            }

            // if the config is empty, initialize it
            if (initEmpty)
            {
                SetDefault();
            }

            _isDirty = false;


        }

        public void SetDefault()
        {
            DefaultProfile = null;
            OverrideOriginalPlayTTS = false;
            OverrideOriginalPlaySound = false;
            FollowLatestLog = false;
            Profiles = new List<IProfileConfig>();
        }


        public void SaveJson(bool force = false)
        {
            if (!force && !_isDirty) return;

            _logger.Log(LogLevel.Debug, $"Save Called.");

            // Create a backup of the current file
            if (File.Exists(_filePath))
            {
                // check if the file is a valid json file
                var isConfigValid = false;
                try
                {

                    using (var stream = new StreamReader(_filePath))
                    {
                        var jsonReader = new JsonTextReader(stream);
                        JToken.ReadFrom(jsonReader);
                    }
                    isConfigValid = true;
                }
                catch (Exception)
                {
                    _logger.Log(LogLevel.Warning, "Config file is not a valid. Skipping backup.");
                }

                // if the file is valid, create a backup
                if (isConfigValid)
                {
                    File.Copy(_filePath, _filePath + BACKUP_SUFFIX, true);
                }
            }

            // Save the current configuration
            using (var stream = new StreamWriter(_filePath))
            {
                var serializer = new JsonSerializer
                {
                    Formatting = Formatting.Indented,
                    TypeNameHandling = TypeNameHandling.Auto,
                };
                serializer.Serialize(stream, this);
            }

            _isDirty = false;
        }

        public void LoadJson(string configPath)
        {
            if (!File.Exists(configPath))
            {
                throw new FileNotFoundException("Config file not found.", configPath);
            }

            using (var stream = new StreamReader(configPath))
            {
                var reader = new JsonTextReader(stream);
                var serializer = new JsonSerializer
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                };
                serializer.Populate(reader, this);
            }
        }
    }
}
