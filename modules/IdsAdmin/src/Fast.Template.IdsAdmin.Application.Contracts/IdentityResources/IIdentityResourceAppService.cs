using System;
using Fast.Template.IdsAdmin.IdentityResources.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Fast.Template.IdsAdmin.IdentityResources
{
    public interface IIdentityResourceAppService : ICrudAppService<
        IdentityResourceDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateIdentityResourceDto,
        CreateIdentityResourceDto>
    {
    }
}
