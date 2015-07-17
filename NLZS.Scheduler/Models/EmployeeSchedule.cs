using System.Collections.Generic;

namespace NLZS.Scheduling.Models
{
    public class EmployeeSchedule
    {
        public Employee Employee { get; private set; }
        public readonly IEnumerable<EmployeeShift> Shifts = new List<EmployeeShift>();

        public EmployeeSchedule(Employee employee)
        {
            Employee = employee;
        }
    }
}
