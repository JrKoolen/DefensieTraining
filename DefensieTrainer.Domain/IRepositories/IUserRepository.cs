using DefensieTrainer.Domain.DTO.IN;
using DefensieTrainer.Domain.DTO.OUT;
using DefensieTrainer.Domain.Logica;

namespace DefensieTrainer.Domain.IRepositories
{
    public interface IUserRepository
    {
        User GetById(int id);

        void CreateUser(PostUserDto User);

        void UpdateUser(PostUserDto User);

        void DeleteUser(int id);

        void DeleteUsers(int[] id);

        List<UserDto> GetAllUsers();
    }
}
