using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Dto
{
    internal class ClusterDto
    {
        private int ClusterLevel { get; set; }
        private string Description { get; set; }

        private List<Requirement> Requirements = new List<Requirement>();
    }
}
