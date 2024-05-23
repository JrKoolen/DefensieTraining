using DefensieTrainer.Domain.IServices;
using DefensieTrainer.Domain.IRepositories;
using DefensieTrainer.Domain.DTO;

namespace DefensieTrainer.Domain.Service
{
    public class UserService : IUserServices
    {
        public readonly IUserRepository _UserRepository;

        public UserService(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }

        public void CreateUser(CreateUserDto userInput)
        {
            _UserRepository.CreateUser(userInput);
        }

        public void DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public UserDto GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(int userId, CreateUserDto userInput)
        {
            throw new NotImplementedException();
        }
    }
}

