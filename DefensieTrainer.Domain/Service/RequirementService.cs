using DefensieTrainer.Domain.IServices;
using DefensieTrainer.Domain.IRepositories;
using DefensieTrainer.Domain.DTO;

namespace DefensieTrainer.Domain.Service
{
    public class RequirementService : IRequirementServices
    {
        public readonly IRequirementRepository _requirementRepository;

        public RequirementService(IRequirementRepository requirementRepository)
        {
            _requirementRepository = requirementRepository;
        }
    
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

        public void CreateRequirement(CreateRequirementDto requirementDto)
        {
            Requirement requirement = new Requirement
            {
                ClusterId = requirementDto.ClusterId,
                Name = requirementDto.Name,
                Description = requirementDto.Description,
                SortTraining = requirementDto.SortTraining,
                Amount = requirementDto.Amount,
                TimeInSeconds = requirementDto.TimeInSeconds
            };

            _requirementRepository.CreateRequirement(requirement);
        }

        public List<Requirement> GetAllRequirements()
        {
            List<Requirement> requirements = new List<Requirement>();

            foreach (var requirementDto in _requirementRepository.GetAllRequirements())
            {
                Requirement requirement = new Requirement
                {
                    ClusterId = requirementDto.ClusterId,
                    Name = requirementDto.Name,
                    Description = requirementDto.Description,
                    SortTraining = requirementDto.SortTraining,
                    Amount = requirementDto.Amount,
                    TimeInSeconds = requirementDto.TimeInSeconds
                };

                requirements.Add(requirement);
            }
            return requirements;
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
