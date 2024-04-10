using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefensieTrainer.Domain.IRepositories
{
    public interface IClusterRepository
    {
        Cluster GetById(int id);

        List<Cluster> GetByClusterIds(int clusterId);

    }
}
