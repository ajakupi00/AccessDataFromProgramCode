using PPPK_DZ2.DAL;
using PPPK_DZ2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPPK_DZ2.ViewModel
{
    public class ProfessorViewModel
    {
        public ObservableCollection<Professor> Professors { get; }
        public ObservableCollection<Course> Courses { get; }

        public ProfessorViewModel()
        {
            Professors = new ObservableCollection<Professor>(RepositoryFactory<Professor>.GetProfessorRepository().GetAll());
            Professors.CollectionChanged += Professors_CollectionChanged;
        }

        private void Professors_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    RepositoryFactory<Professor>.GetProfessorRepository().Add(Professors[e.NewStartingIndex]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    RepositoryFactory<Professor>.GetProfessorRepository().Delete(e.OldItems.OfType<Professor>().ToList()[0]);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    RepositoryFactory<Professor>.GetProfessorRepository().Update(
                       e.NewItems.OfType<Professor>().ToList()[0]);
                    break;

            }
        }
        public void Update(Professor professor) => Professors[Professors.IndexOf(professor)] = professor;
    }
}
