using System;
using Fast.Template.Basic.Dics.Dtos;
using Volo.Abp.Application.Services;

namespace Fast.Template.Basic.Dics;


/// <summary>
/// 字典类型
/// </summary>
public interface IDicTypeAppService :
    ICrudAppService< 
        DicTypeDto, 
        Guid, 
        DicTypeGetListInput,
        CreateUpdateDicTypeDto,
        CreateUpdateDicTypeDto>
{

}