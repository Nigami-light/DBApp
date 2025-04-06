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
using DBApp.Pages;

namespace DBApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Students_btn_Click(object sender, RoutedEventArgs e) => CurrentContent_frm.Navigate(new StudentsPage());
        private void Teachers_btn_Click(object sender, RoutedEventArgs e) => CurrentContent_frm.Navigate(new TeachersPage());
        private void Groups_btn_Click(object sender, RoutedEventArgs e) => CurrentContent_frm.Navigate(new GroupsPage());
        private void Subjects_btn_Click(object sender, RoutedEventArgs e) => CurrentContent_frm.Navigate(new SubjectsPage());
    }
}