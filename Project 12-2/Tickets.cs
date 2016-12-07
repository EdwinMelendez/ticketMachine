using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_12_2
{
    class Tickets
    {
        //data member variables
        private DateTime ticketEntryTime;
        private int tickNum;

        public Tickets()
        {

        }

        //Custructor that sets the ticketNumber to this.TicketNumber
        public Tickets(int ticketNum, DateTime ticketEntryTime)
        {
            this.TicketNumber = ticketNum;
            this.TicketEntryTime = ticketEntryTime;
        }

        //Getting and setting of the data members
        public DateTime TicketEntryTime
        {
            get
            {
                return ticketEntryTime;
            }
            set
            {
                ticketEntryTime = value;
            }
        }

        public int TicketNumber
        {
            get
            {
                return tickNum;
            }
            set
            {
                tickNum = value;
            }
        }

        //Displaying the ticket information
        public string GetDisplayString()
        {
            string ticketIssueTime = this.TicketEntryTime.ToShortTimeString();
            string ticketString = "Ticket " + this.TicketNumber + ": " + ticketIssueTime;
            return ticketString;
        }
    }
}
