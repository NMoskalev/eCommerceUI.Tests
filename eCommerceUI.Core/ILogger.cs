using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceUI.Core
{
    public interface ILogger
    {
        void Log(string message, LoggerLevel level = LoggerLevel.Info);
    }
}
