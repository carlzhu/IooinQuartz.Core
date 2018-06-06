using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IooinQuartz.Main
{
    public class BaseJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            return Task.Run(() =>
            {
                (context.Get("Action") as Action)?.Invoke();
            });
        }
    }
}
