using System;
using System.Collections.Generic;

namespace EnhancedTicketSystem
{
    public class Ticket
    {
        public UInt64 ticketId { get; set; }
        public string summary { get; set;}
        public string status { get; set; }
        public string priority { get; set; }
        public string submitter { get; set; }
        public string assigned { get; set; }
        public List<string> watching { get; set; }
        

        // constructor
        public Ticket(){
            watching = new List<string>();
        }

        public virtual string Display(){
            return $"ID: {ticketId}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nAssigned to: {assigned}\nWatching: {string.Join(", ", watching)}\n";
        }

        // bug class derived from ticket class
        public class Bug : Ticket{
            public string severity { get; set; }

            public override string Display()
            {
                return $"\nID: {ticketId}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSeverity: {severity}\nSubmitter: {submitter}\nAssigned to: {assigned}\nWatching: {string.Join(", ", watching)}\n";
            }

        }

        // Enhancement derived from ticket class
        public class Enhancement : Ticket{
            public string software { get; set; }
            public double cost { get; set; }
            public string reason { get; set; }
            public double estimate { get; set; }

            public override string Display()
            {
                return $"\nTicket ID: {ticketId}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSoftware: {software}\nCost: ${cost}\nReason: {reason}\nEstimate: ${estimate}\nSubmitter: {submitter}\nAssigned to: {assigned}\nWatching: {string.Join(", ", watching)}\n";
            }
        }

        // Task derived from ticket class
        public class Task : Ticket{
            public string projectName { get; set; }
            public string dueDate { get; set; }

            public override string Display()
            {
                return $"\nTicket ID: {ticketId}\n\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nProject Name: {projectName}\nDue Date: {dueDate}\nSubmitter: {submitter}\nAssigned to: {assigned}\nWatching: {string.Join(", ", watching)}\n";
            }
        }
       

    }
}