using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;


namespace BookManagement.Views
    {
    public partial class ViewBooks : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
            {
            if (!IsPostBack)
                {
                // Populate the dropdown list with authors from the database
                BindAuthorsDropDown();

                // Load all books initially
                LoadBooks();
                //PopulateAuthorDropdown();
                LoadAllBooks();
                
                }
            }

        private void LoadAllBooks()
            {
            string connectionString = ConfigurationManager.ConnectionStrings["SMRUTI_db"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
                {
                string query = "SELECT Book.BookID, Book.Title, Book.Price, Author.Name AS AuthorName FROM Book INNER JOIN Author ON Book.AuthorID = Author.AuthorID";
                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gvBooks.DataSource = dt;
                    gvBooks.DataBind();
                    }
                }

            }

        private void BindAuthorsDropDown()
            {
            string connectionString = ConfigurationManager.ConnectionStrings["SMRUTI_db"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
                {
                string query = "SELECT AuthorID, Name FROM Author";
                using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    ddlSearchAuthor.DataSource = reader;
                    ddlSearchAuthor.DataTextField = "Name";
                    ddlSearchAuthor.DataValueField = "AuthorID";
                    ddlSearchAuthor.DataBind();
                    reader.Close();
                    }
                }
            }

        private void LoadBooks()
            {
            string connectionString = ConfigurationManager.ConnectionStrings["SMRUTI_db"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
                {
                string query = "SELECT Book.BookID, Book.Title, Book.Price, Author.Name AS AuthorName FROM Book INNER JOIN Author ON Book.AuthorID = Author.AuthorID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                    // Add search criteria if specified
                    if (!string.IsNullOrWhiteSpace(txtSearchTitle.Text))
                        {
                        query += " WHERE Book.Title LIKE @Title";
                        cmd.Parameters.AddWithValue("@Title", "%" + txtSearchTitle.Text + "%");
                        }
                    if (!string.IsNullOrWhiteSpace(ddlSearchAuthor.SelectedValue))
                        {
                        if (query.Contains("WHERE"))
                            {
                            query += " AND";
                            }
                        else
                            {
                            query += " WHERE";
                            }
                        query += " Book.AuthorID = @AuthorID";
                        cmd.Parameters.AddWithValue("@AuthorID", ddlSearchAuthor.SelectedValue);
                        }

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    gvBooks.DataSource = dt;
                    gvBooks.DataBind();
                    }
                }
            }

        protected void lnkDelete_Click(object sender, EventArgs e)
                {
                LinkButton lnkDelete = (LinkButton)sender;
                int bookID = Convert.ToInt32(lnkDelete.CommandArgument);
                string connectionString = ConfigurationManager.ConnectionStrings["SMRUTI_db"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                    {
                    con.Open();
                    string query = "DELETE FROM Book WHERE BookID = @BookID";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                        cmd.Parameters.AddWithValue("@BookID", bookID);
                        cmd.ExecuteNonQuery();
                        }
                    con.Close();
                    }
                BindGridView();
                }

        private void BindGridView()
            {
            string connectionString = ConfigurationManager.ConnectionStrings["SMRUTI_db"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
                {
                string query = "SELECT Book.BookID, Book.Title, Book.Price, Author.Name AS AuthorName FROM Book INNER JOIN Author ON Book.AuthorID = Author.AuthorID";

                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    gvBooks.DataSource = dt;
                    gvBooks.DataBind();
                    }
                }
            }


        protected void btnSearchTitle_Click(object sender, EventArgs e)
            {
            string searchTitle = txtSearchTitle.Text.Trim();
            SearchBooksByTitle(searchTitle);
            }

        private void SearchBooksByTitle(string searchTitle)
            {
            string connectionString = ConfigurationManager.ConnectionStrings["SMRUTI_db"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
                {
                string query = "SELECT Book.BookID, Book.Title, Book.Price, Author.Name AS AuthorName FROM Book INNER JOIN Author ON Book.AuthorID = Author.AuthorID WHERE Title LIKE @Title";
                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                    da.SelectCommand.Parameters.AddWithValue("@Title", "%" + txtSearchTitle.Text + "%");
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gvBooks.DataSource = dt;
                    gvBooks.DataBind();
                    }
                }

            }

        protected void btnSearchAuthor_Click(object sender, EventArgs e)
            {
            int authorID = Convert.ToInt32(ddlSearchAuthor.SelectedValue);
            SearchBooksByAuthor(authorID);
            }

        private void SearchBooksByAuthor(int authorID)
            {
            string connectionString = ConfigurationManager.ConnectionStrings["SMRUTI_db"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
                {
                string query = "SELECT Book.BookID, Book.Title, Book.Price, Author.Name AS AuthorName FROM Book INNER JOIN Author ON Book.AuthorID = Author.AuthorID WHERE Book.AuthorID = @AuthorID";
                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                    da.SelectCommand.Parameters.AddWithValue("@AuthorID", authorID);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gvBooks.DataSource = dt;
                    gvBooks.DataBind();
                    }
                }
            }

        protected void gvBooks_PageIndexChanging(object sender, GridViewPageEventArgs e)
            {
            gvBooks.PageIndex = e.NewPageIndex;
            BindGridView();
            }
        }
    }
