using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace HttpTaskModel
{
    [DataContractAttribute(IsReference =true )]
    public class HttpResultCfg : EntityBase
    {
        [DataMember]
        /// <summary>
        /// 响应的文件类型
        /// </summary>
        public FilenameExtension ResponseType { get; set; } = FilenameExtension.Text;
        [DataMember]
        /// <summary>
        /// HTTP Status Code
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; set; }
        [DataMember]
        #region MyRegion

        #endregion
        public string FullText { get; set; }
        [DataMember]
        public byte[] Binary { get; set; }
        [DataMember]
        [ForeignKey("Target")]
        public long RequstChildId { get; set; }
        [DataMember]
        public HttpTaskModel.HttpRequestChildCfg Target { get; set; }
        [DataMember]

        public int Page { get; set; }
        [DataMember]
        /// <summary>
        /// 查询关键字
        /// </summary>
        public string SearchKey { get; set; }
    }
}
