using System;
using System.Collections.Generic;
using System.Text;

namespace IooinQuartz.Calc
{
    class Demo3 : ICalcJob
    {
        public string JobName => this.GetType().Name;

        public void Exec()
        {
            Console.WriteLine("RUN DEMO4 Context:" + DateTime.Now);
        }
    }
}
