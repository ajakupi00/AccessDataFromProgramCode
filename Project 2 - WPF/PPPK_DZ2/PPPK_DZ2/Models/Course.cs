using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPK_DZ2.Models
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }
        public int ECTS { get; set; }

        public override string ToString() => $"{Id}: {Name}";

        public override bool Equals(object obj)
        {
            return obj is Course && ((Course)obj).Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
