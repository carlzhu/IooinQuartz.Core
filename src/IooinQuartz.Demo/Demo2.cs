using System;
using System.Collections.Generic;
using System.Text;

namespace IooinQuartz.Demo
{
    public class Demo2 : IDelegateJob
    {
        public string JobName => this.GetType().Name;

        public void Execute()
        {
            Console.WriteLine("RUN DEMO2 Context:" + DateTime.Now);
        }
    }
}
