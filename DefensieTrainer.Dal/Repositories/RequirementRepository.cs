﻿using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using DefensieTrainer.Domain.DTO.IN;
using DefensieTrainer.Domain.DTO.OUT;

public class RequirementRepository
{
    private readonly string _connectionString;

    public RequirementRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void CreateRequirement(PostRequirementDto requirement)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();
            string query = @"INSERT INTO Requirement (Cluster_id, RequiredName, RequiredDescription, RequiredSortTraining, RequiredAmount, RequiredTimeInSeconds)
                         VALUES (@ClusterId, @RequiredName, @RequiredDescription, @RequiredSortTraining, @RequiredAmount, @RequiredTimeInSeconds)";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ClusterId", requirement.ClusterId);
                command.Parameters.AddWithValue("@RequiredName", requirement.Name);
                command.Parameters.AddWithValue("@RequiredDescription", requirement.Description);
                command.Parameters.AddWithValue("@RequiredSortTraining", requirement.SortTraining);
                command.Parameters.AddWithValue("@RequiredAmount", requirement.Amount);
                command.Parameters.AddWithValue("@RequiredTimeInSeconds", requirement.TimeInSeconds);
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
                            reader["RequiredName"].ToString(),
                            reader["RequiredDescription"].ToString(),
                            Convert.ToInt32(reader["Cluster_id"]),
                            Convert.ToInt32(reader["RequiredSortTraining"]),
                            Convert.ToInt32(reader["RequiredAmount"]),
                            Convert.ToInt32(reader["RequiredTimeInSeconds"])
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
                                 RequiredName = @RequiredName, 
                                 RequiredDescription = @RequiredDescription, 
                                 RequiredSortTraining = @RequiredSortTraining, 
                                 RequiredAmount = @RequiredAmount, 
                                 RequiredTimeInSeconds = @RequiredTimeInSeconds 
                             WHERE id = @Id";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ClusterId", requirement.ClusterId);
                command.Parameters.AddWithValue("@RequiredName", requirement.Name);
                command.Parameters.AddWithValue("@RequiredDescription", requirement.Description);
                command.Parameters.AddWithValue("@RequiredSortTraining", requirement.SortTraining);
                command.Parameters.AddWithValue("@RequiredAmount", requirement.Amount);
                command.Parameters.AddWithValue("@RequiredTimeInSeconds", requirement.TimeInSeconds);
                command.Parameters.AddWithValue("@Id", requirement.Id);
                command.ExecuteNonQuery();
            }
        }
    }
}