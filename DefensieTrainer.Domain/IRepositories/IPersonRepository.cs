using DefensieTrainer.Domain.DTO;

namespace DefensieTrainer.Domain.IRepositories
{
    public interface IPersonRepository
    {


        ReadPersonDto GetById(int id);

        void CreateUser(CreatePersonDto User);
        ReadPersonDto GetUserByEmail(string email);
        void UpdateUserRole(string email, string role);
        void DeleteUser(int id);
        void DeleteUsers(int[] id);
        List<ReadPersonDto> GetAllUsers();
        
    }
}
