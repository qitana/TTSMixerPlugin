using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advanced_Combat_Tracker;

namespace Qitana.TTSMixerPlugin
{
    public class Registry
    {
        private TinyIoCContainer _container;
        private List<Type> _profiles;

        public IEnumerable<Type> Profiles => _profiles;


        public Registry(TinyIoCContainer container)
        {
            _container = container;
            _profiles = new List<Type>();
        }

        public static TinyIoCContainer GetContainer()
        {
            // This function is called from addons to get the TinyIoCContainer
            foreach (var entry in ActGlobals.oFormActMain.ActPlugins)
            {
                if (entry.pluginObj != null && entry.pluginObj.GetType().FullName == "Qitana.TTSMixerPlugin.PluginLoader")
                {
                    return (TinyIoCContainer)entry.pluginObj.GetType().GetProperty("Container").GetValue(entry.pluginObj);
                }
            }
            throw new Exception("Couldn't find TTSMixerPlugin!");
        }

        public void RegisterProfile<T>() where T: class, IProfile
        {
            _profiles.Add(typeof(T));
            _container.Register<T>();
        }


    }
}
