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

            var schedule = scheduler.Generate(employees, Enumerable.Range(0, 15), new _247SupportScoringFunction());

            PrintSchedule(employees, schedule);
        }

        private const int Padding = 2;
        private static void PrintSchedule(List<Employee> employees, IEnumerable<Duty> duties)
        {
            var maxNameLength = employees.Max(x => x.Name.Length);

            duties = duties.OrderBy(x => x.Timeslot);

            Debug.Write(new string(' ', maxNameLength + Padding));
            Debug.Write(String.Join("  ", duties.Select(x => x.Timeslot)));
            Debug.WriteLine("");
            foreach (var employee in employees)
            {
                Debug.Write(employee.Name.PadRight(maxNameLength + Padding));

                foreach (var duty in duties)
                {
                    if (duty.Employee.Equals(employee))
                    {
                        Debug.Write("X");
                    }
                    else
                    {
                        Debug.Write(" ");
                    }
                    Debug.Write("  ");
                }

                Debug.Write("    ");
                PrintStatistics(employee, duties);

                Debug.WriteLine("");
            }
        }

        private static void PrintStatistics(Employee employee, IEnumerable<Duty> duties)
        {
            var empduties = duties.Where(x => x.Employee.Equals(employee));
            var weekCount = empduties.Count(x => x.Type == DutyType.Week);
            var weekendCount = empduties.Count(x => x.Type == DutyType.Weekend);
            Debug.Write(String.Format("week: {0} weekend: {1}", weekCount, weekendCount));
        }
    }
}