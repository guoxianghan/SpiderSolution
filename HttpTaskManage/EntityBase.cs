using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace HttpTaskModel
{
    [DataContractAttribute(IsReference = true)]
    public class EntityBase
    {
        public EntityBase()
        {
            //Console.WriteLine(this.GetHashCode());
        }
        [DataMember]
        [Key]
        public long Id { get; set; }
        [DataMember]
        public Guid Key { get; set; }

        [DataMember]
        public DateTime? CreatedTime { get; set; } = DateTime.Now;
        [DataMember]
        /// <summary>
        /// 0未删除,1删除
        /// </summary>
        public bool IsDelete { get; set; } = false;
        [DataMember]
        public DateTime? UpdatedTime { get; set; }
        [DataMember]
        public DateTime? DeletedTime { get; set; }
        [DataMember]
        public string info { get; set; }
        [DataMember]
        /// <summary>
        /// 任务顺序号
        /// </summary>
        public byte SeqNo { get; set; }
        [DataMember]
        public TaskStatus TaskStatus { get; set; } = TaskStatus.Created;
    }
}
