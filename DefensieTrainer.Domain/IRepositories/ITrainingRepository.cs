using DefensieTrainer.Domain.DTO;

namespace DefensieTrainer.Domain.IRepositories
{
    public interface ITrainingRepository
    {
        void AddNewTraining(CreateTrainingDto training);

        TrainingDto GetTrainingById(int trainingId);

        List<TrainingDto> GetAllTrainings();

        void UpdateTraining(TrainingDto training);

        void DeleteTraining(int trainingId);

    }
}
