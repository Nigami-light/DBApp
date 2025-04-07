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
    /// Логика взаимодействия для TeachersPage.xaml
    /// </summary>
    public partial class TeachersPage : Page
    {
        readonly Database database = new();
        public TeachersPage()
        {
            InitializeComponent();
            LoadTeacherData();
        }
        private void LoadTeacherData()
        {
            try
            {
                var teachers = database.GetTeachers();
                TeachersDG.ItemsSource = teachers;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            AddTeacher addWindow = new();
            addWindow.ShowDialog();
            LoadTeacherData();
        }
        
        private void Remove_btn_Click(object sender, RoutedEventArgs e)
        {
            var selectedTeacher = TeachersDG.SelectedItem as Teacher;

            if (selectedTeacher != null)
            {
                var result = MessageBox.Show($"Удалить студента {selectedTeacher.FirstName} {selectedTeacher.LastName}?",
                                             "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        database.DeleteTeacher(selectedTeacher.TeacherID);
                        LoadTeacherData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при удалении: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите преподавателя для удаления");
            }

        }

        private void TeachersDG_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "TeacherID")
                e.Cancel = true;
        }

        
    }
}
