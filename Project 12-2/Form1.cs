using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_12_2
{

    public partial class Form1 : Form
    {
        //Variables
        int issue = 0;
        int num = 0;
        TimeSlot timeSlot;
        List<Tickets> ticketList = new List<Tickets>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //When app starts it displays the options form first
            options optionsForm = new options();
            optionsForm.ShowDialog();

            //timeslot object gets the timeslot from the options form
            timeSlot = optionsForm.GetNewTimeSlot();

            //Timers that keep the current time updated and removes items from listbox when timeslot has passed
           
            Timer tmr1 = new Timer(); //creates new timer
            tmr1.Interval = 100;
            tmr1.Tick += new EventHandler(tmr1_Tick);
            tmr1.Start(); //starts timer
            lblNextEntry.Text = timeSlot.TimeOpen.ToShortTimeString();

            Timer tmr2 = new Timer(); //new timer object
            tmr2.Interval = 100;
            tmr2.Tick += new EventHandler(tmr2_Tick);
            tmr2.Start();
        }

        private void tmr2_Tick(object sender, EventArgs e)
        {
            //Determines if current time is past timeslot and removes the tickets
            if (DateTime.Now > timeSlot.TimeOpen)
            {
                decimal outTickets = Convert.ToDecimal(lblTicksOut.Text); //creates local variable outTickets, gets lblticksout text
                if (outTickets > timeSlot.NumTickets) //if outtickets is greater than time
                {
                    Tickets firstTicket = ticketList.First(); 
                    int mayEnterStart = firstTicket.TicketNumber; //opens first ticket to start
                    int mayEnterEnd = mayEnterStart + timeSlot.NumTickets - 1;
                    if (mayEnterStart == mayEnterEnd)
                    {
                        lblMayEnter.Text = mayEnterStart.ToString();
                    }
                    else
                    {
                        lblMayEnter.Text = mayEnterStart + " - " + mayEnterEnd;
                    }
                    ticketList.RemoveRange(0, timeSlot.NumTickets); //removes tickets that have entered
                    outTickets = ticketList.Count; //counts outTickets
                    lblTicksOut.Text = outTickets.ToString();
                }
                else //if tickets are less than time
                {
                    Tickets firstTicket = ticketList.First();
                    Tickets lastTicket = ticketList.Last();
                    int mayEnterStart = firstTicket.TicketNumber;
                    int mayEnterEnd = lastTicket.TicketNumber;
                    if (mayEnterStart == mayEnterEnd)
                    {
                        lblMayEnter.Text = mayEnterStart.ToString();
                    }
                    else
                    {
                        lblMayEnter.Text = mayEnterStart + " - " + mayEnterEnd;
                    }
                    ticketList.Clear(); //clears ticketlist
                }
                timeSlot.TimeOpen = timeSlot.TimeOpen.AddMinutes(timeSlot.MinPer);
                listTickets.Items.Clear();
                num = num - timeSlot.NumTickets;

                //Displays each of the outstanding tickets
                foreach (Tickets ticket in ticketList)
                {
                    listTickets.Items.Add(ticket.GetDisplayString());
                }
            }
        }

        //Code for displaying the open or closed text depending on the datetime and timeslots
        private void tmr1_Tick(object sender, EventArgs e)
        {
            if (timeSlot.TimeOpen < DateTime.Now) //opens or closes using the timer tick
                this.Text = DateTime.Now.ToLongTimeString() + "(Open)";
            else
                this.Text = DateTime.Now.ToLongTimeString() + "(Closed)";
        }



        private void btnOptions_Click(object sender, EventArgs e)
        {
            //Displays yes or no dialog box to see if user wants to clear all selected options
            DialogResult myDialogResult = MessageBox.Show("All current options will be cleared \n" + "Are you sure you want to select new options?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            //if statement, that if yes clears form and then opens the options form
            if (myDialogResult == DialogResult.Yes)
            {
                issue = 0; //resets values
                num = 0;
                ticketList = new List<Tickets>(); //creates new tickets list
                lblMayEnter.Text = "";
                lblNextEntry.Text = "";
                lblTicksOut.Text = "";
                listTickets.Items.Clear();

                options optionsForm = new options(); //opens options form
                optionsForm.ShowDialog();
                timeSlot = optionsForm.GetNewTimeSlot();
            }
        }

        //Issues tickets and outputs i to tickets outstanding label and may enter label and adds to list
        private void btnIssueTicket_Click(object sender, EventArgs e)
        {
            issue++; //counts number of times issue tickets is pressed
            int timeSlotsFull = num / timeSlot.NumTickets; 
            num++; //counts time slots
            DateTime currentEntry = timeSlot.TimeOpen.AddMinutes(timeSlot.MinPer * timeSlotsFull); //adds current date time to issued ticket
            Tickets newTicket = new Tickets(issue, currentEntry); //creates a new ticket object, passes issue value and current entry time
            if (issue % timeSlot.NumTickets == 0)//returns value thats left over after dividing right operand into left(if it equates to 0)
            {
                DateTime nextEntry = currentEntry.AddMinutes(timeSlot.MinPer);
                lblNextEntry.Text = nextEntry.ToShortTimeString();
            }
            ticketList.Add(newTicket); //adds ticket

            lblTicksOut.Text = ticketList.Count.ToString(); //counts tickets and displays in lblticksout
            listTickets.Items.Clear();
            foreach (Tickets ticket in ticketList)
            {
                listTickets.Items.Add(ticket.GetDisplayString());
            }

        }

        //The Exit Button
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();//closes app
        }
    }
}
