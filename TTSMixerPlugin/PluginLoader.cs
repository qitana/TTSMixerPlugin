using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Advanced_Combat_Tracker;
using RainbowMage.OverlayPlugin;


namespace Qitana.TTSMixerPlugin
{
    internal class PluginLoader : IActPluginV1, IOverlayAddonV2
    {
        TinyIoCContainer _container;
        PluginMain _pluginMain;
        TabPage _pluginScreenSpace;
        Label _pluginStatusText;


        public TinyIoCContainer Container { get; private set; }

        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            _pluginScreenSpace = pluginScreenSpace;
            _pluginStatusText = pluginStatusText;

            _pluginStatusText.Text = "Initializing...";
            _pluginScreenSpace.Text = "TTSMixerPlugin";

            _container = new TinyIoCContainer();

            _pluginMain = new PluginMain(_container);
            _pluginMain.InitPlugin(pluginScreenSpace, pluginStatusText);

            _pluginStatusText.Text = "Ready.";

        }

        public void DeInitPlugin()
        {
            if(_pluginMain != null)
            {
               _pluginMain.DeInitPlugin();
            }
        }

        public void Init()
        {
            var container = RainbowMage.OverlayPlugin.Registry.GetContainer();
            var registry = container.Resolve<RainbowMage.OverlayPlugin.Registry>();
            registry.StartEventSource(new TTSMixerEventSource(container, _pluginMain));
        }
    }
}
