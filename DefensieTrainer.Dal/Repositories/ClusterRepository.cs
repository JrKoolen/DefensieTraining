using DefensieTrainer.Domain.IRepositories;
using DefensieTrainer.Domain.Logica;

namespace DefensieTrainer.Dal.Repositories
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
