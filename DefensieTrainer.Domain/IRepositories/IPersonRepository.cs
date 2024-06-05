using DefensieTrainer.Domain.DTO;
using Newtonsoft.Json.Bson;

namespace DefensieTrainer.Domain.IRepositories
{
    public interface IPersonRepository
    {


        PersonDto GetById(int id);

        void CreateUser(CreatePersonDto User);
        PersonDto GetUserByEmail(string email);
        void UpdateUserRole(string email, string role);
        void DeleteUser(int id);
        void DeleteUsers(int[] id);
        List<PersonDto> GetAllUsers();
        
    }
}
