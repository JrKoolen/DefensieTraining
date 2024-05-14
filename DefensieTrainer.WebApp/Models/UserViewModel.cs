using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace DefensieTrainer.WebApp.Models
{
    public class UserViewModel
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public float Weight { get; set; }
        [Required]
        public float Length { get; set; }
        [Required]
        public DateTime ArrivalDate { get; set; }
        [Required]
        public string ArmedForce { get; set; }
    }
}
