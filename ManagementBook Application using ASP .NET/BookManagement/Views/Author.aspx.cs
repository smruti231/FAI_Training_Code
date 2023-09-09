using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookManagement.Views
    {
    public partial class Author : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
            {
            if (!IsPostBack)
                {
                // Load authors when the page loads
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
        }
    }
