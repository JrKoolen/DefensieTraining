using DefensieTrainer.Domain.IRepositories;
using Logica.ENV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repositories
{

    public class ClusterRepository : IClusterRepository
    {
        public List<Cluster> GetByClusterIds(int clusterId)
        {
            throw new NotImplementedException();
        }

        public Cluster GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
