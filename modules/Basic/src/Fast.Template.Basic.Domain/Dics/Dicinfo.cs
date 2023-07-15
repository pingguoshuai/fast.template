using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Domain.Entities.Auditing;

namespace Fast.Template.Basic.Dics
{
    public class Dicinfo : FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 类型Id
        /// </summary>
        public Guid DictypeId { get; set; }
        public DicType DicType { get; set; }

        /// <summary>
        /// 字典名称
        /// </summary>
        [StringLength(90)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 字典值
        /// </summary>
        [StringLength(90)]
        [Required]
        public string Value { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; } = 0;

        /// <summary>
        /// 状态
        /// </summary>
        public bool Status { get; set; } = true;

    protected Dicinfo()
    {
    }

    public Dicinfo(
        Guid id,
        Guid dictypeId,
        DicType dicType,
        string name,
        string value,
        int sort,
        bool status
    ) : base(id)
    {
        DictypeId = dictypeId;
        DicType = dicType;
        Name = name;
        Value = value;
        Sort = sort;
        Status = status;
    }
    }
}
