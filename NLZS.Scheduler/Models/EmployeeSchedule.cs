using System.Collections.Generic;

namespace NLZS.Scheduling.Models
{
    public class EmployeeSchedule
    {
        public Employee Employee { get; private set; }
        public readonly IEnumerable<Duty> Shifts = new List<Duty>();

        public EmployeeSchedule(Employee employee)
        {
            Employee = employee;
        }
    }
}
