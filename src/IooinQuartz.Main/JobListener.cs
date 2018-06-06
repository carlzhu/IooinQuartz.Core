using Quartz;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IooinQuartz.Main
{
    public class JobListener : IJobListener
    {
        public Action Action { get; set; }

        public string Name { get; set; }

        public Task JobExecutionVetoed(IJobExecutionContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() =>
            {
                //Console.WriteLine("JobExecutionVetoed")
            });
        }

        public Task JobToBeExecuted(IJobExecutionContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            //执行前执行
            return Task.Run(() =>
            {
                if (Action != null)
                    context.Put("Action", Action);
            });
        }

        public Task JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException, CancellationToken cancellationToken = default(CancellationToken))
        {
            //执行后执行
            return Task.Run(() =>
            {
                JobKey jobKey = context.JobDetail.Key;
                // 获取传递过来的参数            
                JobDataMap data = context.JobDetail.JobDataMap;
                //获取回传的数据库表条目数
            });
        }
    }
}
