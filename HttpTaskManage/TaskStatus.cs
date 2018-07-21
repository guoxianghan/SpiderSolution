using System;
using System.Collections.Generic;
using System.Text;

namespace HttpTaskModel
{
    [Flags]
    public enum TaskStatus
    {
        /// <summary>
        /// 创建
        /// </summary>
        Created,
        /// <summary>
        /// 服务端准备任务
        /// </summary>
        Ready,
        /// <summary>
        /// 服务器已推送
        /// </summary>
        ServerSent,
        /// <summary>
        /// 客户端已收到
        /// </summary>
        ClientReceived,
        /// <summary>
        /// 客户端正在执行
        /// </summary>
        Running,
        /// <summary>
        /// 服务端请求中断
        /// </summary>
        Abort,
        /// <summary>
        /// 客户端确认中断或自行中断,(由于查询受限等)
        /// </summary>
        Aborted,
        /// <summary>
        ///服务端请求继续执行
        /// </summary>
        Continue,
        /// <summary>
        /// 客户端完成
        /// </summary>        
        Complete,
        /// <summary>
        /// 任务失败
        /// </summary>
        TaskFailed,
        /// <summary>
        /// 任务超时
        /// </summary>
        TimeOut
    }


}
