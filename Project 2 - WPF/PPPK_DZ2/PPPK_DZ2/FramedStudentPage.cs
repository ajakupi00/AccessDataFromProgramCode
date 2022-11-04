using PPPK_DZ2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PPPK_DZ2
{
    public class FramedStudentPage : Page
    {
        public StudentViewModel StudentViewModel { get; }
        public Frame Frame { get; set; }

        public FramedStudentPage(StudentViewModel viewModel)
        {
            StudentViewModel = viewModel;
        }
    }
}
