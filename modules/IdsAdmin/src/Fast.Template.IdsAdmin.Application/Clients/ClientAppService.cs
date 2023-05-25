using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Fast.Template.Common.Applicaiton.Base;
using Fast.Template.IdsAdmin.Clients.Dtos;
using IdentityServer4.Models;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.IdentityServer.Clients;
using static IdentityServer4.IdentityServerConstants;
using Client = Volo.Abp.IdentityServer.Clients.Client;
using ClientClaim = Volo.Abp.IdentityServer.Clients.ClientClaim;

namespace Fast.Template.IdsAdmin.Clients
{
    /// <summary>
    /// 客户端
    /// </summary>
    public class ClientAppService : BaseCrudAppService<
        Client,
        ClientDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateClientDto,
        CreateClientDto>, IClientAppService
    {
        private readonly IClientRepository _repository;

        public ClientAppService(IClientRepository repository) : base((IRepository<Client, Guid>)repository)
        {
            _repository = repository;
        }

        protected override async Task<IQueryable<Client>> CreateFilteredQueryAsync(PagedAndSortedResultRequestDto input)
        {
            var query = await ((IRepository<Client, Guid>)_repository).WithDetailsAsync();
            return query;
        }

        public override async Task<ClientDto> GetAsync(Guid id)
        {
            await CheckGetPolicyAsync();

            var entity = await GetEntityByIdAsync(id);

            return await MapToGetOutputDtoAsync(entity);
        }

        #region 属性

        /// <summary>
        /// 属性列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<List<ClientPropertyDto>> GetPropertiesAsync(Guid id)
        {
            var entity = await _repository.GetAsync(id);

            return entity.Properties.Select(a => ObjectMapper.Map<ClientProperty, ClientPropertyDto>(a)).ToList();
        }

        /// <summary>
        /// 添加属性
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task PostAddProperyAsync(Guid id, ClientPropertyDto input)
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
        public virtual async Task<List<ClientSecretDto>> GetSecretsAsync(Guid id)
        {
            var entity = await _repository.GetAsync(id);

            return entity.ClientSecrets.Select(a => ObjectMapper.Map<ClientSecret, ClientSecretDto>(a)).ToList();
        }
        /// <summary>
        /// 添加密钥
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task PostAddSecretAsync(Guid id, ClientSecretDto input)
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

        private void HashApiSharedSecret(ClientSecretDto secret)
        {
            if (secret.Type != SecretTypes.SharedSecret) return;

            if (secret.HashType == Enums.HashType.Sha256)
                secret.Value = secret.Value.Sha256();

            if (secret.HashType == Enums.HashType.Sha512)
                secret.Value = secret.Value.Sha512();
        }

        #endregion

        #region claims


        /// <summary>
        /// 声明列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<List<ClientClaimDto>> GetClaimsAsync(Guid id)
        {
            var entity = await _repository.GetAsync(id);

            return entity.Claims.Select(a => ObjectMapper.Map<ClientClaim, ClientClaimDto>(a)).ToList();
        }

        /// <summary>
        /// 添加声明
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task PostAddClaimAsync(Guid id, ClientClaimDto input)
        {
            var entity = await _repository.GetAsync(id);
            entity.RemoveClaim(input.Type);
            entity.AddClaim(input.Type, input.Value);
            await _repository.UpdateAsync(entity);
        }

        /// <summary>
        /// 移除声明
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task DeleteRemoveClaimAsync(Guid id, [Required] string type)
        {
            var entity = await _repository.GetAsync(id);
            entity.RemoveClaim(type);
            await _repository.UpdateAsync(entity);
        }

        #endregion
    }
}
