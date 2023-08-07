using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace Fast.Template.Start.Identity
{
    [RemoteService(IsEnabled = false)]
    public class RoleAppService : IdentityRoleAppService, IRoleAppService
    {
        public RoleAppService(IdentityRoleManager roleManager, IIdentityRoleRepository roleRepository) : base(roleManager, roleRepository)
        {
        }

        /// <summary>
        /// 全部
        /// </summary>
        /// <returns></returns>
        public override Task<ListResultDto<IdentityRoleDto>> GetAllListAsync()
        {
            return base.GetAllListAsync();
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override Task<PagedResultDto<IdentityRoleDto>> GetListAsync(GetIdentityRolesInput input)
        {
            return base.GetListAsync(input);
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override Task<IdentityRoleDto> CreateAsync(IdentityRoleCreateDto input)
        {
            return base.CreateAsync(input);
        }

        /// <summary>
        /// 查询单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Task<IdentityRoleDto> GetAsync(Guid id)
        {
            return base.GetAsync(id);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public override Task<IdentityRoleDto> UpdateAsync(Guid id, IdentityRoleUpdateDto input)
        {
            return base.UpdateAsync(id, input);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Task DeleteAsync(Guid id)
        {
            return base.DeleteAsync(id);
        }
    }
}
