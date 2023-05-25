using Fast.Template.IdsAdmin.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Fast.Template.IdsAdmin.Clients.Dtos
{
    public class ClientSecretDto
    {
        [Required]
        public virtual string Type { get; set; }

        public HashType? HashType { get; set; }

        [Required]
        public virtual string Value { get; set; }

        public virtual string Description { get; set; }

        public virtual DateTime? Expiration { get; set; }
    }
}
