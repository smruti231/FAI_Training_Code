using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookManagement.Views
    {
    public partial class AddAuthor : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
            {

            }

        protected void btnAddAuthor_Click(object sender, EventArgs e)
            {
            string name = txtName.Text.Trim();
            int age = 0;
            if (int.TryParse(txtAge.Text.Trim(), out int parsedAge))
                {
                age = parsedAge;
                }
            string country = txtCountry.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || age <= 0 || string.IsNullOrWhiteSpace(country))
                {
                lblErrorMessage.Text = "Please fill in all fields correctly.";
                lblErrorMessage.Visible = true;
                return;
                }

            // Add the new author to the database
            if (AddNewAuthor(name, age, country))
                {
                lblSuccessMessage.Text = "Author added successfully!";
                lblSuccessMessage.Visible = true;

                // Clear the input fields
                txtName.Text = string.Empty;
                txtAge.Text = string.Empty;
                txtCountry.Text = string.Empty;
                }
            else
                {
                lblErrorMessage.Text = "Failed to add author. Please try again.";
                lblErrorMessage.Visible = true;
                }
            }

        private bool AddNewAuthor(string name, int age, string country)
            {
            string connectionString = ConfigurationManager.ConnectionStrings["SMRUTI_db"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
                {
                string query = "INSERT INTO Author (Name, Age, Country) VALUES (@Name, @Age, @Country)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.Parameters.AddWithValue("@Country", country);
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();

                    return rowsAffected > 0;
                    }
                }
            }
        }
    }
