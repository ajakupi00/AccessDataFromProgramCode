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
    /// Interaction logic for MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : FramedPage
    {
        public MainMenuPage()
        {
            InitializeComponent();
        }

        private void BtnCourses_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new ListCoursePage(new ViewModel.CourseViewModel()) { Frame = Frame });
        }

        private void BtnStudents_Click(object sender, RoutedEventArgs e)
        {   
            Frame.Navigate(new ListStudentPage(new ViewModel.StudentViewModel()) { Frame = Frame });
        }

        private void BtnProfessors_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new ListProfessorsPage(new ViewModel.ProfessorViewModel()) { Frame = Frame });

        }
    }
}
