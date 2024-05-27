using DefensieTrainer.Domain.DTO;
using DefensieTrainer.Domain.Logica;

namespace DefensieTrainer.Domain.IRepositories
{
    public interface IPersonRepository
    {


        PersonDto GetById(int id);

        void CreateUser(CreatePersonDto User);
        PersonDto GetUserByEmail(string email);
        void UpdateUser(CreatePersonDto User);

        void DeleteUser(int id);

        void DeleteUsers(int[] id);

        List<PersonDto> GetAllUsers();
    }
}
