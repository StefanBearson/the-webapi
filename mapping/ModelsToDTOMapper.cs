using the_webapi.models.DTOs;
using the_webapi.models.Models;

namespace the_webapi.mapping
{
    public static class ModelsToDTOMapper
    {
        public static PersonDTO MapToDTO(this Person person)
        {
            return new PersonDTO
            {
                Name = $"{person.firstName} {person.lastName}",
                Age = person.age
            };
        }
    }
}