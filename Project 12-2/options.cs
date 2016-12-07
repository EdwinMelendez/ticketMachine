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
        TimeSlot myTimeSlot = new TimeSlot(); //instantiates new timeslot object

        public options()
        {
            InitializeComponent();

            //Sets the default values of the textboxes
            txtFirstTicketNum.Text = "1";
            txtMinPer.Text = "5";
            txtGuestsPer.Text = "5";
        
        }

        //Sets the timer, datetimepicker, and datetimepicker format
        private void options_Load(object sender, EventArgs e)
        {
            Timer tmr2 = new Timer();
            tmr2.Interval = 100;
            tmr2.Tick += new EventHandler(tmr2_Tick);
            tmr2.Start();

            dateTimePicker1.Value = DateTime.Now.AddMinutes(1);
            dateTimePicker2.Value = DateTime.Now.AddHours(4);

            dateTimePicker1.CustomFormat = ("h:mm tt");
            dateTimePicker2.CustomFormat = ("h:mm tt");
        }


        //Sets the now datetime to display on the form
        private void tmr2_Tick(object sender, EventArgs e)
        {
            this.Text = DateTime.Now.ToLongTimeString();
        }

        //The ok button
        public void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                int minutesPerTextBox = Convert.ToInt32(txtMinPer.Text);
                int guestPerTextBox = Convert.ToInt32(txtGuestsPer.Text);
                int firstTicketNumTextBox = Convert.ToInt32(txtFirstTicketNum.Text);

                //data validation
                if (minutesPerTextBox <= 0)
                {
                    MessageBox.Show("Minutes Must Be Greater Than Zero", "Minutes Per Window Textbox Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (guestPerTextBox <= 0)
                {
                    MessageBox.Show("Guests Must Be Greater Than Zero", "Guests Per Window Textbox Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (firstTicketNumTextBox <= 0)
                {
                    MessageBox.Show("First Ticket Number Must Be Greater Than Zero", "First Ticket Number Textbox Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (dateTimePicker2.Value < dateTimePicker1.Value)
                {
                    MessageBox.Show("Datetime Error! End Time Cannot Be Before Start Time", "Datetime Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //Sets the objects to the designated values of the options form
                    myTimeSlot.TimeOpen = dateTimePicker1.Value;
                    myTimeSlot.TimeClosed = dateTimePicker2.Value;
                    myTimeSlot.MinPer = Convert.ToInt32(txtMinPer.Text);
                    myTimeSlot.NumTickets = int.Parse(txtGuestsPer.Text);

                  
                    this.Close();

                    

                }
            }
            catch
            {
                MessageBox.Show("You must enter a number", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public TimeSlot GetNewTimeSlot()
        {
            return myTimeSlot;
        }
    }
}
