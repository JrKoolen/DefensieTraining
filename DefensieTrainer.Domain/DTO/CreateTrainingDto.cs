namespace DefensieTrainer.Domain.DTO
{
    public class CreateTrainingDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? ClusterId { get; set; }
        public int SortTraining { get; set; }
        public int Amount { get; set; }
        public int TimeInSeconds { get; set; }
        public int Meters { get; set; }
        public DateTime DateTime { get; set; }
        public int PersonId { get; set; }
        public Boolean ForUser { get; set; }
    }
}
