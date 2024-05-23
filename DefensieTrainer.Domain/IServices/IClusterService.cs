using DefensieTrainer.Domain.DTO;

namespace DefensieTrainer.Domain.IServices
{
    public interface IClusterService
    {
        public void CreateCluster(CreateClusterDto ClustertDto);

        public void ChangeCluster(CreateClusterDto ClustertDto);

        public void RemoveCluster(int companyId);

        public void RemoveCluster(List<int> companyIds);

        public List<Cluster> GetAllClusters();
    }
}