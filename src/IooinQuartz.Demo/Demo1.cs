using System;
using System.Collections.Generic;
using System.Text;

namespace IooinQuartz.Demo
{
    public class Demo1 : IDelegateJob
    {
        public string JobName => this.GetType().Name;

        public void Execute()
        {
            Console.WriteLine("RUN DEMO1 Context:" + DateTime.Now);
        }
    }
}
