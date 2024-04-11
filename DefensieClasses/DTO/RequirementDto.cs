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
        public int SortTraining { get; set; }
        public int Amount { get; set; }
        public int TimeInSeconds { get; set; }
    }
}
