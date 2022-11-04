using PPPK_DZ2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPK_DZ2.DAL
{
    static class RepositoryFactory<T> where T : BaseEntity
    {
        private static readonly Lazy<ICourseRepository> courseRepository
            = new Lazy<ICourseRepository>(() => new SqlRepository());
        public static ICourseRepository GetCourseRepository() => courseRepository.Value;

        private static readonly Lazy<IStudentRepository> studentRepository
            = new Lazy<IStudentRepository>(() => new SqlRepository());
        public static IStudentRepository GetStudentRepository() => studentRepository.Value;

        private static readonly Lazy<IProfessorRepository> professorRepository
            = new Lazy<IProfessorRepository>(() => new SqlRepository());
        public static IProfessorRepository GetProfessorRepository() => professorRepository.Value;
    }
}
