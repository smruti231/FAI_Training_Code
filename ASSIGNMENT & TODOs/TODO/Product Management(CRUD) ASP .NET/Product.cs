using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication.TEST
    {
    public class Product
        {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public string ProductImage { get; set; }
        public int StockCount { get; set; } = 100;
        }

    public class ProductManager
        {
        const string STRCONNECTION = @"Data Source=W-674PY03-2;Initial Catalog=SMRUTI_db;Persist Security Info=True;User ID=SA;Password=Password@123456-=";
        //Get all the products from the database.
        static SqlDataAdapter ada = new SqlDataAdapter("SELECT * FROM PRODUCT", STRCONNECTION);
        static SqlCommandBuilder cb = new SqlCommandBuilder(ada);
        static DataSet ds = new DataSet("TempData");



        public DataTable GetAllProducts()
            {
            ds.Tables.Clear();
            ada.FillSchema(ds, SchemaType.Source, "RecordOfProducts");
            ada.Fill(ds, "RecordOfProducts");
            return ds.Tables["RecordOfProducts"];
            }

        //using disconnected model to insert the record..
        public void AddNewProduct(Product product)
            {
            if (ds.Tables["RecordOfProducts"] == null)
                {
                ada.FillSchema(ds, SchemaType.Source, "RecordOfProducts");
                ada.Fill(ds, "RecordOfProducts");
                }

            DataRow row = ds.Tables["RecordOfProducts"].NewRow();
            row["ProductName"] = product.ProductName;
            row["ProductPrice"] = product.ProductPrice;
            row["ProductImage"] = "Images/" + product.ProductImage;
            row["StockCount"] = product.StockCount;

            ds.Tables["RecordOfProducts"].Rows.Add(row);

            ada.Update(ds, "RecordOfProducts");
            }

        public void DeleteProduct(int productId)
            {
            if (ds.Tables["RecordOfProducts"] == null)
                {
                ada.FillSchema(ds, SchemaType.Source, "RecordOfProducts");
                ada.Fill(ds, "RecordOfProducts");
                }

            DataRow rowToDelete = ds.Tables["RecordOfProducts"].Rows.Find(productId);

            if (rowToDelete != null)
                {
                rowToDelete.Delete();
                ada.Update(ds, "RecordOfProducts");
                }
            }

        public bool UpdateProduct(int productId, Product updatedProduct)
            {
            using (SqlConnection con = new SqlConnection(STRCONNECTION))
                {
                con.Open();

                // Define the SQL update query
                string updateQuery = "UPDATE PRODUCT SET ProductName = @ProductName, ProductPrice = @ProductPrice, ProductImage = @ProductImage, StockCount = @StockCount WHERE ProductId = @ProductId";

                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                    {
                    // Add parameters for the update query
                    cmd.Parameters.AddWithValue("@ProductId", productId);
                    cmd.Parameters.AddWithValue("@ProductName", updatedProduct.ProductName);
                    cmd.Parameters.AddWithValue("@ProductPrice", updatedProduct.ProductPrice);
                    cmd.Parameters.AddWithValue("@ProductImage", updatedProduct.ProductImage);
                    cmd.Parameters.AddWithValue("@StockCount", updatedProduct.StockCount);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Check if any rows were affected
                    if (rowsAffected > 0)
                        {
                        return true;    // Update successful
                        }
                    else
                        {
                        return false;   // Product with the specified ID not found
                        }
                    }
                }
            }

        }
    }
