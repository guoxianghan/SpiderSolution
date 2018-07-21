using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpTaskManage
{
    public enum SchedulerType
    {
        /// <summary>
        /// 请求一次
        /// </summary>
        Single,
        /// <summary>
        /// 分页查询
        /// </summary>
        Page,
        /// <summary>
        /// 逐天查询
        /// </summary>
        Date
    }
}
