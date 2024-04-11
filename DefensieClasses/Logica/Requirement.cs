using System;

public class Requirement
{
    public int Id {  get; set; }
    public string Name{get; set;}
    public string Description{ get; set;}
    public int ClusterId { get; set;}
    public int SortTraining{get; set;}
    public int Amount{get; set;}
    public int TimeInSeconds{get; set;}

    private static Dictionary<int, (string, int, int)> TrainingDictionary = new Dictionary<int, (string, int, int)>();
    

    public Requirement(int id, string name, string description, int clusterId, int sortTraining, int amount, int time)
    {
        this.Id = id;
        this.Name = name;
        this.Description = description;
        this.ClusterId = clusterId;
        this.SortTraining = sortTraining;
        this.Amount = amount;
        this.TimeInSeconds = time;

        if (!TrainingDictionary.ContainsKey(sortTraining))
        {
            TrainingDictionary.Add(sortTraining, (this.Description, this.Amount, this.TimeInSeconds));
        }
        else
        {
            Console.WriteLine($"SortTraining {sortTraining} already exists.");
        }
    }
    
    
    public string GetDetails(){
        string details = $"name: {Name}, description: {Description}, ";
        return details;
    }
    public Requirement? GetRequirement(int sortTraining)
    {
        if (TrainingDictionary.ContainsKey(sortTraining))
        {
            var (description, amount, time) = TrainingDictionary[sortTraining];
            return new Requirement(Id, Name, description, ClusterId, sortTraining, amount, time);
        }
        else
        {
            return null;
        }
    }


}