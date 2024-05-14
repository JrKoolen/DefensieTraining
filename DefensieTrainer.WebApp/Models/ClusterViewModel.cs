using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using DefensieTrainer.Domain.DTO.IN;
using DefensieTrainer.Domain.DTO.OUT;
using System.Runtime.InteropServices;

namespace DefensieTrainer.WebApp.Models
{

    public class ClusterViewModel
    {

        public int? id { get; set; }

        [Required]
        public int ClusterLevel { get; set; }

        [Required]
        public string Description { get; set; }

        public List<Requirement>? SelectedRequirements { get; set; }
        public List<Cluster>? Clusters { get; set; }

        public List<Requirement>? Requirements = new List<Requirement>();


        public PostClusterDto ToDto()
        {
            return new PostClusterDto()
            {
                Id = this.id,
                ClusterLevel = this.ClusterLevel,
                Description = this.Description,
                Requirements = this.SelectedRequirements
            };
        }
    }
}
