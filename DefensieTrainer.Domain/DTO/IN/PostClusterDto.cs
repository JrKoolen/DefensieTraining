namespace DefensieTrainer.Domain.DTO.IN
{
    public class PostClusterDto
    {
        public int ClusterLevel { get; set; }
        public string Description { get; set; }
        public List<Requirement> Requirements = new List<Requirement>();
    }
}
