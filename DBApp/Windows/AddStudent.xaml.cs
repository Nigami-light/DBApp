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
    /// Логика взаимодействия для AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        public Database database = new();
        public Student Student { get; private set; }

        public AddStudent()
        {
            InitializeComponent();
        }

        private void AddStudentBtn_Click(object sender, RoutedEventArgs e)
        {
            string firstName = FirstNameTB.Text;
            string lastName = LastNameTB.Text;
            string email = EmailTB.Text;
            DateTime birthDate = BirthDateDB.SelectedDate.HasValue ?
                BirthDateDB.SelectedDate.Value.Date : DateTime.Now.Date;

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
            if (birthDate > DateTime.Now)
            {
                MessageBox.Show("Дата рождения не может быть в будущем.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!email.Contains("@"))
            {
                MessageBox.Show("Некорректный фомат почты", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            database.AddStudent(firstName, lastName, birthDate, email);

            Student student = new()
            {
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate,
                Email = email
            };

            MessageBox.Show("Студент добавлен успешно");

            this.DialogResult = true;
            Close();
        }
    }
}
