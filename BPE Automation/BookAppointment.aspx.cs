using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BPE_Automation
{
    public partial class BookAppointment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
       

        }
     
        protected void calDate_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < DateTime.Today || e.Day.Date.DayOfWeek == DayOfWeek.Saturday || e.Day.Date.DayOfWeek == DayOfWeek.Sunday)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Gray;
            }
      
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = calDate.SelectedDate;
            TimeSpan selectedTime = TimeSpan.Parse(time.SelectedValue);
            // Get the selected date and time from the calendar and drop-down list
            if (!CNICBooked(selectedDate))
            {
            
                if (IsTimeSlotBooked(selectedDate, selectedTime))
                {

                }
                else
                {
                    string connectionString = WebConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Insert the appointment into the database
                        string query = "INSERT INTO appointments (day, start_time,CNIC,Name_) VALUES (@day, @startTime,@Cnic,@name)";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@day", selectedDate.ToString());
                            command.Parameters.AddWithValue("@startTime", selectedTime.ToString());
                            command.Parameters.AddWithValue("@name", name.Text.ToString());
                            command.Parameters.AddWithValue("@Cnic", cnic.Text.ToString());
                            command.ExecuteNonQuery();
                        }

                    }
                    Response.Write("<script>alert('Appointment Booked'); window.location.href=window.location.href;</script>");

                }
            }
            else
            {
                Response.Write("<script>alert('CNIC Already Booked For the Day'); window.location.href=window.location.href;</script>");
            }

        }
        private bool IsTimeSlotBooked(DateTime date, TimeSpan startTime)
        {
            // Connect to the database
            string connectionString = WebConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Check if there is an appointment for the selected date and start time
                string query = "SELECT COUNT(*) FROM appointments WHERE day = @date AND start_time = @startTime";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@date", date.ToString());
                    command.Parameters.AddWithValue("@startTime", startTime.ToString());

                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private bool CNICBooked(DateTime date)
        {
            // Connect to the database
            string connectionString = WebConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Check if there is an appointment for the selected date and start time
                string query = "SELECT COUNT(*) FROM appointments WHERE day = @date AND cnic = @startTime";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@date", date.ToString());
                    command.Parameters.AddWithValue("@startTime", cnic.Text.ToString());

                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }


        protected void calDate_SelectionChanged(object sender, EventArgs e)
        {
            // Get the selected date
            DateTime selectedDate = calDate.SelectedDate;

            // Check if the selected date is a Friday
            bool isFriday = selectedDate.DayOfWeek == DayOfWeek.Friday;

            // Set the start and end times based on the day of the week
            TimeSpan startTime = isFriday ? new TimeSpan(9, 0, 0) : new TimeSpan(9, 0, 0);
            TimeSpan endTime = isFriday ? new TimeSpan(12, 30, 0) : new TimeSpan(14, 0, 0);

            // Clear the current items in the time drop-down list
            time.Items.Clear();

            // Add the time slots to the drop-down list
            while (startTime <= endTime)
            {
                // Check if the time slot is already booked
                bool isBooked = IsTimeSlotBooked(selectedDate, startTime);

                // Add the time slot to the drop-down list if it is not already booked
                if (!isBooked)
                {
                    time.Items.Add(startTime.ToString());
                }

                // Increment the start time by 15 minutes
                startTime = startTime.Add(new TimeSpan(0, 15, 0));
            }

        }
    }
}