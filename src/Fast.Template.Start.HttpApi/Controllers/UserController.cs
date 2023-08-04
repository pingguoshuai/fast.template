using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fast.Template.Start.Identity;
using Fast.Template.Start.Identity.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace Fast.Template.Start.Controllers
{
    public class UserController : IdentityUserController
    {
        private readonly IUserAppService _userService;


        public UserController(IUserAppService userService, IIdentityUserAppService identityUserService) :base(identityUserService)
        {
            _userService = userService;
        }


        #region basic

        /// <summary>
        /// 获取指定Id用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Task<IdentityUserDto> GetAsync(Guid id)
        {
            return base.GetAsync(id);
        }

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override Task<PagedResultDto<IdentityUserDto>> GetListAsync(GetIdentityUsersInput input)
        {
            return base.GetListAsync(input);
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override Task<IdentityUserDto> CreateAsync(IdentityUserCreateDto input)
        {
            return base.CreateAsync(input);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public override Task<IdentityUserDto> UpdateAsync(Guid id, IdentityUserUpdateDto input)
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

        /// <summary>
        /// 获取指定用户角色列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Task<ListResultDto<IdentityRoleDto>> GetRolesAsync(Guid id)
        {
            return base.GetRolesAsync(id);
        }

        ///// <summary>
        ///// 获取可使用的角色列表
        ///// </summary>
        ///// <returns></returns>
        //public override Task<ListResultDto<IdentityRoleDto>> GetAssignableRolesAsync()
        //{
        //    return base.GetAssignableRolesAsync();
        //}

        /// <summary>
        /// 更新用户角色
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public override Task UpdateRolesAsync(Guid id, IdentityUserUpdateRolesDto input)
        {
            return base.UpdateRolesAsync(id, input);
        }

        /// <summary>
        /// 通过用户名获取用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public override Task<IdentityUserDto> FindByUsernameAsync(string userName)
        {
            return base.FindByUsernameAsync(userName);
        }

        /// <summary>
        /// 通过邮箱获取用户信息
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public override Task<IdentityUserDto> FindByEmailAsync(string email)
        {
            return base.FindByEmailAsync(email);
        }

        #endregion


        #region claims
        /// <summary>
        /// claim列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/claims")]
        public virtual async Task<List<ClaimDto>> GetClaimsAsync(Guid id)
        {
            return await _userService.GetClaimsAsync(id);
        }

        /// <summary>
        /// 添加claim
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost("{id}/add-claim")]
        public async Task PostAddClaimAsync(Guid id, ClaimDto input)
        {
            await _userService.PostAddClaimAsync(id, input);
        }

        /// <summary>
        /// 移除claim
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpDelete("{id}/remove-claim")]
        public async Task DeleteRemoveClaimAsync(Guid id, ClaimDto input)
        {
            await _userService.DeleteRemoveClaimAsync(id, input);
        }
        #endregion
    }
}
