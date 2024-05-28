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

        public void AddNewTraining(CreateTrainingDto training)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "INSERT INTO Trainings (Name, Description, ClusterId, SortTraining, Amount, TimeInSeconds, Meters, DateTime, PersonId, ForUser) VALUES" +
                    " (@Name, @Description, @ClusterId, @SortTraining, @Amount, @TimeInSeconds, @Meters, @DateTime, @PersonId, @ForUser)";
                connection.Open();
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", training.Name);
                command.Parameters.AddWithValue("@Description", training.Description);
                command.Parameters.AddWithValue("@ClusterId", training.ClusterId);
                command.Parameters.AddWithValue("@SortTraining", training.SortTraining);
                command.Parameters.AddWithValue("@Amount", training.Amount);
                command.Parameters.AddWithValue("@TimeInSeconds", training.TimeInSeconds);
                command.Parameters.AddWithValue("@Meters", training.Meters);
                command.Parameters.AddWithValue("@DateTime", training.DateTime);
                command.Parameters.AddWithValue("@PersonId", training.PersonId);
                command.Parameters.AddWithValue("@ForUser", training.ForUser);
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
                            ForUser = Convert.ToBoolean(reader["ForUser"])
                        };
                        trainings.Add(training);
                    }
                }
            }
            return trainings;
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
                command.Parameters.AddWithValue("@ForUser", training.ForUser);
                command.ExecuteNonQuery();
            }
        }
    }
}
