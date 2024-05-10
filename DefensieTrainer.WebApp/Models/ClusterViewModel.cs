using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using DefensieTrainer.Domain.DTO.IN;
using DefensieTrainer.Domain.DTO.OUT;

namespace DefensieTrainer.WebApp.Models
{

    public class ClusterViewModel
    {
        [Required(ErrorMessage = "Cluster is required")]
        public int ClusterLevel { get; set; }
        public string Description { get; set; }



        public List<Requirement>? Requirements = new List<Requirement>();


        public PostClusterDto ToDto()
        {
            return new PostClusterDto()
            {
                ClusterLevel = this.ClusterLevel,
                Description = this.Description,
                Requirements = this.Requirements

            };
        }
    }
}
