using System;
using Fast.Template.IdsAdmin.Clients.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Fast.Template.IdsAdmin.Clients
{
    public interface IClientAppService : ICrudAppService<
        ClientDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateClientDto,
        CreateClientDto>
    {
    }
}
