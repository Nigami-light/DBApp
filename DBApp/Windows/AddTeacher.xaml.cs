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
using System.Windows.Shapes;
using DBApp.dbEntityClasses;

namespace DBApp.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddTeacher.xaml
    /// </summary>
    public partial class AddTeacher : Window
    {
        public Database database = new();
        public AddTeacher()
        {
            InitializeComponent();
        }

        private void AddTeacherBtn_Click(object sender, RoutedEventArgs e)
        {
            string firstName = FirstNameTB.Text;
            string lastName = LastNameTB.Text;
            string email = EmailTB.Text;

            if (string.IsNullOrWhiteSpace(firstName))
            {
                    MessageBox.Show("Имя не может быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
            }
            if (string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Фамилия не может быть пустой", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!email.Contains("@"))
            {
                MessageBox.Show("Некорректный фомат почты", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            database.AddTeacher(firstName, lastName, email);

            Teacher teacher = new()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email
            };

            MessageBox.Show("Преподаватель добавлен успешно");

            this.DialogResult = true;
            Close();
        }
    }
}
