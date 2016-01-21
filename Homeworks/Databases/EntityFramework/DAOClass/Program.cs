using NorthwindDBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOClass
{
    public class Program
    {
        public static void Main()
        {
            //Task 2. Create a DAO class with static methods which provide functionality 
            //        for inserting, modifying and deleting customers. Use Northwind database
            //        Write a testing class.

            string customerId = "ALFII";

            InsertNewCustomerInCustomerTable(customerId,
                                             "Alfreds Futterkiste",
                                             "IvanIvanov",
                                             "Sales Representative",
                                             "Obere Str. 57",
                                             "Berlin",
                                             "BC",
                                             "12209",
                                             "Germany",
                                             "030-0074321",
                                             "030-0076545");

            ModifyCustomerInCustomerTable(customerId,
                                          "Bosch",
                                          "IvanIvanov",
                                          "Sales",
                                          "Obere Str. 57",
                                          "Berlin",
                                          "BC",
                                          "12209",
                                          "Germany",
                                          "030-12345",
                                          "030-123456");

            //DeleteCustomerFromCustomerTable(customerId);
        }

        private static void InsertNewCustomerInCustomerTable(string customerId,
                                                             string companyName,
                                                             string contactName,
                                                             string contactTitle,
                                                             string address,
                                                             string city,
                                                             string region,
                                                             string postalCode,
                                                             string country,
                                                             string phone,
                                                             string fax)
        {
            using (var db = new NorthwindEntities())
            {
                Customer newCustomer = new Customer();
                newCustomer.CustomerID = customerId;
                newCustomer.CompanyName = companyName;
                newCustomer.ContactName = contactName;
                newCustomer.ContactTitle = contactTitle;
                newCustomer.Address = address;
                newCustomer.City = city;
                newCustomer.Region = region;
                newCustomer.PostalCode = postalCode;
                newCustomer.Country = country;
                newCustomer.Phone = phone;
                newCustomer.Fax = fax;

                db.Customers.Add(newCustomer);
                db.SaveChanges();
            }

        }

        private static void ModifyCustomerInCustomerTable(string customerId,
                                                          string companyName,
                                                          string contactName,
                                                          string contactTitle,
                                                          string address,
                                                          string city,
                                                          string region,
                                                          string postalCode,
                                                          string country,
                                                          string phone,
                                                          string fax)
        {
            using (var db = new NorthwindEntities())
            {
                Customer customer = GetCustomerByCustomerId(customerId, db);
                customer.CustomerID = customerId;
                customer.CompanyName = companyName;
                customer.ContactName = contactName;
                customer.ContactTitle = contactTitle;
                customer.Address = address;
                customer.City = city;
                customer.Region = region;
                customer.PostalCode = postalCode;
                customer.Country = country;
                customer.Phone = phone;
                customer.Fax = fax;
                
                db.SaveChanges();
            }

        }

        private static void DeleteCustomerFromCustomerTable(string customerId)
        {                        

            using (var db = new NorthwindEntities())
            {
                Customer customer = GetCustomerByCustomerId(customerId, db);
                db.Customers.Remove(customer);
                db.SaveChanges();
            }
        }

        private static Customer GetCustomerByCustomerId(string customerId, NorthwindEntities db)
        {
            Customer customer = db.Customers.FirstOrDefault(c => c.CustomerID == customerId);

            return customer;            
        }
    }
}
