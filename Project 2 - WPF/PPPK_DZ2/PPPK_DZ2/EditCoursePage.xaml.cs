using PPPK_DZ2.Models;
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
    /// Interaction logic for EditCoursePage.xaml
    /// </summary>
    public partial class EditCoursePage : FramedCoursePage
    {
        private readonly Course _course;
        public EditCoursePage(CourseViewModel viewModel, Course course = null) : base(viewModel)
        {
            InitializeComponent();
            _course = course ?? new Course();
            DataContext = _course;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.NavigationService.GoBack();
        }

        private void BtnCommit_Click(object sender, RoutedEventArgs e)
        {
            if (FormValid())
            {
                _course.Name = TbName.Text.Trim();
                _course.ECTS = int.Parse(TbECTS.Text.Trim());
                if(_course.Id == 0)
                {
                    CourseViewModel.Courses.Add(_course);
                    Frame.Navigate(new ListCoursePage(CourseViewModel) { Frame = Frame });
                }
                else
                {
                    CourseViewModel.Update(_course);

                    Frame.NavigationService.GoBack();
                }
               
            }
        }

        private bool FormValid()
        {
            bool valid = true;
            GridContainer.Children.OfType<TextBox>().ToList().ForEach(e =>
            {
                if (string.IsNullOrEmpty(e.Text.Trim()) || "Int".Equals(e.Tag) && !int.TryParse(e.Text.Trim(), out int r))
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
    }
}
