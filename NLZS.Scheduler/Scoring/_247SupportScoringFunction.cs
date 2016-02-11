using System;
using System.Collections.Generic;
using NLZS.Scheduling.Models;

namespace NLZS.Scheduling.Scoring
{
    public class _247SupportScoringFunction : IScoringFunction
    {
        private const int TargetWeekendWeekRatio = 1;
        
        public double Calculate(List<Duty> schedule)
        {
            var weekCount = 0;
            var weekendCount = 0;
            foreach (var shift in schedule)
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

            if (weekendCount == 0 && weekCount == 0)
            {
                return double.MaxValue;
            }

            double ratio;
            if (weekCount != 0)
            {
                ratio = (double) weekendCount/weekCount;
            }
            else
            {
                ratio = (double)weekCount / weekendCount;
            }
            
            var difference = TargetWeekendWeekRatio - ratio;
            return difference*difference;
        }
    }
}
