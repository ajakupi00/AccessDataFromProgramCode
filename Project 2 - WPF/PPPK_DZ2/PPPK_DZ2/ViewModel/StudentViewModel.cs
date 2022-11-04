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
    public class StudentViewModel
    {
        public ObservableCollection<Student> Students { get; }

        public StudentViewModel()
        {
            Students = new ObservableCollection<Student>(RepositoryFactory<Student>.GetStudentRepository().GetAll());
            Students.CollectionChanged += Students_CollectionChanged;
        }

        private void Students_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    RepositoryFactory<Student>.GetStudentRepository().Add(Students[e.NewStartingIndex]);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    RepositoryFactory<Student>.GetStudentRepository().Delete(e.OldItems.OfType<Student>().ToList()[0]);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    RepositoryFactory<Student>.GetStudentRepository().Update(
                        e.NewItems.OfType<Student>().ToList()[0]);
                    break;
            }
        }
        public void Update(Student student) => Students[Students.IndexOf(student)] = student;
    }
}
