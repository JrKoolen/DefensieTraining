namespace DefensieTrainer.Domain.DTO
{
    public class CreateUserTrainingDto
    {
        public int? ClusterId { get; set; }
        public int SortTraining { get; set; }
        public int Amount { get; set; }
        public int TimeInSeconds { get; set; }
        public int Meters { get; set; }
        public DateTime DateTime { get; set; }
        public int? PersonId { get; set; }
        public Boolean NeedsFeedback { get; set; }
    }
}
