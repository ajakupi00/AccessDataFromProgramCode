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
    /// Interaction logic for ListStudentPage.xaml
    /// </summary>
    public partial class ListStudentPage : FramedStudentPage
    {
        public ListStudentPage(StudentViewModel viewModel) : base(viewModel)
        {
            InitializeComponent();
            LvStudents.ItemsSource = viewModel.Students;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new MainMenuPage() { Frame = Frame });
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if(LvStudents.SelectedItem != null)
            {
                Frame.Navigate(new EditStudentPage(new StudentViewModel(), (Student)LvStudents.SelectedItem) { Frame = Frame });
            }
            
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new EditStudentPage(new StudentViewModel()) { Frame = Frame });
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (LvStudents.SelectedItems != null)
            {
                StudentViewModel.Students.Remove((Student)LvStudents.SelectedItem);
            }
        }
    }
}
