using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefensieTrainer.Domain.DTO.IN
{
    public class PostTrainingDto
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

    }
}
