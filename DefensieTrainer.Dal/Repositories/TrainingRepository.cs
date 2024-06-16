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

        public void AddFeedbackToTraining(CreateFeedbackDto dto)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                
                var getPersonIdQuery = @"SELECT Person_id FROM Training WHERE id = @TrainingId";
                using (var getPersonIdCommand = new MySqlCommand(getPersonIdQuery, connection))
                {
                    getPersonIdCommand.Parameters.AddWithValue("@TrainingId", dto.TrainingId);

                    var personIdObject = getPersonIdCommand.ExecuteScalar();
                    if (personIdObject == null || !int.TryParse(personIdObject.ToString(), out int personId))
                    {
                        throw new Exception("PersonId not found for the given TrainingId.");
                    }
                    dto.PersonId = personId;
                }

               
                var insertFeedbackQuery = @"INSERT INTO feedback (Person_id, Training_id, Feedback) VALUES (@PersonId, @TrainingId, @Feedback)";
                using (var insertCommand = new MySqlCommand(insertFeedbackQuery, connection))
                {
                    insertCommand.Parameters.AddWithValue("@PersonId", dto.PersonId);
                    insertCommand.Parameters.AddWithValue("@TrainingId", dto.TrainingId);
                    insertCommand.Parameters.AddWithValue("@Feedback", dto.Feedback);
                    insertCommand.ExecuteNonQuery();
                }

                connection.Close();
            }

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var updateTrainingQuery = @"UPDATE Training SET NeedsFeedBack = 0 WHERE Id = @TrainingId";
                using (var updateCommand = new MySqlCommand(updateTrainingQuery, connection))
                {
                    updateCommand.Parameters.AddWithValue("@TrainingId", dto.TrainingId);
                    updateCommand.ExecuteNonQuery();
                }
                connection.Close();
            }
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
                connection.Close();
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
                connection.Close();
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
                connection.Close();
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
                    connection.Close();
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
                connection.Close();
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
                ROM Training
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
                connection.Close();
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
                    connection.Close();
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
                connection.Close();
            }
        }


        public FeedbackDto GetFeedbackByEmail(string email)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                FeedbackDto feedback = null;
                string query = @"
        SELECT f.* 
        FROM Feedback f
        INNER JOIN Person p ON f.Person_id = p.id
        WHERE p.email = @Email
        ORDER BY f.id DESC
        LIMIT 1";

                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);

                connection.Open(); // Ensure the connection is opened before executing the command
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        feedback = new FeedbackDto
                        {
                            Feedback = reader["Feedback"].ToString()
                        };
                    }
                }
                connection.Close(); // Ensure the connection is closed
                return feedback;
            }
        }
    }
}
