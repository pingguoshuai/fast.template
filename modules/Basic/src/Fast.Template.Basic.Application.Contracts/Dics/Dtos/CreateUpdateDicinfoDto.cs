using System;
using System.ComponentModel;

namespace Fast.Template.Basic.Dics.Dtos;

[Serializable]
public class CreateUpdateDicinfoDto
{
    /// <summary>
    /// 类型Id
    /// </summary>
    [DisplayName("DicinfoDictypeId")]
    public Guid DictypeId { get; set; }

    /// <summary>
    /// 字典名称
    /// </summary>
    [DisplayName("DicinfoName")]
    public string Name { get; set; }

    /// <summary>
    /// 字典值
    /// </summary>
    [DisplayName("DicinfoValue")]
    public string Value { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    [DisplayName("DicinfoSort")]
    public int Sort { get; set; }

    /// <summary>
    /// 状态
    /// </summary>
    [DisplayName("DicinfoStatus")]
    public bool Status { get; set; }
}