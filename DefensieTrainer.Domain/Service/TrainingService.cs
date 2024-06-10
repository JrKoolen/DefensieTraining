using DefensieTrainer.Domain.DTO;
using DefensieTrainer.Domain.IRepositories;
using DefensieTrainer.Domain.IServices;
using DefensieTrainer.Domain.Logica;
using System.Runtime.CompilerServices;

namespace DefensieTrainer.Domain.Service
{
    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _trainingRepository;
        private readonly TrainingCreator _trainingCreator;

        public TrainingService(ITrainingRepository trainingRepository)
        {
            _trainingRepository = trainingRepository;
            _trainingCreator = new TrainingCreator();
        }

        public void AddNewTraining(string Email, UserTrainingInputDto training)
        {
            _trainingRepository.AddNewTraining(Email, training);
        }

        public TrainingDto CreateNewTraining(string email)
        {
            List<TrainingDto> allTrainings = _trainingRepository.GetAllTrainingsByEMail(email);

            _trainingCreator.AllTrainings = allTrainings;
            List<TrainingDto> newTrainingSessions = _trainingCreator.CreateNewTraining(1); 
            if (newTrainingSessions == null || newTrainingSessions.Count == 0)
            {
                return null;
            }
            TrainingDto newTrainingSession = newTrainingSessions.First();
            return newTrainingSession;
    }

    public void DeleteTraining(int trainingId)
        {
            _trainingRepository.DeleteTraining(trainingId);
        }

        public List<TrainingDto> GetAllTrainings()
        {
            return _trainingRepository.GetAllTrainings();
        }

        public DashboardDto GetDashboardByEmail(string email)
        {
            return _trainingRepository.GetDashboardByEmail(email);
        }

        public TrainingDto GetOldestTraining()
        {
            return _trainingRepository.GetOldestTraining();
        }

        public TrainingDto GetTrainingById(int trainingId)
        {
            return _trainingRepository.GetTrainingById(trainingId);
        }

        public void SaveFeedBack(CreateFeedbackDto dto)
        {
            _trainingRepository.AddFeedbackToTraining(dto);
        }

        public void UpdateTraining(TrainingDto training)
        {
            _trainingRepository.UpdateTraining(training);
        }

    }
}
