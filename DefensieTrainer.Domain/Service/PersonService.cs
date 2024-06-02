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


        public PersonDto AuthenticateUser(string email, string password)
        {
            PersonDto user = _personRepository.GetUserByEmail(email);
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
            throw new NotImplementedException();
        }

        public IEnumerable<PersonDto> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public PersonDto GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public void UpdateUserRole(string email, string role)
        {
            _personRepository.UpdateUserRole(email, role);
        }
    }
}

