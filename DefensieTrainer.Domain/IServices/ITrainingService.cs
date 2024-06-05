using DefensieTrainer.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefensieTrainer.Domain.IServices
{
    public interface ITrainingService
    {
        void AddNewTraining(string Email, UserTrainingInputDto training);
        void DeleteTraining(int trainingId);
        List<TrainingDto> GetAllTrainings();
        TrainingDto GetTrainingById(int trainingId);
        void UpdateTraining(TrainingDto training);
        DashboardDto GetDashboardByEmail(string email);
        TrainingDto CreateNewTraining(string Email);
        TrainingDto GetOldestTraining();
        void SaveFeedBack(TrainingDto dto);
    }
}
