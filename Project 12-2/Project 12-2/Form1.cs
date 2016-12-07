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

        int i = 0;
        int n = 0;

        TimeSlot timeSlot;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            options optionsForm = new options();
            optionsForm.ShowDialog();
            timeSlot = optionsForm.GetNewTimeSlot();

            Timer tmr1 = new Timer();
            tmr1.Interval = 1000;
            tmr1.Tick += new EventHandler(tmr1_Tick);
            tmr1.Start();
            lblNextEntry.Text = timeSlot.TimeOpen.ToShortTimeString();

            Timer tmr2 = new Timer();
            tmr2.Interval = 10000;
            tmr2.Tick += new EventHandler(tmr2_Tick);
            tmr2.Start();
;
        }

        private void tmr2_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now > timeSlot.TimeOpen)
            {
                int ticketsOut = i;
                if (ticketsOut > timeSlot.NumTickets)
                {
                    ticketsOut = i - timeSlot.NumTickets;
                }
                else
                    ticketsOut = 0;
                lblTicketsOut.Text = ticketsOut.ToString();
            }
        }

        private void tmr1_Tick(object sender, EventArgs e)
        {
            this.Text = DateTime.Now.ToLongTimeString();
        }


        //Issues tickets and outputs i to tickets outstanding label and may enter label and adds to list
        private void btnIssueTicket_Click(object sender, EventArgs e)
        {
            
            i++;
            lblTicketsOut.Text = i.ToString();

            lblMayEnter.Text = "1 - " + timeSlot.NumTickets;
            if (lblMayEnter.Text == "1 - 1")
            {
                lblMayEnter.Text = "1";
            }
            if (n == timeSlot.NumTickets)
            {
                n = 0;
                timeSlot.TimeOpen = timeSlot.TimeOpen.AddMinutes(timeSlot.MinPer);
                lblNextEntry.Text = timeSlot.TimeOpen.ToShortTimeString();
            }
            n++;
            listTickets.Items.Add("Ticket " + i.ToString() + ": " + lblNextEntry.Text);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            options optionsForm = new options();
            optionsForm.ShowDialog();
            timeSlot = optionsForm.GetNewTimeSlot();
        }

        
    }
}
