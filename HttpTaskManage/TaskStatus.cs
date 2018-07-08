using System;
using System.Collections.Generic;
using System.Text;

namespace HttpTaskModel
{
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
