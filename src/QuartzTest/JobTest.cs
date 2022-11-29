using System;
using System.Threading.Tasks;
using Quartz;

namespace QuartzTest
{
    public class JobTest:IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}