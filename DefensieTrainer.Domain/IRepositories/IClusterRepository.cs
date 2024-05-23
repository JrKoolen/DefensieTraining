using DefensieTrainer.Domain.DTO;
namespace DefensieTrainer.Domain.IRepositories
{
    public interface IClusterRepository
    {
        ClusterDto GetById(int id);

        void CreateCluster(Cluster cluster);

        void UpdateCluster(CreateClusterDto postclusterdDto);

        void DeleteCluster(int id);

        void DeleteCluster(int[] id);

        public List<ClusterDto> GetAllClusters();

    }
}
