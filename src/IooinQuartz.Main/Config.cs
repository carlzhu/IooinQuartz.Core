using System;
using System.Collections.Generic;
using System.Text;

namespace IooinQuartz.Main
{
    public class Config
    {

        public List<IooinPlan> Get
        {
            get
            {

                List<IooinPlan> plans = new List<IooinPlan>();
                plans.Add(new IooinPlan()
                {
                    DllPath = @"C:\Users\Administrator\Source\Repos\IooinQuartz.Core\src\IooinQuartz.Demo\bin\Debug\netcoreapp2.0\IooinQuartz.Demo.dll",
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(1),
                    GroupName = "DemoGroup",
                    InterfaceName = "IDelegateJob",
                    MethodName = "Execute",
                    WithIntervalInSeconds = 10,
                    WithRepeatCount = 2,
                });

                plans.Add(new IooinPlan()
                {
                    DllPath = @"C:\Users\Administrator\Source\Repos\IooinQuartz.Core\src\IooinQuartz.Calc\bin\Debug\netcoreapp2.0\IooinQuartz.Calc.dll",
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddDays(1),
                    GroupName = "DemoGroup",
                    InterfaceName = "ICalcJob",
                    MethodName = "Exec",
                    WithIntervalInSeconds = 10,
                    WithRepeatCount = 5,
                });

                return plans;
            }
        }




    }
}
