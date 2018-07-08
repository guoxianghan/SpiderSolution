using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HttpTaskModel
{
    public class EntityBase
    {
        [Key]
        public long Id { get; set; }
        public string Key { get; set; }
        public DateTime? CreatedTime { get; set; }
        /// <summary>
        /// 0未删除,1删除
        /// </summary>
        public bool IsDelete { get; set; } = false;
        public DateTime? UpdatedTime { get; set; }
        public DateTime? DeletedTime { get; set; }
        /// <summary>
        /// 任务顺序号
        /// </summary>
        public byte SeqNo { get; set; }
        public TaskStatus TaskStatus { get; set; }
    }
}
