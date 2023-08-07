using Fast.Template.Common.Utils;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Fast.Template.Common.Applicaiton.Base
{
    /// <summary>
    /// 应用服务基类：提供基础的curd
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TEntityDto"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TGetListInput"></typeparam>
    /// <typeparam name="TCreateInput"></typeparam>
    /// <typeparam name="TUpdateInput"></typeparam>
    public class BaseCrudAppService<TEntity,
        TEntityDto,
        TKey,
        TGetListInput,
        TCreateInput,
        TUpdateInput
    > : CrudAppService<TEntity, TEntityDto, TKey, TGetListInput, TCreateInput, TUpdateInput>
        where TEntity : class, IEntity<TKey>
        where TEntityDto : IEntityDto<TKey>
    {
        public BaseCrudAppService(IRepository<TEntity, TKey> repository) : base(repository)
        {
        }

        #region 创建

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input">创建数据DTO</param>
        /// <returns></returns>
        public override async Task<TEntityDto> CreateAsync(TCreateInput input)
        {
            await CheckCreatePolicyAsync();

            var entity = await MapToEntityAsync(input);

            TryToSetTenantId(entity);

            CreateBefore(entity);
            await CreateBeforeAsync(entity);

            await Repository.InsertAsync(entity, autoSave: true);

            CreateAfter(entity);
            await CreateAfterAsync(entity);

            return await MapToGetOutputDtoAsync(entity);
        }

        protected virtual void CreateBefore(TEntity entity)
        {

        }

        /// <summary>
        /// 创建前操作
        /// </summary>
        protected virtual Task CreateBeforeAsync(TEntity entity)
        {
            return Task.CompletedTask;
        }

        protected virtual void CreateAfter(TEntity entity)
        {

        }

        /// <summary>
        /// 创建后操作
        /// </summary>
        protected virtual Task CreateAfterAsync(TEntity entity)
        {
            return Task.CompletedTask;
        }

        #endregion

        #region 修改

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id">数据Id</param>
        /// <param name="input">更新数据DTO</param>
        /// <returns></returns>
        public override async Task<TEntityDto> UpdateAsync(TKey id, TUpdateInput input)
        {
            await CheckUpdatePolicyAsync();

            var entity = await GetEntityByIdAsync(id);
            await MapToEntityAsync(input, entity);
            UpdateBefore(entity);
            await UpdateBeforeAsync(entity);
            await Repository.UpdateAsync(entity, autoSave: true);
            UpdateAfter(entity);
            await UpdateAfterAsync(entity);
            return await MapToGetOutputDtoAsync(entity);
        }

        protected virtual void UpdateBefore(TEntity entity)
        {

        }

        /// <summary>
        /// 修改前操作
        /// </summary>
        /// <param name="entity">实体</param>
        protected virtual Task UpdateBeforeAsync(TEntity entity)
        {
            return Task.CompletedTask;
        }

        protected virtual void UpdateAfter(TEntity entity)
        {

        }

        /// <summary>
        /// 修改后操作
        /// </summary>
        /// <param name="entity">实体</param>
        protected virtual Task UpdateAfterAsync(TEntity entity)
        {
            return Task.CompletedTask;
        }

        #endregion

        #region 删除

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">数据Id</param>
        /// <returns></returns>
        public override async Task DeleteAsync(TKey id)
        {
            await CheckDeletePolicyAsync();
            await DeleteBeforeAsync(id);
            await DeleteByIdAsync(id);
            await DeleteAfterAsync(id);
        }

        /// <summary>
        /// 删除前操作
        /// </summary>
        protected virtual Task DeleteBeforeAsync(TKey id)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// 删除后操作
        /// </summary>
        protected virtual Task DeleteAfterAsync(TKey id)
        {
            return Task.CompletedTask;
        }

        #endregion

        #region 查询单个实例

        /// <summary>
        /// 查询指定数据实体
        /// </summary>
        /// <param name="id">数据Id</param>
        /// <returns></returns>
        public override async Task<TEntityDto> GetAsync(TKey id)
        {
            return await base.GetAsync(id);
        }
        #endregion

        #region 分页查询
        /// <summary>
        /// 分页查询数据列表
        /// </summary>
        /// <param name="input">查询条件</param>
        /// <returns></returns>
        public override async Task<PagedResultDto<TEntityDto>> GetListAsync(
            TGetListInput input)
        {
            return await base.GetListAsync(input);
        }

        #endregion

        #region 获取项列表

        /// <summary>
        /// 获取项列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual async Task<List<SelectItem>> GetItemsAsync(TGetListInput input)
        {
            var query = await CreateFilteredQueryAsync(input);
            query = ApplySorting(query, input);
            var entities = await AsyncExecuter.ToListAsync(query);
            return entities.Select(ToItem).ToList();
        }

        protected virtual SelectItem ToItem(TEntity entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
