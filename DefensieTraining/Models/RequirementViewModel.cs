﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

public class RequirementViewModel
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Description is required")]
    public string Description { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "SortTraining must be greater than 0")]
    public int SortTraining { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than 0")]
    public int Amount { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Time must be greater than 0")]
    public int Time { get; set; }

    public List<SelectListItem>? SortTrainingOptions { get; set; }

}
