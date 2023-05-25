using System.ComponentModel.DataAnnotations;

namespace Fast.Template.IdsAdmin.Clients.Dtos
{
    public class ClientClaimDto
    {
        [Required]
        public string Type { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
