using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fast.Template.Start.Identity;
using Fast.Template.Start.Identity.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Fast.Template.Start.Controllers
{
    [Route("api/identity/users")]
    public class UserController : AbpControllerBase
    {
        private readonly IUserAppService _userService;

        public UserController(IUserAppService userService)
        {
            _userService = userService;
        }

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
