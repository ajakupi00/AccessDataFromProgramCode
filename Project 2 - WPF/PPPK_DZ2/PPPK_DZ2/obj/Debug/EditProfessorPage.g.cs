#pragma checksum "..\..\EditProfessorPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C2DDB0A2EED9AF7192ECE283067B28E6D403F2BF85C66228545D0D9BF8138F22"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PPPK_DZ2;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace PPPK_DZ2 {
    
    
    /// <summary>
    /// EditProfessorPage
    /// </summary>
    public partial class EditProfessorPage : PPPK_DZ2.FramedProfessorPage, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\EditProfessorPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridContainer;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\EditProfessorPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnBack;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\EditProfessorPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbFirstName;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\EditProfessorPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbLastName;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\EditProfessorPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbEmail;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\EditProfessorPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnCommit;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\EditProfessorPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LvCourses;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\EditProfessorPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CbCourses;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\EditProfessorPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAddCourse;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\EditProfessorPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnRemoveCourse;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PPPK_DZ2;component/editprofessorpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EditProfessorPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.GridContainer = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.BtnBack = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\EditProfessorPage.xaml"
            this.BtnBack.Click += new System.Windows.RoutedEventHandler(this.BtnBack_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TbFirstName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TbLastName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.TbEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.BtnCommit = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\EditProfessorPage.xaml"
            this.BtnCommit.Click += new System.Windows.RoutedEventHandler(this.BtnCommit_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.LvCourses = ((System.Windows.Controls.ListView)(target));
            return;
            case 8:
            this.CbCourses = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.BtnAddCourse = ((System.Windows.Controls.Button)(target));
            
            #line 105 "..\..\EditProfessorPage.xaml"
            this.BtnAddCourse.Click += new System.Windows.RoutedEventHandler(this.BtnAddCourse_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.BtnRemoveCourse = ((System.Windows.Controls.Button)(target));
            
            #line 114 "..\..\EditProfessorPage.xaml"
            this.BtnRemoveCourse.Click += new System.Windows.RoutedEventHandler(this.BtnRemoveCourse_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

