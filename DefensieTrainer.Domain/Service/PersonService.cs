using DefensieTrainer.Domain.IServices;
using DefensieTrainer.Domain.IRepositories;
using DefensieTrainer.Domain.DTO;

namespace DefensieTrainer.Domain.Service
{
    public class PersonService : IPersonService
    {
        public readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }


        public ReadPersonDto AuthenticateUser(string email, string password)
        {
            ReadPersonDto user = _personRepository.GetUserByEmail(email);
            if (user != null && user.Password == password)
            {
                return user;
            }
            return null;
        }

        public void CreateUser(CreatePersonDto userInput)
        {
            _personRepository.CreateUser(userInput);
        }

        public void DeleteUser(int userId)
        {
            _personRepository.DeleteUser(userId);
        }

        public IEnumerable<ReadPersonDto> GetAllUsers()
        {
            return _personRepository.GetAllUsers();
        }

        public ReadPersonDto GetUserById(int userId)
        {
            return _personRepository.GetById(userId);
        }

        public void UpdateUserRole(string email, string role)
        {
            _personRepository.UpdateUserRole(email, role);
        }
    }
}

