using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefensieTrainer.Dal.Repositories
{
    public class ENV
    {
        private string ConnectionString = "server=localhost;user=root;password=GULAGwarrior1;";
        private string DataBaseName = "DefensieDB";
        public ENV()
        {

        }

        public string GetName()
        {
            return DataBaseName;
        }
        public string GetConnectionString()
        {
            return ConnectionString;
        }

    }
}
