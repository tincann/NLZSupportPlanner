using System;
using NLZS.Scheduling.Models;

namespace NLZS.Scheduling.Scoring
{
    public class _247SupportScoringFunction : IScoringFunction
    {
        public const int TargetWeekendWeekRatio = 1;
        
        public double Calculate(EmployeeSchedule schedule)
        {
            var ratio = CalculateWeekendWeekRatio(schedule);
            var difference = TargetWeekendWeekRatio - ratio;
            return difference*difference;
        }

        private static double CalculateWeekendWeekRatio(EmployeeSchedule schedule)
        {
            var weekCount = 0;
            var weekendCount = 0;
            foreach (var shift in schedule.Shifts)
            {
                switch (shift.Type)
                {
                    case DutyType.Week:
                        weekCount++;
                        break;
                    case DutyType.Weekend:
                        weekendCount++;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return (double) weekendCount/weekCount;
        }
    }
}
