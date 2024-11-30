using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace the_webapi.Services
{
    public interface IPersonService
    {
        Task<models.DTOs.PersonDTO> GetPerson();
        Task<List<models.DTOs.PersonDTO>> GetTenPersons();
    }
}