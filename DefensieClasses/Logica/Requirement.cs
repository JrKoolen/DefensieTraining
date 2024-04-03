using System;

public class Requirement
{
    public string Name{get; private set;}
    public string Description{ get; private set;}
    public int SortTraining{get; private set;}
    public int Amount{get; private set;}
    public int Time{get; private set;}

    private static Dictionary<int, (string, int, int)> TrainingDictionary = new Dictionary<int, (string, int, int)>();

    public Requirement(string name, string description, int sortTraining, int amount, int time)
    {
        this.Name = name;
        this.Description = description;
        this.SortTraining = sortTraining;
        this.Amount = amount;
        this.Time = time;

        if (!TrainingDictionary.ContainsKey(sortTraining))
        {
            TrainingDictionary.Add(sortTraining, (this.Description, this.Amount, this.Time));
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
            return new Requirement(Name, description, sortTraining, amount, time);
        }
        else
        {
            return null;
        }
    }


}