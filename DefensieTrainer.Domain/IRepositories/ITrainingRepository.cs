using DefensieTrainer.Domain.DTO;

namespace DefensieTrainer.Domain.IRepositories
{
    public interface ITrainingRepository
    {
        void AddNewTraining(string Email, CreateUserTrainingDto training);
        ReadTrainingDto GetTrainingById(int trainingId);
        List<ReadTrainingDto> GetAllTrainingsByEMail(string email);
        List<ReadTrainingDto> GetAllTrainings();
        void UpdateTraining(ReadTrainingDto training);
        void DeleteTraining(int trainingId);
        ReadDashboardDto GetDashboardByEmail(string email);
        ReadTrainingDto GetOldestTraining();
        void AddFeedbackToTraining(CreateFeedbackDto dto);
        ReadFeedbackDto GetFeedbackByEmail(string email);
    }
}
