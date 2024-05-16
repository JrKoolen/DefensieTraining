using DefensieTrainer.Domain.DTO.IN;
using DefensieTrainer.Domain.DTO.OUT;

namespace DefensieTrainer.Domain.IRepositories
{
    public interface ITrainingRepository
    {
        void AddNewTraining(PostTrainingDto training);

        TrainingDto GetTrainingById(int trainingId);

        List<TrainingDto> GetAllTrainings();

        void UpdateTraining(TrainingDto training);

        void DeleteTraining(int trainingId);

    }
}
