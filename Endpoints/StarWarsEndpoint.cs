using System.Text.Json.Serialization;

namespace the_webapi.Endpoints
{
    public class StarWarsEndpoint 
    {
  
        public void Map(WebApplication app)
        {
            var group = app.MapGroup("/StarWars").WithTags("Star Wars");
            
            group.MapGet("/character", GetStarWarsCharacter).WithName("Get Star Wars Character");
        }
        public async Task<IResult> GetStarWarsCharacter(IHttpClientFactory httpClientFactory, int Id)
        {
            HttpClient httpClient = httpClientFactory.CreateClient("starwars");
            
            var response = await httpClient.GetAsync($"people/{Id}/");

            if (!response.IsSuccessStatusCode)
            {
                return Results.NotFound();
            }

            var character = response.Content.ReadFromJsonAsync<SWResult>();

            return Results.Ok(character.Result.Result.Properties);
        }
    }

    internal class SWResult
    {
        [JsonPropertyName("result")]
        public SW Result { get; set; }
    }
    internal class SW
    {
        [JsonPropertyName("properties")]
        public character Properties { get; set; }
    }
    internal class character
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("height")]
        public string Height { get; set; }
        [JsonPropertyName("mass")]
        public string Mass { get; set; }
        [JsonPropertyName("hair_color")]
        public string HairColor { get; set; }
        [JsonPropertyName("skin_color")]
        public string SkinColor { get; set; }
        [JsonPropertyName("eye_color")]
        public string EyeColor { get; set; }
        [JsonPropertyName("birth_year")]
        public string BirthYear { get; set; }
    }
}