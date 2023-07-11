using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Fast.Template.Basic.Dics
{
    /// <summary>
    /// 字典类型
    /// </summary>
    public class DicType : FullAuditedAggregateRoot<DicType>
    {
        /// <summary>
        /// 名称
        /// </summary>
        [Required]
        [StringLength(90)]
        public string Name { get; set; }

        /// <summary>
        /// 代码
        /// </summary>
        [Required]
        [StringLength(90)]
        public string Code { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        [Required]
        public bool Status { get; set; }
    }
}
