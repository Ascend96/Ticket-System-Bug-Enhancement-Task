﻿using System;
using NLog.Web;
using System.IO;
using System.Linq;

namespace EnhancedTicketSystem
{
    class Program
    {
        // create static instance of logger
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

        static void Main(string[] args)
        {

            logger.Info("Program Started");

            // sets file paths for tickets
            string ticketFilePath = "Ticket.csv";
            string enhancementTicket = "Enhancement.csv";
            string taskFilePath = "Task.csv";

            // creates ticket file object for tickets
            BugTicketFile bugTicketFile = new BugTicketFile(ticketFilePath);
            EnhancementTicketFile enhancementTicketFile = new EnhancementTicketFile(enhancementTicket);
            TaskTicketFile taskTicketFile = new TaskTicketFile(taskFilePath);
            string choice = "";

            // testing object
           /* Ticket.Bug defaultTicket = new Ticket.Bug(){
                ticketId = 1,
                summary = "summary",
                status = "status",
                priority = "priority",
                severity = "severity",
                submitter = "Name",
                assigned = "name",
                watching = {"name", "name", "name"}
            }; */
            

            // do while loop for menu and option selection

            do{
                // add/display tickets by category
                Console.WriteLine("1) Add new Bug/Defect Ticket");
                Console.WriteLine("2) Add new Enhancement Ticket");
                Console.WriteLine("3) Add new Task Ticket");
                Console.WriteLine("4) Display all Bug/Defect Tickets");
                Console.WriteLine("5) Display all Enhancement Tickets");
                Console.WriteLine("6) Display all Task Tickets");
                Console.WriteLine("7) Search status, priority or submitter of ticket");
                
                // takes users selection for options
                choice = Console.ReadLine();

                // displays option selected by user
                logger.Info("User Selection: {choice}", choice);

                // first option for bug/defect ticket
                if(choice == "1"){
                    // creates object with bug subclass
                    Ticket.Bug ticket = new Ticket.Bug();

                    // asks and gathers users input necessary for bug ticket
                    Console.WriteLine("Enter Ticket Summary");

                    ticket.summary = Console.ReadLine();

                    Console.WriteLine("Enter Ticket Status");

                    ticket.status = Console.ReadLine();

                    Console.WriteLine("Enter Priority Level");

                    ticket.priority = Console.ReadLine();

                    Console.WriteLine("Enter Severity Level");
                    
                    ticket.severity = Console.ReadLine();

                    Console.WriteLine("Enter name of ticket submitter");

                    ticket.submitter = Console.ReadLine();

                    Console.WriteLine("Enter name of person assigned to ticket");

                    ticket.assigned = Console.ReadLine();

                    
                    string input; 
                    // do while loop to ask for all names of people watching ticket
                    do{
                        Console.WriteLine("Enter Name of person(s) watching the ticket(Enter done to quit)");
                        input = Console.ReadLine();

                        // if any input is entered, add it to watching list
                        if(input != "done" && input.Length > 0){
                            ticket.watching.Add(input);
                        }

                    }while(input != "done");
                        // if no input entered, add no listed watchers
                        if (ticket.watching.Count == 0){
                            ticket.watching.Add("No listed watchers");
                        }
                        // adds ticket to bug file
                        bugTicketFile.AddTicket(ticket);
                
                } 
                else if(choice == "2"){
                    Ticket.Enhancement ticket = new Ticket.Enhancement();

                    // asks and gathers users input necessary for enhancement ticket
                    Console.WriteLine("Enter Ticket Summary");

                    ticket.summary = Console.ReadLine();

                    Console.WriteLine("Enter Ticket Status");

                    ticket.status = Console.ReadLine();

                    Console.WriteLine("Enter Priority Level");

                    ticket.priority = Console.ReadLine();

                    Console.WriteLine("Enter Software");
                    
                    ticket.software = Console.ReadLine();

                    Console.WriteLine("Enter Cost");

                    ticket.cost = Double.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Reason");

                    ticket.reason = Console.ReadLine();

                    Console.WriteLine("Enter Price Estimate");

                    ticket.estimate = Double.Parse(Console.ReadLine());

                    Console.WriteLine("Enter name of ticket submitter");

                    ticket.submitter = Console.ReadLine();

                    Console.WriteLine("Enter name of person assigned to ticket");

                    ticket.assigned = Console.ReadLine();

                    
                    string input; 
                    // do while loop to ask for all names of people watching ticket
                    do{
                        Console.WriteLine("Enter Name of person(s) watching the ticket(Enter done to quit)");
                        input = Console.ReadLine();

                        // if any input is entered, add it to watching list
                        if(input != "done" && input.Length > 0){
                            ticket.watching.Add(input);
                        }

                    }while(input != "done");
                        // if no input entered, add no listed watchers
                        if (ticket.watching.Count == 0){
                            ticket.watching.Add("No listed watchers");
                        }
                        // adds ticket to enhancement file
                        enhancementTicketFile.AddTicket(ticket);
                } 
                else if(choice == "3"){
                    // creates object with task subclass
                    Ticket.Task ticket = new Ticket.Task();

                    // asks and gathers users input necessary for Task ticket
                    Console.WriteLine("Enter Ticket Summary");

                    ticket.summary = Console.ReadLine();

                    Console.WriteLine("Enter Ticket Status");

                    ticket.status = Console.ReadLine();

                    Console.WriteLine("Enter Priority Level");

                    ticket.priority = Console.ReadLine();

                    Console.WriteLine("Enter Project Name");
                    
                    ticket.projectName = Console.ReadLine();

                    Console.WriteLine("Enter project due date");

                    ticket.dueDate = Console.ReadLine();

                    Console.WriteLine("Enter name of ticket submitter");

                    ticket.submitter = Console.ReadLine();

                    Console.WriteLine("Enter name of person assigned to ticket");

                    ticket.assigned = Console.ReadLine();

                    
                    string input; 
                    // do while loop to ask for all names of people watching ticket
                    do{
                        Console.WriteLine("Enter Name of person(s) watching the ticket(Enter done to quit)");
                        input = Console.ReadLine();

                        // if any input is entered, add it to watching list
                        if(input != "done" && input.Length > 0){
                            ticket.watching.Add(input);
                        }

                    }while(input != "done");
                        // if no input entered, add no listed watchers
                        if (ticket.watching.Count == 0){
                            ticket.watching.Add("No listed watchers");
                        }
                        // adds ticket to task file
                        taskTicketFile.AddTicket(ticket);
                  
                } 
                // displays all bug tickets in file
                else if(choice == "4"){
                    foreach(Ticket.Bug t in bugTicketFile.Tickets){
                        Console.WriteLine(t.Display());
                    }
                }
                // displays all enhancement tickets in file
                else if(choice == "5"){
                    foreach(Ticket.Enhancement t in enhancementTicketFile.Tickets){
                        Console.WriteLine(t.Display());
                    }
                }
                // displays all task tickets in file
                else if(choice == "6"){
                    foreach(Ticket.Task t in taskTicketFile.Tickets){
                        Console.WriteLine(t.Display());
                    }
                } 
                // Search through tickets of any type based on status, priority or submitter
                else if (choice == "7"){
                    // displays choices
                    Console.WriteLine("1) Search by Status of tickets");
                    Console.WriteLine("2) Search by Priority of tickets");
                    Console.WriteLine("3) Search by Submitter of tickets");
                    var option = Console.ReadLine();
                    if(option == "1"){
                        Console.WriteLine("Enter status of ticket to search for");

                        var resp = Console.ReadLine();
                        // where operator to search through status of each ticket type
                        var taskTickets = taskTicketFile.Tickets.Where(t => t.status.Contains(resp, StringComparison.OrdinalIgnoreCase));

                        var enhanceTickets = enhancementTicketFile.Tickets.Where(e => e.status.Contains(resp, StringComparison.OrdinalIgnoreCase));

                        var bugTickets = bugTicketFile.Tickets.Where(b => b.status.Contains(resp, StringComparison.OrdinalIgnoreCase));
                        // changes console color to display selections that match
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        // three foreach loops to loop through each list and display the tickets that match
                        foreach(Ticket.Task t in taskTickets){
                        Console.WriteLine($"This is a task ticket: {t.Display()}");
                        }

                        foreach(Ticket.Enhancement e in enhanceTickets){
                        Console.WriteLine($"This is a enhancement ticket:  {e.Display()}");
                        }

                        foreach(Ticket.Bug b in bugTickets){
                        Console.WriteLine($"This is a bug ticket: {b.Display()}");
                        }
                        // changes console color back to white
                        Console.ForegroundColor = ConsoleColor.White;
                        // adds up all tickets with count aggregation method and displays number of results
                        Console.WriteLine($"There are {taskTickets.Count() + enhanceTickets.Count() + bugTickets.Count()} matching results\n\n");

                    }
                    else if(option == "2"){
                        Console.WriteLine("Enter priority of ticket to search for");

                        var resp = Console.ReadLine();

                        // where operator to search through priority of each ticket type
                        var taskTickets = taskTicketFile.Tickets.Where(t => t.priority.Contains(resp, StringComparison.OrdinalIgnoreCase));

                        var enhanceTickets = enhancementTicketFile.Tickets.Where(e => e.priority.Contains(resp, StringComparison.OrdinalIgnoreCase));

                        var bugTickets = bugTicketFile.Tickets.Where(b => b.priority.Contains(resp, StringComparison.OrdinalIgnoreCase));
                        Console.ForegroundColor = ConsoleColor.Cyan;

                        // three foreach loops to loop through each list and display the tickets that match
                        foreach(Ticket.Task t in taskTickets){
                        Console.WriteLine($"This is a task ticket: {t.Display()}");
                        }

                        foreach(Ticket.Enhancement e in enhanceTickets){
                        Console.WriteLine($"This is a enhancement ticket:  {e.Display()}");
                        }

                        foreach(Ticket.Bug b in bugTickets){
                        Console.WriteLine($"This is a bug ticket: {b.Display()}");
                        }

                        Console.ForegroundColor = ConsoleColor.White;
                        // adds up all tickets with count aggregation method and displays number of results
                        Console.WriteLine($"There are {taskTickets.Count() + enhanceTickets.Count() + bugTickets.Count()} matching results\n\n");

                    }
                    else if(option == "3"){
                        Console.WriteLine("Enter status of ticket to search for");
                        var resp = Console.ReadLine();

                        // where operator to search through submitter of each ticket type
                        var taskTickets = taskTicketFile.Tickets.Where(t => t.submitter.Contains(resp, StringComparison.OrdinalIgnoreCase));

                        var enhanceTickets = enhancementTicketFile.Tickets.Where(e => e.submitter.Contains(resp, StringComparison.OrdinalIgnoreCase));

                        var bugTickets = bugTicketFile.Tickets.Where(b => b.submitter.Contains(resp, StringComparison.OrdinalIgnoreCase));

                        Console.ForegroundColor = ConsoleColor.Cyan;

                        // three foreach loops to loop through each list and display the tickets that match
                        foreach(Ticket.Task t in taskTickets){
                        Console.WriteLine($"This is a task ticket: {t.Display()}");
                        }

                        foreach(Ticket.Enhancement e in enhanceTickets){
                        Console.WriteLine($"This is a enhancement ticket:  {e.Display()}");
                        }

                        foreach(Ticket.Bug b in bugTickets){
                        Console.WriteLine($"This is a bug ticket: {b.Display()}");
                        }

                        Console.ForegroundColor = ConsoleColor.White;
                        // adds up all tickets with count aggregation method and displays number of results
                        Console.WriteLine($"There are {taskTickets.Count() + enhanceTickets.Count() + bugTickets.Count()} matching results\n\n");

                    }
                }
            } while(choice == "1" || choice == "2" || choice == "3" || choice == "4" || choice == "5" || choice == "6" || choice == "7");

            logger.Info("Program has ended");
        }
    }
}
