using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Fast.Template.Start.Identity.Dtos;
using Volo.Abp.Identity;

namespace Fast.Template.Start.Identity
{
    public interface IUserAppService : IIdentityUserAppService
    {
        Task<List<ClaimDto>> GetClaimsAsync(Guid id);
        Task PostAddClaimAsync(Guid id, ClaimDto input);
        Task DeleteRemoveClaimAsync(Guid id, ClaimDto input);
    }
}
