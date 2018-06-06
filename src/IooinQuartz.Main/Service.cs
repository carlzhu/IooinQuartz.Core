using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Topshelf;
using Topshelf.Runtime;

namespace IooinQuartz.Main
{
    public class Service : ServiceControl
    {
        public static volatile bool IsRunning = true;


        #region Member
        /// <summary>
        /// 
        /// </summary>
        private IScheduler scheduler;

        #endregion

        #region 
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="settings"></param>
        public Service(HostSettings settings)
        {
        }
        #endregion

        #region Start
        /// <summary>
        /// 启动服务
        /// </summary>
        /// <param name="hostControl"></param>
        /// <returns></returns>
        public bool Start(HostControl hostControl)
        {
            Run().GetAwaiter().GetResult();
            return true;
        }
        #endregion


        #region Stop
        /// <summary>
        /// 停止服务
        /// </summary>
        /// <param name="hostControl"></param>
        /// <returns></returns>
        public bool Stop(HostControl hostControl)
        {
            IsRunning = false;
            this.scheduler.Shutdown(true);
            return true;
        }
        #endregion

        #region Run

        private async Task Run()
        {
            try
            {
                // Grab the Scheduler instance from the Factory
                NameValueCollection props = new NameValueCollection
                {
                    { "quartz.serializer.type", "binary" }
                };
                StdSchedulerFactory factory = new StdSchedulerFactory(props);
                this.scheduler = await factory.GetScheduler();


                foreach (var plan in new Config().Get)
                {
                    await InjectionPlan(plan);
                }

                await this.scheduler.Start();

            }
            catch (SchedulerException se)
            {
                await Console.Error.WriteLineAsync(se.ToString());
            }

            while (true)
            {
                var key = Console.ReadLine();
                if (key == "quit")
                {
                    break;
                }
            }
        }

        public async Task InjectionPlan(IooinPlan plan)
        {
            Dictionary<Type, Type[]> jobs = plan.Jobs();

            foreach (var item in jobs)
            {
                var instance = Activator.CreateInstance(item.Key);
                MethodInfo method = (item.Key).GetMethod(plan.MethodName);
                string jobName = (item.Key).GetProperty("JobName")?.GetValue(instance).ToString() ?? "";


                IJobDetail job = JobBuilder.Create(typeof(BaseJob))
                    .WithIdentity(jobName, plan.GroupName)
                    .Build();

                ISimpleTrigger trigger = (ISimpleTrigger)TriggerBuilder.Create()
                    .WithIdentity($"{plan.GroupName}_{jobName}_trigger")
                    .StartAt(plan.StartTime)
                    .EndAt(plan.EndTime)
                    .ForJob(jobName, plan.GroupName)
                    .TriggerFrequency(plan)
                    .Build();



                JobListener listener = new JobListener
                {
                    Name = jobName,
                    Action = () => method.Invoke(instance, null)
                };

                IMatcher<JobKey> matcher = KeyMatcher<JobKey>.KeyEquals(job.Key);
                scheduler.ListenerManager.AddJobListener(listener, matcher);

                await scheduler.ScheduleJob(job, trigger);
            }
        }

        #endregion

    }
}
