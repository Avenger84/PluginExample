using PlugInBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {

            PluginLoader loader = new PluginLoader();
            loader.LoadPlugins(@"C:\Users\volkan.serter\Documents\visual studio 2013\Projects\PlugInExample\TestApp\bin\Debug\Plugins");

            List<IPlugin> plugIns = PluginLoader._plugins;

            IPlugin plugin = plugIns[0];

            plugIns[0].Go("Volkan Test");

            Console.ReadKey();
        }
    }
}
