using System.Collections.Generic;

namespace NLZS.Scheduling.Models
{
    public class EmployeeSchedule
    {
        public Employee Employee { get; private set; }
        public IEnumerable<EmployeeShift> Schedule;

        public EmployeeSchedule(Employee employee)
        {
            Employee = employee;
        }

    }
}
