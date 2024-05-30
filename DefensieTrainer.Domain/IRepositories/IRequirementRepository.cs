using DefensieTrainer.Domain.DTO;

namespace DefensieTrainer.Domain.IRepositories
{
    public interface IRequirementRepository
    {
        RequirementDto GetById(int id);

        void CreateRequirement(CreateRequirementDto requirement);

        void UpdateRequirement(RequirementDto requirement);

        void DeleteRequirement(int id);

        void DeleteRequirements(int[] id);

        List<RequirementDto> GetAllRequirements();

    }
}
