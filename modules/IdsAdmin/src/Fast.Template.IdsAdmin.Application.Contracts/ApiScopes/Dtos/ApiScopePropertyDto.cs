using System;
using System.ComponentModel.DataAnnotations;

namespace Fast.Template.IdsAdmin.ApiScopes.Dtos
{
    public class ApiScopePropertyDto
    {
        [Required]
        public string Key { get; set; }

        [Required]
        public string Value { get; set; }
    }
}
