using DefensieTrainer.Domain.DTO;

namespace DefensieTrainer.Domain.IRepositories
{
    public interface IRequirementRepository
    {
        ReadRequirementDto GetById(int id);

        void CreateRequirement(CreateRequirementDto requirement);

        void UpdateRequirement(ReadRequirementDto requirement);

        void DeleteRequirement(int id);

        void DeleteRequirements(int[] id);

        List<ReadRequirementDto> GetAllRequirements();

    }
}
