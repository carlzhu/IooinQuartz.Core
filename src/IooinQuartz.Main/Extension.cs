using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace IooinQuartz.Main
{
    public static class Extension
    {
        public static TriggerBuilder TriggerFrequency(this TriggerBuilder triggerBuilder, IooinPlan plan)
        {
            if (plan.WithRepeatCount == 0)
            {
                return triggerBuilder.WithSimpleSchedule(x => x.WithIntervalInSeconds(plan.WithIntervalInSeconds).RepeatForever());
            }

            return triggerBuilder.WithSimpleSchedule(x => x.WithIntervalInSeconds(plan.WithIntervalInSeconds).WithRepeatCount(plan.WithRepeatCount));
        }


        /// <summary>
        /// 获取程序集中的实现类对应的多个接口
        /// </summary>
        /// <param name="plan"></param>
        /// <returns></returns>
        public static Dictionary<Type, Type[]> Jobs(this IooinPlan plan)
        {
            if (plan == null)
                throw new ArgumentException(nameof(plan));

            var assembly = Assembly.LoadFile(plan.DllPath);

            if (assembly == null)
                throw new ArgumentNullException(nameof(assembly));

            List<Type> types = assembly.GetTypes().ToList();

            var result = new Dictionary<Type, Type[]>();
            foreach (var item in types.Where(s => !s.IsInterface))
            {
                var interfaceType = item.GetInterfaces();

                if (interfaceType.Any(c => c.Name.Equals(plan.InterfaceName)))
                    result.Add(item, interfaceType);
            }
            return result;
        }
    }
}
