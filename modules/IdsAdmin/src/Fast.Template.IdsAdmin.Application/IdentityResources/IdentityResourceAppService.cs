using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Fast.Template.Common.Applicaiton.Base;
using Fast.Template.IdsAdmin.IdentityResources.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.IdentityServer.IdentityResources;

namespace Fast.Template.IdsAdmin.IdentityResources
{
    /// <summary>
    /// 身份资源
    /// </summary>
    public class IdentityResourceAppService : BaseCrudAppService<
        IdentityResource,
        IdentityResourceDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateIdentityResourceDto,
        CreateIdentityResourceDto>, IIdentityResourceAppService
    {
        private readonly IIdentityResourceRepository _repository;

        public IdentityResourceAppService(IIdentityResourceRepository repository) : base((IRepository<IdentityResource, Guid>)repository)
        {
            _repository = repository;
        }

        protected override async Task<IQueryable<IdentityResource>> CreateFilteredQueryAsync(PagedAndSortedResultRequestDto input)
        {
            var query = await ((IRepository<IdentityResource, Guid>)_repository).WithDetailsAsync();
            return query;
        }

        #region 属性

        /// <summary>
        /// 属性列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<List<IdentityResourcePropertyDto>> GetPropertiesAsync(Guid id)
        {
            var entity = await _repository.GetAsync(id);

            return entity.Properties.Select(a => ObjectMapper.Map<IdentityResourceProperty, IdentityResourcePropertyDto>(a)).ToList();
        }

        /// <summary>
        /// 添加属性
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task PostAddProperyAsync(Guid id, IdentityResourcePropertyDto input)
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
    }
}
