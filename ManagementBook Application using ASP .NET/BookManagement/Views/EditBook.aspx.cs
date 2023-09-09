using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web.Configuration;
using System.Web.UI;


namespace BookManagement.Views
    {
    public partial class EditBook : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
            {
            if (!IsPostBack)
                {
                int bookID;
                if (int.TryParse(Request.QueryString["BookID"], out bookID))
                    {
                    LoadBookDetails(bookID);
                    PopulateAuthorDropdown();
                    ddlAuthors.SelectedValue = "";
                    }
                else
                    {
                    Response.Redirect("ViewBooks.aspx");
                    }
                }
            }

        private void PopulateAuthorDropdown()
            {
            string connectionString = ConfigurationManager.ConnectionStrings["SMRUTI_db"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
                {
                string query = "SELECT AuthorID, Name FROM Author";
                using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    ddlAuthors.DataSource = reader;
                    ddlAuthors.DataTextField = "Name";
                    ddlAuthors.DataValueField = "AuthorID";
                    ddlAuthors.DataBind();
                    con.Close();
                    }
                }

            }

        private void LoadBookDetails(int bookID)
            {
            string connectionString = ConfigurationManager.ConnectionStrings["SMRUTI_db"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
                {
                string query = "SELECT Book.Title, Book.Price, Book.BookImage, Book.AuthorID FROM Book WHERE Book.BookID = @BookID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                    cmd.Parameters.AddWithValue("@BookID", bookID);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                        {
                        txtTitle.Text = reader["Title"].ToString();
                        txtPrice.Text = reader["Price"].ToString();
                        ddlAuthors.SelectedValue = reader["AuthorID"].ToString();
                        }
                    else
                        {
                        Response.Redirect("ViewBooks.aspx");
                        }
                    reader.Close();
                    }
                }
            }

        protected void btnUpdateBook_Click(object sender, EventArgs e)
            {
            if (Page.IsValid)
                {
                int bookID;
                if (int.TryParse(Request.QueryString["BookID"], out bookID))
                    {
                    string title = txtTitle.Text.Trim();
                    decimal price = Convert.ToDecimal(txtPrice.Text.Trim());
                    int authorID = Convert.ToInt32(ddlAuthors.SelectedValue);

                    string connectionString = WebConfigurationManager.ConnectionStrings["SMRUTI_db"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(connectionString))
                        {
                        string query = "UPDATE Book SET Title = @Title, Price = @Price, AuthorID = @AuthorID";
                        string fileName = null;
                        if (fileBookImage.HasFile)
                            {
                            // If a new image is uploaded, update the image field
                            fileName = Path.GetFileName(fileBookImage.PostedFile.FileName);
                            string filePath = Server.MapPath("~/Images/") + fileName;
                            fileBookImage.SaveAs(filePath);
                            query += ", BookImage = @BookImage";
                            }
                        query += " WHERE BookID = @BookID";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                            {
                            cmd.Parameters.AddWithValue("@BookID", bookID);
                            cmd.Parameters.AddWithValue("@Title", title);
                            cmd.Parameters.AddWithValue("@Price", price);
                            cmd.Parameters.AddWithValue("@AuthorID", authorID);

                            if (fileBookImage.HasFile)
                                {
                                cmd.Parameters.AddWithValue("@BookImage", fileName);
                                }

                            con.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();
                            con.Close();

                            if (rowsAffected > 0)
                                {
                                Response.Redirect("ViewBooks.aspx");
                                }
                            else
                                {
                                // Handle update failure
                                lblErrorMessage.Text = "Failed to update the book. Please try again.";
                                lblErrorMessage.Visible = true;
                                }
                            }
                        }
                    }
                else
                    {
                    Response.Redirect("ViewBooks.aspx");
                    }
                }
            }
        }
    }