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
    /// Interaction logic for ListCoursePage.xaml
    /// </summary>
    public partial class ListCoursePage : FramedCoursePage
    {
        public ListCoursePage(CourseViewModel courseViewModel) : base(courseViewModel)
        {
            InitializeComponent();
            LvCourses.ItemsSource = courseViewModel.Courses;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new EditCoursePage(new CourseViewModel(), (Course)LvCourses.SelectedItem) { Frame = Frame});
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(LvCourses.SelectedItems != null)
            {
                CourseViewModel.Courses.Remove((Course)LvCourses.SelectedItem);
            }
            
        }
        

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

            Frame.Navigate(new EditCoursePage(new CourseViewModel()) { Frame = Frame });
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new MainMenuPage() { Frame = Frame});
        }
    }
}
