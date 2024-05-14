using DefensieTrainer.Domain.DTO.OUT;
using DefensieTrainer.Domain.DTO.IN;


namespace DefensieTrainer.Domain.IServices
{
    public interface IUserServices
    {
        UserDto GetUserById(int userId);
        IEnumerable<UserDto> GetAllUsers();
        void CreateUser(PostUserDto userInput);
        void UpdateUser(int userId, PostUserDto userInput);
        void DeleteUser(int userId);
    }
}