using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication.TEST
    {
    public partial class DataApp : System.Web.UI.Page
        {
        protected void Page_Load(object sender, EventArgs e)
            {
            if (!IsPostBack)
                {
                BindGridView(); // Bind GridView on initial page load
                }
            }

        private void BindGridView()
            {
            var obj = new ProductManager();
            grdProducts.DataSource = obj.GetAllProducts();
            grdProducts.DataBind();
            }

        protected void btnAdd_Click(object sender, EventArgs e)
            {
            try
                {
                var obj = new ProductManager();
                var product = new Product
                    {
                    ProductPrice = int.Parse(txtNewCost.Text),
                    ProductName = txtNewName.Text,
                    ProductImage = txtNewImage.Text,
                    };
                obj.AddNewProduct(product);
                lblStatus.Text = "Product added Successfully";
                BindGridView(); // Refresh the GridView after adding a product

                txtNewName.Text = " ";
                txtNewCost.Text = " ";
                txtNewImage.Text = " ";
                }
            catch (Exception ex)
                {
                lblStatus.Text = ex.Message;
                }
            }

        protected void grdProducts_RowCommand(object sender, GridViewCommandEventArgs e)
            {
            if (e.CommandName == "DeleteProduct")
                {
                try
                    {
                    int productId = Convert.ToInt32(e.CommandArgument);
                    var obj = new ProductManager();
                    obj.DeleteProduct(productId);
                    lblStatus.Text = "Product deleted Successfully";
                    BindGridView(); // Refresh the GridView after deletion
                    }
                catch (Exception ex)
                    {
                    lblStatus.Text = ex.Message;
                    }
                }
            }

        protected void btnUpdate_Click(object sender, EventArgs e)
            {
            try
                {
                int productId = int.Parse(txtId.Text);
                var obj = new ProductManager();
                var product = new Product
                    {
                    ProductName = txtUpdatedName.Text,
                    ProductPrice = int.Parse(txtUpdatedCost.Text),
                    ProductImage = "Images/" + txtUpdatedImage.Text,
                    };

                if (obj.UpdateProduct(productId, product))
                    {
                    lblStatus.Text = "Product updated Successfully";
                    BindGridView(); // Refresh the GridView after updating

                    txtId.Text = " ";
                    txtUpdatedName.Text = " ";
                    txtUpdatedCost.Text = " ";
                    txtUpdatedImage.Text = " ";
                    }
                else
                    {
                    lblStatus.Text = "Product with the specified ID not found";
                    }
                }
            catch (Exception ex)
                {
                lblStatus.Text = ex.Message;
                }
            }

        }
    }