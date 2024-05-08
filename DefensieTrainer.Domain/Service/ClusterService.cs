using DefensieTrainer.Domain.IServices;
using DefensieTrainer.Domain.IRepositories;
using DefensieTrainer.Domain.DTO.OUT;
using DefensieTrainer.Domain.DTO.IN;

namespace DefensieTrainer.Domain.Service
{
    public class ClusterService : IClusterService
    {
        public readonly IClusterRepository _clusterRepository;

        public ClusterService(IClusterRepository clusterRepository)
        {
            _clusterRepository = clusterRepository;
        }

        public void ChangeCluster(PostClusterDto ClustertDto)
        {
            throw new NotImplementedException();
        }

        public void CreateCluster(PostClusterDto clusterDto)
        {
            Cluster cluster = new Cluster()
            {
                ClusterLevel = clusterDto.ClusterLevel,
                Description = clusterDto.Description,
                Requirements = clusterDto.Requirements,
            };
        }

        public void RemoveCluster(int companyId)
        {
            throw new NotImplementedException();
        }

        public void RemoveCluster(List<int> companyIds)
        {
            throw new NotImplementedException();
        }
    }
}
