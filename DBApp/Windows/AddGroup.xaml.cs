using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
using System.Windows.Shapes;
using DBApp.dbEntityClasses;

namespace DBApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddGroup.xaml
    /// </summary>
    public partial class AddGroup : Window
    {
        readonly public Database database = new();

        public AddGroup()
        {
            InitializeComponent();
        }

        private void AddGroup_btn_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTB.Text;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Имя не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            database.AddGroup(name);

            DBApp.dbEntityClasses.Group group = new()
            {
                GroupName = name
            };

            MessageBox.Show("Группа добавлена успешно");

            this.DialogResult = true;
            Close();
        }
    }
}
