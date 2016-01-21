namespace MSSQL
{
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Data.OleDb;
    
    public class Program
    {
        public static void Main()
        {
            SqlConnection sqlServerConnection = new SqlConnection("Server=.\\SQLExpress;" +
                                                           "Database=Northwind;" +
                                                           "Integrated Security=true");
            sqlServerConnection.Open();

            string connectionString = @"Provider= Microsoft.ACE.OLEDB.12.0;Data Source = ..\..\excel\exams.xlsx;Extended Properties = ""Excel 12.0 Xml;HDR=YES"";";            

            using (sqlServerConnection)
            {
                //Task 1.Write a program that retrieves from the Northwind sample database in MS SQL Server the number of rows in the Categories table.
                Console.WriteLine("--- Task 1 ---\n");
                Console.WriteLine("DB Northwind -> Categories:  {0} row(s)!", RetrieveNumberOfRowsInTable("Categories", sqlServerConnection));

                
                //Task 2. Write a program that retrieves the name and description of all categories in the Northwind DB.
                Console.WriteLine("\n--- Task 2 ---\n");
                RetrieveNameAndDescriptionFromCategories(sqlServerConnection);

                //Task 3. Write a program that retrieves from the Northwind database all product categories and the names of the products in each category.
                //    Can you do this with a single SQL query (with table join)?
                Console.WriteLine("\n--- Task 3 ---\n");
                RetrieveCategoryWithProductsInside(sqlServerConnection);

                //Task 4. Write a method that adds a new product in the products table in the Northwind database.
                //        Use a parameterized SQL command.
                Console.WriteLine("\n--- Task 4 ---\n");
                AddNewProductInProductTable("Other Chai", 1, 1, "10 boxes x 20 bags", 21.00M, 40, 0, 10, false, sqlServerConnection);
                Console.WriteLine("--- New Product inserted ---");

                //Task 5. Write a program that retrieves the images for all categories in the Northwind database and stores them as JPG 
                //        files in the file system.
                Console.WriteLine("\n--- Task 5 ---\n");
                RetrieveImagesFromCategories(sqlServerConnection);
                Console.WriteLine("--- Pictures retrieved  ---");
            }

            OleDbConnection oleConnection = new OleDbConnection(connectionString);

            oleConnection.Open();

            using (oleConnection)
            {
                //Task 6.Create an Excel file with 2 columns: name and score:.
                // Write a program that reads your MS Excel file through the OLE DB data provider and displays the name and score row by row.
                Console.WriteLine("\n--- Task 6 ---\n");
                GetDataFromExcelTable(oleConnection);                

                //Task 7.Implement appending new rows to the Excel file.
                Console.WriteLine("\n--- Task 7 ---\n");
                AddNewEntryToExcelTable("Evlogi Georgiev", 21, oleConnection);
                AddNewEntryToExcelTable("Kristian Cuklev", 22, oleConnection);                
            }

            using(sqlServerConnection)
            {

                //Task 8. Write a program that reads a string from the console and finds all products that contain this string.
                //        Ensure you handle correctly characters like ', %, ", \ and _.
                Console.WriteLine("\n--- Task 8 ---\n");

                Console.Write("Enter a search product:");
                string searchedProduct = Console.ReadLine();                
                Console.WriteLine("Result of searching for {0}", searchedProduct);
                SearchProductsInProductTable(searchedProduct, sqlServerConnection);

            }
        }

        private static int RetrieveNumberOfRowsInTable(string tableName, SqlConnection dbConnection)
        {
            string query = "SELECT COUNT(*) FROM " + tableName;
            SqlCommand command = new SqlCommand(query, dbConnection);            
            int numberOfRows = (int)command.ExecuteScalar();

            return numberOfRows;
        }

        private static void RetrieveNameAndDescriptionFromCategories(SqlConnection dbConnection)
        {
            SqlCommand command = new SqlCommand("SELECT CategoryName, Description FROM Categories", dbConnection);

            SqlDataReader reader = command.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    string categoryName = (string)reader["CategoryName"];
                    string description = (string)reader["Description"];

                    Console.WriteLine("{0} -> {1}", categoryName, description);
                }
            }
        }

        private static void RetrieveCategoryWithProductsInside(SqlConnection dbConnection)
        {
            string query = "SELECT c.CategoryName, p.ProductName " +
                           "FROM Categories c " +
                           "LEFT JOIN Products p " +
                           "ON c.CategoryID = p.CategoryID " +
                           "ORDER BY c.CategoryName";
            
            SqlCommand command = new SqlCommand(query, dbConnection);
            SqlDataReader reader = command.ExecuteReader();

            using (reader)
            {                
                while (reader.Read())
                {
                    string categoryName = (string)reader["CategoryName"];
                    string productName = (string)reader["ProductName"];                    

                    Console.WriteLine("{0} -> {1}", categoryName, productName);

                }
            }
        }

        private static void AddNewProductInProductTable(string productName, 
                                                        int supplierID, 
                                                        int categoryID, 
                                                        string quantityPerUnit, 
                                                        decimal unitPrice, 
                                                        int unitsInStock, 
                                                        int unitsOnOrder, 
                                                        int reorderLevel, 
                                                        bool discontinued, 
                                                        SqlConnection dbConnection)
        {
            string query = @"INSERT INTO Products 
                                (ProductName, SupplierID, CategoryID, QuantityPerUnit, 
                                 UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued)
                             VALUES 
	                             (@productName, @supplierID, @categoryID, @quantityPerUnit, 
                                  @unitPrice, @unitsInStock, @unitsOnOrder, @reorderLevel, @discontinued)";

            SqlCommand command = new SqlCommand(query, dbConnection);
            command.Parameters.AddWithValue("@productName", productName);
            command.Parameters.AddWithValue("@supplierID", supplierID);
            command.Parameters.AddWithValue("@categoryID", categoryID);
            command.Parameters.AddWithValue("@quantityPerUnit", quantityPerUnit);
            command.Parameters.AddWithValue("@unitPrice", unitPrice);
            command.Parameters.AddWithValue("@unitsInStock", unitsInStock);
            command.Parameters.AddWithValue("@unitsOnOrder", unitsOnOrder);
            command.Parameters.AddWithValue("@reorderLevel", reorderLevel);
            command.Parameters.AddWithValue("@discontinued", discontinued);

            command.ExecuteNonQuery();
        }

        private static void RetrieveImagesFromCategories(SqlConnection dbConnection)
        {
            string query = @"SELECT CategoryName, Picture
                             FROM Categories";

            SqlCommand command = new SqlCommand(query, dbConnection);
            SqlDataReader reader = command.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    string pictureName = (string)reader["CategoryName"];
                    pictureName = pictureName.Replace('/', '_');
                    byte[] picture = (byte[])reader["Picture"];
                    string fileName = string.Format(@"..\..\pictures\{0}.jpg", pictureName);
                    WriteBinaryFile(fileName, picture);
                }
            }
        }

        private static void WriteBinaryFile(string fileName,
        byte[] fileContents)
        {
            FileStream stream = File.OpenWrite(fileName);
            using (stream)
            {
                stream.Write(fileContents, 78, fileContents.Length - 78);
            }
        }

        private static void SearchProductsInProductTable(string searchedProduct, SqlConnection dbConnection)
        {
            string query = string.Format(@"SELECT ProductName
                                           FROM Products
                                           WHERE ProductName LIKE '%{0}%'", searchedProduct);

            SqlCommand command = new SqlCommand(query, dbConnection);
            SqlDataReader reader = command.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string productName = (string)reader["ProductName"];
                    Console.WriteLine("  --> {0}", productName);
                }
            }
        }

        private static void AddNewEntryToExcelTable(string name, double score, OleDbConnection dbConnection)
        {
            string query = string.Format("INSERT INTO [Sheet1$] (Name, Score) VALUES ('{0}', '{1}')", name, score);

            OleDbCommand command = new OleDbCommand(query, dbConnection);

            try
            {
                command.ExecuteNonQuery();
                Console.WriteLine("Entry inserted!");
            }
            catch (OleDbException exception)
            {
                Console.WriteLine("Excel Error occured: " + exception);
            }
        }

        private static void GetDataFromExcelTable(OleDbConnection dbConnection)
        {
            string query = @"SELECT *
                             FROM [Sheet1$]";

            OleDbCommand command = new OleDbCommand(query, dbConnection);
            OleDbDataReader reader = command.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string name = (string)reader["Name"];
                    double score = (double)reader["Score"];
                    Console.WriteLine("{0} -> {1}", name, score);
                }
            }
        }

    }
}