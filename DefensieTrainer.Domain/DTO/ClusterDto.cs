namespace DefensieTrainer.Domain.DTO;


public class ClusterDto
{
    public int Id { get; set; }
    public int ClusterLevel { get; set; }
    public string Description { get; set; }

    public List<RequirementDto> Requirements = new List<RequirementDto>();
}

