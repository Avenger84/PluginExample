using PlugInBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstPlugIn
{
    public class First : IPlugin
    {
        public string Name
        {
            get { return "First"; }
        }

        public string Explanation
        {
            get { return "First plugin"; }
        }

        public void Go(string parameters)
        {
            Console.WriteLine("Hello world first plugin");
        }
    }
}
