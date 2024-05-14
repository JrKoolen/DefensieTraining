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

        public void ChangeCluster(PostClusterDto postClustertDto)
        {
            _clusterRepository.UpdateCluster(postClustertDto);
        }

        public void CreateCluster(PostClusterDto clusterDto)
        {
            Cluster cluster = new Cluster()
            {
                ClusterLevel = clusterDto.ClusterLevel,
                Description = clusterDto.Description,
                Requirements = clusterDto.Requirements,
            };
            _clusterRepository.CreateCluster(cluster);
        }

        public List<Cluster> GetAllClusters()
        {
            List<Cluster> Clusters = new List<Cluster>();

            foreach (var clusterDto in _clusterRepository.GetAllClusters())
            {
                Cluster cluster = new Cluster
                {
                    ClusterLevel = clusterDto.ClusterLevel,
                    Description = clusterDto.Description,
                    Requirements = clusterDto.Requirements,
                };

                Clusters.Add(cluster);
            }
            return Clusters;

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
