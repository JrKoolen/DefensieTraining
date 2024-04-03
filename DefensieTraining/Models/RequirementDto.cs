using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Dto
{
    internal class RequirementDto
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int SortTraining { get; private set; }
        public int Amount { get; private set; }
        public int Time { get; private set; }
    }
}
