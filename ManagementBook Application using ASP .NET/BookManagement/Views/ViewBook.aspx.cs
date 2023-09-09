using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.WebControls;


namespace BookManagement.Views
    {
    public partial class ViewBook : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
            {
            if (!IsPostBack)
                {
                int bookID;
                if (int.TryParse(Request.QueryString["BookID"], out bookID))
                    {
                    LoadBookDetails(bookID);
                    }
                else
                    {
                    Response.Redirect("ViewBooks.aspx");
                    }
                }
            }

        private void LoadBookDetails(int bookID)
            {
            string connectionString = ConfigurationManager.ConnectionStrings["SMRUTI_db"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
                {
                string query = "SELECT Book.Title, Book.Price, Author.Name AS AuthorName, Book.BookImage FROM Book INNER JOIN Author ON Book.AuthorID = Author.AuthorID WHERE Book.BookID = @BookID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                    cmd.Parameters.AddWithValue("@BookID", bookID);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                        {
                        lblTitle.Text = reader["Title"].ToString();
                        lblPrice.Text = string.Format("{0:C}", reader["Price"]);
                        lblAuthor.Text = reader["AuthorName"].ToString();

                        // Display the book image
                        string imageFileName = reader["BookImage"].ToString();
                        if (!string.IsNullOrEmpty(imageFileName))
                            {
                            imgBook.ImageUrl = "~/Images/" + imageFileName;
                            imgBook.Visible = true;
                            }
                        }
                    else
                        {
                        Response.Redirect("ViewBooks.aspx");
                        }
                    reader.Close();
                    }
                }

            // Set the Edit link's NavigateUrl
            lnkEdit.NavigateUrl = "EditBook.aspx?BookID=" + bookID;
            }

        protected void lnkDelete_Click(object sender, EventArgs e)
            {
            int bookID;
            if (int.TryParse(Request.QueryString["BookId"], out bookID))
                {
                DeleteBook(bookID);
                }
            }

        private void DeleteBook(int bookID)
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
