﻿using DefensieTrainer.Domain.DTO.OUT;
using DefensieTrainer.Domain.DTO.IN;
namespace DefensieTrainer.Domain.IRepositories
{
    public interface IClusterRepository
    {
        ClusterDto GetById(int id);

        void CreateCluster(Cluster cluster);

        void UpdateCluster(PostClusterDto postclusterdDto);

        void DeleteCluster(int id);

        void DeleteCluster(int[] id);

        public List<ClusterDto> GetAllClusters();

    }
}
