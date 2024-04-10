using System;

public class Requirement
{
    public int Id {  get; set; }
    public string RequiredName{get; set;}
    public string RequiredDescription{ get; set;}
    public int ClusterId { get; set;}
    public int RequiredSortTraining{get; set;}
    public int RequiredAmount{get; set;}
    public int RequiredTimeInSeconds{get; set;}

    private static Dictionary<int, (string, int, int)> TrainingDictionary = new Dictionary<int, (string, int, int)>();
    

    public Requirement(int id, string name, string description, int clusterId, int sortTraining, int amount, int time)
    {
        this.Id = id;
        this.RequiredName = name;
        this.RequiredDescription = description;
        this.ClusterId = clusterId;
        this.RequiredSortTraining = sortTraining;
        this.RequiredAmount = amount;
        this.RequiredTimeInSeconds = time;

        if (!TrainingDictionary.ContainsKey(sortTraining))
        {
            TrainingDictionary.Add(sortTraining, (this.RequiredDescription, this.RequiredAmount, this.RequiredTimeInSeconds));
        }
        else
        {
            Console.WriteLine($"SortTraining {sortTraining} already exists.");
        }
    }
    
    
    public string GetDetails(){
        string details = $"name: {RequiredName}, description: {RequiredDescription}, ";
        return details;
    }
    public Requirement? GetRequirement(int sortTraining)
    {
        if (TrainingDictionary.ContainsKey(sortTraining))
        {
            var (description, amount, time) = TrainingDictionary[sortTraining];
            return new Requirement(Id, RequiredName, description, ClusterId, sortTraining, amount, time);
        }
        else
        {
            return null;
        }
    }


}