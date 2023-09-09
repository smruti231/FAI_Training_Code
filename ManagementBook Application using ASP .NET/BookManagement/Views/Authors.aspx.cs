using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace BookManagement.Views
    {
    public partial class Authors : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
            {
            if (!IsPostBack)
                {
                LoadAuthors();
                }
            }

        private void LoadAuthors()
            {
            string connectionString = ConfigurationManager.ConnectionStrings["SMRUTI_db"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
                {
                string query = "SELECT AuthorID, Name, Age, Country FROM Author";
                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    GridViewAuthors.DataSource = dt;
                    GridViewAuthors.DataBind();
                    }
                }
            }

        protected void btnAddAuthor_Click(object sender, EventArgs e)
            {
            Response.Redirect("AddAuthor.aspx");
            }

        protected void GridViewAuthors_RowEditing(object sender, GridViewEditEventArgs e)
            {
            GridViewAuthors.EditIndex = e.NewEditIndex;
            LoadAuthors();
            }

        protected void GridViewAuthors_RowUpdating(object sender, GridViewUpdateEventArgs e)
            {
            GridViewRow row = GridViewAuthors.Rows[e.RowIndex];
            int authorID = Convert.ToInt32(GridViewAuthors.DataKeys[e.RowIndex].Values["AuthorID"]);
            string name = ((TextBox)row.FindControl("txtEditName")).Text;
            int age = Convert.ToInt32(((TextBox)row.FindControl("txtEditAge")).Text);
            string country = ((TextBox)row.FindControl("txtEditCountry")).Text;

            UpdateAuthor(authorID, name, age, country);

            GridViewAuthors.EditIndex = -1;
            LoadAuthors();
            }

        protected void GridViewAuthors_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
            {
            GridViewAuthors.EditIndex = -1;
            LoadAuthors();
            }

        protected void GridViewAuthors_RowDeleting(object sender, GridViewDeleteEventArgs e)
            {
            int authorID = Convert.ToInt32(GridViewAuthors.DataKeys[e.RowIndex].Values["AuthorID"]);

            DeleteAuthor(authorID);
            LoadAuthors();
            }

        private void UpdateAuthor(int authorID, string name, int age, string country)
            {
            string connectionString = ConfigurationManager.ConnectionStrings["SMRUTI_db"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
                {
                string query = "UPDATE Author SET Name = @Name, Age = @Age, Country = @Country WHERE AuthorID = @AuthorID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                    cmd.Parameters.AddWithValue("@AuthorID", authorID);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.Parameters.AddWithValue("@Country", country);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    }
                }
            }

        private void DeleteAuthor(int authorID)
            {
            string connectionString = ConfigurationManager.ConnectionStrings["SMRUTI_db"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
                {
                string query = "DELETE FROM Author WHERE AuthorID = @AuthorID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                    cmd.Parameters.AddWithValue("@AuthorID", authorID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    }
                }
            }
        }
    }


