using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Fast.Template.Common.Applicaiton.Base;
using Fast.Template.IdsAdmin.ApiResources.Dtos;
using IdentityServer4.Models;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.IdentityServer.ApiResources;
using static IdentityServer4.IdentityServerConstants;
using ApiResource = Volo.Abp.IdentityServer.ApiResources.ApiResource;

namespace Fast.Template.IdsAdmin.ApiResources
{
    public class ApiResourceAppService : BaseCrudAppService<
        ApiResource,
        ApiResourceDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateApiResourceDto,
        CreateApiResourceDto>, IApiResourceAppService
    {
        private readonly IApiResourceRepository _repository;

        public ApiResourceAppService(IApiResourceRepository repository) : base((IRepository<ApiResource, Guid>)repository)
        {
            _repository = repository;
        }

        protected override async Task<IQueryable<ApiResource>> CreateFilteredQueryAsync(PagedAndSortedResultRequestDto input)
        {
            var query = await((IRepository<ApiResource, Guid>)_repository).WithDetailsAsync();
            return query;
        }

        #region 属性

        /// <summary>
        /// 属性列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<List<ApiResourcePropertyDto>> GetPropertiesAsync(Guid id)
        {
            var entity = await _repository.GetAsync(id);

            return entity.Properties.Select(a => ObjectMapper.Map<ApiResourceProperty, ApiResourcePropertyDto>(a)).ToList();
        }

        /// <summary>
        /// 添加属性
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task PostAddProperyAsync(Guid id, ApiResourcePropertyDto input)
        {
            var entity = await _repository.GetAsync(id);
            entity.RemoveProperty(input.Key);
            entity.AddProperty(input.Key, input.Value);
            await _repository.UpdateAsync(entity);
        }

        /// <summary>
        /// 移除属性
        /// </summary>
        /// <param name="id"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task DeleteRemoveProperyAsync(Guid id, [Required] string key)
        {
            var entity = await _repository.GetAsync(id);
            entity.RemoveProperty(key);
            await _repository.UpdateAsync(entity);
        }

        #endregion

        #region secret

        /// <summary>
        /// 密钥列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<List<ApiResourceSecretDto>> GetSecretsAsync(Guid id)
        {
            var entity = await _repository.GetAsync(id);

            return entity.Secrets.Select(a => ObjectMapper.Map<ApiResourceSecret, ApiResourceSecretDto>(a)).ToList();
        }
        /// <summary>
        /// 添加密钥
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task PostAddSecretAsync(Guid id, ApiResourceSecretDto input)
        {
            HashApiSharedSecret(input);

            var entity = await _repository.GetAsync(id);
            entity.RemoveSecret(input.Value, input.Type);
            entity.AddSecret(input.Value, input.Expiration, input.Type, input.Description);
            await _repository.UpdateAsync(entity);
        }

        /// <summary>
        /// 移除密钥
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task DeleteRemoveSecretAsync(Guid id, [Required] string value, [Required] string type)
        {
            var entity = await _repository.GetAsync(id);
            entity.RemoveSecret(value, type);
            await _repository.UpdateAsync(entity);
        }

        private void HashApiSharedSecret(ApiResourceSecretDto secret)
        {
            if (secret.Type != SecretTypes.SharedSecret) return;

            if (secret.HashType == Enums.HashType.Sha256)
                secret.Value = secret.Value.Sha256();

            if (secret.HashType == Enums.HashType.Sha512)
                secret.Value = secret.Value.Sha512();
        }

        #endregion
    }
}
