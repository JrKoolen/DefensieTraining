using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefensieTrainer.Domain.IRepositories
{
    public interface IRequirementRepository
    {
        Requirement GetById(int id);

        void CreateRequirement(Requirement requirement);

        void UpdateRequirement(Requirement requirement);

        void DeleteRequirement(int id);

        void DeleteRequirements(int[] id);
    }
}
