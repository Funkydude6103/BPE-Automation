using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BPE_Automation
{
    public partial class CutomerSupport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Insert the appointment into the database
                string query = "INSERT INTO support (name_, email,cnic,query) VALUES (@name, @email,@cnic,@query)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name.Text.ToString());
                    command.Parameters.AddWithValue("@email", email.Text.ToString());
                    command.Parameters.AddWithValue("@cnic", cnic.Text.ToString());
                    command.Parameters.AddWithValue("@query", txtMessage.Text.ToString());
                    command.ExecuteNonQuery();
                }

            }
            Response.Write("<script>alert('Request Sent our Agent will Reply you soon'); window.location.href=window.location.href;</script>");

        }
    }
}