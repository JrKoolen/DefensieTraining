using DefensieTrainer.Domain.DTO;

namespace DefensieTrainer.Domain.IServices
{
    public interface IRequirementServices
    {
        public void CreateRequirement(CreateRequirementDto requirementDto);

        public void ChangeRequirement(RequirementDto requirementDto);

        public void RemoveRequirement(int companyId);

        public void RemoveRequirement(List<int> companyIds);

        public List<Requirement> GetAllRequirements();
    }

}