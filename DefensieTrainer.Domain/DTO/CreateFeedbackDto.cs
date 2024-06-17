namespace DefensieTrainer.Domain.DTO
{
    public class CreateFeedbackDto
    {
        public int TrainingId { get; set; }
        public int PersonId { get; set; }
        public string Feedback {  get; set; }
    }
}
