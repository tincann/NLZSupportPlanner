using System.Collections.Generic;

namespace NLZS.Scheduling.Models
{
    public class Employee
    {
        public Employee(string name, IEnumerable<int> available)
        {
            Name = name;
            Availability = available;
        }

        public string Name { get; private set; }
        public IEnumerable<int> Availability { get; private set; }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals((Employee) obj);
        }

        protected bool Equals(Employee other)
        {
            return string.Equals(Name, other.Name);
        }
    }
}