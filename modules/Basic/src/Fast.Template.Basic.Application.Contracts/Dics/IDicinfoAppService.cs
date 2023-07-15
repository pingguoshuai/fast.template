using System;
using Fast.Template.Basic.Dics.Dtos;
using Volo.Abp.Application.Services;

namespace Fast.Template.Basic.Dics;


/// <summary>
/// 
/// </summary>
public interface IDicinfoAppService :
    ICrudAppService< 
        DicinfoDto, 
        Guid, 
        DicinfoGetListInput,
        CreateUpdateDicinfoDto,
        CreateUpdateDicinfoDto>
{

}