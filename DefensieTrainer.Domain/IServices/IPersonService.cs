using DefensieTrainer.Domain.DTO;


namespace DefensieTrainer.Domain.IServices
{
    public interface IPersonService
    {
        PersonDto AuthenticateUser(string email, string password);
        PersonDto GetUserById(int userId);
        IEnumerable<PersonDto> GetAllUsers();
        void CreateUser(CreatePersonDto userInput);
        void UpdateUser(int userId, CreatePersonDto userInput);
        void DeleteUser(int userId);
    }
}