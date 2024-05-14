using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefensieTrainer.Domain.Logica
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public float Weight { get; set; }
        public float Length { get; set; }
        public DateTime ArrivalDate { get; set; }
        public string ArmedForce { get; set; }
    }
}
