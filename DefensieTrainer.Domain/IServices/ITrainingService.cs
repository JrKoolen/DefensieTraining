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
        void AddNewTraining(string Email, CreateUserTrainingDto training);
        void DeleteTraining(int trainingId);
        List<ReadTrainingDto> GetAllTrainings();
        ReadTrainingDto GetTrainingById(int trainingId);
        void UpdateTraining(ReadTrainingDto training);
        ReadDashboardDto GetDashboardByEmail(string email);
        ReadTrainingDto CreateNewTraining(string Email);
        ReadTrainingDto GetOldestTraining();
        void SaveFeedBack(CreateFeedbackDto dto);
        ReadFeedbackDto GetFeedbackByEmail(string email);
    }
}
