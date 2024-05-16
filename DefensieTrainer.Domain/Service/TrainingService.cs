using DefensieTrainer.Domain.DTO.IN;
using DefensieTrainer.Domain.DTO.OUT;
using DefensieTrainer.Domain.IRepositories;
using DefensieTrainer.Domain.IServices;

namespace DefensieTrainer.Services
{
    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _trainingRepository;

        public TrainingService(ITrainingRepository trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }

        public void AddNewTraining(PostTrainingDto training)
        {
            _trainingRepository.AddNewTraining(training);
        }

        public void DeleteTraining(int trainingId)
        {
            _trainingRepository.DeleteTraining(trainingId);
        }

        public List<TrainingDto> GetAllTrainings()
        {
            return _trainingRepository.GetAllTrainings();
        }

        public TrainingDto GetTrainingById(int trainingId)
        {
            return _trainingRepository.GetTrainingById(trainingId);
        }

        public void UpdateTraining(TrainingDto training)
        {
            _trainingRepository.UpdateTraining(training);
        }
    }
}
