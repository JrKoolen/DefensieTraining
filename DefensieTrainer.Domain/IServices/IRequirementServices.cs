using DefensieTrainer.Domain.DTO.OUT;
using DefensieTrainer.Domain.DTO.IN;

namespace DefensieTrainer.Domain.IServices;


public interface IRequirementServices
{
    public void CreateRequirement(PostRequirementDto requirementDto);

    public void ChangeRequirement(RequirementDto requirementDto);

    public void RemoveRequirement(int companyId);

    public void RemoveRequirement(List<int> companyIds);

    public List<Requirement> GetAllRequirements();
}
