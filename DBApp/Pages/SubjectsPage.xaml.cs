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
using DBApp.Windows;
using DBApp.dbEntityClasses;

namespace DBApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для SubjectsPage.xaml
    /// </summary>
    public partial class SubjectsPage : Page
    {
        Database database = new();
        public SubjectsPage()
        {
            InitializeComponent();
            LoadSubjectData();
        }

        private void LoadSubjectData()
        {
            try
            {
                var subjects = database.GetSubjects();
                SubjectsDG.ItemsSource = subjects;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            AddSubject addWindow = new();
            addWindow.ShowDialog();
            LoadSubjectData();
        }

        private void Remove_btn_Click(object sender, RoutedEventArgs e)
        {
            var selectedSubject = SubjectsDG.SelectedItem as Subject;

            if (selectedSubject != null)
            {
                var result = MessageBox.Show($"Удалить предмет {selectedSubject.SubjectName}?",
                                             "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        database.DeleteSubject(selectedSubject.SubjectID);
                        LoadSubjectData();
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

        private void SubjectsDG_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "SubjectID") 
                e.Cancel = true;
        }
    }
}
