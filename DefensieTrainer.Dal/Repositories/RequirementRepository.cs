using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using DefensieTrainer.Domain.DTO;
using DefensieTrainer.Domain.IRepositories;
using System.Xml.Linq;

namespace DefensieTrainer.Dal.Repositories
{
    public class RequirementRepository : IRequirementRepository
    {
        private readonly string _connectionString;

        public RequirementRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateRequirement(CreateRequirementDto requirement)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO Requirement (Cluster_id, Name, Description, SortTraining, TimeInSeconds)
                         VALUES (@ClusterId, @Name, @Description, @SortTraining, @TimeInSeconds)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClusterId", requirement.ClusterId);
                    command.Parameters.AddWithValue("@Name", requirement.Name);
                    command.Parameters.AddWithValue("@Description", requirement.Description);
                    command.Parameters.AddWithValue("@SortTraining", requirement.SortTraining);
                    command.Parameters.AddWithValue("@TimeInSeconds", requirement.TimeInSeconds);
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

        public List<ReadRequirementDto> GetAllRequirements()
        {
            List<ReadRequirementDto> requirements = new List<ReadRequirementDto>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Requirement";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ReadRequirementDto requirement = new ReadRequirementDto
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"] == DBNull.Value ? null : reader["Name"].ToString(),
                                Description = reader["Description"] == DBNull.Value ? null : reader["Description"].ToString(),
                                ClusterId = reader["Cluster_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Cluster_id"]),
                                SortTraining = reader["SortTraining"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SortTraining"]),
                                Amount = reader["Amount"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Amount"]),
                                TimeInSeconds = reader["TimeInSeconds"] == DBNull.Value ? 0 : Convert.ToInt32(reader["TimeInSeconds"])
                            };
                            requirements.Add(requirement);
                        }
                    }
                }
            }
            return requirements;
        }

        public ReadRequirementDto GetById(int id)
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
                            ReadRequirementDto requirement = new ReadRequirementDto
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"] == DBNull.Value ? null : reader["Name"].ToString(),
                                Description = reader["Description"] == DBNull.Value ? null : reader["Description"].ToString(),
                                ClusterId = reader["Cluster_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Cluster_id"]),
                                SortTraining = reader["SortTraining"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SortTraining"]),
                                Amount = reader["Amount"] == DBNull.Value ? 0 : Convert.ToInt32(reader["Amount"]),
                                TimeInSeconds = reader["TimeInSeconds"] == DBNull.Value ? 0 : Convert.ToInt32(reader["TimeInSeconds"])
                            };
                            return requirement;
                        }
                        return null;
                    }
                }
            }
        }

        public void UpdateRequirement(ReadRequirementDto requirement)
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
}