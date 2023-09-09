using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace BookManagement.Views
    {
    public partial class AddBook : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
            {
            if (!IsPostBack)
                {
                BindAuthorsDropDown();
                }
            }

        private void BindAuthorsDropDown()
            {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SMRUTI_db"].ConnectionString))
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
                    reader.Close();
                    }
                }
            }

        protected void btnAddBook_Click(object sender, EventArgs e)
            {
            if (Page.IsValid)
                {
                string title = txtTitle.Text.Trim();
                decimal price = Convert.ToDecimal(txtPrice.Text.Trim());
                int authorID = Convert.ToInt32(ddlAuthors.SelectedValue);

                if (fileBookImage.HasFile)
                    {
                    string fileName = Path.GetFileName(fileBookImage.PostedFile.FileName);
                    string filePath = Server.MapPath("~/Images/") + fileName;
                    fileBookImage.SaveAs(filePath);
    
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SMRUTI_db"].ConnectionString))
                        {
                        string query = "INSERT INTO Book (Title, Price, BookImage, AuthorID) VALUES (@Title, @Price, @BookImage, @AuthorID)";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                            {
                            cmd.Parameters.AddWithValue("@Title", title);
                            cmd.Parameters.AddWithValue("@Price", price);
                            cmd.Parameters.AddWithValue("@BookImage", fileName);
                            cmd.Parameters.AddWithValue("@AuthorID", authorID);

                            con.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();
                            con.Close();

                            if (rowsAffected > 0)
                                {
                                lblMessage.Text = "Book added successfully.";
                                ClearForm();
                                }
                            else
                                {
                                lblMessage.Text = "Failed to add the book.";
                                }
                            }
                        }
                    }
                else
                    {
                    lblMessage.Text = "Please select a book image.";
                    }
                }
            }

        private void ClearForm()
            {
            txtTitle.Text = "";
            txtPrice.Text = "";
            ddlAuthors.SelectedIndex = 0;
            fileBookImage.PostedFile.InputStream.Dispose();
            }
        }
    }
