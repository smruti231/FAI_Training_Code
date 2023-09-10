using Proj1_SampleConApp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDB
    {
    class BookData
        {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public int BookIsbn { get; set; }

        public int? authId { get; set; }
        }

    interface IBookDb
        {
        void AddBook(string BookName, string BookAuthor, int BookIsbn, int authId);
        void UpdateBook(int v1, BookData data);

        void DeleteBook(int id);

        BookData FindBook(int BookId);
        }

    class BookTable : IBookDb
        {
        public object BookId { get; private set; }
        public string STRCONNECTION { get; internal set; }
        public BookData BookData { get; private set; }

        public void AddBook(string BookName, string BookAuthor, int BookIsbn, int authId)
            {
            string query = $"Insert into BookDB values('{BookName}','{BookAuthor}','{BookIsbn}','{authId}')";
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(query, con);
            try
                {
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                    {
                    Console.WriteLine("Book Inserted Successfully");
                    }
                }
            catch (SqlException ex)
                {
                Console.WriteLine(ex.Message);
                }
            finally
                {
                con.Close();
                }
            }

        public void DeleteBook(int BookId)
            {
            string query = $"Delete from BookDB where BookId = {BookId}";
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(query, con);
            try
                {
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                    {
                    Console.WriteLine("Book Deleted Successfully");
                    }
                }
            catch (SqlException ex)
                {
                Console.WriteLine(ex.Message);
                }
            finally
                {
                con.Close();
                }
            }

        public BookData FindBook(int BookId)
            {
            string query = $"SELECT * From BookDB where BookId = {BookId}";

            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(query, con);
            try
                {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                    {
                    BookData = new BookData
                        {
                        BookId = Convert.ToInt32(reader["BookId"]),
                        BookName = reader["BookName"].ToString(),
                        BookAuthor = reader["BookAuthor"].ToString(),
                        BookIsbn = Convert.ToInt32(reader["BookIsbn"]),
                        authId = reader["authId"] == DBNull.Value ? null : (int?)Convert.ToInt32(reader["authId"])
                        };
                    }
                else
                    {
                    Console.WriteLine("Book Not found");
                    }
                }
            catch (SqlException ex)
                {
                Console.WriteLine(ex.Message);
                }
            finally
                {
                con.Close();
                }
            return BookData;
            }

        public void UpdateBook(int v1, BookData data)
            {
            string query = $"Update BookDB Set BookName = '{data.BookName}', BookAuthor = '{data.BookAuthor}', BookIsbn = '{data.BookIsbn}', authId = '{data.authId}' where BookId = {data.BookId}";
            SqlConnection con = new SqlConnection(STRCONNECTION);
            SqlCommand cmd = new SqlCommand(query, con);
            try
                {
                con.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows == 1)
                    {
                    Console.WriteLine("Book Updated Successfully");
                    }
                }
            catch (SqlException ex)
                {
                Console.WriteLine(ex.Message);
                }
            finally
                {
                con.Close();
                }
            }
        }

        class Program
        {
            const string fileName = @"C:\Users\sranjanpolai\source\repos\BookMgmt\BookDB\Menu.txt";

            const string STRSELECT = "SELECT * FROM BookDB";
            const string STRCONNECTION = "Data Source = W-674PY03-2; Initial Catalog = SMRUTI_db; User ID = SA; Password = Password@123456-=";
     
            static BookTable BookTable = new BookTable() { STRCONNECTION = STRCONNECTION };
            static void Main(string[] args)
                {
                string content = File.ReadAllText(fileName);
                var processing = true;
                do
                    {
                    string choice = Utilities.GetString(content).ToUpper();
                    processing = processMenu(choice);
                    } while (processing);
                }

            private static bool processMenu(string choice)
                {
                switch (choice)
                    {
                    case "N":
                        return addingHelper();
                    case "U":
                        return updatingHelper();
                    case "F":
                        return findingHelper();
                    case "D":
                        return deleteHelper();
                    default:
                        return true; ;
                    }
                }


            private static bool addingHelper()
                {
                string BookName = Utilities.GetString("Enter the Book Name: ");
                string BookAuthor = Utilities.GetString("Enter the Author Name: ");
                int BookIsbn = Utilities.GetInteger("Enter the ISBN Number: ");
                int authId = Utilities.GetInteger("Enter the Author Id: ");

                BookTable.AddBook(BookName, BookAuthor, BookIsbn, authId);
                return true;
                }

            private static bool updatingHelper()
                {
                int BookId = Utilities.GetInteger("Enter the Book ID to update: ");

                string BookName = Utilities.GetString("Enter the updated Name of Book: ");
                string BookAuthor = Utilities.GetString("Enter the updated Author Name: ");
                int BookIsbn = Utilities.GetInteger("Enter the updated ISBN Number: ");
                int authId = Utilities.GetInteger("Enter the updated Author Id: ");

                BookData updatedData = new BookData
                    {
                    BookId = BookId,
                    BookName = BookName,
                    BookAuthor = BookAuthor,
                    BookIsbn = BookIsbn,
                    authId = authId
                    };
                BookTable.UpdateBook(BookId, updatedData);
                Console.WriteLine("Book updated successfully");
                return true;
                }


            private static bool deleteHelper()
                {
                int BookId = Utilities.GetInteger("Enter the Book ID to delete: ");
                BookTable.DeleteBook(BookId);
                Console.WriteLine("Book Deleted Successfully");
                return true;
                }

            private static bool findingHelper()
                {
                int BookId = Utilities.GetInteger("Enter the Book ID to find: ");
                BookData BookloyeeData = BookTable.FindBook(BookId);
                BookTable.FindBook(BookId);

                if (BookloyeeData != null)
                    {
                    Console.WriteLine($"Book Name: {BookloyeeData.BookName}");
                    Console.WriteLine($"Author Name: {BookloyeeData.BookAuthor}");
                    Console.WriteLine($"ISBN Number: {BookloyeeData.BookIsbn}");
                    Console.WriteLine($"Author Id: {BookloyeeData.authId}");
                    }
                else
                    {
                    Console.WriteLine("Book Not Found");
                    }
                return true;
                }
            }
        }
  