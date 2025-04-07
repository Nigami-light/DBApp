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
using DBApp.dbEntityClasses;
using DBApp.Windows;

namespace DBApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для StudentsPage.xaml
    /// </summary>
    public partial class StudentsPage : Page
    {
        readonly Database database = new();
        public StudentsPage()
        {
            InitializeComponent();
            LoadStudentData();
        }

        private void LoadStudentData()
        {
            try
            {
                var students = database.GetStudents();
                StudentsDG.ItemsSource = students;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            AddStudent addWindow = new();
            addWindow.ShowDialog();
            LoadStudentData();
        }

        private void Remove_btn_Click(object sender, RoutedEventArgs e)
        {
            var selectedStudent = StudentsDG.SelectedItem as Student;

            if (selectedStudent != null)
            {
                var result = MessageBox.Show($"Удалить студента {selectedStudent.FirstName} {selectedStudent.LastName}?",
                                             "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        database.DeleteStudent(selectedStudent.StudentID); // вызываем метод для удаления
                        LoadStudentData(); // обновляем DataGrid
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при удалении: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите студента для удаления.");
            }
        }

        private void StudentsDG_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "StudentID") 
                e.Cancel = true;
        }   
    }
}
