using System.Collections.Generic;
using System.Linq;
using NLZS.Scheduling.Models;
using NLZS.Scheduling.Scoring;

namespace NLZS.Scheduling
{
    public class Scheduler
    {
        public IEnumerable<EmployeeSchedule> Generate(IEnumerable<Employee> employees, IScoringFunction scoringFunction)
        {
            foreach (var employee in employees)
            {
                
            }
            return new List<EmployeeSchedule>() {new EmployeeSchedule(employees.First())};
        }
    }
}
