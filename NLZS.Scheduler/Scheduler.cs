using System;
using System.Collections.Generic;
using System.Linq;
using NLZS.Scheduling.Models;
using NLZS.Scheduling.Scoring;

namespace NLZS.Scheduling
{
    public class Scheduler
    {
        public IEnumerable<Duty> Generate(IEnumerable<Employee> employees, IEnumerable<int> requiredTimeslots, IScoringFunction scoringFunction)
        {
            var matrix = new AvailabilityMatrix(employees);
            GenerateRandomSchedule(matrix, requiredTimeslots);
        }

        private IEnumerable<Duty> GenerateRandomSchedule(AvailabilityMatrix matrix, IEnumerable<int> requiredTimeslots)
        {
            int currentTimeslot = 0;
            foreach (var timeslot in requiredTimeslots)
            {
                var employees = matrix.GetAvailableEmployees(timeslot);
                employees.
            }
            return null;
        }
    }

    public static class ListExtension
    {
        private static Random _random = new Random();
        public static T GetRandom<T>(this IEnumerable<T> list)
        {
            var i = _random.Next(0, list.Count())
        }
    }
}
