using System.ComponentModel.DataAnnotations;
using DefensieTrainer.Domain.DTO;

namespace DefensieTrainer.WebApp.Models
{
    public class ClusterViewModel
    {
        public int? id { get; set; }
        [Required]
        public int ClusterLevel { get; set; }
        [Required]
        public string Description { get; set; }
        public List<ReadRequirementDto>? SelectedRequirements { get; set; }
        public List<ClusterDto>? Clusters { get; set; }
        public List<ReadRequirementDto>? Requirements = new List<ReadRequirementDto>();

        public CreateClusterDto ToDto()
        {
            return new CreateClusterDto()
            {
                Id = this.id,
                ClusterLevel = this.ClusterLevel,
                Description = this.Description,
                Requirements = this.SelectedRequirements
            };
        }
    }
}
