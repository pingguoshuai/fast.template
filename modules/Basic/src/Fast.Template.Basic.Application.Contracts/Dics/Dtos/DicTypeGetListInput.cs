using System;
using System.ComponentModel;
using Volo.Abp.Application.Dtos;

namespace Fast.Template.Basic.Dics.Dtos;

[Serializable]
public class DicTypeGetListInput : PagedAndSortedResultRequestDto
{
    /// <summary>
    /// 名称
    /// </summary>
    //[DisplayName("DicTypeName")]
    public string? Name { get; set; }

    /// <summary>
    /// 代码
    /// </summary>
    //[DisplayName("DicTypeCode")]
    public string? Code { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    //[DisplayName("DicTypeStatus")]
    public bool? Status { get; set; }
}