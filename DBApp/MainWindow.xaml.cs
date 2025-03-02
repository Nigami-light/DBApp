using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DBApp.DBContexts;

namespace DBApp;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void ShowStudentsPG(object sender, RoutedEventArgs e)
    {
        CurrentContent.Navigate(new StudentsPG());
    }

    private void ShowSubjectsPG(object sender, RoutedEventArgs e)
    {
        CurrentContent.Navigate(new SubjectsPG());
    }

    private void ShowTeachersPG(object sender, RoutedEventArgs e)
    {
        CurrentContent.Navigate(new TeachersPG());
    }

    private void ShowGroupsPG(object sender, RoutedEventArgs e)
    {
        CurrentContent.Navigate(new GroupsPG());
    }
}