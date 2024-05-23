using DefensieTrainer.Domain.DTO;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace DefensieTrainer.WebApp.Models
{
    public class RegisterViewModel
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public float Weight { get; set; }
        [Required]
        public float Length { get; set; }
        [Required]
        public DateTime ArrivalDate { get; set; }
        [Required]
        public string ArmedForce { get; set; }

        public CreateUserDto ToPostDto()
        {
            return new CreateUserDto
            {
                Name = this.Name,
                LastName = this.LastName,
                Weight = this.Weight,
                Length = this.Length,
                Email = this.Email,
                Password = this.Password,
                ArrivalDate = this.ArrivalDate,
                ArmedForce = this.ArmedForce,
            };
        }
    }
}
