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
    public partial class options : Form
    {
        TimeSlot myTimeSlot = new TimeSlot();

        public options()
        {
            InitializeComponent();

            txtMinPer.Text = "5";
            txtGuestsPer.Text = "5";
        
        }
        private void options_Load(object sender, EventArgs e)
        {
            Timer tmr2 = new Timer();
            tmr2.Interval = 1000;
            tmr2.Tick += new EventHandler(tmr2_Tick);
            tmr2.Start();
        }

        private void tmr2_Tick(object sender, EventArgs e)
        {
            this.Text = DateTime.Now.ToLongTimeString();
            string dateTimePicker1 = DateTime.Now.ToLongTimeString();
            string dateTimePicker2 = DateTime.Now.ToLongTimeString();
        }

        public void btnOk_Click(object sender, EventArgs e)
        {
            if (dateTimePicker2.Value < dateTimePicker1.Value)
            {
                MessageBox.Show("Error! End time cannot be before start time", "Time Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                myTimeSlot.TimeOpen = dateTimePicker1.Value;
                myTimeSlot.TimeClosed = dateTimePicker2.Value;
                myTimeSlot.MinPer = Convert.ToInt32(txtMinPer.Text);
                myTimeSlot.NumTickets = int.Parse(txtGuestsPer.Text);

                /*TicketOptions myOptions = TicketOptions.TicketOptions(dateTimePicker1.Value, dateTimePicker2.Value, minPer, guestsPer);
                MessageBox.Show("Time slots: " + this.TimeOpen + "-" + this.TimeClosed +
                    "\n" + "Number of guests: " + this.NumTickets + "\nMinutes per time slot: " + this.MinPer, "Time Slots and Guests",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);*/
                this.Close();
            }  

        }

        public TimeSlot GetNewTimeSlot()
        {
            return myTimeSlot;
        }
    }
}
