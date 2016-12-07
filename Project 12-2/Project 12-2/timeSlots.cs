using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_12_2
{
    public class TimeSlot
    {

        private DateTime timeOpen;
        private DateTime timeClosed;
        private int minPer;
        private int numTickets;

        public TimeSlot()
        {
            this.TimeOpen = DateTime.Now;
            this.TimeClosed = this.TimeOpen.AddHours(1);
            this.MinPer = 5;
            this.NumTickets = 5;
        }

        public TimeSlot(DateTime timeOpen, DateTime timeClosed, int minPer, int numTickets)
        {
            this.TimeOpen = timeOpen;
            this.TimeClosed = timeClosed;
            this.MinPer = minPer;
            this.NumTickets = numTickets;
        }

        public DateTime TimeOpen
        {
            get
            {
                return timeOpen;
            }
            set
            {
                timeOpen = value;
            }
        }
        public DateTime TimeClosed
        {
            get
            {
                return timeClosed;
            }
            set
            {
                timeClosed = value;
            }
        }
        public int MinPer
        {
            get
            {
                return minPer;
            }
            set
            {
                minPer = value;
            }
        }
        public int NumTickets
        {
            get
            {
                return numTickets;
            }
            set
            {
                numTickets = value;
            }
        }
    }
}
