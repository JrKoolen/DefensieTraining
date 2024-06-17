﻿namespace DefensieTrainer.Domain.DTO
{
    public class DashboardDto
    {
        public string ClusterLevel { get; set; }
        public int AmountOfCompletedTrainings { get; set; }
        public DateTime LatestFinishedTraining { get; set; }
        public DateTime UserDeadline { get; set; }
    }
}
