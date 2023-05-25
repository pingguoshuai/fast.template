using System;
using Fast.Template.IdsAdmin.ApiScopes.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Fast.Template.IdsAdmin.ApiScopes
{
    public interface IApiScopeAppService : ICrudAppService<
        ApiScopeDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateApiScopeDto,
        CreateApiScopeDto>
    {
    }
}
