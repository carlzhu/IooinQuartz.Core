using System;
using System.Collections.Generic;
using System.Text;

namespace IooinQuartz.Calc
{
    public interface ICalcJob
    {
        string JobName { get; }
        void Exec();
    }
}
