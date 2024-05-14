using DefensieTrainer.Domain.DTO.OUT;
using DefensieTrainer.Domain.DTO.IN;

namespace DefensieTrainer.Domain.IServices
{
    public interface IClusterService
    {
        public void CreateCluster(PostClusterDto ClustertDto);

        public void ChangeCluster(PostClusterDto ClustertDto);

        public void RemoveCluster(int companyId);

        public void RemoveCluster(List<int> companyIds);

        public List<Cluster> GetAllClusters();
    }
}