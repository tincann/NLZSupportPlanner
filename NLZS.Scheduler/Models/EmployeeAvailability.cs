using System.Collections.Generic;

namespace NLZS.Scheduling.Models
{
    public class EmployeeAvailability
    {
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