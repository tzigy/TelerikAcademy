namespace NorthwindDbClone
{    
    using System;
    using System.Configuration;
    using NorthwindDBContext;

    public class Program
    {
        public static void Main()
        {
            // Task 6.Create a database called NorthwindTwin with the same 
            //        structure as Northwind using the features from DbContext.
            //         Find for the API for schema generation in MSDN or in Google.            

            CreateNorthwindTwin();
        }

        private static void CreateNorthwindTwin()
        {
            using (var db = new NorthwindEntities())
            {
                db.Database.CreateIfNotExists();
                db.SaveChanges();
            }
        }
    }
}
