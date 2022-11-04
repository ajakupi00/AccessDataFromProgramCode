using PPPK_DZ2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPK_DZ2.DAL
{
    public interface IProfessorRepository : IRepository<Professor>
    {
        void AddCourse(Professor professor, Course course);
        IEnumerable<Course> GetCourses(Professor professor);
        void RemoveCourse(Professor professor, int courseId);
    }
}
