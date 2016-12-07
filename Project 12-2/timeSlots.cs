using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_12_2
{
    public class TimeSlot
    {
        //variables
        private DateTime tOpen;
        private DateTime tClosed;
        private int minPer;
        private int numTick;

        //default timeslot Constructor that sets the variables
        public TimeSlot()
        {
            this.TimeOpen = DateTime.Now.AddMinutes(1);
            this.TimeClosed = this.TimeOpen.AddHours(2);
            this.MinPer = 5;
            this.NumTickets = 5;
        }

        //Overloaded constructor for timeslot
        public TimeSlot(DateTime timeOpen, DateTime timeClosed, int minPer, int numTickets)
        {
            this.TimeOpen = tOpen;
            this.TimeClosed = tClosed;
            this.MinPer = minPer;
            this.NumTickets = numTickets;
        }

        //Getting and setting the data member variables
      
        public DateTime TimeClosed
        {
            get
            {
                return tClosed;
            }
            set
            {
                tClosed = value;
            }
        }
        public DateTime TimeOpen
        {
            get
            {
                return tOpen;
            }
            set
            {
                tOpen = value;
            }
        }
        
        public int NumTickets
        {
            get
            {
                return numTick;
            }
            set
            {
                numTick = value;
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
    }
}
