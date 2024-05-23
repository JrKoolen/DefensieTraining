using DefensieTrainer.Domain.DTO;

namespace DefensieTrainer.Domain.IRepositories
{
    public interface IRequirementRepository
    {
        Requirement GetById(int id);

        void CreateRequirement(Requirement requirement);

        void UpdateRequirement(Requirement requirement);

        void DeleteRequirement(int id);

        void DeleteRequirements(int[] id);

        List<RequirementDto> GetAllRequirements();

    }
}
