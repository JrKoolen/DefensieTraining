﻿namespace DefensieTrainer.Domain.DTO
{
    public class CreateClusterDto
    {
        public int? Id { get; set; }
        public int ClusterLevel { get; set; }
        public string Description { get; set; }
        public List<ReadRequirementDto> Requirements = new List<ReadRequirementDto>();
    }
}
