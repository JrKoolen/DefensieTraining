﻿using DefensieTrainer.Domain.DTO;
using System.ComponentModel.DataAnnotations;

namespace DefensieTrainer.WebApp.Models
{
    public class UserTrainingViewModel
    {

        [Display(Name = "What kind of training did you do?")]
        [Required(ErrorMessage = "Please select a training type.")]
        public int SortTraining { get; set; }


        [Display(Name = "How many sets have you done?")]
        [Required]
        public int Amount { get; set; }

        [Display(Name = "How long was the exercise in seconds?")]
        [Required]
        public int TimeInSeconds { get; set; }

        [Display(Name = "What is the distance in meters?")]
        [Required]
        public int Meters { get; set; }

        [Display(Name = "When did you do this exercise?")]
        [Required]
        public bool NeedsFeedback { get; set; }

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
