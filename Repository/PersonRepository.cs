using Bogus;

namespace the_webapi.Repository
{
    public class PersonRepository : IPersonRepository
    {
        public Task<models.Models.Person> GetPerson()
        {
            return Task.FromResult(new Faker<models.Models.Person>()
                .RuleFor(p => p.firstName, f => f.Name.FirstName())
                .RuleFor(p => p.lastName, f => f.Name.LastName())
                .RuleFor(p => p.age, f => f.Random.Int(18, 65))
                .Generate());
        }

        public Task<List<models.Models.Person>> GetTenPersons()
        {
            var persons = new Faker<models.Models.Person>()
                .RuleFor(p => p.firstName, f => f.Name.FirstName())
                .RuleFor(p => p.lastName, f => f.Name.LastName())
                .RuleFor(p => p.age, f => f.Random.Int(18, 65))
                .Generate(10);

            return Task.FromResult(persons);
        }
    }
}