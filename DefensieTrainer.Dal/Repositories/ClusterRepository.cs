using MySql.Data.MySqlClient;
using DefensieTrainer.Domain.IRepositories;
using DefensieTrainer.Domain.DTO.IN;
using DefensieTrainer.Domain.DTO.OUT;

namespace DefensieTrainer.Dal.Repositories
{
    public class ClusterRepository : IClusterRepository
    {
        private readonly string _connectionString;

        public ClusterRepository(string connectionString)
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
            throw new NotImplementedException();
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

        public void UpdateCluster(ClusterDto cluster)
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
