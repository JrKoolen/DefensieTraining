namespace DefensieTrainer.WebApp.Models
{
    public class NextTrainingForUserViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ClusterId { get; set; }
        public int SortTraining { get; set; }
        public decimal Amount { get; set; }
        public int TimeInSeconds { get; set; }
        public int Meters { get; set; }
    }
}

