using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLZS.Scheduling;
using NLZS.Scheduling.Models;
using NLZS.Scheduling.Scoring;

namespace NLZS.Tests
{
    [TestClass]
    public class SchedulerTests
    {
        [TestMethod]
        public void CreateSimpleSchedule()
        {
            var scheduler = new Scheduler();

            var employees = new List<Employee>();

            employees.Add(new Employee("sander", new[]  {0, 1, 2, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15}));
            employees.Add(new Employee("jorik",  new[]  {0, 1, 2, 3, 4, 5, 6, 8, 10, 11, 12, 13, 14}));
            employees.Add(new Employee("jiri",   new[]  {2, 3, 4, 10, 11, 13}));
            employees.Add(new Employee("morten", new[]  {0, 1, 11, 13, 14, 15}));

            var schedule = scheduler.Generate(employees, new _247SupportScoringFunction());

            
        }
    }
}