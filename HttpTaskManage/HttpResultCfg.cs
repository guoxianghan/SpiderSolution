using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Text;

namespace HttpTaskModel
{
    public class HttpResultCfg : EntityBase
    {
        /// <summary>
        /// 响应的文件类型
        /// </summary>
        public FilenameExtension ResponseType { get; set; } = FilenameExtension.Text;
        /// <summary>
        /// HTTP Status Code
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; set; }
        #region MyRegion

        #endregion
        public string FullText { get; set; }
        public byte[] Binary { get; set; }
        [ForeignKey("Target")]
        public long RequstId { get; set; }
        public HttpTaskModel.HttpRequestChildCfg Target { get; set; }

        public int Page { get; set; }
        /// <summary>
        /// 查询关键字
        /// </summary>
        public string SearchKey { get; set; }
    }
}
