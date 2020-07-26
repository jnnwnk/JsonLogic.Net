using System;
using System.Collections.Generic;
using System.Text;

namespace JsonLogic.Net
{
    public interface INamingConventionConverter
    {
        string Convert(string input);
    }
}
