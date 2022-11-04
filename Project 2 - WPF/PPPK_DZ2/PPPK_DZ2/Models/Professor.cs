using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPK_DZ2.Models
{
    public class Professor  : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<Course> TeachingCourses{ get; set; }

        public override bool Equals(object obj)
        {
            return obj is Professor professor &&
                   Id == professor.Id &&
                   FirstName == professor.FirstName &&
                   LastName == professor.LastName;
        }

        public override int GetHashCode()
        {
            int hashCode = 1502931708;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
            return hashCode;
        }

        public override string ToString() => $"{Id}: {FirstName} {LastName}";
    }
}
