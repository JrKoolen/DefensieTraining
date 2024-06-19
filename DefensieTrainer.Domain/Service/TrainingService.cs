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

        public void AddNewTraining(string Email, CreateUserTrainingDto training)
        {
            _trainingRepository.AddNewTraining(Email, training);
        }

        public ReadTrainingDto CreateNewTraining(string email)
        {
            List<ReadTrainingDto> allTrainings = _trainingRepository.GetAllTrainingsByEMail(email);

            _trainingCreator.AllTrainings = allTrainings;
            List<ReadTrainingDto> newTrainingSessions = _trainingCreator.CreateNewTraining(1); 
            if (newTrainingSessions == null || newTrainingSessions.Count == 0)
            {
                return null;
            }
            ReadTrainingDto newTrainingSession = newTrainingSessions.First();
            return newTrainingSession;
        }

    public void DeleteTraining(int trainingId)
        {
            _trainingRepository.DeleteTraining(trainingId);
        }

        public List<ReadTrainingDto> GetAllTrainings()
        {
            return _trainingRepository.GetAllTrainings();
        }

        public ReadDashboardDto GetDashboardByEmail(string email)
        {
            return _trainingRepository.GetDashboardByEmail(email);
        }

        public ReadTrainingDto GetOldestTraining()
        {
            return _trainingRepository.GetOldestTraining();
        }

        public ReadTrainingDto GetTrainingById(int trainingId)
        {
            return _trainingRepository.GetTrainingById(trainingId);
        }

        public void SaveFeedBack(CreateFeedbackDto dto)
        {
            _trainingRepository.AddFeedbackToTraining(dto);
        }

        public void UpdateTraining(ReadTrainingDto training)
        {
            _trainingRepository.UpdateTraining(training);
        }

        public ReadFeedbackDto GetFeedbackByEmail(string email)
        {
            return _trainingRepository.GetFeedbackByEmail(email);
        }


    }
}
