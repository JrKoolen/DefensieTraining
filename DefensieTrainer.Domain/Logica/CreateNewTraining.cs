using System;
using System.Collections.Generic;
using System.Linq;
using DefensieTrainer.Domain.DTO;

namespace DefensieTrainer.Domain.Logica
{
    public class TrainingCreator
    {
        public List<TrainingDto> AllTrainings { get; set; }
        public List<TrainingDto> AllRunningTrainings { get; set; }
        public List<TrainingDto> AllSwimmingTrainings { get; set; }

        public TrainingCreator()
        {
            AllTrainings = new List<TrainingDto>();
            AllRunningTrainings = new List<TrainingDto>();
            AllSwimmingTrainings = new List<TrainingDto>();
        }

        public List<TrainingDto> CreateNewTraining(int mode)
        {
            AllRunningTrainings.Clear();
            AllSwimmingTrainings.Clear();

            foreach (TrainingDto training in AllTrainings)
            {
                if (training.SortTraining == 1)
                {
                    AllRunningTrainings.Add(training);
                }
                else if (training.SortTraining == 2)
                {
                    AllSwimmingTrainings.Add(training);
                }
            }

            return mode == 1 ? GenerateNewTrainingSession(AllRunningTrainings) : GenerateNewTrainingSession(AllSwimmingTrainings);
        }

        public List<TrainingDto> GenerateNewTrainingSession(List<TrainingDto> trainings)
        {
            if (trainings == null || trainings.Count == 0) return new List<TrainingDto>();

            var averageAmount = trainings.Average(t => t.Amount);
            var averageTime = trainings.Average(t => t.TimeInSeconds);
            var averageMeters = trainings.Average(t => t.Meters);
            var newTraining = new TrainingDto
            {
                Id = trainings.Max(t => t.Id) + 1, 
                Name = "New Training Session",
                Description = "Generated training session based on past performance",
                ClusterId = trainings.First().ClusterId, 
                SortTraining = trainings.First().SortTraining,
                Amount = (int)Math.Ceiling(averageAmount * 1.1),
                TimeInSeconds = (int)Math.Ceiling(averageTime * 1.1),
                Meters = (int)Math.Ceiling(averageMeters * 1.1),
                DateTime = DateTime.Now,
                PersonId = trainings.First().PersonId, 
                NeedsFeedback = false
            };
            return new List<TrainingDto> { newTraining };
        }
    }
}
