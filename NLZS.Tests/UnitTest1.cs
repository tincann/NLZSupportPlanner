using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLZS.Scheduling;

namespace NLZS.Tests
{
    [TestClass]
    public class SchedulerTests
    {
        [TestMethod]
        public void CreateSimpleSchedule()
        {
            var scheduler = new Scheduler();
            scheduler.Generate()
        }
    }
}
