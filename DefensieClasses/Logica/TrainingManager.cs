using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Runtime.CompilerServices;

public class TrainingManager
{
	private string User { get; set; }
	private Cluster Cluster { get; set; }
    //get latest training from user from the data base? 
    private int SortTraining { get; set; }
    private int Amount { get; set; }
    private int Time { get; set; }

    private DateTime DateTime { get; set; }
    public static List<SelectListItem> SortTrainingOptions { get; private set; }



    public TrainingManager()
	{
        SortTrainingOptions = new List<SelectListItem>
            {
                //move to class
            new SelectListItem { Value = "1", Text = "Hardlopen" },
            new SelectListItem { Value = "2", Text = "Zwemmen" },
            };
    }
    public Training CreateTraining(Training latestTraining, Cluster desiredCluster)
    {

        return null;

    }
    public List<SelectListItem> GetTrainingOptions()
    {
        return SortTrainingOptions;
    }


    
}
