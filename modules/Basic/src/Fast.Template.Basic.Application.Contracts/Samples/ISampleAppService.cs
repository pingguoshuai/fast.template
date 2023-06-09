﻿using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Fast.Template.Basic.Samples;

public interface ISampleAppService : IApplicationService
{
    Task<SampleDto> GetAsync();

    Task<SampleDto> GetAuthorizedAsync();
}
