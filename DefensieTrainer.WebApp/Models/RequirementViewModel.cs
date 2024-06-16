using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using DefensieTrainer.Domain.DTO;

public class RequirementViewModel
{
    [Required(ErrorMessage = "Name is required")]
    [Display(Name = "Requirement Name")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "Description is required")]
    [Display(Name = "Requirement Description")]
    public string? Description { get; set; }
    public int? ClusterId { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "Sort Training must be 1 or 2")]
    [Display(Name = "Sort Training Type 1 = hardlopen 2 = zwemmen")]
    public int SortTraining { get; set; }
    [Range(1, 5, ErrorMessage = "Amount must be between 1 and 5")]
    [Display(Name = "Amount of sets")]
    public int Amount { get; set; }
    [Display(Name = "Time in Seconds")]
    public int TimeInSeconds { get; set; }
    public List<SelectListItem>? SortTrainingOptions { get; set; }

    public CreateRequirementDto ToDto()
    {
        return new CreateRequirementDto
        {
            Name = this.Name,
            Description = this.Description,
            ClusterId = this.ClusterId,
            SortTraining = this.SortTraining,
            Amount = this.Amount,
            TimeInSeconds = this.TimeInSeconds,
        };
    }

}
