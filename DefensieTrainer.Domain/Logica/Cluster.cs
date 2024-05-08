using System;

public class Cluster
{
    public int ClusterLevel{get; set;}
    public string Description{get; set;}
    public List<Requirement> Requirements = new List<Requirement>();

    public Cluster(int clusterlevel, string description, List<Requirement> requirements)
    {
        ClusterLevel = clusterlevel;
        this.Description = description;
        this.Requirements = requirements;
    }

    public Cluster()
    {

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