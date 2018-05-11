using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HttpTaskManage
{
   public class EntityBase
    {
        [Key]
        public long Id { get; set; }
        public string Key { get; set; } 
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 0未删除,1删除
        /// </summary>
        public byte IsDelete { get; set; }
        public DateTime? UpdateTime { get; set; }
        public DateTime? DeleteTime { get; set; }
        /// <summary>
        /// 任务顺序号
        /// </summary>
        public byte SeqNo { get; set; }
        public TaskStatus TaskStatus { get; set; }
    }
}
