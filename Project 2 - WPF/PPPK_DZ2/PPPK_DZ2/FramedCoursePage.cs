using PPPK_DZ2.Models;
using PPPK_DZ2.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PPPK_DZ2
{
    public class FramedCoursePage : Page
    {
        public CourseViewModel CourseViewModel { get; }
        public Frame Frame { get; set; }

        public FramedCoursePage(CourseViewModel viewModel ) //DEPENDENCY INJECTION
        {
            CourseViewModel = viewModel;
        }
    }
}
