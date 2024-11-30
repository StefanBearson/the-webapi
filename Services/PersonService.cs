using the_webapi.mapping;
using the_webapi.models.DTOs;
using the_webapi.models.Models;
using the_webapi.Repository;

namespace the_webapi.Services
{
    public class PersonService: IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<PersonDTO> GetPerson()
        {
            Person person = await _personRepository.GetPerson();
            PersonDTO personDTO = person.MapToDTO();
            return personDTO;
        }

        public async Task<List<PersonDTO>> GetTenPersons()
        {
            List<Person> person = await _personRepository.GetTenPersons();

            List<PersonDTO> personDTOs = new List<PersonDTO>();
            person.ForEach(p => personDTOs.Add(p.MapToDTO()));
            
            return personDTOs;
        }
    }
}