using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;


namespace BookManagement.Views
    {
    public partial class DeleteBook : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
            {
            if (!IsPostBack)
                {
                int bookID;
                if (int.TryParse(Request.QueryString["BookID"], out bookID))
                    {
                    // Store the book ID in a ViewState variable for later use
                    ViewState["BookID"] = bookID;
                    }
                else
                    {
                    Response.Redirect("ViewBooks.aspx");
                    }
                }
            }

        protected void lnkDelete_Click(object sender, EventArgs e)
            {
            int bookID;
            if (int.TryParse(Request.QueryString["BookID"], out bookID))
                {
                Console.WriteLine(bookID);
                //DeleteDBBook(bookID);
                }
            }

        private void DeleteDBBook(int bookID)
            {
            string connectionString = ConfigurationManager.ConnectionStrings["SMRUTI_db"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
                {
                string query = "DELETE FROM Book WHERE BookID = @BookID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                    cmd.Parameters.AddWithValue("@BookID", bookID);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();

                    if (rowsAffected > 0)
                        {
                        // Delete successful, redirect to the book list page (ViewBooks.aspx)
                        Response.Redirect("ViewBooks.aspx");
                        }
                    else
                        {
                        // Handle delete failure
                        lblErrorMessage.Text = "Failed to delete the book. Please try again.";
                        lblErrorMessage.Visible = true;
                        }
                    }
                }
            }
        }
    }