using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Advanced_Combat_Tracker;
using NAudio.CoreAudioApi;
using Qitana.TTSMixerPlugin.Providers;

namespace Qitana.TTSMixerPlugin
{
    public class PluginMain : IPluginMain
    {
        private TinyIoCContainer _container;
        Logger _logger;

        TabPage _tabPage;
        Label _label;
        ControlPanel _controlPanel;

        Timer _initTimer;
        Timer _configSaveTimer;


        internal PluginConfig Config { get; private set; }
        internal List<IProfile> Profiles { get; private set; }
        public FormActMain.PlayTtsDelegate OriginaPlayTTSMethod { get; private set; }
        public FormActMain.PlaySoundDelegate OriginalPlaySoundMethod { get; private set; }

        public PluginMain(TinyIoCContainer container)
        {
            _container = container;

            // initialize logger
            _logger = new Logger();
            _container.Register(_logger);
            _container.Register<ILogger>(_logger);

            _configSaveTimer = new Timer();
            _configSaveTimer.Interval = 5 * 60 * 1000; // 5 minutes
            _configSaveTimer.Tick += (o, e) => SaveConfig();

            _container.Register(this);
            _container.Register<IPluginMain>(this);
        }

        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            try
            {
                _tabPage = pluginScreenSpace;
                _label = pluginStatusText;


#if DEBUG
                _logger.Log(LogLevel.Warning, "##################################");
                _logger.Log(LogLevel.Warning, "    THIS IS THE DEBUG BUILD");
                _logger.Log(LogLevel.Warning, "##################################");
#endif

                _logger.Log(LogLevel.Info, "Initializing plugin");

                // Registory setup
                _container.Register(new Registry(_container));


                // save the original playTTS and playSound methods
                OriginaPlayTTSMethod = ActGlobals.oFormActMain.PlayTtsMethod;
                OriginalPlaySoundMethod = ActGlobals.oFormActMain.PlaySoundMethod;

                // initialize configuration
                if (!LoadConfig())
                {
                    _logger.Log(LogLevel.Error, "Failed to load configuration");

                    SetErrorLogPanel();
                    return;
                }


                // initialize AudioControllers
                _logger.Log(LogLevel.Info, "Initializing AudioControllers");
                List<IAudioController> audioControllers = new List<IAudioController>();
                var enumerator = new MMDeviceEnumerator();
                var devices = enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);
                foreach (var device in devices)
                {
                    if (device == null)
                    {
                        continue;
                    }
                    _logger.Log(LogLevel.Info, $"Audio device found: {device.FriendlyName}");
                    _logger.Log(LogLevel.Debug, $"Audio device found: {device.FriendlyName} ({device.ID})");
                    var audioController = new AudioController(device.ID);
                    audioControllers.Add(audioController);
                }
                _container.Register(audioControllers);
                _logger.Log(LogLevel.Info, $"Initialized {audioControllers.Count.ToString()} AudioControllers.");


                // setup UI
                _controlPanel = new ControlPanel(_container);
                _controlPanel.Dock = DockStyle.Fill;
                _tabPage.Controls.Add(_controlPanel);
                _tabPage.Name = "TTSMixerPlugin";


                // future: add check update here.


                // delay initialization
                _initTimer = new Timer();
                _initTimer.Interval = 250;
                _initTimer.Tick += async (o, e) =>
                {
                    if (ActGlobals.oFormActMain == null)
                    {
                        // Something went really wrong.
                        _initTimer.Stop();
                        return;
                    }

                    // Check if ACT is ready. This ensures that all plugins are loaded.
                    if (ActGlobals.oFormActMain.InitActDone && ActGlobals.oFormActMain.Handle != IntPtr.Zero)
                    {
                        try
                        {
                            _initTimer.Stop();

                            // Load Profiles to the registry
                            try
                            {
                                await Task.Run(() => LoadBuiltInProfile());
                            }
                            catch (Exception ex)
                            {
                                _logger.Log(LogLevel.Error, "LoadBuiltInProfiles: Failed to load profiles: {0}", ex.ToString());
                            }

                            // Load Addons
                            try
                            {
                                await Task.Run(() => LoadAddons());

                            }
                            catch (Exception ex)
                            {
                                _logger.Log(LogLevel.Error, "LoadAddons: Failed to load addon profiles: {0}", ex.ToString());
                            }
                        }
                        catch
                        {
                            _logger.Log(LogLevel.Error, "LoadAddons: {0}", e);
                            Trace.WriteLine("LoadAddons: " + e.ToString());
                        }
                    }

                    // Run as UI thread
                    ActGlobals.oFormActMain.Invoke((Action)(() =>
                    {
                        try
                        {
                            // initialize profiles
                            Profiles = new List<IProfile>();
                            foreach (var profileConfig in Config.Profiles)
                            {
                                var parameters = new NamedParameterOverloads();
                                parameters["config"] = profileConfig;
                                parameters["name"] = profileConfig.Name;
                                parameters["container"] = _container;

                                var profile = (IProfile)_container.Resolve(profileConfig.ProfileType, parameters);
                                if (profile != null)
                                {
                                    Profiles.Add(profile);
                                }
                            }

                            // initialize profile Tabs
                            _controlPanel.InitializeTabs();

                            // start config save timer
                            _configSaveTimer.Start();
                        }
                        catch (Exception ex)
                        {
                            _logger.Log(LogLevel.Error, "InitPlugin: {0}", ex);
                        }
                    }));

                };
                _initTimer.Start();
                _logger.Log(LogLevel.Info, "Initialized plugin");
            }
            catch (Exception e)
            {
                _logger.Log(LogLevel.Error, "InitPlugin: {0}", e.ToString());
                MessageBox.Show(e.ToString());
                SetErrorLogPanel();
                throw;
            }
        }

        public void DeInitPlugin()
        {
            if (OriginaPlayTTSMethod != null)
            {
                ActGlobals.oFormActMain.PlayTtsMethod = OriginaPlayTTSMethod;
            }
            if (OriginalPlaySoundMethod != null)
            {
                ActGlobals.oFormActMain.PlaySoundMethod = OriginalPlaySoundMethod;
            }
            SaveConfig(true);
        }

        private void LoadAddons()
        {
            foreach (var plugin in ActGlobals.oFormActMain.ActPlugins)
            {
                if (plugin.pluginObj == null) continue;
                try
                {
                    if (plugin.pluginObj.GetType().GetInterface(typeof(IProfileAddon).FullName) != null)
                    {
                        try
                        {
                            var addon = (IProfileAddon)plugin.pluginObj;
                            addon.Init();
                            _logger.Log(LogLevel.Info, "LoadAddons: {0}: Initialized {1}", plugin.lblPluginTitle.Text, addon.ToString());
                        }
                        catch (Exception ex)
                        {
                            _logger.Log(LogLevel.Error, "LoadAddons: {0}: {1}", plugin.lblPluginTitle.Text, ex);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.Log(LogLevel.Error, "LoadAddons: {0}: {1}", plugin.lblPluginTitle.Text, ex);
                }
            }
        }

        private void LoadBuiltInProfile()
        {
            var registory = _container.Resolve<Registry>();
            registory.RegisterProfile<MicrosoftSpeechSynthesizer>();
            registory.RegisterProfile<AzureAISpeech>();
        }

        /// <summary>
        /// Get the configuration path for the plugin.
        /// </summary>
        /// <returns></returns>
        private static string GetConfigPath()
        {
            var path = Path.Combine(
                ActGlobals.oFormActMain.AppDataFolder.FullName,
                "Config",
                "Qitana.TTSMixerPlugin.config.json");

            return path;
        }

        private static string GetCachePath()
        {
            var path = Path.Combine(
                ActGlobals.oFormActMain.AppDataFolder.FullName,
                "TTSMixerPluginCache");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }

        private void SetErrorLogPanel()
        {
            if (_controlPanel == null)
            {
                var errorLogPanel = new ErrorLogPanel(_container);
                errorLogPanel.Dock = DockStyle.Fill;
                _tabPage.Controls.Add(errorLogPanel);
            }
        }

        private bool LoadConfig()
        {
            if (Config != null)
                return true;

            try
            {
                Config = new PluginConfig(GetConfigPath(), GetCachePath(), _container);
            }
            catch (Exception e)
            {
                Config = null;
                _logger.Log(LogLevel.Error, "LoadConfig: {0}", e);
                return false;
            }

            _container.Register(Config);
            _container.Register<IPluginConfig>(Config);
            return true;
        }

        private void SaveConfig(bool force = false)
        {
            if (Config == null) return;


            Config.SaveJson(force);
        }

        public void PlayText(string text, string profileName)
        {
            if (profileName == null)
            {
                profileName = Config.DefaultProfile;
            }
            if (profileName == null)
            {
                _logger.Log(LogLevel.Error, "PlayText: No profile specified.");
                return;
            }

            var profile = Profiles.FirstOrDefault(p => p.Name == profileName);
            if (profile == null)
            {
                _logger.Log(LogLevel.Error, "PlayText: Profile not found: {0}", profileName);
                return;
            }

            profile.PlayText(text);
        }

        public void PlayText(string text)
        {
            PlayText(text, Config.DefaultProfile);
        }

        public void PlayFile(string file, int volumePercent, string profileName)
        {
            if (profileName == null)
            {
                profileName = Config.DefaultProfile;
            }
            if (profileName == null)
            {
                _logger.Log(LogLevel.Error, "PlayFile: No profile specified.");
                return;
            }

            var profile = Profiles.FirstOrDefault(p => p.Name == profileName);
            if (profile == null)
            {
                _logger.Log(LogLevel.Error, "PlayFile: Profile not found: {0}", profileName);
                return;
            }

            profile.PlayFile(file);
        }

        public void PlayFile(string file, int volumePercent)
        {
            PlayFile(file, volumePercent, Config.DefaultProfile);
        }

    }
}
