using Logica.ENV;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class DataManager
    {
        private string connectionString;
        
        public DataManager()
        {
            ENV env = new ENV();
            this.connectionString = env.ConnectionString;
        }

        public void AddRequirement(Requirement requirement)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                string query = @"INSERT INTO Requirement (req_name, req_description, req_sort_training, req_amount, req_time_in_seconds) 
                             VALUES (@Name, @Description, @SortTraining, @Amount, @Time)";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", requirement.Name);
                    command.Parameters.AddWithValue("@Description", requirement.Description);
                    command.Parameters.AddWithValue("@SortTraining", requirement.SortTraining);
                    command.Parameters.AddWithValue("@Amount", requirement.Amount);
                    command.Parameters.AddWithValue("@Time", requirement.Time);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions
                        Console.WriteLine($"Error adding requirement to the database: {ex.Message}");
                    }
                }
            }
        }
    }
}

