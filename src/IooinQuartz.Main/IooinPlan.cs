using System;
using System.Collections.Generic;
using System.Text;

namespace IooinQuartz.Main
{
    public class IooinPlan
    {
        public string DllPath { get; set; }
        public string InterfaceName { get; set; }

        public string GroupName { get; set; }
        public string MethodName { get; internal set; }
        public DateTimeOffset StartTime { get; internal set; }
        public DateTimeOffset? EndTime { get; internal set; }
        public int WithIntervalInSeconds { get; internal set; }
        public int WithRepeatCount { get; internal set; }
    }
}
