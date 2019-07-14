using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class CustomerTableHelper
    {
        public static List<Customer> GetAllCustomersList()
        {
            string strConnectionString = DalUtils.GetConnectionString();

            List<Customer> list = new List<Customer>();

            using (SqlConnection connection =
                new SqlConnection(strConnectionString))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * from Customers");
                String sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Customer
                            {  
                                CustomersName = reader.GetString(1),
                                CustomersSubscription = reader.GetString(2),
                                CustomersAge = reader.GetInt32(3),
                            });
                        }
                    }
                }

            }
            return (list);
        }

        public static bool CustomerExsit(string CustomersName)
        {
            List<Customer> CustomerList = CustomerTableHelper.GetAllCustomersList();

            bool Exsit = CustomerList.Exists(property => property.CustomersName == CustomersName);
            return Exsit; ;
        }
        
        public static int AddCustome(string CustomersName, string CustomersSubscription, int CustomersAge)
        {
            int nRowsAffected;
            string strConnectionString = DalUtils.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(strConnectionString))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("INSERT INTO Customers (Name,Subscription,Age) ");
                sb.Append("VALUES (@Name, @Subscription,@Age);");
                String sql = sb.ToString();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Name", CustomersName);
                    command.Parameters.AddWithValue("@Subscription", CustomersSubscription);
                    command.Parameters.AddWithValue("@Age", CustomersAge);
                    nRowsAffected = command.ExecuteNonQuery();
                }
            }

            return nRowsAffected;
        }
        
    }
}