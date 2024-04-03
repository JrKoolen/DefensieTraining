using System;
using Logica.ENV;
using MySql.Data.MySqlClient;

class Temp
{
    static public void CreateFakeData()
    {
        ENV env = new ENV();

        string connectionString = env.ConnectionString;
        string databaseName = env.DataBaseName;

        // Connect to the existing database
        using (var connection = new MySqlConnection(connectionString))
        {
            try
            {
                connection.Open();

                // Insert fake data into the User table
                InsertFakeUserData(connection);

                Console.WriteLine("Fake data inserted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting fake data: {ex.Message}");
            }
        }
    }

    static void InsertFakeUserData(MySqlConnection connection)
    {
        int numberOfUsersToGenerate = 10; // Adjust the number of users you want to generate

        for (int i = 0; i < numberOfUsersToGenerate; i++)
        {
            string name = "User" + i.ToString();
            string lastName = "Lastname" + i.ToString();
            float weight = GenerateRandomWeight(); // Generate random weight
            float length = GenerateRandomHeight(); // Generate random height
            DateTime arrivalDate = DateTime.Now.AddDays(-GenerateRandomDays()); // Random arrival date within the past year
            string armedForce = "ArmedForce" + i.ToString();

            string insertUserQuery = $@"
                INSERT INTO User (Name, Last_Name, Weight, Length, Arrival_date, Armed_Force)
                VALUES (@Name, @LastName, @Weight, @Length, @ArrivalDate, @ArmedForce);";

            using (var command = new MySqlCommand(insertUserQuery, connection))
            {
                // Add parameters to the query to avoid SQL injection
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Weight", weight);
                command.Parameters.AddWithValue("@Length", length);
                command.Parameters.AddWithValue("@ArrivalDate", arrivalDate);
                command.Parameters.AddWithValue("@ArmedForce", armedForce);

                command.ExecuteNonQuery();
            }
        }
    }

    static float GenerateRandomWeight()
    {
        // Generate a random weight between 50 and 100 kg
        Random random = new Random();
        return (float)(random.Next(5000, 10000) / 100.0);
    }

    static float GenerateRandomHeight()
    {
        // Generate a random height between 150 and 200 cm
        Random random = new Random();
        return (float)(random.Next(15000, 20000) / 100.0);
    }

    static int GenerateRandomDays()
    {
        // Generate a random number of days between 1 and 365
        Random random = new Random();
        return random.Next(1, 365);
    }
}
