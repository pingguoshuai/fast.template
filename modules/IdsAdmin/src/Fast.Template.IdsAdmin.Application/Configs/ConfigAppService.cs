using Fast.Template.IdsAdmin.Consts;
using Fast.Template.IdsAdmin.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fast.Template.Common.Utils;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.IdentityServer.ApiScopes;
using Volo.Abp.IdentityServer.IdentityResources;

namespace Fast.Template.IdsAdmin.Configs
{
    /// <summary>
    /// 常量配置
    /// </summary>
    public class ConfigAppService : ApplicationService
    {
        private readonly IIdentityResourceRepository _identityResourceRepo;
        private readonly IApiScopeRepository _apiScopeRepo;
        public ConfigAppService(
            IIdentityResourceRepository identityResourceRepo,
            IApiScopeRepository apiScopeRepo)
        {
            _identityResourceRepo = identityResourceRepo;
            _apiScopeRepo = apiScopeRepo;
        }

        /// <summary>
        /// 常规声明
        /// </summary>
        /// <returns></returns>
        public List<string> GetStandardClaims()
        {
            return ClientConst.StandardClaims;
        }

        /// <summary>
        /// 签名算法
        /// </summary>
        /// <returns></returns>
        public List<string> GetSigningAlgorithms()
        {
            return ClientConst.SigningAlgorithms;
        }

        /// <summary>
        /// 哈希类型
        /// </summary>
        /// <returns></returns>
        public List<SelectItem<int>> GetHashTypes()
        {
            return Enum.GetValues(typeof(HashType))
                .Cast<HashType>()
                .Select(x => new SelectItem<int>(x.ToString(), x.GetHashCode())).ToList();
        }

        /// <summary>
        /// 访问令牌类型
        /// </summary>
        /// <returns></returns>
        public List<SelectItem<int>> GetAccessTokenTypes()
        {
            return Enum.GetValues(typeof(IdentityServer4.Models.AccessTokenType))
                .Cast<IdentityServer4.Models.AccessTokenType>()
                .Select(x => new SelectItem<int>(x.ToString(), x.GetHashCode())).ToList();
        }

        /// <summary>
        /// 刷新令牌使用情况
        /// </summary>
        /// <returns></returns>
        public List<SelectItem<int>> GetTokenUsages()
        {
            return Enum.GetValues(typeof(IdentityServer4.Models.TokenUsage))
                .Cast<IdentityServer4.Models.TokenUsage>()
                .Select(x => new SelectItem<int>(x.ToString(), x.GetHashCode())).ToList();
        }

        /// <summary>
        /// 刷新令牌过期
        /// </summary>
        /// <returns></returns>
        public List<SelectItem<int>> GetTokenExpirations()
        {
            return Enum.GetValues(typeof(IdentityServer4.Models.TokenExpiration))
                .Cast<IdentityServer4.Models.TokenExpiration>()
                .Select(x => new SelectItem<int>(x.ToString(), x.GetHashCode())).ToList();
        }

        /// <summary>
        /// 加密类型
        /// </summary>
        /// <returns></returns>
        public List<string> GetSecretTypes()
        {
            return ClientConst.SecretTypes;
        }

        /// <summary>
        /// 授权类型
        /// </summary>
        /// <returns></returns>
        public List<string> GetGrantTypes()
        {
            return ClientConst.GrantTypes;
        }

        //public string GetTest(DateTime dt)
        //{
        //    return dt.ToString("yyyy-MM-dd HH:mm:ss");
        //}

        /// <summary>
        /// 可使用的scopes
        /// </summary>
        /// <returns></returns>
        public async Task<List<string>> GetScopesAsync()
        {
            var identityResources = (await ((IRepository<IdentityResource, Guid>)_identityResourceRepo).GetQueryableAsync()).Select(i => i.Name).ToList();
            var apiScopes = (await ((IRepository<ApiScope, Guid>)_apiScopeRepo).GetQueryableAsync()).Select(i => i.Name).ToList();

            return identityResources.Concat(apiScopes).ToList();
        }
    }
}
