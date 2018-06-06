using System;
using System.Collections.Generic;
using System.Text;

namespace IooinQuartz.Demo
{
    public interface IDelegateJob
    {
        string JobName { get; }
        void Execute();
    }
}
