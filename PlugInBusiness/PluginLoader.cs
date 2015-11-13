using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PlugInBusiness
{
    public class PluginLoader
    {
        public static List<IPlugin> _plugins { get; set; }

        public void LoadPlugins(string filePath)
        {
            _plugins = new List<IPlugin>();

            //Load the DLLs from the Plugins directory
            if (Directory.Exists(Constants.FolderName))
            {
                string[] files = Directory.GetFiles(Constants.FolderName);

                foreach (string file in files)
                {
                    if (file.EndsWith(".dll"))
                    {
                        Assembly.LoadFile(Path.GetFullPath(file));
                    }
                }
            }

            Type interfaceType = typeof(IPlugin);

            //Fetch all types that implement the interface IPlugin and are a class
            Type[] types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(p => interfaceType.IsAssignableFrom(p) && p.IsClass)
                .ToArray();

            foreach (Type type in types)
            {
                //Create a new instance of all found types
                _plugins.Add((IPlugin)Activator.CreateInstance(type));
            }
        }

        public void LoadPluginsBase64(string base64String)
        {
            _plugins = new List<IPlugin>();

            byte[] baseByte = Convert.FromBase64String(base64String);

            Assembly.Load(baseByte);

            Type interfaceType = typeof(IPlugin);

            //Fetch all types that implement the interface IPlugin and are a class
            Type[] types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(p => interfaceType.IsAssignableFrom(p) && p.IsClass)
                .ToArray();

            foreach (Type type in types)
            {
                //Create a new instance of all found types
                _plugins.Add((IPlugin)Activator.CreateInstance(type));
            }
        }
    }
}
