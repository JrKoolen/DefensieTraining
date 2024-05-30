using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.InteropServices;
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

        public List<RequirementDto>? SelectedRequirements { get; set; }
        public List<ClusterDto>? Clusters { get; set; }

        public List<RequirementDto>? Requirements = new List<RequirementDto>();


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
