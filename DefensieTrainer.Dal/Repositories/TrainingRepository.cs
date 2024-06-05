using DefensieTrainer.Domain.DTO;
using DefensieTrainer.Domain.IRepositories;
using MySql.Data.MySqlClient;

namespace DefensieTrainer.Dal.Repositories
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly string _connectionString;

        public TrainingRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddNewTraining(string Email, UserTrainingInputDto training)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                var query = @"
                INSERT INTO Training (Person_id, SortTraining, amount, TimeInSeconds, Meters, DateTime, NeedsFeedback)
                SELECT p.id, @SortTraining, @Amount, @TimeInSeconds, @Meters, @DateTime, @NeedsFeedback
                FROM Person p
                WHERE p.email = @Email";

                connection.Open();
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@ClusterId", training.ClusterId);
                command.Parameters.AddWithValue("@SortTraining", training.SortTraining);
                command.Parameters.AddWithValue("@Amount", training.Amount);
                command.Parameters.AddWithValue("@TimeInSeconds", training.TimeInSeconds);
                command.Parameters.AddWithValue("@Meters", training.Meters);
                command.Parameters.AddWithValue("@DateTime", training.DateTime);
                command.Parameters.AddWithValue("@PersonId", training.PersonId);
                command.Parameters.AddWithValue("@NeedsFeedback", training.NeedsFeedback);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteTraining(int trainingId)
        {
            string query = "DELETE FROM Trainings WHERE TrainingId = @TrainingId";
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@TrainingId", trainingId);
                command.ExecuteNonQuery();
            }
        }

        public List<TrainingDto> GetAllTrainings()
        {
            var trainings = new List<TrainingDto>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Trainings";
                connection.Open();
                var command = new MySqlCommand(query, connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var training = new TrainingDto
                        {
                            Id = Convert.ToInt32(reader["TrainingId"]),
                            Name = reader["Name"].ToString(),
                            Description = reader["Description"].ToString(),
                            ClusterId = Convert.ToInt32(reader["ClusterId"]),
                            SortTraining = Convert.ToInt32(reader["SortTraining"]),
                            Amount = Convert.ToInt32(reader["Amount"]),
                            TimeInSeconds = Convert.ToInt32(reader["TimeInSeconds"]),
                            Meters = Convert.ToInt32(reader["Meters"]),
                            DateTime = Convert.ToDateTime(reader["DateTime"]),
                            PersonId = Convert.ToInt32(reader["PersonId"]),
                            NeedsFeedback = Convert.ToBoolean(reader["ForUser"])
                        };
                        trainings.Add(training);
                    }
                }
            }
            return trainings;
        }

        public List<TrainingDto> GetAllTrainingsByEMail(string email)
        {
            {
                List<TrainingDto> trainings = new List<TrainingDto>();
                using (var connection = new MySqlConnection(_connectionString))
                {
                    string query = @"
            SELECT t.Id, t.Name, t.SortTraining, 
                   t.Amount, t.TimeInSeconds, t.Meters, t.DateTime, t.Person_Id
            FROM Training t
            JOIN Person p ON t.Person_Id = p.id
            WHERE p.email = @Email";

                    connection.Open();
                    var command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Email", email);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var training = new TrainingDto
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                //Description = reader["Description"].ToString(),
                                //ClusterId = Convert.ToInt32(reader["ClusterId"]),
                                SortTraining = Convert.ToInt32(reader["SortTraining"]),
                                Amount = Convert.ToInt32(reader["Amount"]),
                                TimeInSeconds = Convert.ToInt32(reader["TimeInSeconds"]),
                                Meters = Convert.ToInt32(reader["Meters"]),
                                DateTime = Convert.ToDateTime(reader["DateTime"]),
                                PersonId = Convert.ToInt32(reader["Person_Id"])
                            };

                            trainings.Add(training);
                        }
                    }
                }
                return trainings;
            }
        }

        public DashboardDto GetDashboardByEmail(string email)
        {
            DashboardDto dashboard = null;
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = @"
        SELECT 
            c.ClusterLevel AS ClusterLevel,
            (SELECT COUNT(*) FROM Training t WHERE t.person_id = p.id) AS AmountOfCompletedTrainings,
            (SELECT MAX(t.DateTime) FROM Training t WHERE t.person_id = p.id) AS LatestFinishedTraining,
            p.ArrivalDate AS UserDeadline
        FROM 
            Person p
        JOIN 
            Cluster c ON p.cluster_id = c.id
        WHERE 
            p.email = @Email";

                connection.Open();
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        dashboard = new DashboardDto
                        {
                            ClusterLevel = reader["ClusterLevel"].ToString(),
                            AmountOfCompletedTrainings = Convert.ToInt32(reader["AmountOfCompletedTrainings"]),
                            LatestFinishedTraining = reader["LatestFinishedTraining"] != DBNull.Value ? Convert.ToDateTime(reader["LatestFinishedTraining"]) : DateTime.MinValue,
                            UserDeadline = reader["UserDeadline"] != DBNull.Value ? Convert.ToDateTime(reader["UserDeadline"]) : DateTime.MinValue
                        };
                    }
                }
            }
            return dashboard;
        }

        public TrainingDto GetOldestTraining()
        {
            TrainingDto training = null;
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = @"
            SELECT * 
            FROM Training
            WHERE NeedsFeedback = 1 
            ORDER BY DateTime ASC 
            LIMIT 1"; 
                connection.Open();
                var command = new MySqlCommand(query, connection);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        training = new TrainingDto
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Name = reader["Name"].ToString(),
                           // Description = reader["Description"].ToString(),
                           // ClusterId = Convert.ToInt32(reader["Cluster_Id"]),
                            SortTraining = Convert.ToInt32(reader["SortTraining"]),
                            Amount = Convert.ToInt32(reader["Amount"]),
                            TimeInSeconds = Convert.ToInt32(reader["TimeInSeconds"]),
                            Meters = Convert.ToInt32(reader["Meters"]),
                            DateTime = Convert.ToDateTime(reader["DateTime"]),
                            PersonId = Convert.ToInt32(reader["Person_Id"]),
                            NeedsFeedback = Convert.ToBoolean(reader["NeedsFeedback"])
                        };
                    }
                }
            }
            return training;
        }

        public TrainingDto GetTrainingById(int trainingId)
        {
            TrainingDto training = null;
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Trainings WHERE TrainingId = @TrainingId";
                connection.Open();
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@TrainingId", trainingId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        training = new TrainingDto
                        {
                            Id = Convert.ToInt32(reader["TrainingId"]),
                            Name = reader["Name"].ToString(),
                            Description = reader["Description"].ToString(),
                            ClusterId = Convert.ToInt32(reader["ClusterId"]),
                            SortTraining = Convert.ToInt32(reader["SortTraining"]),
                            Amount = Convert.ToInt32(reader["Amount"]),
                            TimeInSeconds = Convert.ToInt32(reader["TimeInSeconds"]),
                            Meters = Convert.ToInt32(reader["Meters"]),
                            DateTime = Convert.ToDateTime(reader["DateTime"]),
                            PersonId = Convert.ToInt32(reader["PersonId"])
                        };
                    }
                }
            }
            return training;
        }

        public void UpdateTraining(TrainingDto training)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "UPDATE Trainings SET Name = @Name, Description = @Description, ClusterId = @ClusterId, SortTraining = @SortTraining, Amount = @Amount, TimeInSeconds = @TimeInSeconds, Meters = @Meters, DateTime = @DateTime, PersonId = @PersonId WHERE TrainingId = @TrainingId";
                connection.Open();
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@TrainingId", training.Id);
                command.Parameters.AddWithValue("@Name", training.Name);
                command.Parameters.AddWithValue("@Description", training.Description);
                command.Parameters.AddWithValue("@ClusterId", training.ClusterId);
                command.Parameters.AddWithValue("@SortTraining", training.SortTraining);
                command.Parameters.AddWithValue("@Amount", training.Amount);
                command.Parameters.AddWithValue("@TimeInSeconds", training.TimeInSeconds);
                command.Parameters.AddWithValue("@Meters", training.Meters);
                command.Parameters.AddWithValue("@DateTime", training.DateTime);
                command.Parameters.AddWithValue("@PersonId", training.PersonId);
                command.Parameters.AddWithValue("@ForUser", training.NeedsFeedback);
                command.ExecuteNonQuery();
            }
        }
    }
}
