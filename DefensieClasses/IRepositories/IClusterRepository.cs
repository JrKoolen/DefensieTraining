namespace DefensieTrainer.Domain.IRepositories
{
    public interface IClusterRepository
    {
        Cluster GetById(int id);

        List<Cluster> GetByClusterIds(int clusterId);

    }
}
