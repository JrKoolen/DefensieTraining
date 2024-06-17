using DefensieTrainer.Domain.DTO;

namespace DefensieTrainer.Domain.IServices
{
    public interface IPersonService
    {
        PersonDto AuthenticateUser(string email, string password);
        PersonDto GetUserById(int userId);
        IEnumerable<PersonDto> GetAllUsers();
        void CreateUser(CreatePersonDto userInput);
        void UpdateUserRole(string email, string role);
        void DeleteUser(int userId);
    }
}