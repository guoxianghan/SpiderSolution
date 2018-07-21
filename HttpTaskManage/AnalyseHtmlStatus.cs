using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpTaskManage
{
    [Flags]
    public enum AnalyseHtmlStatus
    {
        Created,
        Ready,
        /// <summary>
        /// 正在解析
        /// </summary>
        Analysing,
        /// <summary>
        /// 解析完成,有数据,也有部分错误
        /// </summary>
        HasError,
        /// <summary>
        /// 解析完全失败
        /// </summary>
        Failed,
        /// <summary>
        /// 解析完成
        /// </summary>
        Complete
    }
}
