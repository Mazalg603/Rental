using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class MoviesTableHelper
    {
        public static List<Movie> GetAllMovieList()
        {
            string strConnectionString = DalUtils.GetConnectionString();

            List<Movie> list = new List<Movie>();

            using (SqlConnection connection =
                new SqlConnection(strConnectionString))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * from Movies");
                String sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Movie
                            {  // רידר נקודה ומיקום מסמן על עמודה
                                MovieId = reader.GetInt32(0),
                                MovieName = reader.GetString(1),
                                MovieCategory = reader.GetString(2)
                            });
                        }
                    }
                }

            }
            return (list);
        }

        public static bool MovieExsit(string MovieName)
        {
            List<Movie> MovieList = MoviesTableHelper.GetAllMovieList();

            bool Exsit = MovieList.Exists(property => property.MovieName == MovieName);
            return Exsit;
        }

        public static int AddMovie(string MovieName, string MovieCategory)
        {
            int nRowsAffected;
            string strConnectionString = DalUtils.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(strConnectionString))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("INSERT INTO Movies (Name,Category) ");
                sb.Append("VALUES (@MovieName, @MovieCategory);");
                String sql = sb.ToString();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@MovieName", MovieName);
                    command.Parameters.AddWithValue("@MovieCategory", MovieCategory);
                    nRowsAffected = command.ExecuteNonQuery();
                }
            }

            return nRowsAffected;
        } 
    }
}