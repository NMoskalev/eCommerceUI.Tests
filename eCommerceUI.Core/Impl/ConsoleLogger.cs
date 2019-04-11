using System;

namespace eCommerceUI.Core.Impl
{
    internal class ConsoleLogger : ILogger
    {
        public void Log(string message, LoggerLevel level = LoggerLevel.Info)
        {
            if (level == LoggerLevel.Error)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(message);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine(message);
            }        
        }
    }
}
