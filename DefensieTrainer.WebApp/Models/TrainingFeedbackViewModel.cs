using System.ComponentModel.DataAnnotations;

namespace DefensieTrainer.WebApp.Models
{
    public class TrainingFeedbackViewModel
    {
    public int TrainingId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public int Meters { get; set; }
    public string SortTraining {  get; set; }
    [Required]
    public string Feedback { get; set; }
    public int TimeInSeconds { get; set; }
    public int PersonId { get; set; }
    }
}
