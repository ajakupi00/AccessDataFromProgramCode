using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PPPK_DZ2
{
    public class FramedPage : Page
    {
        public Frame Frame { get; set; }
    }
}
/*  <local:FramedPage.Resources>
        <Style TargetType="Button">
            <Setter Property="Width" Value="200"/>
            <Setter Property="FontFamily" Value="Arial"/>
            <Setter Property="Padding" Value="0 15"/>
            <Setter Property="Margin" Value="0 25"/>
        </Style>
    </local:FramedPage.Resources>
    <StackPanel VerticalAlignment="Center" HorizontalAlignment="Center">
        <Button x:Name="BtnCourses" Content="Courses" Click="BtnCourses_Click"/>
        <Button x:Name="BtnStudents" Content="Students" Click="BtnStudents_Click" />
        <Button x:Name="BtnProfessors" Content="Professors" Click="BtnProfessors_Click"/>

    </StackPanel>*/