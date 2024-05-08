using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using DefensieTrainer.Domain.DTO.IN;
using DefensieTrainer.Domain.DTO.OUT;
using DefensieTrainer.Domain.IRepositories;

public class RequirementRepository : IRequirementRepository
{
    private readonly string _connectionString;

    public RequirementRepository(string connectionString)
    {
        _connectionString = connectionString;
    }


    public void CreateCluster(Cluster cluster)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            string query = @"INSERT INTO Cluster (ClusterLevel, Description)
                                 VALUES (@ClusterLevel, @Description)";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ClusterLevel", cluster.ClusterLevel);
                command.Parameters.AddWithValue("@Description", cluster.Description);
                command.ExecuteNonQuery();
            }
        }
    }

    public void DeleteRequirement(int id)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            string query = "DELETE FROM Requirement WHERE id = @Id";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }


    public void DeleteRequirements(int[] ids)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            foreach (int id in ids)
            {
                string query = "DELETE FROM Requirement WHERE id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }

    public Requirement GetById(int id)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM Requirement WHERE id = @Id";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Requirement(
                            Convert.ToInt32(reader["id"]),
                            reader["Name"].ToString(),
                            reader["Description"].ToString(),
                            Convert.ToInt32(reader["Cluster_id"]),
                            Convert.ToInt32(reader["SortTraining"]),
                            Convert.ToInt32(reader["SortTraining"]),
                            Convert.ToInt32(reader["TimeInSeconds"])
                        );
                    }
                    return null; // If no requirement found with the given id
                }
            }
        }
    }

    public void UpdateRequirement(Requirement requirement)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            string query = @"UPDATE Requirement 
                             SET Cluster_id = @ClusterId, 
                                 Name = @Name, 
                                 Description = @Description, 
                                 SortTraining = @SortTraining, 
                                 Amount = @Amount, 
                                 TimeInSeconds = @TimeInSeconds 
                             WHERE id = @Id";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ClusterId", requirement.ClusterId);
                command.Parameters.AddWithValue("@RequiredName", requirement.Name);
                command.Parameters.AddWithValue("@Description", requirement.Description);
                command.Parameters.AddWithValue("@SortTraining", requirement.SortTraining);
                command.Parameters.AddWithValue("@RequiredAmount", requirement.SortTraining);
                command.Parameters.AddWithValue("@TimeInSeconds", requirement.TimeInSeconds);
                command.Parameters.AddWithValue("@Id", requirement.Id);
                command.ExecuteNonQuery();
            }
        }
    }
}