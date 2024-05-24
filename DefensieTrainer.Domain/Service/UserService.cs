using DefensieTrainer.Domain.IServices;
using DefensieTrainer.Domain.IRepositories;
using DefensieTrainer.Domain.DTO;

namespace DefensieTrainer.Domain.Service
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public UserDto AuthenticateUser(string email, string password)
        {
            UserDto user = _userRepository.GetUserByEmail(email);
            if (user != null && user.Password == password)
            {
                return new UserDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    LastName = user.LastName,
                    Email = user.Email,
                };
            }
            return null;
        }

        public void CreateUser(CreateUserDto userInput)
        {
            _userRepository.CreateUser(userInput);
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

