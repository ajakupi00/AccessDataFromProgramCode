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
    /// Interaction logic for ListProfessorsPage.xaml
    /// </summary>
    public partial class ListProfessorsPage : FramedProfessorPage
    {
        public ListProfessorsPage(ProfessorViewModel viewModel) : base(viewModel)
        {
            InitializeComponent();
            LvProfessors.ItemsSource = viewModel.Professors;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new EditProfessorPage(ProfessorViewModel) { Frame = Frame });
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if(LvProfessors.SelectedItem != null)
            {
                Frame.Navigate(new EditProfessorPage(ProfessorViewModel, (Professor)LvProfessors.SelectedItem) { Frame = Frame });
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(LvProfessors.SelectedItem != null)
            {
                ProfessorViewModel.Professors.Remove(((Professor)LvProfessors.SelectedItem));

            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(new MainMenuPage() { Frame = Frame });
        }
    }
}
