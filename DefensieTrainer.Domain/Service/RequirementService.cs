using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DefensieTrainer.Domain.Dto;
using DefensieTrainer.Domain.IServices;
using DefensieTrainer.Domain.IRepositories;

namespace DefensieTrainer.Domain.Service
{
    internal class RequirementService : IRequirementServices
    {
        private readonly IRequirementRepository _requirementRepository;
        public void ChangeRequirement(RequirementDto requirementDto)
        {
            Requirement requirement = new() 
            {
                Id = requirementDto.Id,
                Name = requirementDto.Name,
                Description = requirementDto.Description,
                Amount = requirementDto.Amount,
                ClusterId = requirementDto.ClusterId,
                SortTraining = requirementDto.SortTraining,
                TimeInSeconds = requirementDto.TimeInSeconds,

            };
        }

        public void CreateRequirement(RequirementDto requirementDto)
        {
            throw new NotImplementedException();
        }

        public void RemoveRequirement(int companyId)
        {
            throw new NotImplementedException();
        }

        public void RemoveRequirement(List<int> companyIds)
        {
            throw new NotImplementedException();
        }
    }
}
