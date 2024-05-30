using System.Security.Cryptography.X509Certificates;

namespace DefensieTrainer.WebApp.Models
{
    public class UserDashboardViewModel
    {
        public int AmountOfCompletedTrainings { get; set; }
        public DateTime LatestFinishedTraining {  get; set; }
        public DateTime UserDeadLine {  get; set; }

    }
}
