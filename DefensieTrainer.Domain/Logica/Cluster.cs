using System;

public class Cluster
{
    private int ClusterLevel{get; set;}
    private string Description{get; set;}
    private List<Requirement> Requirements = new List<Requirement>();



    public Cluster(int level, string description, List<Requirement> requirements)
    {
        ClusterLevel = level;
        this.Description = description;
        this.Requirements = requirements;
    }
    public void AddRequirement(Requirement requirement)
    {
        Requirements.Add(requirement);
    }
    public void RemoveRequirement(Requirement requirement)
    {
        Requirements.Remove(requirement);
    }
    public List<Requirement> GetAllRequirements()
    {
        return Requirements;
    }

}