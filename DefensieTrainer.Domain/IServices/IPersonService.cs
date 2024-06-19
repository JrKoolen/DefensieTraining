using DefensieTrainer.Domain.DTO;

namespace DefensieTrainer.Domain.IServices
{
    public interface IPersonService
    {
        ReadPersonDto AuthenticateUser(string email, string password);
        ReadPersonDto GetUserById(int userId);
        IEnumerable<ReadPersonDto> GetAllUsers();
        void CreateUser(CreatePersonDto userInput);
        void UpdateUserRole(string email, string role);
        void DeleteUser(int userId);
    }
}