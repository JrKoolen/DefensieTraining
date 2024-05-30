using DefensieTrainer.Domain.DTO;
using System.ComponentModel.DataAnnotations;

namespace DefensieTrainer.WebApp.Models
{
    public class UserTrainingViewModel
    {
        public int? ClusterId { get; set; }
        public int? PersonId { get; set; } 
        [Display(Name = "What kind of training did you do?")]
        public int SortTraining { get; set; }
        [Display(Name = "How many sets have you done?")]
        public int Amount { get; set; }
        [Display(Name = "How long was the exercise?")]
        public int TimeInSeconds { get; set; }
        [Display(Name = "What distance did you go for the exercise?")]
        public int Meters { get; set; }
        [Display(Name = "What day did you do this exercise?")]
        public DateTime DateTime { get; set; }

        public Boolean NeedsFeedback { get; set; }

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
                PersonId = this.PersonId,
                NeedsFeedback = this.NeedsFeedback
            };
        }
    }
}
