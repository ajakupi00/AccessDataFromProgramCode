using Microsoft.Win32;
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
    /// Interaction logic for EditStudentPage.xaml
    /// </summary>
    public partial class EditStudentPage : FramedStudentPage
    {
        private const string Filter = "All supported graphics|*.jpg;*.jpeg;*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|Portable Network Graphic (*.png)|*.png";

        private Student _student;
        private bool imageChanged = false;
        public EditStudentPage(StudentViewModel viewModel, Student student = null) : base(viewModel)
        {
            InitializeComponent();
            _student = student ?? new Student();
            DataContext = _student;
            FillCourses();
        }

        private void FillCourses()
        {
            var allCourses = RepositoryFactory<Course>.GetCourseRepository().GetAll();
            if(_student.Id != 0)
            {
                var studentCourses = RepositoryFactory<Student>.GetStudentRepository().GetCourses(_student);
                var leftCourses = allCourses.Except(studentCourses);
                CbCourses.ItemsSource = leftCourses;
                LvCourses.ItemsSource = studentCourses;
            }
            else
            {
                CbCourses.ItemsSource = allCourses;
            }
           
            CbCourses.SelectedIndex = -1;
        }

        private void BtnUpload_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog()
            {
                Filter = Filter
            };
            if(dialog.ShowDialog() == true)
            {
                xPicture.Source = new BitmapImage(new Uri(dialog.FileName));
                imageChanged = true;
            }

        }

        private void BtnCommit_Click(object sender, RoutedEventArgs e)
        {
            if (FormValid())
            {
                _student.FirstName = TbFirstName.Text.Trim();
                _student.LastName = TbLastName.Text.Trim();
                _student.JMBAG = TbJmbag.Text.Trim();
                if(imageChanged)
                    _student.Image = ImageUtils.BitmapImageToByteArray(xPicture.Source as BitmapImage);

                if(_student.Id == 0)
                {
                    StudentViewModel.Students.Add(_student);
                    Frame.Navigate(new ListStudentPage(new StudentViewModel()) { Frame = Frame });
                }
                else
                {
                    StudentViewModel.Update(_student);
                    Frame.NavigationService.GoBack();
                }
            }
        }

        private bool FormValid()
        {
            bool valid = true;
            GridContainer.Children.OfType<TextBox>().ToList().ForEach(e =>
            {
                if (string.IsNullOrEmpty(e.Text.Trim()))
                {
                    e.Background = Brushes.LightCoral;
                    valid = false;
                }
                else
                {
                    e.Background = Brushes.White;
                }
            });
            if(xPicture.Source == null)
            {
                ImageBorder.BorderBrush = Brushes.LightCoral;
                valid = false;
            }
            else
            {
                ImageBorder.BorderBrush = Brushes.White;

            }

            return valid;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.NavigationService.GoBack();
        }

        private void BtnRemoveCourse_Click(object sender, RoutedEventArgs e)
        {
            if(LvCourses.SelectedItem != null)
            {
                RepositoryFactory<Student>.GetStudentRepository().RemoveCourse(_student,((Course)LvCourses.SelectedItem).Id);
                FillCourses();
            }
        }

        private void BtnAddCourse_Click(object sender, RoutedEventArgs e)
        {
            if(CbCourses.SelectedItem != null)
            {
                if(_student.Id == 0)
                {
                    if(MessageBox.Show("Commit changes first!", "Alert" ) == MessageBoxResult.OK)
                    {
                        return;
                    }
                }
                RepositoryFactory<Student>.GetStudentRepository().AddCourse(_student, (Course)CbCourses.SelectedItem);
                FillCourses();
            }
        }
    }
}
