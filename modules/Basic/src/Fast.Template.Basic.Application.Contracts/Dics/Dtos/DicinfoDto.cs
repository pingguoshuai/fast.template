using System;
using Volo.Abp.Application.Dtos;

namespace Fast.Template.Basic.Dics.Dtos;

/// <summary>
/// 
/// </summary>
[Serializable]
public class DicinfoDto : FullAuditedEntityDto<Guid>
{
    /// <summary>
    /// 类型Id
    /// </summary>
    public Guid DictypeId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string DicTypeName { get; set; }

    /// <summary>
    /// 字典名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 字典值
    /// </summary>
    public string Value { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int Sort { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    public bool Status { get; set; }
}