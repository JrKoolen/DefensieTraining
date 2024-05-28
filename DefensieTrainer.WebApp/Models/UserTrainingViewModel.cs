using DefensieTrainer.Domain.DTO;

namespace DefensieTrainer.WebApp.Models
{
    public class UserTrainingViewModel
    {
        public int? ClusterId { get; set; }
        public int SortTraining { get; set; }
        public int Amount { get; set; }
        public int TimeInSeconds { get; set; }
        public int Meters { get; set; }
        public DateTime DateTime { get; set; }
        public int PersonId { get; set; }

        public UserTrainingInputDto ToDto()
        {
            return new UserTrainingInputDto
            {
                ClusterId = this.ClusterId,
                TimeInSeconds = this.TimeInSeconds,
                SortTraining = this.SortTraining,
                Amount = this.Amount,
                Meters = this.Meters,
                DateTime = this.DateTime,
                PersonId = this.PersonId
            };
        }
    }
}
