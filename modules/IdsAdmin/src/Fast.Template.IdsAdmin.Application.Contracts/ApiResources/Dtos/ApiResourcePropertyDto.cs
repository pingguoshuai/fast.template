
using System.ComponentModel.DataAnnotations;

namespace Fast.Template.IdsAdmin.ApiResources.Dtos
{
    public class ApiResourcePropertyDto
    {
        [Required]
        public string Key { get; set; }
        [Required]
        public string Value { get; set; }
    }
}
