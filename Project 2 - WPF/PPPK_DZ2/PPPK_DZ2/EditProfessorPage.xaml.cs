using PPPK_DZ2.DAL;
using PPPK_DZ2.Models;
using PPPK_DZ2.Utils;
using PPPK_DZ2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PPPK_DZ2
{
    /// <summary>
    /// Interaction logic for EditProfessorPage.xaml
    /// </summary>
    public partial class EditProfessorPage : FramedProfessorPage
    {
        private Professor _professor;
        public EditProfessorPage(ProfessorViewModel viewModel, Professor professor = null) : base(viewModel)
        {
            InitializeComponent();
            _professor = professor ?? new Professor();
            DataContext = _professor;
            FillCourses();
        }

        private void FillCourses()
        {
            var allCourses = RepositoryFactory<Course>.GetCourseRepository().GetAll();
            if (_professor.Id != 0)
            {
                var teachingCourses = RepositoryFactory<Professor>.GetProfessorRepository().GetCourses(_professor);
                var leftCourses = allCourses.Except(teachingCourses);
                CbCourses.ItemsSource = leftCourses;
                LvCourses.ItemsSource = teachingCourses;
            }
            else
            {
                CbCourses.ItemsSource = allCourses;
            }

            CbCourses.SelectedIndex = -1;
        }

        private void BtnAddCourse_Click(object sender, RoutedEventArgs e)
        {
            if (CbCourses.SelectedItem != null)
            {
                if (_professor.Id == 0)
                {
                    if (MessageBox.Show("Commit changes first!", "Alert") == MessageBoxResult.OK)
                    {
                        return;
                    }
                }
                RepositoryFactory<Professor>.GetProfessorRepository().AddCourse(_professor, (Course)CbCourses.SelectedItem);
                FillCourses();
            }
        }

        private void BtnRemoveCourse_Click(object sender, RoutedEventArgs e)
        {
            if (LvCourses.SelectedItem != null)
            {
                RepositoryFactory<Professor>.GetProfessorRepository().RemoveCourse(_professor, ((Course)LvCourses.SelectedItem).Id);
                FillCourses();
            }
        }

        private void BtnCommit_Click(object sender, RoutedEventArgs e)
        {
            if (FormValid())
            {
                _professor.FirstName = TbFirstName.Text.Trim();
                _professor.LastName = TbLastName.Text.Trim();
                _professor.Email = TbEmail.Text.Trim();
                if(_professor.Id == 0)
                {
                    ProfessorViewModel.Professors.Add(_professor);
                    Frame.Navigate(new ListProfessorsPage(new ProfessorViewModel()) { Frame = Frame });
                }
                else
                {
                    ProfessorViewModel.Update(_professor);
                    Frame.NavigationService.GoBack();
                }
            }
        }

        private bool FormValid()
        {
            bool valid = true;
            GridContainer.Children.OfType<TextBox>().ToList().ForEach(e =>
            {
                if (string.IsNullOrEmpty(e.Text.Trim()) || ("Email".Equals(e.Tag) && !ValidationUtils.isValidEmail(TbEmail.Text.Trim())))
                {
                    e.Background = Brushes.LightCoral;
                    valid = false;
                }
                else
                {
                    e.Background = Brushes.White;
                }
            });

            return valid;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.NavigationService.GoBack();
        }
    }
}
