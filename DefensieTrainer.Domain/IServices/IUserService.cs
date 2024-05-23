using DefensieTrainer.Domain.DTO;


namespace DefensieTrainer.Domain.IServices
{
    public interface IUserServices
    {
        UserDto GetUserById(int userId);
        IEnumerable<UserDto> GetAllUsers();
        void CreateUser(CreateUserDto userInput);
        void UpdateUser(int userId, CreateUserDto userInput);
        void DeleteUser(int userId);
    }
}