using System;
using System.Collections.Generic;
using System.IO;
using NLog.Web;
using System.Linq;

namespace EnhancedTicketSystem
{   
    // this file only used for bug tickets
    public class BugTicketFile{

        public string filePath { get; set; }

        public List<Ticket.Bug> Tickets { get; set; }

        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        // reads file and stores each csv into array index to create bug ticket
        public BugTicketFile(string ticketFilePath){
            filePath = ticketFilePath;
            Tickets = new List<Ticket.Bug>();
            
            // skips first line for headers
            try {
                StreamReader sr = new StreamReader(filePath);
                sr.ReadLine();

                while(!sr.EndOfStream){
                    Ticket.Bug ticket = new Ticket.Bug();
                    string line = sr.ReadLine();

                    string[] ticketDetails = line.Split(',');
                    ticket.ticketId = UInt64.Parse(ticketDetails[0]);
                    ticket.summary = ticketDetails[1];
                    ticket.status = ticketDetails[2];
                    ticket.priority = ticketDetails[3];
                    ticket.severity = ticketDetails[4];
                    ticket.submitter = ticketDetails[5];
                    ticket.assigned = ticketDetails[6];
                    ticket.watching = ticketDetails[7].Split('|').ToList();

                    Tickets.Add(ticket);
                }
                sr.Close();

                // logs how many tickets in file
                logger.Info("Tickets in file {count}", Tickets.Count);
            } catch (Exception ex){
                logger.Error(ex.Message);
            }
        }

        // writes bug ticket to the file and adds it to list
        public void AddTicket(Ticket.Bug ticket){
            try {
                // uses 1 number higher than highest ticket id 
                ticket.ticketId = Tickets.Max(t => t.ticketId) + 1;

                StreamWriter sw = new StreamWriter(filePath, true);
                sw.WriteLine($"{ticket.ticketId}, {ticket.summary}, {ticket.status}, {ticket.priority}, {ticket.severity}, {ticket.submitter}, {ticket.assigned}, {string.Join("| ", ticket.watching)}");

                sw.Close();

                Tickets.Add(ticket);
                // logs Id of ticket added
                logger.Info("Ticket id {id} added", ticket.ticketId);   
            } catch(Exception ex){
                logger.Error(ex.Message);
            }
        }
    }
}
