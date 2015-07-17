using NLZS.Scheduling.Models;

namespace NLZS.Scheduling.Scoring
{
    public interface IScoringFunction
    {
        double Calculate(EmployeeSchedule schedule);
    }
}
