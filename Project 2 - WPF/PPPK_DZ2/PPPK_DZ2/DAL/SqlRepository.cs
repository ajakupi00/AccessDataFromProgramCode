using PPPK_DZ2.Models;
using PPPK_DZ2.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;

namespace PPPK_DZ2.DAL
{
    //Pa$$w0rd sql password
    public class SqlRepository : ICourseRepository, IStudentRepository, IProfessorRepository
    {
        private readonly string cs = ConfigurationManager.ConnectionStrings["cs"].ToString();

        public void Add(Course entity)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name + nameof(Course).ToString();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(Course.Name), entity.Name);
                    cmd.Parameters.AddWithValue(nameof(Course.ECTS), entity.ECTS);

                    SqlParameter id = new SqlParameter(nameof(Course.Id), System.Data.SqlDbType.Int)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    cmd.Parameters.Add(id);

                    cmd.ExecuteNonQuery();
                    entity.Id = (int)id.Value;
                }
            }
        }
        public void Delete(Course entity)
        {

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name + nameof(Course).ToString();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(Course.Id), entity.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public Course Get(int id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name + nameof(Course);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(Course.Id), id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            ReadCourse(dr);
                        }
                    }
                }
            }
            throw new Exception("Wrong id");
        }
        public IEnumerable<Course> GetAll()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(GetAll) + nameof(Course);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            yield return ReadCourse(dr);
                        }
                    }
                }
            }
        }
        public void Update(Course entity)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name + nameof(Course).ToString();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(Course.Id), entity.Id);
                    cmd.Parameters.AddWithValue(nameof(Course.Name), entity.Name);
                    cmd.Parameters.AddWithValue(nameof(Course.ECTS), entity.ECTS);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void Add(Student entity)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name + nameof(Student).ToString();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(Student.FirstName), entity.FirstName);
                    cmd.Parameters.AddWithValue(nameof(Student.LastName), entity.LastName);
                    cmd.Parameters.AddWithValue(nameof(Student.JMBAG), entity.JMBAG);

                    cmd.Parameters.Add(new SqlParameter(nameof(Student.Image),
                        System.Data.SqlDbType.Binary, entity.Image.Length)
                    {
                        Value = entity.Image
                    });

                    SqlParameter id = new SqlParameter(nameof(Student.Id), System.Data.SqlDbType.Int)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    cmd.Parameters.Add(id);
                    cmd.ExecuteNonQuery();
                    entity.Id = (int)id.Value;
                }
            }
        }
        public void Delete(Student entity)
        {

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name + nameof(Student).ToString();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(Student.Id), entity.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Update(Student entity)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name + nameof(Student).ToString();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(Student.Id), entity.Id);
                    cmd.Parameters.AddWithValue(nameof(Student.FirstName), entity.FirstName);
                    cmd.Parameters.AddWithValue(nameof(Student.LastName), entity.LastName);
                    cmd.Parameters.AddWithValue(nameof(Student.JMBAG), entity.JMBAG);
                    cmd.Parameters.Add(new SqlParameter(
                        nameof(Student.Image),
                        System.Data.SqlDbType.Binary,
                        entity.Image.Length)
                    {
                        Value = entity.Image
                    });

                    cmd.ExecuteNonQuery();
                }
            }
        }
        Student IRepository<Student>.Get(int id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name + nameof(Student);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(Student.Id), id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            ReadStudent(dr);
                        }
                    }
                }
            }
            throw new Exception("Wrong id");
        }
        IEnumerable<Student> IRepository<Student>.GetAll()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(GetAll) + nameof(Student);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while(dr.Read())
                        {
                            yield return ReadStudent(dr);
                        }
                    }
                }
            }
        }
        public IEnumerable<Course> GetCourses(Student student)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(GetAll) + nameof(Student) + nameof(Course);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(Student.Id), student.Id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            yield return ReadCourse(dr);
                        }
                    }
                }
            }
        }
        public void AddCourse(Student student, Course course)
        {
            if(course.Id == 0 || course == null)
            {
                throw new Exception("Course doesn't exits!");
            }
            using(SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using(SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(Student) + MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(Student) + nameof(Student.Id), student.Id);
                    cmd.Parameters.AddWithValue(nameof(Course) + nameof(Course.Id), course.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void RemoveCourse(Student student, int courseId)
        {
            if (courseId == 0)
            {
                throw new Exception("Course doesn't exits!");
            }
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(Student) + MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(Student) + nameof(Student.Id), student.Id);
                    cmd.Parameters.AddWithValue(nameof(Course) + nameof(Course.Id), courseId);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void Add(Professor entity)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name + nameof(Professor).ToString();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(Professor.FirstName), entity.FirstName);
                    cmd.Parameters.AddWithValue(nameof(Professor.LastName), entity.LastName);
                    cmd.Parameters.AddWithValue(nameof(Professor.Email), entity.Email);

                    SqlParameter id = new SqlParameter(nameof(Professor.Id), System.Data.SqlDbType.Int)
                    {
                        Direction = System.Data.ParameterDirection.Output
                    };
                    cmd.Parameters.Add(id);
                    cmd.ExecuteNonQuery();
                    entity.Id = (int)id.Value;
                }
            }
        }
        public void Delete(Professor entity)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name + nameof(Professor).ToString();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(Professor.Id), entity.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Update(Professor entity)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name + nameof(Professor).ToString();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(Professor.Id), entity.Id);
                    cmd.Parameters.AddWithValue(nameof(Professor.FirstName), entity.FirstName);
                    cmd.Parameters.AddWithValue(nameof(Professor.LastName), entity.LastName);
                    cmd.Parameters.AddWithValue(nameof(Professor.Email), entity.Email);
                  
                    cmd.ExecuteNonQuery();
                }
            }
        }
        Professor IRepository<Professor>.Get(int id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = MethodBase.GetCurrentMethod().Name + nameof(Professor);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(Professor.Id), id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            ReadProfessor(dr);
                        }
                    }
                }
            }
            throw new Exception("Wrong id");
        }
        IEnumerable<Professor> IRepository<Professor>.GetAll()  
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(GetAll) + nameof(Professor);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            yield return ReadProfessor(dr);
                        }
                    }
                }
            }
        }
        public IEnumerable<Course> GetCourses(Professor professor)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(GetAll) + nameof(Professor) + nameof(Course);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(Professor.Id), professor.Id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            yield return ReadCourse(dr);
                        }
                    }
                }
            }
        }
        public void AddCourse(Professor professor, Course course)
        {
            if (course.Id == 0 || course == null)
            {
                throw new Exception("Course doesn't exits!");
            }
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(Professor) + MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(Professor) + nameof(Professor.Id), professor.Id);
                    cmd.Parameters.AddWithValue(nameof(Course) + nameof(Course.Id), course.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void RemoveCourse(Professor professor, int courseId)
        {
            if (courseId == 0)
            {
                throw new Exception("Course doesn't exits!");
            }
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = nameof(Professor) + MethodBase.GetCurrentMethod().Name;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue(nameof(Professor) + nameof(Professor.Id), professor.Id);
                    cmd.Parameters.AddWithValue(nameof(Course) + nameof(Course.Id), courseId);

                    cmd.ExecuteNonQuery();
                }
            }
        }





        private Course ReadCourse(SqlDataReader dr) => new Course()
        {
            Id = (int)dr[nameof(Course.Id)],
            Name = dr[nameof(Course.Name)].ToString(),
            ECTS = (int)dr[nameof(Course.ECTS)]
        };
        private Student ReadStudent(SqlDataReader dr) => new Student
        {
            Id = (int)dr[nameof(Student.Id)],
            FirstName = dr[nameof(Student.FirstName)].ToString(),
            LastName = dr[nameof(Student.LastName)].ToString(),
            JMBAG = dr[nameof(Student.LastName)].ToString(),
            Image = ImageUtils.ByteArrayFromSqlDataReader(dr, 4)
        };
        private Professor ReadProfessor(SqlDataReader dr) => new Professor()
        {
            Id = (int)dr[nameof(Professor.Id)],
            FirstName = dr[nameof(Professor.FirstName)].ToString(),
            LastName = dr[nameof(Professor.LastName)].ToString(),
            Email = dr[nameof(Professor.Email)].ToString()
        };

      
    }
}
