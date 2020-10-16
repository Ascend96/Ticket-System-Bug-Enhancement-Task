using System;
using NLog.Web;
using System.IO;

namespace EnhancedTicketSystem
{
    class Program
    {
        // create static instance of logger
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        static void Main(string[] args)
        {

            logger.Info("Program Started");

            Console.WriteLine("Hello World!");

            logger.Info("Program has ended");
        }
    }
}
