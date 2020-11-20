using LeafFilter.HelpDesk.Data;
using LeafFilter.HelpDesk.Models.Records;
using LeafFilter.HelpDesk.Models.Types;
using System;

namespace LeafFilter.HelpDesk.TestConsole
{
    public class Program
    {
        private static HelpDeskContext _context = new HelpDeskContext();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Help Desk Tracking!");
            InsertNewTicket();
        }

        private static void InsertNewTicket()
        {
            var ticket = new Ticket
            {

                RequestedBy = new User
                {
                    FirstName = "Glenn",
                    LastName = "Weber",
                    Email = "gweber@leaffilter.com"
                },
                AssignedTo = new User
                {
                    FirstName = "James",
                    LastName = "Kelly",
                    Email = "jkelly@leaffilter.com"
                },
                DateOpen = DateTime.Now
            };
            _context.Add(ticket);
            _context.SaveChanges();
        }
    }
}
