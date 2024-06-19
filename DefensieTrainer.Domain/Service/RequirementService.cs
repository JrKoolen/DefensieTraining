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
    
        public void ChangeRequirement(ReadRequirementDto requirementDto)
        {
            _requirementRepository.UpdateRequirement(requirementDto);
        }

        public void CreateRequirement(CreateRequirementDto requirementDto)
        {
            _requirementRepository.CreateRequirement(requirementDto);
        }

        public List<ReadRequirementDto> GetAllRequirements()
        {
            List<ReadRequirementDto> requirements = new List<ReadRequirementDto>();

            foreach (var requirementDto in _requirementRepository.GetAllRequirements())
            {
                ReadRequirementDto requirement = new ReadRequirementDto
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
