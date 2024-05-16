using DefensieTrainer.Domain.DTO.IN;
using DefensieTrainer.Domain.DTO.OUT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefensieTrainer.Domain.IServices
{
    public interface ITrainingService
    {
        void AddNewTraining(PostTrainingDto training);
        void DeleteTraining(int trainingId);
        List<TrainingDto> GetAllTrainings();
        TrainingDto GetTrainingById(int trainingId);
        void UpdateTraining(TrainingDto training);
    }
}
