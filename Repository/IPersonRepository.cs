namespace the_webapi.Repository
{
    public interface IPersonRepository
    {
        Task<models.Models.Person> GetPerson();
        Task<List<models.Models.Person>> GetTenPersons();
    }
}