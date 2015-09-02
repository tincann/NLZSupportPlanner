namespace NLZS.Scheduling.Models
{
    public class Duty
    {
        public int Timeslot { get; private set; }
        public Employee Employee { get; private set; }
        public DutyType Type { get; private set; }

        public Duty(int timeslot, Employee employee, DutyType type)
        {
            Timeslot = timeslot;
            Employee = employee;
            Type = type;
        }
    }
}