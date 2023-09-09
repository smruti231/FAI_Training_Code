using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookManagement.Views
    {
    public partial class AuthorDetails : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
            {
            if (!IsPostBack)
                {
                if (Request.QueryString["authorID"] != null)
                    {
                    int authorID = Convert.ToInt32(Request.QueryString["authorID"]);
                    LoadAuthorDetails(authorID);
                    LoadBooksByAuthor(authorID);
                    }
                else
                    {
                    Response.Redirect("Author.aspx");
                    }
                }
            }

        private void LoadAuthorDetails(int authorID)
            {
            string connectionString = ConfigurationManager.ConnectionStrings["SMRUTI_db"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
                {
                string query = "SELECT Name, Age, Country FROM Author WHERE AuthorID = @AuthorID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                    cmd.Parameters.AddWithValue("@AuthorID", authorID);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                        {
                        lblAuthorName.Text = "Author Name: " + reader["Name"].ToString();
                        lblAuthorAge.Text = "Age: " + reader["Age"].ToString();
                        lblAuthorCountry.Text = "Country: " + reader["Country"].ToString();
                        }
                    else
                        {
                        Response.Redirect("Author.aspx");
                        }
                    reader.Close();
                    }
                }
            }

        private void LoadBooksByAuthor(int authorID)
            {
            string connectionString = ConfigurationManager.ConnectionStrings["SMRUTI_db"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
                {
                string query = "SELECT BookID, Title, Price, BookImage FROM Book WHERE AuthorID = @AuthorID";
                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                    da.SelectCommand.Parameters.AddWithValue("@AuthorID", authorID);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridViewBooks.DataSource = dt;
                    GridViewBooks.DataBind();
                    }
                }
            }

        protected void GridViewBooks_RowDataBound(object sender, GridViewRowEventArgs e)
            {
            if (e.Row.RowType == DataControlRowType.DataRow)
                {
                Image imgBook = e.Row.FindControl("imgBook") as Image;
                Literal litImageName = e.Row.FindControl("litImageName") as Literal;

                if (imgBook != null && litImageName != null)
                    {
                    string imageFileName = litImageName.Text;
                    if (!string.IsNullOrEmpty(imageFileName))
                        {
                        // Assuming your book images are stored in a folder named "Images"
                        imgBook.ImageUrl = "~/Images/" + imageFileName;
                        }
                    else
                        {
                        // Set a default image URL or placeholder image URL
                        imgBook.ImageUrl = "~/Images/NoImage.png"; // Change this to a suitable default image path
                        }
                    }
                }
            }
        }
    }

