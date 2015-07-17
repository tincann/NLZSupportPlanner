using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

            var employees = new List<Employee>
            {
                new Employee("sander",  new[] { 0, 1, 2, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15}),
                new Employee("jorik",   new[] { 0, 1, 2, 3, 4, 5, 6, 8, 10, 11, 12, 13, 14}),
                new Employee("jiri",    new[] { 2, 3, 4, 10, 11, 13}),
                new Employee("morten",  new[] { 0, 1, 11, 13, 14, 15})
            };

            var schedule = scheduler.Generate(employees, new _247SupportScoringFunction());

            PrintSchedule(schedule);   
        }

        private static void PrintSchedule(IEnumerable<EmployeeSchedule> schedule)
        {
            foreach (var empSchedule in schedule)
            {
                var sched = String.Join("  ", empSchedule.Shifts.Select(x => x.TimeSlot));
                Debug.WriteLine("{0}: {1}", empSchedule.Employee.Name, sched);
            }
        }
    }
}