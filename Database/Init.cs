using System;
using Logica.ENV;
using MySql.Data.MySqlClient;

class Init
{
    static void Main()
    {
        ENV env = new ENV();

        string connectionString = env.ConnectionString;
        string databaseName = env.DataBaseName;

        using (var connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();

                string createDatabaseQuery = $"CREATE DATABASE IF NOT EXISTS `{databaseName}`;";

                ExecuteNonQuery(connection, createDatabaseQuery);

                connection.ChangeDatabase(databaseName);

                string createClusterTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Cluster (
                        cluster_id INT AUTO_INCREMENT PRIMARY KEY,
                        cluster_level INT,
                        cluster_description VARCHAR(500)
                    );";

                string createRequirementTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Requirement (
                        req_id INT AUTO_INCREMENT PRIMARY KEY,
                        cluster_id INT,
                        req_name VARCHAR(20),
                        req_description VARCHAR(500),
                        req_sort_training INT,
                        req_amount INT,
                        req_time_in_seconds INT,
                        FOREIGN KEY (cluster_id) REFERENCES Cluster(cluster_id)
                    );";

                string createTrainingTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Training (
                        id INT AUTO_INCREMENT PRIMARY KEY,
                        Name VARCHAR(20),
                        Sort_Training INT,
                        Amount INT,
                        Time INT,
                        Meters INT,
                        Comment VARCHAR(500),
                        Training_DateTime DATETIME
                    );";

                string createUserTableQuery = @"
                    CREATE TABLE IF NOT EXISTS User (
                        id INT AUTO_INCREMENT PRIMARY KEY,
                        Name VARCHAR(20),
                        Last_Name VARCHAR(20),
                        Weight FLOAT,
                        Length FLOAT,
                        Arrival_date DATETIME,
                        Armed_Force VARCHAR(20)
                    );";

                ExecuteNonQuery(connection, createClusterTableQuery);
                ExecuteNonQuery(connection, createRequirementTableQuery);
                ExecuteNonQuery(connection, createTrainingTableQuery);
                ExecuteNonQuery(connection, createUserTableQuery);

                Console.WriteLine("Database and tables created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating database and tables: {ex.Message}");
            }
        }
        Temp.CreateFakeData();
    }

    static void ExecuteNonQuery(MySqlConnection connection, string query)
    {
        using (var command = new MySqlCommand(query, connection))
        {
            command.ExecuteNonQuery();
        }
    }

}
