using System;
using System.Collections.Generic;
using System.Linq;
using NLZS.Scheduling.Models;
using NLZS.Scheduling.Scoring;

namespace NLZS.Scheduling
{
    public class Scheduler
    {
        public List<Duty> Generate(List<Employee> employees, List<int> requiredTimeslots, IScoringFunction scoringFunction)
        {
            var matrix = new AvailabilityMatrix(employees);
            return GenerateRandomSchedule(matrix, requiredTimeslots);
        }

        private List<Duty> GenerateRandomSchedule(AvailabilityMatrix matrix, List<int> requiredTimeslots)
        {
            var duties = new List<Duty>(requiredTimeslots.Count);
            foreach (var timeslot in requiredTimeslots)
            {
                var employees = matrix.GetAvailableEmployees(timeslot);
                var employee = employees.GetRandom();
                var duty = new Duty(timeslot, employee, timeslot % 2 == 0 ? DutyType.Week : DutyType.Weekend); //todo week weekend koppelen aan timeslot
                duties.Add(duty);
            }
            return duties;
        }
    }

    public static class ListExtension
    {
        private static Random _random = new Random();
        public static T GetRandom<T>(this List<T> list)
        {
            var i = _random.Next(0, list.Count);
            return list[i];
        }
    }
}
