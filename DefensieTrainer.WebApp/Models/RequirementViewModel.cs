using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using DefensieTrainer.Domain.DTO.IN;

public class RequirementViewModel
{
    
    [Required(ErrorMessage = "Name is required")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Description is required")]
    public string? Description { get; set; }

    public int? ClusterId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "SortTraining must be greater than 0")]
    public int SortTraining { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than 0")]
    public int Amount { get; set; }

    public int TimeInSeconds { get; set; }

    public List<SelectListItem>? SortTrainingOptions { get; set; }

    public PostRequirementDto ToDto()
    {
        return new PostRequirementDto
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
