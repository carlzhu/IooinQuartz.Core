# IooinQuartz.Core
Use Quartz, You can configure it any way you want.

# Config

        public List<IooinPlan> Get
        {
            get
            {

                List<IooinPlan> plans = new List<IooinPlan>();
                plans.Add(new IooinPlan()
                {
                    DllPath =   "dllpath",
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
                    DllPath = "dllpath",
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
