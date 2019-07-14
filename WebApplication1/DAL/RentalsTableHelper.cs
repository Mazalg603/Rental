using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class RentalsTableHelper
    {
        public static int AddRentals(string CostomerName, string MovieName)
        {
            int MovieID = RentalsTableHelper.GetMovieID(MovieName);
            int CustomerID = RentalsTableHelper.GetCustomerID(CostomerName);
            int nRowsAffected;
            string strConnectionString = DalUtils.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(strConnectionString))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("insert into Rentals (MovieID,CustomerID) VALUES (@MovieID,@CustomerID)");
            
                String sql = sb.ToString();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@MovieID", MovieID);
                    command.Parameters.AddWithValue("@CustomerID", CustomerID);

                    nRowsAffected = command.ExecuteNonQuery();
                }
            }

            return nRowsAffected;
        }

        public static int GetCustomerID(string CustomerName)
        {
            int CustomerID = 0;

            string strConnectionString = DalUtils.GetConnectionString();
            using (SqlConnection connection =
                new SqlConnection(strConnectionString))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT Id from Customers WHERE Customers.Name= '"+CustomerName+"';");
                String sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CustomerID = reader.GetInt32(0);
                        }
                    }
                }

            }
            return CustomerID;
        }

        public static int GetMovieID(string MovieName)
        {
            int MovieID=0;

            string strConnectionString = DalUtils.GetConnectionString();
            
            using (SqlConnection connection =
                new SqlConnection(strConnectionString))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT Id from Movies");
                sb.Append(" where Name= '"+MovieName+"';");
                String sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MovieID = reader.GetInt32(0);
                        }
                    }
                }

            }
            return MovieID;
        }

        public static List<Rental> GetAllRentalsList()
        {
            string strConnectionString = DalUtils.GetConnectionString();

            List<Rental> list = new List<Rental>();

            using (SqlConnection connection =
                new SqlConnection(strConnectionString))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT Customers.Name , Movies.Name, Rentals.Id FROM Rentals INNER JOIN Customers ON Rentals.Id= Customers.Id"+
                         " INNER JOIN Movies ON Rentals.Id = Movies.Id;");
                String sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Rental
                            {
                                CostomerName = reader.GetString(0),
                                MovieName = reader.GetString(1),
                                ID = reader.GetInt32(2),
                            });
                        }
                    }
                }

            }
            return (list);
        }

        public static bool IsTheFilmRented(string MovieName)
        {
            int MovieID = RentalsTableHelper.GetMovieID(MovieName);

            List<Rental> RentalList = GetAllRentalsList();

            bool Exsit = RentalList.Exists(property => property.ID == MovieID);

            return Exsit;
        }
    }
}