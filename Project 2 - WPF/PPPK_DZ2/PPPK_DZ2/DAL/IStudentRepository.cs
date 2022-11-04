using PPPK_DZ2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPK_DZ2.DAL
{
    public interface IStudentRepository : IRepository<Student>
    {
        void AddCourse(Student student, Course course);
        IEnumerable<Course> GetCourses(Student student);
        void RemoveCourse(Student student, int courseId);
    }
}
