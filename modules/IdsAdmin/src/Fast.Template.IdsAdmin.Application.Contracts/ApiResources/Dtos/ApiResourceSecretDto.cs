using Fast.Template.IdsAdmin.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Fast.Template.IdsAdmin.ApiResources.Dtos
{
    public class ApiResourceSecretDto
    {
        //public Guid ApiResourceId { get; set; }

        [Required]
        public string Type { get; set; }

        public HashType? HashType { get; set; }

        [Required]
        public string Value { get; set; }

        public string Description { get; set; }

        public DateTime? Expiration { get; set; }
    }
}
