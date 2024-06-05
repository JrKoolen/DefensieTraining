using Microsoft.CodeAnalysis.CSharp.Syntax;
using DefensieTrainer.Domain.DTO;
using DefensieTrainer.Domain.Enums;

namespace DefensieTrainer.WebApp.Models
{
    public class TrainingFeedbackViewModel
{
    public int TrainingId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public int Meters { get; set; }
    public Dictionary<string, string> SortTraining { get; set; } 
    public int TimeInSeconds { get; set; }
    public string Feedback { get; set; }
}
    }
