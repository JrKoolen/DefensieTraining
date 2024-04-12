using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Dto
{
    internal class RequirementDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get;set; }
        public int ClusterId { get; set; }
        public int RequiredSortTraining { get; set; }
        public int RequiredAmount { get; set; }
        public int RequiredTimeInSeconds { get; set; }
    }
}
