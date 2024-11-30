using System.ComponentModel.DataAnnotations;

namespace the_webapi.models.ViewModels
{
    public class PersonVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, 100)]
        public int Age { get; set; }
    }
}