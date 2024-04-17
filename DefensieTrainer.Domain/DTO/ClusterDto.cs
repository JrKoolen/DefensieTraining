namespace DefensieTrainer.Domain.Dto;


internal class ClusterDto
{
    private int ClusterLevel { get; set; }
    private string Description { get; set; }

    private List<Requirement> Requirements = new List<Requirement>();
}

