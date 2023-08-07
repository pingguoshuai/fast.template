using System;
using Volo.Abp.Application.Dtos;

namespace Fast.Template.Basic.Dics.Dtos;

/// <summary>
/// 字典类型
/// </summary>
[Serializable]
public class DicTypeDto : FullAuditedEntityDto<Guid>
{
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 代码
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    public bool Status { get; set; }
}