using DefensieTrainer.Domain.DTO;
using DefensieTrainer.Domain.Logica;

namespace DefensieTrainer.Domain.IRepositories
{
    public interface IUserRepository
    {


        UserDto GetById(int id);

        void CreateUser(CreateUserDto User);
        UserDto GetUserByEmail(string email);
        void UpdateUser(CreateUserDto User);

        void DeleteUser(int id);

        void DeleteUsers(int[] id);

        List<UserDto> GetAllUsers();
    }
}
