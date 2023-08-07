using System;
using Fast.Template.IdsAdmin.ApiResources.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Fast.Template.IdsAdmin.ApiResources
{
    public interface IApiResourceAppService : ICrudAppService<
        ApiResourceDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateApiResourceDto,
        CreateApiResourceDto>
    {
    }
}
