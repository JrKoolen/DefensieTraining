namespace DefensieTrainer.Domain.DTO.OUT;


public class ClusterDto
{
    public int Id { get; set; }
    public int ClusterLevel { get; set; }
    public string Description { get; set; }

    public List<Requirement> Requirements = new List<Requirement>();
}

