using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefensieTrainer.Domain.DTO
{
    public class CreateFeedbackDto
    {
        public int TrainingId { get; set; }
        public int PersonId { get; set; }
        public string Feedback {  get; set; }
    }
}
