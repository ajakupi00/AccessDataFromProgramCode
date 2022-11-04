using System.Collections.Generic;

namespace PPPK_DZ2.Models
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JMBAG { get; set; }
        public byte[] Image{ get; set; }
        public ICollection<Course> Courses{ get; set; }

        public override bool Equals(object obj)
        {
            return obj is Student student &&
                   Id == student.Id &&
                   FirstName == student.FirstName &&
                   LastName == student.LastName &&
                   JMBAG == student.JMBAG;
        }

        public override int GetHashCode()
        {
            int hashCode = -2015049038;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(JMBAG);
            return hashCode;
        }

        public override string ToString() => $" {FirstName} {LastName}";
    }
}
