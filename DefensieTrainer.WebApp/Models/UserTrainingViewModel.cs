using DefensieTrainer.Domain.DTO;
using System.ComponentModel.DataAnnotations;

namespace DefensieTrainer.WebApp.Models
{
    public class UserTrainingViewModel
    {
        [Required]
        public string UserEmail;
        [Display(Name = "What kind of training did you do?")]
        public int SortTraining { get; set; }
        [Display(Name = "How many sets have you done?")]
        public int Amount { get; set; }
        [Display(Name = "How long was the exercise?")]
        public int TimeInSeconds { get; set; }
        [Display(Name = "What distance did you go for the exercise?")]
        public int Meters { get; set; }
        [Display(Name = "When did you do this exercise?")]
        public Boolean NeedsFeedback { get; set; }

        public UserTrainingInputDto ToDto()
        {
            return new UserTrainingInputDto
            {
                
                TimeInSeconds = this.TimeInSeconds,
                SortTraining = this.SortTraining,
                Amount = this.Amount,
                Meters = this.Meters,
                DateTime = DateTime.Now,
                NeedsFeedback = this.NeedsFeedback
            };
        }
    }
}
