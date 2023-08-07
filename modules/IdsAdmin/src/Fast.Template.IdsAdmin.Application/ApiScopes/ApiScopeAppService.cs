using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Fast.Template.Common.Applicaiton.Base;
using Fast.Template.Common.Utils;
using Fast.Template.IdsAdmin.ApiScopes.Dtos;
using Fast.Template.IdsAdmin.Common;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.IdentityServer.ApiScopes;

namespace Fast.Template.IdsAdmin.ApiScopes
{
    public class ApiScopeAppService : BaseCrudAppService<
        ApiScope,
        ApiScopeDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateApiScopeDto,
        CreateApiScopeDto>,IApiScopeAppService
    {
        private readonly IApiScopeRepository _repository;

        public ApiScopeAppService(
            IApiScopeRepository repository) : base((IRepository<ApiScope,Guid>)repository)
        {
            _repository = repository;
        }

        protected override async Task<IQueryable<ApiScope>> CreateFilteredQueryAsync(PagedAndSortedResultRequestDto input)
        {
            var query = await ((IRepository<ApiScope, Guid>)_repository).WithDetailsAsync();
            return query;
        }

        protected override SelectItem ToItem(ApiScope entity)
        {
            return new SelectItem(entity.Name,entity.Name);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public override async Task<ApiScopeDto> UpdateAsync(Guid id, CreateApiScopeDto input)
        {
            await CheckUpdatePolicyAsync();

            var entity = await GetEntityByIdAsync(id);

            await MapToEntityAsync(input, entity);

            await Repository.UpdateAsync(entity, autoSave: true);

            return await MapToGetOutputDtoAsync(entity);
        }

        #region 属性

        /// <summary>
        /// 属性列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<List<ApiScopePropertyDto>> GetPropertiesAsync(Guid id)
        {
            var entity = await _repository.GetAsync(id);
            
            return entity.Properties.Select(a => ObjectMapper.Map<ApiScopeProperty, ApiScopePropertyDto>(a)).ToList();
        }

        /// <summary>
        /// 添加属性
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task PostAddProperyAsync(Guid id, ApiScopePropertyDto input)
        {
            var entity = await _repository.GetAsync(id);
            entity.RemoveProperty(input.Key);
            entity.AddProperty(input.Key, input.Value);
            await _repository.UpdateAsync(entity, autoSave: true);
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
    }
}
