using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using the_webapi.models.ViewModels;
using the_webapi.Services;

namespace the_webapi.Endpoints
{
    public class PersonEndpoints
    {
        public static void Map(WebApplication app)
        {
            var group = app.MapGroup("/person").WithTags("Person");
            
            group.MapGet("/person", GetPerson).WithName("GetRandomPerson");
            group.MapGet("/persons", GetPersons).WithName("GetTenRandomPersons");

            group.MapPost("/person", (PersonVM person, IPersonService personService) =>
            {
                var validationResults = new List<ValidationResult>();
                var validationContext = new ValidationContext(person);

                if (!Validator.TryValidateObject(person, validationContext, validationResults, true))
                {
                    var errors = validationResults.Select(vr => vr.ErrorMessage);
                    return Results.BadRequest("Invalid input" + string.Join(", ", errors));
                }
                return Results.Ok(person);
            })
            .WithName("CreatePerson");
        }

        public static async Task<IResult> GetPerson(IPersonService personService)
        {
            var person = await personService.GetPerson();
            return Results.Ok(person);
        }

        public static async Task<IResult> GetPersons(IPersonService personService)
        {
            var persons = await personService.GetTenPersons();
            return Results.Ok(persons);
        }
    }
}