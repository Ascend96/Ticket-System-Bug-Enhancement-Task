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

            // string ticketFilePath = "ticketFilePath.csv";

            // ticket object code goes here

            string choice = "";

            // do while loop for menu and option selection

            do{
                // add/display tickets by category
                Console.WriteLine("1) Add new Bug/Defect Ticket");
                Console.WriteLine("2) Add new Enhancement Ticket");
                Console.WriteLine("3) Add new Task Ticket");
                Console.WriteLine("4) Display all Bug/Defect Tickets");
                Console.WriteLine("5) Display all Enhancement Tickets");
                Console.WriteLine("6) Display all Task Tickets");
                
                choice = Console.ReadLine();



                

            } while(choice == "1" || choice == "2" || choice == "3" || choice == "4" || choice == "5" || choice == "6");

            logger.Info("Program has ended");
        }
    }
}
