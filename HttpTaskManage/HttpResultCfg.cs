using System;
using System.Collections.Generic;
using System.Text;

namespace HttpTaskDataBase
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
        public int HttpStatusCode { get; set; }

        public string FullText { get; set; }
        public byte[] Binary { get; set; }
        public long TaskId { get; set; }
    }
}
