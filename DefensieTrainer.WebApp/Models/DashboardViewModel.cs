namespace DefensieTrainer.WebApp.Models
{
    public class DashboardViewModel
    {
        public string UserName { get; set; }
        public string UserClusterId { get; set; }
        public int AmountOfCompletedTrainings { get; set; }
        public DateTime LatestFinishedTraining { get; set; }
        public DateTime UserDeadline { get; set; }
    }
}
