using MySql.Data.MySqlClient;
using DefensieTrainer.Domain.IRepositories;
using System.Diagnostics.Metrics;
using DefensieTrainer.Domain.DTO;

namespace DefensieTrainer.Dal.Repositories
{
    public class ClusterRepository : IClusterRepository
    {
        private readonly string _connectionString;

        public ClusterRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        //TO DO  CHANGE THIS  QUERY
        public void CreateCluster(ClusterDto cluster)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string Query = @"INSERT INTO Cluster (ClusterLevel, Description)
                                     VALUES (@ClusterLevel, @Description);
                                     SELECT LAST_INSERT_ID();"; 

                using (var insertClusterCommand = new MySqlCommand(Query, connection))
                {
                    insertClusterCommand.Parameters.AddWithValue("@ClusterLevel", cluster.ClusterLevel);
                    insertClusterCommand.Parameters.AddWithValue("@Description", cluster.Description);

                    int latestClusterId = Convert.ToInt32(insertClusterCommand.ExecuteScalar());

                    // Insert requirements associated with the cluster
                    string insertRequirementsQuery = @"INSERT INTO Requirement (Cluster_id, Name, Description, SortTraining, TimeInSeconds)
                                               VALUES (@ClusterId, @Name, @Description, @SortTraining, @TimeInSeconds)";

                    foreach (RequirementDto requirement in cluster.Requirements)
                    {
                        using (var insertRequirementCommand = new MySqlCommand(insertRequirementsQuery, connection))
                        {
                            insertRequirementCommand.Parameters.AddWithValue("@ClusterId", latestClusterId);
                            insertRequirementCommand.Parameters.AddWithValue("@Name", requirement.Name);
                            insertRequirementCommand.Parameters.AddWithValue("@Description", requirement.Description);
                            insertRequirementCommand.Parameters.AddWithValue("@SortTraining", requirement.SortTraining);
                            insertRequirementCommand.Parameters.AddWithValue("@TimeInSeconds", requirement.TimeInSeconds);
                            insertRequirementCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public void DeleteCluster(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Cluster WHERE Id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCluster(int[] id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Cluster WHERE Id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<ClusterDto> GetAllClusters()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Cluster";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        var clusters = new List<ClusterDto>();
                        while (reader.Read())
                        {
                            clusters.Add(new ClusterDto
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                ClusterLevel = Convert.ToInt32(reader["ClusterLevel"]),
                                Description = reader["Description"].ToString()
                            });
                        }
                        return clusters;
                    }
                }
            }
        }

        public List<ClusterDto> GetByClusterIds(int clusterId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Cluster WHERE Id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", clusterId);
                    using (var reader = command.ExecuteReader())
                    {
                        var clusters = new List<ClusterDto>();
                        while (reader.Read())
                        {
                            clusters.Add(new ClusterDto
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                ClusterLevel = Convert.ToInt32(reader["ClusterLevel"]),
                                Description = reader["Description"].ToString()
                            });
                        }
                        return clusters;
                    }
                }
            }
        }

        public ClusterDto GetById(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Cluster WHERE Id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ClusterDto
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                ClusterLevel = Convert.ToInt32(reader["ClusterLevel"]),
                                Description = reader["Description"].ToString()
                            };
                        }
                        return null;
                    }
                }
            }
        }

        public void UpdateCluster(CreateClusterDto cluster)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"UPDATE Cluster
                         SET ClusterLevel = @ClusterLevel, 
                             Description = @Description 
                         WHERE Id = @Id";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClusterLevel", cluster.ClusterLevel);
                    command.Parameters.AddWithValue("@Description", cluster.Description);
                    command.Parameters.AddWithValue("@Id", cluster.Id);
                    command.ExecuteNonQuery();
                }
            }
        }


    }
}
