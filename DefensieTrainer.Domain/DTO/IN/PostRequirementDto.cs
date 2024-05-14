namespace DefensieTrainer.Domain.DTO.IN;
public class PostRequirementDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int? ClusterId { get; set; }
    public int SortTraining { get; set; }
    public int Amount { get; set; }
    public int TimeInSeconds { get; set; }
}
