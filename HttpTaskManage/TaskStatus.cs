using System;
using System.Collections.Generic;
using System.Text;

namespace HttpTaskManage
{
   public enum TaskStatus
    {
        Created,
        Ready,
        Running,
        Complete,
        Failed,
        TimeOut
    }
}
