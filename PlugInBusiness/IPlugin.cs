using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlugInBusiness
{
    public interface IPlugin
    {
        string Name { get; }
        string Explanation { get; }
        void Go(string parameters);
    }
}
