using PPPK_DZ2.DAL;
using PPPK_DZ2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPK_DZ2.ViewModel
{
    public class CourseViewModel
    {
        public ObservableCollection<Course> Courses { get; }

        public CourseViewModel()
        {
            Courses = new ObservableCollection<Course>(RepositoryFactory<Course>.GetCourseRepository().GetAll());
            Courses.CollectionChanged += Courses_CollectionChanged;
        }

        private void Courses_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    RepositoryFactory<Course>.GetCourseRepository().Add(Courses[e.NewStartingIndex]);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    RepositoryFactory<Course>.GetCourseRepository().Delete(e.OldItems.OfType<Course>().ToList()[0]);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    RepositoryFactory<Course>.GetCourseRepository().Update(
                        e.NewItems.OfType<Course>().ToList()[0]);
                    break;
            }
        }
        public void Update(Course course) => Courses[Courses.IndexOf(course)] = course;
    }
}
