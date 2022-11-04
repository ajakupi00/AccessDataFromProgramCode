using PPPK_DZ2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PPPK_DZ2
{
    public class FramedProfessorPage : Page
    {
        public ProfessorViewModel ProfessorViewModel{ get; set; }
        public Frame Frame { get; set; }

        public FramedProfessorPage(ProfessorViewModel viewModel) 
        {
            ProfessorViewModel = viewModel;
        }
    }
}
