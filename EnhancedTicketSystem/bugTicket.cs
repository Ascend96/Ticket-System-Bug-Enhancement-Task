using System;
using System.Collections.Generic;

namespace EnhancedTicketSystem
{
    public class BugTicket
    {
        public UInt64 bugId { get; set; }
        public string summary { get; set;}
        public string status { get; set; }
        public string priority { get; set; }
        public string submitter { get; set; }
        public string assigned { get; set; }
        public List<string> watching { get; set; }
        public string severity { get; set; }

        // constructor
        public BugTicket(){
            watching = new List<string>();
        }

        public string DisplayBug(){
            return $"ID: {bugId}\nSummary: {summary}\nStatus: {status}\nPriority: {priority}\nSubmitter: {submitter}\nAssigned to: {assigned}\nWatching: {string.Join(", ", watching)}\n Severity: {severity}\n";
        }
       

    }
}