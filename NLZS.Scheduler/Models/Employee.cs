using System.Collections.Generic;
using System.Linq;

namespace NLZS.Scheduling.Models
{
    public class Employee
    {
        public string Name { get; private set; }

        public Employee(string name)
        {
            Name = name;
        }

        public Employee(string name, IEnumerable<int> available) : this(name)
        {
            available.ToList().ForEach(x => _availability.Add(x));
        }

        private readonly HashSet<int> _availability = new HashSet<int>();

        public void SetAvailability(int timeSlot, bool available)
        {
            if (available)
            {
                _availability.Add(timeSlot);
            }
            else
            {
                _availability.Remove(timeSlot);
            }
        }

        public bool IsAvailable(int timeSlot)
        {
            return _availability.Contains(timeSlot);
        }
    }
}