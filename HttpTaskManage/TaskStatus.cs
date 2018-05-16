using System;
using System.Collections.Generic;
using System.Text;

namespace HttpTaskDataBase
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
