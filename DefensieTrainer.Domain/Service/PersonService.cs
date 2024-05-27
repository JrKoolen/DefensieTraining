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
                return new PersonDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    LastName = user.LastName,
                    Email = user.Email,
                };
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

        public void UpdateUser(int userId, CreatePersonDto userInput)
        {
            throw new NotImplementedException();
        }
    }
}

