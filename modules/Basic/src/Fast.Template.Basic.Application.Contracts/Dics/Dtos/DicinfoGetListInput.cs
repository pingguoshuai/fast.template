using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace Fast.Template.Basic.Dics.Dtos;

[Serializable]
public class DicinfoGetListInput : PagedAndSortedResultRequestDto
{
    /// <summary>
    /// 类型Id
    /// </summary>
    [DisplayName("DicinfoDictypeId")]
    public Guid? DictypeId { get; set; }

    /// <summary>
    /// 字典名称
    /// </summary>
    [DisplayName("DicinfoName")]
    public string? Name { get; set; }

    /// <summary>
    /// 字典值
    /// </summary>
    [DisplayName("DicinfoValue")]
    public string? Value { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    [DisplayName("DicinfoStatus")]
    public bool? Status { get; set; }
}