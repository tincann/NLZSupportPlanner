using System.Collections.Generic;
using NLZS.Scheduling.Models;

namespace NLZS.Scheduling.Scoring
{
    public interface IScoringFunction
    {
        double Calculate(List<Duty> schedule);
    }
}
