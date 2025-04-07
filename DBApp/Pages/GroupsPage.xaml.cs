using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для GroupsPage.xaml
    /// </summary>
    public partial class GroupsPage : Page
    {
        readonly Database database = new();
        public GroupsPage()
        {
            InitializeComponent();
            LoadGroupData();
        }

        private void LoadGroupData()
        {
            try
            {
                var groups = database.GetGroups();
                GroupsDG.ItemsSource = groups;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            AddGroup addWindow = new();
            addWindow.ShowDialog();
            LoadGroupData();
        }

        private void Remove_btn_Click(object sender, RoutedEventArgs e)
        {
            var selectedGroup = GroupsDG.SelectedItem as DBApp.dbEntityClasses.Group;

            if (selectedGroup != null)
            {
                var result = MessageBox.Show($"Удалить группу {selectedGroup.GroupName}?",
                                             "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        database.DeleteGroup(selectedGroup.GroupID);
                        LoadGroupData();
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

        private void GroupsDG_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "GroupID") 
                e.Cancel = true;
        }
    }
}
