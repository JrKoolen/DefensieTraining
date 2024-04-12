using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

public class RequirementViewModel
{
    
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Description is required")]
    public string Description { get; set; }

    public int ClusterId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "SortTraining must be greater than 0")]
    public int RequiredSortTraining { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than 0")]
    public int RequiredAmount { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Time must be greater than 0")]
    public int RequiredTimeInSeconds { get; set; }

    public List<SelectListItem>? SortTrainingOptions { get; set; }

}
