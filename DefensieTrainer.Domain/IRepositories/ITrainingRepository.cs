using DefensieTrainer.Domain.DTO;

namespace DefensieTrainer.Domain.IRepositories
{
    public interface ITrainingRepository
    {
        void AddNewTraining(string Email, UserTrainingInputDto training);
        TrainingDto GetTrainingById(int trainingId);
        List<TrainingDto> GetAllTrainingsByEMail(string email);
        List<TrainingDto> GetAllTrainings();
        void UpdateTraining(TrainingDto training);
        void DeleteTraining(int trainingId);
        DashboardDto GetDashboardByEmail(string email);
        TrainingDto GetOldestTraining();
        void AddFeedbackToTraining(CreateFeedbackDto dto);


    }
}
