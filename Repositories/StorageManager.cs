using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using MovieRR_App.Model;
using System.Data;
using System.Security.AccessControl;


namespace MovieRR_App.Repositories
{
    public class StorageManager
    {
        private SqlConnection conn;

        public StorageManager(string connectionString)
        {
            try
            {
                conn = new SqlConnection(connectionString);
                conn.Open();
                Console.WriteLine("connection successful");
            }
            catch (SqlException e)
            {
                Console.WriteLine("connection failed");
                Console.WriteLine(e.Message);               
            }
            catch (Exception ex)
            {
                Console.WriteLine("error");
                Console.WriteLine(ex.Message);
            }

        }

        public List<Director> GetAllDirectors()
        {
            List<Director> directors = new List<Director>();
            string sqlString = "SELECT * FROM DirectorsTable";
            using (SqlCommand cmd = new SqlCommand(sqlString, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int directorId = Convert.ToInt32(reader["DirectorID"]);
                        string directorName = reader["DirectorName"].ToString();
                        directors.Add(new Director(directorId, directorName));
                    }

                }
            }
            return directors;
        }
        public int UpdateDirectorName(int directorID, string directorName)
        {
            using (SqlCommand cmd = new SqlCommand($"UPDATE DirectorsTable SET directorName = @DirectorName WHERE directorName = @DirectorName", conn))
            { cmd.Parameters.AddWithValue("@DirectorName", directorName);
                cmd.Parameters.AddWithValue("@DirectorID", directorID);
                return cmd.ExecuteNonQuery();

            }
        }
        public  int InsertNewDirectors(Director director1)
        {
            using SqlCommand cmd = new SqlCommand("INSERT INTO DirectorsTable (directorName) " +
                "VALUES (@DirectorName); SELECT SCOPE_IDENTITY(); ", conn);
            {
                cmd.Parameters.AddWithValue("@DirectorName", director1.DirectorName);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }

        }
        public int DeleteDirectorByName(string directorName)
        {
            using SqlCommand cmd = new SqlCommand("DELETE FROM DirectorsTable WHERE directorName " +
                "= @DirectorName", conn);
            {
                cmd.Parameters.AddWithValue("@Director", directorName);
                return cmd.ExecuteNonQuery();
            }

        }

        public void CloseConnection()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
                Console.WriteLine("Connection closed");
            }
        }
    }

}
