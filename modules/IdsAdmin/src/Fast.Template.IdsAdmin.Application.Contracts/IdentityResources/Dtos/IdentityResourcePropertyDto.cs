
using System.ComponentModel.DataAnnotations;

namespace Fast.Template.IdsAdmin.IdentityResources.Dtos
{
    public class IdentityResourcePropertyDto
    {
        [Required]
        public string Key { get; set; }
        [Required]
        public string Value { get; set; }
    }
}
