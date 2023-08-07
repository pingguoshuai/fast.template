using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace Fast.Template.IdsAdmin.ApiResources.Dtos
{
    public class ApiResourceDto : FullAuditedEntityDto<Guid>
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 显示名称
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 启用
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// 在发现文档中显示
        /// </summary>
        public bool ShowInDiscoveryDocument { get; set; }

        /// <summary>
        /// 允许的签名算法列表。如果为空，将使用服务器默认的签名算法。
        /// </summary>
        public List<string> AllowedAccessTokenSigningAlgorithms { get; set; }

        public List<string> UserClaims { get; set; }
        public List<string> Scopes { get; set; }

        public List<ApiResourcePropertyDto> Properties { get; set; }

        public List<ApiResourceSecretDto> Secrets { get; set; }
    }
}
